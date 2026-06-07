using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	[Name("Action", 0)]
	[Description("Executes an action and returns Success or Failure when the action is finished.\nReturns Running until the action is finished.")]
	[Icon("Action", false, null)]
	public class ActionNode : BTNode, ITaskAssignable<ActionTask>, ITaskAssignable, IGraphElement
	{
		[SerializeField]
		private ActionTask _action;

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

		public override string name => null;

		protected override Status OnExecute(Component agent, IBlackboard blackboard)
		{
			return default(Status);
		}

		protected override void OnReset()
		{
		}

		public override void OnGraphPaused()
		{
		}
	}
}
