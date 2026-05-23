using MG_BlocksEngine2.Core;

namespace MG_BlocksEngine2.Block.Instruction
{
	public class BE2_Ins_Return : BE2_InstructionBase, I_BE2_Instruction
	{
		public new void Function()
		{
			BE2_ExecutionManager.Instance.Stop();
		}
	}
}
