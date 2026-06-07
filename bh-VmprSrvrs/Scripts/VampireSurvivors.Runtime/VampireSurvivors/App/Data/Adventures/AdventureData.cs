using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Poncle.Schema.Attributes.Attributes;
using VampireSurvivors.Achievements;
using VampireSurvivors.App.Scripts.Data;
using VampireSurvivors.Data;

namespace VampireSurvivors.App.Data.Adventures
{
	[Serializable]
	public class AdventureData
	{
		[JsonProperty("index")]
		[Title("Index")]
		public int Index { get; set; }

		[JsonProperty("progressKey")]
		[Title("Progress Key")]
		public string ProgressKey { get; set; }

		[JsonProperty("coreAdventureData")]
		[Title("Core Adventure Data")]
		public CoreAdventureData CoreAdventureData { get; set; }

		[JsonProperty("CHARACTER_DATA")]
		[Title("Character Data")]
		public List<CharacterType> CharacterTypes { get; set; }

		[JsonProperty("STAGE_DATA")]
		[Title("Stage Data")]
		public StageSetType StageSetType { get; set; }

		[JsonProperty("WEAPON_DATA")]
		[Title("Weapon Data")]
		public List<WeaponType> WeaponTypes { get; set; }

		[JsonProperty("PROGRESS_DATA")]
		[Title("Progress Data")]
		public List<AchievementData> ProgressData { get; set; }

		[JsonProperty("EXTRA_BESTIARY_TYPES")]
		[Title("Extra Bestiary Types")]
		public List<EnemyType> ExtraBestiaryTypes { get; set; }
	}
}
