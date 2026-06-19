using Unity.Entities;
using Unity.NetCode;

public struct QuickSwapTorchCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public int swappedTorchFromIndex;

	[GhostField]
	public int swappedTorchToIndex;
}
