using System;
using System.Runtime.CompilerServices;
using Pug.UnityExtensions;
using PugTilemap;
using PugTilemap.Quads;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(SimulationSystemGroup))]
public class WaterSpreadingSystem : PugSimulationSystemBase
{
	[NoAlias]
	[BurstCompile]
	private struct WaterSpreadingSystem_73E8DD06_LambdaJob_0_Job : IJobChunk
	{
		public EntityCommandBuffer ecb;

		public NativeParallelHashSet<int2> createdPositions;

		[ReadOnly]
		public TileAccessor tileLookup;

		public Entity updatedTilesSingletonLocal;

		public Entity effectEventBufferEntity;

		public double time;

		public Unity.Mathematics.Random rng;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		public ComponentTypeHandle<WaterSpreaderCD> __waterSpreaderCDTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, [NoAlias] ref WaterSpreaderCD waterSpreaderCD)
		{
			if (!waterSpreaderCD.timer.isRunning)
			{
				waterSpreaderCD.timer.Start(time, GetRandomSpreadDelay(ref rng));
			}
			if (!waterSpreaderCD.timer.IsTimerElapsed(time))
			{
				return;
			}
			int2 position = waterSpreaderCD.position;
			TileCD tileCD;
			bool type = tileLookup.GetType(position, TileType.water, out tileCD);
			if (!type && !tileLookup.HasType(position, TileType.pit))
			{
				ecb.DestroyEntity(entity);
				return;
			}
			int2 int5 = position + AdjacentDir.GetInt2(64);
			int2 int6 = position + AdjacentDir.GetInt2(4);
			int2 int7 = position + AdjacentDir.GetInt2(16);
			int2 int8 = position + AdjacentDir.GetInt2(1);
			TileCD tileCD2;
			bool type2 = tileLookup.GetType(int5, TileType.water, out tileCD2);
			TileCD tileCD3;
			bool type3 = tileLookup.GetType(int6, TileType.water, out tileCD3);
			TileCD tileCD4;
			bool type4 = tileLookup.GetType(int7, TileType.water, out tileCD4);
			TileCD tileCD5;
			bool type5 = tileLookup.GetType(int8, TileType.water, out tileCD5);
			bool flag = type2 || type3 || type4 || type5;
			if (tileLookup.HasType(position, TileType.greatWall))
			{
				if (flag)
				{
					waterSpreaderCD.timer.Start(time, GetRandomSpreadDelay(ref rng));
				}
				else
				{
					ecb.DestroyEntity(entity);
				}
				return;
			}
			int num = (type ? tileCD.tileset : (-1));
			int num2 = num;
			if (type2)
			{
				num2 = GetHighestPrioWater(num2, tileCD2.tileset);
			}
			if (type3)
			{
				num2 = GetHighestPrioWater(num2, tileCD3.tileset);
			}
			if (type4)
			{
				num2 = GetHighestPrioWater(num2, tileCD4.tileset);
			}
			if (type5)
			{
				num2 = GetHighestPrioWater(num2, tileCD5.tileset);
			}
			if (flag && (!type || Tileset1HasHigherPrio(num2, tileCD.tileset)))
			{
				if (!createdPositions.Contains(position))
				{
					createdPositions.Add(position);
					SpreadToPosition(ecb, position, tileCD.tileType, tileCD.tileset, num2, updatedTilesSingletonLocal, effectEventBufferEntity);
				}
			}
			else if (type)
			{
				if (!createdPositions.Contains(int5) && ((type2 && Tileset1HasHigherPrio(num, tileCD2.tileset)) || (!type2 && tileLookup.HasType(int5, TileType.pit))))
				{
					createdPositions.Add(int5);
					SpreadToPosition(ecb, int5, tileCD2.tileType, tileCD2.tileset, tileCD.tileset, updatedTilesSingletonLocal, effectEventBufferEntity);
				}
				if (!createdPositions.Contains(int6) && ((type3 && Tileset1HasHigherPrio(num, tileCD3.tileset)) || (!type3 && tileLookup.HasType(int6, TileType.pit))))
				{
					createdPositions.Add(int6);
					SpreadToPosition(ecb, int6, tileCD3.tileType, tileCD3.tileset, tileCD.tileset, updatedTilesSingletonLocal, effectEventBufferEntity);
				}
				if (!createdPositions.Contains(int7) && ((type4 && Tileset1HasHigherPrio(num, tileCD4.tileset)) || (!type4 && tileLookup.HasType(int7, TileType.pit))))
				{
					createdPositions.Add(int7);
					SpreadToPosition(ecb, int7, tileCD4.tileType, tileCD4.tileset, tileCD.tileset, updatedTilesSingletonLocal, effectEventBufferEntity);
				}
				if (!createdPositions.Contains(int8) && ((type5 && Tileset1HasHigherPrio(num, tileCD5.tileset)) || (!type5 && tileLookup.HasType(int8, TileType.pit))))
				{
					createdPositions.Add(int8);
					SpreadToPosition(ecb, int8, tileCD5.tileType, tileCD5.tileset, tileCD.tileset, updatedTilesSingletonLocal, effectEventBufferEntity);
				}
			}
			ecb.DestroyEntity(entity);
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __waterSpreaderCDTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<WaterSpreaderCD>(nativeArrayPtr2, i));
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<WaterSpreaderCD>(nativeArrayPtr2, j));
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
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<WaterSpreaderCD>(nativeArrayPtr2, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<WaterSpreaderCD>(nativeArrayPtr2, l));
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

		public ComponentTypeHandle<WaterSpreaderCD> __WaterSpreaderCD_RW_ComponentTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
			__WaterSpreaderCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<WaterSpreaderCD>();
		}
	}

	private EntityQuery query;

	private bool hasRunAtLeastOnce;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1681742247_0;

	private EntityQuery __query_1681742247_1;

	[Preserve]
	protected override void OnCreate()
	{
		NeedDatabase();
		NeedTileUpdateBuffer();
		RequireForUpdate<EffectEventBuffer>();
		RequireForUpdate(query);
		base.OnCreate();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		if (base.WorldInfo.simulationDisabled && hasRunAtLeastOnce)
		{
			base.OnUpdate();
			return;
		}
		hasRunAtLeastOnce = true;
		EntityCommandBuffer ecb = CreateCommandBuffer();
		NativeParallelHashSet<int2> createdPositions = new NativeParallelHashSet<int2>(1024, base.World.UpdateAllocator.ToAllocator);
		TileAccessor tileLookup = CreateTileAccessor();
		Entity updatedTilesSingletonLocal = tileUpdateBufferSingletonEntity;
		Entity singletonEntity = __query_1681742247_1.GetSingletonEntity();
		double elapsedTime = base.CheckedStateRef.WorldUnmanaged.Time.ElapsedTime;
		Unity.Mathematics.Random rng = PugRandom.GetRng();
		WaterSpreadingSystem_73E8DD06_LambdaJob_0_Execute(ecb, createdPositions, tileLookup, updatedTilesSingletonLocal, singletonEntity, elapsedTime, rng);
		base.OnUpdate();
	}

	private static float GetRandomSpreadDelay(ref Unity.Mathematics.Random rng)
	{
		return 1f + 0.25f * (float)rng.NextInt(0, 5);
	}

	private static int GetHighestPrioWater(int tileset1, int tileset2)
	{
		if (tileset1 == 10)
		{
			return tileset1;
		}
		if (tileset2 == 10)
		{
			return tileset2;
		}
		return math.max(tileset1, tileset2);
	}

	private static bool Tileset1HasHigherPrio(int tileset1, int tileset2)
	{
		if (tileset1 == 10 && tileset2 != 10)
		{
			return true;
		}
		return tileset2 < tileset1;
	}

	private static void SpreadToPosition(EntityCommandBuffer ecb, int2 tilePos, TileType oldTileType, int oldTileset, int newTileset, Entity updatedTilesSingleton, Entity effectEventBuffer)
	{
		if (oldTileset == 3 || (oldTileType == TileType.water && newTileset == 3))
		{
			ClearAndAddLavaGround(ecb, tilePos, updatedTilesSingleton);
			EntityUtility.PlayEffectEventServer(ecb, effectEventBuffer, new EffectEventCD
			{
				effectID = EffectID.BurnSmoke,
				position1 = new float3(tilePos.x, -0.5f, tilePos.y)
			});
		}
		else
		{
			AddWaterAndRemovePit(ecb, tilePos, newTileset, updatedTilesSingleton);
		}
	}

	private static void AddWaterAndRemovePit(EntityCommandBuffer ecb, int2 tilePos, int tileset, Entity updatedTilesSingleton)
	{
		ecb.AppendToBuffer(updatedTilesSingleton, new TileUpdateBuffer
		{
			command = TileUpdateBuffer.Command.Remove,
			position = tilePos,
			tile = new TileCD
			{
				tileset = 0,
				tileType = TileType.pit
			}
		});
		ecb.AppendToBuffer(updatedTilesSingleton, new TileUpdateBuffer
		{
			command = TileUpdateBuffer.Command.Add,
			position = tilePos,
			tile = new TileCD
			{
				tileset = tileset,
				tileType = TileType.water
			}
		});
	}

	private static void ClearAndAddLavaGround(EntityCommandBuffer ecb, int2 tilePos, Entity updatedTilesSingleton)
	{
		ecb.AppendToBuffer(updatedTilesSingleton, new TileUpdateBuffer
		{
			command = TileUpdateBuffer.Command.Clear,
			position = tilePos
		});
		ecb.AppendToBuffer(updatedTilesSingleton, new TileUpdateBuffer
		{
			command = TileUpdateBuffer.Command.Add,
			position = tilePos,
			tile = new TileCD
			{
				tileset = 3,
				tileType = TileType.ground
			}
		});
	}

	private void WaterSpreadingSystem_73E8DD06_LambdaJob_0_Execute(EntityCommandBuffer ecb, NativeParallelHashSet<int2> createdPositions, TileAccessor tileLookup, Entity updatedTilesSingletonLocal, Entity effectEventBufferEntity, double time, Unity.Mathematics.Random rng)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__WaterSpreaderCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		WaterSpreadingSystem_73E8DD06_LambdaJob_0_Job jobData = new WaterSpreadingSystem_73E8DD06_LambdaJob_0_Job
		{
			ecb = ecb,
			createdPositions = createdPositions,
			tileLookup = tileLookup,
			updatedTilesSingletonLocal = updatedTilesSingletonLocal,
			effectEventBufferEntity = effectEventBufferEntity,
			time = time,
			rng = rng,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__waterSpreaderCDTypeHandle = __TypeHandle.__WaterSpreaderCD_RW_ComponentTypeHandle
		};
		base.CheckedStateRef.Dependency = InternalCompilerInterface.JobChunkInterface.Schedule(jobData, __query_1681742247_0, base.CheckedStateRef.Dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAllRW<WaterSpreaderCD>();
		query = (__query_1681742247_0 = entityQueryBuilder2.Build(ref state));
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<EffectEventBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1681742247_1 = entityQueryBuilder2.Build(ref state);
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
	public WaterSpreadingSystem()
	{
	}
}
