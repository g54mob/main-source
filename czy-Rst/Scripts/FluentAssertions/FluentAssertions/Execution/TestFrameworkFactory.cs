using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions.Configuration;

namespace FluentAssertions.Execution
{
	internal static class TestFrameworkFactory
	{
		private static readonly Dictionary<TestFramework, ITestFramework> Frameworks = new Dictionary<TestFramework, ITestFramework>
		{
			[TestFramework.MSpec] = new MSpecFramework(),
			[TestFramework.NUnit] = new NUnitTestFramework(),
			[TestFramework.MsTest] = new MSTestFrameworkV2(),
			[TestFramework.TUnit] = new TUnitFramework(),
			[TestFramework.XUnit2] = new XUnitTestFramework("xunit.assert"),
			[TestFramework.XUnit3] = new XUnitTestFramework("xunit.v3.assert")
		};

		public static ITestFramework GetFramework(TestFramework? testFrameWork)
		{
			ITestFramework testFramework = null;
			if (testFrameWork.HasValue)
			{
				testFramework = AttemptToDetectUsingSetting(testFrameWork.Value);
			}
			if (testFramework == null)
			{
				testFramework = AttemptToDetectUsingDynamicScanning();
			}
			return testFramework ?? new FallbackTestFramework();
		}

		private static ITestFramework AttemptToDetectUsingSetting(TestFramework framework)
		{
			if (!Frameworks.TryGetValue(framework, out var value))
			{
				string text = string.Join(", ", Frameworks.Keys);
				throw new InvalidOperationException($"FluentAssertions was configured to use the test framework '{framework}' but this is not supported. " + "Please use one of the supported frameworks: " + text + ".");
			}
			if (!value.IsAvailable)
			{
				string text2 = string.Join(", ", Frameworks.Keys);
				string arg = ((value is LateBoundTestFramework lateBoundTestFramework) ? ("the required assembly '" + lateBoundTestFramework.AssemblyName + "' could not be found") : "it could not be found");
				throw new InvalidOperationException($"FluentAssertions was configured to use the test framework '{framework}' but {arg}. " + "Please use one of the supported frameworks: " + text2 + ".");
			}
			return value;
		}

		private static ITestFramework AttemptToDetectUsingDynamicScanning()
		{
			return Frameworks.Values.FirstOrDefault((ITestFramework framework) => framework.IsAvailable);
		}
	}
}
