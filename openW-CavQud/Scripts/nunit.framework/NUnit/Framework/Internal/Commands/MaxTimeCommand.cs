using System.Diagnostics;
using NUnit.Framework.Interfaces;

namespace NUnit.Framework.Internal.Commands
{
	public class MaxTimeCommand : DelegatingTestCommand
	{
		private int maxTime;

		public MaxTimeCommand(TestCommand innerCommand, int maxTime)
			: base(innerCommand)
		{
			this.maxTime = maxTime;
		}

		public override TestResult Execute(ITestExecutionContext context)
		{
			long timestamp = Stopwatch.GetTimestamp();
			TestResult testResult = innerCommand.Execute(context);
			double duration = (double)(Stopwatch.GetTimestamp() - timestamp) / (double)Stopwatch.Frequency;
			testResult.Duration = duration;
			if (testResult.ResultState == ResultState.Success)
			{
				double num = testResult.Duration * 1000.0;
				if (num > (double)maxTime)
				{
					testResult.SetResult(ResultState.Failure, $"Elapsed time of {num}ms exceeds maximum of {maxTime}ms");
				}
			}
			return testResult;
		}
	}
}
