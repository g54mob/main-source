using Unity.Entities;

public struct OverrideLeaveCombatTimeCD : IComponentData, IQueryTypeParameter
{
	public float time;
}
