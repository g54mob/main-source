using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Controller.AI
{
	[CreateAssetMenu(menuName = "Malbers Animations/Pluggable AI/Decision/Check Transform Var", order = 6)]
	public class CheckTransformVar : MAIDecision
	{
		public TransformVar Var;

		public CompareTransformVar compare;

		[Hide("compare", new int[] { 2 })]
		public RuntimeGameObjects Set;

		[SerializeField]
		[HideInInspector]
		private bool showSet;

		public override string DisplayName => "Variables/Check Transform Var";

		public override bool Decide(MAnimalBrain brain, int Index)
		{
			if ((bool)Var)
			{
				switch (compare)
				{
				case CompareTransformVar.IsNull:
					return Var.Value == null;
				case CompareTransformVar.IsCurrentTarget:
					return Var.Value == brain.Target;
				case CompareTransformVar.IsInRuntimeSet:
					if ((bool)Set)
					{
						return Set.items.Contains(Var.Value.gameObject);
					}
					return false;
				}
			}
			return false;
		}

		private void OnValidate()
		{
			showSet = compare == CompareTransformVar.IsInRuntimeSet;
		}
	}
}
