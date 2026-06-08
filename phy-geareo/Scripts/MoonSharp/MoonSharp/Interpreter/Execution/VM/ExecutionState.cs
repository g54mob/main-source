using MoonSharp.Interpreter.DataStructs;

namespace MoonSharp.Interpreter.Execution.VM
{
	internal sealed class ExecutionState
	{
		public FastStack<DynValue> ValueStack;

		public FastStack<CallStackItem> ExecutionStack;

		public int InstructionPtr;

		public CoroutineState State;
	}
}
