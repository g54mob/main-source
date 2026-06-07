using System;
using System.Collections.Generic;
using PajamaLlama.Distribution;
using PajamaLlama.Flotsam.World;
using UnityEngine;
using UnityEngine.Serialization;

namespace PajamaLlama.Flotsam.Narrative
{
	[Serializable]
	public class RegionTriggers : IScenarioTrigger
	{
		[Header("Region Entered")]
		[SerializeField]
		[Tooltip("Triggers when first region is entered, irregardless of 'Region Entered Trigger Conditions'")]
		private SerializeReferencePickingList<ScenarioTriggerableBase> _firstEnteredRegionTriggerables;

		[SerializeReference]
		[InstantiateSerializeReference]
		private TriggerableQuest[] _regionEnteredTriggerableQuests;

		[Header("Scout Region")]
		[SerializeField]
		private SerializeReferencePickingList<ScenarioTriggerableBase> _firstScoutedRegionTriggerables;

		[SerializeField]
		private int _firstScoutedRegionMaxTriggerCount = 2;

		[SerializeReference]
		[InstantiateSerializeReference]
		[FormerlySerializedAs("_regionEnteredTriggerConditions")]
		private IScenarioTriggerableCondition[] _regionEnteredFallbackTriggerConditions;

		[Header("Default")]
		[SerializeReference]
		[InstantiateSerializeReference]
		private TriggerableQuest[] _triggerableQuests;

		[SerializeReference]
		[InstantiateSerializeReference]
		[FormerlySerializedAs("_triggerables")]
		private ScenarioTriggerableBase[] _spawningTriggerables;

		public static List<IWorldRegion> Regions { get; private set; } = new List<IWorldRegion>(8);

		public void Initialize()
		{
			TriggerableQuest[] triggerableQuests = _triggerableQuests;
			for (int i = 0; i < triggerableQuests.Length; i++)
			{
				triggerableQuests[i].Initialize();
			}
			GameEventDispatcher.AddListener(GameEventType.RegionEntered, OnRegionEntered);
			GameEventDispatcher.AddListener(GameEventType.ScoutRegion, OnScoutRegion);
			GameEventDispatcher.AddListener(GameEventType.RegionScouted, OnRegionScouted);
		}

		public void Uninitialize()
		{
			GameEventDispatcher.RemoveListener(GameEventType.RegionEntered, OnRegionEntered);
			GameEventDispatcher.RemoveListener(GameEventType.ScoutRegion, OnScoutRegion);
			GameEventDispatcher.RemoveListener(GameEventType.RegionScouted, OnRegionScouted);
		}

		private void OnRegionEntered(GameEvent gameEvent)
		{
			if (!(gameEvent is MapEvent mapEvent))
			{
				return;
			}
			if (mapEvent.Region.IsFirstWithFlags(WorldRegionFlags.Visited))
			{
				PickAndTrigger(_firstEnteredRegionTriggerables);
			}
			else
			{
				if (!WorldManager.TryReturnCurrentRegion(out var region))
				{
					return;
				}
				Regions.Clear();
				Regions.Add(region);
				TriggerableQuest[] regionEnteredTriggerableQuests = _regionEnteredTriggerableQuests;
				for (int i = 0; i < regionEnteredTriggerableQuests.Length; i++)
				{
					if (regionEnteredTriggerableQuests[i].TryTrigger())
					{
						return;
					}
				}
				if (ConditionsAreMet(_regionEnteredFallbackTriggerConditions))
				{
					TriggerDefault();
				}
			}
		}

		private void OnScoutRegion(GameEvent gameEvent)
		{
			if (gameEvent is ScoutingEvent scoutingEvent)
			{
				IWorldRegion region;
				if (scoutingEvent.Region.IsFirstWithFlags(WorldRegionFlags.Scouted) && !_firstScoutedRegionTriggerables.IsEmpty())
				{
					PickAndTrigger(_firstScoutedRegionTriggerables, _firstScoutedRegionMaxTriggerCount);
				}
				else if (WorldManager.TryReturnCurrentRegion(out region))
				{
					AgentDescriptor actorDescriptor = ((scoutingEvent.Agent != null) ? scoutingEvent.Agent.Descriptor : null);
					Regions.Clear();
					Regions.AddRange(region.Neighbors);
					TriggerDefault(actorDescriptor);
				}
			}
		}

		private void OnRegionScouted(GameEvent gameEvent)
		{
			_ = gameEvent is ScoutingEvent;
		}

		private void TriggerDefault(AgentDescriptor actorDescriptor = null)
		{
			TriggerableQuest[] triggerableQuests = _triggerableQuests;
			for (int i = 0; i < triggerableQuests.Length && !triggerableQuests[i].TryTrigger(actorDescriptor); i++)
			{
			}
			ScenarioTriggerableBase[] spawningTriggerables = _spawningTriggerables;
			for (int i = 0; i < spawningTriggerables.Length; i++)
			{
				spawningTriggerables[i].TryTrigger(actorDescriptor);
			}
		}

		private void PickAndTrigger<T>(PickingListBase<T> pickingList, int max = 1) where T : ScenarioTriggerableBase
		{
			int num = 0;
			int count = pickingList.Count;
			while (0 < count--)
			{
				if (pickingList.TryPickItem(out var pickedItem) && pickedItem.TryTrigger())
				{
					num++;
					if (max <= num)
					{
						break;
					}
				}
			}
		}

		private bool ConditionsAreMet(IScenarioTriggerableCondition[] conditions)
		{
			for (int i = 0; i < conditions.Length; i++)
			{
				if (!conditions[i].IsMet())
				{
					return false;
				}
			}
			return true;
		}
	}
}
