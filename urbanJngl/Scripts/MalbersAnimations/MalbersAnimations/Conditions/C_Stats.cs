using System;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Conditions
{
	[Serializable]
	public class C_Stats : MCondition
	{
		[RequiredField]
		public Stats Target;

		public StatID ID;

		public StatCondition Condition;

		public ComparerInt Compare;

		public FloatReference Value;

		private Stat st;

		public override string DisplayName => "General/Stats";

		public void _SetTarget(Stats targ)
		{
			Target = targ;
		}

		public void _SetID(StatID targ)
		{
			ID = targ;
		}

		public void _SetValue(FloatVar targ)
		{
			Value.Value = targ;
		}

		public void _SetValue(float targ)
		{
			Value.Value = targ;
		}

		private void OnEnable()
		{
			if ((bool)Target)
			{
				st = Target.Stat_Get(ID);
			}
		}

		protected override void _SetTarget(UnityEngine.Object target)
		{
			VerifyTarget(target, ref Target);
		}

		public override bool _Evaluate()
		{
			if ((bool)Target)
			{
				if (st == null)
				{
					_ = Condition;
					return false;
				}
				switch (Condition)
				{
				case StatCondition.Enabled:
					return st.Active;
				case StatCondition.Regenerating:
					return st.IsRegenerating;
				case StatCondition.Degenerating:
					return st.IsDegenerating;
				case StatCondition.Inmune:
					return st.IsImmune;
				case StatCondition.Value:
					return st.Value.CompareFloat(Value.Value, Compare);
				case StatCondition.ValueNormalized:
					return st.NormalizedValue.CompareFloat(Value.Value, Compare);
				case StatCondition.Full:
					return st.IsFull;
				case StatCondition.Empty:
					return st.IsEmpty;
				case StatCondition.MaxValue:
					return st.MaxValue.CompareFloat(Value.Value, Compare);
				case StatCondition.MinValue:
					return st.MinValue.CompareFloat(Value.Value, Compare);
				}
			}
			return false;
		}

		private void Reset()
		{
			Name = "New Stat Comparer";
		}
	}
}
