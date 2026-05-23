using System;
using System.Globalization;

namespace MG_BlocksEngine2.Block.Instruction
{
	public class BE2_Op_Not : BE2_InstructionBase, I_BE2_Instruction
	{
		private I_BE2_BlockSectionHeaderInput _input0;

		private BE2_InputValues _v0;

		public new string Operation()
		{
			_input0 = base.Section0Inputs[0];
			_v0 = _input0.InputValues;
			string stringValue = _v0.stringValue;
			switch (stringValue)
			{
			case "1":
			case "true":
				return "0";
			case "0":
			case "false":
				return "1";
			default:
				if (_v0.isText)
				{
					char[] array = stringValue.ToCharArray();
					Array.Reverse(array);
					return new string(array);
				}
				return (_v0.floatValue * -1f).ToString(CultureInfo.InvariantCulture);
			}
		}
	}
}
