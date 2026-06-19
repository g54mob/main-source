using Pug.UnityExtensions;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct BossLarvaCD : IComponentData, IQueryTypeParameter
{
	public const float MIN_ANGLE_BETWEEN_TARGET_POINTS = 10f;

	public const float MAX_ANGLE_BETWEEN_TARGET_POINTS = 15f;

	public const int SEGMENTS_AMOUNT = 5;

	public WorldGenerationTypeDependentValue<int> roamDistance;

	public WorldGenerationTypeDependentValue<int> roamDeviation;

	public ThreadSafeTimerSimple changeDirectionTimer;

	[GhostField]
	public quaternion currentRotation;

	public quaternion previousRotation;

	public quaternion targetRotation;

	public int targetPointIndex;

	public float3 targetPoint;

	[GhostField]
	public int currentPhase;

	public float3 phase2Position;

	public BossLarvaTurnType currentTurnType;

	public float rotationLerpAlpha;

	public int internalState;

	public int damage;

	public Entity segmentPrefabSmall;

	public Entity segmentPrefabMedium;

	public Entity segmentPrefabLarge;

	[GhostField]
	public Entity segment0;

	[GhostField]
	public Entity segment1;

	[GhostField]
	public Entity segment2;

	[GhostField]
	public Entity segment3;

	[GhostField]
	public Entity segment4;

	public bool isEnraged => currentPhase == 1;

	private unsafe Entity Get(int index)
	{
		Entity* ptr = (Entity*)UnsafeUtility.AddressOf(ref segment0);
		UnsafeUtility.CopyPtrToStructure<Entity>(ptr + index, out var output);
		return output;
	}

	public NativeList<Entity> GetAllSegmentEntites(Allocator allocator)
	{
		NativeList<Entity> result = new NativeList<Entity>(5, allocator);
		for (int i = 0; i < 5; i++)
		{
			result.Add(Get(i));
		}
		return result;
	}
}
