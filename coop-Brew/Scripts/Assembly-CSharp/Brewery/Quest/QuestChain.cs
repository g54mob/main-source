using System.Collections.Generic;
using UnityEngine;

namespace Brewery.Quest
{
	[CreateAssetMenu(fileName = "NewQuestChain", menuName = "Quest/Quest Chain", order = 1)]
	public class QuestChain : ScriptableObject
	{
		[Header("Chain Identity")]
		[Tooltip("Unique identifier for this quest chain")]
		public string chainId;

		[Tooltip("Display name shown in UI (if needed)")]
		public string displayName;

		[Tooltip("NPC ID of the quest giver (for categorization in editors)")]
		public string giverNpcId;

		[Header("Story")]
		[Tooltip("Brief description of this quest chain's narrative")]
		[TextArea(2, 4)]
		public string storyDescription;

		[Header("Localization")]
		[SerializeField]
		private string displayNameKey;

		[SerializeField]
		private string storyDescriptionKey;

		[Header("Visual")]
		[Tooltip("Optional icon for this quest in the Quest Log")]
		public Sprite questIcon;

		[Header("Rewards (Future)")]
		[Tooltip("Rewards given on quest completion - implementation coming later")]
		public QuestReward completionReward;

		[Header("Steps")]
		[Tooltip("Sequential list of objectives in this chain")]
		public List<QuestStep> steps;

		public int StepCount => 0;

		public string GetDisplayName()
		{
			return null;
		}

		public string GetLocalizedStoryDescription()
		{
			return null;
		}

		public QuestStep GetStep(int index)
		{
			return null;
		}

		public bool IsComplete(int stepIndex)
		{
			return false;
		}

		public int FindStepIndex(string stepId)
		{
			return 0;
		}

		private void OnValidate()
		{
		}
	}
}
