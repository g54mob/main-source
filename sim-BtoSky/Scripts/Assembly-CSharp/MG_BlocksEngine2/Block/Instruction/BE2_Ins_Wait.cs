using UnityEngine;

namespace MG_BlocksEngine2.Block.Instruction
{
	public class BE2_Ins_Wait : BE2_InstructionBase, I_BE2_Instruction
	{
		private I_BE2_BlockSectionHeaderInput _input0;

		private bool _firstPlay = true;

		private float _counter;

		public new bool ExecuteInUpdate => true;

		protected override void OnButtonStop()
		{
			_firstPlay = true;
			_counter = 0f;
		}

		public override void OnStackActive()
		{
			_firstPlay = true;
			_counter = 0f;
		}

		public new void Function()
		{
			if (_firstPlay)
			{
				_input0 = base.Section0Inputs[0];
				_counter = _input0.FloatValue;
				_firstPlay = false;
			}
			if (_counter > 0f)
			{
				_counter -= Time.deltaTime;
				return;
			}
			_counter = 0f;
			ExecuteNextInstruction();
			_firstPlay = true;
		}

		public new void Reset()
		{
			_firstPlay = true;
			_counter = 0f;
		}
	}
}
