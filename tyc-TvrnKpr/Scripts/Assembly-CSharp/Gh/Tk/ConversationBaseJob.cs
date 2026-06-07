using System.Collections.Generic;
using Gh.Tk.Story;
using Gh.Tk.Story.Conversations;

namespace Gh.Tk
{
	public abstract class ConversationBaseJob : ActorJob
	{
		protected static string _waitingForReactionAnim;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		protected bool _useRandomStories;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		protected List<Actor> _partners;

		[PersistenceOptIn]
		public bool OrderingIsAllowed;

		protected ConversationBaseJob ParentConversationJob;

		protected bool AttachedToListener;

		[PersistenceOptIn]
		public string[] SpawnableItems;

		[PersistenceOptIn]
		public string ConversationId;

		private const string _conversationIdKey = "CONVERSATION_ID";

		protected ConversationBaseJob()
		{
		}

		protected ConversationBaseJob(Actor owner, ActorBehaviour behaviour, string conversationId)
		{
		}

		protected ConversationBaseJob(Actor owner, ActorBehaviour behaviour)
		{
		}

		private string GetAnimationParam(string animationSetting, string fallback)
		{
			return null;
		}

		protected string GetTalkAnimation(string animationSetting)
		{
			return null;
		}

		protected string GetReactAnimation(string animationSetting)
		{
			return null;
		}

		public virtual (ConversationAnimationNode, bool) GetCurrentAnimationNode()
		{
			return default((ConversationAnimationNode, bool));
		}

		protected ActiveStory GetActiveStoryNode()
		{
			return null;
		}

		public virtual void MarkCurrentConversationAnimationNodeAsComplete(IEnumerable<Actor> actors)
		{
		}

		private static string GetConversationIdFromStory(ActiveStory story)
		{
			return null;
		}

		protected void CleanupStory()
		{
		}

		protected override void OnAbortedInternal()
		{
		}

		public override void ForceDestroy(bool destroyParentToo = false)
		{
		}

		protected void OnSpawnConvItem(object sender, SpawnConvItemEventArgs e)
		{
		}
	}
}
