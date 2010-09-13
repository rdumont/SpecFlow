using System;
using System.Collections.Generic;
using System.Reflection;

namespace TechTalk.SpecFlow
{
    public interface ITestRunnerFactory
    {
        ITestRunner CreateTestRunner(IEnumerable<Assembly> bindingAssemblies);
    }

    public class TestRunnerFactory : ITestRunnerFactory
    {
        public ITestRunner CreateTestRunner(IEnumerable<Assembly> bindingAssemblies)
        {
            throw new NotImplementedException();
        }
    }
}