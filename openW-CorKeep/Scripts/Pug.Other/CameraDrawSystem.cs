using Unity.Entities;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
[UpdateAfter(typeof(CameraUpdateSystem))]
[UpdateInGroup(typeof(PresentationSystemGroup), OrderLast = true)]
[AlwaysUpdateSystem]
public class CameraDrawSystem : SystemBase
{
	[Preserve]
	protected override void OnCreate()
	{
		base.Enabled = Manager.camera != null;
		base.OnCreate();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		if (Manager.sceneHandler != null)
		{
			Manager.camera.Draw();
		}
	}

	[Preserve]
	public CameraDrawSystem()
	{
	}
}
