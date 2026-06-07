using System.Collections.Generic;
using Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator.Attributes;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.SensorParts
{
	[CustomDronePartEditor]
	public class ProgrammableLED : BindableDronePart
	{
		public tk2dSprite OutputLed;

		private KeyBinding _redBinding;

		private KeyBinding _greenBinding;

		private KeyBinding _blueBinding;

		public override void FixedUpdate()
		{
			base.FixedUpdate();
			if (!RuntimeGlobals.IsMovementBlocked && !RuntimeGlobals.IsGameLoading && !RuntimeGlobals.IsGamePaused && CanControlDrone && !IsBroken)
			{
				bool flag = false;
				bool flag2 = false;
				bool flag3 = false;
				if (_redBinding.KeyCode != KeyCode.None || !string.IsNullOrEmpty(_redBinding.StringCode))
				{
					flag = _redBinding.IsPressed(KeyEventHub);
				}
				if (_blueBinding.KeyCode != KeyCode.None || !string.IsNullOrEmpty(_blueBinding.StringCode))
				{
					flag2 = _blueBinding.IsPressed(KeyEventHub);
				}
				if (_greenBinding.KeyCode != KeyCode.None || !string.IsNullOrEmpty(_greenBinding.StringCode))
				{
					flag3 = _greenBinding.IsPressed(KeyEventHub);
				}
				OutputLed.color = new Color(flag ? 1 : 0, flag3 ? 1 : 0, flag2 ? 1 : 0);
			}
			else
			{
				OutputLed.color = ColorHelper.BlackAlpha0;
			}
		}

		public override List<KeyBinding> GetKeyBindings()
		{
			_redBinding = new KeyBinding("Red", KeyCode.None);
			_blueBinding = new KeyBinding("Blue", KeyCode.None);
			_greenBinding = new KeyBinding("Green", KeyCode.None);
			return new List<KeyBinding> { _redBinding, _greenBinding, _blueBinding };
		}

		public override NimbatusItemData CreateData()
		{
			return new LEDPartData();
		}
	}
}
