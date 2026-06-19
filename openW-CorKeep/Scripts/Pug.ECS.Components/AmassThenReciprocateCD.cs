using Unity.Entities;
using Unity.NetCode;

public struct AmassThenReciprocateCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public bool isAmassing;

	[GhostField]
	public int damage;
}
