using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	[Category("Composites")]
	[Description("Quick way to execute the left or the right child, based on a Condition Task.")]
	[Icon("Condition", false, null)]
	[Color("b3ff7f")]
	public class BinarySelector : BTNode, ITaskAssignable<ConditionTask>, ITaskAssignable, IGraphElement
	{
		[Tooltip("If true, the condition will be re-evaluated per frame.")]
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
