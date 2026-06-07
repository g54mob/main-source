using UnityEngine;
using XNode;

namespace Gh.Tk.Story.Narrative
{
	[NodeTint("#8E824D")]
	[NodeWidth(450)]
	public class GazetteNode : ConnectedStoryNode
	{
		[StoryNodeTranslateFieldContent("Gazette Headline", "Gazette")]
		public string topStoryHeadline;

		[TextArea(10, 20)]
		[StoryNodeTranslateFieldContent("Gazette Content", "Gazette")]
		public string topStoryContent;

		[StoryNodeTranslateFieldContent("Gazette Price Override", "Gazette")]
		public string priceOverride;

		[Tooltip("Only 3 side stories are supported atm")]
		[StoryNodeTranslateFieldContent("Gazette Side story", "Gazette")]
		public string[] sideStories;

		public string topStoryImage;

		[Tooltip("If true, this will bypass the usual timing logic and show the gazette immediately")]
		public bool showImmediately;

		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
