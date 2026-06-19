using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
public class ExplodeOnImpactWithMinionSystem : PugSimulationSystemBase
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct HasExploded : IComponentData, IQueryTypeParameter
	{
	}

	[NoAlias]
	[BurstCompile]
	private struct ExplodeOnImpactWithMinionSystem_2A84BEE4_LambdaJob_0_Job : IJobChunk
	{
		public EntityCommandBuffer ecb;

		public Entity effectEventBufferSingleton;

		public AttackSystem.Helper attackHelper;

		[ReadOnly]
		public ComponentLookup<EntityDestroyedCD> entityDestroyedLookup;

		public Entity tileUpdateBufferEntity;

		public Entity tileDamageBufferEntity;

		public BufferLookup<TileUpdateBuffer> tileUpdateBufferLookup;

		public BufferLookup<TileDamageBuffer> tileDamageBufferLookup;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		public ComponentTypeHandle<ExplodeOnImpactWithEntityCD> __explodeStateTypeHandle;

		public ComponentTypeHandle<MinionCD> __minionCDTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<BehaviourTagsCD> __attackTagsTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<StateInfoCD> __stateInfoTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, [NoAlias] ref ExplodeOnImpactWithEntityCD explodeState, [NoAlias] ref MinionCD minionCD, [NoAlias] in BehaviourTagsCD attackTags, [NoAlias] in StateInfoCD stateInfo)
		{
			if (!stateInfo.IsCurrentState(StateID.Chase))
			{
				return;
			}
			bool flag = false;
			if (entityDestroyedLookup.HasAndIsComponentEnabled(entity))
			{
				flag = true;
				ecb.AddComponent<HasExploded>(entity);
			}
			AttackSystem.Helper.Parameters p = new AttackSystem.Helper.Parameters
			{
				effectEventBufferSingleton = effectEventBufferSingleton,
				attacker = entity,
				radius = explodeState.distanceToExplode,
				playerDamage = explodeState.explodeDamage,
				damage = explodeState.explodeDamage,
				skipWallAndRootsLootDropOnDestroy = true,
				attackTime = 1f,
				canOnlyAttackType = CanOnlyAttackType.All,
				behaviourTags = attackTags,
				isExplosive = true
			};
			NativeList<float3> hitPositions = new NativeList<float3>(Allocator.Temp);
			if (!attackHelper.Attack(ecb, ref hitPositions, in p))
			{
				return;
			}
			LocalTransform localTransform = attackHelper.localTransformLookup[entity];
			float2 y = new float2(localTransform.Position.x, localTransform.Position.z);
			int2 int5 = new int2((int)math.round(y.x), (int)math.round(y.y));
			DynamicBuffer<TileDamageBuffer> dynamicBuffer = tileDamageBufferLookup[tileDamageBufferEntity];
			_ = tileUpdateBufferLookup[tileUpdateBufferEntity];
			for (int i = -4; i <= 4; i++)
			{
				for (int j = -4; j <= 4; j++)
				{
					int2 int6 = new int2(i, j) + int5;
					if (math.distance(int6, y) <= explodeState.explodeRadius)
					{
						dynamicBuffer.Add(new TileDamageBuffer
						{
							damage = explodeState.explodeDamage,
							position = int6,
							canHitLowColliders = true,
							bypassMaxDamagePerHit = true,
							damagedByExplosion = true,
							causedByEntity = entity
						});
					}
				}
			}
			minionCD.lifespanTimer = 0f;
			EntityUtility.PlayEffectEventServer(ecb, effectEventBufferSingleton, new EffectEventCD
			{
				effectID = EffectID.AcidExplosion,
				position1 = localTransform.Position
			});
			if (!flag)
			{
				ecb.AddComponent<HasExploded>(entity);
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __explodeStateTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __minionCDTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __attackTagsTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __stateInfoTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ExplodeOnImpactWithEntityCD>(nativeArrayPtr2, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MinionCD>(nativeArrayPtr3, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr4, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr5, i));
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ExplodeOnImpactWithEntityCD>(nativeArrayPtr2, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MinionCD>(nativeArrayPtr3, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr4, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr5, j));
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
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ExplodeOnImpactWithEntityCD>(nativeArrayPtr2, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MinionCD>(nativeArrayPtr3, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr4, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr5, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ExplodeOnImpactWithEntityCD>(nativeArrayPtr2, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MinionCD>(nativeArrayPtr3, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr4, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr5, l));
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

		public ComponentTypeHandle<ExplodeOnImpactWithEntityCD> __ExplodeOnImpactWithEntityCD_RW_ComponentTypeHandle;

		public ComponentTypeHandle<MinionCD> __MinionCD_RW_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<BehaviourTagsCD> __BehaviourTagsCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<StateInfoCD> __StateInfoCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentLookup<EntityDestroyedCD> __EntityDestroyedCD_RO_ComponentLookup;

		public BufferLookup<TileUpdateBuffer> __TileUpdateBuffer_RW_BufferLookup;

		public BufferLookup<TileDamageBuffer> __TileDamageBuffer_RW_BufferLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
			__ExplodeOnImpactWithEntityCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<ExplodeOnImpactWithEntityCD>();
			__MinionCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<MinionCD>();
			__BehaviourTagsCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<BehaviourTagsCD>(isReadOnly: true);
			__StateInfoCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<StateInfoCD>(isReadOnly: true);
			__EntityDestroyedCD_RO_ComponentLookup = state.GetComponentLookup<EntityDestroyedCD>(isReadOnly: true);
			__TileUpdateBuffer_RW_BufferLookup = state.GetBufferLookup<TileUpdateBuffer>();
			__TileDamageBuffer_RW_BufferLookup = state.GetBufferLookup<TileDamageBuffer>();
		}
	}

	private TypeHandle __TypeHandle;

	private EntityQuery __query_780226074_0;

	private EntityQuery __query_780226074_1;

	private EntityQuery __query_780226074_2;

	private EntityQuery __query_780226074_3;

	[Preserve]
	protected override void OnCreate()
	{
		NeedTileUpdateBuffer();
		RequireForUpdate<EffectEventBuffer>();
		RequireForUpdate<WorldInfoCD>();
		base.OnCreate();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		EntityCommandBuffer ecb = CreateCommandBuffer();
		Entity singletonEntity = __query_780226074_1.GetSingletonEntity();
		AttackSystem.Helper helper = GetAttackHelper();
		GetPhysicsWorld();
		_ = tileUpdateBufferSingletonEntity;
		CreateTileAccessor();
		ComponentLookup<EntityDestroyedCD> componentLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EntityDestroyedCD_RO_ComponentLookup, ref base.CheckedStateRef);
		Entity singletonEntity2 = __query_780226074_2.GetSingletonEntity();
		Entity singletonEntity3 = __query_780226074_3.GetSingletonEntity();
		BufferLookup<TileUpdateBuffer> bufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__TileUpdateBuffer_RW_BufferLookup, ref base.CheckedStateRef);
		BufferLookup<TileDamageBuffer> bufferLookup2 = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__TileDamageBuffer_RW_BufferLookup, ref base.CheckedStateRef);
		ExplodeOnImpactWithMinionSystem_2A84BEE4_LambdaJob_0_Execute(ecb, singletonEntity, helper, componentLookup, singletonEntity2, singletonEntity3, bufferLookup, bufferLookup2);
		base.OnUpdate();
	}

	private void ExplodeOnImpactWithMinionSystem_2A84BEE4_LambdaJob_0_Execute(EntityCommandBuffer ecb, Entity effectEventBufferSingleton, AttackSystem.Helper attackHelper, ComponentLookup<EntityDestroyedCD> entityDestroyedLookup, Entity tileUpdateBufferEntity, Entity tileDamageBufferEntity, BufferLookup<TileUpdateBuffer> tileUpdateBufferLookup, BufferLookup<TileDamageBuffer> tileDamageBufferLookup)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__ExplodeOnImpactWithEntityCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__MinionCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__BehaviourTagsCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__StateInfoCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		ExplodeOnImpactWithMinionSystem_2A84BEE4_LambdaJob_0_Job jobData = new ExplodeOnImpactWithMinionSystem_2A84BEE4_LambdaJob_0_Job
		{
			ecb = ecb,
			effectEventBufferSingleton = effectEventBufferSingleton,
			attackHelper = attackHelper,
			entityDestroyedLookup = entityDestroyedLookup,
			tileUpdateBufferEntity = tileUpdateBufferEntity,
			tileDamageBufferEntity = tileDamageBufferEntity,
			tileUpdateBufferLookup = tileUpdateBufferLookup,
			tileDamageBufferLookup = tileDamageBufferLookup,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__explodeStateTypeHandle = __TypeHandle.__ExplodeOnImpactWithEntityCD_RW_ComponentTypeHandle,
			__minionCDTypeHandle = __TypeHandle.__MinionCD_RW_ComponentTypeHandle,
			__attackTagsTypeHandle = __TypeHandle.__BehaviourTagsCD_RO_ComponentTypeHandle,
			__stateInfoTypeHandle = __TypeHandle.__StateInfoCD_RO_ComponentTypeHandle
		};
		base.CheckedStateRef.Dependency = InternalCompilerInterface.JobChunkInterface.Schedule(jobData, __query_780226074_0, base.CheckedStateRef.Dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<HasExploded>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<BehaviourTagsCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<StateInfoCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ExplodeOnImpactWithEntityCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<MinionCD>();
		_queryRequiredForUpdate = (__query_780226074_0 = entityQueryBuilder2.Build(ref state));
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<EffectEventBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_780226074_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<TileUpdateBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_780226074_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<TileDamageBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_780226074_3 = entityQueryBuilder2.Build(ref state);
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
	public ExplodeOnImpactWithMinionSystem()
	{
	}
}
