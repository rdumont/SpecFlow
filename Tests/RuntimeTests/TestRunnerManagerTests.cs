using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Moq;
using NUnit.Framework;

namespace TechTalk.SpecFlow.RuntimeTests
{
    [TestFixture]
    public class TestRunnerManagerTests
    {
        private Mock<ITestRunnerFactory> testRunnerFactoryFake;
        private TestRunnerManager testRunnerManager;

        [SetUp]
        public void Setup()
        {
            testRunnerFactoryFake = new Mock<ITestRunnerFactory>();
            testRunnerManager = new TestRunnerManager(testRunnerFactoryFake.Object);
        }

        [Test]
        public void WhenInstanceRetrieved_ShoulBeAbleToResolveFromDefaultContainer()
        {
            // given

            // when
            var instance = TestRunnerManager.Instance;

            // then
            Assert.IsNotNull(instance);
        }

        [Test]
        public void WhenInsatnceRetreivedTwice_ShouldReturnTheSame()
        {
            // given
            var firstInstance = TestRunnerManager.Instance;

            // when
            var secondInstance = TestRunnerManager.Instance;

            // then
            Assert.AreEqual(firstInstance, secondInstance);
        }

        [Test]
        public void WhenGetTestRunnerForCalledWithANewAssembly_ShouldInitializeANewTestRunner()
        {
            // given
            Assembly sampleAssembly = Assembly.GetExecutingAssembly();
            Mock<ITestRunner> testRunnerMock = new Mock<ITestRunner>();
            testRunnerFactoryFake.Setup(s => s.CreateTestRunner(It.IsAny<IEnumerable<Assembly>>())).Returns(testRunnerMock.Object);

            // when
            var result = testRunnerManager.GetTestRunnerFor(sampleAssembly);

            // then
            Assert.AreEqual(testRunnerMock.Object, result);
        }

        [Test]
        public void WhenGetTestRunnerForCalledWithANewAssembly_ShouldInitializeWithBindingAssembliesFromConfig()
        {
            // given
            Assembly sampleAssembly = Assembly.GetExecutingAssembly();
            Mock<ITestRunner> testRunnerMock = new Mock<ITestRunner>();
            testRunnerFactoryFake.Setup(s => s.CreateTestRunner(It.IsAny<IEnumerable<Assembly>>())).Returns(testRunnerMock.Object);

            // when
            var result = testRunnerManager.GetTestRunnerFor(sampleAssembly);

            // then
            //testRunnerFactoryFake.Verify();
        }
    }
}
