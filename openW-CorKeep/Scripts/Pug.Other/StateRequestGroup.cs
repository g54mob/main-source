using Unity.Entities;
using UnityEngine.Scripting;

[UpdateBefore(typeof(StateHandlerSystem))]
[UpdateInGroup(typeof(StateSystemGroup))]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
public class StateRequestGroup : ComponentSystemGroup
{
	[Preserve]
	[Preserve]
	public StateRequestGroup()
	{
	}
}
