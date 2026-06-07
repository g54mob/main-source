using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
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
