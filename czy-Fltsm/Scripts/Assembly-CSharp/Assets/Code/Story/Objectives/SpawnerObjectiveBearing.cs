using System;
using UnityEngine;
using UnityEngine.PajamaLlama;
using UnityEngine.Serialization;

namespace Assets.Code.Story.Objectives
{
	[Serializable]
	public class SpawnerObjectiveBearing : IWorldMapCompassBearingTarget
	{
		[SerializeField]
		private bool _enabled = true;

		[SerializeField]
		[Tooltip("The scouting state that will be applied when the bearing becomes active.")]
		private ScoutingState _scoutingState;

		[SerializeField]
		[ConditionalHide("_enabled", true)]
		[Tooltip("The bearing icon that is used. When no icon is set the set on the spawner will be used.")]
		private Sprite _bearingIcon;

		[SerializeField]
		[ConditionalHide("_enabled", true)]
		[Tooltip("Features that are enabled for this bearing")]
		private BearingFeatures _bearingFeatures = BearingFeatures.Compass | BearingFeatures.Marker;

		[SerializeField]
		[ConditionalHide("_enabled", true)]
		[Tooltip("Should the fog of war be cleared when the bearing is enabled? (This setting only works for landmarks)")]
		[FormerlySerializedAs("_clearLandmarkFogOfWar")]
		private bool _clearFogOfWar;

		[Header("Conditions")]
		[SerializeField]
		[NamedArrayElement(new string[] { })]
		private int[] _completedObjectivesCondition;

		private IQuestObjective _objective;

		private ISpawner _spawner;

		public bool Enabled => _enabled;

		public bool Active { get; private set; }

		public Vector3 WorldPosition { get; private set; }

		public Sprite BearingIcon { get; private set; }

		public BearingFeatures BearingFeatures => _bearingFeatures;

		public SpawnerObjectiveBearing(SpawnerObjectiveBearing other)
		{
			_enabled = other._enabled;
			_scoutingState = other._scoutingState;
			_bearingIcon = other._bearingIcon;
			_bearingFeatures = other._bearingFeatures;
			_clearFogOfWar = other._clearFogOfWar;
			_completedObjectivesCondition = other._completedObjectivesCondition;
			Active = other.Active;
			WorldPosition = other.WorldPosition;
			BearingIcon = other.BearingIcon;
			_objective = other._objective;
			_spawner = other._spawner;
		}

		public void Initialize(IQuestObjective objective, ISpawner spawner)
		{
			_objective = objective;
			_spawner = spawner;
			Active = false;
			WorldPosition = spawner.WorldPosition;
			BearingIcon = ((_bearingIcon != null) ? _bearingIcon : spawner.BearingIcon);
		}

		public void Uninitialize()
		{
			Active = false;
			MapEvent.DispatchCompassBearingTargetEvent(this);
			_objective = null;
			_spawner = null;
		}

		public void SetActive(bool active)
		{
			if (_enabled && Active != active)
			{
				Active = active;
				if (Active)
				{
					Activate();
				}
				else
				{
					GameEventDispatcher.RemoveListener(GameEventType.QuestObjectiveUpdated, OnQuestObjectiveUpdated);
				}
				MapEvent.DispatchCompassBearingTargetEvent(this);
			}
		}

		private bool Activate()
		{
			if (AreConditionsMet())
			{
				_spawner.SetScoutingState(_scoutingState);
				if (_clearFogOfWar)
				{
					WorldManager.ClearFogOfWar(_spawner);
				}
				return true;
			}
			GameEventDispatcher.AddListener(GameEventType.QuestObjectiveUpdated, OnQuestObjectiveUpdated);
			return false;
		}

		private void OnQuestObjectiveUpdated(GameEvent gameEvent)
		{
			GameEventDispatcher.RemoveListener(GameEventType.QuestObjectiveUpdated, OnQuestObjectiveUpdated);
			if (Activate())
			{
				MapEvent.DispatchCompassBearingTargetEvent(this);
			}
		}

		public bool IsBearingActive()
		{
			if (_enabled && Active && AreConditionsMet() && _objective != null)
			{
				return !_objective.IsCompleted();
			}
			return false;
		}

		public bool IsBearingTo(WorldMapScoutingId scoutingId)
		{
			if (_spawner != null)
			{
				return _spawner.ScoutingId == scoutingId;
			}
			return false;
		}

		public bool IsBearingTo(ISpawner spawner)
		{
			return _spawner == spawner;
		}

		private bool AreConditionsMet()
		{
			if (_completedObjectivesCondition.IsNullOrEmpty())
			{
				return true;
			}
			int[] completedObjectivesCondition = _completedObjectivesCondition;
			foreach (int index in completedObjectivesCondition)
			{
				if (_objective.Quest.Objectives.Objectives.TryGetValue(index, out var value) && value != _objective && !value.IsCompleted())
				{
					return false;
				}
			}
			return true;
		}
	}
}
