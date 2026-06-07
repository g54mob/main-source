using System;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Conditions
{
	[Serializable]
	public class C_Vector3 : MCondition
	{
		public Vector3Reference Target;

		public Vector3Reference Value;

		public override string DisplayName => "Values/Vector3";

		public void SetTarget(Vector3 targ)
		{
			Target.Value = targ;
		}

		public void SetValue(Vector3 targ)
		{
			Value.Value = targ;
		}

		public void SetTarget(Vector3Var targ)
		{
			Target.Value = targ.Value;
		}

		public void SetValue(Vector3Var targ)
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
			Name = "New Vector3 Comparer";
		}
	}
}
