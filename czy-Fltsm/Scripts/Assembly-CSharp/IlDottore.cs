using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Agent/Quirks/Il Dottore")]
public class IlDottore : VitalQuirkBase
{
	public override int OnInitializeVital(VitalType vital, int amount)
	{
		if (vital == VitalType.Pollution)
		{
			return 0;
		}
		return amount;
	}

	public override int OnIncreaseVital(VitalType vital, int amount)
	{
		if (vital == VitalType.Pollution)
		{
			return 0;
		}
		return amount;
	}
}
