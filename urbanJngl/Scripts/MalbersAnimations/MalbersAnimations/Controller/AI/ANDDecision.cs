using System.Collections.Generic;
using UnityEngine;

namespace MalbersAnimations.Controller.AI
{
	[CreateAssetMenu(menuName = "Malbers Animations/Pluggable AI/Decision/AND Decision", order = 100)]
	public class ANDDecision : MAIDecision
	{
		[HideInInspector]
		[Tooltip("Selected Index of the list in the inspector")]
		public int list_index;

		public List<MAIDecision> decisions = new List<MAIDecision>();

		public List<bool> invert = new List<bool>();

		public bool debug;

		public override string DisplayName => "General/AND";

		public override void PrepareDecision(MAnimalBrain brain, int Index)
		{
			if (invert.Count != decisions.Count)
			{
				invert.Resize(decisions.Count, element: false);
			}
			foreach (MAIDecision decision in decisions)
			{
				decision.PrepareDecision(brain, Index);
			}
		}

		public override bool Decide(MAnimalBrain brain, int Index)
		{
			for (int i = 0; i < decisions.Count; i++)
			{
				bool flag = decisions[i].Decide(brain, Index);
				if (invert[i])
				{
					flag = !flag;
				}
				if (debug)
				{
					Debug.Log(string.Format("[{0}] -> [{1}{2}] -> [{3}]", brain.Animal.name, invert[i] ? "NOT " : " ", decisions[i].name, flag), this);
				}
				if (!flag)
				{
					return false;
				}
			}
			return true;
		}

		public override void FinishDecision(MAnimalBrain brain, int Index)
		{
			foreach (MAIDecision decision in decisions)
			{
				decision?.FinishDecision(brain, Index);
			}
		}

		public override void DrawGizmos(MAnimalBrain brain)
		{
			if (decisions == null)
			{
				return;
			}
			foreach (MAIDecision decision in decisions)
			{
				decision?.DrawGizmos(brain);
			}
		}

		private void Reset()
		{
			Description = "All Decisions on the list  must be TRUE in order to sent a True Decision";
		}
	}
}
