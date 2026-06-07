using System;
using UnityEngine;

namespace MalbersAnimations.Conditions
{
	[Serializable]
	public class C_AnimatorParameter : MCondition
	{
		[Tooltip("Target to check for the condition ")]
		[RequiredField]
		public Animator Target;

		[Tooltip("Paramerter to check in the animator ")]
		public string parameter = "Parameter Name";

		[Tooltip("Conditions types")]
		public AnimatorType parameterType;

		[Hide("parameterType", true, new int[] { 2 })]
		public ComparerInt compare;

		[Hide("parameterType", false, new int[] { 2 })]
		public bool m_isTrue;

		[Hide("parameterType", false, new int[] { 0 })]
		public float m_Value;

		[Hide("parameterType", false, new int[] { 1 })]
		public int value;

		private int ParameterHash;

		public override string DisplayName => "Unity/Animator Parameter";

		public override bool _Evaluate()
		{
			if (ParameterHash == 0)
			{
				ParameterHash = Animator.StringToHash(parameter);
			}
			if (Target != null)
			{
				switch (parameterType)
				{
				case AnimatorType.Float:
					return Target.GetFloat(ParameterHash).CompareFloat(m_Value, compare);
				case AnimatorType.Int:
					return Target.GetInteger(ParameterHash).CompareInt(value, compare);
				case AnimatorType.Bool:
					return Target.GetBool(ParameterHash) == m_isTrue;
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
			Name = "New AnimatorParameter Condition";
		}
	}
}
