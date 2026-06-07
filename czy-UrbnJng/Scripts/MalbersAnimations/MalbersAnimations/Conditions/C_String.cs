using System;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Conditions
{
	[Serializable]
	public class C_String : MCondition
	{
		public enum stringCondition
		{
			Equal = 0,
			Contains = 1
		}

		public StringReference Target;

		public stringCondition Condition;

		public StringReference Value;

		public override string DisplayName => "Values/String";

		public void SetTarget(string targ)
		{
			Target.Value = targ;
		}

		public void SetValue(string targ)
		{
			Value.Value = targ;
		}

		public override bool _Evaluate()
		{
			return Condition switch
			{
				stringCondition.Equal => Target.Value == Value.Value, 
				stringCondition.Contains => Target.Value.Contains(Value.Value), 
				_ => false, 
			};
		}

		protected override void _SetTarget(UnityEngine.Object target)
		{
			VerifyTarget(target, ref Target.Variable);
		}

		private void Reset()
		{
			Name = "New String Comparer";
		}
	}
}
