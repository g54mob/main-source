using System;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Conditions
{
	[Serializable]
	public class C_Bool : MCondition
	{
		public BoolReference Target;

		public BoolReference Value;

		public override string DisplayName => "Values/Boolean";

		public void SetTarget(bool targ)
		{
			Target.Value = targ;
		}

		public void SetValue(bool targ)
		{
			Value.Value = targ;
		}

		public void SetTarget(BoolVar targ)
		{
			Target.Value = targ.Value;
		}

		public void SetValue(BoolVar targ)
		{
			Value.Value = targ.Value;
		}

		public override bool _Evaluate()
		{
			return Target.Value == Value.Value;
		}

		protected override void _SetTarget(UnityEngine.Object target)
		{
			VerifyTarget(target, ref Target.Variable);
		}

		private void Reset()
		{
			Name = "New Bool Comparer";
		}
	}
}
