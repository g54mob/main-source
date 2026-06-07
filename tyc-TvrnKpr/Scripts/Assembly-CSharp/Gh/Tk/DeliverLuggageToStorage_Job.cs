using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Gh.Tk
{
	public class DeliverLuggageToStorage_Job : StaffJob
	{
		[CompilerGenerated]
		private sealed class _003CGetActivities_003Ed__4 : IEnumerable<Activity>, IEnumerable, IEnumerator<Activity>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Activity _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public DeliverLuggageToStorage_Job _003C_003E4__this;

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
		private GameItem _luggage;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		private Patron _patron;

		private DeliverLuggageToStorage_Job()
		{
		}

		public DeliverLuggageToStorage_Job(GameObjectX source, GameItem luggage, Patron patron)
		{
		}

		[IteratorStateMachine(typeof(_003CGetActivities_003Ed__4))]
		public override IEnumerable<Activity> GetActivities()
		{
			return null;
		}

		private void SearchForLuggageStorage()
		{
		}
	}
}
