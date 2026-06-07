using System;
using System.Collections;
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
		private Status status;

		private float timeStarted;

		private bool latch;

		public float elapsedTime => 0f;

		public bool isRunning => false;

		public bool isPaused { get; private set; }

		public void ExecuteIndependent(Component agent, IBlackboard blackboard, Action<Status> callback)
		{
		}

		private IEnumerator IndependentActionUpdater(Component agent, IBlackboard blackboard, Action<Status> callback)
		{
			return null;
		}

		[Obsolete]
		public Status ExecuteAction(Component agent, IBlackboard blackboard)
		{
			return default(Status);
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
	}
}
