using Unity.Entities;
using Unity.NetCode;

public struct SimulationGroupNetworkTime : IComponentData, IQueryTypeParameter
{
	public NetworkTime networkTime;
}
