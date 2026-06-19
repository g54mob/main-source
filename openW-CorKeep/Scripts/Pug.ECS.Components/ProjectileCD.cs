using System.Runtime.CompilerServices;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

public struct ProjectileCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public float2 prevPos;

	[GhostField]
	public float2 prevPrevPos;

	[GhostField]
	public Entity lastHitEnemy;

	[GhostField]
	public float directionRadians;

	public float damageRadius;

	public float damageRadiusClient;

	public float tileDamageRadius;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public float3 GetDirection3()
	{
		if (float.IsNaN(directionRadians))
		{
			return float3.zero;
		}
		return new float3(math.cos(directionRadians), 0f, math.sin(directionRadians));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public float2 GetDirection()
	{
		if (float.IsNaN(directionRadians))
		{
			return float2.zero;
		}
		return new float2(math.cos(directionRadians), math.sin(directionRadians));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void SetDirection(float2 direction)
	{
		directionRadians = math.atan2(direction.y, direction.x);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void SetDirection(float3 direction)
	{
		directionRadians = math.atan2(direction.z, direction.x);
	}
}
