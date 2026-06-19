using Unity.Entities;

public struct VendingMachineCD : IComponentData, IQueryTypeParameter
{
	public int sizeX;

	public int sizeY;

	public int size => sizeX * sizeY;
}
