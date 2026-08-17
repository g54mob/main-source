using VampireSurvivors.Data;

namespace VampireSurvivors.Framework;

public class WeightedLimitBreak
{
	public int Weight;

	public WeaponType WeaponType;

	public LimitBreakData KeyValues;

	public uint LimitBreakDataIndex;

	public string Id;

	public WeightedLimitBreak(WeaponType weaponType, int weight, LimitBreakData keyValues, uint limitBreakDataIndex, string id)
	{
		KeyValues = keyValues;
		WeaponType = weaponType;
		Weight = weight;
		uint limitBreakDataIndex2 = default(uint);
		LimitBreakDataIndex = limitBreakDataIndex2;
		string id2 = default(string);
		Id = id2;
	}
}
