using Unity.Entities;

public struct WeaponSkillMultiplierCD : IComponentData, IQueryTypeParameter
{
	public float skillMultiplier;
}
