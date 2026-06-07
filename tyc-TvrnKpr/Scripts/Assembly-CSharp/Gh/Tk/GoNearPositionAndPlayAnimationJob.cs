using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gh.Tk
{
	public class GoNearPositionAndPlayAnimationJob : ActorJob
	{
		[CompilerGenerated]
		private sealed class _003CGetActivities_003Ed__7 : IEnumerable<Activity>, IEnumerable, IEnumerator<Activity>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Activity _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public GoNearPositionAndPlayAnimationJob _003C_003E4__this;

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
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private bool _run;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private bool _wasRunning;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private string _animation;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private float? _animationDuration;

		private GoNearPositionAndPlayAnimationJob()
		{
		}

		public GoNearPositionAndPlayAnimationJob(GameObjectX source, Vector3 targetPosition, bool run = false, string animation = null, float? animDuration = null)
		{
		}

		[IteratorStateMachine(typeof(_003CGetActivities_003Ed__7))]
		public override IEnumerable<Activity> GetActivities()
		{
			return null;
		}

		protected override void OnCleanupInternal()
		{
		}

		protected override void OnFinishInternal()
		{
		}

		private void CleanUpRunningTrait()
		{
		}

		protected override void OnAbortedInternal()
		{
		}
	}
}
