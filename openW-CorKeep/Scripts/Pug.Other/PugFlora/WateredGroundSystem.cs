using System;
using System.Runtime.CompilerServices;
using PugTilemap;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine.Scripting;

namespace PugFlora
{
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
	public class WateredGroundSystem : PugSimulationSystemBase
	{
		[NoAlias]
		[BurstCompile]
		private struct WateredGroundSystem_73B0BF41_LambdaJob_0_Job : IJobChunk
		{
			public float deltaTime;

			public EntityCommandBuffer ecb;

			public NativeParallelHashSet<int2> updatedPositionsLocal;

			public NativeParallelHashSet<int2> usersPositionsLocal;

			public Entity tileUpdateBufferSingletonLocal;

			[ReadOnly]
			public EntityTypeHandle __entityTypeHandle;

			public ComponentTypeHandle<WateredGroundTimerCD> __timerTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void OriginalLambdaBody(Entity entity, [NoAlias] ref WateredGroundTimerCD timer)
			{
				if (updatedPositionsLocal.Contains(timer.position))
				{
					ecb.DestroyEntity(entity);
					return;
				}
				if (usersPositionsLocal.Contains(timer.position))
				{
					timer.timer = 600f;
					return;
				}
				timer.timer -= deltaTime;
				if (timer.timer <= 0f)
				{
					ecb.AppendToBuffer(tileUpdateBufferSingletonLocal, new TileUpdateBuffer
					{
						command = TileUpdateBuffer.Command.Remove,
						position = timer.position,
						tile = new TileCD
						{
							tileType = TileType.wateredGround
						}
					});
					ecb.DestroyEntity(entity);
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __timerTypeHandle);
				int count = chunk.Count;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<WateredGroundTimerCD>(nativeArrayPtr2, i));
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
							OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<WateredGroundTimerCD>(nativeArrayPtr2, j));
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<WateredGroundTimerCD>(nativeArrayPtr2, k));
					}
					num >>= 1;
				}
				num = chunkEnabledMask.ULong1;
				for (int l = 64; l < count; l++)
				{
					if ((num & 1) != 0L)
					{
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<WateredGroundTimerCD>(nativeArrayPtr2, l));
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
		private struct WateredGroundSystem_73B0BF41_LambdaJob_1_Job : IJob
		{
			public EntityCommandBuffer ecb;

			[ReadOnly]
			public TileAccessor tileLookup;

			public NativeParallelHashSet<int2> updatedPositionsLocal;

			public EntityArchetype timerArchetypeLocal;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void OriginalLambdaBody()
			{
				NativeArray<int2> nativeArray = updatedPositionsLocal.ToNativeArray(Allocator.Temp);
				for (int i = 0; i < nativeArray.Length; i++)
				{
					if (tileLookup.HasType(nativeArray[i], TileType.wateredGround))
					{
						Entity e = ecb.CreateEntity(timerArchetypeLocal);
						ecb.SetComponent(e, new WateredGroundTimerCD
						{
							position = nativeArray[i],
							timer = 600f
						});
					}
				}
			}

			public void Execute()
			{
				OriginalLambdaBody();
			}
		}

		private struct TypeHandle
		{
			[ReadOnly]
			public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

			public ComponentTypeHandle<WateredGroundTimerCD> __PugFlora_WateredGroundTimerCD_RW_ComponentTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
				__PugFlora_WateredGroundTimerCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<WateredGroundTimerCD>();
			}
		}

		private WaterGroundRegisterSystem _waterGroundRegisterSystem;

		private EntityArchetype timerArchetype;

		private TypeHandle __TypeHandle;

		private EntityQuery __query_1626299308_0;

		private EntityQuery __query_1626299308_1;

		[Preserve]
		protected override void OnCreate()
		{
			NeedTileUpdateBuffer();
			_waterGroundRegisterSystem = base.World.GetExistingSystemManaged<WaterGroundRegisterSystem>();
			timerArchetype = base.EntityManager.CreateArchetype(typeof(WateredGroundTimerCD));
			base.OnCreate();
		}

		[Preserve]
		protected override void OnUpdate()
		{
			float deltaTime = base.CheckedStateRef.WorldUnmanaged.Time.DeltaTime;
			EntityCommandBuffer ecb = CreateCommandBuffer();
			TileAccessor tileLookup = CreateTileAccessor();
			NativeParallelHashSet<int2> updatedPositions = _waterGroundRegisterSystem.updatedPositions;
			NativeParallelHashSet<int2> positions = __query_1626299308_1.GetSingleton<WateredGroundUserAddedPositionsRegistry>().Positions;
			Entity tileUpdateBufferSingletonLocal = tileUpdateBufferSingletonEntity;
			EntityArchetype timerArchetypeLocal = timerArchetype;
			WateredGroundSystem_73B0BF41_LambdaJob_0_Execute(deltaTime, ecb, updatedPositions, positions, tileUpdateBufferSingletonLocal);
			WateredGroundSystem_73B0BF41_LambdaJob_1_Execute(ecb, tileLookup, updatedPositions, timerArchetypeLocal);
			base.OnUpdate();
		}

		private void WateredGroundSystem_73B0BF41_LambdaJob_0_Execute(float deltaTime, EntityCommandBuffer ecb, NativeParallelHashSet<int2> updatedPositionsLocal, NativeParallelHashSet<int2> usersPositionsLocal, Entity tileUpdateBufferSingletonLocal)
		{
			__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
			__TypeHandle.__PugFlora_WateredGroundTimerCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
			WateredGroundSystem_73B0BF41_LambdaJob_0_Job jobData = new WateredGroundSystem_73B0BF41_LambdaJob_0_Job
			{
				deltaTime = deltaTime,
				ecb = ecb,
				updatedPositionsLocal = updatedPositionsLocal,
				usersPositionsLocal = usersPositionsLocal,
				tileUpdateBufferSingletonLocal = tileUpdateBufferSingletonLocal,
				__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
				__timerTypeHandle = __TypeHandle.__PugFlora_WateredGroundTimerCD_RW_ComponentTypeHandle
			};
			base.CheckedStateRef.Dependency = InternalCompilerInterface.JobChunkInterface.Schedule(jobData, __query_1626299308_0, base.CheckedStateRef.Dependency);
		}

		private void WateredGroundSystem_73B0BF41_LambdaJob_1_Execute(EntityCommandBuffer ecb, TileAccessor tileLookup, NativeParallelHashSet<int2> updatedPositionsLocal, EntityArchetype timerArchetypeLocal)
		{
			WateredGroundSystem_73B0BF41_LambdaJob_1_Job jobData = new WateredGroundSystem_73B0BF41_LambdaJob_1_Job
			{
				ecb = ecb,
				tileLookup = tileLookup,
				updatedPositionsLocal = updatedPositionsLocal,
				timerArchetypeLocal = timerArchetypeLocal
			};
			base.CheckedStateRef.Dependency = IJobExtensions.Schedule(jobData, base.CheckedStateRef.Dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAllRW<WateredGroundTimerCD>();
			__query_1626299308_0 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<WateredGroundUserAddedPositionsRegistry>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1626299308_1 = entityQueryBuilder2.Build(ref state);
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
		public WateredGroundSystem()
		{
		}
	}
}
