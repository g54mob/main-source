using System.Collections.Generic;
using XNode;

namespace Gh.Tk.Story.Actions.Jobs
{
	[NodeTint("#482FB7")]
	public abstract class ActorJobActionNode : ActorActionNode, IJobCallbackStoryNode
	{
		public StoryNodeJobFailedStrategy failStrategy;

		[Output(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection failed;

		protected ActorJobActionNode()
			: base(autoCompleteOnTrigger: false)
		{
		}

		protected override void OnTriggerInternal(ActiveStory story, IEnumerable<Actor> actors)
		{
		}

		protected abstract Job CreateJob(Actor actor);

		public void OnJobCompleted(ActiveStory story, Job sourceJob)
		{
		}

		public void OnJobFailed(ActiveStory story, Job sourceJob)
		{
		}

		private int GetRetryCount(ActiveStory story)
		{
			return 0;
		}

		private void SetRetryCount(ActiveStory story, int count)
		{
		}
	}
}
