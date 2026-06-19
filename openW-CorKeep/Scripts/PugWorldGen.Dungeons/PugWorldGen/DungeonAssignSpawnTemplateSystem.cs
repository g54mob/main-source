using System;
using System.Runtime.CompilerServices;
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
	public class DungeonAssignSpawnTemplateSystem : PugSimulationSystemBase
	{
		[NoAlias]
		[BurstCompile]
		private struct DungeonAssignSpawnTemplateSystem_3B0088F6_LambdaJob_0_Job : IJobChunk
		{
			public BufferLookup<DungeonNodeSpawnTemplateBuffer> nodeSpawnTemplateBufferLookup;

			public BufferLookup<DungeonPathSpawnTemplateBuffer> pathSpawnTemplateBufferLookup;

			public BufferTypeHandle<DungeonRoomBuffer> __nodeBufferTypeHandle;

			public BufferTypeHandle<DungeonPathBuffer> __pathBufferTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<DungeonAreaCD> __dungeonAreaTypeHandle;

			public BufferTypeHandle<DungeonNodeTemplateBuffer> __nodeTemplateBufferTypeHandle;

			public BufferTypeHandle<DungeonPathTemplateBuffer> __pathTemplateBufferTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void OriginalLambdaBody(DynamicBuffer<DungeonRoomBuffer> nodeBuffer, DynamicBuffer<DungeonPathBuffer> pathBuffer, [NoAlias] in DungeonAreaCD dungeonArea, DynamicBuffer<DungeonNodeTemplateBuffer> nodeTemplateBuffer, DynamicBuffer<DungeonPathTemplateBuffer> pathTemplateBuffer)
			{
				Unity.Mathematics.Random random = new Unity.Mathematics.Random(dungeonArea.seed ^ 0x2CC571C7);
				for (int i = 0; i < nodeBuffer.Length; i++)
				{
					for (int j = 0; j < nodeTemplateBuffer.Length; j++)
					{
						DungeonNodeTemplateBuffer dungeonNodeTemplateBuffer = nodeTemplateBuffer[j];
						if (!nodeBuffer[i].room.flags.Matches(RoomFlags.CustomScene) && dungeonNodeTemplateBuffer.flags.Matches(nodeBuffer[i].room.flags) && nodeBuffer[i].room.size >= dungeonNodeTemplateBuffer.minimumSizeRequirement)
						{
							if (nodeSpawnTemplateBufferLookup.TryGetBuffer(dungeonNodeTemplateBuffer.spawnTemplateBufferEntity, out var bufferData) && bufferData.Length > 0)
							{
								nodeBuffer.ElementAt(i).spawnTemplate = bufferData[random.NextInt(bufferData.Length)].Value;
							}
							break;
						}
					}
				}
				for (int k = 0; k < pathBuffer.Length; k++)
				{
					for (int l = 0; l < pathTemplateBuffer.Length; l++)
					{
						DungeonPathTemplateBuffer dungeonPathTemplateBuffer = pathTemplateBuffer[l];
						if (dungeonPathTemplateBuffer.flags.MatchesAll(pathBuffer[k].path.flags) && pathBuffer[k].path.width >= (float)dungeonPathTemplateBuffer.minimumSizeRequirement)
						{
							if (pathSpawnTemplateBufferLookup.TryGetBuffer(dungeonPathTemplateBuffer.spawnTemplateBufferEntity, out var bufferData2) && bufferData2.Length > 0)
							{
								pathBuffer.ElementAt(k).spawnTemplate = bufferData2[random.NextInt(bufferData2.Length)].Value;
							}
							break;
						}
					}
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				BufferAccessor<DungeonRoomBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __nodeBufferTypeHandle);
				BufferAccessor<DungeonPathBuffer> bufferAccessor2 = chunk.GetBufferAccessor(ref __pathBufferTypeHandle);
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __dungeonAreaTypeHandle);
				BufferAccessor<DungeonNodeTemplateBuffer> bufferAccessor3 = chunk.GetBufferAccessor(ref __nodeTemplateBufferTypeHandle);
				BufferAccessor<DungeonPathTemplateBuffer> bufferAccessor4 = chunk.GetBufferAccessor(ref __pathTemplateBufferTypeHandle);
				int count = chunk.Count;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						OriginalLambdaBody(bufferAccessor[i], bufferAccessor2[i], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DungeonAreaCD>(nativeArrayPtr, i), bufferAccessor3[i], bufferAccessor4[i]);
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
							OriginalLambdaBody(bufferAccessor[j], bufferAccessor2[j], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DungeonAreaCD>(nativeArrayPtr, j), bufferAccessor3[j], bufferAccessor4[j]);
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
						OriginalLambdaBody(bufferAccessor[k], bufferAccessor2[k], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DungeonAreaCD>(nativeArrayPtr, k), bufferAccessor3[k], bufferAccessor4[k]);
					}
					num >>= 1;
				}
				num = chunkEnabledMask.ULong1;
				for (int l = 64; l < count; l++)
				{
					if ((num & 1) != 0L)
					{
						OriginalLambdaBody(bufferAccessor[l], bufferAccessor2[l], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DungeonAreaCD>(nativeArrayPtr, l), bufferAccessor3[l], bufferAccessor4[l]);
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
			public BufferTypeHandle<DungeonRoomBuffer> __PugWorldGen_DungeonRoomBuffer_RW_BufferTypeHandle;

			public BufferTypeHandle<DungeonPathBuffer> __PugWorldGen_DungeonPathBuffer_RW_BufferTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<DungeonAreaCD> __PugWorldGen_DungeonAreaCD_RO_ComponentTypeHandle;

			[ReadOnly]
			public BufferTypeHandle<DungeonNodeTemplateBuffer> __PugWorldGen_DungeonNodeTemplateBuffer_RO_BufferTypeHandle;

			[ReadOnly]
			public BufferTypeHandle<DungeonPathTemplateBuffer> __PugWorldGen_DungeonPathTemplateBuffer_RO_BufferTypeHandle;

			[ReadOnly]
			public BufferLookup<DungeonNodeSpawnTemplateBuffer> __PugWorldGen_DungeonNodeSpawnTemplateBuffer_RO_BufferLookup;

			[ReadOnly]
			public BufferLookup<DungeonPathSpawnTemplateBuffer> __PugWorldGen_DungeonPathSpawnTemplateBuffer_RO_BufferLookup;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__PugWorldGen_DungeonRoomBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<DungeonRoomBuffer>();
				__PugWorldGen_DungeonPathBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<DungeonPathBuffer>();
				__PugWorldGen_DungeonAreaCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<DungeonAreaCD>(isReadOnly: true);
				__PugWorldGen_DungeonNodeTemplateBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<DungeonNodeTemplateBuffer>(isReadOnly: true);
				__PugWorldGen_DungeonPathTemplateBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<DungeonPathTemplateBuffer>(isReadOnly: true);
				__PugWorldGen_DungeonNodeSpawnTemplateBuffer_RO_BufferLookup = state.GetBufferLookup<DungeonNodeSpawnTemplateBuffer>(isReadOnly: true);
				__PugWorldGen_DungeonPathSpawnTemplateBuffer_RO_BufferLookup = state.GetBufferLookup<DungeonPathSpawnTemplateBuffer>(isReadOnly: true);
			}
		}

		private const uint systemSeed = 751137223u;

		private TypeHandle __TypeHandle;

		private EntityQuery __query_1368842562_0;

		[Preserve]
		protected override void OnUpdate()
		{
			BufferLookup<DungeonNodeSpawnTemplateBuffer> bufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__PugWorldGen_DungeonNodeSpawnTemplateBuffer_RO_BufferLookup, ref base.CheckedStateRef);
			BufferLookup<DungeonPathSpawnTemplateBuffer> bufferLookup2 = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__PugWorldGen_DungeonPathSpawnTemplateBuffer_RO_BufferLookup, ref base.CheckedStateRef);
			DungeonAssignSpawnTemplateSystem_3B0088F6_LambdaJob_0_Execute(bufferLookup, bufferLookup2);
		}

		private void DungeonAssignSpawnTemplateSystem_3B0088F6_LambdaJob_0_Execute(BufferLookup<DungeonNodeSpawnTemplateBuffer> nodeSpawnTemplateBufferLookup, BufferLookup<DungeonPathSpawnTemplateBuffer> pathSpawnTemplateBufferLookup)
		{
			__TypeHandle.__PugWorldGen_DungeonRoomBuffer_RW_BufferTypeHandle.Update(ref base.CheckedStateRef);
			__TypeHandle.__PugWorldGen_DungeonPathBuffer_RW_BufferTypeHandle.Update(ref base.CheckedStateRef);
			__TypeHandle.__PugWorldGen_DungeonAreaCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
			__TypeHandle.__PugWorldGen_DungeonNodeTemplateBuffer_RO_BufferTypeHandle.Update(ref base.CheckedStateRef);
			__TypeHandle.__PugWorldGen_DungeonPathTemplateBuffer_RO_BufferTypeHandle.Update(ref base.CheckedStateRef);
			DungeonAssignSpawnTemplateSystem_3B0088F6_LambdaJob_0_Job jobData = new DungeonAssignSpawnTemplateSystem_3B0088F6_LambdaJob_0_Job
			{
				nodeSpawnTemplateBufferLookup = nodeSpawnTemplateBufferLookup,
				pathSpawnTemplateBufferLookup = pathSpawnTemplateBufferLookup,
				__nodeBufferTypeHandle = __TypeHandle.__PugWorldGen_DungeonRoomBuffer_RW_BufferTypeHandle,
				__pathBufferTypeHandle = __TypeHandle.__PugWorldGen_DungeonPathBuffer_RW_BufferTypeHandle,
				__dungeonAreaTypeHandle = __TypeHandle.__PugWorldGen_DungeonAreaCD_RO_ComponentTypeHandle,
				__nodeTemplateBufferTypeHandle = __TypeHandle.__PugWorldGen_DungeonNodeTemplateBuffer_RO_BufferTypeHandle,
				__pathTemplateBufferTypeHandle = __TypeHandle.__PugWorldGen_DungeonPathTemplateBuffer_RO_BufferTypeHandle
			};
			base.CheckedStateRef.Dependency = InternalCompilerInterface.JobChunkInterface.Schedule(jobData, __query_1368842562_0, base.CheckedStateRef.Dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<DungeonAreaCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<DungeonNodeTemplateBuffer>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<DungeonPathTemplateBuffer>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<DungeonGenerationInitializationCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<DungeonRoomBuffer>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<DungeonPathBuffer>();
			_queryRequiredForUpdate = (__query_1368842562_0 = entityQueryBuilder2.Build(ref state));
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
		public DungeonAssignSpawnTemplateSystem()
		{
		}
	}
}
