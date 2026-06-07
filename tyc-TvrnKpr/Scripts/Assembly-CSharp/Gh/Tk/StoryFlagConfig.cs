using System;
using Gh.Tk.Story;

namespace Gh.Tk
{
	[Serializable]
	public struct StoryFlagConfig
	{
		[DropDownChoice(typeof(StoryHelper), "GetAllStoryFlags")]
		public string id;

		public StoryFlagScope scope;

		public bool addValue;

		public int value;
	}
}
