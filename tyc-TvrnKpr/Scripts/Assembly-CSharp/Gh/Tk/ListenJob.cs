using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Gh.Tk
{
	public class ListenJob : ConversationBaseJob
	{
		[CompilerGenerated]
		private sealed class _003CGetActivities_003Ed__8 : IEnumerable<Activity>, IEnumerable, IEnumerator<Activity>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Activity _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public ListenJob _003C_003E4__this;

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
			public _003CGetActivities_003Ed__8(int _003C_003E1__state)
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
		private string _listenAnimation;

		[PersistenceOptIn]
		private string _reactAnimation;

		[PersistenceOptIn]
		public string Stage;

		[PersistenceOptIn]
		public string ReactAnimationSetting;

		[PersistenceOptIn]
		public bool IsConcreteAnimationSetting;

		[PersistenceOptIn]
		public string ReactIcon;

		protected ListenJob()
		{
		}

		public ListenJob(Actor owner, ActorBehaviour behaviour, string conversationId)
		{
		}

		[IteratorStateMachine(typeof(_003CGetActivities_003Ed__8))]
		public override IEnumerable<Activity> GetActivities()
		{
			return null;
		}

		private void StopListenAnimation()
		{
		}

		protected override void OnCleanupInternal()
		{
		}

		protected override void OnAbortedInternal()
		{
		}

		public override void ForceDestroy(bool destroyParentToo = false)
		{
		}

		protected override void OnFinishInternal()
		{
		}

		private void CleanUpListenerJobFromTalkJob()
		{
		}

		private void RemoveListener()
		{
		}
	}
}
