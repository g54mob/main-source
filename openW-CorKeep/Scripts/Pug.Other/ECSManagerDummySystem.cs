using Unity.Entities;
using Unity.Jobs;
using UnityEngine.Scripting;

[DisableAutoCreation]
[AlwaysUpdateSystem]
public class ECSManagerDummySystem : SystemBase
{
	public new EntityQuery GetEntityQuery(params ComponentType[] componentTypes)
	{
		return base.GetEntityQuery(componentTypes);
	}

	public new EntityQuery GetEntityQuery(params EntityQueryDesc[] queryDescs)
	{
		return base.GetEntityQuery(queryDescs);
	}

	[Preserve]
	protected override void OnUpdate()
	{
		base.Dependency = default(JobHandle);
	}

	[Preserve]
	public ECSManagerDummySystem()
	{
	}
}
