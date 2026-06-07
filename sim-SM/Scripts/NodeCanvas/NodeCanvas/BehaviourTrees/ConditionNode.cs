using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	[Name("Condition", 0)]
	[Description("Checks a condition and returns Success or Failure.")]
	[Icon("Condition", false, null)]
	public class ConditionNode : BTNode, ITaskAssignable<ConditionTask>, ITaskAssignable, IGraphElement
	{
		[SerializeField]
		private ConditionTask _condition;

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

		public ConditionTask condition
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
	}
}
