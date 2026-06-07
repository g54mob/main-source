using Assets.Nimbatus.Scripts.Common.Helpers;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Conditions
{
	public class AccelerationCondition : NimbatusCondition
	{
		public EIntegerCompareType CompareType;

		public float Value;

		public override bool IsTrue()
		{
			return NumberCompare.Compare(OwnWorldObject.GetAcceleration().magnitude, CompareType, Value);
		}
	}
}
