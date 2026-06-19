using Unity.Entities;
using Unity.NetCode;

public struct PlayerOrientationCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public bool reorientationBlocked;
}
