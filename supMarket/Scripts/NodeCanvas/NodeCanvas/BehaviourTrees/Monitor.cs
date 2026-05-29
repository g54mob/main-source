using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	[Category("Decorators")]
	[Icon("Eye", false, null)]
	[Description("Monitors the decorated child for a returned Status and executes an Action when that is the case.\nThe final Status returned to the parent can either be the original decorated child Status, or the new decorator Action Status.")]
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

		[Name("Monitor", 0)]
		[Tooltip("The Status to monitor for.")]
		public MonitorMode monitorMode;

		[Name("Return", 0)]
		[Tooltip("The Status to return after (and if) the Action is executed.")]
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
