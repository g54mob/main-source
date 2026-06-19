using System;
using System.Runtime.CompilerServices;
using Pug.UnityExtensions;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine.Scripting;

namespace PugWorldGen
{
	[WorldSystemFilter(WorldSystemFilterFlags.Editor | WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
	[UpdateInGroup(typeof(SimulationSystemGroup))]
	[UpdateAfter(typeof(DungeonPlaceRoomsSystem))]
	[UpdateAfter(typeof(DungeonPlacePathsSystem))]
	[UpdateBefore(typeof(DungeonAssignSpawnTemplateSystem))]
	public class DungeonFillSystem : PugSimulationSystemBase
	{
		[NoAlias]
		[BurstCompile]
		private struct DungeonFillSystem_260EB06F_LambdaJob_0_Job : IJobChunk
		{
			[ReadOnly]
			public EntityTypeHandle __entityTypeHandle;

			public BufferTypeHandle<DungeonRoomBuffer> __roomBufferTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<LocalTransform> __transformTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<DungeonAreaCD> __dungeonAreaTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<DungeonFillCD> __dungeonFillTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void OriginalLambdaBody(Entity entity, DynamicBuffer<DungeonRoomBuffer> roomBuffer, [NoAlias] in LocalTransform transform, [NoAlias] in DungeonAreaCD dungeonArea, [NoAlias] in DungeonFillCD dungeonFill)
			{
				int2 position = transform.Position.RoundToInt2();
				NativeArray<DungeonRoomBuffer> nativeArray = roomBuffer.ToNativeArray(Allocator.Temp);
				if (!dungeonFill.defineShapeByRooms)
				{
					roomBuffer.ResizeUninitialized(roomBuffer.Length + 1);
					roomBuffer[0] = new DungeonRoomBuffer
					{
						room = new RoomCD
						{
							position = position,
							size = (int)math.ceil((float)dungeonArea.radius * (1f + dungeonArea.shapeAmp)),
							flags = RoomFlags.Fill
						}
					};
				}
				else if (dungeonFill.roomSize > 0f)
				{
					int num = 0;
					for (int i = 0; i < nativeArray.Length; i++)
					{
						if (!roomBuffer[i].room.flags.Matches(RoomFlags.Entrance))
						{
							num++;
						}
					}
					roomBuffer.ResizeUninitialized(roomBuffer.Length + num);
					int num2 = 0;
					for (int j = 0; j < nativeArray.Length; j++)
					{
						DungeonRoomBuffer value = nativeArray[j];
						if (!value.room.flags.Matches(RoomFlags.Entrance))
						{
							roomBuffer[num2] = value;
							ref RoomCD room = ref roomBuffer.ElementAt(num2).room;
							room.flags = RoomFlags.Fill;
							room.size = (int)math.ceil((float)room.size * (1f + dungeonFill.roomSize));
							num2++;
						}
					}
				}
				for (int k = 0; k < nativeArray.Length; k++)
				{
					roomBuffer[k + (roomBuffer.Length - nativeArray.Length)] = nativeArray[k];
				}
				nativeArray.Dispose();
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
				BufferAccessor<DungeonRoomBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __roomBufferTypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __transformTypeHandle);
				IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __dungeonAreaTypeHandle);
				IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __dungeonFillTypeHandle);
				int count = chunk.Count;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), bufferAccessor[i], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DungeonAreaCD>(nativeArrayPtr3, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DungeonFillCD>(nativeArrayPtr4, i));
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
							OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), bufferAccessor[j], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DungeonAreaCD>(nativeArrayPtr3, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DungeonFillCD>(nativeArrayPtr4, j));
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), bufferAccessor[k], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DungeonAreaCD>(nativeArrayPtr3, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DungeonFillCD>(nativeArrayPtr4, k));
					}
					num >>= 1;
				}
				num = chunkEnabledMask.ULong1;
				for (int l = 64; l < count; l++)
				{
					if ((num & 1) != 0L)
					{
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), bufferAccessor[l], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DungeonAreaCD>(nativeArrayPtr3, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DungeonFillCD>(nativeArrayPtr4, l));
					}
					num >>= 1;
				}
			}

			void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
			}
		}

		[NoAlias]
		[BurstCompile]
		private struct DungeonFillSystem_260EB06F_LambdaJob_1_Job : IJobChunk
		{
			[ReadOnly]
			public EntityTypeHandle __entityTypeHandle;

			public BufferTypeHandle<DungeonPathBuffer> __pathBufferTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<DungeonFillCD> __dungeonFillTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void OriginalLambdaBody(Entity entity, DynamicBuffer<DungeonPathBuffer> pathBuffer, [NoAlias] in DungeonFillCD dungeonFill)
			{
				NativeArray<DungeonPathBuffer> nativeArray = pathBuffer.ToNativeArray(Allocator.Temp);
				if (dungeonFill.defineShapeByRooms && dungeonFill.pathSize > 0f)
				{
					pathBuffer.ResizeUninitialized(pathBuffer.Length * 2);
					for (int i = 0; i < nativeArray.Length; i++)
					{
						pathBuffer[i] = nativeArray[i];
						ref PathCD path = ref pathBuffer.ElementAt(i).path;
						path.flags = RoomFlags.Fill;
						path.width = (int)math.ceil(path.width * (1f + dungeonFill.pathSize));
					}
				}
				for (int j = 0; j < nativeArray.Length; j++)
				{
					pathBuffer[j + (pathBuffer.Length - nativeArray.Length)] = nativeArray[j];
				}
				nativeArray.Dispose();
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
				BufferAccessor<DungeonPathBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __pathBufferTypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __dungeonFillTypeHandle);
				int count = chunk.Count;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), bufferAccessor[i], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DungeonFillCD>(nativeArrayPtr2, i));
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
							OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), bufferAccessor[j], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DungeonFillCD>(nativeArrayPtr2, j));
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), bufferAccessor[k], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DungeonFillCD>(nativeArrayPtr2, k));
					}
					num >>= 1;
				}
				num = chunkEnabledMask.ULong1;
				for (int l = 64; l < count; l++)
				{
					if ((num & 1) != 0L)
					{
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), bufferAccessor[l], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DungeonFillCD>(nativeArrayPtr2, l));
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

			[ReadOnly]
			public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<DungeonAreaCD> __PugWorldGen_DungeonAreaCD_RO_ComponentTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<DungeonFillCD> __PugWorldGen_DungeonFillCD_RO_ComponentTypeHandle;

			public BufferTypeHandle<DungeonPathBuffer> __PugWorldGen_DungeonPathBuffer_RW_BufferTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
				__PugWorldGen_DungeonRoomBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<DungeonRoomBuffer>();
				__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
				__PugWorldGen_DungeonAreaCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<DungeonAreaCD>(isReadOnly: true);
				__PugWorldGen_DungeonFillCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<DungeonFillCD>(isReadOnly: true);
				__PugWorldGen_DungeonPathBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<DungeonPathBuffer>();
			}
		}

		private TypeHandle __TypeHandle;

		private EntityQuery __query_2011188540_0;

		private EntityQuery __query_2011188540_1;

		[Preserve]
		protected override void OnCreate()
		{
			RequireForUpdate(GetEntityQuery(ComponentType.ReadOnly<DungeonAreaCD>(), ComponentType.ReadOnly<DungeonGenerationInitializationCD>()));
			base.OnCreate();
		}

		[Preserve]
		protected override void OnUpdate()
		{
			DungeonFillSystem_260EB06F_LambdaJob_0_Execute();
			DungeonFillSystem_260EB06F_LambdaJob_1_Execute();
			base.OnUpdate();
		}

		private void DungeonFillSystem_260EB06F_LambdaJob_0_Execute()
		{
			__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
			__TypeHandle.__PugWorldGen_DungeonRoomBuffer_RW_BufferTypeHandle.Update(ref base.CheckedStateRef);
			__TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
			__TypeHandle.__PugWorldGen_DungeonAreaCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
			__TypeHandle.__PugWorldGen_DungeonFillCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
			DungeonFillSystem_260EB06F_LambdaJob_0_Job jobData = new DungeonFillSystem_260EB06F_LambdaJob_0_Job
			{
				__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
				__roomBufferTypeHandle = __TypeHandle.__PugWorldGen_DungeonRoomBuffer_RW_BufferTypeHandle,
				__transformTypeHandle = __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle,
				__dungeonAreaTypeHandle = __TypeHandle.__PugWorldGen_DungeonAreaCD_RO_ComponentTypeHandle,
				__dungeonFillTypeHandle = __TypeHandle.__PugWorldGen_DungeonFillCD_RO_ComponentTypeHandle
			};
			base.CheckedStateRef.Dependency = InternalCompilerInterface.JobChunkInterface.Schedule(jobData, __query_2011188540_0, base.CheckedStateRef.Dependency);
		}

		private void DungeonFillSystem_260EB06F_LambdaJob_1_Execute()
		{
			__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
			__TypeHandle.__PugWorldGen_DungeonPathBuffer_RW_BufferTypeHandle.Update(ref base.CheckedStateRef);
			__TypeHandle.__PugWorldGen_DungeonFillCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
			DungeonFillSystem_260EB06F_LambdaJob_1_Job jobData = new DungeonFillSystem_260EB06F_LambdaJob_1_Job
			{
				__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
				__pathBufferTypeHandle = __TypeHandle.__PugWorldGen_DungeonPathBuffer_RW_BufferTypeHandle,
				__dungeonFillTypeHandle = __TypeHandle.__PugWorldGen_DungeonFillCD_RO_ComponentTypeHandle
			};
			base.CheckedStateRef.Dependency = InternalCompilerInterface.JobChunkInterface.Schedule(jobData, __query_2011188540_1, base.CheckedStateRef.Dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<LocalTransform>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<DungeonAreaCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<DungeonFillCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<DungeonGenerationInitializationCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<DungeonRoomBuffer>();
			__query_2011188540_0 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<DungeonFillCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<DungeonGenerationInitializationCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<DungeonPathBuffer>();
			__query_2011188540_1 = entityQueryBuilder2.Build(ref state);
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
		public DungeonFillSystem()
		{
		}
	}
}
