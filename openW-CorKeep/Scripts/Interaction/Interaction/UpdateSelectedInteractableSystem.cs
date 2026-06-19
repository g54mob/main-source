using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Interaction
{
	[BurstCompile]
	[UpdateInGroup(typeof(InteractionSystemGroup))]
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
	public struct UpdateSelectedInteractableSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
	{
		private struct NearbyInteract
		{
			public int interactorIndex;

			public NearbyInteractData interactData;
		}

		private struct NearbyInteractData
		{
			public Entity entity;

			public float3 position;

			public FactionID requiredFactionToInteract;

			public BlobAssetReference<InteractablePointOffsetsData> interactingPointsData;

			public float weightMultiplier;

			public Direction.Id direction;

			public bool allowToUseOnlyWhenClaimed;

			public bool ignorePlayerDirection;
		}

		[BurstCompile]
		private struct RegisterNearbyInteractableToInteractorJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<InteractableCD> __Interaction_InteractableCD_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
						__Interaction_InteractableCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<InteractableCD>(isReadOnly: true);
						__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
					}

					public void Update(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle.Update(ref state);
						__Interaction_InteractableCD_RO_ComponentTypeHandle.Update(ref state);
						__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<InteractableCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
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
				public void Run(ref RegisterNearbyInteractableToInteractorJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref RegisterNearbyInteractableToInteractorJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref RegisterNearbyInteractableToInteractorJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref RegisterNearbyInteractableToInteractorJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref RegisterNearbyInteractableToInteractorJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref RegisterNearbyInteractableToInteractorJob job, EntityManager entityManager)
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
			public NativeList<LocalTransform> interactorTransforms;

			[ReadOnly]
			public ComponentLookup<DirectionCD> directionLookup;

			public NativeQueue<NearbyInteract>.ParallelWriter nearbyInteracts;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			private void Execute(Entity entity, in InteractableCD interactableCD, in LocalTransform localTransform)
			{
				directionLookup.TryGetComponent(entity, out var componentData);
				Direction.Id id = Direction.FromVector(componentData.direction).id;
				ref InteractableData value = ref interactableCD.interactableData.Value;
				float3 float5 = localTransform.Position + value.directionOffset.GetDataInDirection(id, value.directionOffset.forward).ToFloat3();
				for (int i = 0; i < interactorTransforms.Length; i++)
				{
					float3 position = interactorTransforms[i].Position;
					ref BlobArray<float3> interactablePointsInDirection = ref interactableCD.interactablePointOffsetsData.Value.GetInteractablePointsInDirection(id);
					int length = interactablePointsInDirection.Length;
					if (length > 0)
					{
						bool flag = false;
						for (int j = 0; j < length; j++)
						{
							float3 y = float5 + interactablePointsInDirection[j];
							if (math.distancesq(position, y) < value.interactRadiusSqr)
							{
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							continue;
						}
					}
					else if (math.distancesq(float5, position) >= value.interactRadiusSqr)
					{
						continue;
					}
					nearbyInteracts.Enqueue(new NearbyInteract
					{
						interactorIndex = i,
						interactData = new NearbyInteractData
						{
							entity = entity,
							position = float5,
							requiredFactionToInteract = value.requiredFactionToInteract,
							allowToUseOnlyWhenClaimed = value.allowToUseOnlyWhenClaimed,
							interactingPointsData = interactableCD.interactablePointOffsetsData,
							weightMultiplier = value.weightMultiplier,
							direction = id,
							ignorePlayerDirection = value.ignorePlayerDirection
						}
					});
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Interaction_InteractableCD_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
						Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<InteractableCD>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, i));
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
							Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<InteractableCD>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, nextRangeBegin));
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
						Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<InteractableCD>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, j));
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
						Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<InteractableCD>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, k));
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
		private struct FillHashMapJob : IJob
		{
			[ReadOnly]
			public NativeList<Entity> interactorEntities;

			public NativeQueue<NearbyInteract> nearbyInteracts;

			public NativeParallelMultiHashMap<Entity, NearbyInteractData> interactorToNearbyInteractableMap;

			public void Execute()
			{
				NearbyInteract item;
				while (nearbyInteracts.TryDequeue(out item))
				{
					Entity key = interactorEntities[item.interactorIndex];
					interactorToNearbyInteractableMap.Add(key, item.interactData);
				}
			}
		}

		[BurstCompile]
		[WithAll(new Type[] { typeof(Simulate) })]
		private struct FindClosestValidInteractableJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

					public ComponentTypeHandle<InteractorCD> __Interaction_InteractorCD_RW_ComponentTypeHandle;

					public ComponentTypeHandle<NextInteractorCD> __Interaction_NextInteractorCD_RW_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<AnimationOrientationCD> __AnimationOrientationCD_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<FactionCD> __FactionCD_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<PlayerGhost> __PlayerGhost_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<ClientInput> __ClientInput_RO_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
						__Interaction_InteractorCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<InteractorCD>();
						__Interaction_NextInteractorCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<NextInteractorCD>();
						__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
						__AnimationOrientationCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<AnimationOrientationCD>(isReadOnly: true);
						__FactionCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<FactionCD>(isReadOnly: true);
						__PlayerGhost_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PlayerGhost>(isReadOnly: true);
						__ClientInput_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ClientInput>(isReadOnly: true);
					}

					public void Update(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle.Update(ref state);
						__Interaction_InteractorCD_RW_ComponentTypeHandle.Update(ref state);
						__Interaction_NextInteractorCD_RW_ComponentTypeHandle.Update(ref state);
						__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
						__AnimationOrientationCD_RO_ComponentTypeHandle.Update(ref state);
						__FactionCD_RO_ComponentTypeHandle.Update(ref state);
						__PlayerGhost_RO_ComponentTypeHandle.Update(ref state);
						__ClientInput_RO_ComponentTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<LocalTransform>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<AnimationOrientationCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<FactionCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<PlayerGhost>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<ClientInput>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<InteractorCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<NextInteractorCD>();
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
				public void Run(ref FindClosestValidInteractableJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref FindClosestValidInteractableJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref FindClosestValidInteractableJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref FindClosestValidInteractableJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref FindClosestValidInteractableJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref FindClosestValidInteractableJob job, EntityManager entityManager)
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
			public NativeParallelMultiHashMap<Entity, NearbyInteractData>.ReadOnly interactorToNearbyInteractableMap;

			[ReadOnly]
			public ComponentLookup<SurfacePriorityCD> surfacePriorityLookup;

			[ReadOnly]
			public ComponentLookup<ClaimedByPlayerGuidCD> claimedByPlayerGUIDLookup;

			[ReadOnly]
			public TileAccessor tileAccessor;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			private void Execute(Entity entity, ref InteractorCD interactorCD, ref NextInteractorCD nextInteractorCD, in LocalTransform localTransform, in AnimationOrientationCD animationOrientationCD, in FactionCD factionCD, in PlayerGhost playerGhost, in ClientInput clientInput)
			{
				Entity entity2 = Entity.Null;
				float num = float.MinValue;
				float3 interactPoint = GetInteractPoint(localTransform.Position, animationOrientationCD.facingDirection.isH);
				float3 playerTargetingDirection = math.normalizesafe(clientInput.targetingDirection).ToFloat3();
				if (interactorToNearbyInteractableMap.TryGetFirstValue(entity, out var item, out var it))
				{
					do
					{
						FactionID requiredFactionToInteract = item.requiredFactionToInteract;
						if ((requiredFactionToInteract == FactionID.None || factionCD.faction == requiredFactionToInteract || factionCD.HasBefriendedFaction(new FactionCD
						{
							originalFaction = requiredFactionToInteract,
							faction = requiredFactionToInteract
						})) && (!surfacePriorityLookup.TryGetComponent(item.entity, out var componentData) || tileAccessor.GetTop(item.position.RoundToInt2()).tileType.GetSurfacePriorityFromJob() <= componentData.Value) && (!item.allowToUseOnlyWhenClaimed || EntityMonoBehaviour.IsClaimedByPlayer(item.entity, in playerGhost, claimedByPlayerGUIDLookup)))
						{
							(float3, float) currentBestInteractingPointWithWeight = GetCurrentBestInteractingPointWithWeight(in item.interactingPointsData, item.direction, item.position, interactPoint, playerTargetingDirection, item.weightMultiplier);
							float3 item2 = currentBestInteractingPointWithWeight.Item1;
							float item3 = currentBestInteractingPointWithWeight.Item2;
							float3 vectorFromPlayer = math.normalizesafe(item2 - interactPoint);
							if ((item.ignorePlayerDirection || IsPlayerLookingAtUs(vectorFromPlayer, playerTargetingDirection)) && (!(entity2 != Entity.Null) || num < item3))
							{
								entity2 = item.entity;
								num = item3;
							}
						}
					}
					while (interactorToNearbyInteractableMap.TryGetNextValue(out item, ref it));
				}
				nextInteractorCD.nextClosestInteractable = entity2;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private static float3 GetInteractPoint(float3 playerPosition, bool isFacingHorizontal)
			{
				float3 float5 = new float3(0f, 0f, 0.25f);
				return playerPosition + (isFacingHorizontal ? float5 : float3.zero);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private static (float3, float) GetCurrentBestInteractingPointWithWeight(in BlobAssetReference<InteractablePointOffsetsData> interactingPoints, Direction.Id direction, float3 interactablePosition, float3 playerInteractionPoint, float3 playerTargetingDirection, float weightMultiplier)
			{
				float3 item = float3.zero;
				float num = float.MinValue;
				ref BlobArray<float3> interactablePointsInDirection = ref interactingPoints.Value.GetInteractablePointsInDirection(direction);
				int length = interactablePointsInDirection.Length;
				for (int i = 0; i < length; i++)
				{
					float3 float5 = interactablePosition + interactablePointsInDirection[i];
					float weightValue = GetWeightValue(float5 - playerInteractionPoint, playerTargetingDirection, weightMultiplier);
					if (!(weightValue < num))
					{
						num = weightValue;
						item = float5;
					}
				}
				return (item, num);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private static float GetWeightValue(float3 vectorFromPlayer, float3 playerTargetingDirection, float weightMultiplier)
			{
				float angleDeg = GetAngleDeg(vectorFromPlayer, playerTargetingDirection);
				float num = math.max(0f, (90f - angleDeg) / 90f) * 0.7f;
				float num2 = math.max(0f, (5f - math.length(vectorFromPlayer)) / 5f) * 0.3f;
				return (num + num2) * weightMultiplier;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private static float GetAngleDeg(float3 vectorFromPlayer, float3 playerTargetingDirection)
			{
				return Vector3.Angle(vectorFromPlayer, playerTargetingDirection);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private static bool IsPlayerLookingAtUs(float3 vectorFromPlayer, float3 playerTargetingDirection)
			{
				return (double)math.dot(vectorFromPlayer, playerTargetingDirection) > 0.342;
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Interaction_InteractorCD_RW_ComponentTypeHandle);
				IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Interaction_NextInteractorCD_RW_ComponentTypeHandle);
				IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__AnimationOrientationCD_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr6 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__FactionCD_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr7 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__PlayerGhost_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr8 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__ClientInput_RO_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
						Execute(entity, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<InteractorCD>(nativeArrayPtr2, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<NextInteractorCD>(nativeArrayPtr3, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr4, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationOrientationCD>(nativeArrayPtr5, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<FactionCD>(nativeArrayPtr6, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerGhost>(nativeArrayPtr7, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr8, i));
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
							Execute(entity2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<InteractorCD>(nativeArrayPtr2, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<NextInteractorCD>(nativeArrayPtr3, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr4, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationOrientationCD>(nativeArrayPtr5, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<FactionCD>(nativeArrayPtr6, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerGhost>(nativeArrayPtr7, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr8, nextRangeBegin));
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
						Execute(entity3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<InteractorCD>(nativeArrayPtr2, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<NextInteractorCD>(nativeArrayPtr3, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr4, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationOrientationCD>(nativeArrayPtr5, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<FactionCD>(nativeArrayPtr6, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerGhost>(nativeArrayPtr7, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr8, j));
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
						Execute(entity4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<InteractorCD>(nativeArrayPtr2, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<NextInteractorCD>(nativeArrayPtr3, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr4, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationOrientationCD>(nativeArrayPtr5, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<FactionCD>(nativeArrayPtr6, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerGhost>(nativeArrayPtr7, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr8, k));
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
		[WithOptions(EntityQueryOptions.IgnoreComponentEnabledState)]
		private struct ChangeSelectedInteractableJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

					public ComponentTypeHandle<InteractorCD> __Interaction_InteractorCD_RW_ComponentTypeHandle;

					public ComponentTypeHandle<NextInteractorCD> __Interaction_NextInteractorCD_RW_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
						__Interaction_InteractorCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<InteractorCD>();
						__Interaction_NextInteractorCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<NextInteractorCD>();
					}

					public void Update(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle.Update(ref state);
						__Interaction_InteractorCD_RW_ComponentTypeHandle.Update(ref state);
						__Interaction_NextInteractorCD_RW_ComponentTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAllRW<InteractorCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<NextInteractorCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IgnoreComponentEnabledState);
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
				public void Run(ref ChangeSelectedInteractableJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref ChangeSelectedInteractableJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref ChangeSelectedInteractableJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref ChangeSelectedInteractableJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref ChangeSelectedInteractableJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref ChangeSelectedInteractableJob job, EntityManager entityManager)
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

			public BufferLookup<TriggerExitInteractionBuffer> triggerExitInteractionBufferLookup;

			[ReadOnly]
			public ComponentLookup<Simulate> simulateLookup;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			private void Execute(Entity entity, ref InteractorCD interactorCD, ref NextInteractorCD nextInteractorCD)
			{
				if (!simulateLookup.IsComponentEnabled(entity))
				{
					return;
				}
				if (interactorCD.currentClosestInteractable == nextInteractorCD.nextClosestInteractable)
				{
					nextInteractorCD.nextClosestInteractable = Entity.Null;
					return;
				}
				if (interactorCD.currentClosestInteractable != Entity.Null && triggerExitInteractionBufferLookup.TryGetBuffer(interactorCD.currentClosestInteractable, out var bufferData))
				{
					bufferData.Add(new TriggerExitInteractionBuffer
					{
						interactorEntity = entity
					});
				}
				interactorCD.currentClosestInteractable = nextInteractorCD.nextClosestInteractable;
				nextInteractorCD.nextClosestInteractable = Entity.Null;
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Interaction_InteractorCD_RW_ComponentTypeHandle);
				IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Interaction_NextInteractorCD_RW_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
						Execute(entity, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<InteractorCD>(nativeArrayPtr2, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<NextInteractorCD>(nativeArrayPtr3, i));
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
							Execute(entity2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<InteractorCD>(nativeArrayPtr2, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<NextInteractorCD>(nativeArrayPtr3, nextRangeBegin));
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
						Execute(entity3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<InteractorCD>(nativeArrayPtr2, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<NextInteractorCD>(nativeArrayPtr3, j));
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
						Execute(entity4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<InteractorCD>(nativeArrayPtr2, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<NextInteractorCD>(nativeArrayPtr3, k));
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
			public ComponentLookup<DirectionCD> __DirectionCD_RO_ComponentLookup;

			public RegisterNearbyInteractableToInteractorJob.InternalCompilerQueryAndHandleData __Interaction_UpdateSelectedInteractableSystem_RegisterNearbyInteractableToInteractorJob_WithDefaultQuery_JobEntityTypeHandle;

			[ReadOnly]
			public ComponentLookup<ClaimedByPlayerGuidCD> __ClaimedByPlayerGuidCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<SurfacePriorityCD> __SurfacePriorityCD_RO_ComponentLookup;

			public FindClosestValidInteractableJob.InternalCompilerQueryAndHandleData __Interaction_UpdateSelectedInteractableSystem_FindClosestValidInteractableJob_WithDefaultQuery_JobEntityTypeHandle;

			public BufferLookup<TriggerExitInteractionBuffer> __Interaction_TriggerExitInteractionBuffer_RW_BufferLookup;

			[ReadOnly]
			public ComponentLookup<Simulate> __Unity_Entities_Simulate_RO_ComponentLookup;

			public ChangeSelectedInteractableJob.InternalCompilerQueryAndHandleData __Interaction_UpdateSelectedInteractableSystem_ChangeSelectedInteractableJob_WithDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__DirectionCD_RO_ComponentLookup = state.GetComponentLookup<DirectionCD>(isReadOnly: true);
				__Interaction_UpdateSelectedInteractableSystem_RegisterNearbyInteractableToInteractorJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
				__ClaimedByPlayerGuidCD_RO_ComponentLookup = state.GetComponentLookup<ClaimedByPlayerGuidCD>(isReadOnly: true);
				__SurfacePriorityCD_RO_ComponentLookup = state.GetComponentLookup<SurfacePriorityCD>(isReadOnly: true);
				__Interaction_UpdateSelectedInteractableSystem_FindClosestValidInteractableJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
				__Interaction_TriggerExitInteractionBuffer_RW_BufferLookup = state.GetBufferLookup<TriggerExitInteractionBuffer>();
				__Unity_Entities_Simulate_RO_ComponentLookup = state.GetComponentLookup<Simulate>(isReadOnly: true);
				__Interaction_UpdateSelectedInteractableSystem_ChangeSelectedInteractableJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void __codegen__OnUpdate_00000153_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnUpdate_00000153_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00000153_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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
		internal delegate void __codegen__OnStartRunning_00000154_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnStartRunning_00000154_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStartRunning_00000154_0024PostfixBurstDelegate>(__codegen__OnStartRunning).Value;
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

		private TileAccessor _tileAccessor;

		private TypeHandle __TypeHandle;

		private EntityQuery __query_845845972_0;

		[BurstCompile]
		public void OnStartRunning(ref SystemState state)
		{
			_tileAccessor = new TileAccessor(ref state);
		}

		public void OnStopRunning(ref SystemState state)
		{
		}

		[BurstCompile]
		public void OnUpdate(ref SystemState state)
		{
			_tileAccessor.Update(ref state);
			NativeParallelMultiHashMap<Entity, NearbyInteractData> interactorToNearbyInteractableMap = new NativeParallelMultiHashMap<Entity, NearbyInteractData>(32, state.WorldUpdateAllocator);
			EntityQuery _query_845845972_ = __query_845845972_0;
			JobHandle outJobHandle;
			NativeList<LocalTransform> interactorTransforms = _query_845845972_.ToComponentDataListAsync<LocalTransform>(state.WorldUpdateAllocator, state.Dependency, out outJobHandle);
			JobHandle outJobHandle2;
			NativeList<Entity> interactorEntities = _query_845845972_.ToEntityListAsync(state.WorldUpdateAllocator, state.Dependency, out outJobHandle2);
			state.Dependency = JobHandle.CombineDependencies(outJobHandle, outJobHandle2);
			NativeQueue<NearbyInteract> nearbyInteracts = new NativeQueue<NearbyInteract>(state.WorldUpdateAllocator);
			state.Dependency = __ScheduleViaJobChunkExtension_0(new RegisterNearbyInteractableToInteractorJob
			{
				interactorTransforms = interactorTransforms,
				directionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DirectionCD_RO_ComponentLookup, ref state),
				nearbyInteracts = nearbyInteracts.AsParallelWriter()
			}, __TypeHandle.__Interaction_UpdateSelectedInteractableSystem_RegisterNearbyInteractableToInteractorJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
			state.Dependency = IJobExtensions.Schedule(new FillHashMapJob
			{
				interactorEntities = interactorEntities,
				nearbyInteracts = nearbyInteracts,
				interactorToNearbyInteractableMap = interactorToNearbyInteractableMap
			}, state.Dependency);
			state.Dependency = __ScheduleViaJobChunkExtension_1(new FindClosestValidInteractableJob
			{
				interactorToNearbyInteractableMap = interactorToNearbyInteractableMap.AsReadOnly(),
				tileAccessor = _tileAccessor,
				claimedByPlayerGUIDLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ClaimedByPlayerGuidCD_RO_ComponentLookup, ref state),
				surfacePriorityLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__SurfacePriorityCD_RO_ComponentLookup, ref state)
			}, __TypeHandle.__Interaction_UpdateSelectedInteractableSystem_FindClosestValidInteractableJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
			state.Dependency = __ScheduleViaJobChunkExtension_2(new ChangeSelectedInteractableJob
			{
				triggerExitInteractionBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__Interaction_TriggerExitInteractionBuffer_RW_BufferLookup, ref state),
				simulateLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Entities_Simulate_RO_ComponentLookup, ref state)
			}, __TypeHandle.__Interaction_UpdateSelectedInteractableSystem_ChangeSelectedInteractableJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_0(RegisterNearbyInteractableToInteractorJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__Interaction_UpdateSelectedInteractableSystem_RegisterNearbyInteractableToInteractorJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__Interaction_UpdateSelectedInteractableSystem_RegisterNearbyInteractableToInteractorJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__Interaction_UpdateSelectedInteractableSystem_RegisterNearbyInteractableToInteractorJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__Interaction_UpdateSelectedInteractableSystem_RegisterNearbyInteractableToInteractorJob_WithDefaultQuery_JobEntityTypeHandle.ScheduleParallel(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_1(FindClosestValidInteractableJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__Interaction_UpdateSelectedInteractableSystem_FindClosestValidInteractableJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__Interaction_UpdateSelectedInteractableSystem_FindClosestValidInteractableJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__Interaction_UpdateSelectedInteractableSystem_FindClosestValidInteractableJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__Interaction_UpdateSelectedInteractableSystem_FindClosestValidInteractableJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_2(ChangeSelectedInteractableJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__Interaction_UpdateSelectedInteractableSystem_ChangeSelectedInteractableJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__Interaction_UpdateSelectedInteractableSystem_ChangeSelectedInteractableJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__Interaction_UpdateSelectedInteractableSystem_ChangeSelectedInteractableJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__Interaction_UpdateSelectedInteractableSystem_ChangeSelectedInteractableJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			__query_845845972_0 = entityQueryBuilder.WithAll<LocalTransform, InteractorCD, Simulate>().Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder.Dispose();
		}

		public void OnCreateForCompiler(ref SystemState state)
		{
			__AssignQueries(ref state);
			__TypeHandle.__AssignHandles(ref state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			__codegen__OnUpdate_00000153_0024BurstDirectCall.Invoke(self, state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
		{
			__codegen__OnStartRunning_00000154_0024BurstDirectCall.Invoke(self, state);
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
		{
			((UpdateSelectedInteractableSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			((UpdateSelectedInteractableSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((UpdateSelectedInteractableSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnStartRunning_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((UpdateSelectedInteractableSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
		}
	}
}
