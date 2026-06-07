using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.SensorParts
{
	public class NotGate : SensorPart
	{
		public tk2dSprite OutputLed;

		public tk2dSprite InputLed;

		private EventKeyBinding _outputBinding;

		private KeyBinding _inputBinding;

		private bool _wasTrue;

		public override void FixedUpdate()
		{
			if (RuntimeGlobals.RunningMode == ERunningMode.DroneCustomization)
			{
				return;
			}
			base.FixedUpdate();
			if (IsActive())
			{
				if (_inputBinding.KeyCode != KeyCode.None || !string.IsNullOrEmpty(_inputBinding.StringCode))
				{
					bool flag = _inputBinding.IsPressed(KeyEventHub);
					InputLed.color = (flag ? Color.green : Color.red);
					OutputLed.color = ((!flag) ? Color.green : Color.red);
					if (!flag)
					{
						if (!_wasTrue)
						{
							_outputBinding.PressKey(true, KeyEventHub);
							_wasTrue = true;
						}
					}
					else if (_wasTrue)
					{
						_outputBinding.PressKey(false, KeyEventHub);
						_wasTrue = false;
					}
				}
			}
			else
			{
				InputLed.color = Color.red;
				OutputLed.color = Color.red;
			}
			if (IsBroken && _wasTrue)
			{
				_outputBinding.PressKey(false, KeyEventHub);
				_wasTrue = false;
			}
		}

		public override void OnDisable()
		{
			base.OnDisable();
			if (_wasTrue)
			{
				_outputBinding.PressKey(false, KeyEventHub);
			}
		}

		public override List<KeyBinding> GetKeyBindings()
		{
			_inputBinding = new KeyBinding("Input", KeyCode.None);
			return new List<KeyBinding> { _inputBinding };
		}

		public override List<EventKeyBinding> GetEventBindings()
		{
			_outputBinding = new EventKeyBinding("Output", KeyCode.None, true);
			return new List<EventKeyBinding> { _outputBinding };
		}
	}
}
