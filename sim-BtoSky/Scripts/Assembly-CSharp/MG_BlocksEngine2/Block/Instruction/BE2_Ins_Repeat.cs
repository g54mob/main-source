namespace MG_BlocksEngine2.Block.Instruction
{
	public class BE2_Ins_Repeat : BE2_InstructionBase, I_BE2_Instruction
	{
		private I_BE2_BlockSectionHeaderInput _input0;

		private int _counter;

		private float _value;

		protected override void OnButtonStop()
		{
			_counter = 0;
		}

		public override void OnStackActive()
		{
			_counter = 0;
		}

		public new void Function()
		{
			_input0 = base.Section0Inputs[0];
			_value = _input0.FloatValue;
			if ((float)_counter != _value)
			{
				_counter++;
				ExecuteSection(0);
			}
			else
			{
				_counter = 0;
				ExecuteNextInstruction();
			}
		}

		public new void Reset()
		{
			_counter = 0;
		}
	}
}
