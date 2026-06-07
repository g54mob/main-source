using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Gh.Tk
{
	public class StaffInspectStockJob : StaffJob
	{
		[CompilerGenerated]
		private sealed class _003CGetActivities_003Ed__7 : IEnumerable<Activity>, IEnumerable, IEnumerator<Activity>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Activity _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public StaffInspectStockJob _003C_003E4__this;

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

		public static string NeededJobRole;

		private List<Room> _targetRooms;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		private GameItem _itemToCheck;

		[PersistenceOptIn]
		private int _position;

		private StaffInspectStockJob()
		{
		}

		public StaffInspectStockJob(Room source)
		{
		}

		public override IEnumerable<Room> GetTargetRooms()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CGetActivities_003Ed__7))]
		public override IEnumerable<Activity> GetActivities()
		{
			return null;
		}

		public static IEnumerable<Tuple<GameObjectX, Prop>> GetItemsToCheck(Room room)
		{
			return null;
		}
	}
}
