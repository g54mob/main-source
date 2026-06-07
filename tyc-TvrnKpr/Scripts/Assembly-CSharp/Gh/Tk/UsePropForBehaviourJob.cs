using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Gh.Tk
{
	public class UsePropForBehaviourJob : PatronJob, ISetPropTarget, IReferenceableObject
	{
		[CompilerGenerated]
		private sealed class _003CGetActivities_003Ed__8 : IEnumerable<Activity>, IEnumerable, IEnumerator<Activity>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Activity _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public UsePropForBehaviourJob _003C_003E4__this;

			private PatronBehaviour _003Cbehaviour_003E5__2;

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
		[PersistenceObjectReference]
		private SatisfactionStatBase _satisfactionStat;

		[PersistenceOptIn]
		private string _feedbackReasonKey;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private bool _goHomeIfFailed;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private float _weighting;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private string[] _propTypesToIgnore;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private string[] _allowedZones;

		private UsePropForBehaviourJob()
		{
		}

		public UsePropForBehaviourJob(Patron source, PatronBehaviour behaviour, SatisfactionStatBase satisfactionStat, string propNotFoundFeedBackReasonKey, float weighting = 1f, bool goHomeIfFailed = false, string[] propTypesToIgnore = null, string[] allowedZones = null)
		{
		}

		[IteratorStateMachine(typeof(_003CGetActivities_003Ed__8))]
		public override IEnumerable<Activity> GetActivities()
		{
			return null;
		}

		public void SetTarget(Prop prop)
		{
		}
	}
}
