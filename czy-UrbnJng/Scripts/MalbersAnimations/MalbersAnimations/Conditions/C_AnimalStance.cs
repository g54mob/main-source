using System;

namespace MalbersAnimations.Conditions
{
	[Serializable]
	public class C_AnimalStance : MAnimalCondition
	{
		public enum StanceCondition
		{
			CurrentStance = 0,
			DefaultStance = 1
		}

		public StanceCondition Condition;

		public StanceID Value;

		public override string DisplayName => "Animal/Stances";

		public void SetValue(StanceID v)
		{
			Value = v;
		}

		public override bool _Evaluate()
		{
			if ((bool)Target)
			{
				switch (Condition)
				{
				case StanceCondition.CurrentStance:
					return Target.Stance == Value;
				case StanceCondition.DefaultStance:
					return Target.DefaultStanceID == Value;
				}
			}
			return false;
		}
	}
}
