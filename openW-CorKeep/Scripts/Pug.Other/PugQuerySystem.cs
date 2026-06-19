using Unity.Entities;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
public class PugQuerySystem : SystemBase
{
	[Preserve]
	protected override void OnCreate()
	{
		base.OnCreate();
		base.Enabled = false;
	}

	[Preserve]
	protected override void OnUpdate()
	{
	}

	[Preserve]
	public PugQuerySystem()
	{
	}
}
