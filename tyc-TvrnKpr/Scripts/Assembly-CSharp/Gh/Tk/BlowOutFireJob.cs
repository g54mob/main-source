using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening;

namespace Gh.Tk
{
	public class BlowOutFireJob : ActorJob
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass6_0
		{
			public Fire fire;

			public BlowOutFireJob _003C_003E4__this;

			internal bool _003CGetActivities_003Eb__0(Activity activity)
			{
				return false;
			}

			internal void _003CGetActivities_003Eb__1()
			{
			}

			internal void _003CGetActivities_003Eb__2()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CGetActivities_003Ed__6 : IEnumerable<Activity>, IEnumerable, IEnumerator<Activity>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Activity _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public BlowOutFireJob _003C_003E4__this;

			private _003C_003Ec__DisplayClass6_0 _003C_003E8__1;

			private Prop _003Cprop_003E5__2;

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
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private bool _runningTraitAdded;

		private Tween _rotationTween;

		public override bool IsValid()
		{
			return false;
		}

		private BlowOutFireJob()
		{
		}

		public BlowOutFireJob(GameObjectX source, int priority = 1020)
		{
		}

		protected override bool CheckOnHoldInternal()
		{
			return false;
		}

		[IteratorStateMachine(typeof(_003CGetActivities_003Ed__6))]
		public override IEnumerable<Activity> GetActivities()
		{
			return null;
		}

		protected override void OnCleanupInternal()
		{
		}

		private void Cleanup()
		{
		}

		protected override void OnAbortedInternal()
		{
		}
	}
}
