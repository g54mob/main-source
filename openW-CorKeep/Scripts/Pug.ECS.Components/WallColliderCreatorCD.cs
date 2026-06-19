using Unity.Entities;

public struct WallColliderCreatorCD : IComponentData, IQueryTypeParameter
{
	public double refreshTime;

	public uint lastHash;
}
