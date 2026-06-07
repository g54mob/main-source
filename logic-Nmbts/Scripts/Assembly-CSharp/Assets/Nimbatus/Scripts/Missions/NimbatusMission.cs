using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.GalaxyMap;
using Assets.Nimbatus.Scripts.Missions.Objectives;
using Assets.Nimbatus.Scripts.Missions.Rewards;
using Assets.Nimbatus.Scripts.Receivables;
using Assets.Nimbatus.Scripts.Spawning.PlanetSpawnSystem;
using Assets.Nimbatus.Scripts.Spawning.SpaceSpawnSystem;
using Assets.Nimbatus.Scripts.World.Terrain.ClimateZone;
using Assets.Nimbatus.Scripts.WorldObjects;
using I2.Loc;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Missions
{
	public class NimbatusMission : SerializedScriptableObject
	{
		public class PossibleRewardPoolSettings
		{
			public RewardPool Pool;

			public float Probability = 1f;
		}

		public EMissionType MissionType;

		public EMissionDifficulty Difficulty;

		public bool RandomPlanetMission;

		[ShowIf("RandomPlanetMission", true)]
		public EClimateZoneType Zone;

		public bool RandomSpaceMission;

		[ShowIf("RandomSpaceMission", true)]
		public ESpaceLocation SpaceLocation;

		public bool OneAttempt;

		public bool ExitOnFinish;

		public bool CompleteOnExit;

		[Header("Win Settings")]
		[OdinSerialize]
		protected List<MissionObjective> Objectives = new List<MissionObjective>();

		public bool HasMissionTargets;

		[ShowIf("HasMissionTargets", true)]
		public List<InteractiveWorldObject> MissionTargets = new List<InteractiveWorldObject>();

		public bool NoRewards;

		[HideIf("NoRewards", true)]
		public bool CustomRewardPools;

		[HideIf("NoRewards", true)]
		[ShowIf("CustomRewardPools", true)]
		[OdinSerialize]
		protected List<PossibleRewardPoolSettings> PossibleRewardPools = new List<PossibleRewardPoolSettings>();

		[Header("Fail Settings")]
		[OdinSerialize]
		protected List<MissionObjective> Failstates = new List<MissionObjective>();

		public bool HasFailurePenalty;

		[ShowIf("HasFailurePenalty", true)]
		[OdinSerialize]
		protected List<BaseReceivable> PossiblePenalties = new List<BaseReceivable>();

		[Header("Spawn Settings")]
		[ListDrawerSettings(ShowPaging = true, NumberOfItemsPerPage = 1)]
		[OdinSerialize]
		protected internal List<PlanetSpawnSetting> SpawnSettings = new List<PlanetSpawnSetting>();

		[ListDrawerSettings(ShowPaging = true, NumberOfItemsPerPage = 1)]
		[OdinSerialize]
		protected internal List<SpaceSpawnSetting> SpaceSpawnSettings = new List<SpaceSpawnSetting>();

		public AnimationCurve ProbabilityByComplexity = new AnimationCurve(new Keyframe(1f, 0.1f), new Keyframe(5f, 0.9f));

		private bool _playerDroneDestroyed;

		private bool _failed;

		private bool _completed;

		private bool _initiated;

		public List<MissionObjective> GetMissionObjectives()
		{
			return Objectives;
		}

		public List<PossibleRewardPoolSettings> GetPossibleRewardPools()
		{
			return PossibleRewardPools;
		}

		public List<MissionObjective> GetMissionFailstates()
		{
			return Failstates;
		}

		public List<BaseReceivable> GetPossiblePenalties()
		{
			return PossiblePenalties;
		}

		public void SetCompleted(bool isCompleted)
		{
			if (isCompleted)
			{
				Objectives.ForEach(delegate(MissionObjective o)
				{
					o.SetFullfilled();
				});
			}
		}

		public bool IsCompleted()
		{
			if (!_initiated)
			{
				return false;
			}
			if (_completed)
			{
				return true;
			}
			if (_failed)
			{
				return false;
			}
			return _completed = Objectives.Count > 0 && Objectives.All((MissionObjective o) => o.IsFullfilled());
		}

		public bool IsFailed()
		{
			if (!_initiated)
			{
				return false;
			}
			if (_completed)
			{
				return false;
			}
			if (_failed)
			{
				return true;
			}
			return _failed = _playerDroneDestroyed || (Failstates.Count > 0 && Failstates.All((MissionObjective s) => s.IsFullfilled()));
		}

		public void Init()
		{
			foreach (MissionObjective objective in Objectives)
			{
				objective.Init();
			}
			foreach (MissionObjective failstate in Failstates)
			{
				failstate.Init();
			}
			_initiated = true;
		}

		public void ResetProgress()
		{
			foreach (MissionObjective objective in Objectives)
			{
				objective.ResetProgress();
			}
			_initiated = false;
			_completed = false;
			_failed = false;
			_playerDroneDestroyed = false;
			foreach (MissionObjective failstate in Failstates)
			{
				failstate.ResetProgress();
			}
		}

		public void PlayerDroneDestroyed()
		{
			if (!_playerDroneDestroyed)
			{
				bool num = IsFailed();
				_playerDroneDestroyed = true;
				if (!num && IsFailed())
				{
					MissionManager.InvokeMissionFailed(this);
				}
			}
		}

		public void ObjectDestroyed(string id)
		{
			bool flag = IsCompleted();
			bool flag2 = IsFailed();
			foreach (DestroyObjective item in Objectives.OfType<DestroyObjective>())
			{
				item.UpdateProgress(id);
			}
			foreach (DestroyObjective item2 in Failstates.OfType<DestroyObjective>())
			{
				item2.UpdateProgress(id);
			}
			if (!flag2 && !flag && IsCompleted())
			{
				MissionManager.InvokeMissionCompleted(this);
			}
			if (!flag2 && !flag && IsFailed())
			{
				MissionManager.InvokeMissionFailed(this);
			}
		}

		public void ObjectUncovered(string id)
		{
			bool flag = IsCompleted();
			bool flag2 = IsFailed();
			foreach (UncoverItemObjective item in Objectives.OfType<UncoverItemObjective>())
			{
				item.UpdateProgress(id);
			}
			foreach (UncoverItemObjective item2 in Failstates.OfType<UncoverItemObjective>())
			{
				item2.UpdateProgress(id);
			}
			if (!flag2 && !flag && IsCompleted())
			{
				MissionManager.InvokeMissionCompleted(this);
			}
			if (!flag2 && !flag && IsFailed())
			{
				MissionManager.InvokeMissionFailed(this);
			}
		}

		public void ObjectFrozen(InteractiveWorldObject worldObject)
		{
			bool flag = IsCompleted();
			bool flag2 = IsFailed();
			foreach (FreezeObjective item in Objectives.OfType<FreezeObjective>())
			{
				item.ObjectFrozen(worldObject);
			}
			foreach (FreezeObjective item2 in Failstates.OfType<FreezeObjective>())
			{
				item2.ObjectFrozen(worldObject);
			}
			if (!flag2 && !flag && IsCompleted())
			{
				MissionManager.InvokeMissionCompleted(this);
			}
			if (!flag2 && !flag && IsFailed())
			{
				MissionManager.InvokeMissionFailed(this);
			}
		}

		public void ObjectUnfrozen(InteractiveWorldObject worldObject)
		{
			bool flag = IsCompleted();
			bool flag2 = IsFailed();
			foreach (FreezeObjective item in Objectives.OfType<FreezeObjective>())
			{
				item.ObjectUnfrozen(worldObject);
			}
			foreach (FreezeObjective item2 in Failstates.OfType<FreezeObjective>())
			{
				item2.ObjectUnfrozen(worldObject);
			}
			if (!flag2 && !flag && IsCompleted())
			{
				MissionManager.InvokeMissionCompleted(this);
			}
			if (!flag2 && !flag && IsFailed())
			{
				MissionManager.InvokeMissionFailed(this);
			}
		}

		public void ObjectCollected(string id)
		{
			bool flag = IsCompleted();
			bool flag2 = IsFailed();
			foreach (CollectItemObjective item in Objectives.OfType<CollectItemObjective>())
			{
				item.UpdateProgress(id);
			}
			foreach (CollectItemObjective item2 in Failstates.OfType<CollectItemObjective>())
			{
				item2.UpdateProgress(id);
			}
			if (!flag2 && !flag && IsCompleted())
			{
				MissionManager.InvokeMissionCompleted(this);
			}
			if (!flag2 && !flag && IsFailed())
			{
				MissionManager.InvokeMissionFailed(this);
			}
		}

		public void UpdateTimer()
		{
			bool flag = IsCompleted();
			bool flag2 = IsFailed();
			if (IsCompleted() || IsFailed())
			{
				return;
			}
			foreach (TimerObjective item in Objectives.OfType<TimerObjective>())
			{
				item.UpdateTimer();
			}
			foreach (TimerObjective item2 in Failstates.OfType<TimerObjective>())
			{
				item2.UpdateTimer();
			}
			foreach (SurveyObjective item3 in Objectives.OfType<SurveyObjective>())
			{
				item3.UpdatePercentage();
			}
			foreach (SurveyObjective item4 in Failstates.OfType<SurveyObjective>())
			{
				item4.UpdatePercentage();
			}
			if (!flag2 && !flag && IsCompleted())
			{
				MissionManager.InvokeMissionCompleted(this);
			}
			if (!flag2 && !flag && IsFailed())
			{
				MissionManager.InvokeMissionFailed(this);
			}
		}

		public string GetStatusText()
		{
			string text = "";
			if (IsCompleted())
			{
				return MissionType.ToLocalizationString();
			}
			if (IsFailed())
			{
				return LocalizationManager.GetTermTranslation("GalaxyMap/MissionFailed");
			}
			if (Objectives.Count < 1 || Objectives.Exists((MissionObjective o) => o is TimerObjective))
			{
				return MissionType.ToLocalizationString();
			}
			foreach (MissionObjective objective in Objectives)
			{
				text += objective.GetStatusText();
			}
			return text;
		}

		public string GetTitle()
		{
			return MissionType.ToLocalizationString();
		}
	}
}
