using System.Collections.Generic;
using UnityEngine;

namespace Brewery.Achievements
{
	[CreateAssetMenu(fileName = "NewAchievement", menuName = "Brewery/Achievements/Definition", order = 1)]
	public class AchievementDefinition : ScriptableObject
	{
		[Header("Identity")]
		[Tooltip("Unique internal ID (e.g., BREW_FIRST_BEER). Must match Steam achievement API name.")]
		[SerializeField]
		private string achievementId;

		[Tooltip("Display name shown to players")]
		[SerializeField]
		private string displayName;

		[SerializeField]
		private string displayNameKey;

		[Tooltip("Description shown to players (clear or cryptic for hidden)")]
		[TextArea(2, 4)]
		[SerializeField]
		private string description;

		[SerializeField]
		private string descriptionKey;

		[Header("Classification")]
		[Tooltip("Achievement type determines how progress is tracked")]
		[SerializeField]
		private AchievementType type;

		[Tooltip("Category for organization and filtering")]
		[SerializeField]
		private AchievementCategory category;

		[Tooltip("Rarity affects notification style")]
		[SerializeField]
		private AchievementRarity rarity;

		[Tooltip("Hidden achievements don't show description until unlocked")]
		[SerializeField]
		private bool isHidden;

		[Header("Progress Tracking")]
		[Tooltip("Target value for cumulative/milestone achievements (e.g., 100 for 'Brew 100 batches')")]
		[SerializeField]
		private int targetValue;

		[Tooltip("Event type that triggers this achievement")]
		[SerializeField]
		private AchievementTriggerType triggerType;

		[Tooltip("Optional context filter (e.g., 'beer' for brew type, 'CorporateElite' for faction)")]
		[SerializeField]
		private string triggerContext;

		[Header("Compound Achievement (if Type == Compound)")]
		[Tooltip("For compound achievements, list of sub-conditions that must ALL be met")]
		[SerializeField]
		private List<AchievementCondition> conditions;

		[Header("UI")]
		[Tooltip("Icon shown when achievement is unlocked")]
		[SerializeField]
		private Sprite unlockedIcon;

		[Tooltip("Icon shown when achievement is locked")]
		[SerializeField]
		private Sprite lockedIcon;

		public string AchievementId => null;

		public string DisplayName => null;

		public string Description => null;

		public AchievementType Type => default(AchievementType);

		public AchievementCategory Category => default(AchievementCategory);

		public AchievementRarity Rarity => default(AchievementRarity);

		public bool IsHidden => false;

		public int TargetValue => 0;

		public AchievementTriggerType TriggerType => default(AchievementTriggerType);

		public string TriggerContext => null;

		public List<AchievementCondition> Conditions => null;

		public Sprite UnlockedIcon => null;

		public Sprite LockedIcon => null;

		private void OnValidate()
		{
		}
	}
}
