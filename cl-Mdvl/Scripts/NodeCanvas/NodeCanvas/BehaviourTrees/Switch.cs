using System;
using System.Collections.Generic;
using NodeCanvas.Framework;
using NodeCanvas.Framework.Internal;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	[Category("Composites")]
	[Description("Executes one child based on the provided int or enum case and returns its status.")]
	[ParadoxNotion.Design.Icon("IndexSwitcher", false, "")]
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
		public OutOfRangeMode outOfRangeMode = OutOfRangeMode.LoopIndex;

		[ShowIf("selectionMode", 1)]
		[BlackboardOnly]
		public BBObjectParameter enumCase = new BBObjectParameter(typeof(Enum));

		private Dictionary<int, int> enumCasePairing;

		private int current;

		private int runningIndex;

		public override void OnGraphStarted()
		{
			if (selectionMode != CaseSelectionMode.EnumBased)
			{
				return;
			}
			object value = enumCase.value;
			if (value != null)
			{
				enumCasePairing = new Dictionary<int, int>();
				Array values = Enum.GetValues(value.GetType());
				for (int i = 0; i < values.Length; i++)
				{
					enumCasePairing[(int)values.GetValue(i)] = i;
				}
			}
		}

		protected override Status OnExecute(Component agent, IBlackboard blackboard)
		{
			if (base.outConnections.Count == 0)
			{
				return Status.Optional;
			}
			if (base.status == Status.Resting || dynamic)
			{
				if (selectionMode == CaseSelectionMode.IndexBased)
				{
					current = intCase.value;
					if (outOfRangeMode == OutOfRangeMode.LoopIndex)
					{
						current = Mathf.Abs(current) % base.outConnections.Count;
					}
				}
				else
				{
					current = enumCasePairing[(int)enumCase.value];
				}
				if (runningIndex != current)
				{
					base.outConnections[runningIndex].Reset();
				}
				if (current < 0 || current >= base.outConnections.Count)
				{
					return Status.Failure;
				}
			}
			base.status = base.outConnections[current].Execute(agent, blackboard);
			if (base.status == Status.Running)
			{
				runningIndex = current;
			}
			return base.status;
		}
	}
}
