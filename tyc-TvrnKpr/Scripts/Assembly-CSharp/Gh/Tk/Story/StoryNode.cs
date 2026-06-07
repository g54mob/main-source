using System;
using System.Collections.Generic;
using XNode;

namespace Gh.Tk.Story
{
	public abstract class StoryNode : NodeBase
	{
		private static readonly Dictionary<Type, string> _defaultNodeNameCache;

		private string DurationKey => null;

		protected static void ExecuteOnActive<T>(Action<T, ActiveStory> action) where T : StoryNode
		{
		}

		public virtual void OnTrigger(ActiveStory story)
		{
		}

		private void UpdateNodeDurationCounter(ActiveStory story)
		{
		}

		private float GetNodeCompletedDurationsInSeconds(ActiveStory story)
		{
			return 0f;
		}

		public virtual void OnUpdate(ActiveStory story)
		{
		}

		public virtual void OnDecision(ActiveStory story, int decision)
		{
		}

		public virtual void Complete(ActiveStory story)
		{
		}

		protected void CompleteWithoutContinue(ActiveStory story)
		{
		}

		public bool ShouldTrackInAnalytics()
		{
			return false;
		}

		protected void TriggerAnalyticsEventStoryNodeCompleted(ActiveStory story)
		{
		}

		private void TrackNodeCompletedInGameStats()
		{
		}

		public string GetDefaultNodeName()
		{
			return null;
		}

		protected void ContinueStoryOnPort(ActiveStory story, string portName, bool completeCurrentNode = true)
		{
		}

		protected bool HasPortConnections(string portName)
		{
			return false;
		}

		protected void PlayNextNodes(ActiveStory story)
		{
		}

		protected void PlayNextNodes(ActiveStory story, string output)
		{
		}

		protected void PlayNextNodes(ActiveStory story, IEnumerable<NodePort> connections)
		{
		}

		public string GetNodePath()
		{
			return null;
		}
	}
}
