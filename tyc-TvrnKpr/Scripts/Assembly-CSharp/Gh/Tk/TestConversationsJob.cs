using System.Collections.Generic;
using Gh.Tk.Story.Conversations;

namespace Gh.Tk
{
	public class TestConversationsJob : ConversationJob
	{
		[PersistenceOptIn]
		private ConversationSpeaker _speakerForTest;

		[PersistenceOptIn]
		private bool _talk;

		[PersistenceOptIn]
		private List<ConversationAnimationPresets.ConversationAnimation> _talkAnimations;

		[PersistenceOptIn]
		private List<ConversationAnimationPresets.ConversationAnimation> _reactAnimations;

		[PersistenceOptIn]
		private int _currentAnimIndex;

		protected TestConversationsJob()
		{
		}

		public TestConversationsJob(Patron owner, IEnumerable<Patron> partners)
		{
		}

		public override (ConversationAnimationNode, bool) GetCurrentAnimationNode()
		{
			return default((ConversationAnimationNode, bool));
		}

		public override void MarkCurrentConversationAnimationNodeAsComplete(IEnumerable<Actor> actors)
		{
		}
	}
}
