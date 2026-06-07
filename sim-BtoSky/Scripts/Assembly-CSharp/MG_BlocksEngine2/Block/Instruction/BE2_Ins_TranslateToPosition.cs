using UnityEngine;

namespace MG_BlocksEngine2.Block.Instruction
{
	public class BE2_Ins_TranslateToPosition : BE2_InstructionBase, I_BE2_Instruction
	{
		private I_BE2_BlockSectionHeaderInput _input0;

		private I_BE2_BlockSectionHeaderInput _input1;

		private I_BE2_BlockSectionHeaderInput _input2;

		public new void Function()
		{
			_input0 = base.Section0Inputs[0];
			_input1 = base.Section0Inputs[1];
			_input2 = base.Section0Inputs[2];
			base.TargetObject.Transform.position = new Vector3(_input0.FloatValue, _input1.FloatValue, _input2.FloatValue);
			ExecuteNextInstruction();
		}
	}
}
