using System.Collections.Generic;
using NUnit.Framework.Interfaces;

namespace NUnit.Framework.Internal
{
	public class TestCaseResult : TestResult
	{
		public override int FailCount => (base.ResultState.Status == TestStatus.Failed) ? 1 : 0;

		public override int PassCount => (base.ResultState.Status == TestStatus.Passed) ? 1 : 0;

		public override int SkipCount => (base.ResultState.Status == TestStatus.Skipped) ? 1 : 0;

		public override int InconclusiveCount => (base.ResultState.Status == TestStatus.Inconclusive) ? 1 : 0;

		public override bool HasChildren => false;

		public override IEnumerable<ITestResult> Children => new ITestResult[0];

		public TestCaseResult(TestMethod test)
			: base(test)
		{
		}
	}
}
