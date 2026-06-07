using System;
using Newtonsoft.Json;
using Poncle.Schema.Attributes.Attributes;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Algorithm;

namespace VampireSurvivors.App.Data
{
	[Serializable]
	public class FollowerData
	{
		[JsonProperty("followerCharacter")]
		[Title("Follower Character")]
		public CharacterType FollowerCharacter { get; set; }

		[JsonProperty("followerAI")]
		[Title("Follower AI")]
		public AIType FollowerAI { get; set; }

		[JsonProperty("isFollowerInvinceable")]
		[Title("Is Follower Invincible")]
		public bool IsFollowerInvinceable { get; set; }

		[JsonProperty("countsAsMainCharacterForRevivals")]
		[Title("Counts as Main Character for Revivals")]
		public bool CountsAsMainCharacterForRevivals { get; set; }

		[JsonProperty("manualLevelUps")]
		[Title("Manual LevelUps")]
		public bool ManualLevelUps { get; set; }

		[JsonProperty("trackedByCamera")]
		[Title("Tracked By Camera")]
		public bool TrackedByCamera { get; set; }

		[JsonProperty("shouldFollowMainPlayer")]
		[Title("Should Follow Main Player")]
		public bool ShouldFollowMainPlayer { get; set; }

		[JsonProperty("allowDuplicates")]
		[Title("Allow Duplicates")]
		public bool AllowDuplicates { get; set; }

		[JsonProperty("everyXLevels")]
		[Title("Every X Levels")]
		public int EveryXLevels { get; set; }

		[JsonProperty("ShouldSharePassives")]
		[Title("Should Share Passives")]
		public bool ShouldSharePassives { get; set; }

		[JsonProperty("ShouldFollowerReactToArcanas")]
		[Title("Should Follower React To Arcanas")]
		public bool ShouldFollowerReactToArcanas { get; set; }
	}
}
