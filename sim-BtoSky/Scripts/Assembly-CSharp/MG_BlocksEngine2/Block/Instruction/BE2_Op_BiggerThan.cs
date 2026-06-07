namespace MG_BlocksEngine2.Block.Instruction
{
	public class BE2_Op_BiggerThan : BE2_InstructionBase, I_BE2_Instruction
	{
		private I_BE2_BlockSectionHeaderInput _input0;

		private I_BE2_BlockSectionHeaderInput _input1;

		private BE2_InputValues _v0;

		private BE2_InputValues _v1;

		public new string Operation()
		{
			_input0 = base.Section0Inputs[0];
			_input1 = base.Section0Inputs[1];
			_v0 = _input0.InputValues;
			_v1 = _input1.InputValues;
			if (_v0.isText || _v1.isText)
			{
				if (_v0.stringValue.Length <= _v1.stringValue.Length)
				{
					return "0";
				}
				return "1";
			}
			if (!(_v0.floatValue > _v1.floatValue))
			{
				return "0";
			}
			return "1";
		}
	}
}
