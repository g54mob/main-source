using UnityEngine;

[CreateAssetMenu(fileName = "Night Requirement", menuName = "Flotsam/Buildable/Generator Requirement/Night")]
public class EnergyNightRequirement : EnergyPassiveGeneratorRequirement
{
	public override bool MeetsRequirement(EnergyPassiveGenerator generator)
	{
		return GameManager.TimeManager.CurrentDay.DayTime == Day.E_DayTime.Day;
	}
}
