using System.Collections.Generic;
using Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator.Attributes;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Assets.Nimbatus.Scripts.WorldObjects.Items.Selection;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.SensorParts
{
	[CustomDronePartEditor]
	public class LEDPart : BindableDronePart
	{
		public Color Color;

		public tk2dSprite OutputLed;

		private KeyBinding _inputBinding;

		protected override void Start()
		{
			base.Start();
			OutputLed.color = ColorHelper.BlackAlpha0;
		}

		public override void FixedUpdate()
		{
			base.FixedUpdate();
			if (!RuntimeGlobals.IsMovementBlocked && !RuntimeGlobals.IsGameLoading && !RuntimeGlobals.IsGamePaused && CanControlDrone && !IsBroken)
			{
				if (_inputBinding.KeyCode != KeyCode.None || !string.IsNullOrEmpty(_inputBinding.StringCode))
				{
					bool flag = _inputBinding.IsPressed(KeyEventHub);
					OutputLed.color = (flag ? Color : ColorHelper.BlackAlpha0);
				}
			}
			else
			{
				OutputLed.color = ColorHelper.BlackAlpha0;
			}
			if (RuntimeGlobals.RunningMode == ERunningMode.DroneCustomization)
			{
				OutputLed.color = Color;
			}
			if (RuntimeGlobals.RunningMode == ERunningMode.DroneCustomization && ItemSelector.IsSelected(this))
			{
				OutputLed.color = ColorHelper.BlackAlpha0;
			}
		}

		public override List<KeyBinding> GetKeyBindings()
		{
			_inputBinding = new KeyBinding("Input", KeyCode.None);
			return new List<KeyBinding> { _inputBinding };
		}

		public override NimbatusItemData CreateData()
		{
			return new LEDPartData();
		}

		public override void FillUpData(ref NimbatusItemData data)
		{
			base.FillUpData(ref data);
			LEDPartData lEDPartData = data as LEDPartData;
			if (lEDPartData != null)
			{
				lEDPartData.Color = Color;
			}
		}

		public override void Load(NimbatusItemData data)
		{
			base.Load(data);
			LEDPartData lEDPartData = data as LEDPartData;
			if (lEDPartData != null)
			{
				Color = lEDPartData.Color;
			}
		}
	}
}
