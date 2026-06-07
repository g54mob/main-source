using System;
using System.Collections.Generic;
using UnityEngine;

namespace Brewery.Quest
{
	[Serializable]
	public class QuestStep
	{
		[Header("Identity")]
		[Tooltip("Unique identifier for this step")]
		public string stepId;

		[Header("Display")]
		[Tooltip("Short title shown in the UI")]
		public string title;

		[Tooltip("Description/narrative text for this objective (what the quest giver says)")]
		[TextArea(2, 5)]
		public string description;

		[Tooltip("What the TARGET NPC says when you reach them. If empty, uses description.")]
		[TextArea(2, 5)]
		public string targetDialogue;

		[Tooltip("Optional hint text shown below the description (e.g., key prompts for tutorial steps)")]
		public string hint;

		[Header("Localization")]
		[SerializeField]
		private string titleKey;

		[SerializeField]
		private string descriptionKey;

		[SerializeField]
		private string hintKey;

		[Header("Completion")]
		[Tooltip("The event type that completes this step")]
		public QuestEventType completionEvent;

		[Tooltip("Optional context filter (e.g., 'npcId:tradeId'). Empty = any context matches.")]
		public string eventContext;

		[Header("Map Marker")]
		[Tooltip("Show a marker on the map for this objective?")]
		public bool showMapMarker;

		[Tooltip("(Legacy - doesn't work with ScriptableObjects) The transform to mark on the map")]
		public Transform objectiveLocation;

		[Header("Location Target")]
		[Tooltip("Location ID to show marker for (finds QuestLocationMarker in scene). Used for buildings, stations, areas.")]
		public string targetLocationId;

		[Header("NPC Target")]
		[Tooltip("NPC ID to show marker/indicator on (for turn-in or talk-to objectives)")]
		public string targetNpcId;

		[Header("Item Target")]
		[Tooltip("Item ID to show marker for (finds closest ItemPickup in scene). Used for pickup objectives.")]
		public string targetItemId;

		[Header("Auto-Advance")]
		[Tooltip("If > 0, auto-advance to next step after this many seconds (useful for story beats)")]
		public float autoAdvanceDelay;

		[Header("Step Reward")]
		[Tooltip("Reward given when this step is completed")]
		public QuestReward stepReward;

		[Header("Item Delivery")]
		[Tooltip("Items required for delivery. Format: 'itemId:quantity,itemId:quantity' (e.g., 'honey:3,empty_bottle:10')")]
		public string requiredItems;

		[Header("Progress Display")]
		[Tooltip("Item ID for progress tracking (e.g., 'Corn'). Used to query inventory count.")]
		public string progressItemId;

		[Tooltip("Required quantity for completion (e.g., 10)")]
		public int requiredQuantity;

		[Tooltip("Icon to show in progress display (optional - if null, loads from ItemRegistry using progressItemId)")]
		public Sprite progressIcon;

		[Header("Display Icon")]
		[Tooltip("Item ID to show icon for (without progress count). Useful for 'show item to NPC' steps.")]
		public string displayItemId;

		[Header("Partial Delivery Support")]
		[Tooltip("Allow partial deliveries for this step (cumulative tracking)")]
		public bool allowPartialDelivery;

		[Tooltip("Show delivery progress in UI like 'Delivered: 10/50'")]
		public bool showDeliveryProgress;

		[Header("Multi-Objective Support")]
		[Tooltip("List of sub-objectives for this step. If not empty, step completes when ALL objectives are done.")]
		public List<QuestObjective> objectives;

		[Tooltip("If true, objectives must be completed in order (only first uncompleted objective can match events).")]
		public bool orderedObjectives;

		[Tooltip("When orderedObjectives is true, this many objectives at the start can be completed in any order. 0 = all sequential.")]
		public int unorderedObjectiveCount;

		public bool RequiresDelivery => false;

		public bool ShowsProgress => false;

		public bool ShowsDisplayIcon => false;

		public bool HasMultipleObjectives => false;

		public bool AllObjectivesCompleted => false;

		public string GetLocalizedTitle()
		{
			return null;
		}

		public string GetLocalizedDescription()
		{
			return null;
		}

		public string GetLocalizedHint()
		{
			return null;
		}

		public void ResetObjectives()
		{
		}

		public bool TryCompleteObjective(QuestEventType eventType, string context)
		{
			return false;
		}

		private static List<string> SplitRequiredItems(string items)
		{
			return null;
		}

		public Dictionary<string, int> GetRequiredItemsDict()
		{
			return null;
		}

		public List<RequiredItemInfo> GetRequiredItemsInfo()
		{
			return null;
		}

		public bool HasCatalyzedRequirements()
		{
			return false;
		}

		public string GetDialogueForNpc(string npcId)
		{
			return null;
		}

		public bool MatchesEvent(QuestEventType eventType, string context)
		{
			return false;
		}
	}
}
