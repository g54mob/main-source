using Unity.Entities;

public struct ExtraInventoryCD : IComponentData, IQueryTypeParameter
{
	public int size;

	public int nextLevelSize;

	public ulong categoryTagsMask;

	public bool isPouch;
}
