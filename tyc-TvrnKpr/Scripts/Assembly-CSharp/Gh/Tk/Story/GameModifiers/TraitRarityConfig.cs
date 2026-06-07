using System;

namespace Gh.Tk.Story.GameModifiers
{
	[Serializable]
	public class TraitRarityConfig
	{
		[DropDownChoice(typeof(StoryHelper), "GetActorTraits")]
		public string traitType;

		public TraitRarityRaceConfig[] rarity;
	}
}
