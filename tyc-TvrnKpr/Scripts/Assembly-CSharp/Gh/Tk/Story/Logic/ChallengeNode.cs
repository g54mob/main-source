using XNode;

namespace Gh.Tk.Story.Logic
{
	[NodeTint("#80463c")]
	public class ChallengeNode : ChallengeBaseNode, IStoryNodeHasComplexity
	{
		public StoryComplexity complexityValue;

		public StoryComplexity StoryComplexity => default(StoryComplexity);

		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
