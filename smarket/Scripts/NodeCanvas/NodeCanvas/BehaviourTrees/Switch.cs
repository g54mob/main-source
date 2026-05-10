using System.Collections.Generic;
using NodeCanvas.Framework;
using NodeCanvas.Framework.Internal;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	[Category("Composites")]
	[Description("Executes one child based on the provided int or enum case and returns its status.")]
	[Icon("IndexSwitcher", false, null)]
	[Color("b3ff7f")]
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

		[Tooltip("If true and the 'case' change while a child is running, that child will immediately be interrupted and the new child will be executed.")]
		public bool dynamic;

		[Tooltip("The selection mode used.")]
		public CaseSelectionMode selectionMode;

		[ShowIf("selectionMode", 0)]
		public BBParameter<int> intCase;

		[ShowIf("selectionMode", 0)]
		public OutOfRangeMode outOfRangeMode;

		[ShowIf("selectionMode", 1)]
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
