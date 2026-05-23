namespace MG_BlocksEngine2.Block.Instruction
{
	public class BE2_Ins_IfElse : BE2_InstructionBase, I_BE2_Instruction
	{
		private I_BE2_BlockSectionHeaderInput _input0;

		private string _value;

		private bool _isFirstPlay = true;

		protected override void OnButtonStop()
		{
			_isFirstPlay = true;
		}

		public override void OnStackActive()
		{
			_isFirstPlay = true;
		}

		public new void Function()
		{
			if (_isFirstPlay)
			{
				_input0 = base.Section0Inputs[0];
				_value = _input0.StringValue;
				if (_value == "1" || _value.ToLower() == "true")
				{
					_isFirstPlay = false;
					ExecuteSection(0);
				}
				else
				{
					_isFirstPlay = false;
					ExecuteSection(1);
				}
			}
			else
			{
				_isFirstPlay = true;
				ExecuteNextInstruction();
			}
		}

		public new void Reset()
		{
			_isFirstPlay = true;
		}
	}
}
