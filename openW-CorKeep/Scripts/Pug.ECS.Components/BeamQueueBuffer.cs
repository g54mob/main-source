using Unity.Entities;
using Unity.Mathematics;

public struct BeamQueueBuffer : IBufferElementData
{
	public int beamId;

	public double spawnTime;

	public float3 spawnPos;

	public float startDuration;
}
