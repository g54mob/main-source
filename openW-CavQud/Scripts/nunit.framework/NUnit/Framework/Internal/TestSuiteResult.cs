using System;
using System.Collections.Generic;
using NUnit.Framework.Interfaces;

namespace NUnit.Framework.Internal
{
	public class TestSuiteResult : TestResult
	{
		private int _passCount;

		private int _failCount;

		private int _skipCount;

		private int _inconclusiveCount;

		private List<ITestResult> _children;

		public override int FailCount => _failCount;

		public override int PassCount => _passCount;

		public override int SkipCount => _skipCount;

		public override int InconclusiveCount => _inconclusiveCount;

		public override bool HasChildren => _children.Count != 0;

		public override IEnumerable<ITestResult> Children => _children;

		public TestSuiteResult(TestSuite suite)
			: base(suite)
		{
			_children = new List<ITestResult>();
		}

		public virtual void AddResult(ITestResult result)
		{
			if (Children is IList<ITestResult> list)
			{
				list.Add(result);
				if (base.ResultState != ResultState.Cancelled)
				{
					switch (result.ResultState.Status)
					{
					case TestStatus.Passed:
						if (base.ResultState.Status == TestStatus.Inconclusive)
						{
							SetResult(ResultState.Success);
						}
						break;
					case TestStatus.Failed:
						if (base.ResultState.Status != TestStatus.Failed)
						{
							SetResult(ResultState.ChildFailure, TestResult.CHILD_ERRORS_MESSAGE);
						}
						break;
					case TestStatus.Skipped:
						if (result.ResultState.Label == "Ignored" && (base.ResultState.Status == TestStatus.Inconclusive || base.ResultState.Status == TestStatus.Passed))
						{
							SetResult(ResultState.Ignored, TestResult.CHILD_IGNORE_MESSAGE);
						}
						break;
					}
				}
				InternalAssertCount += result.AssertCount;
				_passCount += result.PassCount;
				_failCount += result.FailCount;
				_skipCount += result.SkipCount;
				_inconclusiveCount += result.InconclusiveCount;
				return;
			}
			throw new NotSupportedException("cannot add results to Children");
		}
	}
}
