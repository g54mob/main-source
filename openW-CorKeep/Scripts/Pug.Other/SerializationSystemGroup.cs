using Unity.Entities;
using UnityEngine.Scripting;

[UpdateInGroup(typeof(SimulationSystemGroup))]
public class SerializationSystemGroup : ComponentSystemGroup
{
	[Preserve]
	[Preserve]
	public SerializationSystemGroup()
	{
	}
}
