using System;

namespace MalbersAnimations.Conditions
{
	[Serializable]
	public class C_AnimalStrafe : MAnimalCondition
	{
		public enum StrafeCondition
		{
			Strafing = 0,
			CanSrafe = 1
		}

		public StrafeCondition Condition;

		public StanceID Value;

		public override string DisplayName => "Animal/Strafe";

		public void _SetStanceID(StanceID v)
		{
			Value = v;
		}

		public override bool _Evaluate()
		{
			if ((bool)Target)
			{
				switch (Condition)
				{
				case StrafeCondition.Strafing:
					return Target.Strafe;
				case StrafeCondition.CanSrafe:
					if (Target.CanStrafe && (bool)Target.ActiveStance.CanStrafe)
					{
						return Target.ActiveState.CanStrafe;
					}
					return false;
				}
			}
			return false;
		}

		private void Reset()
		{
			Name = "Can the Animal Strafe?";
		}
	}
}
