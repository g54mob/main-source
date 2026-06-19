using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using EnvironmentEvents.Components;
using Inventory;
using PlayerState;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Physics;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Scripting;

namespace PlayerCommand
{
	[UpdateBefore(typeof(SetupRandomSystem))]
	[UpdateInGroup(typeof(RunSimulationSystemGroup), OrderFirst = true)]
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
	public class ServerSystem : PugSimulationSystemBase
	{
		private struct ServerSystem_4A171A05_LambdaJob_0_Job : IJobChunk
		{
			public ServerSystem __this;

			[ReadOnly]
			public ComponentTypeHandle<UpdatePlayerCustomizationRpc> __rpcTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<ReceiveRpcCommandRequest> __rpcSourceTypeHandle;

			public ComponentLookup<PlayerCustomizationCD> __PlayerCustomizationCD_ComponentLookup;

			private void OriginalLambdaBody(in UpdatePlayerCustomizationRpc rpc, in ReceiveRpcCommandRequest rpcSource)
			{
				if (__PlayerCustomizationCD_ComponentLookup.HasComponent(rpc.entity))
				{
					PlayerCustomizationCD value = __PlayerCustomizationCD_ComponentLookup[rpc.entity];
					value.customization = PlayerCustomizationNetcode.ConvertFromAddress(rpc.playerCustomization);
					value.triggerCount++;
					__PlayerCustomizationCD_ComponentLookup[rpc.entity] = value;
					Manager.networking.OnPlayerNameChange(rpc.playerCustomization.name.ToString(), rpcSource.SourceConnection, __this.World);
				}
				else
				{
					Debug.LogError("Got update player customization rpc on entity without customization");
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __rpcTypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __rpcSourceTypeHandle);
				int count = chunk.Count;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						OriginalLambdaBody(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<UpdatePlayerCustomizationRpc>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ReceiveRpcCommandRequest>(nativeArrayPtr2, i));
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
							OriginalLambdaBody(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<UpdatePlayerCustomizationRpc>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ReceiveRpcCommandRequest>(nativeArrayPtr2, j));
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
						OriginalLambdaBody(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<UpdatePlayerCustomizationRpc>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ReceiveRpcCommandRequest>(nativeArrayPtr2, k));
					}
					num >>= 1;
				}
				num = chunkEnabledMask.ULong1;
				for (int l = 64; l < count; l++)
				{
					if ((num & 1) != 0L)
					{
						OriginalLambdaBody(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<UpdatePlayerCustomizationRpc>(nativeArrayPtr, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ReceiveRpcCommandRequest>(nativeArrayPtr2, l));
					}
					num >>= 1;
				}
			}

			public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
			{
				InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<ServerSystem_4A171A05_LambdaJob_0_Job>(jobPtr), ref query);
			}

			void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
			}
		}

		private struct TypeHandle
		{
			[ReadOnly]
			public ComponentTypeHandle<UpdatePlayerCustomizationRpc> __PlayerCommand_UpdatePlayerCustomizationRpc_RO_ComponentTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<ReceiveRpcCommandRequest> __Unity_NetCode_ReceiveRpcCommandRequest_RO_ComponentTypeHandle;

			public ComponentLookup<PlayerCustomizationCD> __PlayerCustomizationCD_RW_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<ConnectionAdminLevelCD> __ConnectionAdminLevelCD_RO_ComponentLookup;

			public ComponentLookup<DontDropLootCD> __DontDropLootCD_RW_ComponentLookup;

			public ComponentLookup<DontDropSelfCD> __DontDropSelfCD_RW_ComponentLookup;

			public BufferLookup<SkillBuffer> __SkillBuffer_RW_BufferLookup;

			public ComponentLookup<DealDamageToCrittersCD> __DealDamageToCrittersCD_RW_ComponentLookup;

			public BufferLookup<SkillConditionsBuffer> __SkillConditionsBuffer_RW_BufferLookup;

			public ComponentLookup<PlayerStateCD> __PlayerState_PlayerStateCD_RW_ComponentLookup;

			public ComponentLookup<PlayerOrientationCD> __PlayerOrientationCD_RW_ComponentLookup;

			public BufferLookup<InventoryChangeBuffer> __Inventory_InventoryChangeBuffer_RW_BufferLookup;

			public ComponentLookup<HealthCD> __HealthCD_RW_ComponentLookup;

			public ComponentLookup<DeathStateCD> __PlayerState_DeathStateCD_RW_ComponentLookup;

			public ComponentLookup<EntityDestroyedCD> __EntityDestroyedCD_RW_ComponentLookup;

			public ComponentLookup<KilledByPlayerCD> __KilledByPlayerCD_RW_ComponentLookup;

			public ComponentLookup<PlantCD> __PlantCD_RW_ComponentLookup;

			[ReadOnly]
			public BufferLookup<SummarizedConditionEffectsBuffer> __SummarizedConditionEffectsBuffer_RO_BufferLookup;

			public ComponentLookup<GodModeCD> __GodModeCD_RW_ComponentLookup;

			public ComponentLookup<MoveToPredictedByEntityDestroyedCD> __MoveToPredictedByEntityDestroyedCD_RW_ComponentLookup;

			[ReadOnly]
			public BufferLookup<SummarizedConditionsBuffer> __SummarizedConditionsBuffer_RO_BufferLookup;

			public ComponentLookup<MortarProjectileDamageEffectCD> __MortarProjectileDamageEffectCD_RW_ComponentLookup;

			public ComponentLookup<FactionCD> __FactionCD_RW_ComponentLookup;

			public ComponentLookup<BehaviourTagsCD> __BehaviourTagsCD_RW_ComponentLookup;

			public ComponentLookup<MortarProjectileCD> __MortarProjectileCD_RW_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<BossCD> __BossCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<SpawnedByStreamIntegrationCD> __SpawnedByStreamIntegrationCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<ObjectCategoryTagsCD> __ObjectCategoryTagsCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<PlayerInvincibilityCD> __PlayerInvincibilityCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<NetworkId> __Unity_NetCode_NetworkId_RO_ComponentLookup;

			public ComponentLookup<ManaCD> __ManaCD_RW_ComponentLookup;

			public BufferLookup<CraftBuffer> __Inventory_CraftBuffer_RW_BufferLookup;

			public BufferLookup<TileUpdateBuffer> __TileUpdateBuffer_RW_BufferLookup;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__PlayerCommand_UpdatePlayerCustomizationRpc_RO_ComponentTypeHandle = state.GetComponentTypeHandle<UpdatePlayerCustomizationRpc>(isReadOnly: true);
				__Unity_NetCode_ReceiveRpcCommandRequest_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ReceiveRpcCommandRequest>(isReadOnly: true);
				__PlayerCustomizationCD_RW_ComponentLookup = state.GetComponentLookup<PlayerCustomizationCD>();
				__ConnectionAdminLevelCD_RO_ComponentLookup = state.GetComponentLookup<ConnectionAdminLevelCD>(isReadOnly: true);
				__DontDropLootCD_RW_ComponentLookup = state.GetComponentLookup<DontDropLootCD>();
				__DontDropSelfCD_RW_ComponentLookup = state.GetComponentLookup<DontDropSelfCD>();
				__SkillBuffer_RW_BufferLookup = state.GetBufferLookup<SkillBuffer>();
				__DealDamageToCrittersCD_RW_ComponentLookup = state.GetComponentLookup<DealDamageToCrittersCD>();
				__SkillConditionsBuffer_RW_BufferLookup = state.GetBufferLookup<SkillConditionsBuffer>();
				__PlayerState_PlayerStateCD_RW_ComponentLookup = state.GetComponentLookup<PlayerStateCD>();
				__PlayerOrientationCD_RW_ComponentLookup = state.GetComponentLookup<PlayerOrientationCD>();
				__Inventory_InventoryChangeBuffer_RW_BufferLookup = state.GetBufferLookup<InventoryChangeBuffer>();
				__HealthCD_RW_ComponentLookup = state.GetComponentLookup<HealthCD>();
				__PlayerState_DeathStateCD_RW_ComponentLookup = state.GetComponentLookup<DeathStateCD>();
				__EntityDestroyedCD_RW_ComponentLookup = state.GetComponentLookup<EntityDestroyedCD>();
				__KilledByPlayerCD_RW_ComponentLookup = state.GetComponentLookup<KilledByPlayerCD>();
				__PlantCD_RW_ComponentLookup = state.GetComponentLookup<PlantCD>();
				__SummarizedConditionEffectsBuffer_RO_BufferLookup = state.GetBufferLookup<SummarizedConditionEffectsBuffer>(isReadOnly: true);
				__GodModeCD_RW_ComponentLookup = state.GetComponentLookup<GodModeCD>();
				__MoveToPredictedByEntityDestroyedCD_RW_ComponentLookup = state.GetComponentLookup<MoveToPredictedByEntityDestroyedCD>();
				__SummarizedConditionsBuffer_RO_BufferLookup = state.GetBufferLookup<SummarizedConditionsBuffer>(isReadOnly: true);
				__MortarProjectileDamageEffectCD_RW_ComponentLookup = state.GetComponentLookup<MortarProjectileDamageEffectCD>();
				__FactionCD_RW_ComponentLookup = state.GetComponentLookup<FactionCD>();
				__BehaviourTagsCD_RW_ComponentLookup = state.GetComponentLookup<BehaviourTagsCD>();
				__MortarProjectileCD_RW_ComponentLookup = state.GetComponentLookup<MortarProjectileCD>();
				__BossCD_RO_ComponentLookup = state.GetComponentLookup<BossCD>(isReadOnly: true);
				__SpawnedByStreamIntegrationCD_RO_ComponentLookup = state.GetComponentLookup<SpawnedByStreamIntegrationCD>(isReadOnly: true);
				__ObjectCategoryTagsCD_RO_ComponentLookup = state.GetComponentLookup<ObjectCategoryTagsCD>(isReadOnly: true);
				__PlayerInvincibilityCD_RO_ComponentLookup = state.GetComponentLookup<PlayerInvincibilityCD>(isReadOnly: true);
				__Unity_NetCode_NetworkId_RO_ComponentLookup = state.GetComponentLookup<NetworkId>(isReadOnly: true);
				__ManaCD_RW_ComponentLookup = state.GetComponentLookup<ManaCD>();
				__Inventory_CraftBuffer_RW_BufferLookup = state.GetBufferLookup<CraftBuffer>();
				__TileUpdateBuffer_RW_BufferLookup = state.GetBufferLookup<TileUpdateBuffer>();
			}
		}

		private EntityQuery _rpcQuery;

		private EntityQuery _debugRpcQuery;

		private EntityQuery _textRpcQuery;

		private Entity _inventoryChangeBufferEntity;

		private Entity _craftBufferEntity;

		private EntityQuery _updatePlayerCustomizationRpcQuery;

		private Dictionary<long, StringBuilder> _textRpcLookup = new Dictionary<long, StringBuilder>();

		private TypeHandle __TypeHandle;

		private EntityQuery __query_1290592712_0;

		private EntityQuery __query_1290592712_1;

		private EntityQuery __query_1290592712_2;

		private EntityQuery __query_1290592712_3;

		private EntityQuery __query_1290592712_4;

		private EntityQuery __query_1290592712_5;

		private EntityQuery __query_1290592712_6;

		private EntityQuery __query_1290592712_7;

		private EntityQuery __query_1290592712_8;

		private EntityQuery __query_1290592712_9;

		[Preserve]
		protected override void OnCreate()
		{
			UpdatesInRunGroup();
			NeedDatabase();
			NeedLootBank();
			NeedTileUpdateBuffer();
			NeedTileDamageBuffer();
			RequireForUpdate(__query_1290592712_1);
			RequireForUpdate<ConditionsTableCD>();
			RequireForUpdate<InventoryChangeBuffer>();
			RequireForUpdate<KilledEnemiesBuffer>();
			_rpcQuery = GetEntityQuery(typeof(Rpc), typeof(ReceiveRpcCommandRequest));
			_debugRpcQuery = GetEntityQuery(typeof(DebugRpc), typeof(ReceiveRpcCommandRequest));
			_textRpcQuery = GetEntityQuery(typeof(TextRpc), typeof(ReceiveRpcCommandRequest));
			_updatePlayerCustomizationRpcQuery = GetEntityQuery(typeof(UpdatePlayerCustomizationRpc), typeof(ReceiveRpcCommandRequest));
			if (Manager.prefs.enemiesDisabled)
			{
				base.EntityManager.CreateEntity(typeof(DisableAllStateCD));
			}
			RequireAnyForUpdate(_debugRpcQuery, _rpcQuery, _textRpcQuery, _updatePlayerCustomizationRpcQuery);
			base.OnCreate();
		}

		[Preserve]
		protected override void OnStartRunning()
		{
			base.OnStartRunning();
			_inventoryChangeBufferEntity = __query_1290592712_2.GetSingletonEntity();
			_craftBufferEntity = __query_1290592712_3.GetSingletonEntity();
		}

		[Preserve]
		protected unsafe override void OnUpdate()
		{
			ProcessDebugRPCCommands();
			EntityCommandBuffer ecb = new EntityCommandBuffer(Allocator.Temp);
			BlobAssetReference<PugDatabase.PugDatabaseBank> blobAssetReference = database;
			Entity inventoryChangeBufferEntity = _inventoryChangeBufferEntity;
			ComponentLookup<ConnectionAdminLevelCD> fromEntity = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ConnectionAdminLevelCD_RO_ComponentLookup, ref base.CheckedStateRef);
			bool guestMode = base.WorldInfo.guestMode;
			Unity.Mathematics.Random rng = PugRandom.GetRng();
			__query_1290592712_4.TryGetSingleton<NetworkTime>(out var value);
			NetworkTick serverTick = value.ServerTick;
			uint simulationTickRate = (uint)PlatformConfiguration.Instance.SessionConfiguration.SimulationTickRate;
			ComponentLookup<DontDropLootCD> componentLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DontDropLootCD_RW_ComponentLookup, ref base.CheckedStateRef);
			ComponentLookup<DontDropSelfCD> componentLookup2 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DontDropSelfCD_RW_ComponentLookup, ref base.CheckedStateRef);
			BufferLookup<SkillBuffer> bufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__SkillBuffer_RW_BufferLookup, ref base.CheckedStateRef);
			ComponentLookup<DealDamageToCrittersCD> componentLookup3 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DealDamageToCrittersCD_RW_ComponentLookup, ref base.CheckedStateRef);
			BufferLookup<SkillConditionsBuffer> bufferLookup2 = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__SkillConditionsBuffer_RW_BufferLookup, ref base.CheckedStateRef);
			ComponentLookup<PlayerStateCD> componentLookup4 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlayerState_PlayerStateCD_RW_ComponentLookup, ref base.CheckedStateRef);
			ComponentLookup<PlayerOrientationCD> componentLookup5 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlayerOrientationCD_RW_ComponentLookup, ref base.CheckedStateRef);
			BufferLookup<InventoryChangeBuffer> bufferLookup3 = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__Inventory_InventoryChangeBuffer_RW_BufferLookup, ref base.CheckedStateRef);
			ComponentLookup<HealthCD> componentLookup6 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__HealthCD_RW_ComponentLookup, ref base.CheckedStateRef);
			ComponentLookup<DeathStateCD> componentLookup7 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlayerState_DeathStateCD_RW_ComponentLookup, ref base.CheckedStateRef);
			ComponentLookup<EntityDestroyedCD> componentLookup8 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EntityDestroyedCD_RW_ComponentLookup, ref base.CheckedStateRef);
			ComponentLookup<KilledByPlayerCD> componentLookup9 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__KilledByPlayerCD_RW_ComponentLookup, ref base.CheckedStateRef);
			ComponentLookup<PlantCD> componentLookup10 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlantCD_RW_ComponentLookup, ref base.CheckedStateRef);
			BufferLookup<SummarizedConditionEffectsBuffer> bufferLookup4 = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__SummarizedConditionEffectsBuffer_RO_BufferLookup, ref base.CheckedStateRef);
			ComponentLookup<GodModeCD> componentLookup11 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__GodModeCD_RW_ComponentLookup, ref base.CheckedStateRef);
			ComponentLookup<MoveToPredictedByEntityDestroyedCD> componentLookup12 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MoveToPredictedByEntityDestroyedCD_RW_ComponentLookup, ref base.CheckedStateRef);
			CollisionWorld collisionWorld = __query_1290592712_5.GetSingleton<PhysicsWorldSingleton>().PhysicsWorld.CollisionWorld;
			DynamicBuffer<KilledEnemiesBuffer> singletonBuffer = __query_1290592712_6.GetSingletonBuffer<KilledEnemiesBuffer>();
			using (NativeArray<Entity> nativeArray = _rpcQuery.ToEntityArray(Allocator.Temp))
			{
				for (int i = 0; i < nativeArray.Length; i++)
				{
					Rpc component = GetComponent<Rpc>(nativeArray[i]);
					ReceiveRpcCommandRequest component2 = GetComponent<ReceiveRpcCommandRequest>(nativeArray[i]);
					if (guestMode)
					{
						Command command = component.command;
						if (command != Command.MapPing && command != Command.RemoveLoginImmunity && command != Command.SetPlayerState && command != Command.UnlockCurrentState && fromEntity.GetAdminLevelOnServer(component2.SourceConnection) <= 0)
						{
							continue;
						}
					}
					bool flag = true;
					switch (component.command)
					{
					case Command.Unstuck:
					case Command.SetPlayerHealth:
					case Command.RemoveLoginImmunity:
					case Command.AddOrRefreshCondition:
					case Command.EnableSuperManForStreamIntegration:
					case Command.ResetMerchantHasNewItems:
						if (!EntityUtility.EntityExists(component.entity0, base.World) || !EntityUtility.HasComponentData<LocalTransform>(component.entity0, base.World) || EntityUtility.EntityIsDeferred(component.entity0))
						{
							flag = false;
						}
						break;
					}
					if (!flag)
					{
						continue;
					}
					RefRW<HealthCD> refRW2;
					switch (component.command)
					{
					case Command.Unstuck:
						refRW2 = componentLookup6.GetRefRW(component.entity0);
						refRW2.ValueRW.health = -999;
						componentLookup7.GetRefRW(component.entity0).ValueRW.allowHardcoreRespawn = true;
						break;
					case Command.SetPlayerHealth:
					{
						refRW2 = componentLookup6.GetRefRW(component.entity0);
						ref HealthCD valueRW = ref refRW2.ValueRW;
						valueRW.health = component.int0;
						bool flag2 = component.int1 == 1;
						if (valueRW.health <= 0 && !flag2)
						{
							componentLookup7.GetRefRW(component.entity0).ValueRW.allowHardcoreRespawn = true;
						}
						break;
					}
					case Command.SetPlayerManaForStreamIntegration:
					{
						ManaCD componentData4 = EntityUtility.GetComponentData<ManaCD>(component.entity0, base.World);
						componentData4.mana = math.clamp(componentData4.mana += component.int0, 0, componentData4.maxMana);
						if (component.int0 < 0)
						{
							componentData4.delay = true;
						}
						ecb.SetComponent(component.entity0, componentData4);
						break;
					}
					case Command.CreateMapUI:
					{
						ObjectDataCD objectDataCD = new ObjectDataCD
						{
							objectID = ObjectID.MapMarker,
							variation = component.int0 - 2
						};
						EntityUtility.CreateEntity(ecb, component.position0, objectDataCD.objectID, 1, blobAssetReference, out var _, objectDataCD.variation);
						break;
					}
					case Command.CreateEntityForStreamIntegration:
					{
						Entity prefabEntity2;
						Entity e = EntityUtility.CreateEntity(ecb, component.position0, (ObjectID)component.int0, 1, blobAssetReference, out prefabEntity2, component.int1);
						if (EntityUtility.HasComponentData<GhostOwner>(prefabEntity2, base.World))
						{
							ReceiveRpcCommandRequest component3 = GetComponent<ReceiveRpcCommandRequest>(nativeArray[i]);
							ecb.SetComponent(e, new GhostOwner
							{
								NetworkId = GetComponent<NetworkId>(component3.SourceConnection).Value
							});
						}
						ecb.AddComponent<DestroyEntityWhenNoNearbyPlayerCD>(e);
						ecb.SetComponent(e, new DestroyEntityWhenNoNearbyPlayerCD
						{
							distanceSq = 400f,
							destroyDelay = 300f
						});
						ecb.AddComponent<DontSerializeCD>(e);
						ecb.AddComponent<SpawnedByStreamIntegrationCD>(e);
						break;
					}
					case Command.CreateMortarEntityForStreamIntegration:
					{
						ConditionsTableCD singleton2 = __query_1290592712_7.GetSingleton<ConditionsTableCD>();
						BufferLookup<SummarizedConditionsBuffer> bufferLookup5 = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__SummarizedConditionsBuffer_RO_BufferLookup, ref base.CheckedStateRef);
						ComponentLookup<MortarProjectileDamageEffectCD> componentLookup13 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MortarProjectileDamageEffectCD_RW_ComponentLookup, ref base.CheckedStateRef);
						ComponentLookup<FactionCD> componentLookup14 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__FactionCD_RW_ComponentLookup, ref base.CheckedStateRef);
						ComponentLookup<BehaviourTagsCD> componentLookup15 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__BehaviourTagsCD_RW_ComponentLookup, ref base.CheckedStateRef);
						ComponentLookup<MortarProjectileCD> componentLookup16 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MortarProjectileCD_RW_ComponentLookup, ref base.CheckedStateRef);
						EntityUtility.SpawnMortarProjectile(ecb, component.position0, blobAssetReference, (ObjectID)component.int0, component.int2, component.position0, Entity.Null, 0f, 0f, 1f, 0.3f, 0, singleton2, ref rng, componentLookup14, componentLookup15, bufferLookup5, componentLookup16, componentLookup13, component.int1);
						break;
					}
					case Command.DestroyAllEntitiesForStreamIntegration:
					{
						NativeList<ColliderCastHit> outHits = new NativeList<ColliderCastHit>(Allocator.Temp);
						if (!collisionWorld.SphereCastAll(component.position0, 10f, float3.zero, 0f, ref outHits, new CollisionFilter
						{
							BelongsTo = uint.MaxValue,
							CollidesWith = 24u
						}))
						{
							break;
						}
						foreach (ColliderCastHit item in outHits)
						{
							if (InternalCompilerInterface.HasComponentAfterCompletingDependency(ref __TypeHandle.__BossCD_RO_ComponentLookup, ref base.CheckedStateRef, item.Entity) && !InternalCompilerInterface.HasComponentAfterCompletingDependency(ref __TypeHandle.__SpawnedByStreamIntegrationCD_RO_ComponentLookup, ref base.CheckedStateRef, item.Entity))
							{
								continue;
							}
							if (InternalCompilerInterface.HasComponentAfterCompletingDependency(ref __TypeHandle.__ObjectCategoryTagsCD_RO_ComponentLookup, ref base.CheckedStateRef, item.Entity))
							{
								ObjectCategoryTagsCD componentAfterCompletingDependency = InternalCompilerInterface.GetComponentAfterCompletingDependency(ref __TypeHandle.__ObjectCategoryTagsCD_RO_ComponentLookup, ref base.CheckedStateRef, item.Entity);
								if (!ObjectCategoryTagsCD.HasTag(componentAfterCompletingDependency.tagsBitMask, ObjectCategoryTag.HostileCreature) || ObjectCategoryTagsCD.HasTag(componentAfterCompletingDependency.tagsBitMask, ObjectCategoryTag.Cattle) || ObjectCategoryTagsCD.HasTag(componentAfterCompletingDependency.tagsBitMask, ObjectCategoryTag.NonHostileCreature))
								{
									continue;
								}
							}
							EntityUtility.Destroy(item.Entity, dontDrop: false, Entity.Null, componentLookup6, componentLookup8, componentLookup2, componentLookup, componentLookup9, componentLookup10, bufferLookup4, ref rng, componentLookup12, serverTick);
						}
						break;
					}
					case Command.EnableSuperManForStreamIntegration:
					{
						ConditionsTableCD singleton = __query_1290592712_7.GetSingleton<ConditionsTableCD>();
						EntityUtility.AddOrRefreshCondition(component.entity0, base.World, ConditionID.ArmorIncrease, (int)(1000f * component.position0.x), component.float0, singleton, serverTick, simulationTickRate);
						EntityUtility.AddOrRefreshCondition(component.entity0, base.World, ConditionID.CritChance, (int)(100f * component.position0.x), component.float0, singleton, serverTick, simulationTickRate);
						EntityUtility.AddOrRefreshCondition(component.entity0, base.World, ConditionID.DodgeChance, (int)(100f * component.position0.x), component.float0, singleton, serverTick, simulationTickRate);
						EntityUtility.AddOrRefreshCondition(component.entity0, base.World, ConditionID.MiningIncrease, (int)(1000f * component.position0.x), component.float0, singleton, serverTick, simulationTickRate);
						EntityUtility.AddOrRefreshCondition(component.entity0, base.World, ConditionID.PhysicalMeleeDamageIncrease, (int)(10000f * component.position0.x), component.float0, singleton, serverTick, simulationTickRate);
						EntityUtility.AddOrRefreshCondition(component.entity0, base.World, ConditionID.IncreasedMaxHealth, (int)(1000f * component.position0.x), component.float0, singleton, serverTick, simulationTickRate);
						EntityUtility.AddOrRefreshCondition(component.entity0, base.World, ConditionID.PhysicalRangeDamageIncrease, (int)(10000f * component.position0.x), component.float0, singleton, serverTick, simulationTickRate);
						EntityUtility.AddOrRefreshCondition(component.entity0, base.World, ConditionID.MovementSpeedIncrease, 300, component.float0, singleton, serverTick, simulationTickRate);
						EntityUtility.AddOrRefreshCondition(component.entity0, base.World, ConditionID.IncreasedMagicDamagePercentage, (int)(10000f * component.position0.x), component.float0, singleton, serverTick, simulationTickRate);
						break;
					}
					case Command.CreateAndDropItem:
						EntityUtility.CreateAndDropItem((ObjectID)component.int0, component.int1, (int)component.position1.x, component.position0, component.entity0, blobAssetReference, ecb);
						break;
					case Command.PlayMusicSheet:
						if (EntityUtility.HasComponentData<MusicSheetPlayedCD>(component.entity0, base.World))
						{
							ecb.SetComponent(component.entity0, new MusicSheetPlayedCD
							{
								currentSheetPlayed = (ObjectID)component.int0
							});
						}
						break;
					case Command.RemoveLoginImmunity:
					{
						ConditionsTableCD singleton4 = __query_1290592712_7.GetSingleton<ConditionsTableCD>();
						ConditionData conditionData = new ConditionData
						{
							conditionID = ConditionID.ImmuneToDamageAfterLogin,
							value = 1,
							duration = 2f
						};
						EntityUtility.AddOrRefreshCondition(component.entity0, base.World, conditionData, singleton4, serverTick, simulationTickRate);
						break;
					}
					case Command.AddOrRefreshCondition:
					{
						ConditionsTableCD singleton3 = __query_1290592712_7.GetSingleton<ConditionsTableCD>();
						EntityUtility.AddOrRefreshCondition(component.entity0, base.World, (ConditionID)component.int0, component.int1, component.float0, singleton3, serverTick, simulationTickRate);
						break;
					}
					case Command.SetSkillTalentCondition:
						EntityUtility.SetSkillTalentCondition(component.entity0, base.World, new ConditionData
						{
							conditionID = (ConditionID)component.int0,
							value = component.int1
						});
						break;
					case Command.LowerTheGreatWall:
						if (!EntityUtility.HasComponentData<TheGreatWallSystem.PlayerActivatedWall>(component.entity0, base.World))
						{
							ecb.AddComponent(component.entity0, default(TheGreatWallSystem.PlayerActivatedWall));
						}
						break;
					case Command.UnlockSouls:
						ecb.SetComponent(component.entity0, new SoulsInfoCD
						{
							hasUnlockedSouls = true
						});
						break;
					case Command.CollectSoul:
						EntityUtility.CollectSoul(component.entity0, base.World, (SoulID)component.int0);
						break;
					case Command.CompleteQuest:
						EntityUtility.CompleteQuest(component.entity0, base.World, (QuestID)component.int0);
						break;
					case Command.MapPing:
					{
						Entity e2 = ecb.CreateEntity();
						ecb.AddComponent(e2, component);
						ecb.AddComponent<SendRpcCommandRequest>(e2);
						break;
					}
					case Command.ResetMerchantHasNewItems:
					{
						MerchantCD component4 = GetComponent<MerchantCD>(component.entity0);
						ecb.SetComponent(component.entity0, new MerchantCD
						{
							previousAmountOfItems = component4.previousAmountOfItems,
							hasNewItems = false
						});
						break;
					}
					case Command.ActivateTerminal:
						if (HasComponent<EventTerminalCD>(component.entity0) && !HasComponent<TerminalActiveCD>(component.entity0))
						{
							ecb.AddComponent<TerminalActiveCD>(component.entity0);
						}
						break;
					case Command.SetPlayerImmuneToDamage:
					{
						Entity entity3 = component.entity0;
						bool bool5 = component.bool0;
						if (InternalCompilerInterface.HasComponentAfterCompletingDependency(ref __TypeHandle.__PlayerInvincibilityCD_RO_ComponentLookup, ref base.CheckedStateRef, entity3))
						{
							ecb.SetComponent(entity3, new PlayerInvincibilityCD
							{
								isInvincible = bool5
							});
						}
						break;
					}
					case Command.SetPlayerState:
						if (componentLookup4.HasComponent(component.entity0))
						{
							PlayerStateEnum int6 = (PlayerStateEnum)component.int0;
							componentLookup4.GetRefRW(component.entity0).ValueRW.SetNextState(int6, component.bool0);
						}
						break;
					case Command.AddSkillValue:
						PlayerController.AddSkill(component.entity0, (SkillID)component.int0, component.int1, ecb, isServer: true);
						break;
					case Command.SetSkillValue:
					{
						Entity entity2 = component.entity0;
						if (bufferLookup.TryGetBuffer(entity2, out var bufferData))
						{
							SkillID int5 = (SkillID)component.int0;
							ref SkillBuffer reference = ref bufferData.ElementAt((int)int5);
							reference.Value = component.int1;
							DynamicBuffer<SkillConditionsBuffer> skillConditionsBuffer = bufferLookup2[entity2];
							ConditionData conditionDataForSkill = SkillExtensions.GetConditionDataForSkill(int5, reference.Value);
							EntityUtility.SetSkillCondition(skillConditionsBuffer, conditionDataForSkill);
						}
						break;
					}
					case Command.SetSquashBugs:
					{
						Entity entity = component.entity0;
						if (componentLookup3.TryGetComponent(entity, out var componentData3))
						{
							componentData3.squashBugs = component.bool0;
							componentLookup3[entity] = componentData3;
						}
						break;
					}
					case Command.UnlockCurrentState:
						if (componentLookup4.HasComponent(component.entity0) && componentLookup5.HasComponent(component.entity0))
						{
							RefRW<PlayerOrientationCD> refRW = componentLookup5.GetRefRW(component.entity0);
							componentLookup4.GetRefRW(component.entity0).ValueRW.UnlockCurrentState(ref refRW.ValueRW);
						}
						break;
					case Command.SetWorldLabelVisibility:
					{
						ObjectDataCD componentData2 = EntityUtility.GetComponentData<ObjectDataCD>(component.entity0, base.World);
						componentData2.amount = component.int0;
						ecb.SetComponent(component.entity0, componentData2);
						break;
					}
					case Command.SetCattleBreedable:
					{
						BreedToggleCD componentData = EntityUtility.GetComponentData<BreedToggleCD>(component.entity0, base.World);
						componentData.breedingDisabled = component.bool0;
						ecb.SetComponent(component.entity0, componentData);
						break;
					}
					case Command.CreateItem:
						bufferLookup3[inventoryChangeBufferEntity].Add(new InventoryChangeBuffer
						{
							inventoryChangeData = Create.CreateItem(component.entity0, component.int0, (ObjectID)component.int1, component.int2, component.position0, component.int3)
						});
						break;
					case Command.SetGodMode:
						if (componentLookup11.HasComponent(component.entity0))
						{
							componentLookup11.SetComponentEnabled(component.entity0, component.bool0);
						}
						break;
					case Command.MarkEnemyAsKilled:
						singletonBuffer.Add(new KilledEnemiesBuffer
						{
							objectData = new ObjectDataCD
							{
								objectID = (ObjectID)component.int0,
								amount = 1
							}
						});
						break;
					default:
						Debug.LogError($"unknown player rpc command: {component.command}");
						break;
					}
				}
			}
			using (NativeArray<Entity> nativeArray2 = _textRpcQuery.ToEntityArray(Allocator.Temp))
			{
				foreach (Entity item2 in nativeArray2)
				{
					TextRpc component5 = GetComponent<TextRpc>(item2);
					ReceiveRpcCommandRequest component6 = GetComponent<ReceiveRpcCommandRequest>(item2);
					if (guestMode && fromEntity.GetAdminLevelOnServer(component6.SourceConnection) <= 0)
					{
						continue;
					}
					if (component5.command == Command.SetName)
					{
						NameCD componentData5 = EntityUtility.GetComponentData<NameCD>(component5.entity, base.World);
						componentData5.Value = component5.text;
						ecb.SetComponent(component5.entity, componentData5);
					}
					else
					{
						if (component5.command == Command.SetAuthor)
						{
							continue;
						}
						if (!InternalCompilerInterface.HasComponentAfterCompletingDependency(ref __TypeHandle.__Unity_NetCode_NetworkId_RO_ComponentLookup, ref base.CheckedStateRef, component6.SourceConnection))
						{
							Debug.LogError("no network id on text rpc");
							continue;
						}
						long key = ((long)InternalCompilerInterface.GetComponentAfterCompletingDependency(ref __TypeHandle.__Unity_NetCode_NetworkId_RO_ComponentLookup, ref base.CheckedStateRef, component6.SourceConnection).Value << 32) | component5.rpcId;
						if (!_textRpcLookup.ContainsKey(key))
						{
							_textRpcLookup.Add(key, new StringBuilder());
						}
						_textRpcLookup[key].Append(component5.text);
						if (component5.text.Length == component5.text.Capacity)
						{
							continue;
						}
						if (component5.command == Command.SetDescription)
						{
							string text = _textRpcLookup[key].ToString();
							int byteCount = Encoding.UTF8.GetByteCount(text);
							DynamicBuffer<DescriptionBuffer> dynamicBuffer = ecb.SetBuffer<DescriptionBuffer>(component5.entity);
							dynamicBuffer.Length = byteCount;
							fixed (char* chars = text)
							{
								Encoding.UTF8.GetBytes(chars, text.Length, (byte*)dynamicBuffer.GetUnsafePtr(), dynamicBuffer.Length);
							}
						}
						else
						{
							Debug.LogError($"unknown text rpc {component5.command}");
						}
						_textRpcLookup.Remove(key);
					}
				}
			}
			ServerSystem_4A171A05_LambdaJob_0_Execute();
			base.EntityManager.DestroyEntity(_rpcQuery);
			base.EntityManager.DestroyEntity(_textRpcQuery);
			base.EntityManager.DestroyEntity(_updatePlayerCustomizationRpcQuery);
			ecb.Playback(base.EntityManager);
			ecb.Dispose();
			base.OnUpdate();
		}

		private void ProcessDebugRPCCommands()
		{
			ComponentLookup<ConnectionAdminLevelCD> fromEntity = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ConnectionAdminLevelCD_RO_ComponentLookup, ref base.CheckedStateRef);
			ComponentLookup<HealthCD> componentLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__HealthCD_RW_ComponentLookup, ref base.CheckedStateRef);
			ComponentLookup<DeathStateCD> componentLookup2 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlayerState_DeathStateCD_RW_ComponentLookup, ref base.CheckedStateRef);
			BufferLookup<SkillBuffer> bufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__SkillBuffer_RW_BufferLookup, ref base.CheckedStateRef);
			BufferLookup<SkillConditionsBuffer> bufferLookup2 = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__SkillConditionsBuffer_RW_BufferLookup, ref base.CheckedStateRef);
			ComponentLookup<PlayerStateCD> componentLookup3 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlayerState_PlayerStateCD_RW_ComponentLookup, ref base.CheckedStateRef);
			ComponentLookup<GodModeCD> componentLookup4 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__GodModeCD_RW_ComponentLookup, ref base.CheckedStateRef);
			ComponentLookup<EntityDestroyedCD> componentLookup5 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EntityDestroyedCD_RW_ComponentLookup, ref base.CheckedStateRef);
			ComponentLookup<DontDropSelfCD> componentLookup6 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DontDropSelfCD_RW_ComponentLookup, ref base.CheckedStateRef);
			ComponentLookup<DontDropLootCD> componentLookup7 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DontDropLootCD_RW_ComponentLookup, ref base.CheckedStateRef);
			ComponentLookup<KilledByPlayerCD> componentLookup8 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__KilledByPlayerCD_RW_ComponentLookup, ref base.CheckedStateRef);
			ComponentLookup<ManaCD> componentLookup9 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ManaCD_RW_ComponentLookup, ref base.CheckedStateRef);
			ComponentLookup<PlantCD> componentLookup10 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlantCD_RW_ComponentLookup, ref base.CheckedStateRef);
			BufferLookup<InventoryChangeBuffer> bufferLookup3 = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__Inventory_InventoryChangeBuffer_RW_BufferLookup, ref base.CheckedStateRef);
			BufferLookup<CraftBuffer> bufferLookup4 = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__Inventory_CraftBuffer_RW_BufferLookup, ref base.CheckedStateRef);
			Entity inventoryChangeBufferEntity = _inventoryChangeBufferEntity;
			Entity craftBufferEntity = _craftBufferEntity;
			BufferLookup<SummarizedConditionEffectsBuffer> bufferLookup5 = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__SummarizedConditionEffectsBuffer_RO_BufferLookup, ref base.CheckedStateRef);
			ComponentLookup<MoveToPredictedByEntityDestroyedCD> componentLookup11 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MoveToPredictedByEntityDestroyedCD_RW_ComponentLookup, ref base.CheckedStateRef);
			Entity entity = tileUpdateBufferSingletonEntity;
			__query_1290592712_4.TryGetSingleton<NetworkTime>(out var value);
			NetworkTick serverTick = value.ServerTick;
			uint simulationTickRate = (uint)PlatformConfiguration.Instance.SessionConfiguration.SimulationTickRate;
			BlobAssetReference<PugDatabase.PugDatabaseBank> blobAssetReference = database;
			EntityCommandBuffer ecb = new EntityCommandBuffer(Allocator.Temp);
			Unity.Mathematics.Random rng = PugRandom.GetRng();
			using NativeArray<Entity> nativeArray = _debugRpcQuery.ToEntityArray(Allocator.Temp);
			for (int i = 0; i < nativeArray.Length; i++)
			{
				DebugRpc component = GetComponent<DebugRpc>(nativeArray[i]);
				int adminLevelOnServer = fromEntity.GetAdminLevelOnServer(GetComponent<ReceiveRpcCommandRequest>(nativeArray[i]).SourceConnection);
				if (!Manager.enableConsole || adminLevelOnServer <= 0)
				{
					continue;
				}
				bool flag = true;
				RefRW<HealthCD> refRW;
				switch (component.command)
				{
				case DebugCommand.ConsoleCommandUsed:
				{
					__query_1290592712_8.GetSingletonEntity();
					ref WorldInfoCD valueRW = ref __query_1290592712_9.GetSingletonRW<WorldInfoCD>().ValueRW;
					if (!valueRW.consoleCommandUsedThisSession)
					{
						valueRW.consoleCommandUsedThisSession = true;
						Entity e = ecb.CreateEntity();
						ecb.AddComponent(e, new SendRpcCommandRequest
						{
							TargetConnection = Entity.Null
						});
						ecb.AddComponent(e, new Rpc
						{
							command = Command.Message,
							int0 = 21
						});
					}
					break;
				}
				case DebugCommand.SetPlayerHealth:
				{
					refRW = componentLookup.GetRefRW(component.entity0);
					ref HealthCD valueRW2 = ref refRW.ValueRW;
					valueRW2.health = component.int0;
					bool flag2 = component.int1 == 1;
					if (valueRW2.health <= 0 && !flag2)
					{
						componentLookup2.GetRefRW(component.entity0).ValueRW.allowHardcoreRespawn = true;
					}
					break;
				}
				case DebugCommand.SetPlayerImmuneToDamage:
				{
					Entity entity3 = component.entity0;
					bool bool5 = component.bool0;
					if (InternalCompilerInterface.HasComponentAfterCompletingDependency(ref __TypeHandle.__PlayerInvincibilityCD_RO_ComponentLookup, ref base.CheckedStateRef, entity3))
					{
						ecb.SetComponent(entity3, new PlayerInvincibilityCD
						{
							isInvincible = bool5
						});
					}
					break;
				}
				case DebugCommand.CreateAndDropItem:
					EntityUtility.CreateAndDropItem((ObjectID)component.int0, component.int1, (int)component.position1.x, component.position0, component.entity0, blobAssetReference, ecb);
					break;
				case DebugCommand.SetSkillValue:
				{
					Entity entity2 = component.entity0;
					if (bufferLookup.TryGetBuffer(entity2, out var bufferData))
					{
						SkillID int5 = (SkillID)component.int0;
						ref SkillBuffer reference = ref bufferData.ElementAt((int)int5);
						reference.Value = component.int1;
						DynamicBuffer<SkillConditionsBuffer> skillConditionsBuffer = bufferLookup2[entity2];
						ConditionData conditionDataForSkill = SkillExtensions.GetConditionDataForSkill(int5, reference.Value);
						EntityUtility.SetSkillCondition(skillConditionsBuffer, conditionDataForSkill);
					}
					break;
				}
				case DebugCommand.SetPlayerState:
					if (componentLookup3.HasComponent(component.entity0))
					{
						PlayerStateEnum int6 = (PlayerStateEnum)component.int0;
						componentLookup3.GetRefRW(component.entity0).ValueRW.SetNextState(int6, component.bool0);
					}
					break;
				case DebugCommand.SetGodMode:
					if (componentLookup4.HasComponent(component.entity0))
					{
						componentLookup4.SetComponentEnabled(component.entity0, component.bool0);
					}
					break;
				case DebugCommand.SetPlayerHunger:
				case DebugCommand.EnableSuperMan:
				case DebugCommand.SetMovementSpeedMultiplier:
				case DebugCommand.SetPlayerBaseMaxHealth:
				case DebugCommand.DisableSuperman:
				case DebugCommand.SetPlayerMana:
				case DebugCommand.SetAllItemsInInventoryToLevel:
				case DebugCommand.RepairAll:
					if (!EntityUtility.EntityExists(component.entity0, base.World) || !EntityUtility.HasComponentData<LocalTransform>(component.entity0, base.World) || EntityUtility.EntityIsDeferred(component.entity0))
					{
						flag = false;
					}
					break;
				case DebugCommand.Destroy:
					if (!EntityUtility.EntityExists(component.entity0, base.World) || EntityUtility.EntityIsDeferred(component.entity0))
					{
						flag = false;
					}
					if (!EntityUtility.EntityExists(component.entity1, base.World) || !EntityUtility.HasComponentData<LocalTransform>(component.entity1, base.World) || EntityUtility.EntityIsDeferred(component.entity1))
					{
						flag = false;
					}
					break;
				}
				if (!flag)
				{
					continue;
				}
				switch (component.command)
				{
				case DebugCommand.SetPlayerBaseMaxHealth:
					refRW = componentLookup.GetRefRW(component.entity0);
					refRW.ValueRW.maxHealth = math.max(1, component.int0);
					break;
				case DebugCommand.SetPlayerHunger:
				{
					HungerCD componentData = EntityUtility.GetComponentData<HungerCD>(component.entity0, base.World);
					componentData.hunger = math.clamp(component.int0, 0, 100);
					ecb.SetComponent(component.entity0, componentData);
					break;
				}
				case DebugCommand.CreateEntity:
				{
					Entity prefabEntity;
					Entity e3 = EntityUtility.CreateEntity(ecb, component.position0, (ObjectID)component.int0, 1, blobAssetReference, out prefabEntity, component.int1);
					if (EntityUtility.HasComponentData<GhostOwner>(prefabEntity, base.World))
					{
						ReceiveRpcCommandRequest component2 = GetComponent<ReceiveRpcCommandRequest>(nativeArray[i]);
						ecb.SetComponent(e3, new GhostOwner
						{
							NetworkId = GetComponent<NetworkId>(component2.SourceConnection).Value
						});
					}
					break;
				}
				case DebugCommand.Destroy:
					if (EntityUtility.EntityExists(component.entity0, base.World))
					{
						EntityUtility.Destroy(component.entity0, component.bool0, component.entity1, componentLookup, componentLookup5, componentLookup6, componentLookup7, componentLookup8, componentLookup10, bufferLookup5, ref rng, componentLookup11, serverTick);
					}
					break;
				case DebugCommand.FillTile:
				{
					TileType int8 = (TileType)component.int0;
					int int9 = component.int1;
					int2 int10 = component.position0.RoundToInt2();
					int2 int11 = component.position1.RoundToInt2();
					bool isWorldModeCreative = Manager.saves.IsWorldModeEnabled(WorldMode.Creative);
					DynamicBuffer<TileUpdateBuffer> bufferAfterCompletingDependency = InternalCompilerInterface.GetBufferAfterCompletingDependency(ref __TypeHandle.__TileUpdateBuffer_RW_BufferLookup, ref base.CheckedStateRef, entity);
					for (int j = int10.x; j < int10.x + int11.x; j++)
					{
						for (int k = int10.y; k < int10.y + int11.y; k++)
						{
							EntityUtility.AddTile(int9, int8, new int2(j, k), isWorldModeCreative, bufferAfterCompletingDependency);
						}
					}
					break;
				}
				case DebugCommand.ClearTile:
				{
					DynamicBuffer<TileUpdateBuffer> bufferAfterCompletingDependency2 = InternalCompilerInterface.GetBufferAfterCompletingDependency(ref __TypeHandle.__TileUpdateBuffer_RW_BufferLookup, ref base.CheckedStateRef, entity);
					int2 int12 = component.position0.RoundToInt2();
					int2 int13 = component.position1.RoundToInt2();
					for (int l = int12.x; l < int12.x + int13.x; l++)
					{
						for (int m = int12.y; m < int12.y + int13.y; m++)
						{
							bufferAfterCompletingDependency2.Add(new TileUpdateBuffer
							{
								command = TileUpdateBuffer.Command.Clear,
								position = new int2(l, m)
							});
						}
					}
					break;
				}
				case DebugCommand.ToggleEnemyBehaviour:
				{
					using (EntityQuery entityQuery = base.EntityManager.CreateEntityQuery(typeof(DisableAllStateCD)))
					{
						if (entityQuery.IsEmpty)
						{
							Entity e2 = ecb.CreateEntity();
							ecb.AddComponent(e2, default(DisableAllStateCD));
						}
						else
						{
							ecb.DestroyEntity(entityQuery);
						}
					}
					break;
				}
				case DebugCommand.SetMovementSpeedMultiplier:
				{
					if (EntityUtility.TryGetComponentData<PlayerMovementCD>(component.entity0, base.World, out var value2))
					{
						value2.movementSpeed = component.position0.x;
						EntityUtility.SetComponentData(component.entity0, base.World, value2);
					}
					break;
				}
				case DebugCommand.EnableSuperMan:
				{
					ConditionsTableCD singleton = __query_1290592712_7.GetSingleton<ConditionsTableCD>();
					EntityUtility.AddOrRefreshCondition(component.entity0, base.World, ConditionID.ArmorIncrease, (int)(1000f * component.position0.x), 6000f, singleton, serverTick, simulationTickRate);
					EntityUtility.AddOrRefreshCondition(component.entity0, base.World, ConditionID.CritChance, (int)(100f * component.position0.x), 6000f, singleton, serverTick, simulationTickRate);
					EntityUtility.AddOrRefreshCondition(component.entity0, base.World, ConditionID.DodgeChance, (int)(100f * component.position0.x), 6000f, singleton, serverTick, simulationTickRate);
					EntityUtility.AddOrRefreshCondition(component.entity0, base.World, ConditionID.MiningIncrease, (int)(1000f * component.position0.x), 6000f, singleton, serverTick, simulationTickRate);
					EntityUtility.AddOrRefreshCondition(component.entity0, base.World, ConditionID.PhysicalMeleeDamageIncrease, (int)(10000f * component.position0.x), 6000f, singleton, serverTick, simulationTickRate);
					EntityUtility.AddOrRefreshCondition(component.entity0, base.World, ConditionID.IncreasedMaxHealth, (int)(1000f * component.position0.x), 6000f, singleton, serverTick, simulationTickRate);
					EntityUtility.AddOrRefreshCondition(component.entity0, base.World, ConditionID.PhysicalRangeDamageIncrease, (int)(10000f * component.position0.x), 6000f, singleton, serverTick, simulationTickRate);
					EntityUtility.AddOrRefreshCondition(component.entity0, base.World, ConditionID.MovementSpeedIncrease, 300, 6000f, singleton, serverTick, simulationTickRate);
					EntityUtility.AddOrRefreshCondition(component.entity0, base.World, ConditionID.IncreasedMagicDamagePercentage, (int)(10000f * component.position0.x), 6000f, singleton, serverTick, simulationTickRate);
					break;
				}
				case DebugCommand.DisableSuperman:
					EntityUtility.RemoveCondition(ConditionID.ArmorIncrease, component.entity0, base.World);
					EntityUtility.RemoveCondition(ConditionID.CritChance, component.entity0, base.World);
					EntityUtility.RemoveCondition(ConditionID.DodgeChance, component.entity0, base.World);
					EntityUtility.RemoveCondition(ConditionID.MiningIncrease, component.entity0, base.World);
					EntityUtility.RemoveCondition(ConditionID.PhysicalMeleeDamageIncrease, component.entity0, base.World);
					EntityUtility.RemoveCondition(ConditionID.IncreasedMaxHealth, component.entity0, base.World);
					EntityUtility.RemoveCondition(ConditionID.PhysicalRangeDamageIncrease, component.entity0, base.World);
					EntityUtility.RemoveCondition(ConditionID.MovementSpeedIncrease, component.entity0, base.World);
					EntityUtility.RemoveCondition(ConditionID.IncreasedMagicDamagePercentage, component.entity0, base.World);
					break;
				case DebugCommand.TriggerEnvironmentEvent:
				{
					EnvironmentEventType int7 = (EnvironmentEventType)component.int0;
					bool bool7 = component.bool0;
					DebugTriggerData.debugTriggerData.Data.attemptToTriggerEventNow = int7;
					DebugTriggerData.debugTriggerData.Data.bypassTriggerRequirements = bool7;
					Manager.menu.quantumConsole.LogToConsole("Attempting to start event: " + int7.ToString() + ". " + ((!bool7) ? "Note that the environment event won't start if the environment you are currently in doesn't fulfill the requirements for the event." : ""));
					break;
				}
				case DebugCommand.ResetEnvironmentEventCooldowns:
					DebugTriggerData.debugTriggerData.Data.resetEventCooldowns = true;
					break;
				case DebugCommand.SetEnvironmentEventsEnabled:
				{
					bool bool6 = component.bool0;
					DebugTriggerData.debugTriggerData.Data.eventsDisabled = !bool6;
					break;
				}
				case DebugCommand.SetPlayerMana:
					componentLookup9.GetRefRW(component.entity0).ValueRW.mana = component.int0;
					break;
				case DebugCommand.SetUnlimitedPlayerMana:
					componentLookup9.GetRefRW(component.entity0).ValueRW.isUnlimited = component.bool0;
					break;
				case DebugCommand.SetAllItemsInInventoryToLevel:
					bufferLookup3[inventoryChangeBufferEntity].Add(new InventoryChangeBuffer
					{
						playerEntity = component.entity0,
						inventoryChangeData = Create.SetAllItemsInInventoryToLevel(component.entity0, component.int0)
					});
					break;
				case DebugCommand.RepairAll:
					bufferLookup4[craftBufferEntity].Add(new CraftBuffer
					{
						playerEntity = component.entity0,
						craftActionData = Create.RepairAllItems(component.entity0, component.bool0)
					});
					break;
				}
			}
			ecb.Playback(base.EntityManager);
			ecb.Dispose();
			base.EntityManager.DestroyEntity(_debugRpcQuery);
		}

		private void ServerSystem_4A171A05_LambdaJob_0_Execute()
		{
			__TypeHandle.__PlayerCommand_UpdatePlayerCustomizationRpc_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
			__TypeHandle.__Unity_NetCode_ReceiveRpcCommandRequest_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
			__TypeHandle.__PlayerCustomizationCD_RW_ComponentLookup.Update(ref base.CheckedStateRef);
			ServerSystem_4A171A05_LambdaJob_0_Job value = new ServerSystem_4A171A05_LambdaJob_0_Job
			{
				__this = this,
				__rpcTypeHandle = __TypeHandle.__PlayerCommand_UpdatePlayerCustomizationRpc_RO_ComponentTypeHandle,
				__rpcSourceTypeHandle = __TypeHandle.__Unity_NetCode_ReceiveRpcCommandRequest_RO_ComponentTypeHandle,
				__PlayerCustomizationCD_ComponentLookup = __TypeHandle.__PlayerCustomizationCD_RW_ComponentLookup
			};
			if (!__query_1290592712_0.IsEmptyIgnoreFilter)
			{
				base.CheckedStateRef.CompleteDependency();
				IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
				ServerSystem_4A171A05_LambdaJob_0_Job.RunWithoutJobSystem(ref __query_1290592712_0, jobPtr);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<UpdatePlayerCustomizationRpc>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<ReceiveRpcCommandRequest>();
			_updatePlayerCustomizationRpcQuery = (__query_1290592712_0 = entityQueryBuilder2.Build(ref state));
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAny<BiomeRangesCD, BiomeSamplesCD>();
			__query_1290592712_1 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<InventoryChangeBuffer>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1290592712_2 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<CraftBuffer>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1290592712_3 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1290592712_4 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<PhysicsWorldSingleton>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1290592712_5 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAllRW<KilledEnemiesBuffer>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1290592712_6 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<ConditionsTableCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1290592712_7 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldInfoCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1290592712_8 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAllRW<WorldInfoCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1290592712_9 = entityQueryBuilder2.Build(ref state);
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
		public ServerSystem()
		{
		}
	}
}
