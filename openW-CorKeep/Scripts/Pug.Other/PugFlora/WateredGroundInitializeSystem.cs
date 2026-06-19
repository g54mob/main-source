using System;
using System.Runtime.CompilerServices;
using PugTilemap;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using UnityEngine.Scripting;

namespace PugFlora
{
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
	[UpdateInGroup(typeof(SimulationSystemGroup))]
	public class WateredGroundInitializeSystem : PugSimulationSystemBase
	{
		[NoAlias]
		[BurstCompile]
		private struct WateredGroundInitializeSystem_31257C11_LambdaJob_0_Job : IJobChunk
		{
			public NativeList<int2> wateredGroundPositionsLocal;

			[ReadOnly]
			public ComponentTypeHandle<SubMapCD> __submapTypeHandle;

			public BufferTypeHandle<SubMapLayerBuffer> __submapLayersTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void OriginalLambdaBody([NoAlias] in SubMapCD submap, DynamicBuffer<SubMapLayerBuffer> submapLayers)
			{
				DynamicBuffer<SubMapLayer> dynamicBuffer = submapLayers.Reinterpret<SubMapLayer>();
				for (int i = 0; i < dynamicBuffer.Length; i++)
				{
					if (dynamicBuffer[i].layer.tileType != TileType.wateredGround)
					{
						continue;
					}
					for (int j = 0; j < submap.height(); j++)
					{
						if (dynamicBuffer[i].GetRow(j) == 0L)
						{
							continue;
						}
						for (int k = 0; k < submap.width(); k++)
						{
							int2 int5 = new int2(k, j);
							if (dynamicBuffer[i].Get(int5))
							{
								wateredGroundPositionsLocal.Add(submap.position() + int5);
							}
						}
					}
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __submapTypeHandle);
				BufferAccessor<SubMapLayerBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __submapLayersTypeHandle);
				int count = chunk.Count;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						OriginalLambdaBody(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SubMapCD>(nativeArrayPtr, i), bufferAccessor[i]);
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
							OriginalLambdaBody(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SubMapCD>(nativeArrayPtr, j), bufferAccessor[j]);
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
						OriginalLambdaBody(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SubMapCD>(nativeArrayPtr, k), bufferAccessor[k]);
					}
					num >>= 1;
				}
				num = chunkEnabledMask.ULong1;
				for (int l = 64; l < count; l++)
				{
					if ((num & 1) != 0L)
					{
						OriginalLambdaBody(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SubMapCD>(nativeArrayPtr, l), bufferAccessor[l]);
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
			public ComponentTypeHandle<SubMapCD> __SubMapCD_RO_ComponentTypeHandle;

			[ReadOnly]
			public BufferTypeHandle<SubMapLayerBuffer> __SubMapLayerBuffer_RO_BufferTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__SubMapCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<SubMapCD>(isReadOnly: true);
				__SubMapLayerBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<SubMapLayerBuffer>(isReadOnly: true);
			}
		}

		private NativeList<int2> wateredGroundPositions;

		private TypeHandle __TypeHandle;

		private EntityQuery __query_1626299099_0;

		[Preserve]
		protected override void OnDestroy()
		{
			if (wateredGroundPositions.IsCreated)
			{
				wateredGroundPositions.Dispose();
				wateredGroundPositions = default(NativeList<int2>);
			}
			base.OnDestroy();
		}

		[Preserve]
		protected override void OnStartRunning()
		{
			wateredGroundPositions = new NativeList<int2>(Allocator.Persistent);
			base.OnStartRunning();
		}

		[Preserve]
		protected override void OnStopRunning()
		{
			base.Dependency.Complete();
			EntityArchetype archetype = base.EntityManager.CreateArchetype(typeof(WateredGroundTimerCD));
			using NativeArray<Entity> nativeArray = base.EntityManager.CreateEntity(archetype, wateredGroundPositions.Length, Allocator.Temp);
			for (int i = 0; i < nativeArray.Length; i++)
			{
				base.EntityManager.SetComponentData(nativeArray[i], new WateredGroundTimerCD
				{
					position = wateredGroundPositions[i],
					timer = 600f
				});
			}
			wateredGroundPositions.Dispose();
			wateredGroundPositions = default(NativeList<int2>);
			base.OnStopRunning();
		}

		[Preserve]
		protected override void OnUpdate()
		{
			NativeList<int2> wateredGroundPositionsLocal = wateredGroundPositions;
			WateredGroundInitializeSystem_31257C11_LambdaJob_0_Execute(wateredGroundPositionsLocal);
			base.Enabled = false;
			base.OnUpdate();
		}

		private void WateredGroundInitializeSystem_31257C11_LambdaJob_0_Execute(NativeList<int2> wateredGroundPositionsLocal)
		{
			__TypeHandle.__SubMapCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
			__TypeHandle.__SubMapLayerBuffer_RO_BufferTypeHandle.Update(ref base.CheckedStateRef);
			WateredGroundInitializeSystem_31257C11_LambdaJob_0_Job jobData = new WateredGroundInitializeSystem_31257C11_LambdaJob_0_Job
			{
				wateredGroundPositionsLocal = wateredGroundPositionsLocal,
				__submapTypeHandle = __TypeHandle.__SubMapCD_RO_ComponentTypeHandle,
				__submapLayersTypeHandle = __TypeHandle.__SubMapLayerBuffer_RO_BufferTypeHandle
			};
			base.CheckedStateRef.Dependency = InternalCompilerInterface.JobChunkInterface.Schedule(jobData, __query_1626299099_0, base.CheckedStateRef.Dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<SubMapCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<SubMapLayerBuffer>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeDisabledEntities);
			__query_1626299099_0 = entityQueryBuilder2.Build(ref state);
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
		public WateredGroundInitializeSystem()
		{
		}
	}
}
