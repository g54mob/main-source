using System;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.GalaxyMap.LocationSettings;
using Assets.Nimbatus.Scripts.GalaxyMap.Sectors;
using Assets.Nimbatus.Scripts.Missions;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World;
using Assets.Nimbatus.Scripts.World.Terrain.ClimateZone;
using Assets.Nimbatus.Scripts.World.Terrain.TerrainSettings;
using I2.Loc;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Locations
{
	public class SpaceLocationData : LocationData
	{
		public int Seed;

		public ESpaceLocation SpaceLocation;

		public EAirResistance AirResistance;

		public void Init(SpaceLocationSetting settings, Random rnd, GalaxyMapSector sector, EMissionDifficulty difficulty, EMissionComplexity complexity)
		{
			Init((LocationSetting)settings, rnd, sector, difficulty, complexity);
			SpaceLocation = settings.SpaceLocation;
			Seed = rnd.RandomInt();
			AirResistance = EAirResistance.Low;
			base.Mission = SerializableMonobehaviour<MissionManager, MissionData>.Instance.GetRandomSpaceMission(rnd.RandomInt(), SpaceLocation, difficulty, complexity);
			base.MissionDifficulty = SerializableMonobehaviour<MissionManager, MissionData>.Instance.GetMission(base.Mission).Difficulty;
			MissionCompleted = false;
		}

		public override void ApplyLocationSettings()
		{
			base.ApplyLocationSettings();
			WorldController.Seed = Seed;
			WorldController.TerrainSettings.AirResistance = AirResistance;
			WorldController.TerrainSettings.Gravity = EGravity.None;
			SerializableMonobehaviour<NimbatusClimateZoneManager, ClimateZoneManagerSaveData>.Instance.ResetActiveClimateZone();
		}

		public override void LaunchDrone()
		{
			if (SerializableMonobehaviour<MissionManager, MissionData>.Instance.GetMission(base.Mission).OneAttempt)
			{
				Visitable = false;
			}
			LaunchToScene();
		}

		public override string GetDescription()
		{
			string description = base.GetDescription();
			description = description + LabelHelper.LightGrey + LocalizationManager.GetTermTranslation("GalaxyMap/Gravity") + ": " + LabelHelper.Orange + EGravity.None.ToLocalizationString() + LabelHelper.NewLine;
			return description + LabelHelper.LightGrey + LocalizationManager.GetTermTranslation("GalaxyMap/AirResistance") + ": " + LabelHelper.Orange + AirResistance.ToLocalizationString() + LabelHelper.NewLine;
		}

		public override string GetGameplayScene()
		{
			return "SpaceScene";
		}
	}
}
