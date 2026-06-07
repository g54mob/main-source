using ModApi.Craft.Program.Craft;
using ModApi.Craft.Program.Expressions;
using ModApi.Craft.Program.Instructions;

namespace ModApi.Craft.Program
{
	public interface IThreadContext
	{
		int CallStackSize { get; }

		ICraftService Craft { get; }

		double DeltaTime { get; }

		ILogService Log { get; }

		ProgramInstruction NextInstruction { get; }

		void BreakExecution(BreakExecutionType breakExecutionType);

		Variable CreateLocalVariable(string name);

		CustomExpression GetCustomExpression(string name);

		CustomInstruction GetCustomInstruction(string name);

		double GetInstructionState(ProgramInstruction instruction);

		Variable GetLocalVariable(string name);

		Variable GetOrCreateGlobalVariable(string name);

		bool HasInstructionState(ProgramInstruction instruction);

		StackFrame PopStackFrame();

		void PushStackFrame(ProgramInstruction returnInstruction);

		void SetInstructionState(ProgramInstruction instruction, double state);
	}
}
