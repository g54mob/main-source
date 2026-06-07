using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Gh.Tk
{
	public class FindTargetPropPatronJob : PatronJob
	{
		[CompilerGenerated]
		private sealed class _003CGetActivities_003Ed__21 : IEnumerable<Activity>, IEnumerable, IEnumerator<Activity>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Activity _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public FindTargetPropPatronJob _003C_003E4__this;

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

		[PersistenceOptIn]
		[PersistenceObjectReference]
		private ISetPropTarget _sourceJob;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		private PatronBehaviour _behaviour;

		[PersistenceOptIn]
		private bool _goHomeIfFailed;

		[PersistenceOptIn]
		private float _weighting;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		private SatisfactionStatBase _satisfactionStat;

		[PersistenceOptIn]
		private string _propNotFoundFeedBackReasonKey;

		[PersistenceOptIn]
		private string[] _allowedZones;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		public Prop Match { get; private set; }

		[PersistenceOptIn]
		public bool TriedToFindTarget { get; private set; }

		[PersistenceOptIn]
		public bool WentNearPossibleProp { get; private set; }

		protected FindTargetPropPatronJob()
		{
		}

		public FindTargetPropPatronJob(Patron owner, ISetPropTarget sourceJob, PatronBehaviour behaviour, SatisfactionStatBase satisfactionStat, string propNotFoundFeedBackReasonKey, float weighting, bool goHomeIfFailed, string[] allowedZones = null)
		{
		}

		[IteratorStateMachine(typeof(_003CGetActivities_003Ed__21))]
		public override IEnumerable<Activity> GetActivities()
		{
			return null;
		}

		private void AbortIdleJobs()
		{
		}

		private void OnBehaviourFailed()
		{
		}

		protected override void OnCleanupInternal()
		{
		}

		protected override void OnAbortedInternal()
		{
		}

		private Prop GetTarget(bool ignoreQueues = false)
		{
			return null;
		}

		public static void UpdateAllFindTargetJobs()
		{
		}

		private static void AssignIdleJob(Patron patron)
		{
		}

		private static ActorJob GenerateIdleJob(FindTargetPropPatronJob findJob)
		{
			return null;
		}
	}
}
