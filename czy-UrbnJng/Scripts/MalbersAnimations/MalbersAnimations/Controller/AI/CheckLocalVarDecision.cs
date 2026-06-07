using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Controller.AI
{
	[CreateAssetMenu(menuName = "Malbers Animations/Pluggable AI/Decision/Check Local Var", order = 201)]
	public class CheckLocalVarDecision : MAIDecision
	{
		public enum CheckLocalVarsOn
		{
			Self = 0,
			Target = 1,
			TransformHook = 2,
			GameObjectVar = 3
		}

		[Space]
		[Tooltip("Check the Decision on the Animal(Self) or the Target(Target), or on an object with a tag")]
		public CheckLocalVarsOn checkOn;

		[Hide("checkOn", new int[] { 2 })]
		[RequiredField]
		public TransformVar TransformHook;

		[Hide("checkOn", new int[] { 3 })]
		[RequiredField]
		public GameObjectVar GameObjectVar;

		[Hide("isNumber")]
		public ComparerInt compare;

		[Tooltip("Name and Type of variable to check on the gameObject")]
		public LocalVar value;

		[HideInInspector]
		public bool isNumber;

		public override string DisplayName => "Variables/Check Local Variable";

		public override void PrepareDecision(MAnimalBrain brain, int Index)
		{
			switch (checkOn)
			{
			case CheckLocalVarsOn.Self:
				brain.ExtraLocalVars = brain.LocalVars;
				break;
			case CheckLocalVarsOn.Target:
				brain.ExtraLocalVars = brain.TargetVars;
				break;
			case CheckLocalVarsOn.TransformHook:
				if (TransformHook != null && TransformHook.Value != null)
				{
					brain.ExtraLocalVars = TransformHook.Value.FindComponent<MLocalVars>();
				}
				break;
			case CheckLocalVarsOn.GameObjectVar:
				if (GameObjectVar != null && GameObjectVar.Value != null)
				{
					brain.ExtraLocalVars = GameObjectVar.Value.FindComponent<MLocalVars>();
				}
				break;
			}
		}

		public override bool Decide(MAnimalBrain brain, int Index)
		{
			if (brain.ExtraLocalVars != null)
			{
				return brain.ExtraLocalVars.Compare(value, compare);
			}
			return false;
		}

		private void OnValidate()
		{
			isNumber = value.type == LocalVar.VarType.Int || value.type == LocalVar.VarType.Float;
		}
	}
}
