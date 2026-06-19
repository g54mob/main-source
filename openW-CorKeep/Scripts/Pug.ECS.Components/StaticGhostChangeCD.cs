using Unity.Entities;
using Unity.NetCode;

public struct StaticGhostChangeCD : IComponentData, IQueryTypeParameter, IEnableableComponent
{
	public NetworkTick lastChangeTick;
}
