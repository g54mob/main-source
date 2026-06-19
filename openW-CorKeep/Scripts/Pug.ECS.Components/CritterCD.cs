using Unity.Entities;

public struct CritterCD : IComponentData, IQueryTypeParameter
{
	public float destroyTimer;
}
