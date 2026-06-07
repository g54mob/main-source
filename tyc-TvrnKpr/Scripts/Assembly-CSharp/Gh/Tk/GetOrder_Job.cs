using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Gh.Tk
{
	public class GetOrder_Job : StaffJob
	{
		[CompilerGenerated]
		private sealed class _003CGetActivities_003Ed__8 : IEnumerable<Activity>, IEnumerable, IEnumerator<Activity>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Activity _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public GetOrder_Job _003C_003E4__this;

			private IDisposable _003C_003E7__wrap1;

			private int _003CpatronNumber_003E5__3;

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
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public bool IsJoinable;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		private Patron _currentPatron;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		public List<Patron> _patronsDone;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		public Job _nextJobForPatron;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		private PlayOrderAnimationJob _currentOrderAnimationJob;

		[PersistenceOptIn]
		private string _takeOrderReadyAnimation;

		private GetOrder_Job()
		{
		}

		public GetOrder_Job(Prop source)
		{
		}

		[IteratorStateMachine(typeof(_003CGetActivities_003Ed__8))]
		public override IEnumerable<Activity> GetActivities()
		{
			return null;
		}

		public void SetPatronOrderAnimationIsDone()
		{
		}

		private void GenerateNewJobsForOtherPatrons()
		{
		}

		private bool IsMultiOrderAllowed()
		{
			return false;
		}

		private IEnumerable<Patron> GetPatronsReadyToOrder()
		{
			return null;
		}

		private void RecordPatronServiceSatisfaction(Patron patron)
		{
		}
	}
}
