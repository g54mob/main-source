using System.Collections.Generic;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator.Attributes;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.SensorParts
{
	public class TemperatureSensor : SensorPart
	{
		private const int MinTolerance = -100;

		private const int MaxTolerance = 100;

		[HideInInspector]
		[IntSetting("DronePartSettings/TemperatureLimit", -100, 100, 200, UndoManager.EStoreReason.TemperatureSensorTolerance)]
		public int Tolerance = 10;

		public Renderer TemperatureZone;

		public GameObject TemperatureIndicator;

		private EventKeyBinding _keyBinding;

		private bool _keyPressed;

		public override List<KeyBinding> GetKeyBindings()
		{
			return new List<KeyBinding>();
		}

		protected override void Validate()
		{
			base.Validate();
			Tolerance = Mathf.Clamp(Tolerance, -100, 100);
		}

		public override void FixedUpdate()
		{
			if (RuntimeGlobals.RunningMode == ERunningMode.DroneCustomization)
			{
				return;
			}
			base.FixedUpdate();
			float currentTemperature = HealthPool.CurrentTemperature;
			float value = Mathf.InverseLerp(-140f, 140f, currentTemperature);
			value = Mathf.Clamp01(value);
			TemperatureZone.material.SetFloat("_Cutoff", value);
			float value2 = Mathf.InverseLerp(-100f, 100f, Tolerance);
			value2 = Mathf.Clamp01(value2);
			Vector3 localPosition = TemperatureIndicator.transform.localPosition;
			localPosition.x = -1.3f + value2 * 2.6f;
			TemperatureIndicator.transform.localPosition = localPosition;
			if (IsActive())
			{
				if (HealthPool.CurrentTemperature > (float)Tolerance)
				{
					PressKey(true);
				}
				else
				{
					PressKey(false);
				}
			}
			if (IsBroken)
			{
				PressKey(false);
			}
		}

		private void PressKey(bool press)
		{
			if (_keyPressed != press)
			{
				_keyBinding.PressKey(press, KeyEventHub);
				_keyPressed = press;
				TemperatureZone.material.color = (press ? Color.green : Color.red);
			}
		}

		public override string GetDetailedTooltip()
		{
			string text = base.GetDetailedTooltip() + LabelHelper.NewLine;
			return text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/TemperatureLimit") + ": " + LabelHelper.Orange + Tolerance + " %";
		}

		public override void OnDisable()
		{
			base.OnDisable();
			PressKey(false);
		}

		public override List<EventKeyBinding> GetEventBindings()
		{
			_keyBinding = new EventKeyBinding("Temp. Reached", KeyCode.None, true);
			return new List<EventKeyBinding> { _keyBinding };
		}

		public override NimbatusItemData CreateData()
		{
			return new TemperatureSensorData();
		}

		public override void FillUpData(ref NimbatusItemData data)
		{
			base.FillUpData(ref data);
			TemperatureSensorData temperatureSensorData = data as TemperatureSensorData;
			if (temperatureSensorData != null)
			{
				temperatureSensorData.Tolerance = Tolerance;
			}
		}

		public override void Load(NimbatusItemData data)
		{
			base.Load(data);
			TemperatureSensorData temperatureSensorData = data as TemperatureSensorData;
			if (temperatureSensorData != null)
			{
				Tolerance = temperatureSensorData.Tolerance;
			}
		}
	}
}
