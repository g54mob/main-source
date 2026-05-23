using UnityEngine;

namespace MG_BlocksEngine2.Block.Instruction
{
	public class BE2_Ins_SlideForward : BE2_InstructionBase, I_BE2_Instruction
	{
		private I_BE2_BlockSectionHeaderInput _input0;

		private float _value;

		private float _absValue;

		private bool _firstPlay = true;

		private float _timer;

		private int _counter;

		private Vector3 _initialPosition;

		public new bool ExecuteInUpdate => true;

		protected override void OnButtonStop()
		{
			_firstPlay = true;
			_timer = 0f;
			_counter = 0;
		}

		public override void OnStackActive()
		{
			_firstPlay = true;
			_timer = 0f;
			_counter = 0;
		}

		public new void Function()
		{
			if (_firstPlay)
			{
				_input0 = base.Section0Inputs[0];
				_value = _input0.FloatValue;
				_absValue = Mathf.Abs(_value);
				_initialPosition = base.TargetObject.Transform.position;
				_firstPlay = false;
			}
			if ((float)_counter < _absValue)
			{
				if (_timer < 1f)
				{
					_timer += Time.deltaTime / 0.2f;
					if (_timer > 1f)
					{
						_timer = 1f;
					}
					base.TargetObject.Transform.position = Vector3.Lerp(_initialPosition, _initialPosition + base.TargetObject.Transform.forward * (_value / _absValue), _timer);
				}
				else
				{
					_timer = 0f;
					_counter++;
					_firstPlay = true;
				}
			}
			else
			{
				ExecuteNextInstruction();
				_counter = 0;
				_timer = 0f;
				_firstPlay = true;
			}
		}
	}
}
