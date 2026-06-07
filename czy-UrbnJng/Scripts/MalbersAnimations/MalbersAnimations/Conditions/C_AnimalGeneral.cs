using System;

namespace MalbersAnimations.Conditions
{
	[Serializable]
	public class C_AnimalGeneral : MAnimalCondition
	{
		public enum AnimalCondition
		{
			Grounded = 0,
			RootMotion = 1,
			FreeMovement = 2,
			AlwaysForward = 3,
			Sleep = 4,
			AdditivePosition = 5,
			AdditiveRotation = 6,
			InZone = 7,
			InGroundChanger = 8
		}

		public AnimalCondition Condition;

		public override string DisplayName => "Animal/General";

		public override bool _Evaluate()
		{
			if ((bool)Target)
			{
				switch (Condition)
				{
				case AnimalCondition.Grounded:
					return Target.Grounded;
				case AnimalCondition.RootMotion:
					return Target.RootMotion;
				case AnimalCondition.FreeMovement:
					return Target.FreeMovement;
				case AnimalCondition.AlwaysForward:
					return Target.AlwaysForward;
				case AnimalCondition.Sleep:
					return Target.Sleep;
				case AnimalCondition.AdditivePosition:
					return Target.UseAdditivePos;
				case AnimalCondition.AdditiveRotation:
					return Target.UseAdditiveRot;
				case AnimalCondition.InZone:
					return Target.InZone;
				case AnimalCondition.InGroundChanger:
					if (Target.GroundChanger != null)
					{
						return Target.GroundChanger.Lerp > 0f;
					}
					return false;
				}
			}
			return false;
		}

		private void Reset()
		{
			Name = "New Animal Condition";
		}
	}
}
