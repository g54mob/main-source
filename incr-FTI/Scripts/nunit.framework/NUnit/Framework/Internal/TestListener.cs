using NUnit.Framework.Interfaces;

namespace NUnit.Framework.Internal
{
	public class TestListener : ITestListener
	{
		public static ITestListener NULL => new TestListener();

		public void TestStarted(ITest test)
		{
		}

		public void TestFinished(ITestResult result)
		{
		}

		public void TestOutput(TestOutput output)
		{
		}

		private TestListener()
		{
		}
	}
}
