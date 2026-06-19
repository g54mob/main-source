using Unity.Entities;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(PresentationSystemGroup), OrderLast = true)]
[AlwaysUpdateSystem]
public class CameraUpdateSystem : SystemBase
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
			Manager.camera.CameraUpdate(base.CheckedStateRef.WorldUnmanaged.Time.DeltaTime, shouldDraw: false);
		}
	}

	[Preserve]
	public CameraUpdateSystem()
	{
	}
}
