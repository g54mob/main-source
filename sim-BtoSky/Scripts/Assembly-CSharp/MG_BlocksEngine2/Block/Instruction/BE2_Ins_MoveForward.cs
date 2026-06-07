namespace MG_BlocksEngine2.Block.Instruction
{
	public class BE2_Ins_MoveForward : BE2_InstructionBase, I_BE2_Instruction
	{
		private I_BE2_BlockSectionHeaderInput _input0;

		private float _value;

		public new void Function()
		{
			_input0 = base.Section0Inputs[0];
			_value = _input0.FloatValue;
			base.TargetObject.Transform.position += base.TargetObject.Transform.forward * _value;
			ExecuteNextInstruction();
		}
	}
}
