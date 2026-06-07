using System;

namespace ModApi.GameLoop
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
	public sealed class GameLoopExecutionOrderAttribute : Attribute
	{
		public const int DefaultExecutionOrder = 0;

		public int ExecutionOrder;

		public GameLoopExecutionOrderAttribute(int executionOrder)
		{
			ExecutionOrder = executionOrder;
		}
	}
}
