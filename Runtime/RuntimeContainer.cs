using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniDi;

namespace TechTalk.SpecFlow
{
    internal class RuntimeContainer
    {
        static public IObjectContainer CreateDefaultContainer()
        {
            MiniDi.ObjectContainer container = new MiniDi.ObjectContainer();

            //TODO: init with default
            InitContainerWithDefaults(container);

            //TODO: process normal config
            //TODO: process advanced config

            return container;
        }

        static private void InitContainerWithDefaults(IObjectContainer container)
        {
            container.RegisterTypeAs<TestRunnerManager, ITestRunnerManager>();
            container.RegisterTypeAs<TestRunnerFactory, ITestRunnerFactory>();
            container.RegisterTypeAs<TestRunner, ITestRunner>();
        }
    }
}
