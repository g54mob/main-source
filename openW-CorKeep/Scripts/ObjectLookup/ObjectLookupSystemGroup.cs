using Unity.Entities;
using Unity.NetCode;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(PredictedSimulationSystemGroup), OrderFirst = true)]
[UpdateAfter(typeof(PhysicsWorldHistory))]
public class ObjectLookupSystemGroup : ComponentSystemGroup
{
	[Preserve]
	[Preserve]
	public ObjectLookupSystemGroup()
	{
	}
}
