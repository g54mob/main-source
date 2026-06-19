using Unity.Entities;
using UnityEngine.Scripting;

[UpdateAfter(typeof(StateHandlerSystem))]
[UpdateInGroup(typeof(StateSystemGroup))]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
public class StateUpdateGroup : ComponentSystemGroup
{
	[Preserve]
	[Preserve]
	public StateUpdateGroup()
	{
	}
}
