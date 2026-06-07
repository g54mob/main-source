using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Gh.Tk
{
	public class PatronGoToSleepJob : PatronJob
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass10_0
		{
			public Bed targetBed;

			internal bool _003CGetActivities_003Eb__2(PatronStorage x)
			{
				return false;
			}

			internal bool _003CGetActivities_003Eb__5(Wash_Basin x)
			{
				return false;
			}
		}

		[CompilerGenerated]
		private sealed class _003CGetActivities_003Ed__10 : IEnumerable<Activity>, IEnumerable, IEnumerator<Activity>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Activity _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public PatronGoToSleepJob _003C_003E4__this;

			private _003C_003Ec__DisplayClass10_0 _003C_003E8__1;

			private AccommodationBehaviour _003CaccommodationBehaviour_003E5__2;

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
			public _003CGetActivities_003Ed__10(int _003C_003E1__state)
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
		private GameObjectXMatchInfo _targetStorageMatchInfo;

		[PersistenceOptIn]
		private GameObjectXMatchInfo _targetWashBasinMatchInfo;

		[PersistenceOptIn]
		private bool _retrievingLuggage;

		[PersistenceOptIn]
		public bool HasSlept { get; set; }

		private PatronGoToSleepJob()
		{
		}

		public PatronGoToSleepJob(Patron patron, ActorBehaviour behaviour)
		{
		}

		public override bool IsValid()
		{
			return false;
		}

		[IteratorStateMachine(typeof(_003CGetActivities_003Ed__10))]
		public override IEnumerable<Activity> GetActivities()
		{
			return null;
		}

		protected override void OnCleanupInternal()
		{
		}
	}
}
