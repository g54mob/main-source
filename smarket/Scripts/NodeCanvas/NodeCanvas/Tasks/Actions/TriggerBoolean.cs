using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Blackboard")]
	[Description("Triggers a boolean variable for 1 frame to True then back to False")]
	public class TriggerBoolean : ActionTask
	{
		[CompilerGenerated]
		private sealed class _003CFlip_003Ed__4 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public TriggerBoolean _003C_003E4__this;

			object IEnumerator<object>.Current
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
			public _003CFlip_003Ed__4(int _003C_003E1__state)
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
		}

		[RequiredField]
		[BlackboardOnly]
		public BBParameter<bool> variable;

		protected override string info => null;

		protected override void OnExecute()
		{
		}

		[IteratorStateMachine(typeof(_003CFlip_003Ed__4))]
		private IEnumerator Flip()
		{
			return null;
		}
	}
}
