using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Gh.Tk
{
	public class StaffCouncelJob : StaffJob
	{
		[CompilerGenerated]
		private sealed class _003CGetActivities_003Ed__6 : IEnumerable<Activity>, IEnumerable, IEnumerator<Activity>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Activity _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public StaffCouncelJob _003C_003E4__this;

			private Patron _003Cpatron_003E5__2;

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
			public _003CGetActivities_003Ed__6(int _003C_003E1__state)
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
		private ActorBehaviour _patronBehaviour;

		[PersistenceOptIn]
		private string _stage;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		private PatronCouncelJob _patronJob;

		protected StaffCouncelJob()
		{
		}

		public StaffCouncelJob(Patron source, CouncelorCouch target, ActorBehaviour patronBehaviour)
		{
		}

		public void SetNextStage(string stage)
		{
		}

		[IteratorStateMachine(typeof(_003CGetActivities_003Ed__6))]
		public override IEnumerable<Activity> GetActivities()
		{
			return null;
		}

		protected override void OnAbortedInternal()
		{
		}
	}
}
