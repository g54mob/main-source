using Unity.Entities;

public struct PugDamageSetDirtyIfChangedCD : IComponentData, IQueryTypeParameter
{
	public int LastDamage;
}
