using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.GalaxyMap;
using Assets.Nimbatus.Scripts.Missions.Rewards;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Persistence.Achievements;
using Assets.Nimbatus.Scripts.Receivables;
using Assets.Nimbatus.Scripts.TravelEvents;
using Assets.Nimbatus.Scripts.World.Terrain.ClimateZone;
using Assets.Nimbatus.Scripts.WorldObjects;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Missions
{
	public class MissionManager : SerializableMonobehaviour<MissionManager, MissionData>
	{
		internal List<NimbatusMission> MissionPrefabs;

		internal List<NimbatusPlanetTheme> ThemePrefabs;

		internal List<NimbatusPlanetTheme> DecoThemePrefabs;

		internal List<NimbatusPlanetEvent> EventPrefabs;

		internal List<RewardPool> AllRewardPoolPrefabs;

		internal List<RewardPool> DefaultRewardPoolPrefabs;

		[HideInInspector]
		public NimbatusMission ActiveMission;

		[CompilerGenerated]
		private readonly string _003CFilename_003Ek__BackingField = "Missions.xml";

		internal override string Filename
		{
			[CompilerGenerated]
			get
			{
				return _003CFilename_003Ek__BackingField;
			}
		}

		public static event Action<NimbatusMission> OnMissionCompleted;

		public static event Action<NimbatusMission> OnMissionFailed;

		public static void InvokeMissionCompleted(NimbatusMission mission)
		{
			if (SerializableMonobehaviour<TravelEventManager, TravelEventManagerSaveData>.Instance.ActiveEvent != null)
			{
				SerializableMonobehaviour<TravelEventManager, TravelEventManagerSaveData>.Instance.SetMissionCompleted();
			}
			else
			{
				SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation.SetMissionCompleted(mission);
			}
			Action<NimbatusMission> onMissionCompleted = MissionManager.OnMissionCompleted;
			if (onMissionCompleted != null)
			{
				onMissionCompleted(mission);
			}
		}

		public static void InvokeMissionFailed(NimbatusMission mission)
		{
			if (SerializableMonobehaviour<TravelEventManager, TravelEventManagerSaveData>.Instance.ActiveEvent != null)
			{
				SerializableMonobehaviour<TravelEventManager, TravelEventManagerSaveData>.Instance.SetMissionFailed();
			}
			else
			{
				SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation.SetMissionFailed(mission);
			}
			Action<NimbatusMission> onMissionFailed = MissionManager.OnMissionFailed;
			if (onMissionFailed != null)
			{
				onMissionFailed(mission);
			}
		}

		protected override void PreLoad()
		{
			MissionPrefabs = Resources.LoadAll<NimbatusMission>("2_Missions").ToList();
			ThemePrefabs = Resources.LoadAll<NimbatusPlanetTheme>("3_MainThemes").ToList();
			DecoThemePrefabs = Resources.LoadAll<NimbatusPlanetTheme>("5_DecoThemes").ToList();
			EventPrefabs = Resources.LoadAll<NimbatusPlanetEvent>("6_PlanetEvents").ToList();
			AllRewardPoolPrefabs = Resources.LoadAll<RewardPool>("RewardPools").ToList();
			DefaultRewardPoolPrefabs = (from p in Resources.LoadAll<RewardPool>("RewardPools")
				where p.IsDefaultPool
				select p).ToList();
		}

		protected override void Reset()
		{
			ActiveMission = null;
		}

		public void UpdateTimer()
		{
			NimbatusMission activeMission = ActiveMission;
			if ((object)activeMission != null)
			{
				activeMission.UpdateTimer();
			}
		}

		public void PlayerDroneDestroyed()
		{
			NimbatusMission activeMission = ActiveMission;
			if ((object)activeMission != null)
			{
				activeMission.PlayerDroneDestroyed();
			}
		}

		public void ObjectDestroyed(string id)
		{
			NimbatusMission activeMission = ActiveMission;
			if ((object)activeMission != null)
			{
				activeMission.ObjectDestroyed(id);
			}
		}

		public void ObjectUncovered(string id)
		{
			NimbatusMission activeMission = ActiveMission;
			if ((object)activeMission != null)
			{
				activeMission.ObjectUncovered(id);
			}
		}

		public void ObjectFrozen(InteractiveWorldObject worldObject)
		{
			NimbatusMission activeMission = ActiveMission;
			if ((object)activeMission != null)
			{
				activeMission.ObjectFrozen(worldObject);
			}
		}

		public void ObjectUnfrozen(InteractiveWorldObject worldObject)
		{
			NimbatusMission activeMission = ActiveMission;
			if ((object)activeMission != null)
			{
				activeMission.ObjectUnfrozen(worldObject);
			}
		}

		public void ObjectCollected(string id)
		{
			NimbatusMission activeMission = ActiveMission;
			if ((object)activeMission != null)
			{
				activeMission.ObjectCollected(id);
			}
		}

		public void StartLocalMission(EMissionType missionType, bool isCompleted)
		{
			if (missionType == EMissionType.OrePlanet)
			{
				BaseSingleton<AchievementManager>.Instance.UnlockAchievement(EAchievement.DoctorJones);
			}
			if (missionType != EMissionType.None)
			{
				NimbatusMission nimbatusMission = MissionPrefabs.First((NimbatusMission m) => m.MissionType == missionType);
				UnityEngine.Object.Instantiate(nimbatusMission).SetCompleted(isCompleted);
				ActiveMission = nimbatusMission;
				BaseSingleton<MissionTargetManager>.Instance.InitMission();
			}
		}

		public bool IsLocalMissionCompleted(EMissionType missionType)
		{
			if (ActiveMission != null)
			{
				return ActiveMission.IsCompleted();
			}
			return true;
		}

		public bool IsLocalMissionFailed(EMissionType missionType)
		{
			if (ActiveMission != null)
			{
				return ActiveMission.IsFailed();
			}
			return false;
		}

		public void ResetLocalMissionProgress()
		{
			NimbatusMission activeMission = ActiveMission;
			if ((object)activeMission != null)
			{
				activeMission.ResetProgress();
			}
		}

		public void InitMissions()
		{
			NimbatusMission activeMission = ActiveMission;
			if ((object)activeMission != null)
			{
				activeMission.Init();
			}
		}

		public void ClearLocalMissions()
		{
			NimbatusMission activeMission = ActiveMission;
			if ((object)activeMission != null)
			{
				activeMission.ResetProgress();
			}
			ActiveMission = null;
			BaseSingleton<MissionTargetManager>.Instance.Reset();
		}

		public string GetMissionDescription(EMissionType type)
		{
			if (MissionPrefabs.FirstOrDefault((NimbatusMission m) => m.MissionType == type) != null)
			{
				return LocalizationManager.GetTermTranslation("MissionDescriptions/" + type);
			}
			return "";
		}

		public string GetMissionTitle(EMissionType type)
		{
			NimbatusMission nimbatusMission = MissionPrefabs.FirstOrDefault((NimbatusMission m) => m.MissionType == type);
			if (nimbatusMission != null)
			{
				return nimbatusMission.MissionType.ToLocalizationString();
			}
			return "";
		}

		public string GetStatusText(EMissionType type)
		{
			NimbatusMission nimbatusMission = MissionPrefabs.FirstOrDefault((NimbatusMission m) => m.MissionType == type);
			if (ActiveMission != null)
			{
				return ActiveMission.GetStatusText();
			}
			if (nimbatusMission != null)
			{
				return nimbatusMission.MissionType.ToLocalizationString();
			}
			return "";
		}

		public EMissionType GetRandomMission(int missionSeed, EClimateZoneType zoneType, EMissionDifficulty difficulty, EMissionComplexity complexity)
		{
			List<NimbatusMission> list = MissionPrefabs.Where((NimbatusMission m) => m.RandomPlanetMission && (m.Zone == zoneType || m.Zone == EClimateZoneType.None) && (difficulty == EMissionDifficulty.None || m.Difficulty == difficulty)).ToList();
			if (list.Count > 0)
			{
				if (complexity == EMissionComplexity.None)
				{
					return list.RandomItemSeed(missionSeed).MissionType;
				}
				return list.RandomItemProbability((NimbatusMission m, int i) => m.ProbabilityByComplexity.Evaluate((float)complexity), missionSeed).MissionType;
			}
			return EMissionType.None;
		}

		public EMissionType GetRandomSpaceMission(int missionSeed, ESpaceLocation spaceLoc, EMissionDifficulty difficulty, EMissionComplexity complexity)
		{
			List<NimbatusMission> list = MissionPrefabs.Where((NimbatusMission m) => m.RandomSpaceMission && (m.SpaceLocation == spaceLoc || m.SpaceLocation == ESpaceLocation.None) && (difficulty == EMissionDifficulty.None || m.Difficulty == difficulty)).ToList();
			if (list.Count > 0)
			{
				if (complexity == EMissionComplexity.None)
				{
					return list.RandomItemSeed(missionSeed).MissionType;
				}
				return list.RandomItemProbability((NimbatusMission m, int i) => m.ProbabilityByComplexity.Evaluate((float)complexity), missionSeed).MissionType;
			}
			return EMissionType.None;
		}

		public List<EMissionType> GetValidMissions(ESpaceLocation zone)
		{
			return (from m in MissionPrefabs
				where m.RandomSpaceMission && (m.SpaceLocation == zone || m.SpaceLocation == ESpaceLocation.None)
				select m.MissionType).ToList();
		}

		public List<EMissionType> GetValidMissions(EClimateZoneType zone)
		{
			return (from m in MissionPrefabs
				where m.RandomPlanetMission && (m.Zone == zone || m.Zone == EClimateZoneType.None)
				select m.MissionType).ToList();
		}

		public List<EThemeType> GetValidThemes(EClimateZoneType zone)
		{
			return (from m in ThemePrefabs
				where m.Zone == zone || m.Zone == EClimateZoneType.None
				select m.ThemeType).ToList();
		}

		public List<EThemeType> GetValidDecoThemes(EClimateZoneType zone)
		{
			return (from m in DecoThemePrefabs
				where m.Zone == zone || m.Zone == EClimateZoneType.None
				select m.ThemeType).ToList();
		}

		public NimbatusPlanetTheme GetRandomTheme(int seed, EClimateZoneType zone, EMissionComplexity complexity)
		{
			List<NimbatusPlanetTheme> list = ThemePrefabs.Where((NimbatusPlanetTheme m) => m.Zone == EClimateZoneType.None || m.Zone == zone).ToList();
			if (list.Count > 0)
			{
				return list.RandomItemProbability((NimbatusPlanetTheme t) => t.Probability.Evaluate((float)complexity), seed);
			}
			return null;
		}

		public NimbatusPlanetTheme GetRandomDecoTheme(int seed, EClimateZoneType zone)
		{
			List<NimbatusPlanetTheme> list = DecoThemePrefabs.Where((NimbatusPlanetTheme m) => m.Zone == EClimateZoneType.None || m.Zone == zone).ToList();
			if (list.Count > 0)
			{
				return list.RandomItemSeed(seed);
			}
			return null;
		}

		public NimbatusPlanetEvent GetRandomEvent(int seed, EClimateZoneType zone, EMissionComplexity complexity)
		{
			List<NimbatusPlanetEvent> list = EventPrefabs.Where((NimbatusPlanetEvent m) => m.AllZones || m.Zones.Contains(zone)).ToList();
			if (list.Count > 0)
			{
				return list.RandomItemProbability((NimbatusPlanetEvent t) => t.Probability.Evaluate((float)complexity), seed);
			}
			return null;
		}

		public NimbatusPlanetEvent GetEvent(EPlanetEventType eventType)
		{
			return EventPrefabs.FirstOrDefault((NimbatusPlanetEvent e) => e.EventType == eventType);
		}

		public NimbatusPlanetTheme GetTheme(EThemeType themeType)
		{
			return ThemePrefabs.FirstOrDefault((NimbatusPlanetTheme e) => e.ThemeType == themeType);
		}

		public NimbatusPlanetTheme GetDecoTheme(EThemeType themeType)
		{
			return DecoThemePrefabs.FirstOrDefault((NimbatusPlanetTheme e) => e.ThemeType == themeType);
		}

		public NimbatusMission GetMission(EMissionType mission)
		{
			return MissionPrefabs.FirstOrDefault((NimbatusMission m) => m.MissionType == mission);
		}

		public BaseReceivable GetRandomReward(int poolSeed, int rewardSeed, EMissionType mission, EMissionComplexity complexity = EMissionComplexity.None)
		{
			NimbatusMission nimbatusMission = MissionPrefabs.First((NimbatusMission m) => m.MissionType == mission);
			if (nimbatusMission == null)
			{
				return new NoReceivable();
			}
			if (!nimbatusMission.CustomRewardPools)
			{
				return GetRandomRewardFromPools(poolSeed, rewardSeed, DefaultRewardPoolPrefabs, nimbatusMission.Difficulty, complexity);
			}
			List<NimbatusMission.PossibleRewardPoolSettings> possibleRewardPools = nimbatusMission.GetPossibleRewardPools();
			if (possibleRewardPools == null || possibleRewardPools.Count < 1)
			{
				throw new Exception("No custom reward pools assigned");
			}
			List<NimbatusMission.PossibleRewardPoolSettings> source = possibleRewardPools.Where((NimbatusMission.PossibleRewardPoolSettings p) => p.Pool.IsCompatible()).ToList();
			if (!source.Any())
			{
				return GetRandomRewardFromPools(poolSeed, rewardSeed, DefaultRewardPoolPrefabs, nimbatusMission.Difficulty, complexity);
			}
			RewardPool randomRewardPool = GetRandomRewardPool(source.Select((NimbatusMission.PossibleRewardPoolSettings p) => p.Pool).ToList(), source.Select((NimbatusMission.PossibleRewardPoolSettings p) => p.Probability).ToList(), poolSeed);
			BaseReceivable reward = randomRewardPool.CreateRandomReward(rewardSeed, nimbatusMission.Difficulty, complexity);
			return CheckIfRewardIsAllowed(reward, randomRewardPool, source.Select((NimbatusMission.PossibleRewardPoolSettings p) => p.Pool).ToList(), rewardSeed + poolSeed, nimbatusMission.Difficulty, complexity);
		}

		public List<BaseReceivable> CleanRewards(List<BaseReceivable> rewards, List<RewardPool> customPools, System.Random randomGenerator, EMissionComplexity complexity, bool strict = false)
		{
			if (!strict && !rewards.Any((BaseReceivable r) => r.Type() == EReceivableType.Upgrade || r.Type() == EReceivableType.Technology || r.Type() == EReceivableType.Effect))
			{
				return rewards;
			}
			BaseReceivable first = rewards[0];
			for (int num = 0; num < 20; num++)
			{
				if (rewards.Any((BaseReceivable r) => r != first && first.IsDuplicate(r)))
				{
					BaseReceivable item = rewards.First((BaseReceivable r) => r != first && first.IsDuplicate(r));
					BaseReceivable randomRewardFromPools = GetRandomRewardFromPools(randomGenerator.Next(), randomGenerator.Next(), customPools, EMissionDifficulty.None, complexity);
					if (randomRewardFromPools != null && !(randomRewardFromPools is NoReceivable) && !first.IsDuplicate(randomRewardFromPools))
					{
						rewards.Remove(item);
						rewards.Add(randomRewardFromPools);
					}
				}
				BaseReceivable item2 = rewards[rewards.Count - 1];
				rewards.Remove(item2);
				rewards.Insert(0, item2);
				first = rewards[0];
			}
			return rewards;
		}

		public BaseReceivable GetRandomRewardFromPools(int poolSeed, int rewardSeed, List<RewardPool> possiblePools, EMissionDifficulty difficulty = EMissionDifficulty.None, EMissionComplexity complexity = EMissionComplexity.None)
		{
			List<RewardPool> list = possiblePools.Where((RewardPool p) => p.IsCompatible()).ToList();
			if (!list.Any())
			{
				list = DefaultRewardPoolPrefabs.Where((RewardPool p) => p.IsCompatible()).ToList();
				if (!list.Any())
				{
					return new NoReceivable();
				}
			}
			IEnumerable<float> source = list.Select((RewardPool p) => p.GetEffectiveProbability(complexity));
			RewardPool randomRewardPool = GetRandomRewardPool(list, source.ToList(), poolSeed);
			BaseReceivable reward = randomRewardPool.CreateRandomReward(rewardSeed, difficulty, complexity);
			return CheckIfRewardIsAllowed(reward, randomRewardPool, list, rewardSeed + poolSeed, difficulty, complexity);
		}

		private RewardPool GetRandomRewardPool(List<RewardPool> poolList, List<float> probList, int seed)
		{
			return poolList.RandomItemProbability((RewardPool p, int i) => probList[i], new System.Random(seed));
		}

		private BaseReceivable CheckIfRewardIsAllowed(BaseReceivable reward, RewardPool currentPool, List<RewardPool> possiblePools, int seed, EMissionDifficulty difficulty, EMissionComplexity complexity)
		{
			if (reward != null && ReceivableHelper.IsAllowed(reward))
			{
				return reward;
			}
			if (currentPool != null && possiblePools != null)
			{
				System.Random random = new System.Random(seed);
				int possibleRewardsSeed = random.Next();
				List<RewardPool.PossibleReward> allowedRewards = (from r in currentPool.GetPossibleRewards(difficulty, complexity, possibleRewardsSeed)
					where ReceivableHelper.IsAllowed(r.Receivable)
					select r).ToList();
				if (allowedRewards.Count > 0)
				{
					reward = allowedRewards.RandomItemProbability((RewardPool.PossibleReward s, int i) => allowedRewards.Select((RewardPool.PossibleReward l) => l.Probability).ToList()[i], random.Next()).Receivable;
					return reward;
				}
				List<RewardPool> list = possiblePools.Where((RewardPool p) => p.GetPossibleRewards(difficulty, complexity, possibleRewardsSeed).Any((RewardPool.PossibleReward r) => ReceivableHelper.IsAllowed(r.Receivable))).ToList();
				if (list.Count > 0)
				{
					IEnumerable<float> source = list.Select((RewardPool p) => p.GetEffectiveProbability(complexity));
					currentPool = GetRandomRewardPool(list, source.ToList(), random.Next());
					List<RewardPool.PossibleReward> list2 = (from r in currentPool.GetPossibleRewards(difficulty, complexity, possibleRewardsSeed)
						where ReceivableHelper.IsAllowed(r.Receivable)
						select r).ToList();
					if (list2.Count < 1)
					{
						return new NoReceivable();
					}
					reward = list2.RandomItemProbability((RewardPool.PossibleReward s, int i) => list2.Select((RewardPool.PossibleReward l) => l.Probability).ToList()[i], random.Next()).Receivable;
					return reward;
				}
			}
			return new NoReceivable();
		}

		public RewardPool GetBiomeSpecificRewardPool(int seed, EClimateZoneType biome)
		{
			return AllRewardPoolPrefabs.Where((RewardPool p) => p.IsClimateZoneSpecific && p.AllowedClimateZones.Contains(biome)).ToList().RandomItemSeed(seed);
		}

		public BaseReceivable GetRandomPenalty(int seed, EMissionType mission)
		{
			NimbatusMission nimbatusMission = MissionPrefabs.First((NimbatusMission m) => m.MissionType == mission);
			if (nimbatusMission == null)
			{
				return new NoReceivable();
			}
			if (!nimbatusMission.HasFailurePenalty)
			{
				return new NoReceivable();
			}
			BaseReceivable baseReceivable = nimbatusMission.GetPossiblePenalties().RandomItemSeed(seed);
			if (ReceivableHelper.IsAllowed(baseReceivable))
			{
				return baseReceivable;
			}
			return new NoReceivable();
		}

		public bool IsMissionRunning(EMissionType missionKey)
		{
			if (ActiveMission != null)
			{
				return ActiveMission.MissionType == missionKey;
			}
			return false;
		}

		protected override void LoadFromFile(MissionData data)
		{
		}

		protected override MissionData SaveToFile()
		{
			return new MissionData();
		}
	}
}
