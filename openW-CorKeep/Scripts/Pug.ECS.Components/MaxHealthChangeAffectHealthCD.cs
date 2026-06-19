using Unity.Entities;
using Unity.NetCode;

public struct MaxHealthChangeAffectHealthCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public int previousMaxHealth;
}
