using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	[Name("Conditional", 0)]
	[Category("Decorators")]
	[Description("Executes and returns the child status only if the condition is true. Returns Failure if the condition is false.")]
	[Icon("Accessor", false, null)]
	public class ConditionalEvaluator : BTDecorator, ITaskAssignable<ConditionTask>, ITaskAssignable, IGraphElement
	{
		[Name("Dynamic", 0)]
		[Tooltip("If enabled, the condition is re-evaluated per frame and the child is aborted if the condition becomes false.")]
		public bool isDynamic;

		[Tooltip("The status that will be returned if the assigned condition is or becomes false.")]
		public CompactStatus conditionFailReturn;

		[SerializeField]
		private ConditionTask _condition;

		private bool accessed;

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
