using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	[Name("Interrupt", 0)]
	[Category("Decorators")]
	[Description("Executes and returns the child status. If the condition is or becomes true, the child is interrupted and returns Failure.")]
	[Icon("Interruptor", false, null)]
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
