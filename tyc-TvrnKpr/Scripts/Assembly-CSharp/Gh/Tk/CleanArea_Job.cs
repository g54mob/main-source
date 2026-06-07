using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gh.Tk
{
	public class CleanArea_Job : StaffJob, ILateLateRestoreState
	{
		[CompilerGenerated]
		private sealed class _003CGetActivities_003Ed__7 : IEnumerable<Activity>, IEnumerable, IEnumerator<Activity>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Activity _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public CleanArea_Job _003C_003E4__this;

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

		[PersistenceOptIn]
		private Vector3 _targetPosition;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		private GameObjectX _currentIndicator;

		private const float AreaRadiusSquared = 35f;

		private CleanArea_Job()
		{
		}

		public CleanArea_Job(Vector3 targetPosition)
		{
		}

		private void SetTargetPosition(Vector3 targetPosition)
		{
		}

		public static IEnumerable<Clean_Job> GetJobsForArea(Vector3 where)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CGetActivities_003Ed__7))]
		public override IEnumerable<Activity> GetActivities()
		{
			return null;
		}

		private void SetIndicator(Vector3 where)
		{
		}

		private void AttachListener()
		{
		}

		private void RemoveIndicator()
		{
		}

		protected override void OnCleanupInternal()
		{
		}

		protected override void OnAbortedInternal()
		{
		}

		public void LateLateRestoreState(IDataStore data)
		{
		}
	}
}
