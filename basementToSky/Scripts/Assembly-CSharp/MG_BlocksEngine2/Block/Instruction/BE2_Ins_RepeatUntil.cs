namespace MG_BlocksEngine2.Block.Instruction
{
	public class BE2_Ins_RepeatUntil : BE2_InstructionBase, I_BE2_Instruction
	{
		private I_BE2_BlockSectionHeaderInput _input0;

		private string _value;

		public new void Function()
		{
			_input0 = base.Section0Inputs[0];
			_value = _input0.StringValue;
			if (_value != "1" && _value != "true")
			{
				ExecuteSection(0);
			}
			else
			{
				ExecuteNextInstruction();
			}
		}
	}
}
