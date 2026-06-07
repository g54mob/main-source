using System;

namespace VampireSurvivors.Data
{
	[Serializable]
	public class MusicData
	{
		public string title { get; set; }

		public string author { get; set; }

		public string source { get; set; }

		public StageType? unlockedByStage { get; set; }

		public CharacterType? unlockedByCharacter { get; set; }

		public ItemType? unlockedByItem { get; set; }

		public bool isUnlocked { get; set; }

		public string icon { get; set; }

		public HyperMod hyperMod { get; set; }

		public ForsakenMod forsakenMod { get; set; }

		public string GetLocalizedTitle(BgmType t)
		{
			return null;
		}
	}
}
