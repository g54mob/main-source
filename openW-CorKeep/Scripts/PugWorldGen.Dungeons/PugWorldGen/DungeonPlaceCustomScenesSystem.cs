using System;
using System.Runtime.CompilerServices;
using Pug.UnityExtensions;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using UnityEngine.Scripting;

namespace PugWorldGen
{
	[WorldSystemFilter(WorldSystemFilterFlags.Editor | WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
	[UpdateInGroup(typeof(SimulationSystemGroup))]
	[UpdateAfter(typeof(DungeonFillSystem))]
	[UpdateBefore(typeof(DungeonGenerateRoomsSystem))]
	public class DungeonPlaceCustomScenesSystem : PugSimulationSystemBase
	{
		[NoAlias]
		[BurstCompile]
		private struct DungeonPlaceCustomScenesSystem_76C49F49_LambdaJob_0_Job : IJobChunk
		{
			[ReadOnly]
			public EntityTypeHandle __entityTypeHandle;

			public BufferTypeHandle<DungeonRoomBuffer> __roomBufferTypeHandle;

			public BufferTypeHandle<DungeonCustomSceneGroupBuffer> __customSceneGroupBufferTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<DungeonAreaCD> __dungeonAreaTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void OriginalLambdaBody(Entity entity, DynamicBuffer<DungeonRoomBuffer> roomBuffer, DynamicBuffer<DungeonCustomSceneGroupBuffer> customSceneGroupBuffer, [NoAlias] in DungeonAreaCD dungeonArea)
			{
				if (roomBuffer.Length == 0)
				{
					return;
				}
				Unity.Mathematics.Random rng = new Unity.Mathematics.Random(dungeonArea.seed ^ 0x38D6F8D8);
				NativeArray<int> list = new NativeArray<int>(roomBuffer.Length, Allocator.Temp);
				for (int i = 0; i < list.Length; i++)
				{
					list[i] = i;
				}
				for (int j = 0; j < customSceneGroupBuffer.Length; j++)
				{
					DungeonCustomSceneGroupBuffer dungeonCustomSceneGroupBuffer = customSceneGroupBuffer[j];
					if (dungeonCustomSceneGroupBuffer.customScenes.Length == 0)
					{
						continue;
					}
					PugRandom.ShuffleListKindOfRandomly(ref list, ref rng);
					int num = rng.NextInt(dungeonCustomSceneGroupBuffer.minSpawns, dungeonCustomSceneGroupBuffer.maxSpawns + 1);
					int k = 0;
					for (int l = 0; l < num; l++)
					{
						for (; k < list.Length; k++)
						{
							RoomFlags flags = roomBuffer[list[k]].room.flags;
							if (!flags.Matches(RoomFlags.CustomScene | RoomFlags.Fill) && dungeonCustomSceneGroupBuffer.roomType.Matches(flags))
							{
								break;
							}
						}
						if (k == list.Length)
						{
							break;
						}
						int index = list[k];
						DungeonCustomScene dungeonCustomScene = dungeonCustomSceneGroupBuffer.customScenes[rng.NextInt(dungeonCustomSceneGroupBuffer.customScenes.Length)];
						roomBuffer.ElementAt(index).room.flags |= RoomFlags.CustomScene;
						roomBuffer.ElementAt(index).customSceneName = dungeonCustomScene.name;
						roomBuffer.ElementAt(index).spawnTemplate = BlobAssetReference<SpawnTemplateBlob>.Null;
					}
				}
				list.Dispose();
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
				BufferAccessor<DungeonRoomBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __roomBufferTypeHandle);
				BufferAccessor<DungeonCustomSceneGroupBuffer> bufferAccessor2 = chunk.GetBufferAccessor(ref __customSceneGroupBufferTypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __dungeonAreaTypeHandle);
				int count = chunk.Count;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), bufferAccessor[i], bufferAccessor2[i], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DungeonAreaCD>(nativeArrayPtr2, i));
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
							OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), bufferAccessor[j], bufferAccessor2[j], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DungeonAreaCD>(nativeArrayPtr2, j));
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), bufferAccessor[k], bufferAccessor2[k], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DungeonAreaCD>(nativeArrayPtr2, k));
					}
					num >>= 1;
				}
				num = chunkEnabledMask.ULong1;
				for (int l = 64; l < count; l++)
				{
					if ((num & 1) != 0L)
					{
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), bufferAccessor[l], bufferAccessor2[l], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DungeonAreaCD>(nativeArrayPtr2, l));
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

			public BufferTypeHandle<DungeonRoomBuffer> __PugWorldGen_DungeonRoomBuffer_RW_BufferTypeHandle;

			public BufferTypeHandle<DungeonCustomSceneGroupBuffer> __PugWorldGen_DungeonCustomSceneGroupBuffer_RW_BufferTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<DungeonAreaCD> __PugWorldGen_DungeonAreaCD_RO_ComponentTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
				__PugWorldGen_DungeonRoomBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<DungeonRoomBuffer>();
				__PugWorldGen_DungeonCustomSceneGroupBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<DungeonCustomSceneGroupBuffer>();
				__PugWorldGen_DungeonAreaCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<DungeonAreaCD>(isReadOnly: true);
			}
		}

		private const uint seed = 953612504u;

		private TypeHandle __TypeHandle;

		private EntityQuery __query_1391395639_0;

		[Preserve]
		protected override void OnUpdate()
		{
			DungeonPlaceCustomScenesSystem_76C49F49_LambdaJob_0_Execute();
			base.OnUpdate();
		}

		private void DungeonPlaceCustomScenesSystem_76C49F49_LambdaJob_0_Execute()
		{
			__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
			__TypeHandle.__PugWorldGen_DungeonRoomBuffer_RW_BufferTypeHandle.Update(ref base.CheckedStateRef);
			__TypeHandle.__PugWorldGen_DungeonCustomSceneGroupBuffer_RW_BufferTypeHandle.Update(ref base.CheckedStateRef);
			__TypeHandle.__PugWorldGen_DungeonAreaCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
			DungeonPlaceCustomScenesSystem_76C49F49_LambdaJob_0_Job jobData = new DungeonPlaceCustomScenesSystem_76C49F49_LambdaJob_0_Job
			{
				__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
				__roomBufferTypeHandle = __TypeHandle.__PugWorldGen_DungeonRoomBuffer_RW_BufferTypeHandle,
				__customSceneGroupBufferTypeHandle = __TypeHandle.__PugWorldGen_DungeonCustomSceneGroupBuffer_RW_BufferTypeHandle,
				__dungeonAreaTypeHandle = __TypeHandle.__PugWorldGen_DungeonAreaCD_RO_ComponentTypeHandle
			};
			base.CheckedStateRef.Dependency = InternalCompilerInterface.JobChunkInterface.Schedule(jobData, __query_1391395639_0, base.CheckedStateRef.Dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<DungeonAreaCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<DungeonGenerationInitializationCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<DungeonRoomBuffer>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<DungeonCustomSceneGroupBuffer>();
			_queryRequiredForUpdate = (__query_1391395639_0 = entityQueryBuilder2.Build(ref state));
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
		public DungeonPlaceCustomScenesSystem()
		{
		}
	}
}
