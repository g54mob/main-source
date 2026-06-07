using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Gh.Tk
{
	public class SocialMeetingJob : PatronJob
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass7_0
		{
			public SocialMeetingJob _003C_003E4__this;

			public GlobalTimeController timeController;

			internal bool _003CGetActivities_003Eb__0()
			{
				return false;
			}

			internal bool _003CGetActivities_003Eb__1()
			{
				return false;
			}

			internal bool _003CGetActivities_003Eb__2()
			{
				return false;
			}

			internal bool _003CGetActivities_003Eb__3()
			{
				return false;
			}

			internal bool _003CGetActivities_003Eb__7(Job x)
			{
				return false;
			}

			internal bool _003CGetActivities_003Eb__4()
			{
				return false;
			}
		}

		[CompilerGenerated]
		private sealed class _003CGetActivities_003Ed__7 : IEnumerable<Activity>, IEnumerable, IEnumerator<Activity>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Activity _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public SocialMeetingJob _003C_003E4__this;

			private _003C_003Ec__DisplayClass7_0 _003C_003E8__1;

			private ListPoolX.DisposablePooledList<AccessPoint> _003Caps_003E5__2;

			private Job _003CconsumeJob_003E5__3;

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
			public _003CGetActivities_003Ed__7(int _003C_003E1__state)
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

			private void _003C_003Em__Finally1()
			{
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
		[PersistenceObjectReference]
		private Patron _partner;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		private AccessPoint _reservedForPartner;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		private SocialMeetingJob _otherJob;

		[PersistenceOptIn]
		protected string _stage;

		[PersistenceOptIn]
		private float _maxWaitUntil;

		protected SocialMeetingJob()
		{
		}

		public SocialMeetingJob(Patron owner, SocialMeetingBehaviour behaviour)
		{
		}

		[IteratorStateMachine(typeof(_003CGetActivities_003Ed__7))]
		public override IEnumerable<Activity> GetActivities()
		{
			return null;
		}

		private SocialMeetingJob FetchPartnerJob()
		{
			return null;
		}

		private Patron FetchPartner()
		{
			return null;
		}

		protected override void OnCleanupInternal()
		{
		}

		private void CleanUp()
		{
		}

		protected override void OnAbortedInternal()
		{
		}
	}
}
