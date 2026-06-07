using System;
using Newtonsoft.Json;
using Poncle.Schema.Attributes.Attributes;
using VampireSurvivors.Data;

namespace VampireSurvivors.App.Data.Adventures
{
	[Serializable]
	public class AdventureProgressData
	{
		[JsonProperty("Type")]
		[Title("Type")]
		public AdventureAchievementType Type { get; set; }

		[JsonProperty("iconSpriteName")]
		[Title("Icon Sprite Name")]
		public string IconSpriteName { get; set; }

		[JsonProperty("iconTextureName")]
		[Title("Icon Texture Name")]
		public string IconTextureName { get; set; }

		[JsonProperty("requiredLevel")]
		[Title("Required Level")]
		public int? RequiredLevel { get; set; }

		[JsonProperty("requiredMinute")]
		[Title("Required Minute")]
		public int? RequiredMinute { get; set; }

		[JsonProperty("requiredCharacter")]
		[Title("Required Character")]
		public CharacterType? RequiredCharacter { get; set; }

		[JsonProperty("requiredStage")]
		[Title("Required Stage")]
		public StageType? RequiredStage { get; set; }

		[JsonProperty("requiredEnemyKillType")]
		[Title("Required Enemy Kill Type")]
		public EnemyType? RequiredEnemyKillType { get; set; }

		[JsonProperty("requiredEnemyKillCount")]
		[Title("Required Enemy Kill Count")]
		public int? RequiredEnemyKillCount { get; set; }

		[JsonProperty("foundWeaponType")]
		[Title("Required Found Weapon Type")]
		public WeaponType? RequiredFoundWeaponType { get; set; }

		[JsonProperty("foundCoffin")]
		[Title("Required Found Coffin Type")]
		public CharacterType? RequiredFoundCoffinType { get; set; }
	}
}
