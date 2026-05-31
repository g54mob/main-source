using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace NodeCanvas.Framework
{
	public abstract class ConditionTask<T> : ConditionTask where T : class
	{
		public sealed override Type agentType => null;

		public new T agent => null;
	}
	public abstract class ConditionTask : Task
	{
		[CompilerGenerated]
		private sealed class _003CFlip_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ConditionTask _003C_003E4__this;

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
			public _003CFlip_003Ed__13(int _003C_003E1__state)
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

		[SerializeField]
		private bool _invert;

		private int yieldReturn;

		private int yields;

		private bool isRuntimeEnabled;

		public bool invert
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public void Enable(Component agent, IBlackboard bb)
		{
		}

		public void Disable()
		{
		}

		[Obsolete("Use 'Check'")]
		public bool CheckCondition(Component agent, IBlackboard blackboard)
		{
			return false;
		}

		public bool Check(Component agent, IBlackboard blackboard)
		{
			return false;
		}

		public bool CheckOnce(Component agent, IBlackboard blackboard)
		{
			return false;
		}

		protected void YieldReturn(bool value)
		{
		}

		[IteratorStateMachine(typeof(_003CFlip_003Ed__13))]
		private IEnumerator Flip()
		{
			return null;
		}

		protected virtual void OnEnable()
		{
		}

		protected virtual void OnDisable()
		{
		}

		protected virtual bool OnCheck()
		{
			return false;
		}
	}
}
