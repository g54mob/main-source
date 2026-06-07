using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gh.Tk
{
	public class CleanNestWithInsecticide_Job : StaffJob
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass6_0
		{
			public CleanNestWithInsecticide_Job _003C_003E4__this;

			public float minSquareDistance;

			public float maxSquareDistance;

			internal bool _003CGetActivities_003Eb__1(TileData x)
			{
				return false;
			}

			internal bool _003CGetActivities_003Eb__3(TileData x)
			{
				return false;
			}
		}

		[CompilerGenerated]
		private sealed class _003CGetActivities_003Ed__6 : IEnumerable<Activity>, IEnumerable, IEnumerator<Activity>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Activity _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public CleanNestWithInsecticide_Job _003C_003E4__this;

			private _003C_003Ec__DisplayClass6_0 _003C_003E8__1;

			private IDisposable _003C_003E7__wrap1;

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
		[PersistenceObjectReference]
		private Insecticide _insecticide;

		[PersistenceOptIn]
		private Vector3? _positionToHide;

		[PersistenceOptIn]
		private Vector3? _targetCoord;

		[PersistenceOptIn]
		private bool _wasRunning;

		private CleanNestWithInsecticide_Job()
		{
		}

		public CleanNestWithInsecticide_Job(Insecticide source, InfestationNest nest = null, Vector3? targetCoord = null, int priority = 10)
		{
		}

		[IteratorStateMachine(typeof(_003CGetActivities_003Ed__6))]
		public override IEnumerable<Activity> GetActivities()
		{
			return null;
		}

		private void AnimationEventObserver_AnimEvent(object sender, AnimationEventArgs e)
		{
		}

		private void DestroyNest()
		{
		}

		protected override void OnAbortedInternal()
		{
		}

		protected override void OnCleanupInternal()
		{
		}
	}
}
