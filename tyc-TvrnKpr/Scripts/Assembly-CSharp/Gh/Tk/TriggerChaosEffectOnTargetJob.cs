using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Gh.Tk.Story.Actions;

namespace Gh.Tk
{
	public class TriggerChaosEffectOnTargetJob : Job
	{
		[CompilerGenerated]
		private sealed class _003CGetActivities_003Ed__4 : IEnumerable<Activity>, IEnumerable, IEnumerator<Activity>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Activity _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public TriggerChaosEffectOnTargetJob _003C_003E4__this;

			private IDisposable _003C_003E7__wrap1;

			private Prop _003Cprop_003E5__3;

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
		private ChaosActions.ChaosActionTypes _propAction;

		[PersistenceOptIn]
		private bool _isChaosEvent;

		protected TriggerChaosEffectOnTargetJob()
		{
		}

		public TriggerChaosEffectOnTargetJob(GameObjectX target, ChaosActions.ChaosActionTypes action, bool isChaosEvent)
		{
		}

		[IteratorStateMachine(typeof(_003CGetActivities_003Ed__4))]
		public override IEnumerable<Activity> GetActivities()
		{
			return null;
		}

		protected override void OnCleanupInternal()
		{
		}
	}
}
