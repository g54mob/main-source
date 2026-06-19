using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Pug.UnityExtensions;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Transforms;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public class BossSummoningSystem : PugSimulationSystemBase
{
	[NoAlias]
	[BurstCompile]
	private struct BossSummoningSystem_4A15507E_LambdaJob_0_Job : IJobChunk
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void RunWithoutJobSystem_00000668_0024PostfixBurstDelegate(ref EntityQuery query, IntPtr jobPtr);

		internal static class RunWithoutJobSystem_00000668_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<RunWithoutJobSystem_00000668_0024PostfixBurstDelegate>(RunWithoutJobSystem).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static void Invoke(ref EntityQuery query, IntPtr jobPtr)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<ref EntityQuery, IntPtr, void>)functionPointer)(ref query, jobPtr);
						return;
					}
				}
				RunWithoutJobSystem_0024BurstManaged(ref query, jobPtr);
			}
		}

		public double time;

		public EntityCommandBuffer ecb;

		public BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal;

		public NativeArray<Entity> summonedEnemies;

		public int animIdle;

		public int animGlow;

		public int animSpawn;

		public Entity effectEventBufferSingleton;

		public AttackSystem.Helper attackHelper;

		public Entity tileDamageBufferEntity;

		[ReadOnly]
		public BufferLookup<SummoningItemBuffer> bossSummonsBuffer;

		public ComponentLookup<EntityDestroyedCD> entityDestroyedLookup;

		public NetworkTick currentTick;

		public ComponentLookup<DontDropSelfCD> dontDropLootLookup;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		public BufferTypeHandle<AnimationBuffer> __animationTypeHandle;

		public ComponentTypeHandle<AnimationBufferPointer> __animationBufferPointerTypeHandle;

		public ComponentTypeHandle<SummonAreaCD> __summonAreaTypeHandle;

		public BufferTypeHandle<NearbyEntitiesBufferCD> __nearbyEntitiesTypeHandle;

		[ReadOnly]
		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ObjectDataCD> __ObjectDataCD_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, DynamicBuffer<AnimationBuffer> animation, [NoAlias] ref AnimationBufferPointer animationBufferPointer, [NoAlias] ref SummonAreaCD summonArea, DynamicBuffer<NearbyEntitiesBufferCD> nearbyEntities)
		{
			if (!__Unity_Transforms_LocalTransform_ComponentLookup.HasComponent(entity))
			{
				return;
			}
			LocalTransform component = __Unity_Transforms_LocalTransform_ComponentLookup[entity];
			int num = -1;
			for (int i = 0; i < summonedEnemies.Length; i++)
			{
				if (!__ObjectDataCD_ComponentLookup.HasComponent(summonedEnemies[i]) || !__Unity_Transforms_LocalTransform_ComponentLookup.HasComponent(summonedEnemies[i]))
				{
					continue;
				}
				ObjectID objectID = __ObjectDataCD_ComponentLookup[summonedEnemies[i]].objectID;
				if (objectID == summonArea.bossToSummon)
				{
					if (!(summonArea.overrideDistanceSqToCheckForExistingBoss > 0f))
					{
						num = 0;
						summonArea.internalTimer.Stop();
						break;
					}
					LocalTransform localTransform = __Unity_Transforms_LocalTransform_ComponentLookup[summonedEnemies[i]];
					if (math.distancesq(component.Position, localTransform.Position) < summonArea.overrideDistanceSqToCheckForExistingBoss)
					{
						num = 0;
						summonArea.internalTimer.Stop();
						break;
					}
				}
				if (summonArea.optionalBossToSummon != ObjectID.None && objectID == summonArea.optionalBossToSummon)
				{
					LocalTransform localTransform2 = __Unity_Transforms_LocalTransform_ComponentLookup[summonedEnemies[i]];
					if (math.distancesq(component.Position, localTransform2.Position) < 4900f)
					{
						num = 0;
						summonArea.internalTimer.Stop();
						break;
					}
				}
			}
			Entity entity2 = Entity.Null;
			if (num == -1)
			{
				float num2 = ((summonArea.overrideDistanceSqToCheckSummoningItem > 0f) ? summonArea.overrideDistanceSqToCheckSummoningItem : 4f);
				for (int j = 0; j < nearbyEntities.Length; j++)
				{
					entity2 = nearbyEntities[j].entity;
					if (__Unity_Transforms_LocalTransform_ComponentLookup.HasComponent(entity2))
					{
						float3 float5 = (summonArea.dontOffsetSpawnItemLocation ? float3.zero : summonArea.spawnOffset);
						if (math.distancesq(__Unity_Transforms_LocalTransform_ComponentLookup[entity2].Position, component.Position + float5) > num2)
						{
							continue;
						}
					}
					if (bossSummonsBuffer.HasComponent(entity2) && (!entityDestroyedLookup.HasComponent(entity2) || !entityDestroyedLookup.IsComponentEnabled(entity2)))
					{
						for (int k = 0; k < bossSummonsBuffer[entity2].Length; k++)
						{
							ObjectID bossToSummon = bossSummonsBuffer[entity2][k].bossToSummon;
							if (bossToSummon == summonArea.bossToSummon || bossToSummon == summonArea.optionalBossToSummon)
							{
								summonArea.currentBossToSummon = bossToSummon;
								num = 1;
								break;
							}
						}
					}
					if (num == 1)
					{
						break;
					}
				}
			}
			if (num != -1 && summonArea.internalTimer.isRunning && summonArea.internalTimer.IsTimerElapsed(time))
			{
				num = ((summonArea.internalState != 1) ? 3 : 2);
			}
			if (num == -1)
			{
				summonArea.internalTimer.Stop();
				num = 0;
			}
			if (num == summonArea.internalState)
			{
				return;
			}
			summonArea.internalState = num;
			if (summonArea.internalState == 0)
			{
				AnimationUtilities.TriggerAnimation(animIdle, currentTick, animation, ref animationBufferPointer);
			}
			else if (summonArea.internalState == 1)
			{
				summonArea.internalTimer.Start(time, summonArea.anticipationTime);
				AnimationUtilities.TriggerAnimation(animGlow, currentTick, animation, ref animationBufferPointer);
			}
			else if (summonArea.internalState == 2)
			{
				summonArea.internalTimer.Start(time, summonArea.spawnTime);
				AnimationUtilities.TriggerAnimation(animSpawn, currentTick, animation, ref animationBufferPointer);
			}
			else
			{
				if (summonArea.internalState != 3)
				{
					return;
				}
				Entity e = EntityUtility.CreateEntity(ecb, summonArea.currentBossToSummon, 1, databaseLocal);
				component.Position += summonArea.spawnOffset;
				ecb.SetComponent(e, component);
				dontDropLootLookup.SetComponentEnabled(entity2, value: true);
				entityDestroyedLookup.SetComponentEnabled(entity2, value: true);
				summonArea.internalState = 0;
				AnimationUtilities.TriggerAnimation(animIdle, currentTick, animation, ref animationBufferPointer);
				int2 int5 = component.Position.RoundToInt2();
				int distanceToDestroyTilesOnSpawn = summonArea.distanceToDestroyTilesOnSpawn;
				for (int l = -distanceToDestroyTilesOnSpawn; l <= distanceToDestroyTilesOnSpawn; l++)
				{
					for (int m = -distanceToDestroyTilesOnSpawn; m <= distanceToDestroyTilesOnSpawn; m++)
					{
						int2 int6 = new int2(l, m) + int5;
						if (math.distance(int5, int6) <= 3f)
						{
							ecb.AppendToBuffer(tileDamageBufferEntity, new TileDamageBuffer
							{
								damage = 10000,
								position = int6,
								canHitLowColliders = true
							});
						}
					}
				}
				AttackSystem.Helper.Parameters p = new AttackSystem.Helper.Parameters
				{
					effectEventBufferSingleton = effectEventBufferSingleton,
					attacker = entity,
					isRanged = false,
					radius = summonArea.distanceToDestroyTilesOnSpawn,
					damage = 1000,
					playerDamage = 0,
					pushback = 0f,
					bypassMaxDamagePerHit = true
				};
				attackHelper.Attack(ecb, in p);
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			BufferAccessor<AnimationBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __animationTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __animationBufferPointerTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __summonAreaTypeHandle);
			BufferAccessor<NearbyEntitiesBufferCD> bufferAccessor2 = chunk.GetBufferAccessor(ref __nearbyEntitiesTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), bufferAccessor[i], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr2, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SummonAreaCD>(nativeArrayPtr3, i), bufferAccessor2[i]);
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), bufferAccessor[j], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr2, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SummonAreaCD>(nativeArrayPtr3, j), bufferAccessor2[j]);
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
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), bufferAccessor[k], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr2, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SummonAreaCD>(nativeArrayPtr3, k), bufferAccessor2[k]);
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), bufferAccessor[l], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr2, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SummonAreaCD>(nativeArrayPtr3, l), bufferAccessor2[l]);
				}
				num >>= 1;
			}
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(RunWithoutJobSystem_00000668_0024PostfixBurstDelegate))]
		public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
		{
			RunWithoutJobSystem_00000668_0024BurstDirectCall.Invoke(ref query, jobPtr);
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void RunWithoutJobSystem_0024BurstManaged(ref EntityQuery query, IntPtr jobPtr)
		{
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<BossSummoningSystem_4A15507E_LambdaJob_0_Job>(jobPtr), ref query);
		}
	}

	private struct TypeHandle
	{
		[ReadOnly]
		public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

		public BufferTypeHandle<AnimationBuffer> __AnimationBuffer_RW_BufferTypeHandle;

		public ComponentTypeHandle<AnimationBufferPointer> __AnimationBufferPointer_RW_ComponentTypeHandle;

		public ComponentTypeHandle<SummonAreaCD> __SummonAreaCD_RW_ComponentTypeHandle;

		[ReadOnly]
		public BufferTypeHandle<NearbyEntitiesBufferCD> __NearbyEntitiesBufferCD_RO_BufferTypeHandle;

		[ReadOnly]
		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ObjectDataCD> __ObjectDataCD_RO_ComponentLookup;

		[ReadOnly]
		public BufferLookup<SummoningItemBuffer> __SummoningItemBuffer_RO_BufferLookup;

		public ComponentLookup<EntityDestroyedCD> __EntityDestroyedCD_RW_ComponentLookup;

		public ComponentLookup<DontDropSelfCD> __DontDropSelfCD_RW_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
			__AnimationBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<AnimationBuffer>();
			__AnimationBufferPointer_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AnimationBufferPointer>();
			__SummonAreaCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<SummonAreaCD>();
			__NearbyEntitiesBufferCD_RO_BufferTypeHandle = state.GetBufferTypeHandle<NearbyEntitiesBufferCD>(isReadOnly: true);
			__Unity_Transforms_LocalTransform_RO_ComponentLookup = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
			__ObjectDataCD_RO_ComponentLookup = state.GetComponentLookup<ObjectDataCD>(isReadOnly: true);
			__SummoningItemBuffer_RO_BufferLookup = state.GetBufferLookup<SummoningItemBuffer>(isReadOnly: true);
			__EntityDestroyedCD_RW_ComponentLookup = state.GetComponentLookup<EntityDestroyedCD>();
			__DontDropSelfCD_RW_ComponentLookup = state.GetComponentLookup<DontDropSelfCD>();
		}
	}

	private const float SYSTEM_UPDATE_COOLDOWN = 0.2f;

	private const float MIN_DISTANCE_SQ_TO_ALLOW_SUMMON_OTHER_BOSS = 4900f;

	private const float MAX_DISTANCE_SQ_TO_SUMMON_ITEM = 4f;

	private float systemTimer;

	private EntityQuery summonedEnemiesQ;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_153593806_0;

	private EntityQuery __query_153593806_1;

	private EntityQuery __query_153593806_2;

	[Preserve]
	protected override void OnCreate()
	{
		NeedDatabase();
		NeedTileDamageBuffer();
		RequireForUpdate<EffectEventBuffer>();
		RequireForUpdate<WorldInfoCD>();
		EntityQueryDesc entityQueryDesc = new EntityQueryDesc();
		entityQueryDesc.All = new ComponentType[2]
		{
			typeof(SummonedEnemyCD),
			typeof(ObjectDataCD)
		};
		entityQueryDesc.Options = EntityQueryOptions.IncludeDisabledEntities;
		EntityQueryDesc entityQueryDesc2 = entityQueryDesc;
		summonedEnemiesQ = GetEntityQuery(entityQueryDesc2);
		base.OnCreate();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		systemTimer -= base.CheckedStateRef.WorldUnmanaged.Time.DeltaTime;
		if (systemTimer <= 0f)
		{
			systemTimer = 0.2f;
			double time = base.CheckedStateRef.WorldUnmanaged.Time.ElapsedTime;
			EntityCommandBuffer ecb = CreateCommandBuffer();
			BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal = database;
			NativeArray<Entity> summonedEnemies = summonedEnemiesQ.ToEntityArray(Allocator.Temp);
			int animIdle = -601574123;
			int animGlow = -360926955;
			int animSpawn = -1878077465;
			Entity effectEventBufferSingleton = __query_153593806_1.GetSingletonEntity();
			AttackSystem.Helper helper = GetAttackHelper();
			Entity tileDamageBufferEntity = tileDamageBufferSingletonEntity;
			BufferLookup<SummoningItemBuffer> bossSummonsBuffer = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__SummoningItemBuffer_RO_BufferLookup, ref base.CheckedStateRef);
			ComponentLookup<EntityDestroyedCD> entityDestroyedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EntityDestroyedCD_RW_ComponentLookup, ref base.CheckedStateRef);
			__query_153593806_2.TryGetSingleton<NetworkTime>(out var value);
			NetworkTick currentTick = value.ServerTick;
			ComponentLookup<DontDropSelfCD> dontDropLootLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DontDropSelfCD_RW_ComponentLookup, ref base.CheckedStateRef);
			BossSummoningSystem_4A15507E_LambdaJob_0_Execute(ref time, ref ecb, ref databaseLocal, ref summonedEnemies, ref animIdle, ref animGlow, ref animSpawn, ref effectEventBufferSingleton, ref helper, ref tileDamageBufferEntity, ref bossSummonsBuffer, ref entityDestroyedLookup, ref currentTick, ref dontDropLootLookup);
			summonedEnemies.Dispose();
		}
		base.OnUpdate();
	}

	private void BossSummoningSystem_4A15507E_LambdaJob_0_Execute(ref double time, ref EntityCommandBuffer ecb, ref BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal, ref NativeArray<Entity> summonedEnemies, ref int animIdle, ref int animGlow, ref int animSpawn, ref Entity effectEventBufferSingleton, ref AttackSystem.Helper attackHelper, ref Entity tileDamageBufferEntity, ref BufferLookup<SummoningItemBuffer> bossSummonsBuffer, ref ComponentLookup<EntityDestroyedCD> entityDestroyedLookup, ref NetworkTick currentTick, ref ComponentLookup<DontDropSelfCD> dontDropLootLookup)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__AnimationBuffer_RW_BufferTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__AnimationBufferPointer_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__SummonAreaCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__NearbyEntitiesBufferCD_RO_BufferTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__ObjectDataCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		BossSummoningSystem_4A15507E_LambdaJob_0_Job value = new BossSummoningSystem_4A15507E_LambdaJob_0_Job
		{
			time = time,
			ecb = ecb,
			databaseLocal = databaseLocal,
			summonedEnemies = summonedEnemies,
			animIdle = animIdle,
			animGlow = animGlow,
			animSpawn = animSpawn,
			effectEventBufferSingleton = effectEventBufferSingleton,
			attackHelper = attackHelper,
			tileDamageBufferEntity = tileDamageBufferEntity,
			bossSummonsBuffer = bossSummonsBuffer,
			entityDestroyedLookup = entityDestroyedLookup,
			currentTick = currentTick,
			dontDropLootLookup = dontDropLootLookup,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__animationTypeHandle = __TypeHandle.__AnimationBuffer_RW_BufferTypeHandle,
			__animationBufferPointerTypeHandle = __TypeHandle.__AnimationBufferPointer_RW_ComponentTypeHandle,
			__summonAreaTypeHandle = __TypeHandle.__SummonAreaCD_RW_ComponentTypeHandle,
			__nearbyEntitiesTypeHandle = __TypeHandle.__NearbyEntitiesBufferCD_RO_BufferTypeHandle,
			__Unity_Transforms_LocalTransform_ComponentLookup = __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup,
			__ObjectDataCD_ComponentLookup = __TypeHandle.__ObjectDataCD_RO_ComponentLookup
		};
		if (!__query_153593806_0.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
			BossSummoningSystem_4A15507E_LambdaJob_0_Job.RunWithoutJobSystem(ref __query_153593806_0, jobPtr);
		}
		time = value.time;
		ecb = value.ecb;
		databaseLocal = value.databaseLocal;
		summonedEnemies = value.summonedEnemies;
		animIdle = value.animIdle;
		animGlow = value.animGlow;
		animSpawn = value.animSpawn;
		effectEventBufferSingleton = value.effectEventBufferSingleton;
		attackHelper = value.attackHelper;
		tileDamageBufferEntity = value.tileDamageBufferEntity;
		bossSummonsBuffer = value.bossSummonsBuffer;
		entityDestroyedLookup = value.entityDestroyedLookup;
		currentTick = value.currentTick;
		dontDropLootLookup = value.dontDropLootLookup;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<NearbyEntitiesBufferCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBufferPointer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<SummonAreaCD>();
		__query_153593806_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<EffectEventBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_153593806_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_153593806_2 = entityQueryBuilder2.Build(ref state);
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
	public BossSummoningSystem()
	{
	}
}
