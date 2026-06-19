using System;
using System.Collections.Generic;
using System.Linq;
using Services.Save.Missions;
using UnityEngine;
using Zenject;

namespace Services.Missions
{
	public class MissionService : IMissionService, IInitializable, IDisposable
	{
		private readonly MissionEventBus _eventBus;

		private readonly MissionSaveService _missionSaveService;

		private Dictionary<string, MissionInstance> _activeMissions = new Dictionary<string, MissionInstance>();

		private Dictionary<string, MissionInstance> _completedMissions = new Dictionary<string, MissionInstance>();

		public event Action<MissionInstance> OnMissionStarted;

		public event Action<MissionInstance> OnMissionCompleted;

		public event Action<MissionInstance, ObjectiveInstance> OnObjectiveUpdated;

		[Inject]
		public MissionService(MissionEventBus eventBus, MissionSaveService saveService)
		{
			_eventBus = eventBus;
			_missionSaveService = saveService;
			_missionSaveService.OnLoadComplete += LoadFromSave;
		}

		public void Initialize()
		{
			_eventBus.OnGameEvent += HandleGameEvent;
		}

		public void Dispose()
		{
			_eventBus.OnGameEvent -= HandleGameEvent;
		}

		private void LoadFromSave()
		{
			foreach (MissionInstance activeMission in _missionSaveService.ActiveMissions)
			{
				_activeMissions[activeMission.MissionId] = activeMission;
			}
			foreach (MissionInstance completedMission in _missionSaveService.CompletedMissions)
			{
				_completedMissions[completedMission.MissionId] = completedMission;
			}
		}

		public bool StartMission(MissionDefinition def, bool ignorePrerequisites = false)
		{
			if (_activeMissions.ContainsKey(def.MissionId) || _completedMissions.ContainsKey(def.MissionId))
			{
				Debug.LogWarning("[MissionService] Mission '" + def.MissionId + "' already exists.");
				return false;
			}
			if (!ignorePrerequisites && !PrerequisitesMet(def))
			{
				Debug.LogWarning("[MissionService] Prerequisites not met for '" + def.MissionId + "'.");
				return false;
			}
			MissionInstance missionInstance = new MissionInstance(def);
			_activeMissions[def.MissionId] = missionInstance;
			_missionSaveService.AddActiveMission(missionInstance);
			this.OnMissionStarted?.Invoke(missionInstance);
			Debug.Log("[MissionService] Started: " + def.Title);
			return true;
		}

		public void FailMission(string missionId)
		{
			if (_activeMissions.TryGetValue(missionId, out var value))
			{
				value.Status = MissionStatus.Failed;
				_activeMissions.Remove(missionId);
				_missionSaveService.RemoveMission(value);
				Debug.Log("[MissionService] Failed: " + missionId);
			}
		}

		public void ForceComplete(string missionId)
		{
			if (!_activeMissions.TryGetValue(missionId, out var value))
			{
				Debug.LogWarning("[MissionService] ForceComplete: '" + missionId + "' is not active.");
				return;
			}
			foreach (ObjectiveInstance obj in value.Objectives)
			{
				ObjectiveDefinition objectiveDefinition = value.Definition.Objectives.FirstOrDefault((ObjectiveDefinition d) => d.ObjectiveId == obj.ObjectiveId);
				if (objectiveDefinition != null)
				{
					obj.CurrentAmount = objectiveDefinition.RequiredAmount;
				}
				obj.IsComplete = true;
			}
			TryComplete(missionId, value);
		}

		public MissionInstance Get(string missionId)
		{
			if (_activeMissions.TryGetValue(missionId, out var value))
			{
				return value;
			}
			return _completedMissions.GetValueOrDefault(missionId);
		}

		public MissionInstance GetActive(string missionId)
		{
			return _activeMissions.GetValueOrDefault(missionId);
		}

		public MissionInstance GetCompleted(string missionId)
		{
			return _completedMissions.GetValueOrDefault(missionId);
		}

		public bool IsActive(string missionId)
		{
			return _activeMissions.ContainsKey(missionId);
		}

		public bool IsCompleted(string missionId)
		{
			return _completedMissions.ContainsKey(missionId);
		}

		public IReadOnlyCollection<MissionInstance> GetAllActive()
		{
			return _activeMissions.Values;
		}

		public IReadOnlyCollection<MissionInstance> GetAllCompleted()
		{
			return _completedMissions.Values;
		}

		void IMissionService.MarkRewardCollected(string missionId)
		{
			MissionInstance completed = GetCompleted(missionId);
			if (completed != null)
			{
				completed.RewardCollected = true;
			}
		}

		bool IMissionService.IsRewardCollected(string missionId)
		{
			return GetCompleted(missionId)?.RewardCollected ?? false;
		}

		private void HandleGameEvent(string eventType, string targetId, int amount)
		{
			foreach (KeyValuePair<string, MissionInstance> item in _activeMissions.ToList())
			{
				item.Deconstruct(out var key, out var value);
				string missionId = key;
				MissionInstance missionInstance = value;
				MissionDefinition definition = missionInstance.Definition;
				if (definition == null)
				{
					continue;
				}
				foreach (ObjectiveDefinition objective2 in definition.Objectives)
				{
					if (!Matches(objective2, eventType, targetId))
					{
						continue;
					}
					ObjectiveInstance objective = missionInstance.GetObjective(objective2.ObjectiveId);
					if (objective != null && !objective.IsComplete)
					{
						objective.CurrentAmount = Mathf.Min(objective.CurrentAmount + amount, objective2.RequiredAmount);
						if (objective.CurrentAmount >= objective2.RequiredAmount)
						{
							objective.IsComplete = true;
						}
						this.OnObjectiveUpdated?.Invoke(missionInstance, objective);
					}
				}
				TryComplete(missionId, missionInstance);
			}
		}

		private void TryComplete(string missionId, MissionInstance instance)
		{
			if (instance.Objectives.All((ObjectiveInstance o) => o.IsComplete))
			{
				instance.Status = MissionStatus.Completed;
				instance.CompletedAt = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
				_completedMissions[missionId] = instance;
				_activeMissions.Remove(missionId);
				_missionSaveService.CompleteMission(instance);
				this.OnMissionCompleted?.Invoke(instance);
				Debug.Log("[MissionService] Completed: " + missionId);
			}
		}

		private bool PrerequisitesMet(MissionDefinition def)
		{
			return def.Prerequisites.All((string preId) => _completedMissions.ContainsKey(preId));
		}

		private static bool Matches(ObjectiveDefinition objDef, string eventType, string targetId)
		{
			if (objDef.Type.ToString().Equals(eventType, StringComparison.OrdinalIgnoreCase))
			{
				return objDef.TargetId == targetId;
			}
			return false;
		}
	}
}
