using System.Collections.Generic;

namespace Gh.Tk.Story.Actions
{
	public class SetBuildModeFilterActionNode : ConnectedStoryNode
	{
		public bool removeFilter;

		[DropDownChoice(typeof(StoryHelper), "GetAllPropsWithoutConvenientGroupOptions")]
		public string[] allowedProps;

		[DropDownChoice(typeof(StoryHelper), "GetAllDecoPropKeys")]
		public string[] allowedDecoProps;

		public string[] allowedTemplateIds;

		public string[] categoryFilter;

		private const string _storyFlagKey = "storyBuildMenuFilter";

		private const string _categoryPrefix = "category:";

		public override void OnTrigger(ActiveStory story)
		{
		}

		public static bool IsFilterActive()
		{
			return false;
		}

		private static List<string> GetFilterList()
		{
			return null;
		}

		public static bool IsVisibleToPlayer(BuildableTemplate template)
		{
			return false;
		}
	}
}
