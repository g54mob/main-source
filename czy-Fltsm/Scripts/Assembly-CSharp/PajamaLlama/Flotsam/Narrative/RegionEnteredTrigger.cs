using System;
using PajamaLlama.Flotsam.World;
using UnityEngine;

namespace PajamaLlama.Flotsam.Narrative
{
	[Serializable]
	public class RegionEnteredTrigger : IScenarioTrigger
	{
		[Tooltip("Cooldown between triggering in seconds")]
		[SerializeField]
		private float _cooldown = 900f;

		[SerializeReference]
		[SubclassSelector]
		private IScenarioTriggerableCondition[] _conditions;

		[Tooltip("Triggered the first time a region with a scout landmark is entered.")]
		[SerializeReference]
		[SubclassSelector]
		private ScenarioTriggerableBase _firstScoutableRegionTriggerable;

		[Tooltip("When triggered the quest triggerables will be traversed first. Only one quest triggerable can be triggered at a time.")]
		[SerializeReference]
		[SubclassSelector]
		private TriggerableQuest[] _triggerableQuests;

		[Tooltip("When no quest triggerable was triggered, this list is traversed in order. Only one triggerable can be triggered at a time.")]
		[SerializeReference]
		[SubclassSelector]
		private ScenarioTriggerableBase[] _triggerables;

		[NonSerialized]
		private float _lastTriggerTimeStamp;

		public void Initialize()
		{
			GameEventDispatcher.AddListener(GameEventType.RegionEntered, OnRegionEntered);
		}

		public void Uninitialize()
		{
			GameEventDispatcher.RemoveListener(GameEventType.RegionEntered, OnRegionEntered);
		}

		private void OnRegionEntered(GameEvent gameEvent)
		{
			if (!(gameEvent is MapEvent mapEvent) || (_firstScoutableRegionTriggerable != null && IsFirstScoutableRegion(mapEvent.Region) && _firstScoutableRegionTriggerable.TryTrigger()) || !mapEvent.Region.HasUnscoutedDisabledLandmarks() || mapEvent.Region.StartQuest())
			{
				return;
			}
			float currentPlayTime = GameManager.TimeManager.CurrentPlayTime;
			if (currentPlayTime - _lastTriggerTimeStamp < _cooldown)
			{
				return;
			}
			IScenarioTriggerableCondition[] conditions = _conditions;
			for (int i = 0; i < conditions.Length; i++)
			{
				if (!conditions[i].IsMet())
				{
					return;
				}
			}
			if (Trigger())
			{
				_lastTriggerTimeStamp = currentPlayTime;
			}
		}

		private bool Trigger()
		{
			TriggerableQuest[] triggerableQuests = _triggerableQuests;
			for (int i = 0; i < triggerableQuests.Length; i++)
			{
				if (triggerableQuests[i].TryTrigger())
				{
					return true;
				}
			}
			ScenarioTriggerableBase[] triggerables = _triggerables;
			for (int i = 0; i < triggerables.Length; i++)
			{
				if (triggerables[i].TryTrigger())
				{
					return true;
				}
			}
			return false;
		}

		private bool IsFirstScoutableRegion(IWorldRegion region)
		{
			if (region.WorldTile.Index != 0 || !region.TryReturnScoutingLandmark(out var scoutingLandmark))
			{
				return false;
			}
			foreach (IWorldRegion neighbor in region.Neighbors)
			{
				if ((neighbor.Flags & WorldRegionFlags.Visited) != WorldRegionFlags.None && region.TryReturnScoutingLandmark(out scoutingLandmark))
				{
					return false;
				}
			}
			return true;
		}
	}
}
