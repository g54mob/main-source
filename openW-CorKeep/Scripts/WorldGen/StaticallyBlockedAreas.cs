using System;
using Pug.UnityExtensions;
using PugWorldGen;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

public struct StaticallyBlockedAreas : IDisposable
{
	public struct CircleBandOrAABB
	{
		public OptionalValue<PugGeometry.CircleBand> CircleBand;

		public OptionalValue<PugGeometry.AxisAlignedBoundingBox> AABB;

		public static implicit operator CircleBandOrAABB(PugGeometry.CircleBand band)
		{
			return new CircleBandOrAABB
			{
				CircleBand = new OptionalValue<PugGeometry.CircleBand>(band),
				AABB = default(OptionalValue<PugGeometry.AxisAlignedBoundingBox>)
			};
		}

		public static implicit operator CircleBandOrAABB(PugGeometry.AxisAlignedBoundingBox aabb)
		{
			return new CircleBandOrAABB
			{
				CircleBand = default(OptionalValue<PugGeometry.CircleBand>),
				AABB = new OptionalValue<PugGeometry.AxisAlignedBoundingBox>(aabb)
			};
		}
	}

	public NativeArray<CircleBandOrAABB> BlockedAreas;

	public bool IsCreated => BlockedAreas.IsCreated;

	public static StaticallyBlockedAreas Create(BlobAssetReference<PugDatabase.PugDatabaseBank> database, CoreKeeperWorldParameters worldGenParameters, ComponentLookup<BossLarvaCD> bossLarvaLookup, Allocator allocator)
	{
		StaticallyBlockedAreas result = default(StaticallyBlockedAreas);
		result.BlockedAreas = new NativeArray<CircleBandOrAABB>(5, allocator);
		result.BlockedAreas[0] = new PugGeometry.CircleBand
		{
			Radius = (int)math.round(worldGenParameters.ring2Size),
			Width = (int)math.round(worldGenParameters.ring2Chaos / 2f)
		};
		result.BlockedAreas[1] = new PugGeometry.CircleBand
		{
			Radius = (int)math.round(worldGenParameters.ring3Size),
			Width = (int)math.round(worldGenParameters.ring3Chaos / 2f)
		};
		result.BlockedAreas[2] = new PugGeometry.CircleBand
		{
			Radius = (int)math.round(worldGenParameters.ring4Size),
			Width = (int)math.round(worldGenParameters.ring4Chaos / 2f)
		};
		Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(ObjectID.BossLarva, database);
		BossLarvaCD bossLarvaCD = bossLarvaLookup[primaryPrefabEntity];
		result.BlockedAreas[3] = new PugGeometry.CircleBand
		{
			Radius = bossLarvaCD.roamDistance.fullRelease,
			Width = bossLarvaCD.roamDeviation.fullRelease
		};
		float num = worldGenParameters.northBlobRadius * 1.5f;
		float2 float5 = new float2(0f, worldGenParameters.ring4Size + num);
		float num2 = 20f;
		result.BlockedAreas[4] = PugGeometry.AxisAlignedBoundingBox.FromLowerCornerAndSize(float5 - new float2(num2 / 2f, num), new float2(num2, num * 2f));
		return result;
	}

	public void Dispose()
	{
		if (BlockedAreas.IsCreated)
		{
			BlockedAreas.Dispose();
		}
	}

	public bool Overlaps(PugGeometry.Circle circle)
	{
		foreach (CircleBandOrAABB blockedArea in BlockedAreas)
		{
			if (blockedArea.CircleBand.TryGetValue(out var output) && output.DistanceToPoint(circle.Center) < circle.Radius)
			{
				return true;
			}
			if (blockedArea.AABB.TryGetValue(out var output2) && circle.Overlaps(output2))
			{
				return true;
			}
		}
		return false;
	}

	public float GetClosestDistance(float2 position)
	{
		float num = float.MaxValue;
		foreach (CircleBandOrAABB blockedArea in BlockedAreas)
		{
			if (blockedArea.CircleBand.TryGetValue(out var output))
			{
				float num2 = output.DistanceToPoint(position);
				if (num2 < num)
				{
					num = num2;
				}
			}
			if (blockedArea.AABB.TryGetValue(out var output2))
			{
				float num3 = output2.DistanceToPoint(position);
				if (num3 < num)
				{
					num = num3;
				}
			}
		}
		return num;
	}
}
