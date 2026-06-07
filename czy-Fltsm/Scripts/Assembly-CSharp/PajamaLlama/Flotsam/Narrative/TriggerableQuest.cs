using System;
using UnityEngine;

namespace PajamaLlama.Flotsam.Narrative
{
	[Serializable]
	public class TriggerableQuest : ScenarioTriggerableBase
	{
		public enum QuestGiver
		{
			FirstMate = 0,
			TriggerActor = 1,
			ActorProfile = 0x10
		}

		[Header("Quest")]
		[SerializeField]
		private QuestProperties _questProperties;

		[SerializeField]
		private QuestGiver _questGiver;

		[SerializeField]
		[ConditionalEnumHide("_questGiver", 16, true)]
		private AgentProfile _actorProfile;

		[SerializeField]
		[Min(0f)]
		private float _delay;

		[SerializeField]
		private bool _validateQuestVariableConditions;

		private AgentDescriptor _actor;

		private int _worldTileIndex;

		protected override bool Trigger(AgentDescriptor actor = null)
		{
			if (CanTrigger())
			{
				GameEventDispatcher.AddListener(GameEventType.QuestStarted, OnQuestStarted);
				GameEventDispatcher.AddListener(GameEventType.QuestFailed, OnQuestFailed);
				_actor = actor;
				if (StoryManager.StartQuest(_questProperties, GetQuestGiver(actor), _delay) == null)
				{
					GameEventDispatcher.AddListener(GameEventType.StoryManagerStart, OnStoryManagerStart);
				}
				return true;
			}
			return false;
		}

		private void OnStoryManagerStart(GameEvent gameEvent)
		{
			GameEventDispatcher.RemoveListener(GameEventType.StoryManagerStart, OnStoryManagerStart);
			StoryManager.StartQuest(_questProperties, GetQuestGiver(_actor), _delay);
		}

		private void OnQuestStarted(GameEvent gameEvent)
		{
			if (gameEvent is QuestEvent questEvent && questEvent.Quest.Properties == _questProperties)
			{
				GameEventDispatcher.RemoveListener(GameEventType.QuestStarted, OnQuestStarted);
				GameEventDispatcher.RemoveListener(GameEventType.QuestFailed, OnQuestFailed);
				GameEventDispatcher.RemoveListener(GameEventType.MapDeactivated, OnMapDeactivated);
				_actor = null;
			}
		}

		private void OnQuestFailed(GameEvent gameEvent)
		{
			if (gameEvent is QuestEvent questEvent && questEvent.Quest.Properties == _questProperties)
			{
				GameEventDispatcher.RemoveListener(GameEventType.QuestFailed, OnQuestFailed);
				Debug.LogException(new Exception($"Triggerable Quest Failed: {_questProperties}"));
				TriggerFallback();
			}
		}

		private void TriggerFallback()
		{
			if (WorldManager.TryReturnCurrentRegion(out var region))
			{
				_worldTileIndex = region.WorldTile.Index;
			}
			GameEventDispatcher.AddListener(GameEventType.MapDeactivated, OnMapDeactivated);
		}

		private void OnMapDeactivated(GameEvent gameEvent)
		{
			if (WorldManager.TryReturnCurrentRegion(out var region) && _worldTileIndex < region.WorldTile.Index)
			{
				_worldTileIndex = region.WorldTile.Index;
				StoryManager.StartQuest(_questProperties, GetQuestGiver(_actor));
			}
		}

		public AgentDescriptor GetQuestGiver(AgentDescriptor actor)
		{
			switch (_questGiver)
			{
			case QuestGiver.FirstMate:
				return StoryManager.DialogueContext.GetActor(DialogueContext.ActorType.FirstMate);
			case QuestGiver.TriggerActor:
				if (actor == null)
				{
					Debug.LogException(new ArgumentException("TriggerableQuest has QuestGiver.TriggerActor selected, but the trigge actor is NULL"));
				}
				return actor;
			case QuestGiver.ActorProfile:
				return _actorProfile.GetDescriptor();
			default:
				return null;
			}
		}

		protected override bool GetWasTriggered()
		{
			Quest questInstance;
			return StoryManager.TryGetQuest(_questProperties, out questInstance);
		}

		internal override void RestoreWasTriggered()
		{
			if (GetWasTriggered())
			{
				base.RestoreWasTriggered();
			}
		}

		private bool CanTrigger()
		{
			if (!_validateQuestVariableConditions || _questProperties.AreVariableConditionsMet())
			{
				if (!base.IsRetriggerable)
				{
					return !GetWasTriggered();
				}
				return true;
			}
			return false;
		}
	}
}
