using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	public class Interruptor : BTDecorator, ITaskAssignable<ConditionTask>, ITaskAssignable, IGraphElement
	{
		[SerializeField]
		private ConditionTask _condition;

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
