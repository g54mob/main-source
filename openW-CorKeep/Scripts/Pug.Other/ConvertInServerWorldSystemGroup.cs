using Unity.Entities;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(InitializationSystemGroup))]
public class ConvertInServerWorldSystemGroup : ComponentSystemGroup
{
	[Preserve]
	[Preserve]
	public ConvertInServerWorldSystemGroup()
	{
	}
}
