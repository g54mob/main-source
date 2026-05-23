using MG_BlocksEngine2.Block.Instruction;
using MG_BlocksEngine2.Environment;
using UnityEngine.Events;

namespace MG_BlocksEngine2.Core
{
	public interface I_BE2_BlocksStack
	{
		I_BE2_TargetObject TargetObject { get; set; }

		bool IsActive { get; set; }

		int OverflowGuard { get; set; }

		int Pointer { get; set; }

		I_BE2_Instruction TriggerInstruction { get; }

		I_BE2_Instruction[] InstructionsArray { get; set; }

		UnityEvent<I_BE2_Instruction> OnFunctionStart { get; set; }

		bool IsStepPlay { get; }

		UnityEvent OnStackStart { get; set; }

		UnityEvent OnStackLastBlockExecuted { get; set; }

		void Execute();

		void PopulateStack();

		void StepPlay();

		void Pause();
	}
}
