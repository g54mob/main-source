using System;
using UnityEngine;

namespace MalbersAnimations.Conditions
{
	[Serializable]
	public class C_Behaviour : MCondition
	{
		[Tooltip("Target to check for the condition ")]
		[RequiredField]
		public Behaviour Target;

		[Tooltip("Conditions types")]
		public ComponentCondition Condition;

		public override string DisplayName => "Unity/Behavior";

		public override bool _Evaluate()
		{
			if (Target != null)
			{
				switch (Condition)
				{
				case ComponentCondition.Enabled:
					return Target.enabled;
				case ComponentCondition.ActiveAndEnabled:
					return Target.isActiveAndEnabled;
				}
			}
			return false;
		}

		protected override void _SetTarget(UnityEngine.Object target)
		{
			VerifyTarget(target, ref Target);
		}

		private void Reset()
		{
			Name = "New Behaviour Condition";
		}
	}
}
