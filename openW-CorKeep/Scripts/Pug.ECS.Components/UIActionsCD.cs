using Unity.Entities;
using Unity.NetCode;

public struct UIActionsCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public NetworkTick lastActionTick;
}
