using Unity.Entities;
using Unity.Mathematics;

public struct CoreBossBeamMovementInstructionBuffer : IBufferElementData
{
	public int beamId;

	public float speed;

	public float duration;

	public int forwardMovementSign;

	public int rotationAroundTargetSign;

	public float3 target;
}
