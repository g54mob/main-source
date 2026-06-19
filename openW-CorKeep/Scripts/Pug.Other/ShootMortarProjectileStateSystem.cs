using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Pug.UnityExtensions;
using PugTilemap;
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
public class ShootMortarProjectileStateSystem : PugSimulationSystemBase
{
	[NoAlias]
	[BurstCompile]
	private struct ShootMortarProjectileStateSystem_53D1C7D8_LambdaJob_0_Job : IJobChunk
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void RunWithoutJobSystem_00003D7B_0024PostfixBurstDelegate(ref EntityQuery query, IntPtr jobPtr);

		internal static class RunWithoutJobSystem_00003D7B_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<RunWithoutJobSystem_00003D7B_0024PostfixBurstDelegate>(RunWithoutJobSystem).Value;
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

		[ReadOnly]
		public NativeArray<int> __ChunkBaseEntityIndices;

		public double time;

		public EntityCommandBuffer ecb;

		public BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal;

		public int attackAnimID;

		public int attackedAnimID;

		[ReadOnly]
		public BufferLookup<SummarizedConditionsBuffer> conditionsBufferLookup;

		public ConditionsTableCD conditionsTableLocal;

		public Unity.Mathematics.Random rnd;

		[ReadOnly]
		public TileAccessor tileLookUp;

		[ReadOnly]
		public BufferLookup<TargetMortarPositionBuffer> targetShootBuffer;

		[ReadOnly]
		public BufferLookup<NewCombatantsBuffer> newCombatantsBuffer;

		[ReadOnly]
		public ComponentLookup<EntityDestroyedCD> entityDestroyedLookup;

		public ComponentLookup<MortarProjectileDamageEffectCD> mortarProjectileDamageEffectLookup;

		public ComponentLookup<RandomCD> randomLookup;

		public NetworkTick currentTick;

		public ComponentLookup<AnimationBufferPointer> animationBufferPointerLookup;

		[ReadOnly]
		public ComponentLookup<LevelCD> levelLookup;

		[ReadOnly]
		public ComponentLookup<EnrageStateCD> enrageStateLookup;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		public ComponentTypeHandle<StateInfoCD> __stateInfoTypeHandle;

		public ComponentTypeHandle<ShootMortarProjectileStateCD> __shootStateTypeHandle;

		public BufferTypeHandle<MortarShotsBuffer> __mortarShotsBufferTypeHandle;

		public BufferTypeHandle<AnimationBuffer> __animationBufferTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<LocalTransform> __transformTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<BehaviourTagsCD> __attackTagsTypeHandle;

		[ReadOnly]
		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<AmountOfTimesTakingDamageCounterCD> __AmountOfTimesTakingDamageCounterCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<MortarProjectileCD> __MortarProjectileCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<FactionCD> __FactionCD_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, int entityInQueryIndex, [NoAlias] ref StateInfoCD stateInfo, [NoAlias] ref ShootMortarProjectileStateCD shootState, DynamicBuffer<MortarShotsBuffer> mortarShotsBuffer, DynamicBuffer<AnimationBuffer> animationBuffer, [NoAlias] in LocalTransform transform, [NoAlias] in BehaviourTagsCD attackTags)
		{
			if (!stateInfo.IsCurrentState(StateID.ShootMortarProjectile))
			{
				if (mortarShotsBuffer.Length <= 0)
				{
					return;
				}
				if (shootState.destroyProjectilesWhenNotInState)
				{
					for (int i = 0; i < mortarShotsBuffer.Length; i++)
					{
						if (__Unity_Transforms_LocalTransform_ComponentLookup.HasComponent(mortarShotsBuffer[i].entity))
						{
							ecb.DestroyEntity(mortarShotsBuffer[i].entity);
						}
					}
				}
				mortarShotsBuffer.Clear();
				return;
			}
			if (shootState.aimingAtEntity != Entity.Null && __Unity_Transforms_LocalTransform_ComponentLookup.HasComponent(shootState.aimingAtEntity) && (!entityDestroyedLookup.HasComponent(shootState.aimingAtEntity) || !entityDestroyedLookup.IsComponentEnabled(shootState.aimingAtEntity)) && (shootState.internalState == 0 || shootState.internalState == 1))
			{
				float3 position = __Unity_Transforms_LocalTransform_ComponentLookup[shootState.aimingAtEntity].Position;
				shootState.shootPosition = position;
			}
			float num = math.distancesq(shootState.shootPosition, transform.Position);
			if (num < shootState.minMaxDistanceToTargetToShootSqr.x || num > shootState.minMaxDistanceToTargetToShootSqr.y)
			{
				stateInfo.LeaveState();
				return;
			}
			if (shootState.internalState == 1 && shootState.keepShootingUntilTakingDamageXTimes > 0 && __AmountOfTimesTakingDamageCounterCD_ComponentLookup.HasComponent(entity) && shootState.damageTakenCountOnStartingToShoot + shootState.keepShootingUntilTakingDamageXTimes <= __AmountOfTimesTakingDamageCounterCD_ComponentLookup[entity].count)
			{
				shootState.internalTimer.Start(time, 0f);
				shootState.internalState = 2;
			}
			RefRW<AnimationBufferPointer> refRW;
			if (shootState.internalState == 0 && !shootState.internalTimer.isRunning)
			{
				refRW = animationBufferPointerLookup.GetRefRW(entity);
				ref AnimationBufferPointer valueRW = ref refRW.ValueRW;
				AnimationUtilities.TriggerAnimation((shootState.overrideAnimID != 0) ? shootState.overrideAnimID : attackAnimID, currentTick, animationBuffer, ref valueRW);
				shootState.internalTimer.Start(time, shootState.anticipationDuration);
				shootState.internalState = 1;
				if (newCombatantsBuffer.HasComponent(shootState.aimingAtEntity))
				{
					ecb.AppendToBuffer(shootState.aimingAtEntity, new NewCombatantsBuffer
					{
						Target = entity
					});
				}
				if (shootState.keepShootingUntilTakingDamageXTimes > 0 && __AmountOfTimesTakingDamageCounterCD_ComponentLookup.HasComponent(entity))
				{
					shootState.damageTakenCountOnStartingToShoot = __AmountOfTimesTakingDamageCounterCD_ComponentLookup[entity].count;
				}
			}
			else if (shootState.internalState == 1 && shootState.internalTimer.isRunning && shootState.internalTimer.IsTimerElapsed(time))
			{
				Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(shootState.mortarProjectileID, databaseLocal);
				if (__MortarProjectileCD_ComponentLookup.HasComponent(primaryPrefabEntity))
				{
					levelLookup.TryGetComponent(entity, out var componentData);
					int num2 = (int)math.min((float)shootState.maxProjectilesShotPerWave * math.pow(shootState.maxProjectilesShotPerWaveMultiplier, shootState.waveCount), shootState.projectilesToSpawn - shootState.projectilesSpawned);
					NativeList<int2> nativeList = new NativeList<int2>(Allocator.Temp);
					for (int j = 0; j < num2; j++)
					{
						float3 float5 = shootState.shootPosition;
						if (shootState.shootAtSelf)
						{
							float5 = transform.Position;
						}
						if (shootState.lineFromShooterToTarget)
						{
							int projectilesSpawned = shootState.projectilesSpawned;
							float lineLengthMultiplier = shootState.lineLengthMultiplier;
							float3 float6 = shootState.initialShootPosition;
							if (shootState.lineBendTowardTarget)
							{
								float6 = shootState.shootPosition;
							}
							float3 float7 = math.normalizesafe(float6 - transform.Position);
							float num3 = (float)projectilesSpawned / (float)shootState.projectilesToSpawn;
							float3 float8 = ((!(rnd.NextFloat() > 0.5f)) ? 1 : (-1)) * math.cross(float7, math.up()).xz.ToFloat3();
							float5 = transform.Position + float7 * shootState.lineLengthStartPositionPadding + (float)projectilesSpawned * lineLengthMultiplier * float7 + float8 * shootState.lineScatterMultiplier * num3;
						}
						if (shootState.overridePositionToShootAt)
						{
							float5 = shootState.overrideShootPosition;
						}
						bool flag = false;
						if (targetShootBuffer.HasComponent(entity) && targetShootBuffer[entity].Length > shootState.projectilesSpawned)
						{
							float5 += targetShootBuffer[entity][shootState.projectilesSpawned].position;
							flag = true;
						}
						else if (shootState.maxRandomSpreadDistance > 0f)
						{
							for (int k = 0; k < 10; k++)
							{
								float3 float9 = new float3(rnd.NextFloat(-1f, 1f), 0f, rnd.NextFloat(-1f, 1f));
								float9 *= rnd.NextFloat(shootState.maxRandomSpreadDistance - shootState.minRandomSpreadDistance);
								float9 += math.normalizesafe(float9) * shootState.minRandomSpreadDistance;
								float5 += float9;
								int2 int5 = float5.RoundToInt2();
								bool flag2 = false;
								if (shootState.dontAllowOverlappingShots)
								{
									for (int l = 0; l < mortarShotsBuffer.Length; l++)
									{
										if (__Unity_Transforms_LocalTransform_ComponentLookup.HasComponent(mortarShotsBuffer[l].entity) && math.all(__Unity_Transforms_LocalTransform_ComponentLookup[mortarShotsBuffer[l].entity].Position.RoundToInt2() == int5))
										{
											flag2 = true;
											break;
										}
									}
									if (!flag2)
									{
										for (int m = 0; m < nativeList.Length; m++)
										{
											if (math.all(nativeList[m] == int5))
											{
												flag2 = true;
												break;
											}
										}
									}
								}
								if (!flag2)
								{
									TileType topType = tileLookUp.GetTopType(float5.RoundToInt2());
									if (topType.IsWalkableTile() || (shootState.canShootOnWaterAndPits && !topType.IsWallTile()))
									{
										float5 = new float3(int5.x, 0f, int5.y);
										nativeList.Add(float5.RoundToInt2());
										flag = true;
										break;
									}
								}
							}
						}
						else
						{
							flag = true;
						}
						if (math.distancesq(transform.Position, float5) > 2500f)
						{
							flag = false;
						}
						if (flag)
						{
							FactionCD faction = (__FactionCD_ComponentLookup.HasComponent(entity) ? __FactionCD_ComponentLookup[entity] : default(FactionCD));
							MortarProjectileCD projectile = __MortarProjectileCD_ComponentLookup[primaryPrefabEntity];
							RefRW<RandomCD> refRW2 = randomLookup.GetRefRW(entity);
							Entity entity2 = EntityUtility.SpawnMortarProjectile(ecb, transform.Position, databaseLocal, shootState.mortarProjectileID, shootState.mortarDamage, shootState.hitTiles, shootState.mortarTileDamage, float5, entity, projectile, shootState.goUpTime, shootState.airTime + shootState.airTimeAdditionBetweenProjectiles * (float)shootState.projectilesSpawned, shootState.goDownTime, shootState.explodeTime, componentData.level, shootState.canShootOnWaterAndPits, attackTags, conditionsBufferLookup, faction, conditionsTableLocal, ref refRW2.ValueRW, mortarProjectileDamageEffectLookup);
							if (entity2 != Entity.Null)
							{
								ecb.AppendToBuffer(entity, new MortarShotsBuffer
								{
									entity = entity2
								});
								if (shootState.playAttackFireAnimation)
								{
									refRW = animationBufferPointerLookup.GetRefRW(entity);
									ref AnimationBufferPointer valueRW2 = ref refRW.ValueRW;
									AnimationUtilities.TriggerAnimation(attackedAnimID, currentTick, animationBuffer, ref valueRW2);
								}
							}
						}
						shootState.projectilesSpawned++;
					}
					nativeList.Dispose();
				}
				shootState.waveCount++;
				if (shootState.projectilesSpawned >= shootState.projectilesToSpawn)
				{
					shootState.internalTimer.Start(time, shootState.attackDuration);
					shootState.internalState = 2;
				}
				else
				{
					shootState.internalTimer.Start(time, shootState.timeBetweenProjectiles);
				}
			}
			else if (shootState.internalState == 2 && shootState.internalTimer.isRunning && shootState.internalTimer.IsTimerElapsed(time))
			{
				Unity.Mathematics.Random random = Unity.Mathematics.Random.CreateFromIndex((uint)((double)entityInQueryIndex + time + 1.0));
				SetCooldown(entity, time, ref shootState, enrageStateLookup, ref random);
				stateInfo.LeaveState();
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __stateInfoTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __shootStateTypeHandle);
			BufferAccessor<MortarShotsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __mortarShotsBufferTypeHandle);
			BufferAccessor<AnimationBuffer> bufferAccessor2 = chunk.GetBufferAccessor(ref __animationBufferTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __transformTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __attackTagsTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					int entityInQueryIndex = __ChunkBaseEntityIndices[batchIndex] + num++;
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), entityInQueryIndex, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ShootMortarProjectileStateCD>(nativeArrayPtr3, i), bufferAccessor[i], bufferAccessor2[i], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr4, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr5, i));
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
						int entityInQueryIndex2 = __ChunkBaseEntityIndices[batchIndex] + num++;
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), entityInQueryIndex2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ShootMortarProjectileStateCD>(nativeArrayPtr3, j), bufferAccessor[j], bufferAccessor2[j], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr4, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr5, j));
					}
				}
				return;
			}
			ulong num2 = chunkEnabledMask.ULong0;
			int num3 = math.min(64, count);
			for (int k = 0; k < num3; k++)
			{
				if ((num2 & 1) != 0L)
				{
					int entityInQueryIndex3 = __ChunkBaseEntityIndices[batchIndex] + num++;
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), entityInQueryIndex3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ShootMortarProjectileStateCD>(nativeArrayPtr3, k), bufferAccessor[k], bufferAccessor2[k], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr4, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr5, k));
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num2 & 1) != 0L)
				{
					int entityInQueryIndex4 = __ChunkBaseEntityIndices[batchIndex] + num++;
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), entityInQueryIndex4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ShootMortarProjectileStateCD>(nativeArrayPtr3, l), bufferAccessor[l], bufferAccessor2[l], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr4, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr5, l));
				}
				num2 >>= 1;
			}
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(RunWithoutJobSystem_00003D7B_0024PostfixBurstDelegate))]
		public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
		{
			RunWithoutJobSystem_00003D7B_0024BurstDirectCall.Invoke(ref query, jobPtr);
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void RunWithoutJobSystem_0024BurstManaged(ref EntityQuery query, IntPtr jobPtr)
		{
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<ShootMortarProjectileStateSystem_53D1C7D8_LambdaJob_0_Job>(jobPtr), ref query);
		}
	}

	private struct TypeHandle
	{
		[ReadOnly]
		public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

		public ComponentTypeHandle<StateInfoCD> __StateInfoCD_RW_ComponentTypeHandle;

		public ComponentTypeHandle<ShootMortarProjectileStateCD> __ShootMortarProjectileStateCD_RW_ComponentTypeHandle;

		public BufferTypeHandle<MortarShotsBuffer> __MortarShotsBuffer_RW_BufferTypeHandle;

		public BufferTypeHandle<AnimationBuffer> __AnimationBuffer_RW_BufferTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<BehaviourTagsCD> __BehaviourTagsCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<AmountOfTimesTakingDamageCounterCD> __AmountOfTimesTakingDamageCounterCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<MortarProjectileCD> __MortarProjectileCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<FactionCD> __FactionCD_RO_ComponentLookup;

		[ReadOnly]
		public BufferLookup<SummarizedConditionsBuffer> __SummarizedConditionsBuffer_RO_BufferLookup;

		public BufferLookup<TargetMortarPositionBuffer> __TargetMortarPositionBuffer_RW_BufferLookup;

		[ReadOnly]
		public BufferLookup<NewCombatantsBuffer> __NewCombatantsBuffer_RO_BufferLookup;

		[ReadOnly]
		public ComponentLookup<EntityDestroyedCD> __EntityDestroyedCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<MortarProjectileDamageEffectCD> __MortarProjectileDamageEffectCD_RO_ComponentLookup;

		public ComponentLookup<RandomCD> __RandomCD_RW_ComponentLookup;

		public ComponentLookup<AnimationBufferPointer> __AnimationBufferPointer_RW_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<LevelCD> __LevelCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<EnrageStateCD> __EnrageStateCD_RO_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
			__StateInfoCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<StateInfoCD>();
			__ShootMortarProjectileStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<ShootMortarProjectileStateCD>();
			__MortarShotsBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<MortarShotsBuffer>();
			__AnimationBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<AnimationBuffer>();
			__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
			__BehaviourTagsCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<BehaviourTagsCD>(isReadOnly: true);
			__Unity_Transforms_LocalTransform_RO_ComponentLookup = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
			__AmountOfTimesTakingDamageCounterCD_RO_ComponentLookup = state.GetComponentLookup<AmountOfTimesTakingDamageCounterCD>(isReadOnly: true);
			__MortarProjectileCD_RO_ComponentLookup = state.GetComponentLookup<MortarProjectileCD>(isReadOnly: true);
			__FactionCD_RO_ComponentLookup = state.GetComponentLookup<FactionCD>(isReadOnly: true);
			__SummarizedConditionsBuffer_RO_BufferLookup = state.GetBufferLookup<SummarizedConditionsBuffer>(isReadOnly: true);
			__TargetMortarPositionBuffer_RW_BufferLookup = state.GetBufferLookup<TargetMortarPositionBuffer>();
			__NewCombatantsBuffer_RO_BufferLookup = state.GetBufferLookup<NewCombatantsBuffer>(isReadOnly: true);
			__EntityDestroyedCD_RO_ComponentLookup = state.GetComponentLookup<EntityDestroyedCD>(isReadOnly: true);
			__MortarProjectileDamageEffectCD_RO_ComponentLookup = state.GetComponentLookup<MortarProjectileDamageEffectCD>(isReadOnly: true);
			__RandomCD_RW_ComponentLookup = state.GetComponentLookup<RandomCD>();
			__AnimationBufferPointer_RW_ComponentLookup = state.GetComponentLookup<AnimationBufferPointer>();
			__LevelCD_RO_ComponentLookup = state.GetComponentLookup<LevelCD>(isReadOnly: true);
			__EnrageStateCD_RO_ComponentLookup = state.GetComponentLookup<EnrageStateCD>(isReadOnly: true);
		}
	}

	private ConditionsTableCD conditionsTable;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_579808520_0;

	private EntityQuery __query_579808520_1;

	private EntityQuery __query_579808520_2;

	[Preserve]
	protected override void OnCreate()
	{
		NeedDatabase();
		RequireForUpdate<EffectEventBuffer>();
		RequireForUpdate<ConditionsTableCD>();
		RequireForUpdate<ShootMortarProjectileStateCD>();
		base.OnCreate();
	}

	[Preserve]
	protected override void OnStartRunning()
	{
		conditionsTable = __query_579808520_1.GetSingleton<ConditionsTableCD>();
		base.OnStartRunning();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		double time = base.CheckedStateRef.WorldUnmanaged.Time.ElapsedTime;
		EntityCommandBuffer ecb = CreateCommandBuffer();
		BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal = database;
		int attackAnimID = 1203776827;
		int attackedAnimID = -871297121;
		BufferLookup<SummarizedConditionsBuffer> conditionsBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__SummarizedConditionsBuffer_RO_BufferLookup, ref base.CheckedStateRef);
		ConditionsTableCD conditionsTableLocal = conditionsTable;
		Unity.Mathematics.Random rnd = PugRandom.GetRng();
		TileAccessor tileLookUp = CreateTileAccessor();
		BufferLookup<TargetMortarPositionBuffer> targetShootBuffer = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__TargetMortarPositionBuffer_RW_BufferLookup, ref base.CheckedStateRef);
		BufferLookup<NewCombatantsBuffer> newCombatantsBuffer = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__NewCombatantsBuffer_RO_BufferLookup, ref base.CheckedStateRef);
		ComponentLookup<EntityDestroyedCD> entityDestroyedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EntityDestroyedCD_RO_ComponentLookup, ref base.CheckedStateRef);
		ComponentLookup<MortarProjectileDamageEffectCD> mortarProjectileDamageEffectLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MortarProjectileDamageEffectCD_RO_ComponentLookup, ref base.CheckedStateRef);
		ComponentLookup<RandomCD> randomLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__RandomCD_RW_ComponentLookup, ref base.CheckedStateRef);
		__query_579808520_2.TryGetSingleton<NetworkTime>(out var value);
		NetworkTick currentTick = value.ServerTick;
		ComponentLookup<AnimationBufferPointer> animationBufferPointerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__AnimationBufferPointer_RW_ComponentLookup, ref base.CheckedStateRef);
		ComponentLookup<LevelCD> levelLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__LevelCD_RO_ComponentLookup, ref base.CheckedStateRef);
		ComponentLookup<EnrageStateCD> enrageStateLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EnrageStateCD_RO_ComponentLookup, ref base.CheckedStateRef);
		ShootMortarProjectileStateSystem_53D1C7D8_LambdaJob_0_Execute(ref time, ref ecb, ref databaseLocal, ref attackAnimID, ref attackedAnimID, ref conditionsBufferLookup, ref conditionsTableLocal, ref rnd, ref tileLookUp, ref targetShootBuffer, ref newCombatantsBuffer, ref entityDestroyedLookup, ref mortarProjectileDamageEffectLookup, ref randomLookup, ref currentTick, ref animationBufferPointerLookup, ref levelLookup, ref enrageStateLookup);
		base.OnUpdate();
	}

	public static void SetCooldown(Entity entity, double time, ref ShootMortarProjectileStateCD shootState, ComponentLookup<EnrageStateCD> enrageStateLookup, ref Unity.Mathematics.Random rnd)
	{
		float num = rnd.NextFloat(shootState.minCooldown, shootState.maxCooldown);
		if (enrageStateLookup.TryGetComponent(entity, out var componentData) && componentData.isEnraged)
		{
			num /= 2f;
		}
		shootState.cooldownTimer.Start(time, num);
	}

	private void ShootMortarProjectileStateSystem_53D1C7D8_LambdaJob_0_Execute(ref double time, ref EntityCommandBuffer ecb, ref BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal, ref int attackAnimID, ref int attackedAnimID, ref BufferLookup<SummarizedConditionsBuffer> conditionsBufferLookup, ref ConditionsTableCD conditionsTableLocal, ref Unity.Mathematics.Random rnd, ref TileAccessor tileLookUp, ref BufferLookup<TargetMortarPositionBuffer> targetShootBuffer, ref BufferLookup<NewCombatantsBuffer> newCombatantsBuffer, ref ComponentLookup<EntityDestroyedCD> entityDestroyedLookup, ref ComponentLookup<MortarProjectileDamageEffectCD> mortarProjectileDamageEffectLookup, ref ComponentLookup<RandomCD> randomLookup, ref NetworkTick currentTick, ref ComponentLookup<AnimationBufferPointer> animationBufferPointerLookup, ref ComponentLookup<LevelCD> levelLookup, ref ComponentLookup<EnrageStateCD> enrageStateLookup)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__StateInfoCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__ShootMortarProjectileStateCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__MortarShotsBuffer_RW_BufferTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__AnimationBuffer_RW_BufferTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__BehaviourTagsCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__AmountOfTimesTakingDamageCounterCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__MortarProjectileCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__FactionCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		ShootMortarProjectileStateSystem_53D1C7D8_LambdaJob_0_Job value = new ShootMortarProjectileStateSystem_53D1C7D8_LambdaJob_0_Job
		{
			time = time,
			ecb = ecb,
			databaseLocal = databaseLocal,
			attackAnimID = attackAnimID,
			attackedAnimID = attackedAnimID,
			conditionsBufferLookup = conditionsBufferLookup,
			conditionsTableLocal = conditionsTableLocal,
			rnd = rnd,
			tileLookUp = tileLookUp,
			targetShootBuffer = targetShootBuffer,
			newCombatantsBuffer = newCombatantsBuffer,
			entityDestroyedLookup = entityDestroyedLookup,
			mortarProjectileDamageEffectLookup = mortarProjectileDamageEffectLookup,
			randomLookup = randomLookup,
			currentTick = currentTick,
			animationBufferPointerLookup = animationBufferPointerLookup,
			levelLookup = levelLookup,
			enrageStateLookup = enrageStateLookup,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__stateInfoTypeHandle = __TypeHandle.__StateInfoCD_RW_ComponentTypeHandle,
			__shootStateTypeHandle = __TypeHandle.__ShootMortarProjectileStateCD_RW_ComponentTypeHandle,
			__mortarShotsBufferTypeHandle = __TypeHandle.__MortarShotsBuffer_RW_BufferTypeHandle,
			__animationBufferTypeHandle = __TypeHandle.__AnimationBuffer_RW_BufferTypeHandle,
			__transformTypeHandle = __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle,
			__attackTagsTypeHandle = __TypeHandle.__BehaviourTagsCD_RO_ComponentTypeHandle,
			__Unity_Transforms_LocalTransform_ComponentLookup = __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup,
			__AmountOfTimesTakingDamageCounterCD_ComponentLookup = __TypeHandle.__AmountOfTimesTakingDamageCounterCD_RO_ComponentLookup,
			__MortarProjectileCD_ComponentLookup = __TypeHandle.__MortarProjectileCD_RO_ComponentLookup,
			__FactionCD_ComponentLookup = __TypeHandle.__FactionCD_RO_ComponentLookup
		};
		value.__ChunkBaseEntityIndices = __query_579808520_0.CalculateBaseEntityIndexArray(base.CheckedStateRef.WorldUpdateAllocator);
		if (!__query_579808520_0.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
			ShootMortarProjectileStateSystem_53D1C7D8_LambdaJob_0_Job.RunWithoutJobSystem(ref __query_579808520_0, jobPtr);
		}
		time = value.time;
		ecb = value.ecb;
		databaseLocal = value.databaseLocal;
		attackAnimID = value.attackAnimID;
		attackedAnimID = value.attackedAnimID;
		conditionsBufferLookup = value.conditionsBufferLookup;
		conditionsTableLocal = value.conditionsTableLocal;
		rnd = value.rnd;
		tileLookUp = value.tileLookUp;
		targetShootBuffer = value.targetShootBuffer;
		newCombatantsBuffer = value.newCombatantsBuffer;
		entityDestroyedLookup = value.entityDestroyedLookup;
		mortarProjectileDamageEffectLookup = value.mortarProjectileDamageEffectLookup;
		randomLookup = value.randomLookup;
		currentTick = value.currentTick;
		animationBufferPointerLookup = value.animationBufferPointerLookup;
		levelLookup = value.levelLookup;
		enrageStateLookup = value.enrageStateLookup;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<LocalTransform>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<BehaviourTagsCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<StateInfoCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ShootMortarProjectileStateCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<MortarShotsBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBuffer>();
		__query_579808520_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ConditionsTableCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_579808520_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_579808520_2 = entityQueryBuilder2.Build(ref state);
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
	public ShootMortarProjectileStateSystem()
	{
	}
}
