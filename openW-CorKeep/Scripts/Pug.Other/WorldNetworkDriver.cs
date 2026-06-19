using Unity.Entities;
using Unity.Networking.Transport;

public struct WorldNetworkDriver : IComponentData, IQueryTypeParameter
{
	public NetworkDriver driver;
}
