using System;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Conditions
{
	[Serializable]
	public class C_Float : MCondition
	{
		public FloatReference Target;

		public ComparerInt Condition;

		public FloatReference Value;

		public override string DisplayName => "Values/Float";

		public void SetTarget(float targ)
		{
			Target.Value = targ;
		}

		public void SetValue(float targ)
		{
			Value.Value = targ;
		}

		public void SetTarget(FloatVar targ)
		{
			Target.Value = targ.Value;
		}

		public void SetValue(FloatVar targ)
		{
			Value.Value = targ.Value;
		}

		public override bool _Evaluate()
		{
			return Target.Value.CompareFloat(Value.Value, Condition);
		}

		protected override void _SetTarget(UnityEngine.Object target)
		{
			VerifyTarget(target, ref Target.Variable);
		}

		private void Reset()
		{
			Name = "New Float Comparer";
		}
	}
}
