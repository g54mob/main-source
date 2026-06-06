using UnityEngine;

[CreateAssetMenu(fileName = "Generator Requirement", menuName = "Flotsam/Buildable/Energy/Passive Generator Requirement")]
public abstract class EnergyPassiveGeneratorRequirement : ScriptableObject
{
	public abstract bool MeetsRequirement(EnergyPassiveGenerator generator);
}
