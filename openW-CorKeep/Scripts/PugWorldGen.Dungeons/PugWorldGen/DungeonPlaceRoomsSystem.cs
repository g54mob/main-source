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
using UnityEngine;
using UnityEngine.Scripting;

namespace PugWorldGen
{
	[WorldSystemFilter(WorldSystemFilterFlags.Editor | WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
	[UpdateInGroup(typeof(SimulationSystemGroup))]
	[UpdateAfter(typeof(DungeonAssignSeedSystem))]
	public class DungeonPlaceRoomsSystem : PugSimulationSystemBase
	{
		[NoAlias]
		[BurstCompile]
		private struct DungeonPlaceRoomsSystem_390BA9F_LambdaJob_0_Job : IJobChunk
		{
			[ReadOnly]
			public EntityTypeHandle __entityTypeHandle;

			public BufferTypeHandle<DungeonRoomBuffer> __dungeonRoomBufferTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<LocalTransform> __transformTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<DungeonAreaCD> __dungeonAreaTypeHandle;

			public BufferTypeHandle<DungeonRoomPlacementBuffer> __roomPlacementBufferTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void OriginalLambdaBody(Entity entity, DynamicBuffer<DungeonRoomBuffer> dungeonRoomBuffer, [NoAlias] in LocalTransform transform, [NoAlias] in DungeonAreaCD dungeonArea, DynamicBuffer<DungeonRoomPlacementBuffer> roomPlacementBuffer)
			{
				int2 int5 = transform.Position.RoundToInt2();
				Unity.Mathematics.Random random = new Unity.Mathematics.Random(0xC4618866u ^ dungeonArea.seed);
				for (int i = 0; i < roomPlacementBuffer.Length; i++)
				{
					DungeonRoomPlacement config = roomPlacementBuffer[i].Value;
					switch (config.algorithm)
					{
					case RoomPlacementAlgorithm.Center:
					{
						int size2 = random.NextInt(config.size.min, config.size.max);
						if (!IsBlockedByCurrentRoom(config, int5, size2, 0, ref dungeonRoomBuffer))
						{
							PlaceRoom(int5, in config, int5, size2, entrance: false, ref dungeonRoomBuffer);
						}
						break;
					}
					case RoomPlacementAlgorithm.Entrance:
					{
						int num8 = random.NextInt(config.amount.min, config.amount.max);
						for (int n = 0; n < num8; n++)
						{
							int num9;
							for (num9 = 0; num9 < 100; num9++)
							{
								float num10 = random.NextFloat(config.angleMin, config.angleMax);
								if (config.alignAngleWithCoreRadial)
								{
									num10 += math.atan2(int5.y, int5.x);
								}
								float radiusIncludingShape2 = dungeonArea.GetRadiusIncludingShape(num10);
								int2 position2 = int5 + (int2)math.round(new float2(math.cos(num10), math.sin(num10)) * radiusIncludingShape2);
								int size3 = random.NextInt(config.size.min, config.size.max);
								if (!IsBlockedByCurrentRoom(config, position2, size3, 1, ref dungeonRoomBuffer))
								{
									PlaceRoom(int5, in config, position2, size3, entrance: true, ref dungeonRoomBuffer);
									break;
								}
							}
							if (num9 == 100)
							{
								break;
							}
						}
						break;
					}
					case RoomPlacementAlgorithm.Random:
					{
						int num5 = random.NextInt(config.amount.min, config.amount.max);
						for (int l = 0; l < num5; l++)
						{
							int m;
							for (m = 0; m < 100; m++)
							{
								float num6 = random.NextFloat(MathF.PI * 2f);
								float num7 = random.NextFloat(dungeonArea.GetRadiusIncludingShape(num6));
								int2 position = int5 + (int2)math.round(num7 * new float2(math.cos(num6), math.sin(num6)));
								int size = random.NextInt(config.size.min, config.size.max);
								if (!IsBlockedByCurrentRoom(config, position, size, 1, ref dungeonRoomBuffer))
								{
									PlaceRoom(int5, in config, position, size, entrance: false, ref dungeonRoomBuffer);
									break;
								}
							}
							if (m == 100)
							{
								break;
							}
						}
						break;
					}
					case RoomPlacementAlgorithm.FromOtherRooms:
					{
						int num = random.NextInt(config.amount.min, config.amount.max);
						if (dungeonRoomBuffer.Length == 0)
						{
							Debug.LogError("need at least one room to start from");
							return;
						}
						for (int j = 0; j < num; j++)
						{
							int2 int6 = default(int2);
							int num2 = 0;
							int k;
							for (k = 0; k < 100; k++)
							{
								int index = random.NextInt(dungeonRoomBuffer.Length);
								RoomCD room = dungeonRoomBuffer[index].room;
								float num3 = (config.fromExistingPerpendicular ? (MathF.PI / 2f * (float)random.NextInt(4)) : random.NextFloat(MathF.PI * 2f));
								num2 = random.NextInt(config.size.min, config.size.max + 1);
								int num4 = room.size + num2 + random.NextInt(config.fromExistingSpacing.min, config.fromExistingSpacing.max + 1);
								int6 = room.position + (int2)math.round(new float2(math.cos(num3), math.sin(num3)) * num4);
								float radiusIncludingShape = dungeonArea.GetRadiusIncludingShape(num3);
								if (!(math.distance(int5, int6) + math.length(num2) + (float)config.fromExistingSpacing.min > radiusIncludingShape) && !IsBlockedByCurrentRoom(config, int6, num2, config.fromExistingSpacing.min, ref dungeonRoomBuffer))
								{
									PlaceRoom(int5, in config, int6, num2, entrance: false, ref dungeonRoomBuffer);
									break;
								}
							}
							if (k == 100)
							{
								break;
							}
						}
						break;
					}
					}
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
				BufferAccessor<DungeonRoomBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __dungeonRoomBufferTypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __transformTypeHandle);
				IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __dungeonAreaTypeHandle);
				BufferAccessor<DungeonRoomPlacementBuffer> bufferAccessor2 = chunk.GetBufferAccessor(ref __roomPlacementBufferTypeHandle);
				int count = chunk.Count;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), bufferAccessor[i], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DungeonAreaCD>(nativeArrayPtr3, i), bufferAccessor2[i]);
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
							OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), bufferAccessor[j], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DungeonAreaCD>(nativeArrayPtr3, j), bufferAccessor2[j]);
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), bufferAccessor[k], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DungeonAreaCD>(nativeArrayPtr3, k), bufferAccessor2[k]);
					}
					num >>= 1;
				}
				num = chunkEnabledMask.ULong1;
				for (int l = 64; l < count; l++)
				{
					if ((num & 1) != 0L)
					{
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), bufferAccessor[l], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DungeonAreaCD>(nativeArrayPtr3, l), bufferAccessor2[l]);
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
			public BufferTypeHandle<DungeonRoomPlacementBuffer> __PugWorldGen_DungeonRoomPlacementBuffer_RO_BufferTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
				__PugWorldGen_DungeonRoomBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<DungeonRoomBuffer>();
				__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
				__PugWorldGen_DungeonAreaCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<DungeonAreaCD>(isReadOnly: true);
				__PugWorldGen_DungeonRoomPlacementBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<DungeonRoomPlacementBuffer>(isReadOnly: true);
			}
		}

		public const uint seedOffset = 3294726246u;

		private TypeHandle __TypeHandle;

		private EntityQuery __query_2048841916_0;

		[Preserve]
		protected override void OnUpdate()
		{
			DungeonPlaceRoomsSystem_390BA9F_LambdaJob_0_Execute();
			base.OnUpdate();
		}

		private static bool IsBlockedByCurrentRoom(DungeonRoomPlacement placement, int2 position, int size, int extraDist, ref DynamicBuffer<DungeonRoomBuffer> dungeonRoomBuffer)
		{
			for (int i = 0; i < dungeonRoomBuffer.Length; i++)
			{
				RoomCD room = dungeonRoomBuffer[i].room;
				if (!room.flags.Matches(RoomFlags.Fill) && !placement.canIntersectRooms.Matches(room.flags))
				{
					int num = size + room.size + extraDist;
					if (math.distancesq(position, room.position) < (float)(num * num))
					{
						return true;
					}
				}
			}
			return false;
		}

		private static void PlaceRoom(int2 dungeonCenter, in DungeonRoomPlacement config, int2 position, int size, bool entrance, ref DynamicBuffer<DungeonRoomBuffer> dungeonRoomBuffer)
		{
			if (math.distancesq(dungeonCenter, position) > 40000f)
			{
				Debug.LogError("not placing dungeon room too far from center");
				return;
			}
			RoomCD room = new RoomCD
			{
				position = position,
				size = size,
				flags = config.roomType
			};
			if (entrance)
			{
				room.flags |= RoomFlags.Entrance;
			}
			dungeonRoomBuffer.Add(new DungeonRoomBuffer
			{
				room = room,
				spawnTemplate = BlobAssetReference<SpawnTemplateBlob>.Null
			});
		}

		private void DungeonPlaceRoomsSystem_390BA9F_LambdaJob_0_Execute()
		{
			__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
			__TypeHandle.__PugWorldGen_DungeonRoomBuffer_RW_BufferTypeHandle.Update(ref base.CheckedStateRef);
			__TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
			__TypeHandle.__PugWorldGen_DungeonAreaCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
			__TypeHandle.__PugWorldGen_DungeonRoomPlacementBuffer_RO_BufferTypeHandle.Update(ref base.CheckedStateRef);
			DungeonPlaceRoomsSystem_390BA9F_LambdaJob_0_Job jobData = new DungeonPlaceRoomsSystem_390BA9F_LambdaJob_0_Job
			{
				__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
				__dungeonRoomBufferTypeHandle = __TypeHandle.__PugWorldGen_DungeonRoomBuffer_RW_BufferTypeHandle,
				__transformTypeHandle = __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle,
				__dungeonAreaTypeHandle = __TypeHandle.__PugWorldGen_DungeonAreaCD_RO_ComponentTypeHandle,
				__roomPlacementBufferTypeHandle = __TypeHandle.__PugWorldGen_DungeonRoomPlacementBuffer_RO_BufferTypeHandle
			};
			base.CheckedStateRef.Dependency = InternalCompilerInterface.JobChunkInterface.Schedule(jobData, __query_2048841916_0, base.CheckedStateRef.Dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<LocalTransform>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<DungeonAreaCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<DungeonRoomPlacementBuffer>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<DungeonGenerationInitializationCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<DungeonRoomBuffer>();
			_queryRequiredForUpdate = (__query_2048841916_0 = entityQueryBuilder2.Build(ref state));
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
		public DungeonPlaceRoomsSystem()
		{
		}
	}
}
