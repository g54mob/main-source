using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Gh.Tk.Story.Conversations;

namespace Gh.Tk
{
	public class ConversationJob : ConversationBaseJob
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass21_0
		{
			public (ConversationAnimationNode node, bool isEndOfStory) currentNode;

			public ConversationJob _003C_003E4__this;

			internal bool _003CGetActivities_003Eb__7()
			{
				return false;
			}
		}

		[CompilerGenerated]
		private sealed class _003CGetActivities_003Ed__21 : IEnumerable<Activity>, IEnumerable, IEnumerator<Activity>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Activity _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public ConversationJob _003C_003E4__this;

			private _003C_003Ec__DisplayClass21_0 _003C_003E8__1;

			private string _003Ckey_003E5__2;

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
			public _003CGetActivities_003Ed__21(int _003C_003E1__state)
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

		private static readonly string WaitStart;

		private static readonly string SyncConvStart;

		private static readonly string SubJobDone;

		private static readonly string HandedOver;

		private static readonly string WaitForDecision;

		private static readonly string DecisionDone;

		private static readonly string EndConversation;

		[PersistenceOptIn]
		public bool IsConversationLeader;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		[PersistenceAllowBrokenReferenceOnLoad]
		private List<ConversationJob> _otherJobs;

		[PersistenceOptIn]
		private string _inConversationParam;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		protected bool _storyEnded;

		[PersistenceOptIn]
		private ConversationSpeaker _speakerSetting;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		protected Actor _currentSpeaker;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		public Job PlannedSubJob;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		public Actor PartnerToLookAt;

		[PersistenceOptIn]
		private string _stage;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private int _conversationNo;

		public bool AreAllOtherSubJobsDone => false;

		protected ConversationJob()
		{
		}

		public ConversationJob(Patron owner, IEnumerable<Actor> partners, ActorBehaviour behaviour, bool useRandomStories = true)
		{
		}

		[IteratorStateMachine(typeof(_003CGetActivities_003Ed__21))]
		public override IEnumerable<Activity> GetActivities()
		{
			return null;
		}

		private void ChooseNextSpeaker()
		{
		}

		protected override void OnCleanupInternal()
		{
		}

		private void CleanUpConversationParams()
		{
		}

		protected override void OnAbortedInternal()
		{
		}
	}
}
