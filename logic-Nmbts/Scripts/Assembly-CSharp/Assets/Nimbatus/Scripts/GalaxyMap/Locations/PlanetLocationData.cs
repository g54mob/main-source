using System;
using System.Collections;
using System.Xml.Serialization;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.GUI.TravelScene;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Common.LevelTransition;
using Assets.Nimbatus.Scripts.GalaxyMap.LocationSettings;
using Assets.Nimbatus.Scripts.GalaxyMap.Sectors;
using Assets.Nimbatus.Scripts.Missions;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Persistence.Achievements;
using Assets.Nimbatus.Scripts.World;
using Assets.Nimbatus.Scripts.World.Terrain.ClimateZone;
using Assets.Nimbatus.Scripts.World.Terrain.TerrainSettings;
using Assets.Nimbatus.Scripts.WorldObjects.DronePerks;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Locations
{
	[Serializable]
	public class PlanetLocationData : LocationData
	{
		public NimbatusTerrainSetting PlanetSettings;

		public int TerrainSeed;

		public EThemeType ThemeType;

		public EThemeType DecoThemeType;

		public EPlanetEventType EventType;

		public bool IsEndPlanet;

		public bool IntroEventSeen;

		public EClimateZoneType ClimateZoneType;

		public int ClimateZoneSeed;

		private BitArray _collectedMineralBitArray;

		private NimbatusTerrainClimateZone _climateZone;

		public byte[] CollectedMineralStatus
		{
			get
			{
				byte[] array = new byte[151251];
				_collectedMineralBitArray.CopyTo(array, 0);
				return array;
			}
			set
			{
				_collectedMineralBitArray = new BitArray(value);
			}
		}

		[XmlIgnore]
		public NimbatusTerrainClimateZone ClimateZone
		{
			get
			{
				if (_climateZone == null)
				{
					_climateZone = SerializableMonobehaviour<NimbatusClimateZoneManager, ClimateZoneManagerSaveData>.Instance.GetClimateZone(ClimateZoneType, ClimateZoneSeed);
					if (!PlanetSettings.IsInitialized)
					{
						PlanetSettings = ClimateZone.TerrainSetting.GenerateSettings(new System.Random(ClimateZoneSeed));
					}
					_climateZone.SelectedSettings = PlanetSettings;
				}
				return _climateZone;
			}
		}

		public void Init(PlanetLocationSetting settings, System.Random rnd, GalaxyMapSector sector, EMissionDifficulty difficulty, EMissionComplexity complexity)
		{
			Init((LocationSetting)settings, rnd, sector, difficulty, complexity);
			TerrainSeed = rnd.RandomInt();
			ClimateZoneSeed = rnd.RandomInt();
			CollectedMineralStatus = new byte[151251];
			SolarSystem solarSystem;
			if ((solarSystem = sector as SolarSystem) != null)
			{
				ClimateZoneType = solarSystem.ClimateZoneType;
			}
			else
			{
				ClimateZoneType = EClimateZoneType.Corp;
			}
			base.Mission = SerializableMonobehaviour<MissionManager, MissionData>.Instance.GetRandomMission(rnd.RandomInt(), ClimateZoneType, difficulty, complexity);
			ThemeType = SerializableMonobehaviour<MissionManager, MissionData>.Instance.GetRandomTheme(rnd.RandomInt(), ClimateZoneType, complexity).ThemeType;
			DecoThemeType = SerializableMonobehaviour<MissionManager, MissionData>.Instance.GetRandomDecoTheme(rnd.RandomInt(), ClimateZoneType).ThemeType;
			EventType = SerializableMonobehaviour<MissionManager, MissionData>.Instance.GetRandomEvent(rnd.RandomInt(), ClimateZoneType, base.MissionComplexity).EventType;
			PlanetSettings = ClimateZone.TerrainSetting.GenerateSettings(new System.Random(ClimateZoneSeed));
			ClimateZone.SelectedSettings = PlanetSettings;
			base.MissionDifficulty = difficulty;
			MissionCompleted = false;
		}

		public override void ApplyLocationSettings()
		{
			base.ApplyLocationSettings();
			ClimateZone.SetSettings(PlanetSettings);
			WorldController.Seed = TerrainSeed;
			WorldController.ClimateZoneSeed = ClimateZoneSeed;
			WorldController.TerrainSettings = ClimateZone.SelectedSettings;
			SerializableMonobehaviour<NimbatusClimateZoneManager, ClimateZoneManagerSaveData>.Instance.BuildTerrainCache(this);
		}

		public override void LaunchDrone()
		{
			if (SerializableMonobehaviour<MissionManager, MissionData>.Instance.GetMission(base.Mission).OneAttempt)
			{
				Visitable = false;
			}
			LaunchToScene();
		}

		public override void LoadLocationScene()
		{
			if (IsEndPlanet && MissionCompleted)
			{
				LoadEndScene();
			}
			else
			{
				base.LoadLocationScene();
			}
		}

		public void LoadEndScene()
		{
			if (!IsEndPlanet)
			{
				return;
			}
			if (RuntimeGlobals.GameMode == EGameMode.Campaign)
			{
				if (SerializableMonobehaviour<DronePerkManager, DronePerkManagerData>.Instance.ActivePerk != null)
				{
					BaseSingleton<AchievementManager>.Instance.UnlockAchievement(SerializableMonobehaviour<DronePerkManager, DronePerkManagerData>.Instance.ActivePerk.SurvivalModeAchievement);
				}
				if (RuntimeGlobals.GameModeSettings.Difficulty > EGameModeDifficulty.Easy)
				{
					BaseSingleton<AchievementManager>.Instance.UnlockAchievement(EAchievement.Survivor);
				}
			}
			NimbatusSceneManager.LoadScene("EndOfGameScene");
		}

		public void TravelToNextGalaxy()
		{
			int seed = new System.Random(TerrainSeed).Next();
			int level = SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentGalaxy.Level + 1;
			TravelManager.ThreatIncrease = 0f;
			SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.ReloadGalaxy(seed, level);
		}

		public override Texture GetPreviewImage()
		{
			return ClimateZone.PreviewImage;
		}

		public override string GetDescription()
		{
			string description = base.GetDescription();
			description = description + LabelHelper.LightGrey + LocalizationManager.GetTermTranslation("GalaxyMap/PlanetDiameter") + ": " + LabelHelper.Orange + PlanetSettings.PlanetSize * 2 + LabelHelper.NewLine;
			description = description + LabelHelper.LightGrey + LocalizationManager.GetTermTranslation("GalaxyMap/Gravity") + ": " + LabelHelper.Orange + PlanetSettings.Gravity.ToLocalizationString() + LabelHelper.NewLine;
			return description + LabelHelper.LightGrey + LocalizationManager.GetTermTranslation("GalaxyMap/AirResistance") + ": " + LabelHelper.Orange + PlanetSettings.AirResistance.ToLocalizationString() + LabelHelper.NewLine;
		}

		public override string GetGameplayScene()
		{
			return "MainScene";
		}

		public bool HasMineralBeenCollected(int x, int y)
		{
			return _collectedMineralBitArray[x * 1100 + y];
		}

		public void SetMineralCollected(Vector2 worldPosition)
		{
			int num = (int)worldPosition.x + 540;
			int num2 = (int)worldPosition.y + 540;
			_collectedMineralBitArray[num * 1100 + num2] = true;
		}
	}
}
