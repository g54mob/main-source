using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Transforms;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public class SpawnPointSystem : PugSimulationSystemBase
{
	private struct SpawnPointSystem_8B472B9_LambdaJob_0_Job
	{
		public SpawnPointSystem __this;

		private void OriginalLambdaBody(Entity entity, in LocalTransform transform)
		{
			__this.EntityManager.AddComponentData(entity, new SpawnPointCD
			{
				position = transform.Position
			});
		}

		public void RunWithStructuralChange(EntityQuery query)
		{
			EntityQueryMask entityQueryMask = query.GetEntityQueryMask();
			InternalCompilerInterface.UnsafeCreateGatherEntitiesResult(ref query, out var result);
			TypeIndex typeIndex = TypeManager.GetTypeIndex<LocalTransform>();
			try
			{
				int entityCount = result.EntityCount;
				for (int i = 0; i != entityCount; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetEntityFromGatheredEntities(ref result, i);
					if (entityQueryMask.MatchesIgnoreFilter(entity))
					{
						OriginalLambdaBody(entity, InternalCompilerInterface.GetComponentData<LocalTransform>(__this.EntityManager, entity, typeIndex, out var _));
					}
				}
			}
			finally
			{
				InternalCompilerInterface.UnsafeReleaseGatheredEntities(ref query, ref result);
			}
		}
	}

	private struct TypeHandle
	{
		[ReadOnly]
		public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
			__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
		}
	}

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1759838561_0;

	[Preserve]
	protected override void OnCreate()
	{
		UpdatesInRunGroup();
		base.OnCreate();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		SpawnPointSystem_8B472B9_LambdaJob_0_Execute();
		base.OnUpdate();
	}

	private void SpawnPointSystem_8B472B9_LambdaJob_0_Execute()
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		SpawnPointSystem_8B472B9_LambdaJob_0_Job spawnPointSystem_8B472B9_LambdaJob_0_Job = new SpawnPointSystem_8B472B9_LambdaJob_0_Job
		{
			__this = this
		};
		if (!__query_1759838561_0.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			spawnPointSystem_8B472B9_LambdaJob_0_Job.RunWithStructuralChange(__query_1759838561_0);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<SpawnPointCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<HasSpawnPointCD>();
		__query_1759838561_0 = entityQueryBuilder2.Build(ref state);
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
	public SpawnPointSystem()
	{
	}
}
