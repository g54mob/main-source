using Unity.Entities;
using Unity.NetCode;
using UnityEngine.Scripting;

[UpdateInGroup(typeof(PredictedSimulationSystemGroup))]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
public class UpdateHealthSystemGroup : ComponentSystemGroup
{
	[Preserve]
	[Preserve]
	public UpdateHealthSystemGroup()
	{
	}
}
