using System;
using UnityEngine;

namespace Brewery.Quest
{
	[Serializable]
	public class QuestObjective
	{
		[Tooltip("Short description shown in UI (e.g., 'Buy Water Container')")]
		public string description;

		[Tooltip("Event type that completes this objective")]
		public QuestEventType completionEvent;

		[Tooltip("Event context filter (e.g., 'wheatbeards_market:WaterContainer'). Case-insensitive matching.")]
		public string eventContext;

		[Tooltip("Item ID for icon lookup (uses ItemRegistry to get icon). Leave empty for no icon.")]
		public string itemId;

		[Header("Progress Tracking")]
		[Tooltip("Item ID for progress tracking (e.g., 'Corn'). Used to query inventory count.")]
		public string progressItemId;

		[Tooltip("Required quantity for completion (e.g., 10). Set to 0 for single event objectives.")]
		public int requiredQuantity;

		[NonSerialized]
		public bool isCompleted;

		public bool ShowsProgress => false;

		public bool MatchesEvent(QuestEventType eventType, string context)
		{
			return false;
		}

		private bool MatchesItemCollectedEvent(string triggeredContext)
		{
			return false;
		}
	}
}
