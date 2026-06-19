#define PUG_RGB_ENABLED
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.NetCode;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public class TheGreatWallAnimationSystem : PugSimulationSystemBase
{
	public struct TheGreatWallanimationBuffer : IComponentData, IQueryTypeParameter
	{
		public float animationTimer;
	}

	private struct TheGreatWallAnimationSystem_27B12EEE_LambdaJob_0_Job
	{
		public TheGreatWallAnimationSystem __this;

		public NetworkTick clientTick;

		public bool wallIsBeingLoweredLocal;

		public NetworkTick animationStartTickLocal;

		private void OriginalLambdaBody(Entity entity, in TheGreatWallSystem.TriggerWallAnimationRPC triggerWall)
		{
			if (!triggerWall.startTick.IsNewerThan(clientTick))
			{
				wallIsBeingLoweredLocal = true;
				animationStartTickLocal = triggerWall.startTick;
				__this.EntityManager.DestroyEntity(entity);
			}
		}

		public void RunWithStructuralChange(EntityQuery query)
		{
			EntityQueryMask entityQueryMask = query.GetEntityQueryMask();
			InternalCompilerInterface.UnsafeCreateGatherEntitiesResult(ref query, out var result);
			TypeIndex typeIndex = TypeManager.GetTypeIndex<TheGreatWallSystem.TriggerWallAnimationRPC>();
			try
			{
				int entityCount = result.EntityCount;
				for (int i = 0; i != entityCount; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetEntityFromGatheredEntities(ref result, i);
					if (entityQueryMask.MatchesIgnoreFilter(entity))
					{
						OriginalLambdaBody(entity, InternalCompilerInterface.GetComponentData<TheGreatWallSystem.TriggerWallAnimationRPC>(__this.EntityManager, entity, typeIndex, out var _));
					}
				}
			}
			finally
			{
				InternalCompilerInterface.UnsafeReleaseGatheredEntities(ref query, ref result);
			}
		}
	}

	private struct TheGreatWallAnimationSystem_27B12EEE_LambdaJob_1_Job
	{
		public TheGreatWallAnimationSystem __this;

		public float deltaTime;

		private void OriginalLambdaBody(Entity entity, ref TheGreatWallanimationBuffer wallAnim)
		{
			wallAnim.animationTimer += deltaTime;
			if (wallAnim.animationTimer >= 12f)
			{
				__this.EntityManager.DestroyEntity(entity);
			}
		}

		public void RunWithStructuralChange(EntityQuery query)
		{
			EntityQueryMask entityQueryMask = query.GetEntityQueryMask();
			InternalCompilerInterface.UnsafeCreateGatherEntitiesResult(ref query, out var result);
			TypeIndex typeIndex = TypeManager.GetTypeIndex<TheGreatWallanimationBuffer>();
			try
			{
				int entityCount = result.EntityCount;
				for (int i = 0; i != entityCount; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetEntityFromGatheredEntities(ref result, i);
					if (entityQueryMask.MatchesIgnoreFilter(entity))
					{
						TheGreatWallanimationBuffer originalComponent;
						TheGreatWallanimationBuffer wallAnim = InternalCompilerInterface.GetComponentData<TheGreatWallanimationBuffer>(__this.EntityManager, entity, typeIndex, out originalComponent);
						OriginalLambdaBody(entity, ref wallAnim);
						InternalCompilerInterface.WriteComponentData(__this.EntityManager, entity, typeIndex, ref wallAnim, ref originalComponent);
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
		public ComponentTypeHandle<TheGreatWallSystem.TriggerWallAnimationRPC> __TheGreatWallSystem_TriggerWallAnimationRPC_RO_ComponentTypeHandle;

		public ComponentTypeHandle<TheGreatWallanimationBuffer> __TheGreatWallAnimationSystem_TheGreatWallanimationBuffer_RW_ComponentTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
			__TheGreatWallSystem_TriggerWallAnimationRPC_RO_ComponentTypeHandle = state.GetComponentTypeHandle<TheGreatWallSystem.TriggerWallAnimationRPC>(isReadOnly: true);
			__TheGreatWallAnimationSystem_TheGreatWallanimationBuffer_RW_ComponentTypeHandle = state.GetComponentTypeHandle<TheGreatWallanimationBuffer>();
		}
	}

	private EntityQuery wallAnimQuery;

	private int tickRate;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1875619488_0;

	private EntityQuery __query_1875619488_1;

	private EntityQuery __query_1875619488_2;

	[Preserve]
	protected override void OnCreate()
	{
		UpdatesInRunGroup();
		RequireForUpdate<ClientServerTickRate>();
		wallAnimQuery = GetEntityQuery(typeof(TheGreatWallanimationBuffer));
		base.OnCreate();
	}

	[Preserve]
	protected override void OnStartRunning()
	{
		tickRate = __query_1875619488_2.GetSingleton<ClientServerTickRate>().SimulationTickRate;
		base.OnStartRunning();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		float deltaTime = base.CheckedStateRef.WorldUnmanaged.Time.DeltaTime;
		NetworkTick clientTick = GetServerTick();
		bool wallIsBeingLoweredLocal = false;
		NetworkTick animationStartTickLocal = NetworkTick.Invalid;
		TheGreatWallAnimationSystem_27B12EEE_LambdaJob_0_Execute(ref clientTick, ref wallIsBeingLoweredLocal, ref animationStartTickLocal);
		if (wallIsBeingLoweredLocal && wallAnimQuery.IsEmpty)
		{
			Entity entity = base.EntityManager.CreateEntity();
			base.EntityManager.AddComponentData(entity, new TheGreatWallanimationBuffer
			{
				animationTimer = (float)clientTick.TicksSince(animationStartTickLocal) / (float)tickRate
			});
			Manager.rgb.TriggerEvent(RGBManager.Event.LoweringGreatWall);
		}
		TheGreatWallAnimationSystem_27B12EEE_LambdaJob_1_Execute(ref deltaTime);
		base.OnUpdate();
	}

	private void TheGreatWallAnimationSystem_27B12EEE_LambdaJob_0_Execute(ref NetworkTick clientTick, ref bool wallIsBeingLoweredLocal, ref NetworkTick animationStartTickLocal)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__TheGreatWallSystem_TriggerWallAnimationRPC_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		TheGreatWallAnimationSystem_27B12EEE_LambdaJob_0_Job theGreatWallAnimationSystem_27B12EEE_LambdaJob_0_Job = new TheGreatWallAnimationSystem_27B12EEE_LambdaJob_0_Job
		{
			__this = this,
			clientTick = clientTick,
			wallIsBeingLoweredLocal = wallIsBeingLoweredLocal,
			animationStartTickLocal = animationStartTickLocal
		};
		if (!__query_1875619488_0.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			theGreatWallAnimationSystem_27B12EEE_LambdaJob_0_Job.RunWithStructuralChange(__query_1875619488_0);
		}
		clientTick = theGreatWallAnimationSystem_27B12EEE_LambdaJob_0_Job.clientTick;
		wallIsBeingLoweredLocal = theGreatWallAnimationSystem_27B12EEE_LambdaJob_0_Job.wallIsBeingLoweredLocal;
		animationStartTickLocal = theGreatWallAnimationSystem_27B12EEE_LambdaJob_0_Job.animationStartTickLocal;
	}

	private void TheGreatWallAnimationSystem_27B12EEE_LambdaJob_1_Execute(ref float deltaTime)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__TheGreatWallAnimationSystem_TheGreatWallanimationBuffer_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		TheGreatWallAnimationSystem_27B12EEE_LambdaJob_1_Job theGreatWallAnimationSystem_27B12EEE_LambdaJob_1_Job = new TheGreatWallAnimationSystem_27B12EEE_LambdaJob_1_Job
		{
			__this = this,
			deltaTime = deltaTime
		};
		if (!__query_1875619488_1.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			theGreatWallAnimationSystem_27B12EEE_LambdaJob_1_Job.RunWithStructuralChange(__query_1875619488_1);
		}
		deltaTime = theGreatWallAnimationSystem_27B12EEE_LambdaJob_1_Job.deltaTime;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<TheGreatWallSystem.TriggerWallAnimationRPC>();
		__query_1875619488_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAllRW<TheGreatWallanimationBuffer>();
		__query_1875619488_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1875619488_2 = entityQueryBuilder2.Build(ref state);
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
	public TheGreatWallAnimationSystem()
	{
	}
}
