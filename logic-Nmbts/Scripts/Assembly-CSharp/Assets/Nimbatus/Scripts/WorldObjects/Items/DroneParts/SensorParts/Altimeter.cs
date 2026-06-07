using System.Collections.Generic;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator.Attributes;
using Assets.Nimbatus.Scripts.GalaxyMap.CombatArena;
using Assets.Nimbatus.Scripts.GalaxyMap.SumoArena;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World;
using Assets.Nimbatus.Scripts.World.Terrain.ClimateZone;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.SensorParts
{
	public class Altimeter : SensorPart
	{
		private const int MinAltitude = -100;

		private const int MaxAltitude = 100;

		[HideInInspector]
		[IntSetting("DronePartSettings/Altitude", -100, 100, 101, UndoManager.EStoreReason.AltimeterHeight)]
		public int Altitude;

		private const int MinTolerance = 0;

		private const int MaxTolerance = 200;

		[HideInInspector]
		[IntSetting("DronePartSettings/Tolerance", 0, 200, 101, UndoManager.EStoreReason.AltimeterTolerance)]
		public int Tolerance;

		public Color LowerColor;

		public Color UpperColor;

		private EventKeyBinding _belowEvent;

		private EventKeyBinding _topEvent;

		public Renderer LowerZone;

		public Renderer UpperZone;

		public GameObject AltitudeDisplay;

		private bool _belowPressed;

		private bool _topPressed;

		protected override void Validate()
		{
			base.Validate();
			Tolerance = Mathf.Clamp(Tolerance, 0, 200);
			Altitude = Mathf.Clamp(Altitude, -100, 100);
		}

		public override List<KeyBinding> GetKeyBindings()
		{
			return new List<KeyBinding>();
		}

		public override void FixedUpdate()
		{
			base.FixedUpdate();
			float magnitude = ((Vector2)base.transform.position).magnitude;
			float b = WorldController.TerrainSettings.PlanetSize * 2;
			if (SumoArenaManager.Instance != null)
			{
				b = SumoArenaManager.Instance.CurrentRadius * 2f;
			}
			if (CombatArenaManager.Instance != null)
			{
				b = 200f;
			}
			if (RuntimeGlobals.RunningMode == ERunningMode.TestFlightPlanet)
			{
				b = SerializableMonobehaviour<NimbatusClimateZoneManager, ClimateZoneManagerSaveData>.Instance.ActiveClimateZone.SelectedSettings.PlanetSize * 2;
			}
			int num = -100;
			int num2 = 100;
			float t = Mathf.Clamp01(Mathf.InverseLerp(0f, b, magnitude));
			float num3 = Mathf.Lerp(num, num2, t);
			LowerZone.material.SetFloat("_Cutoff", ((float)(100 - Altitude) + (float)Tolerance / 2f) * 0.005f);
			UpperZone.material.SetFloat("_Cutoff", ((float)(100 + Altitude) + (float)Tolerance / 2f) * 0.005f);
			Vector3 localPosition = AltitudeDisplay.transform.localPosition;
			localPosition.y = num3 * 0.01f * 1.2f;
			AltitudeDisplay.transform.localPosition = localPosition;
			if (IsActive())
			{
				if (num3 >= (float)Altitude + (float)Tolerance / 2f)
				{
					PressLowerKey(false);
					PressUpperKey(true);
				}
				else if (num3 < (float)Altitude - (float)Tolerance / 2f)
				{
					PressLowerKey(true);
					PressUpperKey(false);
				}
				else
				{
					PressLowerKey(false);
					PressUpperKey(false);
				}
			}
			if (IsBroken)
			{
				PressLowerKey(false);
				PressUpperKey(false);
			}
		}

		private void PressLowerKey(bool press)
		{
			if (_belowPressed != press)
			{
				_belowEvent.PressKey(press, KeyEventHub);
				_belowPressed = press;
				LowerZone.material.color = (press ? Color.green : LowerColor);
			}
		}

		private void PressUpperKey(bool press)
		{
			if (_topPressed != press)
			{
				_topEvent.PressKey(press, KeyEventHub);
				_topPressed = press;
				UpperZone.material.color = (press ? Color.green : UpperColor);
			}
		}

		public override void OnDisable()
		{
			base.OnDisable();
			if (_belowPressed)
			{
				_belowEvent.PressKey(false, KeyEventHub);
				_belowPressed = false;
			}
			if (_topPressed)
			{
				_topEvent.PressKey(false, KeyEventHub);
				_topPressed = false;
			}
		}

		public override List<EventKeyBinding> GetEventBindings()
		{
			_topEvent = new EventKeyBinding("Higher", KeyCode.None);
			_belowEvent = new EventKeyBinding("Lower", KeyCode.None);
			return new List<EventKeyBinding> { _topEvent, _belowEvent };
		}

		public override string GetDetailedTooltip()
		{
			string text = base.GetDetailedTooltip() + LabelHelper.NewLine;
			text = text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/Altitude") + ": " + LabelHelper.Orange + Altitude + " %" + LabelHelper.NewLine;
			return text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/Tolerance") + ": " + LabelHelper.Orange + Tolerance + " %";
		}

		public override NimbatusItemData CreateData()
		{
			return new AltimeterData();
		}

		public override void FillUpData(ref NimbatusItemData data)
		{
			base.FillUpData(ref data);
			AltimeterData altimeterData = data as AltimeterData;
			if (altimeterData != null)
			{
				altimeterData.Altitude = Altitude;
				altimeterData.Tolerance = Tolerance;
			}
		}

		public override void Load(NimbatusItemData data)
		{
			base.Load(data);
			AltimeterData altimeterData = data as AltimeterData;
			if (altimeterData != null)
			{
				Altitude = altimeterData.Altitude;
				Tolerance = altimeterData.Tolerance;
			}
		}
	}
}
