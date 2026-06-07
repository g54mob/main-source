using System;
using Gh.Tk.Story;

namespace Gh.Tk
{
	[Serializable]
	public class ConversationAnimationIconPreset
	{
		[Serializable]
		public class ConversationAnimationIconPresetConfig
		{
			public byte minTier;

			public byte maxTier;

			[DropDownChoice(typeof(StoryHelper), "GetRaces")]
			public string race;

			[DropDownChoice(typeof(StoryHelper), "GetIcons")]
			public string[] icons;

			private int GetEffectiveMinTier()
			{
				return 0;
			}

			private int GetEffectiveMaxTier()
			{
				return 0;
			}

			public bool MatchesActor(Actor actor)
			{
				return false;
			}
		}

		public string name;

		public ConversationAnimationIconPresetConfig[] iconSettings;
	}
}
