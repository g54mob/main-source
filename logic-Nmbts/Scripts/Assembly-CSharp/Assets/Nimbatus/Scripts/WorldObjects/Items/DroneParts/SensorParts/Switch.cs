using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.SensorParts
{
	public class Switch : SensorPart
	{
		public tk2dSprite OutputLed;

		public tk2dSprite InputLed;

		private EventKeyBinding _outputBinding;

		private KeyBinding _toggleBinding;

		private bool _isOutputActive;

		private bool _wasInputActive;

		public override void FixedUpdate()
		{
			if (RuntimeGlobals.RunningMode == ERunningMode.DroneCustomization)
			{
				return;
			}
			base.FixedUpdate();
			if (!RuntimeGlobals.IsMovementBlocked && !RuntimeGlobals.IsGameLoading && !RuntimeGlobals.IsGamePaused && CanControlDrone && !IsBroken)
			{
				if (_toggleBinding.KeyCode != KeyCode.None || !string.IsNullOrEmpty(_toggleBinding.StringCode))
				{
					bool flag = _toggleBinding.IsPressed(KeyEventHub);
					InputLed.color = (flag ? Color.green : Color.red);
					if (flag && !_wasInputActive)
					{
						if (_isOutputActive)
						{
							_outputBinding.PressKey(false, KeyEventHub);
							_isOutputActive = false;
						}
						else
						{
							_outputBinding.PressKey(true, KeyEventHub);
							_isOutputActive = true;
						}
					}
					OutputLed.color = (_isOutputActive ? Color.green : Color.red);
					_wasInputActive = flag;
				}
			}
			else
			{
				InputLed.color = Color.red;
				OutputLed.color = Color.red;
			}
			if (IsBroken && _isOutputActive)
			{
				_outputBinding.PressKey(false, KeyEventHub);
				_isOutputActive = false;
			}
		}

		public override void OnDisable()
		{
			base.OnDisable();
			if (_isOutputActive)
			{
				_outputBinding.PressKey(false, KeyEventHub);
				_isOutputActive = false;
			}
		}

		public override List<KeyBinding> GetKeyBindings()
		{
			_toggleBinding = new KeyBinding("Toggle", KeyCode.None);
			return new List<KeyBinding> { _toggleBinding };
		}

		public override List<EventKeyBinding> GetEventBindings()
		{
			_outputBinding = new EventKeyBinding("Activate", KeyCode.None, true);
			return new List<EventKeyBinding> { _outputBinding };
		}
	}
}
