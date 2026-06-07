using UnityEngine;

namespace MG_BlocksEngine2.Block.Instruction
{
	public class BE2_Ins_RotateAxis : BE2_InstructionBase, I_BE2_Instruction
	{
		private I_BE2_BlockSectionHeaderInput _input0;

		private string _axisString;

		private I_BE2_BlockSectionHeaderInput _input1;

		public new void Function()
		{
			_input0 = base.Section0Inputs[0];
			_input1 = base.Section0Inputs[1];
			_axisString = _input0.StringValue;
			switch (_axisString)
			{
			case "X axis":
				base.TargetObject.Transform.Rotate(Vector3.right, _input1.FloatValue);
				break;
			case "Y axis":
				base.TargetObject.Transform.Rotate(Vector3.up, _input1.FloatValue);
				break;
			case "Z axis":
				base.TargetObject.Transform.Rotate(Vector3.forward, _input1.FloatValue);
				break;
			default:
				base.TargetObject.Transform.Rotate(Vector3.up, _input1.FloatValue);
				break;
			}
			ExecuteNextInstruction();
		}
	}
}
