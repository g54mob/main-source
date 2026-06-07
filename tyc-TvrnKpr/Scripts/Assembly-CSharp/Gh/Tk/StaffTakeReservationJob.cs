using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Gh.Tk
{
	public class StaffTakeReservationJob : StaffJob
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass4_0
		{
			public Patron patron;

			public StaffTakeReservationJob _003C_003E4__this;

			public AccommodationBehaviour accommodationBehaviour;

			public Func<Actor, bool> _003C_003E9__6;

			internal bool _003CGetActivities_003Eb__3(Bed x)
			{
				return false;
			}

			internal float _003CGetActivities_003Eb__4(GameObjectX gox)
			{
				return 0f;
			}

			internal bool _003CGetActivities_003Eb__5(KeyRack x)
			{
				return false;
			}

			internal void _003CGetActivities_003Eb__0()
			{
			}

			internal bool _003CGetActivities_003Eb__1(Actor x)
			{
				return false;
			}

			internal bool _003CGetActivities_003Eb__2()
			{
				return false;
			}

			internal bool _003CGetActivities_003Eb__6(Actor x)
			{
				return false;
			}
		}

		[CompilerGenerated]
		private sealed class _003CGetActivities_003Ed__4 : IEnumerable<Activity>, IEnumerable, IEnumerator<Activity>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Activity _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public StaffTakeReservationJob _003C_003E4__this;

			private _003C_003Ec__DisplayClass4_0 _003C_003E8__1;

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
			public _003CGetActivities_003Ed__4(int _003C_003E1__state)
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
		[PersistenceObjectReference]
		private RoomReservation _reservation;

		private StaffTakeReservationJob()
		{
		}

		public StaffTakeReservationJob(RegistrationDesk desk, Patron patron)
		{
		}

		public override IEnumerable<Room> GetTargetRooms()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CGetActivities_003Ed__4))]
		public override IEnumerable<Activity> GetActivities()
		{
			return null;
		}

		protected override void OnCleanupInternal()
		{
		}

		public void ChangeTargetTo(Patron owner)
		{
		}

		protected override void OnAbortedInternal()
		{
		}
	}
}
