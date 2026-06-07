using VampireSurvivors.Data;

namespace VampireSurvivors.Framework
{
	public class WeightedLimitBreak
	{
		public int Weight;

		public WeaponType WeaponType;

		public LimitBreakData KeyValues;

		public uint LimitBreakDataIndex;

		public string Id;

		public WeightedLimitBreak(WeaponType weaponType, int weight, LimitBreakData keyValues, uint limitBreakDataIndex, string id)
		{
		}
	}
}
