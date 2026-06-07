using System;
using MG_BlocksEngine2.Block.Instruction;

public class Block_DeployParachute : BE2_InstructionBase, I_BE2_Instruction
{
	public static event Action OnParachuteDeploy;

	public new void Function()
	{
		Block_DeployParachute.OnParachuteDeploy?.Invoke();
		ExecuteNextInstruction();
	}
}
