using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Scripting;

namespace PugWorldGen
{
	[WorldSystemFilter(WorldSystemFilterFlags.Editor | WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
	[UpdateInGroup(typeof(SimulationSystemGroup))]
	[UpdateAfter(typeof(ResetYSystem))]
	public class DungeonAssignSeedSystem : PugSimulationSystemBase
	{
		private struct TypeHandle
		{
			public DungeonJob.InternalCompilerQueryAndHandleData __PugWorldGen_DungeonJob_WithoutDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__PugWorldGen_DungeonJob_WithoutDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: false);
			}
		}

		private const uint SYSTEM_SEED = 2706886u;

		private EntityQuery query;

		private EntityQuery seedQ;

		private EntityQuery dungeonAreaQ;

		private TypeHandle __TypeHandle;

		[Preserve]
		protected override void OnCreate()
		{
			seedQ = GetEntityQuery(ComponentType.ReadOnly<ServerSeedCD>());
			query = GetEntityQuery(ComponentType.ReadWrite<DungeonAreaCD>(), ComponentType.ReadOnly<LocalTransform>(), ComponentType.ReadOnly<DungeonGenerationInitializationCD>());
			if (Application.isPlaying)
			{
				dungeonAreaQ = GetEntityQuery(ComponentType.ReadOnly<DungeonAreaCD>());
				RequireForUpdate(dungeonAreaQ);
			}
			else
			{
				RequireForUpdate(query);
			}
			base.OnCreate();
		}

		[Preserve]
		protected override void OnUpdate()
		{
			EntityCommandBuffer ecb = CreateCommandBuffer();
			uint num = 2706886u;
			if (!seedQ.IsEmpty)
			{
				num ^= seedQ.GetSingleton<ServerSeedCD>().Value;
			}
			bool isPlaying = Application.isPlaying;
			DungeonJob job = new DungeonJob
			{
				ecb = ecb,
				isPlaying = isPlaying,
				serverSeed = num,
				systemSeed = 2706886u
			};
			base.Dependency = __ScheduleViaJobChunkExtension_0(job, query, base.Dependency, ref base.CheckedStateRef, hasUserDefinedQuery: true);
			base.OnUpdate();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_0(DungeonJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__PugWorldGen_DungeonJob_WithoutDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__PugWorldGen_DungeonJob_WithoutDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__PugWorldGen_DungeonJob_WithoutDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__PugWorldGen_DungeonJob_WithoutDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
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
		public DungeonAssignSeedSystem()
		{
		}
	}
}
