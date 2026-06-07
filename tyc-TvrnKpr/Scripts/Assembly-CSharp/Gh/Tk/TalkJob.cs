using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Gh.Tk.Story.Conversations;

namespace Gh.Tk
{
	public class TalkJob : ConversationBaseJob
	{
		[CompilerGenerated]
		private sealed class _003CGetActivities_003Ed__12 : IEnumerable<Activity>, IEnumerable, IEnumerator<Activity>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Activity _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public TalkJob _003C_003E4__this;

			Activity IEnumerator<Activity>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CGetActivities_003Ed__12(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<Activity> IEnumerable<Activity>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		[PersistenceOptIn]
		private string _currentAnimation;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		public List<ListenJob> ListenerJobs;

		[PersistenceOptIn]
		private bool _hadPunchLine;

		[PersistenceOptIn]
		private ConversationSpeaker _speakerSetting;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private bool _atReactionNode;

		[PersistenceOptIn]
		private bool _reactionSet;

		[PersistenceOptIn]
		private float _waitForPunchlineUntilMaxTime;

		[PersistenceOptIn]
		private bool _isConcreteAnimation;

		[PersistenceOptIn]
		private ConversationAnimationPresets.ConversationAnimation _animationSetting;

		[PersistenceOptIn]
		private bool _reachedFinishEvent;

		protected TalkJob()
		{
		}

		public TalkJob(Actor owner, ActorBehaviour behaviour, string conversationId, ConversationSpeaker speakerSetting, List<Actor> partners)
		{
		}

		[IteratorStateMachine(typeof(_003CGetActivities_003Ed__12))]
		public override IEnumerable<Activity> GetActivities()
		{
			return null;
		}

		private void OnAnimEvent(object sender, AnimationEventArgs e)
		{
		}

		private void ReachedFinishEvent()
		{
		}

		public void TimedOut()
		{
		}

		private void ReachedPunchline()
		{
		}

		protected override void OnCleanupInternal()
		{
		}

		private void RemoveListener()
		{
		}

		protected override void OnAbortedInternal()
		{
		}

		private void SetReactions()
		{
		}

		public override void ForceDestroy(bool destroyParentToo = false)
		{
		}
	}
}
