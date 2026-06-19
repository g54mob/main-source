using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.UnityExtensions;
using PugWorldGen;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Transforms;
using UnityEngine;

[BurstCompile]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(SimulationSystemGroup))]
public struct RoamingPathSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private struct HasInitializedRoamingPath : IComponentData, IQueryTypeParameter
	{
	}

	[WithAll(new Type[] { typeof(HasInitializedRoamingPath) })]
	private struct TriggerRoamAroundPlayerWhenInSubBiomeJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

				public ComponentTypeHandle<RoamAroundPlayerWhenInSubBiomeCD> __RoamAroundPlayerWhenInSubBiomeCD_RW_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
					__RoamAroundPlayerWhenInSubBiomeCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<RoamAroundPlayerWhenInSubBiomeCD>();
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
					__RoamAroundPlayerWhenInSubBiomeCD_RW_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<HasInitializedRoamingPath>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RoamAroundPlayerWhenInSubBiomeCD>();
				DefaultQuery = entityQueryBuilder2.Build(ref state);
				entityQueryBuilder.Reset();
				entityQueryBuilder.Dispose();
			}

			public void Init(ref SystemState state, bool assignDefaultQuery)
			{
				if (assignDefaultQuery)
				{
					__AssignQueries(ref state);
				}
				__TypeHandle.__AssignHandles(ref state);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void Run(ref TriggerRoamAroundPlayerWhenInSubBiomeJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref TriggerRoamAroundPlayerWhenInSubBiomeJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref TriggerRoamAroundPlayerWhenInSubBiomeJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref TriggerRoamAroundPlayerWhenInSubBiomeJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref TriggerRoamAroundPlayerWhenInSubBiomeJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref TriggerRoamAroundPlayerWhenInSubBiomeJob job, EntityManager entityManager)
			{
			}
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct InternalCompiler
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			public static void CheckForErrors(int scheduleType)
			{
			}
		}

		private const float NEW_PATH_REFRESH_COOLDOWN_TIME = 5f;

		private const float NEW_PATH_ON_FOUND_COOLDOWN_TIME = 15f;

		private const float MAX_PLAYER_CHECK_DISTANCE = 400f;

		private const float MAX_PLAYER_CHECK_DISTANCE_SQ = 160000f;

		[ReadOnly]
		public ComponentLookup<CurrentSubBiomeCD> currentSubBiomeLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> translationLookup;

		[ReadOnly]
		public NativeList<Entity> playerEntities;

		public NetworkTick currentTick;

		public uint tickRate;

		public EntityCommandBuffer ecb;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, in LocalTransform localTransform, ref RoamAroundPlayerWhenInSubBiomeCD roamAroundPlayerWhenInSubBiomeCD)
		{
			if (roamAroundPlayerWhenInSubBiomeCD.newPathCooldown.isRunning && !roamAroundPlayerWhenInSubBiomeCD.newPathCooldown.IsTimerElapsed(currentTick))
			{
				return;
			}
			Entity entity2 = Entity.Null;
			float num = 160000f;
			for (int i = 0; i < playerEntities.Length; i++)
			{
				Entity entity3 = playerEntities[i];
				float num2 = math.distancesq(translationLookup[entity3].Position, localTransform.Position);
				currentSubBiomeLookup.TryGetComponent(entity3, out var componentData);
				if (num2 < num && componentData.subBiome == roamAroundPlayerWhenInSubBiomeCD.subBiomeTileset)
				{
					entity2 = entity3;
					num = num2;
				}
			}
			if (entity2 != Entity.Null)
			{
				float3 position = translationLookup[entity2].Position;
				roamAroundPlayerWhenInSubBiomeCD.newPathCooldown.Start(currentTick, 15f, tickRate);
				roamAroundPlayerWhenInSubBiomeCD.wasRaomingAroundPlayer = true;
				ecb.RemoveComponent<HasInitializedRoamingPath>(entity);
				ecb.SetComponentEnabled<ForceRoamAroundPlayerCD>(entity, value: true);
				ecb.SetComponent(entity, new ForceRoamAroundPlayerCD
				{
					playerPos = position
				});
			}
			else
			{
				if (roamAroundPlayerWhenInSubBiomeCD.wasRaomingAroundPlayer)
				{
					roamAroundPlayerWhenInSubBiomeCD.wasRaomingAroundPlayer = false;
					ecb.RemoveComponent<HasInitializedRoamingPath>(entity);
				}
				roamAroundPlayerWhenInSubBiomeCD.newPathCooldown.Start(currentTick, 5f, tickRate);
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__RoamAroundPlayerWhenInSubBiomeCD_RW_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RoamAroundPlayerWhenInSubBiomeCD>(nativeArrayPtr3, i));
					num++;
				}
				return;
			}
			if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
			{
				int nextRangeBegin = 0;
				int nextRangeEnd = 0;
				while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out nextRangeBegin, out nextRangeEnd))
				{
					while (nextRangeBegin < nextRangeEnd)
					{
						Entity entity2 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, nextRangeBegin);
						Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RoamAroundPlayerWhenInSubBiomeCD>(nativeArrayPtr3, nextRangeBegin));
						nextRangeBegin++;
						num++;
					}
				}
				return;
			}
			ulong num2 = chunkEnabledMask.ULong0;
			int num3 = math.min(64, count);
			for (int j = 0; j < num3; j++)
			{
				if ((num2 & 1) != 0L)
				{
					Entity entity3 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j);
					Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RoamAroundPlayerWhenInSubBiomeCD>(nativeArrayPtr3, j));
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					Entity entity4 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k);
					Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RoamAroundPlayerWhenInSubBiomeCD>(nativeArrayPtr3, k));
					num++;
				}
				num2 >>= 1;
			}
		}

		private JobHandle __ThrowCodeGenException()
		{
			throw new Exception("This method should have been replaced by source gen.");
		}

		public void Run()
		{
			__ThrowCodeGenException();
		}

		public void RunByRef()
		{
			__ThrowCodeGenException();
		}

		public void Run(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void RunByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public JobHandle Schedule(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleByRef(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle Schedule(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleByRef(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public void Schedule()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleByRef()
		{
			__ThrowCodeGenException();
		}

		public void Schedule(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void ScheduleByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
		{
			return __ThrowCodeGenException();
		}

		public void ScheduleParallel()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallelByRef()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallel(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallelByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	[BurstCompile]
	[WithNone(new Type[] { typeof(HasInitializedRoamingPath) })]
	private struct RoamingPathInitializeJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public BufferTypeHandle<RoamingPathBuffer> __RoamingPathBuffer_RW_BufferTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<RoamingPathCD> __RoamingPathCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<SpawnPointCD> __SpawnPointCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__RoamingPathBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<RoamingPathBuffer>();
					__RoamingPathCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<RoamingPathCD>(isReadOnly: true);
					__SpawnPointCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<SpawnPointCD>(isReadOnly: true);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__RoamingPathBuffer_RW_BufferTypeHandle.Update(ref state);
					__RoamingPathCD_RO_ComponentTypeHandle.Update(ref state);
					__SpawnPointCD_RO_ComponentTypeHandle.Update(ref state);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<HasInitializedRoamingPath>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<RoamingPathCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SpawnPointCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RoamingPathBuffer>();
				DefaultQuery = entityQueryBuilder2.Build(ref state);
				entityQueryBuilder.Reset();
				entityQueryBuilder.Dispose();
			}

			public void Init(ref SystemState state, bool assignDefaultQuery)
			{
				if (assignDefaultQuery)
				{
					__AssignQueries(ref state);
				}
				__TypeHandle.__AssignHandles(ref state);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void Run(ref RoamingPathInitializeJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref RoamingPathInitializeJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref RoamingPathInitializeJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref RoamingPathInitializeJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref RoamingPathInitializeJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref RoamingPathInitializeJob job, EntityManager entityManager)
			{
			}
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct InternalCompiler
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			public static void CheckForErrors(int scheduleType)
			{
			}
		}

		[ReadOnly]
		public NativeArray<int2> biomeCentroids;

		[ReadOnly]
		public BiomeLookup biomeLookup;

		public ComponentLookup<ForceRoamAroundPlayerCD> forceRoamAroundPlayerLookup;

		public uint seed;

		public EntityCommandBuffer ecb;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, ref DynamicBuffer<RoamingPathBuffer> path, in RoamingPathCD roamingPath, in SpawnPointCD spawnPoint, in LocalTransform localTransform)
		{
			path.Clear();
			float3 pathStartPosition = spawnPoint.position;
			Unity.Mathematics.Random rnd = PugRandom.GetRngFromWorldPosition(pathStartPosition, seed);
			Biome biome = ((roamingPath.forceBiome != Biome.None) ? roamingPath.forceBiome : biomeLookup.GetBiome(pathStartPosition.RoundToInt2()));
			float distanceFromCore = math.length(pathStartPosition);
			RoamingPathType roamingPathType = roamingPath.pathType;
			if (roamingPathType == RoamingPathType.StayInsideBiomeAtDistanceFromCore && biome == Biome.None)
			{
				roamingPathType = RoamingPathType.RandomInsideCircle;
			}
			if (forceRoamAroundPlayerLookup.HasAndIsComponentEnabled(entity))
			{
				roamingPathType = RoamingPathType.RandomNearPlayer;
				forceRoamAroundPlayerLookup.SetComponentEnabled(entity, value: false);
			}
			switch (roamingPathType)
			{
			case RoamingPathType.StayInsideBiomeAtDistanceFromCore:
				StayInsideBiomeAtDistanceFromCore(distanceFromCore, roamingPath.distanceDeviation, roamingPath.minAngleToBiomeMidpoint, roamingPath.angleWidth, roamingPath.pathLengthMultiplier, biome, roamingPath.distanceBetweenPoints, roamingPath.curveSmoothness, roamingPath.angleDeviation, roamingPath.pointsBetweenAngleDeviationChanges, ref path, ref pathStartPosition, ref rnd);
				break;
			case RoamingPathType.RandomInsideCircle:
				RandomInsideCircle(pathStartPosition, ref path, ref rnd, roamingPath.pointCount, new float2(0f, roamingPath.regionRadius), roamingPath.segmentation, roamingPath.zigzagAmount, includeCenter: true);
				break;
			case RoamingPathType.RandomNearPlayer:
			{
				float3 position = localTransform.Position;
				forceRoamAroundPlayerLookup.TryGetComponent(entity, out var componentData);
				float3 playerPos = componentData.playerPos;
				CirclingAroundPoint(position, playerPos, ref path, ref rnd, 8, new float2(20f, 30f), 3, 0f);
				break;
			}
			}
			ecb.AddComponent<HasInitializedRoamingPath>(entity);
		}

		private void StayInsideBiomeAtDistanceFromCore(float distanceFromCore, float distanceDeviation, float minAngleToBiomeMidpoint, float angleWidth, float pathLengthMultiplier, Biome biome, float2 distanceBetweenPoints, float curveSmoothness, float angleDeviation, int pointsBetweenAngleDeviationChanges, ref DynamicBuffer<RoamingPathBuffer> path, ref float3 pathStartPosition, ref Unity.Mathematics.Random rnd)
		{
			float num = distanceFromCore - distanceDeviation;
			float num2 = distanceFromCore + distanceDeviation;
			float angleStart = AngleRadians(biomeCentroids[(int)biome]) + minAngleToBiomeMidpoint;
			float num3 = angleWidth * math.length(pathStartPosition) * pathLengthMultiplier * 2f;
			float3 float5 = math.normalizesafe(biomeCentroids[(int)biome].ToFloat3()) * distanceFromCore;
			if (biomeLookup.GetBiome(pathStartPosition.RoundToInt2()) != biome)
			{
				pathStartPosition = float5;
			}
			float3 float6 = pathStartPosition;
			path.Add(new RoamingPathBuffer(pathStartPosition));
			float3 float7 = float3.zero;
			float num4 = 0f;
			bool flag = true;
			bool flag2 = false;
			float num5 = 0f;
			float num6 = 0f;
			int num7 = 0;
			while (num4 < num3)
			{
				if (!flag2)
				{
					float num8 = math.distance(pathStartPosition, float6);
					if (num4 + num8 > num3 * 0.9f)
					{
						flag2 = true;
					}
				}
				if (flag2)
				{
					num5 = math.abs(GetAngle(pathStartPosition, float6));
				}
				float3 float8 = math.cross(math.normalizesafe(float6), flag ? math.down() : math.up());
				float8.y = 0f;
				float3 float9 = float8;
				if (!IsInAngleRange(AngleRadians(float6.FloorToInt2()), angleStart, angleWidth))
				{
					float num9 = math.distancesq(float6 + float9, float5);
					if (math.distancesq(float6 - float9, float5) < num9)
					{
						float9 = -float9;
						flag = !flag;
					}
				}
				if (flag2)
				{
					float num10 = math.distancesq(float6 + float9, pathStartPosition);
					if (math.distancesq(float6 - float9, pathStartPosition) < num10)
					{
						float9 = -float9;
						flag = !flag;
					}
				}
				if (num7 % pointsBetweenAngleDeviationChanges == 0)
				{
					float num11 = math.length(float6);
					num6 = rnd.NextFloat((num11 < num * 1.1f) ? 0f : (0f - angleDeviation), (num11 > num2 * 0.9f) ? 0f : angleDeviation);
					if (!flag)
					{
						num6 = 0f - num6;
					}
				}
				float num12 = (flag2 ? 0.5f : 1f);
				float3 vec = math.normalizesafe(pathStartPosition - float6, float9);
				float num13 = math.sign(float9.x * vec.z - float9.z * vec.x) * GetAngle(float9, vec);
				float num14 = (flag2 ? (1f + 20f / (num5 + 1f)) : 0f);
				float num15 = num12 + num14;
				float f = (num6 * num12 / num15 + num13 * num14 / num15) * (MathF.PI / 180f);
				float x = float9.x * Mathf.Cos(f) - float9.z * Mathf.Sin(f);
				float z = float9.x * Mathf.Sin(f) + float9.z * Mathf.Cos(f);
				float9 = new float3(x, 0f, z);
				float num16 = rnd.NextFloat(distanceBetweenPoints.x, distanceBetweenPoints.y);
				float3 float10 = float9 * num16;
				float3 float11 = float6 + float10;
				float3 float12 = math.normalizesafe(float11 - float6);
				if (math.length(float7) > 1.1920929E-07f && math.length(float12) > 1.1920929E-07f)
				{
					float12 = math.mul(math.slerp(quaternion.LookRotationSafe(float12, math.up()), quaternion.LookRotationSafe(float7, math.up()), curveSmoothness), math.forward());
					float11 = float6 + float12 * num16;
				}
				path.Add(new RoamingPathBuffer(float11));
				float num17 = math.distance(float6, float11);
				num4 += num17;
				float6 = float11;
				float7 = float12;
				num7++;
				if (flag2 && num5 < 5f)
				{
					break;
				}
			}
		}

		private void RandomInsideCircle(float3 pathStartPosition, ref DynamicBuffer<RoamingPathBuffer> path, ref Unity.Mathematics.Random rnd, int pointCount, float2 minMaxRegionRadius, int segmentation, float zigzagAmount, bool includeCenter)
		{
			NativeArray<float2> nativeArray = new NativeArray<float2>(pointCount, Allocator.Temp);
			int num = 0;
			if (includeCenter)
			{
				nativeArray[num] = new float2
				{
					x = 0f,
					y = 0f
				};
				num++;
			}
			path.Add(new RoamingPathBuffer(pathStartPosition));
			for (int i = num; i < pointCount; i++)
			{
				float num2 = rnd.NextFloat();
				float x = rnd.NextFloat();
				float x2 = MathF.PI * 2f * num2;
				float num3 = math.lerp(minMaxRegionRadius.x, minMaxRegionRadius.y, math.sqrt(x));
				float x3 = num3 * math.cos(x2);
				float y = num3 * math.sin(x2);
				nativeArray[i] = new float2
				{
					x = x3,
					y = y
				};
			}
			int length = nativeArray.Length * segmentation;
			NativeArray<float2> nativeArray2 = new NativeArray<float2>(length, Allocator.Temp);
			int num4 = 0;
			for (int j = 0; j < nativeArray.Length; j++)
			{
				float2 float5 = ((j > 0) ? nativeArray[j - 1] : nativeArray[nativeArray.Length - 1]);
				float2 float6 = nativeArray[j];
				float2 float7 = nativeArray[(j + 1) % nativeArray.Length];
				float2 float8 = nativeArray[(j + 2) % nativeArray.Length];
				float2 float9 = new float2
				{
					x = float6.x + (float7.x - float5.x) / 6f,
					y = float6.y + (float7.y - float5.y) / 6f
				};
				float2 float10 = new float2
				{
					x = float7.x - (float8.x - float6.x) / 6f,
					y = float7.y - (float8.y - float6.y) / 6f
				};
				for (int k = 0; k < segmentation; k++)
				{
					float num5 = (float)k / (float)segmentation;
					nativeArray2[num4++] = new float2
					{
						x = math.pow(1f - num5, 3f) * float6.x + 3f * math.pow(1f - num5, 2f) * num5 * float9.x + 3f * (1f - num5) * math.pow(num5, 2f) * float10.x + math.pow(num5, 3f) * float7.x,
						y = math.pow(1f - num5, 3f) * float6.y + 3f * math.pow(1f - num5, 2f) * num5 * float9.y + 3f * (1f - num5) * math.pow(num5, 2f) * float10.y + math.pow(num5, 3f) * float7.y
					};
				}
			}
			nativeArray.Dispose();
			NativeArray<float2> nativeArray3 = new NativeArray<float2>(length, Allocator.Temp);
			float num6 = 0f;
			for (int l = 0; l < nativeArray2.Length; l++)
			{
				float2 float11 = nativeArray2[l];
				float2 float12 = nativeArray2[(l + 1) % nativeArray2.Length] - float11;
				float2 float13 = math.normalizesafe(new float2(0f - float12.y, float12.x)) * math.sin(math.radians(num6)) * zigzagAmount;
				nativeArray3[l] = float11 + float13;
				num6 += 80f;
			}
			nativeArray2.Dispose();
			foreach (float2 item in nativeArray3)
			{
				path.Add(new RoamingPathBuffer(pathStartPosition + new float3(item.x, 0f, item.y)));
			}
			nativeArray3.Dispose();
		}

		private void CirclingAroundPoint(float3 currentPos, float3 circleAroundPos, ref DynamicBuffer<RoamingPathBuffer> path, ref Unity.Mathematics.Random rnd, int pointCount, float2 minMaxRegionRadius, int segmentation, float zigzagAmount)
		{
			NativeArray<float2> nativeArray = new NativeArray<float2>(pointCount, Allocator.Temp);
			float2 x = (circleAroundPos - currentPos).ToFloat2();
			x = (nativeArray[0] = math.clamp(math.length(x), minMaxRegionRadius.x, minMaxRegionRadius.y) * math.normalizesafe(x));
			float num = math.atan2(currentPos.x, currentPos.y);
			path.Add(new RoamingPathBuffer(circleAroundPos + x.ToFloat3()));
			for (int i = 1; i < pointCount; i++)
			{
				float x2 = rnd.NextFloat();
				float x3 = num + MathF.PI * 2f * (float)i / (float)pointCount;
				float num2 = math.lerp(minMaxRegionRadius.x, minMaxRegionRadius.y, math.sqrt(x2));
				float x4 = num2 * math.cos(x3);
				float y = num2 * math.sin(x3);
				nativeArray[i] = new float2
				{
					x = x4,
					y = y
				};
			}
			int length = nativeArray.Length * segmentation;
			NativeArray<float2> nativeArray2 = new NativeArray<float2>(length, Allocator.Temp);
			int num3 = 0;
			for (int j = 0; j < nativeArray.Length; j++)
			{
				float2 float6 = ((j > 0) ? nativeArray[j - 1] : nativeArray[nativeArray.Length - 1]);
				float2 float7 = nativeArray[j];
				float2 float8 = nativeArray[(j + 1) % nativeArray.Length];
				float2 float9 = nativeArray[(j + 2) % nativeArray.Length];
				float2 float10 = new float2
				{
					x = float7.x + (float8.x - float6.x) / 6f,
					y = float7.y + (float8.y - float6.y) / 6f
				};
				float2 float11 = new float2
				{
					x = float8.x - (float9.x - float7.x) / 6f,
					y = float8.y - (float9.y - float7.y) / 6f
				};
				for (int k = 0; k < segmentation; k++)
				{
					float num4 = (float)k / (float)segmentation;
					nativeArray2[num3++] = new float2
					{
						x = math.pow(1f - num4, 3f) * float7.x + 3f * math.pow(1f - num4, 2f) * num4 * float10.x + 3f * (1f - num4) * math.pow(num4, 2f) * float11.x + math.pow(num4, 3f) * float8.x,
						y = math.pow(1f - num4, 3f) * float7.y + 3f * math.pow(1f - num4, 2f) * num4 * float10.y + 3f * (1f - num4) * math.pow(num4, 2f) * float11.y + math.pow(num4, 3f) * float8.y
					};
				}
			}
			nativeArray.Dispose();
			NativeArray<float2> nativeArray3 = new NativeArray<float2>(length, Allocator.Temp);
			float num5 = 0f;
			for (int l = 0; l < nativeArray2.Length; l++)
			{
				float2 float12 = nativeArray2[l];
				float2 float13 = nativeArray2[(l + 1) % nativeArray2.Length] - float12;
				float2 float14 = math.normalizesafe(new float2(0f - float13.y, float13.x)) * math.sin(math.radians(num5)) * zigzagAmount;
				nativeArray3[l] = float12 + float14;
				num5 += 80f;
			}
			nativeArray2.Dispose();
			foreach (float2 item in nativeArray3)
			{
				path.Add(new RoamingPathBuffer(circleAroundPos + new float3(item.x, 0f, item.y)));
			}
			nativeArray3.Dispose();
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			BufferAccessor<RoamingPathBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__RoamingPathBuffer_RW_BufferTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__RoamingPathCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__SpawnPointCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					DynamicBuffer<RoamingPathBuffer> path = bufferAccessor[i];
					Execute(entity, ref path, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RoamingPathCD>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SpawnPointCD>(nativeArrayPtr3, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr4, i));
					num++;
				}
				return;
			}
			if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
			{
				int nextRangeBegin = 0;
				int nextRangeEnd = 0;
				while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out nextRangeBegin, out nextRangeEnd))
				{
					while (nextRangeBegin < nextRangeEnd)
					{
						Entity entity2 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, nextRangeBegin);
						DynamicBuffer<RoamingPathBuffer> path2 = bufferAccessor[nextRangeBegin];
						Execute(entity2, ref path2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RoamingPathCD>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SpawnPointCD>(nativeArrayPtr3, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr4, nextRangeBegin));
						nextRangeBegin++;
						num++;
					}
				}
				return;
			}
			ulong num2 = chunkEnabledMask.ULong0;
			int num3 = math.min(64, count);
			for (int j = 0; j < num3; j++)
			{
				if ((num2 & 1) != 0L)
				{
					Entity entity3 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j);
					DynamicBuffer<RoamingPathBuffer> path3 = bufferAccessor[j];
					Execute(entity3, ref path3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RoamingPathCD>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SpawnPointCD>(nativeArrayPtr3, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr4, j));
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					Entity entity4 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k);
					DynamicBuffer<RoamingPathBuffer> path4 = bufferAccessor[k];
					Execute(entity4, ref path4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RoamingPathCD>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SpawnPointCD>(nativeArrayPtr3, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr4, k));
					num++;
				}
				num2 >>= 1;
			}
		}

		private JobHandle __ThrowCodeGenException()
		{
			throw new Exception("This method should have been replaced by source gen.");
		}

		public void Run()
		{
			__ThrowCodeGenException();
		}

		public void RunByRef()
		{
			__ThrowCodeGenException();
		}

		public void Run(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void RunByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public JobHandle Schedule(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleByRef(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle Schedule(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleByRef(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public void Schedule()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleByRef()
		{
			__ThrowCodeGenException();
		}

		public void Schedule(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void ScheduleByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
		{
			return __ThrowCodeGenException();
		}

		public void ScheduleParallel()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallelByRef()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallel(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallelByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	private struct TypeHandle
	{
		[ReadOnly]
		public ComponentLookup<CurrentSubBiomeCD> __CurrentSubBiomeCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentLookup;

		public TriggerRoamAroundPlayerWhenInSubBiomeJob.InternalCompilerQueryAndHandleData __RoamingPathSystem_TriggerRoamAroundPlayerWhenInSubBiomeJob_WithDefaultQuery_JobEntityTypeHandle;

		public ComponentLookup<ForceRoamAroundPlayerCD> __ForceRoamAroundPlayerCD_RW_ComponentLookup;

		public RoamingPathInitializeJob.InternalCompilerQueryAndHandleData __RoamingPathSystem_RoamingPathInitializeJob_WithDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__CurrentSubBiomeCD_RO_ComponentLookup = state.GetComponentLookup<CurrentSubBiomeCD>(isReadOnly: true);
			__Unity_Transforms_LocalTransform_RO_ComponentLookup = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
			__RoamingPathSystem_TriggerRoamAroundPlayerWhenInSubBiomeJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__ForceRoamAroundPlayerCD_RW_ComponentLookup = state.GetComponentLookup<ForceRoamAroundPlayerCD>();
			__RoamingPathSystem_RoamingPathInitializeJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnUpdate_00003D11_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_00003D11_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00003D11_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(IntPtr self, IntPtr state)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)functionPointer)(self, state);
					return;
				}
			}
			__codegen__OnUpdate_0024BurstManaged(self, state);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnStartRunning_00003D12_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStartRunning_00003D12_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStartRunning_00003D12_0024PostfixBurstDelegate>(__codegen__OnStartRunning).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(IntPtr self, IntPtr state)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)functionPointer)(self, state);
					return;
				}
			}
			__codegen__OnStartRunning_0024BurstManaged(self, state);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnStopRunning_00003D13_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStopRunning_00003D13_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStopRunning_00003D13_0024PostfixBurstDelegate>(__codegen__OnStopRunning).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(IntPtr self, IntPtr state)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)functionPointer)(self, state);
					return;
				}
			}
			__codegen__OnStopRunning_0024BurstManaged(self, state);
		}
	}

	private BiomeLookup _biomeLookup;

	private EntityQuery _playerQuery;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_2101573125_0;

	private EntityQuery __query_2101573125_1;

	private EntityQuery __query_2101573125_2;

	private EntityQuery __query_2101573125_3;

	private EntityQuery __query_2101573125_4;

	private EntityQuery __query_2101573125_5;

	private EntityQuery __query_2101573125_6;

	private EntityQuery __query_2101573125_7;

	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<ServerSeedCD>();
		state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
		state.RequireForUpdate(__query_2101573125_0);
		state.RequireForUpdate<BiomeCentroidsCD>();
		_playerQuery = state.EntityManager.CreateEntityQuery(ComponentType.ReadOnly<PlayerGhost>(), ComponentType.ReadOnly<LocalTransform>(), ComponentType.Exclude<DisablePhysicsCD>());
	}

	[BurstCompile]
	public void OnStartRunning(ref SystemState state)
	{
		_biomeLookup = (__query_2101573125_1.TryGetSingleton<BiomeSamplesCD>(out var value) ? new BiomeLookup(value) : new BiomeLookup(__query_2101573125_2.GetSingleton<BiomeRangesCD>().Value, Allocator.Persistent));
	}

	[BurstCompile]
	public void OnStopRunning(ref SystemState state)
	{
		_biomeLookup.Dispose();
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		EntityCommandBuffer ecb = __query_2101573125_3.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
		__query_2101573125_4.TryGetSingleton<NetworkTime>(out var value);
		JobHandle outJobHandle;
		NativeList<Entity> playerEntities = _playerQuery.ToEntityListAsync(state.WorldUpdateAllocator, state.Dependency, out outJobHandle);
		state.Dependency = __ScheduleViaJobChunkExtension_0(new TriggerRoamAroundPlayerWhenInSubBiomeJob
		{
			currentSubBiomeLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__CurrentSubBiomeCD_RO_ComponentLookup, ref state),
			translationLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref state),
			playerEntities = playerEntities,
			currentTick = value.ServerTick,
			tickRate = (uint)__query_2101573125_5.GetSingleton<ClientServerTickRate>().SimulationTickRate,
			ecb = ecb
		}, __TypeHandle.__RoamingPathSystem_TriggerRoamAroundPlayerWhenInSubBiomeJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, outJobHandle, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_1(new RoamingPathInitializeJob
		{
			biomeLookup = _biomeLookup,
			biomeCentroids = __query_2101573125_6.GetSingleton<BiomeCentroidsCD>().Centroids,
			forceRoamAroundPlayerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ForceRoamAroundPlayerCD_RW_ComponentLookup, ref state),
			ecb = ecb,
			seed = __query_2101573125_7.GetSingleton<ServerSeedCD>().Value
		}, __TypeHandle.__RoamingPathSystem_RoamingPathInitializeJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
	}

	private static float AngleRadians(float2 pos)
	{
		return math.atan2(pos.y, pos.x);
	}

	private static bool IsInAngleRange(float v, float angleStart, float angleWidth)
	{
		angleStart = TrueMod(angleStart, MathF.PI * 2f);
		v = TrueMod(v, MathF.PI * 2f);
		if (v < angleStart)
		{
			v += MathF.PI * 2f;
		}
		return v - angleStart < angleWidth;
	}

	private static float TrueMod(float x, float m)
	{
		x %= m;
		if (x < 0f)
		{
			x += m;
		}
		return x;
	}

	[BurstDiscard]
	private static void DrawDebugLines(RoamingPathCD roamingPath, NativeParallelHashSet<int2> debugPositionsDrawn, float3 spawnPos, DynamicBuffer<RoamingPathBuffer> path, WorldGenerationTypeCD worldGenerationType)
	{
		if (!roamingPath.drawDebugLines || debugPositionsDrawn.Contains(spawnPos.RoundToInt2()))
		{
			return;
		}
		debugPositionsDrawn.Add(spawnPos.RoundToInt2());
		for (int i = 0; i < path.Length; i++)
		{
			Color color = i switch
			{
				1 => Color.blue, 
				0 => Color.green, 
				_ => Color.red, 
			};
			int index = (i + 1) % path.Length;
			if (worldGenerationType.Value == WorldGenerationType.FullRelease)
			{
				PugWorld.AddDebugLine(path[i].Value.xz, path[index].Value.xz, color);
			}
			else
			{
				UnityEngine.Debug.DrawLine(path[i].Value + new float3(0f, 1002f, 0f), path[index].Value + new float3(0f, 1002f, 0f), color, 2000f);
			}
		}
	}

	private static float GetAngle(float3 vec1, float3 vec2)
	{
		if (math.distancesq(vec1, vec2) < 1.1920929E-07f)
		{
			return 0f;
		}
		float num = math.dot(vec1, vec2);
		float num2 = math.length(vec1);
		float num3 = math.length(vec2);
		return math.degrees(math.acos(math.clamp(num / (num2 * num3), -1f, 1f)));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(TriggerRoamAroundPlayerWhenInSubBiomeJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__RoamingPathSystem_TriggerRoamAroundPlayerWhenInSubBiomeJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__RoamingPathSystem_TriggerRoamAroundPlayerWhenInSubBiomeJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__RoamingPathSystem_TriggerRoamAroundPlayerWhenInSubBiomeJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__RoamingPathSystem_TriggerRoamAroundPlayerWhenInSubBiomeJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_1(RoamingPathInitializeJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__RoamingPathSystem_RoamingPathInitializeJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__RoamingPathSystem_RoamingPathInitializeJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__RoamingPathSystem_RoamingPathInitializeJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__RoamingPathSystem_RoamingPathInitializeJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAny<BiomeRangesCD, BiomeSamplesCD>();
		__query_2101573125_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BiomeSamplesCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_2101573125_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BiomeRangesCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_2101573125_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_2101573125_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_2101573125_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_2101573125_5 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BiomeCentroidsCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_2101573125_6 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ServerSeedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_2101573125_7 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder.Dispose();
	}

	public void OnCreateForCompiler(ref SystemState state)
	{
		__AssignQueries(ref state);
		__TypeHandle.__AssignHandles(ref state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate(IntPtr self, IntPtr state)
	{
		((RoamingPathSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_00003D11_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStartRunning_00003D12_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStopRunning_00003D13_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((RoamingPathSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((RoamingPathSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStartRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((RoamingPathSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStopRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((RoamingPathSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
	}
}
