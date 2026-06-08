using System;
using NUnit.Framework.Interfaces;

namespace NUnit.Framework.Internal.Commands
{
	public class TestMethodCommand : TestCommand
	{
		private readonly TestMethod testMethod;

		private readonly object[] arguments;

		public TestMethodCommand(TestMethod testMethod)
			: base(testMethod)
		{
			this.testMethod = testMethod;
			arguments = testMethod.Arguments;
		}

		public override TestResult Execute(ITestExecutionContext context)
		{
			object actual = RunTestMethod(context);
			if (testMethod.HasExpectedResult)
			{
				Assert.AreEqual(testMethod.ExpectedResult, actual);
			}
			context.CurrentResult.SetResult(ResultState.Success);
			return context.CurrentResult;
		}

		private object RunTestMethod(ITestExecutionContext context)
		{
			if (AsyncInvocationRegion.IsAsyncOperation(testMethod.Method.MethodInfo))
			{
				return RunAsyncTestMethod(context);
			}
			return RunNonAsyncTestMethod(context);
		}

		private object RunAsyncTestMethod(ITestExecutionContext context)
		{
			using AsyncInvocationRegion asyncInvocationRegion = AsyncInvocationRegion.Create(testMethod.Method.MethodInfo);
			object invocationResult = Reflect.InvokeMethod(testMethod.Method.MethodInfo, context.TestObject, arguments);
			try
			{
				return asyncInvocationRegion.WaitForPendingOperationsToComplete(invocationResult);
			}
			catch (Exception inner)
			{
				throw new NUnitException("Rethrown", inner);
			}
		}

		private object RunNonAsyncTestMethod(ITestExecutionContext context)
		{
			return testMethod.Method.Invoke(context.TestObject, arguments);
		}
	}
}
