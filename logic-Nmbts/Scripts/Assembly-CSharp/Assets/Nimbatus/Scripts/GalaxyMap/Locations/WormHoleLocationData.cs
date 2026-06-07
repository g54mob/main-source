using System;
using Assets.Nimbatus.GUI.TravelScene;
using Assets.Nimbatus.Scripts.Common.LevelTransition;
using Assets.Nimbatus.Scripts.GalaxyMap.LocationSettings;
using Assets.Nimbatus.Scripts.GalaxyMap.Sectors;
using Assets.Nimbatus.Scripts.Missions;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World.Terrain.ClimateZone;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Locations
{
	[Serializable]
	public class WormHoleLocationData : LocationData
	{
		public int GalaxyLevel;

		public int GalaxySeed;

		public void Init(WormHoleLocationSetting settings, Random randomGenerator, GalaxyMapSector sector, EMissionDifficulty difficulty, EMissionComplexity complexity)
		{
			Init((LocationSetting)settings, randomGenerator, sector, difficulty, complexity);
			GalaxySeed = randomGenerator.Next(int.MinValue, int.MaxValue);
		}

		public void SetGalaxyLevel(int lvl)
		{
			GalaxyLevel = lvl;
			if (lvl == 1)
			{
				GalaxySeed = Guid.NewGuid().ToString().GetHashCode();
			}
		}

		public override void ApplyLocationSettings()
		{
			base.ApplyLocationSettings();
			SerializableMonobehaviour<NimbatusClimateZoneManager, ClimateZoneManagerSaveData>.Instance.ResetActiveClimateZone();
		}

		public override void LoadLocationScene()
		{
			if (RuntimeGlobals.GameMode == EGameMode.Campaign)
			{
				if (!RuntimeGlobals.GameModeSettings.InCampaignTutorial)
				{
					NimbatusSceneManager.LoadScene("EndOfGalaxyScene");
				}
				else
				{
					NimbatusSceneManager.LoadScene("CampaignIntroScene");
				}
			}
			else
			{
				TravelToNextGalaxy();
			}
		}

		public void TravelToNextGalaxy()
		{
			Galaxy currentGalaxy = SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentGalaxy;
			TravelManager.ThreatIncrease = 0f;
			if (GalaxyLevel != currentGalaxy.Level)
			{
				SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.ReloadGalaxy(GalaxySeed, GalaxyLevel);
			}
		}

		public override void LaunchDrone()
		{
		}
	}
}
