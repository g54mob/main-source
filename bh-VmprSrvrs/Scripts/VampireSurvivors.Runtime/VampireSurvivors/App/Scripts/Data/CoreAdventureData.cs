using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Poncle.Schema.Attributes.Attributes;
using VampireSurvivors.Achievements;
using VampireSurvivors.Data;

namespace VampireSurvivors.App.Scripts.Data
{
	[Serializable]
	public class CoreAdventureData
	{
		[JsonProperty("name")]
		[Title("Adventure Name")]
		public string AdventureName { get; set; }

		[JsonProperty("subtitleImage")]
		[Title("Subtitle Image")]
		public string SubtitleImage { get; set; }

		[JsonProperty("startingCoins")]
		[Title("Starting Coins")]
		public int StartingCoins { get; set; }

		[JsonProperty("startingCharacter")]
		[Title("Starting Character")]
		public CharacterType StartingCharacter { get; set; }

		[JsonProperty("startingStage")]
		[Title("Starting Stage")]
		public StageType StartingStage { get; set; }

		[JsonProperty("spriteName")]
		[Title("Sprite Name")]
		public string SpriteName { get; set; }

		[JsonProperty("texture")]
		[Title("Texture")]
		public string Texture { get; set; }

		[JsonProperty("requiresDLC")]
		[Title("Requires DLC")]
		public DlcType? RequiresDLC { get; set; }

		[JsonProperty("completionCoinReward")]
		[Title("Completion Reward")]
		public int CompletionCoinReward { get; set; }

		[JsonProperty("completionSkinsReward")]
		[Title("Completion Skins")]
		public List<SkinToUnlock> CompletionSkinsReward { get; set; }
	}
}
