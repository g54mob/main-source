using System;

namespace Gh.Tk.Story.Config
{
	[Serializable]
	public struct SecondaryNeedConfig
	{
		[DropDownChoice(typeof(StoryHelper), "GetAllPatronNeedTypes")]
		public string primaryNeed;

		[DropDownChoice(typeof(StoryHelper), "GetSecondaryNeedTypes")]
		public string secondaryNeedType;

		public string parameter;
	}
}
