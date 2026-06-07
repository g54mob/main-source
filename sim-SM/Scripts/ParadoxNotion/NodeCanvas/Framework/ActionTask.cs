using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace NodeCanvas.Framework
{
	public abstract class ActionTask<T> : ActionTask where T : class
	{
		public sealed override Type agentType => null;

		public new T agent => null;
	}
	public abstract class ActionTask : Task
	{
		[CompilerGenerated]
		private sealed class _003CIndependentActionUpdater_003Ed__12 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ActionTask _003C_003E4__this;

			public Component agent;

			public IBlackboard blackboard;

			public Action<Status> callback;

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
			public _003CIndependentActionUpdater_003Ed__12(int _003C_003E1__state)
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

		private Status status;

		private float timeStarted;

		private bool latch;

		public float elapsedTime => 0f;

		public bool isRunning => false;

		public bool isPaused { get; private set; }

		public void ExecuteIndependent(Component agent, IBlackboard blackboard, Action<Status> callback)
		{
		}

		[IteratorStateMachine(typeof(_003CIndependentActionUpdater_003Ed__12))]
		private IEnumerator IndependentActionUpdater(Component agent, IBlackboard blackboard, Action<Status> callback)
		{
			return null;
		}

		public Status Execute(Component agent, IBlackboard blackboard)
		{
			return default(Status);
		}

		public void EndAction()
		{
		}

		public void EndAction(bool success)
		{
		}

		public void EndAction(bool? success)
		{
		}

		public void Pause()
		{
		}

		protected virtual void OnExecute()
		{
		}

		protected virtual void OnUpdate()
		{
		}

		protected virtual void OnStop(bool interrupted)
		{
		}

		protected virtual void OnStop()
		{
		}

		protected virtual void OnPause()
		{
		}

		protected virtual void OnResume()
		{
		}

		[Obsolete("Use 'Execute'")]
		public Status ExecuteAction(Component agent, IBlackboard blackboard)
		{
			return default(Status);
		}
	}
}
