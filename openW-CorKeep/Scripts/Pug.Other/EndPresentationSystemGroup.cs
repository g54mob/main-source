using Pug.ECS.Hybrid;
using Unity.Entities;
using UnityEngine.Scripting;

[UpdateBefore(typeof(UpdateGraphicalObjectSystem))]
[UpdateInGroup(typeof(PresentationSystemGroup), OrderLast = true)]
[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
public class EndPresentationSystemGroup : ComponentSystemGroup
{
	[Preserve]
	public EndPresentationSystemGroup()
	{
	}
}
