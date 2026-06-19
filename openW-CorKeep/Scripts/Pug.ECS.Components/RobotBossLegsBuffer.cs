using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct RobotBossLegsBuffer : IBufferElementData
{
	[GhostField]
	public Entity leg;

	[GhostField]
	public float3 plannedTargetPosition;

	[GhostField]
	public bool hasPlannedTarget;

	[GhostField]
	public ThreadSafeTimerSimple brokenTimer;

	[GhostField]
	public int brokenTimerValue;

	[GhostField]
	public RobotBossLegPosition legPosition;
}
