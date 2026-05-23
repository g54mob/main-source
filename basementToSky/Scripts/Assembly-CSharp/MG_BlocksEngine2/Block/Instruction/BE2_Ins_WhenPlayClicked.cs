namespace MG_BlocksEngine2.Block.Instruction
{
	public class BE2_Ins_WhenPlayClicked : BE2_InstructionBase, I_BE2_Instruction
	{
		protected override void OnButtonPlay()
		{
			base.BlocksStack.IsActive = true;
		}

		protected override void OnAwake()
		{
			base.BlocksStack.OnStackLastBlockExecuted.AddListener(EndExecution);
		}

		private void EndExecution()
		{
			base.BlocksStack.IsActive = false;
		}

		public new void Function()
		{
			ExecuteSection(0);
		}
	}
}
