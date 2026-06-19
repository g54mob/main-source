using Unity.Entities;
using Unity.NetCode;
using UnityEngine.Scripting;

[UpdateInGroup(typeof(PredictedSimulationSystemGroup))]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
public class ConditionEffectsUpdateSystemGroup : ComponentSystemGroup
{
	[Preserve]
	public ConditionEffectsUpdateSystemGroup()
	{
	}
}
