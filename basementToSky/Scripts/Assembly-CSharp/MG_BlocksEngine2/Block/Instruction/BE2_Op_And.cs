namespace MG_BlocksEngine2.Block.Instruction
{
	public class BE2_Op_And : BE2_InstructionBase, I_BE2_Instruction
	{
		private I_BE2_BlockSectionHeaderInput _input0;

		private I_BE2_BlockSectionHeaderInput _input1;

		private string _vs0;

		private string _vs1;

		public new string Operation()
		{
			_input0 = base.Section0Inputs[0];
			_input1 = base.Section0Inputs[1];
			_vs0 = _input0.StringValue;
			_vs1 = _input1.StringValue;
			if ((!(_vs0 == "1") && !(_vs0 == "true")) || (!(_vs1 == "1") && !(_vs1 == "true")))
			{
				return "0";
			}
			return "1";
		}
	}
}
