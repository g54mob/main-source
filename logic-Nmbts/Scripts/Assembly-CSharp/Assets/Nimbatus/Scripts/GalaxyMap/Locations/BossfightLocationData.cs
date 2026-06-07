using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.GalaxyMap.Boss;
using Assets.Nimbatus.Scripts.GalaxyMap.LocationSettings;
using Assets.Nimbatus.Scripts.GalaxyMap.Sectors;
using Assets.Nimbatus.Scripts.Missions;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Persistence.Achievements;
using Assets.Nimbatus.Scripts.Receivables;
using Assets.Nimbatus.Scripts.World.Terrain.ClimateZone;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Locations
{
	public class BossfightLocationData : LocationData
	{
		public string BossFightId;

		public int RewardSeed;

		private BossFight _bossFight;

		public BossFight Fight
		{
			get
			{
				if (_bossFight == null)
				{
					_bossFight = GetBossfightFromId(BossFightId);
				}
				return _bossFight;
			}
		}

		public void Init(BossfightLocationSetting settings, Random randomGenerator, GalaxyMapSector sector, EMissionDifficulty difficulty, EMissionComplexity complexity)
		{
			Init((LocationSetting)settings, randomGenerator, sector, difficulty, complexity);
			RewardSeed = randomGenerator.Next(int.MinValue, int.MaxValue);
		}

		private BossFight GetBossfightFromId(string bossFightId)
		{
			BossfightLocationSetting bossfightLocationSetting;
			if ((object)(bossfightLocationSetting = base.LocationSetting as BossfightLocationSetting) != null)
			{
				return bossfightLocationSetting.Bossfights.FirstOrDefault((BossFight b) => b.UniqueId == bossFightId);
			}
			return null;
		}

		public void SetBossFight(BossFight fight)
		{
			if (!(fight == null))
			{
				BossFightId = fight.UniqueId;
				_bossFight = fight;
			}
		}

		public void SetBossfightCompleted()
		{
			if (Fight.Achievement != EAchievement.None)
			{
				BaseSingleton<AchievementManager>.Instance.UnlockAchievement(Fight.Achievement);
			}
			if (!MissionCompleted)
			{
				MissionRewards.ForEach(delegate(BaseReceivable r)
				{
					r.HandleReward();
				});
			}
			if (base.Sector != null)
			{
				base.Sector.BossfightCompleted();
			}
			MissionCompleted = true;
		}

		public override void LaunchDrone()
		{
			LaunchToScene();
		}

		public override string GetGameplayScene()
		{
			return Fight.BossfightScene;
		}

		public override void CreateRewards(Random randomGenerator)
		{
			if (!(Fight == null) && Fight.PossiblePools != null && Fight.PossiblePools.Count >= 1)
			{
				MissionRewards = new List<BaseReceivable>();
				Random random = new Random(RewardSeed);
				for (int i = 0; i < 3; i++)
				{
					int poolSeed = random.Next();
					int rewardSeed = random.Next();
					MissionRewards.Add(SerializableMonobehaviour<MissionManager, MissionData>.Instance.GetRandomRewardFromPools(poolSeed, rewardSeed, Fight.PossiblePools));
				}
				MissionRewards = SerializableMonobehaviour<MissionManager, MissionData>.Instance.CleanRewards(MissionRewards, Fight.PossiblePools, random, base.MissionComplexity);
			}
		}

		public override void ApplyLocationSettings()
		{
			base.ApplyLocationSettings();
			SerializableMonobehaviour<NimbatusClimateZoneManager, ClimateZoneManagerSaveData>.Instance.ResetActiveClimateZone();
		}

		public string GetName()
		{
			if (Fight == null)
			{
				return "";
			}
			return Fight.Name.GetTranslation();
		}

		public string GetMissionName()
		{
			if (Fight == null)
			{
				return "";
			}
			return Fight.MissionName.GetTranslation();
		}

		public override string GetDescription()
		{
			if (Fight == null)
			{
				return base.GetDescription();
			}
			return Fight.Description.GetTranslation();
		}
	}
}
