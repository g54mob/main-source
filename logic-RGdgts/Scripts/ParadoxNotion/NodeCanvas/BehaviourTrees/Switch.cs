using System.Collections.Generic;
using NodeCanvas.Framework;
using NodeCanvas.Framework.Internal;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	public class Switch : BTComposite
	{
		public enum CaseSelectionMode
		{
			IndexBased = 0,
			EnumBased = 1
		}

		public enum OutOfRangeMode
		{
			ReturnFailure = 0,
			LoopIndex = 1
		}

		public bool dynamic;

		public CaseSelectionMode selectionMode;

		public BBParameter<int> intCase;

		public OutOfRangeMode outOfRangeMode;

		[BlackboardOnly]
		public BBObjectParameter enumCase;

		private Dictionary<int, int> enumCasePairing;

		private int current;

		private int runningIndex;

		public override void OnGraphStarted()
		{
		}

		protected override Status OnExecute(Component agent, IBlackboard blackboard)
		{
			return default(Status);
		}
	}
}
