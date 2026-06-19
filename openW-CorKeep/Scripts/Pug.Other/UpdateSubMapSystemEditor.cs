using Unity.Burst;
using Unity.Entities;
using UnityEngine.Scripting;

[BurstCompile]
[WorldSystemFilter(WorldSystemFilterFlags.Editor, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup), OrderFirst = true)]
public class UpdateSubMapSystemEditor : ComponentSystemGroup
{
	[Preserve]
	protected override void OnCreate()
	{
		base.OnCreate();
		AddSystemToUpdateList(base.World.CreateSystem(typeof(UpdateSubMapSystemServerEditor)));
	}

	[Preserve]
	public UpdateSubMapSystemEditor()
	{
	}
}
