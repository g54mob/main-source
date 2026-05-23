using MG_BlocksEngine2.Block.Instruction;

public class BE2_Cst_TestBlock2 : BE2_InstructionBase, I_BE2_Instruction
{
	public new void Function()
	{
		ExecuteNextInstruction();
	}

	public new string Operation()
	{
		return "";
	}
}
