using NodeCanvas.Framework;
using ParadoxNotion;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	public class BinarySelector : BTNode, ITaskAssignable<ConditionTask>, ITaskAssignable, IGraphElement
	{
		public bool dynamic;

		[SerializeField]
		private ConditionTask _condition;

		private int succeedIndex;

		public override int maxOutConnections => 0;

		public override Alignment2x2 commentsAlignment => default(Alignment2x2);

		public override string name => null;

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

		private ConditionTask condition
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
