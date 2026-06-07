using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Controller.AI
{
	[CreateAssetMenu(menuName = "Malbers Animations/Pluggable AI/Decision/Is Target in RuntimeSet", order = 4)]
	public class IsTargetInSetDecision : MAIDecision
	{
		public RuntimeGameObjects Set;

		[Tooltip("Check if the Current Target is the closest ")]
		public bool IsClosest;

		[Tooltip("If the closest Object is not the Current Target. Assign it as a new target")]
		[Hide("IsClosest")]
		public bool ClosestIsNewTarget;

		[Tooltip("When the new target is assigned, set it to move to the target")]
		[Hide("ClosestIsNewTarget")]
		public bool Move = true;

		public override string DisplayName => "Runtime Set/Is Target in RuntimeSet";

		public override bool Decide(MAnimalBrain brain, int Index)
		{
			if (brain.AIControl.Target != null)
			{
				bool flag = Set.Items.Contains(brain.Target.gameObject);
				if (flag)
				{
					if (IsClosest)
					{
						GameObject gameObject = Set.Item_GetClosest(brain.gameObject);
						if (gameObject != brain.Target.gameObject)
						{
							if (ClosestIsNewTarget)
							{
								brain.AIControl.SetTarget(gameObject.transform, Move);
							}
							return false;
						}
						return true;
					}
					return flag;
				}
			}
			return false;
		}

		private void Reset()
		{
			Description = "Returns true if the Current AI Target is on a Runtime Set.\n If [IsClosest] is enabled. It will check also if the current target is the closest one. If is Not, then it will return false";
		}
	}
}
