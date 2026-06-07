using System;
using UnityEngine;

namespace Brewery.Skills
{
	[Serializable]
	public class SkillDefinition
	{
		[Header("Identity")]
		[Tooltip("The SkillType enum value this definition is for")]
		public SkillType skillType;

		[Tooltip("Display name shown in UI")]
		public string displayName;

		[Header("Category")]
		[Tooltip("Category ID this skill belongs to (must match a SkillCategoryConfig.categoryId)")]
		public string categoryId;

		[Header("Description")]
		[TextArea(2, 5)]
		[Tooltip("Description shown in skill details panel")]
		public string description;

		[Header("Localization")]
		[SerializeField]
		private string displayNameKey;

		[SerializeField]
		private string descriptionKey;

		[Header("Associations (Optional)")]
		[Tooltip("Associated station ID (for duration skills)")]
		public string stationId;

		[Tooltip("Associated NPC profile name (for trading discount skills)")]
		public string npcProfileId;

		[Tooltip("Associated catalyst name (for catalyst bonus skills)")]
		public string catalystName;

		[Tooltip("Associated brew type: Beer, Wine, or Spirits (for base value/barrel skills)")]
		public string brewType;

		[Tooltip("Associated faction name (for faction sell bonus skills)")]
		public string factionName;

		[Header("Base Values")]
		[Tooltip("Original base value (for Base Drink Value skills: Beer=5, Wine=7, Spirits=11)")]
		public int originalBaseValue;

		[Tooltip("Base bottle count (for Barrel Output skills)")]
		public int baseBottleCount;

		[Header("Icon")]
		[Tooltip("Icon sprite for this skill (displayed in skill tree UI)")]
		public Sprite icon;

		[Tooltip("Badge overlay sprite for composite skill icons (optional)")]
		public Sprite badge;

		public string GetDisplayName()
		{
			return null;
		}

		public string GetLocalizedDescription()
		{
			return null;
		}
	}
}
