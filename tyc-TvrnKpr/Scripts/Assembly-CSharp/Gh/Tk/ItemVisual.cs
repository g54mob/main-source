using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Gh.Tk
{
	public class ItemVisual : GameObjectX
	{
		[CompilerGenerated]
		private sealed class _003CGetAvailableManualJobs_003Ed__1 : IEnumerable<ContextMenuItem>, IEnumerable, IEnumerator<ContextMenuItem>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private ContextMenuItem _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public ItemVisual _003C_003E4__this;

			private Staff staff;

			public Staff _003C_003E3__staff;

			private IEnumerator<ContextMenuItem> _003C_003E7__wrap1;

			private IEnumerator<Job> _003C_003E7__wrap2;

			ContextMenuItem IEnumerator<ContextMenuItem>.Current
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
			public _003CGetAvailableManualJobs_003Ed__1(int _003C_003E1__state)
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

			private void _003C_003Em__Finally2()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<ContextMenuItem> IEnumerable<ContextMenuItem>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		public override void Start()
		{
		}

		[IteratorStateMachine(typeof(_003CGetAvailableManualJobs_003Ed__1))]
		public override IEnumerable<ContextMenuItem> GetAvailableManualJobs(Staff staff)
		{
			return null;
		}

		public override bool CanUseDirectly(Actor actor)
		{
			return false;
		}
	}
}
