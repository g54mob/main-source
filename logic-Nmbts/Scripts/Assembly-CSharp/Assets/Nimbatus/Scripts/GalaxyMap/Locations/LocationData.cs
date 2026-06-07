using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Assets.Nimbatus.GUI.TravelScene;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Common.LevelTransition;
using Assets.Nimbatus.Scripts.GalaxyMap.LocationSettings;
using Assets.Nimbatus.Scripts.GalaxyMap.Sectors;
using Assets.Nimbatus.Scripts.Missions;
using Assets.Nimbatus.Scripts.Missions.Rewards;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Persistence.Achievements;
using Assets.Nimbatus.Scripts.Receivables;
using Assets.Nimbatus.Scripts.TravelEvents;
using Assets.Nimbatus.Scripts.World.Terrain.ClimateZone;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Thruster;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Locations
{
	[Serializable]
	[XmlInclude(typeof(PlanetLocationData))]
	[XmlInclude(typeof(WormHoleLocationData))]
	[XmlInclude(typeof(SimpleLocationData))]
	[XmlInclude(typeof(ShopLocationData))]
	[XmlInclude(typeof(SpaceLocationData))]
	[XmlInclude(typeof(GarageLocationData))]
	[XmlInclude(typeof(ScrapyardLocationData))]
	[XmlInclude(typeof(BossfightLocationData))]
	public abstract class LocationData
	{
		public bool MissionCompleted;

		public bool Visitable = true;

		public bool RewardsLocked;

		public List<BaseReceivable> MissionRewards;

		public List<BaseReceivable> MissionPenalties;

		public bool RewardScreenShown;

		private LocationSetting _locationSetting;

		public string UniqueId { get; set; }

		public string PrefabId { get; set; }

		public string Name { get; set; }

		public Vector2 Position { get; set; }

		public float CustomScale { get; set; } = 1f;

		public EMissionType Mission { get; set; }

		public EMissionDifficulty MissionDifficulty { get; set; }

		public EMissionComplexity MissionComplexity { get; set; }

		public bool IsSpecialLocation { get; set; }

		public bool IsShopLocation { get; set; }

		[XmlIgnore]
		public GalaxyMapSector Sector { get; set; }

		[XmlIgnore]
		public LocationSetting LocationSetting
		{
			get
			{
				if (_locationSetting == null)
				{
					_locationSetting = SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.LocationSettings.FirstOrDefault((LocationSetting s) => s.UniqueId == PrefabId);
				}
				return _locationSetting;
			}
		}

		public virtual string GetDescription()
		{
			return "";
		}

		public virtual string GetGameplayScene()
		{
			return "";
		}

		public void Init(LocationSetting settings, System.Random randomGenerator, GalaxyMapSector sector, EMissionDifficulty difficulty, EMissionComplexity complexity)
		{
			Sector = sector;
			UniqueId = Guid.NewGuid().ToString();
			PrefabId = settings.UniqueId;
			_locationSetting = settings;
			IsShopLocation = settings.IsShopLocation;
			string value = StringHelper.GenerateRandomLocationName(randomGenerator);
			if (settings is PlanetLocationSetting && randomGenerator.Next(0, 100) >= 60)
			{
				value = SerializableMonobehaviour<NimbatusClimateZoneManager, ClimateZoneManagerSaveData>.Instance.GetPlanetNameFromFile(randomGenerator);
			}
			string translation = settings.Name.GetTranslation();
			LocalizationManager.ApplyLocalizationParams(ref translation, "Name", value);
			Name = translation;
			CustomScale = (settings.HasCustomScale ? settings.CustomScale : 1f);
			MissionComplexity = complexity;
			if (_locationSetting.DefaultMission != null)
			{
				Mission = _locationSetting.DefaultMission.MissionType;
				MissionDifficulty = _locationSetting.DefaultMission.Difficulty;
				if (MissionDifficulty == EMissionDifficulty.None)
				{
					MissionDifficulty = difficulty;
				}
				MissionCompleted = false;
			}
			else
			{
				MissionDifficulty = difficulty;
			}
		}

		public virtual void PostLoad(GalaxyMapSector sector)
		{
			Sector = sector;
			if (CustomScale < 0.1f)
			{
				CustomScale = 1f;
			}
		}

		public virtual void ApplyLocationSettings()
		{
			SerializableMonobehaviour<MissionManager, MissionData>.Instance.ClearLocalMissions();
			SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.ClearActiveDrones();
			SerializableMonobehaviour<MissionManager, MissionData>.Instance.StartLocalMission(Mission, MissionCompleted);
		}

		public abstract void LaunchDrone();

		public void LaunchToScene()
		{
			TravelManager.IsLocationEvent = true;
			if (RuntimeGlobals.GameModeSettings.NimbatusHealthAndThreat)
			{
				TravelEvent travelEventOfType = SerializableMonobehaviour<TravelEventManager, TravelEventManagerSaveData>.Instance.GetTravelEventOfType(ETravelEventType.LocationDamage);
				float num = ((!RuntimeGlobals.GameModeSettings.InCampaignTutorial) ? travelEventOfType.ProbabilityByThreatLevel.Evaluate(SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentGalaxy.CurrentThreatLevel) : ((SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentGalaxy.CurrentThreatLevel >= 90f) ? 1f : 0f));
				if (UnityEngine.Random.Range(float.Epsilon, 1f) <= num)
				{
					TravelManager.LocationEvent = travelEventOfType;
				}
			}
			NimbatusSceneManager.LoadScene("TravelScene");
		}

		public virtual void LoadLocationScene()
		{
			NimbatusSceneManager.LoadScene(SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation.LocationSetting.LocationSceneName);
		}

		public virtual void LoadGameplayScene()
		{
			if (!string.IsNullOrEmpty(GetGameplayScene()))
			{
				NimbatusSceneManager.LoadScene(GetGameplayScene());
			}
		}

		public void SetMissionCompleted(NimbatusMission mission)
		{
			if (Mission != mission.MissionType)
			{
				return;
			}
			if (!MissionCompleted)
			{
				mission.Difficulty = MissionDifficulty;
				if (Sector != null)
				{
					Sector.MissionCompleted(mission);
				}
				MissionRewards.ForEach(delegate(BaseReceivable r)
				{
					r.HandleReward();
				});
				MissionCompleted = true;
			}
			if (RuntimeGlobals.NimbatusPlayer != null && RuntimeGlobals.NimbatusPlayer.Drone != null && RuntimeGlobals.NimbatusPlayer.Drone.RootDronePart.GetNumberOfDroneParts<Thruster>() <= 0 && RuntimeGlobals.NimbatusPlayer.Drone.RootDronePart.GetNumberOfDroneParts<Afterburner>() <= 0 && RuntimeGlobals.NimbatusPlayer.Drone.RootDronePart.GetNumberOfDroneParts<DynamicThruster>() <= 0 && RuntimeGlobals.NimbatusPlayer.Drone.RootDronePart.GetNumberOfDroneParts<VtolThruster>() <= 0)
			{
				BaseSingleton<AchievementManager>.Instance.UnlockAchievement(EAchievement.GoingGreen);
			}
		}

		public void SetMissionFailed(NimbatusMission mission)
		{
			if (Mission == mission.MissionType && !MissionCompleted)
			{
				MissionPenalties.ForEach(delegate(BaseReceivable r)
				{
					r.HandleReward();
				});
			}
		}

		public virtual void CreateRewards(System.Random randomGenerator)
		{
			if (RewardsLocked)
			{
				return;
			}
			MissionRewards = new List<BaseReceivable>();
			NimbatusMission mission = SerializableMonobehaviour<MissionManager, MissionData>.Instance.GetMission(Mission);
			if (mission == null || mission.GetMissionObjectives().Count < 1 || mission.NoRewards)
			{
				return;
			}
			PlanetLocationData planetLocationData = this as PlanetLocationData;
			for (int i = 0; i < 2; i++)
			{
				int num = randomGenerator.Next();
				int num2 = randomGenerator.Next();
				RewardPool rewardPool = ((planetLocationData != null) ? SerializableMonobehaviour<MissionManager, MissionData>.Instance.GetBiomeSpecificRewardPool(num, planetLocationData.ClimateZoneType) : null);
				if (i == 1 && rewardPool != null && rewardPool.IsCompatible() && (float)randomGenerator.Next(0, 100) / 100f <= rewardPool.GetEffectiveProbability(MissionComplexity))
				{
					BaseReceivable baseReceivable = rewardPool.CreateRandomReward(num2, MissionDifficulty, MissionComplexity);
					if (baseReceivable != null && !(baseReceivable is NoReceivable))
					{
						MissionRewards.Add(baseReceivable);
					}
				}
				else
				{
					BaseReceivable randomReward = SerializableMonobehaviour<MissionManager, MissionData>.Instance.GetRandomReward(num, num2, Mission, MissionComplexity);
					if (randomReward != null && !(randomReward is NoReceivable))
					{
						MissionRewards.Add(randomReward);
					}
				}
			}
			MissionRewards = SerializableMonobehaviour<MissionManager, MissionData>.Instance.CleanRewards(MissionRewards, (from p in mission.GetPossibleRewardPools()
				select p.Pool).ToList(), randomGenerator, MissionComplexity);
		}

		public void CreatePenalties(System.Random randomGenerator)
		{
			MissionPenalties = new List<BaseReceivable>();
			for (int i = 0; i < 1; i++)
			{
				BaseReceivable randomPenalty = SerializableMonobehaviour<MissionManager, MissionData>.Instance.GetRandomPenalty(randomGenerator.Next(), Mission);
				if (randomPenalty != null && !(randomPenalty is NoReceivable))
				{
					MissionPenalties.Add(randomPenalty);
				}
			}
		}

		public void SetPreset(IndividualLocationSetting setting, System.Random randomGenerator)
		{
			IsSpecialLocation = setting.IsSpecialLocation;
			if (setting.CustomMission)
			{
				SetMission(setting.Mission, randomGenerator);
			}
			PlanetLocationData planetLocationData;
			if (setting.CustomTheme && (planetLocationData = this as PlanetLocationData) != null)
			{
				planetLocationData.ThemeType = setting.Theme.ThemeType;
			}
			if (!setting.CustomRewards)
			{
				return;
			}
			List<BaseReceivable> list = new List<BaseReceivable>();
			foreach (TravelEventConsequence reward in setting.Rewards)
			{
				list.Add(reward.CreateReward(randomGenerator.Next()));
			}
			MissionRewards = new List<BaseReceivable>();
			MissionRewards = list;
			RewardsLocked = true;
		}

		private void SetMission(NimbatusMission mission, System.Random randomGenerator)
		{
			Mission = mission.MissionType;
			if (mission.Difficulty == EMissionDifficulty.None)
			{
				mission.Difficulty = MissionDifficulty;
			}
			else
			{
				MissionDifficulty = mission.Difficulty;
			}
			CreateRewards(randomGenerator);
			CreatePenalties(randomGenerator);
		}

		public virtual Texture GetPreviewImage()
		{
			BossfightLocationData bossfightLocationData;
			if ((bossfightLocationData = this as BossfightLocationData) != null)
			{
				return bossfightLocationData.Fight.PreviewImage;
			}
			return LocationSetting.PreviewImage;
		}
	}
}
