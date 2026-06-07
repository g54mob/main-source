using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.GalaxyMap.LocationSettings;
using Assets.Nimbatus.Scripts.GalaxyMap.Locations;
using Assets.Nimbatus.Scripts.Missions;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World.Terrain.ClimateZone;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Sectors
{
	[Serializable]
	public class SolarSystem : GalaxyMapSector
	{
		public List<LocationData> Locations = new List<LocationData>();

		private SolarSystemSetting _solarSystemPreset;

		private List<EClimateZoneType> _allowedClimateZones;

		private List<EClimateZoneType> _forbiddenClimateZones;

		private int _lastAngle;

		private const int MinDist = 20;

		public EClimateZoneType ClimateZoneType { get; set; }

		public Color SunColor { get; set; }

		public float SunScale { get; set; }

		public EMissionComplexity MissionComplexity { get; set; }

		public EGalaxyComplexity MapComplexity { get; set; }

		protected override void Init(System.Random randomGenerator)
		{
			SolarSystemSetting solarSystemSetting;
			if (_solarSystemPreset != null)
			{
				solarSystemSetting = _solarSystemPreset;
				if (_solarSystemPreset.CustomClimateZone && _solarSystemPreset.ClimateZone != EClimateZoneType.None)
				{
					ClimateZoneType = _solarSystemPreset.ClimateZone;
				}
				else
				{
					ClimateZoneType = SerializableMonobehaviour<NimbatusClimateZoneManager, ClimateZoneManagerSaveData>.Instance.GetRandomClimateZone(randomGenerator);
				}
			}
			else
			{
				solarSystemSetting = SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.GetRandomSolarSystem(randomGenerator, MapComplexity);
				List<EClimateZoneType> list = _allowedClimateZones ?? SerializableMonobehaviour<NimbatusClimateZoneManager, ClimateZoneManagerSaveData>.Instance.GetAllClimateZones().ToList();
				if (_forbiddenClimateZones != null)
				{
					list = list.Where((EClimateZoneType a) => !_forbiddenClimateZones.Contains(a)).ToList();
				}
				if (list.Count <= 0 && _allowedClimateZones != null)
				{
					list = _allowedClimateZones;
				}
				if (list.Count > 0)
				{
					ClimateZoneType = list.RandomItem(randomGenerator);
				}
				if (ClimateZoneType == EClimateZoneType.None)
				{
					ClimateZoneType = SerializableMonobehaviour<NimbatusClimateZoneManager, ClimateZoneManagerSaveData>.Instance.GetRandomClimateZone(randomGenerator);
				}
			}
			SunColor = solarSystemSetting.SunColors.RandomItem(randomGenerator);
			SunScale = (float)(randomGenerator.NextDouble() * 6.0) + 2f;
			base.InfluenceToUnlock = solarSystemSetting.InfluenceToUnlock;
			base.Radius = 0f;
			Locations.Clear();
			for (int num = 0; num < solarSystemSetting.Locations.Count; num++)
			{
				SolarSystemLocationSetting solarSystemLocationSetting = solarSystemSetting.Locations[num];
				LocationData locationData = solarSystemLocationSetting.Location.ToList().RandomItem(randomGenerator).CreateLocation(randomGenerator, this, solarSystemLocationSetting.Difficulty, MissionComplexity);
				locationData.SetPreset(solarSystemLocationSetting.IndividualSetting, randomGenerator);
				int num2 = randomGenerator.Next(0, 360) % 360;
				if (num > 0 && Mathf.Abs(num2 - _lastAngle) < 20)
				{
					num2 = ((num2 >= 90 && (num2 < 180 || num2 >= 270)) ? (num2 + 40) : (num2 - 40));
				}
				_lastAngle = num2;
				int num3 = (num + 2) * 8;
				locationData.Position = new Vector3(Mathf.Cos((float)num2 * ((float)Math.PI / 180f)), Mathf.Sin((float)num2 * ((float)Math.PI / 180f)), 0f).normalized * num3;
				Locations.Add(locationData);
				if (locationData.Position.magnitude > base.Radius)
				{
					base.Radius = locationData.Position.magnitude;
				}
				if (base.Explored)
				{
					locationData.CreateRewards(randomGenerator);
					locationData.CreatePenalties(randomGenerator);
				}
			}
		}

		public LocationData AddLocation(LocationSetting loc, System.Random rnd)
		{
			LocationData locationData = loc.CreateLocation(rnd, this, EMissionDifficulty.None, MissionComplexity);
			locationData.IsSpecialLocation = true;
			int num = rnd.Next(0, 360) % 360;
			if (Mathf.Abs(num - _lastAngle) < 20)
			{
				num = ((num >= 90 && (num < 180 || num >= 270)) ? (num + 40) : (num - 40));
			}
			int num2 = (Locations.Count + 2) * 8;
			locationData.Position = new Vector3(Mathf.Cos((float)num * ((float)Math.PI / 180f)), Mathf.Sin((float)num * ((float)Math.PI / 180f)), 0f).normalized * num2;
			Locations.Add(locationData);
			if (locationData.Position.magnitude > base.Radius)
			{
				base.Radius = locationData.Position.magnitude;
			}
			if (base.Explored)
			{
				locationData.CreateRewards(rnd);
				locationData.CreatePenalties(rnd);
			}
			return locationData;
		}

		public void RemoveLocation(LocationData loc)
		{
			if (Locations.Contains(loc))
			{
				Locations.Remove(loc);
				base.Radius = Locations[Locations.Count - 1].Position.magnitude;
			}
		}

		public void SetPreset(SolarSystemSetting preset)
		{
			_solarSystemPreset = preset;
		}

		public void SetAllowedClimateZones(List<EClimateZoneType> zones)
		{
			_allowedClimateZones = zones;
		}

		public void AddForbiddenClimateZone(EClimateZoneType type)
		{
			if (_forbiddenClimateZones == null)
			{
				_forbiddenClimateZones = new List<EClimateZoneType>();
			}
			if (!_forbiddenClimateZones.Contains(type))
			{
				_forbiddenClimateZones.Add(type);
			}
		}

		public override LocationData GetLocationById(string dataCurrentLocationId)
		{
			return Locations.FirstOrDefault((LocationData l) => l.UniqueId == dataCurrentLocationId);
		}

		public override void PostLoad(Galaxy galaxy)
		{
			base.PostLoad(galaxy);
			foreach (LocationData location in Locations)
			{
				location.PostLoad(this);
			}
		}
	}
}
