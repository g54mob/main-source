using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.SensorParts
{
	public class XNorGate : SensorPart
	{
		public tk2dSprite OutputLed;

		public tk2dSprite InputLed1;

		public tk2dSprite InputLed2;

		private EventKeyBinding _outputBinding;

		private KeyBinding _inputBinding1;

		private KeyBinding _inputBinding2;

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
				bool flag = _inputBinding1.IsPressed(KeyEventHub);
				bool flag2 = _inputBinding2.IsPressed(KeyEventHub);
				InputLed1.color = (flag ? Color.green : Color.red);
				InputLed2.color = (flag2 ? Color.green : Color.red);
				OutputLed.color = ((!(flag2 ^ flag)) ? Color.green : Color.red);
				if (!(flag2 ^ flag))
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
			else
			{
				InputLed1.color = Color.red;
				InputLed2.color = Color.red;
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
			_inputBinding1 = new KeyBinding("Input 1", KeyCode.None);
			_inputBinding2 = new KeyBinding("Input 2", KeyCode.None);
			return new List<KeyBinding> { _inputBinding1, _inputBinding2 };
		}

		public override List<EventKeyBinding> GetEventBindings()
		{
			_outputBinding = new EventKeyBinding("Output", KeyCode.None, true);
			return new List<EventKeyBinding> { _outputBinding };
		}
	}
}
