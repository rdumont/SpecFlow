using System;
using System.Reflection;
using System.Threading;
using TechTalk.SpecFlow.Utils;

namespace TechTalk.SpecFlow
{
    public interface ITestRunnerManager
    {
        //ITestRunner CreateTestRunner();

        ITestRunner GetTestRunnerFor(Assembly testAssembly);
        ITestRunner GetTestRunnerForCallingAssembly();
    }

    public class TestRunnerManager : ITestRunnerManager
    {
        private static readonly object instanceSynchRoot = new object();
        private static ITestRunnerManager instance = null;

        public static ITestRunnerManager Instance
        {
            get
            {
                return SynchronizationHelper.GetOrCreate(ref instance, instanceSynchRoot, () => RuntimeContainer.CreateDefaultContainer().Resolve<ITestRunnerManager>());
            }
            // for testing
            internal set { instance = value; }
        }

        private ITestRunnerFactory testRunnerFactory;

        public TestRunnerManager(ITestRunnerFactory testRunnerFactory)
        {
            this.testRunnerFactory = testRunnerFactory;
        }

        public ITestRunner GetTestRunnerFor(Assembly testAssembly)
        {
            return testRunnerFactory.CreateTestRunner(null);
//            List<Assembly> bindingAssemblies = new List<Assembly>();
//            bindingAssemblies.Add(callingAssembly);
//
//            bindingAssemblies.AddRange(configuration.AdditionalStepAssemblies);

            //return ObjectContainer.EnsureTestRunner(Assembly.GetCallingAssembly());
            throw new NotImplementedException();
        }

        public ITestRunner GetTestRunnerForCallingAssembly()
        {
            Assembly callingAssembly = Assembly.GetCallingAssembly();
            return GetTestRunnerFor(callingAssembly);
        }

        //this method is used by the generated test classes, do not change!
        public static ITestRunner GetTestRunner()
        {
            Assembly callingAssembly = Assembly.GetCallingAssembly();
            return Instance.GetTestRunnerFor(callingAssembly);
        }
    }
}