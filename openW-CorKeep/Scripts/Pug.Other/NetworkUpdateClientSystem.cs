using Unity.Entities;
using Unity.NetCode;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation | WorldSystemFilterFlags.ThinClientSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(NetworkReceiveSystemGroup), OrderFirst = true)]
public class NetworkUpdateClientSystem : SystemBase
{
	[Preserve]
	protected override void OnUpdate()
	{
		Manager.networking.ClientNetworkUpdate(base.World);
	}

	[Preserve]
	public NetworkUpdateClientSystem()
	{
	}
}
