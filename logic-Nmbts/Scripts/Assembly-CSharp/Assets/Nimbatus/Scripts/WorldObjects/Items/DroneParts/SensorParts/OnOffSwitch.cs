using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.SensorParts
{
	public class OnOffSwitch : SensorPart
	{
		public tk2dSprite OutputLed;

		public tk2dSprite InputLedOn;

		public tk2dSprite InputLedOff;

		private EventKeyBinding _outputBinding;

		private KeyBinding _onBinding;

		private KeyBinding _offBinding;

		private bool _isOutputActive;

		public override void FixedUpdate()
		{
			if (RuntimeGlobals.RunningMode == ERunningMode.DroneCustomization)
			{
				return;
			}
			base.FixedUpdate();
			if (!RuntimeGlobals.IsMovementBlocked && !RuntimeGlobals.IsGameLoading && !RuntimeGlobals.IsGamePaused && CanControlDrone && !IsBroken)
			{
				bool flag = false;
				if (_onBinding.KeyCode != KeyCode.None || !string.IsNullOrEmpty(_onBinding.StringCode))
				{
					flag = _onBinding.IsPressed(KeyEventHub);
					InputLedOn.color = (flag ? Color.green : Color.red);
				}
				bool flag2 = false;
				if (_offBinding.KeyCode != KeyCode.None || !string.IsNullOrEmpty(_offBinding.StringCode))
				{
					flag2 = _offBinding.IsPressed(KeyEventHub);
					InputLedOff.color = (flag2 ? Color.green : Color.red);
				}
				bool flag3 = _isOutputActive;
				if (flag)
				{
					flag3 = true;
				}
				else if (flag2)
				{
					flag3 = false;
				}
				if (flag3 && !_isOutputActive)
				{
					_outputBinding.PressKey(true, KeyEventHub);
					_isOutputActive = true;
				}
				else if (!flag3 && _isOutputActive)
				{
					_outputBinding.PressKey(false, KeyEventHub);
					_isOutputActive = false;
				}
				OutputLed.color = (flag3 ? Color.green : Color.red);
				_isOutputActive = flag3;
			}
			else
			{
				InputLedOn.color = Color.red;
				InputLedOff.color = Color.red;
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
			_onBinding = new KeyBinding("On", KeyCode.None);
			_offBinding = new KeyBinding("Off", KeyCode.None);
			return new List<KeyBinding> { _onBinding, _offBinding };
		}

		public override List<EventKeyBinding> GetEventBindings()
		{
			_outputBinding = new EventKeyBinding("Output", KeyCode.None, true);
			return new List<EventKeyBinding> { _outputBinding };
		}
	}
}
