using System;
using Assets.Nimbatus.GUI.MissionControl.Scripts;
using Assets.Nimbatus.Scripts.Common.LevelTransition;
using Assets.Nimbatus.Scripts.GalaxyMap.LocationSettings;
using Assets.Nimbatus.Scripts.GalaxyMap.Sectors;
using Assets.Nimbatus.Scripts.Missions;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Locations
{
	public class ScrapyardLocationData : LocationData
	{
		public void Init(ScrapyardLocationSetting settings, Random randomGenerator, GalaxyMapSector sector, EMissionDifficulty difficulty, EMissionComplexity complexity)
		{
			Init((LocationSetting)settings, randomGenerator, sector, difficulty, complexity);
		}

		public override void LaunchDrone()
		{
		}

		public override void ApplyLocationSettings()
		{
			base.ApplyLocationSettings();
			MissionCompleted = true;
			NimbatusSceneManager.SetReturnScene(base.LocationSetting.LocationSceneName, "MissionControlScene");
			MissionControlNavigator.PageToLoad = EMissionControlPage.Main;
		}
	}
}
