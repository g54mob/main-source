using Unity.Entities;
using Unity.Mathematics;

public struct ForceRoamAroundPlayerCD : IComponentData, IQueryTypeParameter, IEnableableComponent
{
	public float3 playerPos;
}
