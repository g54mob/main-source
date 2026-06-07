using UnityEngine;

namespace MG_BlocksEngine2.Block.Instruction
{
	public class BE2_Ins_TurnDirection : BE2_InstructionBase, I_BE2_Instruction
	{
		private I_BE2_BlockSectionHeaderInput _input0;

		private string _value;

		private Vector3 _axis = Vector3.up;

		public new void Function()
		{
			_input0 = base.Section0Inputs[0];
			_value = _input0.StringValue;
			if (_value == "Left")
			{
				base.TargetObject.Transform.Rotate(_axis, -90f);
			}
			else if (_value == "Right")
			{
				base.TargetObject.Transform.Rotate(_axis, 90f);
			}
			ExecuteNextInstruction();
		}
	}
}
