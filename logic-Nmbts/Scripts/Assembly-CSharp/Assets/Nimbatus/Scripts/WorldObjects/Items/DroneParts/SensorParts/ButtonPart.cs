using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.SensorParts
{
	public class ButtonPart : SensorPart
	{
		public tk2dSprite OutputLed;

		private EventKeyBinding _outputBinding;

		private bool _wasTrue;

		public override void FixedUpdate()
		{
			if (RuntimeGlobals.RunningMode != ERunningMode.DroneCustomization)
			{
				base.FixedUpdate();
				if (IsActive() && !_wasTrue)
				{
					OutputLed.color = Color.green;
					_outputBinding.PressKey(true, KeyEventHub);
					_wasTrue = true;
				}
				else if (!_wasTrue)
				{
					OutputLed.color = ColorHelper.BlackAlpha0;
				}
				else
				{
					OutputLed.color = Color.green;
				}
				if (IsBroken && _wasTrue)
				{
					_wasTrue = false;
					_outputBinding.PressKey(false, KeyEventHub);
				}
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
			return new List<KeyBinding>();
		}

		public override List<EventKeyBinding> GetEventBindings()
		{
			_outputBinding = new EventKeyBinding("Output", KeyCode.None, true);
			return new List<EventKeyBinding> { _outputBinding };
		}
	}
}
