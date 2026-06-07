using UnityEngine;
using UnityEngine.Scripting;
using XNode;

namespace Gh.Tk.Story.Narrative
{
	[InitializeOnGameStarted]
	[NodeWidth(250)]
	[NodeTint("#466969")]
	public class AdvisorEventCameraNode : ConnectedStoryNode, IStoryNodeHasComplexity
	{
		[Output(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection onFirstShown;

		[TextArea(2, 5)]
		public string text;

		public AdvisorState advisorState;

		[Tooltip("If true, the advisor will be automatically skipped when another advisor shows up.")]
		public bool IsAutoSkipped;

		[Range(0f, 5f)]
		[Tooltip("If set, the node will first wait for both advisor and narrator to be silence for at least the amount of seconds")]
		public float requireSecondsOfNarrationSilence;

		private string ShownKey => null;

		private string EventId => null;

		public StoryComplexity StoryComplexity => default(StoryComplexity);

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private void OnEventRemoved(ActiveStory story, int eventId)
		{
		}

		public void OnShown(ActiveStory story)
		{
		}

		public override void OnTrigger(ActiveStory story)
		{
		}

		public override void OnUpdate(ActiveStory story)
		{
		}

		private bool IsTriggered(ActiveStory story)
		{
			return false;
		}

		private void SetIsTriggered(ActiveStory story)
		{
		}

		private void TriggerAdvisor(ActiveStory story)
		{
		}

		private void CompleteOtherAdvisors()
		{
		}
	}
}
