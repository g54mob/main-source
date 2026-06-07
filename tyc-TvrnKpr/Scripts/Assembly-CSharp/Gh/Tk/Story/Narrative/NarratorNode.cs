using UnityEngine;
using XNode;

namespace Gh.Tk.Story.Narrative
{
	[NodeTint("#466969")]
	public class NarratorNode : ConnectedStoryNode, IStoryNodeHasComplexity
	{
		[Range(0f, 2f)]
		[Tooltip("If a delay is configured, the node will first count down the delay before triggering the narrator")]
		public float unscaledDelayInSeconds;

		[TextArea(6, 6)]
		public string Text;

		[Tooltip("If true, the narrator will be automatically skipped when something else wants to be narrated.")]
		public bool IsAutoSkipped;

		public StoryComplexity StoryComplexity => default(StoryComplexity);

		private string CountdownKey => null;

		public override void OnTrigger(ActiveStory story)
		{
		}

		private void StartCountdown(ActiveStory story, float delayInSecondsF)
		{
		}

		public override void OnUpdate(ActiveStory story)
		{
		}

		private void TriggerNarrator(ActiveStory story)
		{
		}
	}
}
