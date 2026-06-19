using System;
using System.Runtime.CompilerServices;
using Pug.UnityExtensions;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Scripting;

namespace PugWorldGen
{
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
	[UpdateInGroup(typeof(SimulationSystemGroup))]
	[UpdateAfter(typeof(DungeonPlaceRoomsSystem))]
	[UpdateAfter(typeof(DungeonPlacePathsSystem))]
	[UpdateAfter(typeof(DungeonFillSystem))]
	public class DungeonAddBlockedAreasSystem : PugSimulationSystemBase
	{
		[NoAlias]
		[BurstCompile]
		private struct DungeonAddBlockedAreasSystem_6014B7D5_LambdaJob_0_Job : IJobChunk
		{
			public EntityCommandBuffer ecb;

			public bool isPlaying;

			public EntityArchetype blockedAreaArchetypeLocal;

			public BufferLookup<BlockedSpawnAreaBuffer> blockedSpawnAreaBufferLookup;

			[ReadOnly]
			public EntityTypeHandle __entityTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<DungeonAreaCD> __dungeonAreaTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<SpawnAreaEntityRefCD> __spawnAreaEntityRefTypeHandle;

			public BufferTypeHandle<DungeonRoomBuffer> __roomBufferTypeHandle;

			public BufferTypeHandle<DungeonPathBuffer> __pathBufferTypeHandle;

			[ReadOnly]
			public ComponentLookup<DungeonFillCD> __PugWorldGen_DungeonFillCD_ComponentLookup;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void OriginalLambdaBody(Entity entity, [NoAlias] in DungeonAreaCD dungeonArea, [NoAlias] in SpawnAreaEntityRefCD spawnAreaEntityRef, DynamicBuffer<DungeonRoomBuffer> roomBuffer, DynamicBuffer<DungeonPathBuffer> pathBuffer)
			{
				if (!dungeonArea.blockSpawns || !isPlaying)
				{
					return;
				}
				DynamicBuffer<BlockedSpawnAreaBuffer> bufferData = default(DynamicBuffer<BlockedSpawnAreaBuffer>);
				bool flag = spawnAreaEntityRef.Value == Entity.Null || !blockedSpawnAreaBufferLookup.TryGetBuffer(spawnAreaEntityRef.Value, out bufferData);
				bool flag2 = false;
				if (__PugWorldGen_DungeonFillCD_ComponentLookup.HasComponent(entity))
				{
					DungeonFillCD dungeonFillCD = __PugWorldGen_DungeonFillCD_ComponentLookup[entity];
					flag2 = !dungeonFillCD.defineShapeByRooms || dungeonFillCD.roomSize > 0f;
				}
				for (int i = 0; i < roomBuffer.Length; i++)
				{
					if (!flag2 || roomBuffer[i].room.flags.Matches(RoomFlags.Fill))
					{
						float2 center = roomBuffer[i].room.position.ToFloat2();
						float radius = roomBuffer[i].room.size;
						if (flag)
						{
							Entity e = ecb.CreateEntity(blockedAreaArchetypeLocal);
							ecb.SetComponent(e, new BlockedSpawnAreaCD(center, radius));
						}
						else
						{
							bufferData.Add(new BlockedSpawnAreaBuffer(center, radius));
						}
					}
				}
				for (int j = 0; j < pathBuffer.Length; j++)
				{
					if (!flag2 || pathBuffer[j].path.flags.Matches(RoomFlags.Fill))
					{
						float2 center2 = (float2)(pathBuffer[j].path.from + pathBuffer[j].path.to) / 2f;
						float num = math.distance(pathBuffer[j].path.from, pathBuffer[j].path.to);
						if (flag)
						{
							Entity e2 = ecb.CreateEntity(blockedAreaArchetypeLocal);
							ecb.SetComponent(e2, new BlockedSpawnAreaCD(center2, num / 2f));
						}
						else
						{
							bufferData.Add(new BlockedSpawnAreaBuffer(center2, num / 2f));
						}
					}
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __dungeonAreaTypeHandle);
				IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __spawnAreaEntityRefTypeHandle);
				BufferAccessor<DungeonRoomBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __roomBufferTypeHandle);
				BufferAccessor<DungeonPathBuffer> bufferAccessor2 = chunk.GetBufferAccessor(ref __pathBufferTypeHandle);
				int count = chunk.Count;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DungeonAreaCD>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SpawnAreaEntityRefCD>(nativeArrayPtr3, i), bufferAccessor[i], bufferAccessor2[i]);
					}
					return;
				}
				if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
				{
					int j = 0;
					int nextRangeEnd = 0;
					while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out j, out nextRangeEnd))
					{
						for (; j < nextRangeEnd; j++)
						{
							OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DungeonAreaCD>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SpawnAreaEntityRefCD>(nativeArrayPtr3, j), bufferAccessor[j], bufferAccessor2[j]);
						}
					}
					return;
				}
				ulong num = chunkEnabledMask.ULong0;
				int num2 = math.min(64, count);
				for (int k = 0; k < num2; k++)
				{
					if ((num & 1) != 0L)
					{
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DungeonAreaCD>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SpawnAreaEntityRefCD>(nativeArrayPtr3, k), bufferAccessor[k], bufferAccessor2[k]);
					}
					num >>= 1;
				}
				num = chunkEnabledMask.ULong1;
				for (int l = 64; l < count; l++)
				{
					if ((num & 1) != 0L)
					{
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DungeonAreaCD>(nativeArrayPtr2, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SpawnAreaEntityRefCD>(nativeArrayPtr3, l), bufferAccessor[l], bufferAccessor2[l]);
					}
					num >>= 1;
				}
			}

			void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
			}
		}

		private struct TypeHandle
		{
			[ReadOnly]
			public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<DungeonAreaCD> __PugWorldGen_DungeonAreaCD_RO_ComponentTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<SpawnAreaEntityRefCD> __PugWorldGen_SpawnAreaEntityRefCD_RO_ComponentTypeHandle;

			[ReadOnly]
			public BufferTypeHandle<DungeonRoomBuffer> __PugWorldGen_DungeonRoomBuffer_RO_BufferTypeHandle;

			[ReadOnly]
			public BufferTypeHandle<DungeonPathBuffer> __PugWorldGen_DungeonPathBuffer_RO_BufferTypeHandle;

			[ReadOnly]
			public ComponentLookup<DungeonFillCD> __PugWorldGen_DungeonFillCD_RO_ComponentLookup;

			public BufferLookup<BlockedSpawnAreaBuffer> __BlockedSpawnAreaBuffer_RW_BufferLookup;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
				__PugWorldGen_DungeonAreaCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<DungeonAreaCD>(isReadOnly: true);
				__PugWorldGen_SpawnAreaEntityRefCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<SpawnAreaEntityRefCD>(isReadOnly: true);
				__PugWorldGen_DungeonRoomBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<DungeonRoomBuffer>(isReadOnly: true);
				__PugWorldGen_DungeonPathBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<DungeonPathBuffer>(isReadOnly: true);
				__PugWorldGen_DungeonFillCD_RO_ComponentLookup = state.GetComponentLookup<DungeonFillCD>(isReadOnly: true);
				__BlockedSpawnAreaBuffer_RW_BufferLookup = state.GetBufferLookup<BlockedSpawnAreaBuffer>();
			}
		}

		private EntityArchetype blockedAreaArchetype;

		private TypeHandle __TypeHandle;

		private EntityQuery __query_1683133662_0;

		[Preserve]
		protected override void OnCreate()
		{
			blockedAreaArchetype = base.EntityManager.CreateArchetype(typeof(BlockedSpawnAreaCD));
			base.OnCreate();
		}

		[Preserve]
		protected override void OnUpdate()
		{
			EntityCommandBuffer ecb = CreateCommandBuffer();
			bool isPlaying = Application.isPlaying;
			EntityArchetype blockedAreaArchetypeLocal = blockedAreaArchetype;
			BufferLookup<BlockedSpawnAreaBuffer> bufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__BlockedSpawnAreaBuffer_RW_BufferLookup, ref base.CheckedStateRef);
			DungeonAddBlockedAreasSystem_6014B7D5_LambdaJob_0_Execute(ecb, isPlaying, blockedAreaArchetypeLocal, bufferLookup);
			base.OnUpdate();
		}

		private void DungeonAddBlockedAreasSystem_6014B7D5_LambdaJob_0_Execute(EntityCommandBuffer ecb, bool isPlaying, EntityArchetype blockedAreaArchetypeLocal, BufferLookup<BlockedSpawnAreaBuffer> blockedSpawnAreaBufferLookup)
		{
			__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
			__TypeHandle.__PugWorldGen_DungeonAreaCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
			__TypeHandle.__PugWorldGen_SpawnAreaEntityRefCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
			__TypeHandle.__PugWorldGen_DungeonRoomBuffer_RO_BufferTypeHandle.Update(ref base.CheckedStateRef);
			__TypeHandle.__PugWorldGen_DungeonPathBuffer_RO_BufferTypeHandle.Update(ref base.CheckedStateRef);
			__TypeHandle.__PugWorldGen_DungeonFillCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
			DungeonAddBlockedAreasSystem_6014B7D5_LambdaJob_0_Job jobData = new DungeonAddBlockedAreasSystem_6014B7D5_LambdaJob_0_Job
			{
				ecb = ecb,
				isPlaying = isPlaying,
				blockedAreaArchetypeLocal = blockedAreaArchetypeLocal,
				blockedSpawnAreaBufferLookup = blockedSpawnAreaBufferLookup,
				__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
				__dungeonAreaTypeHandle = __TypeHandle.__PugWorldGen_DungeonAreaCD_RO_ComponentTypeHandle,
				__spawnAreaEntityRefTypeHandle = __TypeHandle.__PugWorldGen_SpawnAreaEntityRefCD_RO_ComponentTypeHandle,
				__roomBufferTypeHandle = __TypeHandle.__PugWorldGen_DungeonRoomBuffer_RO_BufferTypeHandle,
				__pathBufferTypeHandle = __TypeHandle.__PugWorldGen_DungeonPathBuffer_RO_BufferTypeHandle,
				__PugWorldGen_DungeonFillCD_ComponentLookup = __TypeHandle.__PugWorldGen_DungeonFillCD_RO_ComponentLookup
			};
			base.CheckedStateRef.Dependency = InternalCompilerInterface.JobChunkInterface.Schedule(jobData, __query_1683133662_0, base.CheckedStateRef.Dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<DungeonAreaCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<SpawnAreaEntityRefCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<DungeonRoomBuffer>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<DungeonPathBuffer>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<DungeonGenerationInitializationCD>();
			_queryRequiredForUpdate = (__query_1683133662_0 = entityQueryBuilder2.Build(ref state));
			entityQueryBuilder.Reset();
			entityQueryBuilder.Dispose();
		}

		protected override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			__AssignQueries(ref base.CheckedStateRef);
			__TypeHandle.__AssignHandles(ref base.CheckedStateRef);
		}

		[Preserve]
		public DungeonAddBlockedAreasSystem()
		{
		}
	}
}
