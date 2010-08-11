using System.CodeDom;
using System.Collections.Generic;

namespace TechTalk.SpecFlow.Generator.UnitTestProvider
{
    public class MsTestSilverlightAsyncGeneratorProvider : MsTestSilverlightGeneratorProvider, IExtendedUnitTestGeneratorProvider
    {
        private const string TESTFIXTURE_BASETYPE = "Microsoft.Silverlight.Testing.SilverlightTest";
        private const string ASYNC_ATTR = "Microsoft.Silverlight.Testing.AsynchronousAttribute";
        private const string AFTER_SETUP_PARTIALMETHOD = "OnAfterScenarioSetup";

        public static readonly string CALLING_FEATURE_KEY = "ScenarioContext.CallingFeature";

        public override void SetTestFixture(CodeTypeDeclaration typeDeclaration, string title, string description)
        {
            base.SetTestFixture(typeDeclaration, title, description);
            
            //Use Silverlight test as the base type
            typeDeclaration.BaseTypes.Add(new CodeTypeReference(TESTFIXTURE_BASETYPE));
        }

        public override void SetTest(CodeMemberMethod memberMethod, string title)
        {
            base.SetTest(memberMethod, title);

            memberMethod.CustomAttributes.Add(
                new CodeAttributeDeclaration(
                    new CodeTypeReference(ASYNC_ATTR)));
        }

        #region IExtendedUnitTestGeneratorProvider Members

        public virtual void SetScenarioSetup(CodeMemberMethod memberMethod)
        {
            //ScenarioContext
            var scenarioContext = new CodeTypeReferenceExpression("ScenarioContext");

            // .Current
            var currentContext = new CodePropertyReferenceExpression(scenarioContext, "Current");

            // ["SomeKey"]
            var indexer = new CodeIndexerExpression(currentContext, new CodePrimitiveExpression(CALLING_FEATURE_KEY));

            // = this;
            var assignMent = new CodeAssignStatement(indexer, new CodeThisReferenceExpression());

            //ScenarioContext.Current["SomeKey"] = this;
            memberMethod.Statements.Add(assignMent);
        }

        #endregion
    }
}