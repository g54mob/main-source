using Assets.Nimbatus.Scripts.Common.Helpers;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Conditions
{
	public class ItemCollectCount : NimbatusCondition
	{
		public EIntegerCompareType CompareType;

		public int Value;

		public override bool IsTrue()
		{
			return NumberCompare.Compare(OwnWorldObject.GetCollectCount(), CompareType, Value);
		}
	}
}
