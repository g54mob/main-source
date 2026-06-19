using System.Runtime.CompilerServices;
using PugTilemap;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine.Scripting;

namespace PugFlora
{
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
	[UpdateBefore(typeof(UpdateSubMapSystemServer))]
	[UpdateInGroup(typeof(EndPredictedSimulationSystemGroup))]
	public class WaterGroundRegisterSystem : PugSimulationSystemBase
	{
		[NoAlias]
		[BurstCompile]
		private struct WaterGroundRegisterSystem_7092AFF5_LambdaJob_0_Job : IJob
		{
			public Entity updatedTilesSingletonLocal;

			public NativeParallelHashSet<int2> updatedPositionsLocal;

			public BufferLookup<TileUpdateBuffer> __TileUpdateBuffer_BufferLookup;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void OriginalLambdaBody()
			{
				DynamicBuffer<TileUpdateBuffer> dynamicBuffer = __TileUpdateBuffer_BufferLookup[updatedTilesSingletonLocal];
				for (int num = dynamicBuffer.Length - 1; num >= 0; num--)
				{
					if (!updatedPositionsLocal.Contains(dynamicBuffer[num].position) && dynamicBuffer[num].tile.tileType == TileType.wateredGround)
					{
						updatedPositionsLocal.Add(dynamicBuffer[num].position);
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
			public BufferLookup<TileUpdateBuffer> __TileUpdateBuffer_RW_BufferLookup;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__TileUpdateBuffer_RW_BufferLookup = state.GetBufferLookup<TileUpdateBuffer>();
			}
		}

		public NativeParallelHashSet<int2> updatedPositions;

		private TypeHandle __TypeHandle;

		[Preserve]
		protected override void OnCreate()
		{
			base.OnCreate();
			NeedTileUpdateBuffer();
			updatedPositions = new NativeParallelHashSet<int2>(128, Allocator.Persistent);
		}

		[Preserve]
		protected override void OnDestroy()
		{
			base.OnDestroy();
			updatedPositions.Dispose();
		}

		[Preserve]
		protected override void OnUpdate()
		{
			Entity updatedTilesSingletonLocal = tileUpdateBufferSingletonEntity;
			NativeParallelHashSet<int2> updatedPositionsLocal = updatedPositions;
			updatedPositionsLocal.Clear();
			base.Dependency = WaterGroundRegisterSystem_7092AFF5_LambdaJob_0_Execute(updatedTilesSingletonLocal, updatedPositionsLocal, base.Dependency);
		}

		private JobHandle WaterGroundRegisterSystem_7092AFF5_LambdaJob_0_Execute(Entity updatedTilesSingletonLocal, NativeParallelHashSet<int2> updatedPositionsLocal, JobHandle __inputDependency)
		{
			__TypeHandle.__TileUpdateBuffer_RW_BufferLookup.Update(ref base.CheckedStateRef);
			return IJobExtensions.Schedule(new WaterGroundRegisterSystem_7092AFF5_LambdaJob_0_Job
			{
				updatedTilesSingletonLocal = updatedTilesSingletonLocal,
				updatedPositionsLocal = updatedPositionsLocal,
				__TileUpdateBuffer_BufferLookup = __TypeHandle.__TileUpdateBuffer_RW_BufferLookup
			}, __inputDependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			new EntityQueryBuilder(Allocator.Temp).Dispose();
		}

		protected override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			__AssignQueries(ref base.CheckedStateRef);
			__TypeHandle.__AssignHandles(ref base.CheckedStateRef);
		}

		[Preserve]
		public WaterGroundRegisterSystem()
		{
		}
	}
}
