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

[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(SimulationSystemGroup))]
[UpdateBefore(typeof(SendClientSubMapToPugMapSystem))]
public class SendPseudoTileToPugMapSystem : PugSimulationSystemBase
{
	[NoAlias]
	[BurstCompile]
	private struct SendPseudoTileToPugMapSystem_3AA9077B_LambdaJob_0_Job : IJobChunk
	{
		public EntityCommandBuffer ecb;

		public NativeParallelHashSet<SendClientSubMapToPugMapSystem.PositionAndTile> pseudoTileMapLocal;

		public NativeList<SendClientSubMapToPugMapSystem.TileUpdate> tileUpdatesLocal;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<TileCreatedFromEntityCD> __tileTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, [NoAlias] in TileCreatedFromEntityCD tile)
		{
			SendClientSubMapToPugMapSystem.PositionAndTile item = new SendClientSubMapToPugMapSystem.PositionAndTile
			{
				pos = tile.pos,
				tile = new TileCD
				{
					tileset = tile.tileset,
					tileType = tile.tileType
				}
			};
			pseudoTileMapLocal.Remove(item);
			ref NativeList<SendClientSubMapToPugMapSystem.TileUpdate> reference = ref tileUpdatesLocal;
			SendClientSubMapToPugMapSystem.TileUpdate value = new SendClientSubMapToPugMapSystem.TileUpdate
			{
				add = false,
				pos = tile.pos,
				tileType = tile.tileType,
				tileset = tile.tileset
			};
			reference.Add(in value);
			ecb.RemoveComponent<TileCreatedFromEntityCD>(entity);
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __tileTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<TileCreatedFromEntityCD>(nativeArrayPtr2, i));
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<TileCreatedFromEntityCD>(nativeArrayPtr2, j));
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
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<TileCreatedFromEntityCD>(nativeArrayPtr2, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<TileCreatedFromEntityCD>(nativeArrayPtr2, l));
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
	private struct SendPseudoTileToPugMapSystem_3AA9077B_LambdaJob_1_Job : IJobChunk
	{
		public EntityCommandBuffer ecb;

		public NativeParallelHashSet<SendClientSubMapToPugMapSystem.PositionAndTile> pseudoTileMapLocal;

		public NativeList<SendClientSubMapToPugMapSystem.TileUpdate> tileUpdatesLocal;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<TileCreatedFromEntityCD> __tileTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, [NoAlias] in TileCreatedFromEntityCD tile)
		{
			SendClientSubMapToPugMapSystem.PositionAndTile item = new SendClientSubMapToPugMapSystem.PositionAndTile
			{
				pos = tile.pos,
				tile = new TileCD
				{
					tileset = tile.tileset,
					tileType = tile.tileType
				}
			};
			pseudoTileMapLocal.Remove(item);
			ref NativeList<SendClientSubMapToPugMapSystem.TileUpdate> reference = ref tileUpdatesLocal;
			SendClientSubMapToPugMapSystem.TileUpdate value = new SendClientSubMapToPugMapSystem.TileUpdate
			{
				add = false,
				pos = tile.pos,
				tileType = tile.tileType,
				tileset = tile.tileset
			};
			reference.Add(in value);
			ecb.RemoveComponent<TileCreatedFromEntityCD>(entity);
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __tileTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<TileCreatedFromEntityCD>(nativeArrayPtr2, i));
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<TileCreatedFromEntityCD>(nativeArrayPtr2, j));
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
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<TileCreatedFromEntityCD>(nativeArrayPtr2, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<TileCreatedFromEntityCD>(nativeArrayPtr2, l));
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
	private struct SendPseudoTileToPugMapSystem_3AA9077B_LambdaJob_2_Job : IJobChunk
	{
		public EntityCommandBuffer ecb;

		public NativeParallelHashSet<SendClientSubMapToPugMapSystem.PositionAndTile> pseudoTileMapLocal;

		public NativeList<SendClientSubMapToPugMapSystem.TileUpdate> tileUpdatesLocal;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<PseudoTileCD> __tileTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<LocalTransform> __transformTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, [NoAlias] in PseudoTileCD tile, [NoAlias] in LocalTransform transform)
		{
			int2 pos = transform.Position.RoundToInt2();
			SendClientSubMapToPugMapSystem.PositionAndTile item = new SendClientSubMapToPugMapSystem.PositionAndTile
			{
				pos = pos,
				tile = new TileCD
				{
					tileset = tile.tileset,
					tileType = tile.tileType
				}
			};
			if (!pseudoTileMapLocal.Contains(item))
			{
				pseudoTileMapLocal.Add(item);
				ref NativeList<SendClientSubMapToPugMapSystem.TileUpdate> reference = ref tileUpdatesLocal;
				SendClientSubMapToPugMapSystem.TileUpdate value = new SendClientSubMapToPugMapSystem.TileUpdate
				{
					add = true,
					pos = pos,
					tileset = tile.tileset,
					tileType = tile.tileType
				};
				reference.Add(in value);
				ecb.AddComponent(entity, new TileCreatedFromEntityCD
				{
					pos = pos,
					tileType = tile.tileType,
					tileset = tile.tileset
				});
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __tileTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __transformTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PseudoTileCD>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, i));
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PseudoTileCD>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, j));
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
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PseudoTileCD>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PseudoTileCD>(nativeArrayPtr2, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, l));
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
		public ComponentTypeHandle<TileCreatedFromEntityCD> __TileCreatedFromEntityCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<PseudoTileCD> __PseudoTileCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
			__TileCreatedFromEntityCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<TileCreatedFromEntityCD>(isReadOnly: true);
			__PseudoTileCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PseudoTileCD>(isReadOnly: true);
			__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
		}
	}

	private NativeParallelHashSet<SendClientSubMapToPugMapSystem.PositionAndTile> pseudoTileMap;

	private SendClientSubMapToPugMapSystem sendClientSubMapToPugMapSystem;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_526967471_0;

	private EntityQuery __query_526967471_1;

	private EntityQuery __query_526967471_2;

	[Preserve]
	protected override void OnCreate()
	{
		pseudoTileMap = new NativeParallelHashSet<SendClientSubMapToPugMapSystem.PositionAndTile>(1024, Allocator.Persistent);
		sendClientSubMapToPugMapSystem = base.World.GetExistingSystemManaged<SendClientSubMapToPugMapSystem>();
		base.OnCreate();
	}

	[Preserve]
	protected override void OnDestroy()
	{
		pseudoTileMap.Dispose();
		base.OnDestroy();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		EntityCommandBuffer ecb = CreateCommandBuffer();
		NativeParallelHashSet<SendClientSubMapToPugMapSystem.PositionAndTile> pseudoTileMapLocal = pseudoTileMap;
		NativeList<SendClientSubMapToPugMapSystem.TileUpdate> tileUpdates = sendClientSubMapToPugMapSystem.tileUpdates;
		SendPseudoTileToPugMapSystem_3AA9077B_LambdaJob_0_Execute(ecb, pseudoTileMapLocal, tileUpdates);
		SendPseudoTileToPugMapSystem_3AA9077B_LambdaJob_1_Execute(ecb, pseudoTileMapLocal, tileUpdates);
		SendPseudoTileToPugMapSystem_3AA9077B_LambdaJob_2_Execute(ecb, pseudoTileMapLocal, tileUpdates);
		sendClientSubMapToPugMapSystem.tileUpdatesWriterDependency = base.Dependency;
		base.OnUpdate();
	}

	private void SendPseudoTileToPugMapSystem_3AA9077B_LambdaJob_0_Execute(EntityCommandBuffer ecb, NativeParallelHashSet<SendClientSubMapToPugMapSystem.PositionAndTile> pseudoTileMapLocal, NativeList<SendClientSubMapToPugMapSystem.TileUpdate> tileUpdatesLocal)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__TileCreatedFromEntityCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		SendPseudoTileToPugMapSystem_3AA9077B_LambdaJob_0_Job jobData = new SendPseudoTileToPugMapSystem_3AA9077B_LambdaJob_0_Job
		{
			ecb = ecb,
			pseudoTileMapLocal = pseudoTileMapLocal,
			tileUpdatesLocal = tileUpdatesLocal,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__tileTypeHandle = __TypeHandle.__TileCreatedFromEntityCD_RO_ComponentTypeHandle
		};
		base.CheckedStateRef.Dependency = InternalCompilerInterface.JobChunkInterface.Schedule(jobData, __query_526967471_0, base.CheckedStateRef.Dependency);
	}

	private void SendPseudoTileToPugMapSystem_3AA9077B_LambdaJob_1_Execute(EntityCommandBuffer ecb, NativeParallelHashSet<SendClientSubMapToPugMapSystem.PositionAndTile> pseudoTileMapLocal, NativeList<SendClientSubMapToPugMapSystem.TileUpdate> tileUpdatesLocal)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__TileCreatedFromEntityCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		SendPseudoTileToPugMapSystem_3AA9077B_LambdaJob_1_Job jobData = new SendPseudoTileToPugMapSystem_3AA9077B_LambdaJob_1_Job
		{
			ecb = ecb,
			pseudoTileMapLocal = pseudoTileMapLocal,
			tileUpdatesLocal = tileUpdatesLocal,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__tileTypeHandle = __TypeHandle.__TileCreatedFromEntityCD_RO_ComponentTypeHandle
		};
		base.CheckedStateRef.Dependency = InternalCompilerInterface.JobChunkInterface.Schedule(jobData, __query_526967471_1, base.CheckedStateRef.Dependency);
	}

	private void SendPseudoTileToPugMapSystem_3AA9077B_LambdaJob_2_Execute(EntityCommandBuffer ecb, NativeParallelHashSet<SendClientSubMapToPugMapSystem.PositionAndTile> pseudoTileMapLocal, NativeList<SendClientSubMapToPugMapSystem.TileUpdate> tileUpdatesLocal)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__PseudoTileCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		SendPseudoTileToPugMapSystem_3AA9077B_LambdaJob_2_Job jobData = new SendPseudoTileToPugMapSystem_3AA9077B_LambdaJob_2_Job
		{
			ecb = ecb,
			pseudoTileMapLocal = pseudoTileMapLocal,
			tileUpdatesLocal = tileUpdatesLocal,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__tileTypeHandle = __TypeHandle.__PseudoTileCD_RO_ComponentTypeHandle,
			__transformTypeHandle = __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle
		};
		base.CheckedStateRef.Dependency = InternalCompilerInterface.JobChunkInterface.Schedule(jobData, __query_526967471_2, base.CheckedStateRef.Dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<PseudoTileCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<TileCreatedFromEntityCD>();
		__query_526967471_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<TileCreatedFromEntityCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<PseudoTileCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<EntityDestroyedCD>();
		__query_526967471_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithNone<TileCreatedFromEntityCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithNone<EntityDestroyedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<PseudoTileCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
		__query_526967471_2 = entityQueryBuilder2.Build(ref state);
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
	public SendPseudoTileToPugMapSystem()
	{
	}
}
