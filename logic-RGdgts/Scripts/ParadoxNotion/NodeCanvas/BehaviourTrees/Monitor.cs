using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	public class Monitor : BTDecorator, ITaskAssignable<ActionTask>, ITaskAssignable, IGraphElement
	{
		public enum MonitorMode
		{
			Failure = 0,
			Success = 1,
			AnyStatus = 10
		}

		public enum ReturnStatusMode
		{
			OriginalDecoratedChildStatus = 0,
			NewDecoratorActionStatus = 1
		}

		public MonitorMode monitorMode;

		public ReturnStatusMode returnMode;

		private Status decoratorActionStatus;

		[SerializeField]
		private ActionTask _action;

		public ActionTask action
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Task task
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		protected override Status OnExecute(Component agent, IBlackboard blackboard)
		{
			return default(Status);
		}

		protected override void OnReset()
		{
		}
	}
}
