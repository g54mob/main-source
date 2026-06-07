using System.Collections.Generic;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator.Attributes;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.SensorParts
{
	public class SpeedSensor : SensorPart
	{
		private const int MinTolerance = 0;

		private const int MaxTolerance = 300;

		[HideInInspector]
		[IntSetting("DronePartSettings/Limit", 0, 300, 31, UndoManager.EStoreReason.SpeedSensor)]
		public int Tolerance = 10;

		public Renderer SpeedZone;

		public GameObject SpeedDisplay;

		private EventKeyBinding _speedZoneBinding;

		private bool _speedZonePressed;

		public override List<KeyBinding> GetKeyBindings()
		{
			return new List<KeyBinding>();
		}

		protected override void Validate()
		{
			base.Validate();
			Tolerance = Mathf.Clamp(Tolerance, 0, 300);
		}

		public override void FixedUpdate()
		{
			if (RuntimeGlobals.RunningMode == ERunningMode.DroneCustomization)
			{
				return;
			}
			base.FixedUpdate();
			float magnitude = Rigidbody.velocity.magnitude;
			SpeedZone.material.SetFloat("_Cutoff", 0.0033333334f * magnitude);
			Vector3 localPosition = SpeedDisplay.transform.localPosition;
			localPosition.x = -1.3f + 0.017333332f * (float)Tolerance;
			SpeedDisplay.transform.localPosition = localPosition;
			if (IsActive())
			{
				if (Rigidbody.velocity.magnitude > (float)Tolerance)
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
			if (_speedZonePressed != press)
			{
				_speedZoneBinding.PressKey(press, KeyEventHub);
				_speedZonePressed = press;
				SpeedZone.material.color = (press ? Color.green : Color.red);
			}
		}

		public override string GetDetailedTooltip()
		{
			string text = base.GetDetailedTooltip() + LabelHelper.NewLine;
			return text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/SpeedLimit") + ": " + LabelHelper.Orange + Tolerance + " m/s";
		}

		public override void OnDisable()
		{
			base.OnDisable();
			PressKey(false);
		}

		public override List<EventKeyBinding> GetEventBindings()
		{
			_speedZoneBinding = new EventKeyBinding("Speed Reached", KeyCode.None, true);
			return new List<EventKeyBinding> { _speedZoneBinding };
		}

		public override NimbatusItemData CreateData()
		{
			return new SpeedSensorData();
		}

		public override void FillUpData(ref NimbatusItemData data)
		{
			base.FillUpData(ref data);
			SpeedSensorData speedSensorData = data as SpeedSensorData;
			if (speedSensorData != null)
			{
				speedSensorData.Tolerance = Tolerance;
			}
		}

		public override void Load(NimbatusItemData data)
		{
			base.Load(data);
			SpeedSensorData speedSensorData = data as SpeedSensorData;
			if (speedSensorData != null)
			{
				Tolerance = speedSensorData.Tolerance;
			}
		}
	}
}
