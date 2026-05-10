using System.Collections;
using NodeCanvas.Framework;
using NodeCanvas.Framework.Internal;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	[Name("Iterate", 0)]
	[Category("Decorators")]
	[Description("Iterates a list and executes its child once for each element in that list. Keeps iterating until the Termination Policy is met or until the whole list is iterated, in which case the last iteration child status is returned.")]
	[Icon("List", false, null)]
	public class Iterator : BTDecorator
	{
		public enum TerminationConditions
		{
			None = 0,
			FirstSuccess = 1,
			FirstFailure = 2
		}

		[RequiredField]
		[BlackboardOnly]
		[Tooltip("The list to iterate.")]
		public BBParameter<IList> targetList;

		[BlackboardOnly]
		[Name("Current Element", 0)]
		[Tooltip("Store the currently iterated list element in a variable.")]
		public BBObjectParameter current;

		[BlackboardOnly]
		[Name("Current Index", 0)]
		[Tooltip("Store the currently iterated list index in a variable.")]
		public BBParameter<int> storeIndex;

		[Name("Termination Policy", 0)]
		[Tooltip("The condition for when to terminate the iteration and return status.")]
		public TerminationConditions terminationCondition;

		[Tooltip("The maximum allowed iterations. Leave at -1 to iterate the whole list.")]
		public BBParameter<int> maxIteration;

		[Tooltip("Should the iteration start from the begining after the Iterator node resets?")]
		public bool resetIndex;

		private int currentIndex;

		private IList list => null;

		protected override Status OnExecute(Component agent, IBlackboard blackboard)
		{
			return default(Status);
		}

		protected override void OnReset()
		{
		}
	}
}
