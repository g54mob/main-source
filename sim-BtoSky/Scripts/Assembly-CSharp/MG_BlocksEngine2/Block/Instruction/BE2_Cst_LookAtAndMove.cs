using UnityEngine;

namespace MG_BlocksEngine2.Block.Instruction
{
	public class BE2_Cst_LookAtAndMove : BE2_InstructionBase, I_BE2_Instruction
	{
		private bool _firstPlay = true;

		private float _timer;

		private int _counter;

		private Vector3 _initialPosition;

		private Quaternion _initialRotation;

		private Vector3 _direction;

		public new bool ExecuteInUpdate => true;

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
				_initialPosition = base.TargetObject.Transform.position;
				_initialRotation = base.TargetObject.Transform.rotation;
				_direction = GetDirection(base.Section0Inputs[0].StringValue);
				_firstPlay = false;
			}
			if ((float)_counter < Mathf.Abs(base.Section0Inputs[1].FloatValue))
			{
				if (_timer <= 1f)
				{
					_timer += Time.deltaTime / 0.2f;
					base.TargetObject.Transform.position = Vector3.Lerp(_initialPosition, _initialPosition + base.TargetObject.Transform.forward * (base.Section0Inputs[1].FloatValue / Mathf.Abs(base.Section0Inputs[1].FloatValue)), _timer);
					base.TargetObject.Transform.rotation = Quaternion.Lerp(_initialRotation, Quaternion.LookRotation(_direction), _timer);
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

		private Vector3 GetDirection(string option)
		{
			return option switch
			{
				"Up" => Vector3.forward, 
				"Down" => Vector3.back, 
				"Right" => Vector3.right, 
				"Left" => Vector3.left, 
				_ => Vector3.zero, 
			};
		}
	}
}
