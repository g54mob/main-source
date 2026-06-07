using System;

namespace Gh.Tk
{
	[Serializable]
	public enum StoryFlagScope : sbyte
	{
		LocalStory = 0,
		LevelStory = 1,
		GlobalProfile = 2,
		LevelStoryTemporary = 3
	}
}
