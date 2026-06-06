using System;
using UnityEngine;

namespace MalbersAnimations.Conditions
{
	[Serializable]
	public class C_HasComponentGameObject : MCondition
	{
		[Tooltip("Target to check for the condition ")]
		[RequiredField]
		public GameObject Target;

		[Tooltip("Type of Script-Component attached to the GameObject")]
		public string componentName;

		public override string DisplayName => "Unity/Has Component [GameObject]";

		public override bool _Evaluate()
		{
			if (Target != null)
			{
				return Target.GetComponent(componentName) != null;
			}
			return false;
		}

		protected override void _SetTarget(UnityEngine.Object target)
		{
			VerifyTarget(target, ref Target);
		}

		private void Reset()
		{
			Name = "Does the GameObject has this component?";
		}
	}
}
