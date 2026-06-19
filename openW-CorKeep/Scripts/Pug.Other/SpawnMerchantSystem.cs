using System;
using System.Runtime.CompilerServices;
using Pug.UnityExtensions;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Transforms;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public class SpawnMerchantSystem : PugSimulationSystemBase
{
	private struct SpawnMerchantSystem_684B862F_LambdaJob_0_Job : IJob
	{
		public SpawnMerchantSystem __this;

		public EntityCommandBuffer ecb;

		public BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal;

		public NativeArray<Entity> npcs;

		public NativeArray<Entity> beds;

		[ReadOnly]
		public BufferLookup<RoomObjectBuffer> roomObjectsBufferLookUp;

		public BufferLookup<RoomEmptyPositions> roomEmptyPositionsLookUp;

		public NativeArray<LocalTransform> playerPositions;

		public Entity effectEventBufferEntity;

		public int spawnAnim;

		[ReadOnly]
		public ComponentLookup<EntityDestroyedCD> entityDestroyedLookup;

		public NetworkTick currentTick;

		public BufferLookup<AnimationBuffer> animationBufferLookup;

		public ComponentLookup<AnimationBufferPointer> animationBufferPointerLookup;

		public EntityArchetype enabledPositionArchetypeLocal;

		public Unity.Mathematics.Random rng;

		[ReadOnly]
		public ComponentLookup<ObjectDataCD> __ObjectDataCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ClaimedByCharacterGuidCD> __ClaimedByCharacterGuidCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DetectRoomCD> __DetectRoomCD_ComponentLookup;

		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<CharacterClaimedBedCD> __CharacterClaimedBedCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<BedCD> __BedCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<CharacterGuidCD> __CharacterGuidCD_ComponentLookup;

		private void OriginalLambdaBody()
		{
			bool flag = true;
			bool flag2 = true;
			bool flag3 = true;
			bool flag4 = true;
			bool flag5 = true;
			bool flag6 = true;
			for (int i = 0; i < npcs.Length; i++)
			{
				if (__ObjectDataCD_ComponentLookup.HasComponent(npcs[i]))
				{
					ObjectDataCD objectDataCD = __ObjectDataCD_ComponentLookup[npcs[i]];
					if (objectDataCD.objectID == ObjectID.CavelingMerchant)
					{
						flag2 = false;
					}
					else if (objectDataCD.objectID == ObjectID.SlimeMerchant)
					{
						flag = false;
					}
					else if (objectDataCD.objectID == ObjectID.FishingMerchant)
					{
						flag3 = false;
					}
					else if (objectDataCD.objectID == ObjectID.SeasonalMerchant)
					{
						flag4 = false;
					}
					else if (objectDataCD.objectID == ObjectID.CrystalMerchant)
					{
						flag5 = false;
					}
					else if (objectDataCD.objectID == ObjectID.VoidMerchant)
					{
						flag6 = false;
					}
				}
			}
			if (!PugDatabase.HasObject(ObjectID.CavelingMerchant, databaseLocal))
			{
				flag2 = false;
			}
			if (!PugDatabase.HasObject(ObjectID.SlimeMerchant, databaseLocal))
			{
				flag = false;
			}
			if (!PugDatabase.HasObject(ObjectID.FishingMerchant, databaseLocal))
			{
				flag3 = false;
			}
			if (!PugDatabase.HasObject(ObjectID.SeasonalMerchant, databaseLocal))
			{
				flag4 = false;
			}
			if (!PugDatabase.HasObject(ObjectID.CrystalMerchant, databaseLocal))
			{
				flag5 = false;
			}
			if (!PugDatabase.HasObject(ObjectID.VoidMerchant, databaseLocal))
			{
				flag6 = false;
			}
			NativeList<ObjectID> nativeList = new NativeList<ObjectID>(Allocator.Temp);
			if (flag)
			{
				nativeList.Add(ObjectID.SlimeMerchant);
			}
			if (flag2)
			{
				nativeList.Add(ObjectID.CavelingMerchant);
			}
			if (flag3)
			{
				nativeList.Add(ObjectID.FishingMerchant);
			}
			if (flag4)
			{
				nativeList.Add(ObjectID.SeasonalMerchant);
			}
			if (flag5)
			{
				nativeList.Add(ObjectID.CrystalMerchant);
			}
			if (flag6)
			{
				nativeList.Add(ObjectID.VoidMerchant);
			}
			NativeList<Entity> nativeList2 = new NativeList<Entity>(Allocator.Temp);
			for (int j = 0; j < beds.Length; j++)
			{
				if (!__ClaimedByCharacterGuidCD_ComponentLookup[beds[j]].isClaimed && __DetectRoomCD_ComponentLookup[beds[j]].roomDetected && (!entityDestroyedLookup.HasComponent(beds[j]) || !entityDestroyedLookup.IsComponentEnabled(beds[j])))
				{
					nativeList2.Add(beds[j]);
				}
			}
			if (nativeList.Length > 0)
			{
				for (int k = 0; k < nativeList.Length; k++)
				{
					ObjectID objectID = nativeList[k];
					ObjectID requiredObjectForMerchant = GetRequiredObjectForMerchant(objectID);
					for (int l = 0; l < nativeList2.Length; l++)
					{
						Entity entity = nativeList2[l];
						DynamicBuffer<RoomEmptyPositions> dynamicBuffer = roomEmptyPositionsLookUp[entity];
						DynamicBuffer<RoomObjectBuffer> dynamicBuffer2 = roomObjectsBufferLookUp[entity];
						if (dynamicBuffer2.Length <= 0 || dynamicBuffer.Length <= 0)
						{
							continue;
						}
						bool flag7 = false;
						for (int m = 0; m < dynamicBuffer2.Length; m++)
						{
							if (requiredObjectForMerchant == dynamicBuffer2[m].Value.objectID)
							{
								flag7 = true;
								break;
							}
						}
						if (flag7)
						{
							int2 value = dynamicBuffer[rng.NextInt(0, dynamicBuffer.Length)].Value;
							float3 float5 = new float3(value.x, 0f, value.y);
							Entity e = EntityUtility.CreateEntity(ecb, float5, objectID, 1, databaseLocal);
							EntityUtility.PlayEffectEventServer(ecb, effectEventBufferEntity, new EffectEventCD
							{
								effectID = EffectID.SpawnNPC,
								value1 = (int)objectID,
								position1 = float5
							});
							Hash128 hash = PugRandom.GenerateGuid(rng);
							ecb.SetComponent(e, new CharacterGuidCD
							{
								Value = hash
							});
							ecb.RemoveComponent<CreateNewGuidCD>(e);
							ecb.SetComponent(nativeList2[l], new ClaimedByCharacterGuidCD
							{
								characterGuid = hash
							});
							nativeList2.RemoveAtSwapBack(l);
							break;
						}
					}
				}
			}
			for (int n = 0; n < npcs.Length; n++)
			{
				float3 position = __Unity_Transforms_LocalTransform_ComponentLookup[npcs[n]].Position;
				float num = float.PositiveInfinity;
				for (int num2 = 0; num2 < playerPositions.Length; num2++)
				{
					float num3 = math.distancesq(position, playerPositions[num2].Position);
					if (num > num3)
					{
						num = num3;
					}
				}
				if (num < 4f)
				{
					continue;
				}
				ObjectID objectID2 = (__ObjectDataCD_ComponentLookup.HasComponent(npcs[n]) ? __ObjectDataCD_ComponentLookup[npcs[n]].objectID : ObjectID.None);
				ObjectID requiredObjectForMerchant2 = GetRequiredObjectForMerchant(objectID2);
				bool flag8 = __CharacterClaimedBedCD_ComponentLookup.HasComponent(npcs[n]);
				bool flag9 = flag8 && __BedCD_ComponentLookup.HasComponent(__CharacterClaimedBedCD_ComponentLookup[npcs[n]].claimedBedEntity);
				if (flag8 && !flag9)
				{
					if (nativeList2.Length <= 0)
					{
						continue;
					}
					int num4;
					for (num4 = 0; num4 < nativeList2.Length; num4++)
					{
						if (roomEmptyPositionsLookUp[nativeList2[num4]].Length <= 0)
						{
							continue;
						}
						bool flag10 = false;
						DynamicBuffer<RoomObjectBuffer> dynamicBuffer3 = roomObjectsBufferLookUp[nativeList2[num4]];
						for (int num5 = 0; num5 < dynamicBuffer3.Length; num5++)
						{
							if (requiredObjectForMerchant2 == dynamicBuffer3[num5].Value.objectID)
							{
								flag10 = true;
								break;
							}
						}
						if (flag10)
						{
							break;
						}
					}
					if (num4 != nativeList2.Length)
					{
						ecb.SetComponent(nativeList2[num4], new ClaimedByCharacterGuidCD
						{
							characterGuid = __CharacterGuidCD_ComponentLookup[npcs[n]].Value
						});
						DynamicBuffer<RoomEmptyPositions> dynamicBuffer4 = roomEmptyPositionsLookUp[nativeList2[num4]];
						int2 value2 = dynamicBuffer4[rng.NextInt(0, dynamicBuffer4.Length)].Value;
						float3 float6 = new float3(value2.x, 0f, value2.y);
						float3 position2 = __Unity_Transforms_LocalTransform_ComponentLookup[npcs[n]].Position;
						Entity e2 = ecb.CreateEntity(enabledPositionArchetypeLocal);
						ecb.SetComponent(e2, new EnableEntitiesInCircleCD
						{
							Center = position2.xz,
							Radius = 1f
						});
						ecb.SetComponent(e2, new EnableEntitiesTimerCD
						{
							RemainingTime = 0f
						});
						__Unity_Transforms_LocalTransform_ComponentLookup[npcs[n]] = LocalTransform.FromPosition(float6);
						EntityUtility.PlayEffectEventServer(ecb, effectEventBufferEntity, new EffectEventCD
						{
							effectID = EffectID.SpawnNPC,
							value1 = (int)objectID2,
							position1 = float6,
							value2 = 0
						});
						EntityUtility.PlayEffectEventServer(ecb, effectEventBufferEntity, new EffectEventCD
						{
							effectID = EffectID.SpawnNPC,
							value1 = (int)objectID2,
							position1 = position2,
							value2 = 1
						});
						if (animationBufferLookup.TryGetBuffer(npcs[n], out var bufferData))
						{
							AnimationUtilities.TriggerAnimation(spawnAnim, currentTick, bufferData, ref animationBufferPointerLookup.GetRefRW(npcs[n]).ValueRW);
						}
						nativeList2.RemoveAtSwapBack(num4);
					}
				}
				else
				{
					if (!(flag8 && flag9))
					{
						continue;
					}
					float3 position3 = __Unity_Transforms_LocalTransform_ComponentLookup[npcs[n]].Position;
					Entity claimedBedEntity = __CharacterClaimedBedCD_ComponentLookup[npcs[n]].claimedBedEntity;
					float3 position4 = __Unity_Transforms_LocalTransform_ComponentLookup[claimedBedEntity].Position;
					if (!(math.distancesq(position3, position4) > 900f))
					{
						continue;
					}
					DynamicBuffer<RoomEmptyPositions> dynamicBuffer5 = roomEmptyPositionsLookUp[claimedBedEntity];
					if (dynamicBuffer5.Length > 0)
					{
						int2 value3 = dynamicBuffer5[rng.NextInt(0, dynamicBuffer5.Length)].Value;
						float3 float7 = new float3(value3.x, 0f, value3.y);
						ecb.SetComponent(npcs[n], LocalTransform.FromPosition(float7));
						EntityUtility.PlayEffectEventServer(ecb, effectEventBufferEntity, new EffectEventCD
						{
							effectID = EffectID.SpawnNPC,
							value1 = (int)objectID2,
							position1 = float7,
							value2 = 0
						});
						EntityUtility.PlayEffectEventServer(ecb, effectEventBufferEntity, new EffectEventCD
						{
							effectID = EffectID.SpawnNPC,
							value1 = (int)objectID2,
							position1 = position3,
							value2 = 1
						});
						if (animationBufferLookup.TryGetBuffer(npcs[n], out var bufferData2))
						{
							AnimationUtilities.TriggerAnimation(spawnAnim, currentTick, bufferData2, ref animationBufferPointerLookup.GetRefRW(npcs[n]).ValueRW);
						}
					}
				}
			}
			nativeList.Dispose();
			nativeList2.Dispose();
		}

		public void Execute()
		{
			OriginalLambdaBody();
		}

		public static void RunWithoutJobSystem(IntPtr jobPtr)
		{
			InternalCompilerInterface.UnsafeAsRef<SpawnMerchantSystem_684B862F_LambdaJob_0_Job>(jobPtr).Execute();
		}
	}

	private struct TypeHandle
	{
		[ReadOnly]
		public ComponentLookup<ObjectDataCD> __ObjectDataCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ClaimedByCharacterGuidCD> __ClaimedByCharacterGuidCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DetectRoomCD> __DetectRoomCD_RO_ComponentLookup;

		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RW_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<CharacterClaimedBedCD> __CharacterClaimedBedCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<BedCD> __BedCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<CharacterGuidCD> __CharacterGuidCD_RO_ComponentLookup;

		[ReadOnly]
		public BufferLookup<RoomObjectBuffer> __RoomObjectBuffer_RO_BufferLookup;

		[ReadOnly]
		public BufferLookup<RoomEmptyPositions> __RoomEmptyPositions_RO_BufferLookup;

		public BufferLookup<AnimationBuffer> __AnimationBuffer_RW_BufferLookup;

		public ComponentLookup<AnimationBufferPointer> __AnimationBufferPointer_RW_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__ObjectDataCD_RO_ComponentLookup = state.GetComponentLookup<ObjectDataCD>(isReadOnly: true);
			__ClaimedByCharacterGuidCD_RO_ComponentLookup = state.GetComponentLookup<ClaimedByCharacterGuidCD>(isReadOnly: true);
			__DetectRoomCD_RO_ComponentLookup = state.GetComponentLookup<DetectRoomCD>(isReadOnly: true);
			__Unity_Transforms_LocalTransform_RW_ComponentLookup = state.GetComponentLookup<LocalTransform>();
			__CharacterClaimedBedCD_RO_ComponentLookup = state.GetComponentLookup<CharacterClaimedBedCD>(isReadOnly: true);
			__BedCD_RO_ComponentLookup = state.GetComponentLookup<BedCD>(isReadOnly: true);
			__CharacterGuidCD_RO_ComponentLookup = state.GetComponentLookup<CharacterGuidCD>(isReadOnly: true);
			__RoomObjectBuffer_RO_BufferLookup = state.GetBufferLookup<RoomObjectBuffer>(isReadOnly: true);
			__RoomEmptyPositions_RO_BufferLookup = state.GetBufferLookup<RoomEmptyPositions>(isReadOnly: true);
			__AnimationBuffer_RW_BufferLookup = state.GetBufferLookup<AnimationBuffer>();
			__AnimationBufferPointer_RW_ComponentLookup = state.GetComponentLookup<AnimationBufferPointer>();
		}
	}

	private const float distanceSqFromPlayer = 4f;

	private const float distanceSqFromBedToTeleportBack = 900f;

	private const float SYSTEM_UPDATE_COOLDOWN = 5f;

	private float systemTimer;

	private EntityQuery npcsQ;

	private EntityQuery bossesQ;

	private EntityQuery bedsQ;

	private EntityQuery playersQ;

	private EntityArchetype enabledPositionArchetype;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1517175680_0;

	private EntityQuery __query_1517175680_1;

	[Preserve]
	protected override void OnCreate()
	{
		UpdatesInRunGroup();
		NeedDatabase();
		RequireForUpdate<EffectEventBuffer>();
		EntityQueryDesc entityQueryDesc = new EntityQueryDesc();
		entityQueryDesc.Any = new ComponentType[1] { typeof(MerchantCD) };
		entityQueryDesc.Options = EntityQueryOptions.IncludeDisabledEntities;
		EntityQueryDesc entityQueryDesc2 = entityQueryDesc;
		npcsQ = GetEntityQuery(entityQueryDesc2);
		entityQueryDesc = new EntityQueryDesc();
		entityQueryDesc.Any = new ComponentType[1] { typeof(BossCD) };
		entityQueryDesc.Options = EntityQueryOptions.IncludeDisabledEntities;
		EntityQueryDesc entityQueryDesc3 = entityQueryDesc;
		bossesQ = GetEntityQuery(entityQueryDesc3);
		entityQueryDesc = new EntityQueryDesc();
		entityQueryDesc.All = new ComponentType[2]
		{
			typeof(BedCD),
			typeof(RoomObjectBuffer)
		};
		entityQueryDesc.Options = EntityQueryOptions.IncludeDisabledEntities;
		EntityQueryDesc entityQueryDesc4 = entityQueryDesc;
		bedsQ = GetEntityQuery(entityQueryDesc4);
		entityQueryDesc = new EntityQueryDesc();
		entityQueryDesc.All = new ComponentType[2]
		{
			typeof(PlayerGhost),
			typeof(LocalTransform)
		};
		EntityQueryDesc entityQueryDesc5 = entityQueryDesc;
		playersQ = GetEntityQuery(entityQueryDesc5);
		enabledPositionArchetype = base.EntityManager.CreateArchetype(typeof(EnableEntitiesInCircleCD), typeof(EnableEntitiesTimerCD));
		systemTimer = 5f;
		base.OnCreate();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		systemTimer -= base.CheckedStateRef.WorldUnmanaged.Time.DeltaTime;
		if (systemTimer <= 0f)
		{
			systemTimer = 5f;
			EntityCommandBuffer ecb = new EntityCommandBuffer(Allocator.Temp);
			BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal = database;
			NativeArray<Entity> npcs = npcsQ.ToEntityArray(Allocator.Temp);
			NativeArray<Entity> nativeArray = bossesQ.ToEntityArray(Allocator.Temp);
			NativeArray<Entity> beds = bedsQ.ToEntityArray(Allocator.Temp);
			BufferLookup<RoomObjectBuffer> roomObjectsBufferLookUp = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__RoomObjectBuffer_RO_BufferLookup, ref base.CheckedStateRef);
			BufferLookup<RoomEmptyPositions> roomEmptyPositionsLookUp = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__RoomEmptyPositions_RO_BufferLookup, ref base.CheckedStateRef);
			NativeArray<LocalTransform> playerPositions = playersQ.ToComponentDataArray<LocalTransform>(Allocator.Temp);
			Entity effectEventBufferEntity = __query_1517175680_0.GetSingletonEntity();
			int spawnAnim = -1878077465;
			ComponentLookup<EntityDestroyedCD> entityDestroyedLookup = GetComponentLookup<EntityDestroyedCD>(isReadOnly: true);
			__query_1517175680_1.TryGetSingleton<NetworkTime>(out var value);
			NetworkTick currentTick = value.ServerTick;
			BufferLookup<AnimationBuffer> animationBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__AnimationBuffer_RW_BufferLookup, ref base.CheckedStateRef);
			ComponentLookup<AnimationBufferPointer> animationBufferPointerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__AnimationBufferPointer_RW_ComponentLookup, ref base.CheckedStateRef);
			EntityArchetype enabledPositionArchetypeLocal = enabledPositionArchetype;
			Unity.Mathematics.Random rng = PugRandom.GetRng();
			SpawnMerchantSystem_684B862F_LambdaJob_0_Execute(ref ecb, ref databaseLocal, ref npcs, ref beds, ref roomObjectsBufferLookUp, ref roomEmptyPositionsLookUp, ref playerPositions, ref effectEventBufferEntity, ref spawnAnim, ref entityDestroyedLookup, ref currentTick, ref animationBufferLookup, ref animationBufferPointerLookup, ref enabledPositionArchetypeLocal, ref rng);
			playerPositions.Dispose();
			npcs.Dispose();
			nativeArray.Dispose();
			beds.Dispose();
			ecb.Playback(base.EntityManager);
			ecb.Dispose();
		}
		base.OnUpdate();
	}

	private static ObjectID GetRequiredObjectForMerchant(ObjectID merchantID)
	{
		return merchantID switch
		{
			ObjectID.CavelingMerchant => ObjectID.MysteriousIdol, 
			ObjectID.SlimeMerchant => ObjectID.SlimeOil, 
			ObjectID.FishingMerchant => ObjectID.PileOfChum, 
			ObjectID.SeasonalMerchant => ObjectID.Calendar, 
			ObjectID.CrystalMerchant => ObjectID.CrystalMerchantSpawnItem, 
			ObjectID.VoidMerchant => ObjectID.VoidMerchantIdol, 
			_ => ObjectID.None, 
		};
	}

	private void SpawnMerchantSystem_684B862F_LambdaJob_0_Execute(ref EntityCommandBuffer ecb, ref BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal, ref NativeArray<Entity> npcs, ref NativeArray<Entity> beds, ref BufferLookup<RoomObjectBuffer> roomObjectsBufferLookUp, ref BufferLookup<RoomEmptyPositions> roomEmptyPositionsLookUp, ref NativeArray<LocalTransform> playerPositions, ref Entity effectEventBufferEntity, ref int spawnAnim, ref ComponentLookup<EntityDestroyedCD> entityDestroyedLookup, ref NetworkTick currentTick, ref BufferLookup<AnimationBuffer> animationBufferLookup, ref ComponentLookup<AnimationBufferPointer> animationBufferPointerLookup, ref EntityArchetype enabledPositionArchetypeLocal, ref Unity.Mathematics.Random rng)
	{
		__TypeHandle.__ObjectDataCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__ClaimedByCharacterGuidCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__DetectRoomCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_Transforms_LocalTransform_RW_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__CharacterClaimedBedCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__BedCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__CharacterGuidCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		SpawnMerchantSystem_684B862F_LambdaJob_0_Job value = new SpawnMerchantSystem_684B862F_LambdaJob_0_Job
		{
			__this = this,
			ecb = ecb,
			databaseLocal = databaseLocal,
			npcs = npcs,
			beds = beds,
			roomObjectsBufferLookUp = roomObjectsBufferLookUp,
			roomEmptyPositionsLookUp = roomEmptyPositionsLookUp,
			playerPositions = playerPositions,
			effectEventBufferEntity = effectEventBufferEntity,
			spawnAnim = spawnAnim,
			entityDestroyedLookup = entityDestroyedLookup,
			currentTick = currentTick,
			animationBufferLookup = animationBufferLookup,
			animationBufferPointerLookup = animationBufferPointerLookup,
			enabledPositionArchetypeLocal = enabledPositionArchetypeLocal,
			rng = rng,
			__ObjectDataCD_ComponentLookup = __TypeHandle.__ObjectDataCD_RO_ComponentLookup,
			__ClaimedByCharacterGuidCD_ComponentLookup = __TypeHandle.__ClaimedByCharacterGuidCD_RO_ComponentLookup,
			__DetectRoomCD_ComponentLookup = __TypeHandle.__DetectRoomCD_RO_ComponentLookup,
			__Unity_Transforms_LocalTransform_ComponentLookup = __TypeHandle.__Unity_Transforms_LocalTransform_RW_ComponentLookup,
			__CharacterClaimedBedCD_ComponentLookup = __TypeHandle.__CharacterClaimedBedCD_RO_ComponentLookup,
			__BedCD_ComponentLookup = __TypeHandle.__BedCD_RO_ComponentLookup,
			__CharacterGuidCD_ComponentLookup = __TypeHandle.__CharacterGuidCD_RO_ComponentLookup
		};
		base.CheckedStateRef.CompleteDependency();
		SpawnMerchantSystem_684B862F_LambdaJob_0_Job.RunWithoutJobSystem(InternalCompilerInterface.AddressOf(ref value));
		ecb = value.ecb;
		databaseLocal = value.databaseLocal;
		npcs = value.npcs;
		beds = value.beds;
		roomObjectsBufferLookUp = value.roomObjectsBufferLookUp;
		roomEmptyPositionsLookUp = value.roomEmptyPositionsLookUp;
		playerPositions = value.playerPositions;
		effectEventBufferEntity = value.effectEventBufferEntity;
		spawnAnim = value.spawnAnim;
		entityDestroyedLookup = value.entityDestroyedLookup;
		currentTick = value.currentTick;
		animationBufferLookup = value.animationBufferLookup;
		animationBufferPointerLookup = value.animationBufferPointerLookup;
		enabledPositionArchetypeLocal = value.enabledPositionArchetypeLocal;
		rng = value.rng;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<EffectEventBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1517175680_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1517175680_1 = entityQueryBuilder2.Build(ref state);
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
	public SpawnMerchantSystem()
	{
	}
}
