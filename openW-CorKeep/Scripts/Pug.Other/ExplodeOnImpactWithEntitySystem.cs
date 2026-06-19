using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
public class ExplodeOnImpactWithEntitySystem : PugSimulationSystemBase
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct HasExploded : IComponentData, IQueryTypeParameter
	{
	}

	[NoAlias]
	[BurstCompile]
	private struct ExplodeOnImpactWithEntitySystem_1D9E16F7_LambdaJob_0_Job : IJobChunk
	{
		public EntityCommandBuffer ecb;

		public Entity effectEventBufferSingleton;

		public AttackSystem.Helper attackHelper;

		[ReadOnly]
		public CollisionWorld collisionWorld;

		public Entity updatedTilesSingleton;

		[ReadOnly]
		public TileAccessor tileLookup;

		[ReadOnly]
		public ComponentLookup<EntityDestroyedCD> entityDestroyedLookup;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		public ComponentTypeHandle<ExplodeOnImpactWithEntityCD> __explodeStateTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<BehaviourTagsCD> __attackTagsTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<StateInfoCD> __stateInfoTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, [NoAlias] ref ExplodeOnImpactWithEntityCD explodeState, [NoAlias] in BehaviourTagsCD attackTags, [NoAlias] in StateInfoCD stateInfo)
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
				reverseDamage = 999999,
				skipWallAndRootsLootDropOnDestroy = true,
				attackTime = 1f,
				canOnlyAttackType = CanOnlyAttackType.EnemyAndPlayer,
				behaviourTags = attackTags,
				isExplosive = true
			};
			NativeList<float3> hitPositions = new NativeList<float3>(Allocator.Temp);
			if (!attackHelper.Attack(ecb, ref hitPositions, in p))
			{
				return;
			}
			LocalTransform component = LocalTransform.FromPosition(hitPositions[0]);
			ecb.SetComponent(entity, component);
			if (explodeState.spawnTilesOnExplode)
			{
				p.radius = explodeState.explodeRadius;
				p.damage = explodeState.explodeDamage;
				p.playerDamage = 0;
				p.reverseDamage = 0;
				p.attackTime = 0f;
				attackHelper.Attack(ecb, in p);
				float2 y = new float2(component.Position.x, component.Position.z);
				int2 int5 = component.Position.RoundToInt2();
				int num = (int)math.ceil(explodeState.explodeRadius);
				for (int i = -num; i <= num; i++)
				{
					for (int j = -num; j <= num; j++)
					{
						int2 int6 = int5 + new int2(i, j);
						if (math.length(int6) > 1.5f && math.distance(int6, y) <= explodeState.explodeRadius && tileLookup.HasType(int6, TileType.ground) && !PositionIsBlocked(collisionWorld, new float3(int6.x, 0f, int6.y), 0.49f))
						{
							ecb.AppendToBuffer(updatedTilesSingleton, new TileUpdateBuffer
							{
								command = TileUpdateBuffer.Command.Add,
								position = int6,
								tile = new TileCD
								{
									tileset = (int)explodeState.tilesetToSpawn,
									tileType = explodeState.tileTypeToSpawn
								}
							});
						}
					}
				}
			}
			EntityUtility.PlayEffectEventServer(ecb, effectEventBufferSingleton, new EffectEventCD
			{
				effectID = EffectID.AcidExplosion,
				position1 = component.Position
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
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __attackTagsTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __stateInfoTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ExplodeOnImpactWithEntityCD>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr3, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr4, i));
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ExplodeOnImpactWithEntityCD>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr3, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr4, j));
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
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ExplodeOnImpactWithEntityCD>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr3, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr4, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ExplodeOnImpactWithEntityCD>(nativeArrayPtr2, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr3, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr4, l));
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

		[ReadOnly]
		public ComponentTypeHandle<BehaviourTagsCD> __BehaviourTagsCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<StateInfoCD> __StateInfoCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentLookup<EntityDestroyedCD> __EntityDestroyedCD_RO_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
			__ExplodeOnImpactWithEntityCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<ExplodeOnImpactWithEntityCD>();
			__BehaviourTagsCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<BehaviourTagsCD>(isReadOnly: true);
			__StateInfoCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<StateInfoCD>(isReadOnly: true);
			__EntityDestroyedCD_RO_ComponentLookup = state.GetComponentLookup<EntityDestroyedCD>(isReadOnly: true);
		}
	}

	private TypeHandle __TypeHandle;

	private EntityQuery __query_21221134_0;

	private EntityQuery __query_21221134_1;

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
		Entity singletonEntity = __query_21221134_1.GetSingletonEntity();
		AttackSystem.Helper helper = GetAttackHelper();
		CollisionWorld collisionWorld = GetPhysicsWorld().CollisionWorld;
		Entity updatedTilesSingleton = tileUpdateBufferSingletonEntity;
		TileAccessor tileLookup = CreateTileAccessor();
		ComponentLookup<EntityDestroyedCD> componentLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EntityDestroyedCD_RO_ComponentLookup, ref base.CheckedStateRef);
		ExplodeOnImpactWithEntitySystem_1D9E16F7_LambdaJob_0_Execute(ecb, singletonEntity, helper, collisionWorld, updatedTilesSingleton, tileLookup, componentLookup);
		base.OnUpdate();
	}

	private static bool PositionIsBlocked(CollisionWorld collisionWorld, float3 position, float radius)
	{
		return collisionWorld.SphereCast(position, radius, float3.zero, 0f, new CollisionFilter
		{
			BelongsTo = uint.MaxValue,
			CollidesWith = 131905u
		});
	}

	private void ExplodeOnImpactWithEntitySystem_1D9E16F7_LambdaJob_0_Execute(EntityCommandBuffer ecb, Entity effectEventBufferSingleton, AttackSystem.Helper attackHelper, CollisionWorld collisionWorld, Entity updatedTilesSingleton, TileAccessor tileLookup, ComponentLookup<EntityDestroyedCD> entityDestroyedLookup)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__ExplodeOnImpactWithEntityCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__BehaviourTagsCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__StateInfoCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		ExplodeOnImpactWithEntitySystem_1D9E16F7_LambdaJob_0_Job jobData = new ExplodeOnImpactWithEntitySystem_1D9E16F7_LambdaJob_0_Job
		{
			ecb = ecb,
			effectEventBufferSingleton = effectEventBufferSingleton,
			attackHelper = attackHelper,
			collisionWorld = collisionWorld,
			updatedTilesSingleton = updatedTilesSingleton,
			tileLookup = tileLookup,
			entityDestroyedLookup = entityDestroyedLookup,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__explodeStateTypeHandle = __TypeHandle.__ExplodeOnImpactWithEntityCD_RW_ComponentTypeHandle,
			__attackTagsTypeHandle = __TypeHandle.__BehaviourTagsCD_RO_ComponentTypeHandle,
			__stateInfoTypeHandle = __TypeHandle.__StateInfoCD_RO_ComponentTypeHandle
		};
		base.CheckedStateRef.Dependency = InternalCompilerInterface.JobChunkInterface.Schedule(jobData, __query_21221134_0, base.CheckedStateRef.Dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<HasExploded>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<BehaviourTagsCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<StateInfoCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ExplodeOnImpactWithEntityCD>();
		_queryRequiredForUpdate = (__query_21221134_0 = entityQueryBuilder2.Build(ref state));
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<EffectEventBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_21221134_1 = entityQueryBuilder2.Build(ref state);
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
	public ExplodeOnImpactWithEntitySystem()
	{
	}
}
