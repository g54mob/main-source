using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Compression;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Affixes.Components;
using PimDeWitte.UnityMainThreadDispatcher;
using PlayerCommand;
using Pug.Automation;
using Pug.ECS.Serialization;
using Pug.Platform;
using Pug.Properties;
using Pug.UnityExtensions;
using PugScan;
using PugTilemap;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Entities.Serialization;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Profiling;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(SerializationSystemGroup))]
public class SerializeWorldSystem : SystemBase
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct SerializeWorld : IComponentData, IQueryTypeParameter
	{
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	[TypeManager.OverrideTypeHash(8089487776991448321uL)]
	private struct RemoveAfterSerialize : IComponentData, IQueryTypeParameter
	{
	}

	[BurstCompile]
	private struct MarkChunksDirtyJob : IJob
	{
		public NativeList<SerializedChunkData> Chunks;

		public void Execute()
		{
			for (int num = Chunks.Length - 1; num >= 0; num--)
			{
				SerializedChunkData value = Chunks[num];
				if (value.ChunkListIndex != -2)
				{
					value.ChunkListIndex = -1;
					Chunks[num] = value;
				}
			}
		}
	}

	[BurstCompile]
	private struct SerializeObjectJob : IJobChunk
	{
		public ExclusiveEntityTransaction EntityTransaction;

		public NativeList<Entity> SerializedEntities;

		public NativeList<SerializeWorldDataCD.FreeEntityRange> FreeSerializedEntities;

		public NativeList<SerializedChunkData> Chunks;

		public NativeList<int> FreeChunks;

		public ComponentTypeHandle<SerializedChunkData> SerializedChunk;

		public uint GlobalSystemVersion;

		[ReadOnly]
		public ComponentTypeHandle<LocalTransform> Transform;

		[ReadOnly]
		public ComponentTypeHandle<ObjectDataCD> ObjectData;

		[ReadOnly]
		public ComponentTypeHandle<CharacterGuidCD> CharacterGuid;

		[ReadOnly]
		public ComponentTypeHandle<ClaimedByCharacterGuidCD> ClaimedByCharacterGuid;

		[ReadOnly]
		public ComponentTypeHandle<PlayerGuidCD> PlayerGuid;

		[ReadOnly]
		public ComponentTypeHandle<ClaimedByPlayerGuidCD> ClaimedByPlayerGuid;

		[ReadOnly]
		public ComponentTypeHandle<HealthCD> Health;

		[ReadOnly]
		public ComponentTypeHandle<GrowingCD> Growing;

		[ReadOnly]
		public ComponentTypeHandle<GrowTimerRefCD> GrowTimer;

		[ReadOnly]
		public ComponentTypeHandle<HungerCD> Hunger;

		[ReadOnly]
		public ComponentTypeHandle<DropsLootFromLootTableCD> DropsLootFromLootTable;

		[ReadOnly]
		public ComponentTypeHandle<PaintableObjectCD> PaintableObject;

		[ReadOnly]
		public ComponentTypeHandle<DirectionCD> Direction;

		[ReadOnly]
		public ComponentTypeHandle<HasBeenDiscoveredCD> HasBeenDiscovered;

		[ReadOnly]
		public ComponentTypeHandle<CustomSceneObjectCD> CustomSceneObject;

		[ReadOnly]
		public ComponentTypeHandle<ActiveEquipmentPresetCD> ActiveEquipmentPreset;

		[ReadOnly]
		public ComponentTypeHandle<PlayerGhost> PlayerGhost;

		[ReadOnly]
		public ComponentTypeHandle<PlayerLastSessionCD> PlayerLastSession;

		[ReadOnly]
		public ComponentTypeHandle<SpawnPointCD> SpawnPoint;

		[ReadOnly]
		public ComponentTypeHandle<NameCD> Name;

		[ReadOnly]
		public ComponentTypeHandle<AuthorCD> Author;

		[ReadOnly]
		public ComponentTypeHandle<CraftingCD> Crafting;

		[ReadOnly]
		public ComponentTypeHandle<SnakeSegmentCD> SnakeBossSegment;

		[ReadOnly]
		public ComponentTypeHandle<MealsEatenCD> MealsEaten;

		[ReadOnly]
		public ComponentTypeHandle<BreedToggleCD> BreedToggle;

		[ReadOnly]
		public ComponentTypeHandle<ObjectFilteringCD> ObjectFilter;

		[ReadOnly]
		public ComponentTypeHandle<PugAutomationEnabledMoverSyncedCD> PugAutomationMoverOrchestratorSynced;

		[ReadOnly]
		public ComponentTypeHandle<MoveeBigEntityCD> MoveeBigEntity;

		[ReadOnly]
		public ComponentTypeHandle<ImmunityZoneCD> ImmunityZone;

		[ReadOnly]
		public BufferTypeHandle<ContainedObjectsBuffer> ContainedObjects;

		[ReadOnly]
		public BufferTypeHandle<ConditionsBuffer> Conditions;

		[ReadOnly]
		public BufferTypeHandle<ActiveAffixStateBuffer> ActiveAffixState;

		[ReadOnly]
		public BufferTypeHandle<ActiveAffixConditionsBuffer> ActiveAffixCondition;

		[ReadOnly]
		public BufferTypeHandle<DropsLootBuffer> DropsLoot;

		[ReadOnly]
		public BufferTypeHandle<SummarizedConditionEffectsBuffer> SummarizedConditions;

		[ReadOnly]
		public BufferTypeHandle<DescriptionBuffer> Description;

		[ReadOnly]
		public BufferTypeHandle<CraftingTimerSlotBuffer> CraftingTimerSlotCrafter;

		[ReadOnly]
		public BufferTypeHandle<CraftingByRecipeSlotBuffer> RecipeCrafter;

		[ReadOnly]
		public BufferTypeHandle<CraftingByConsumedObjectSlotBuffer> ConsumedObjectCrafter;

		[ReadOnly]
		public ComponentLookup<GrowTimerCD> GrowTimerLookup;

		public NetworkTick CurrentTick;

		public uint TickRate;

		public unsafe void Execute(in ArchetypeChunk batchInChunk, int chunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			SerializedChunkData serializedChunk = batchInChunk.GetChunkComponentData(SerializedChunk);
			bool flag = batchInChunk.Has(CharacterGuid);
			bool flag2 = batchInChunk.Has(ClaimedByCharacterGuid);
			bool flag3 = batchInChunk.Has(PlayerGuid);
			bool flag4 = batchInChunk.Has(ClaimedByPlayerGuid);
			bool flag5 = batchInChunk.Has(Health);
			bool flag6 = batchInChunk.Has(Growing);
			bool flag7 = flag6 && batchInChunk.Has(GrowTimer);
			bool flag8 = batchInChunk.Has(Hunger);
			bool flag9 = batchInChunk.Has(DropsLootFromLootTable);
			bool flag10 = batchInChunk.Has(PaintableObject);
			bool flag11 = batchInChunk.Has(Direction);
			bool flag12 = batchInChunk.Has(HasBeenDiscovered);
			bool flag13 = batchInChunk.Has(CustomSceneObject);
			bool flag14 = batchInChunk.Has(ActiveEquipmentPreset);
			bool flag15 = batchInChunk.Has(PlayerGhost);
			bool flag16 = batchInChunk.Has(PlayerLastSession);
			bool flag17 = batchInChunk.Has(SpawnPoint);
			bool flag18 = batchInChunk.Has(Name);
			batchInChunk.Has(Author);
			batchInChunk.Has(Crafting);
			bool flag19 = batchInChunk.Has(CraftingTimerSlotCrafter);
			bool flag20 = batchInChunk.Has(RecipeCrafter);
			bool flag21 = batchInChunk.Has(ConsumedObjectCrafter);
			bool flag22 = batchInChunk.Has(ObjectFilter);
			bool flag23 = batchInChunk.Has(PugAutomationMoverOrchestratorSynced);
			bool flag24 = batchInChunk.Has(MoveeBigEntity);
			bool flag25 = batchInChunk.Has(SnakeBossSegment);
			bool flag26 = batchInChunk.Has(MealsEaten);
			bool flag27 = batchInChunk.Has(BreedToggle);
			bool flag28 = batchInChunk.Has(ContainedObjects);
			bool flag29 = batchInChunk.Has(Conditions);
			bool flag30 = flag5 && batchInChunk.Has(ActiveAffixState) && batchInChunk.Has(ActiveAffixCondition);
			bool flag31 = batchInChunk.Has(DropsLoot);
			bool flag32 = batchInChunk.Has(Description);
			bool flag33 = batchInChunk.Has(ImmunityZone);
			bool flag34 = flag5 && batchInChunk.Has(SummarizedConditions);
			if (batchInChunk.DidOrderChange(serializedChunk.ChangeVersion))
			{
				serializedChunk.StartIndex = 0;
				serializedChunk.Count = 0;
				serializedChunk.ChunkListIndex = 0;
				serializedChunk.ChangeVersion = 0u;
			}
			if (serializedChunk.Count > batchInChunk.Count)
			{
				for (int i = batchInChunk.Count; i < serializedChunk.Count; i++)
				{
					EntityTransaction.DestroyEntity(SerializedEntities[serializedChunk.StartIndex + i]);
				}
			}
			else if (serializedChunk.Count < batchInChunk.Count)
			{
				if (serializedChunk.StartIndex == 0)
				{
					AllocateSerializedChunk(in batchInChunk, ref serializedChunk, SerializedEntities, FreeSerializedEntities, Chunks, FreeChunks);
				}
				NativeList<ComponentType> list = new NativeList<ComponentType>(Allocator.Temp);
				list.Add(ComponentType.ReadOnly<Translation>());
				list.Add(ComponentType.ReadOnly<ObjectDataSerializedCD>());
				if (flag)
				{
					list.Add(ComponentType.ReadOnly<CharacterGuidSerializedCD>());
				}
				if (flag2)
				{
					list.Add(ComponentType.ReadOnly<ClaimedByCharacterGuidSerializedCD>());
				}
				if (flag3)
				{
					list.Add(ComponentType.ReadOnly<PlayerGuidSerializedCD>());
				}
				if (flag4)
				{
					list.Add(ComponentType.ReadOnly<ClaimedByPlayerGuidSerializedCD>());
				}
				if (flag5)
				{
					list.Add(ComponentType.ReadOnly<HealthSerializedCD>());
				}
				if (flag6)
				{
					list.Add(ComponentType.ReadOnly<GrowingSerializedCD>());
				}
				if (flag8)
				{
					list.Add(ComponentType.ReadOnly<HungerSerializedCD>());
				}
				if (flag9)
				{
					list.Add(ComponentType.ReadOnly<LootTableSerializedCD>());
				}
				if (flag10)
				{
					list.Add(ComponentType.ReadOnly<PaintableObjectSerializedCD>());
				}
				if (flag11)
				{
					list.Add(ComponentType.ReadOnly<RotationSerializedCD>());
				}
				if (flag12)
				{
					list.Add(ComponentType.ReadOnly<HasBeenDiscoveredSerializedCD>());
				}
				if (flag13)
				{
					list.Add(ComponentType.ReadOnly<CustomSceneObjectSerializedCD>());
				}
				if (flag14)
				{
					list.Add(ComponentType.ReadOnly<ActiveEquipmentPresetSerializedCD>());
				}
				if (flag15)
				{
					list.Add(ComponentType.ReadOnly<PlayerSerializedCD>());
				}
				if (flag16)
				{
					list.Add(ComponentType.ReadOnly<PlayerLastSessionSerializedCD>());
				}
				if (flag17)
				{
					list.Add(ComponentType.ReadOnly<SpawnPointCD>());
				}
				if (flag18)
				{
					list.Add(ComponentType.ReadOnly<NameSerializedCD>());
				}
				if (flag19)
				{
					list.Add(ComponentType.ReadOnly<CraftingSlotTimerSerialized>());
				}
				if (flag20)
				{
					list.Add(ComponentType.ReadOnly<CraftingSlotByRecipesSerialized>());
				}
				if (flag21)
				{
					list.Add(ComponentType.ReadOnly<CraftingSlotByConsumedObjectsSerialized>());
				}
				if (flag22)
				{
					list.Add(ComponentType.ReadOnly<FilteringSerializedBuffer>());
				}
				if (flag23)
				{
					list.Add(ComponentType.ReadOnly<MoverOrchestratorSerialized>());
				}
				if (flag24)
				{
					list.Add(ComponentType.ReadOnly<MoveeSerialized>());
				}
				if (flag25)
				{
					list.Add(ComponentType.ReadOnly<SnakeBossSegmentSerializedCD>());
				}
				if (flag26)
				{
					list.Add(ComponentType.ReadOnly<BreedStateSerializedCD>());
				}
				if (flag27)
				{
					list.Add(ComponentType.ReadOnly<BreedToggleSerializedCD>());
				}
				if (flag28)
				{
					list.Add(ComponentType.ReadOnly<ContainedObjectsSerializedBuffer>());
					list.Add(ComponentType.ReadOnly<ContainedObjectsAuxIndexSerializedBuffer>());
				}
				if (flag29)
				{
					list.Add(ComponentType.ReadOnly<ConditionsSerializedBuffer>());
				}
				if (flag30)
				{
					list.Add(ComponentType.ReadOnly<AffixSerializedBuffer>());
				}
				if (flag31)
				{
					list.Add(ComponentType.ReadOnly<DropsLootSerializedBuffer>());
				}
				if (flag32)
				{
					list.Add(ComponentType.ReadOnly<DescriptionSerializedBuffer>());
				}
				if (flag33)
				{
					list.Add(ComponentType.ReadOnly<ImmunityZoneShapeSerializedCD>());
				}
				NativeArray<Entity> entities = new NativeArray<Entity>(batchInChunk.Count - serializedChunk.Count, Allocator.Temp);
				EntityArchetype archetype = EntityTransaction.CreateArchetype(list.GetUnsafeReadOnlyPtr(), list.Length);
				EntityTransaction.CreateEntity(archetype, entities);
				for (int j = serializedChunk.Count; j < batchInChunk.Count; j++)
				{
					SerializedEntities[serializedChunk.StartIndex + j] = entities[j - serializedChunk.Count];
				}
				entities.Dispose();
				list.Dispose();
			}
			serializedChunk.Count = batchInChunk.Count;
			if (batchInChunk.DidChange(Transform, serializedChunk.ChangeVersion))
			{
				NativeArray<LocalTransform> nativeArray = batchInChunk.GetNativeArray(Transform);
				for (int k = 0; k < batchInChunk.Count; k++)
				{
					Entity entity = SerializedEntities[serializedChunk.StartIndex + k];
					EntityTransaction.SetComponentData(entity, new Translation
					{
						Value = nativeArray[k].Position
					});
				}
			}
			if (batchInChunk.DidChange(ObjectData, serializedChunk.ChangeVersion))
			{
				NativeArray<ObjectDataCD> nativeArray2 = batchInChunk.GetNativeArray(ObjectData);
				for (int l = 0; l < batchInChunk.Count; l++)
				{
					Entity entity2 = SerializedEntities[serializedChunk.StartIndex + l];
					ObjectDataCD objectDataCD = nativeArray2[l];
					EntityTransaction.SetComponentData(entity2, new ObjectDataSerializedCD
					{
						ObjectID = objectDataCD.objectID,
						Amount = objectDataCD.amount,
						Variation = objectDataCD.variation
					});
				}
			}
			if (flag && batchInChunk.DidChange(CharacterGuid, serializedChunk.ChangeVersion))
			{
				NativeArray<CharacterGuidCD> nativeArray3 = batchInChunk.GetNativeArray(CharacterGuid);
				for (int m = 0; m < batchInChunk.Count; m++)
				{
					Entity entity3 = SerializedEntities[serializedChunk.StartIndex + m];
					CharacterGuidCD characterGuidCD = nativeArray3[m];
					EntityTransaction.SetComponentData(entity3, new CharacterGuidSerializedCD
					{
						Value = characterGuidCD.Value
					});
				}
			}
			if (flag2 && batchInChunk.DidChange(ClaimedByCharacterGuid, serializedChunk.ChangeVersion))
			{
				NativeArray<ClaimedByCharacterGuidCD> nativeArray4 = batchInChunk.GetNativeArray(ClaimedByCharacterGuid);
				for (int n = 0; n < batchInChunk.Count; n++)
				{
					Entity entity4 = SerializedEntities[serializedChunk.StartIndex + n];
					ClaimedByCharacterGuidCD claimedByCharacterGuidCD = nativeArray4[n];
					EntityTransaction.SetComponentData(entity4, new ClaimedByCharacterGuidSerializedCD
					{
						Value = claimedByCharacterGuidCD.characterGuid
					});
				}
			}
			if (flag3 && batchInChunk.DidChange(PlayerGuid, serializedChunk.ChangeVersion))
			{
				NativeArray<PlayerGuidCD> nativeArray5 = batchInChunk.GetNativeArray(PlayerGuid);
				for (int num = 0; num < batchInChunk.Count; num++)
				{
					Entity entity5 = SerializedEntities[serializedChunk.StartIndex + num];
					PlayerGuidCD playerGuidCD = nativeArray5[num];
					EntityTransaction.SetComponentData(entity5, new PlayerGuidSerializedCD
					{
						Value = playerGuidCD.Value
					});
				}
			}
			if (flag4 && batchInChunk.DidChange(ClaimedByPlayerGuid, serializedChunk.ChangeVersion))
			{
				NativeArray<ClaimedByPlayerGuidCD> nativeArray6 = batchInChunk.GetNativeArray(ClaimedByPlayerGuid);
				for (int num2 = 0; num2 < batchInChunk.Count; num2++)
				{
					Entity entity6 = SerializedEntities[serializedChunk.StartIndex + num2];
					ClaimedByPlayerGuidCD claimedByPlayerGuidCD = nativeArray6[num2];
					EntityTransaction.SetComponentData(entity6, new ClaimedByPlayerGuidSerializedCD
					{
						Value = claimedByPlayerGuidCD.playerGuid
					});
				}
			}
			if (flag5 && batchInChunk.DidChange(Health, serializedChunk.ChangeVersion))
			{
				NativeArray<HealthCD> nativeArray7 = batchInChunk.GetNativeArray(Health);
				BufferAccessor<SummarizedConditionEffectsBuffer> bufferAccessor = default(BufferAccessor<SummarizedConditionEffectsBuffer>);
				if (flag34)
				{
					bufferAccessor = batchInChunk.GetBufferAccessor(SummarizedConditions);
				}
				for (int num3 = 0; num3 < batchInChunk.Count; num3++)
				{
					Entity entity7 = SerializedEntities[serializedChunk.StartIndex + num3];
					HealthCD healthCD = nativeArray7[num3];
					int num4 = healthCD.maxHealth;
					if (flag34)
					{
						DynamicBuffer<SummarizedConditionEffectsBuffer> dynamicBuffer = bufferAccessor[num3];
						num4 += dynamicBuffer[5].value;
						num4 += dynamicBuffer[68].value;
						float num5 = math.max(1f + (float)dynamicBuffer[34].value / 100f, 0f);
						num4 = (int)math.round(math.max(1f, num5 * (float)num4));
					}
					EntityTransaction.SetComponentData(entity7, new HealthSerializedCD
					{
						Value = (float)healthCD.health / (float)num4
					});
				}
			}
			if (flag6 && batchInChunk.DidChange(Growing, serializedChunk.ChangeVersion))
			{
				NativeArray<GrowingCD> nativeArray8 = batchInChunk.GetNativeArray(Growing);
				NativeArray<GrowTimerRefCD> nativeArray9 = default(NativeArray<GrowTimerRefCD>);
				if (flag7)
				{
					nativeArray9 = batchInChunk.GetNativeArray(GrowTimer);
				}
				for (int num6 = 0; num6 < batchInChunk.Count; num6++)
				{
					Entity entity8 = SerializedEntities[serializedChunk.StartIndex + num6];
					GrowingCD growingCD = nativeArray8[num6];
					if (flag7)
					{
						growingCD.grownTimeToApplyToTimer += GrowTimerLookup[nativeArray9[num6].GrowTimerEntity].Value;
					}
					EntityTransaction.SetComponentData(entity8, new GrowingSerializedCD
					{
						Stage = growingCD.currentStage,
						GrowTime = growingCD.grownTimeToApplyToTimer
					});
				}
			}
			if (flag8 && batchInChunk.DidChange(Hunger, serializedChunk.ChangeVersion))
			{
				NativeArray<HungerCD> nativeArray10 = batchInChunk.GetNativeArray(Hunger);
				for (int num7 = 0; num7 < batchInChunk.Count; num7++)
				{
					Entity entity9 = SerializedEntities[serializedChunk.StartIndex + num7];
					float value = (float)nativeArray10[num7].hunger / 100f;
					EntityTransaction.SetComponentData(entity9, new HungerSerializedCD
					{
						Value = value
					});
				}
			}
			if (flag9 && batchInChunk.DidChange(DropsLootFromLootTable, serializedChunk.ChangeVersion))
			{
				NativeArray<DropsLootFromLootTableCD> nativeArray11 = batchInChunk.GetNativeArray(DropsLootFromLootTable);
				for (int num8 = 0; num8 < batchInChunk.Count; num8++)
				{
					Entity entity10 = SerializedEntities[serializedChunk.StartIndex + num8];
					DropsLootFromLootTableCD dropsLootFromLootTableCD = nativeArray11[num8];
					EntityTransaction.SetComponentData(entity10, new LootTableSerializedCD
					{
						Value = dropsLootFromLootTableCD.lootTableID
					});
				}
			}
			if (flag10 && batchInChunk.DidChange(PaintableObject, serializedChunk.ChangeVersion))
			{
				NativeArray<PaintableObjectCD> nativeArray12 = batchInChunk.GetNativeArray(PaintableObject);
				for (int num9 = 0; num9 < batchInChunk.Count; num9++)
				{
					Entity entity11 = SerializedEntities[serializedChunk.StartIndex + num9];
					PaintableObjectCD paintableObjectCD = nativeArray12[num9];
					EntityTransaction.SetComponentData(entity11, new PaintableObjectSerializedCD
					{
						Value = (int)paintableObjectCD.color
					});
				}
			}
			if (flag26 && batchInChunk.DidChange(MealsEaten, serializedChunk.ChangeVersion))
			{
				NativeArray<MealsEatenCD> nativeArray13 = batchInChunk.GetNativeArray(MealsEaten);
				for (int num10 = 0; num10 < batchInChunk.Count; num10++)
				{
					Entity entity12 = SerializedEntities[serializedChunk.StartIndex + num10];
					MealsEatenCD mealsEatenCD = nativeArray13[num10];
					EntityTransaction.SetComponentData(entity12, new BreedStateSerializedCD
					{
						Value = mealsEatenCD.Value
					});
				}
			}
			if (flag27 && batchInChunk.DidChange(BreedToggle, serializedChunk.ChangeVersion))
			{
				NativeArray<BreedToggleCD> nativeArray14 = batchInChunk.GetNativeArray(BreedToggle);
				for (int num11 = 0; num11 < batchInChunk.Count; num11++)
				{
					Entity entity13 = SerializedEntities[serializedChunk.StartIndex + num11];
					BreedToggleCD breedToggleCD = nativeArray14[num11];
					EntityTransaction.SetComponentData(entity13, new BreedToggleSerializedCD
					{
						Value = (breedToggleCD.breedingDisabled ? 1 : 0)
					});
				}
			}
			if (flag11 && batchInChunk.DidChange(Direction, serializedChunk.ChangeVersion))
			{
				NativeArray<DirectionCD> nativeArray15 = batchInChunk.GetNativeArray(Direction);
				for (int num12 = 0; num12 < batchInChunk.Count; num12++)
				{
					Entity entity14 = SerializedEntities[serializedChunk.StartIndex + num12];
					DirectionCD directionCD = nativeArray15[num12];
					EntityTransaction.SetComponentData(entity14, new RotationSerializedCD
					{
						Value = directionCD.direction
					});
				}
			}
			if (flag14 && batchInChunk.DidChange(ActiveEquipmentPreset, serializedChunk.ChangeVersion))
			{
				NativeArray<ActiveEquipmentPresetCD> nativeArray16 = batchInChunk.GetNativeArray(ActiveEquipmentPreset);
				for (int num13 = 0; num13 < batchInChunk.Count; num13++)
				{
					Entity entity15 = SerializedEntities[serializedChunk.StartIndex + num13];
					ActiveEquipmentPresetCD activeEquipmentPresetCD = nativeArray16[num13];
					EntityTransaction.SetComponentData(entity15, new ActiveEquipmentPresetSerializedCD
					{
						Value = activeEquipmentPresetCD.Value
					});
				}
			}
			if (flag15 && batchInChunk.DidChange(PlayerGhost, serializedChunk.ChangeVersion))
			{
				NativeArray<PlayerGhost> nativeArray17 = batchInChunk.GetNativeArray(PlayerGhost);
				for (int num14 = 0; num14 < batchInChunk.Count; num14++)
				{
					Entity entity16 = SerializedEntities[serializedChunk.StartIndex + num14];
					PlayerGhost playerGhost = nativeArray17[num14];
					EntityTransaction.SetComponentData(entity16, new PlayerSerializedCD
					{
						PlayerGuid = playerGhost.playerGuid
					});
				}
			}
			if (flag16 && batchInChunk.DidChange(PlayerLastSession, serializedChunk.ChangeVersion))
			{
				NativeArray<PlayerLastSessionCD> nativeArray18 = batchInChunk.GetNativeArray(PlayerLastSession);
				for (int num15 = 0; num15 < batchInChunk.Count; num15++)
				{
					Entity entity17 = SerializedEntities[serializedChunk.StartIndex + num15];
					EntityTransaction.SetComponentData(entity17, new PlayerLastSessionSerializedCD
					{
						Value = nativeArray18[num15].Value
					});
				}
			}
			if (flag17 && batchInChunk.DidChange(SpawnPoint, serializedChunk.ChangeVersion))
			{
				NativeArray<SpawnPointCD> nativeArray19 = batchInChunk.GetNativeArray(SpawnPoint);
				for (int num16 = 0; num16 < batchInChunk.Count; num16++)
				{
					Entity entity18 = SerializedEntities[serializedChunk.StartIndex + num16];
					SpawnPointCD spawnPointCD = nativeArray19[num16];
					EntityTransaction.SetComponentData(entity18, new SpawnPointCD
					{
						position = spawnPointCD.position
					});
				}
			}
			if (flag18 && batchInChunk.DidChange(Name, serializedChunk.ChangeVersion))
			{
				NativeArray<NameCD> nativeArray20 = batchInChunk.GetNativeArray(Name);
				for (int num17 = 0; num17 < batchInChunk.Count; num17++)
				{
					Entity entity19 = SerializedEntities[serializedChunk.StartIndex + num17];
					NameCD nameCD = nativeArray20[num17];
					EntityTransaction.SetComponentData(entity19, new NameSerializedCD
					{
						Value = nameCD.Value
					});
				}
			}
			if (flag19 && batchInChunk.DidChange(CraftingTimerSlotCrafter, serializedChunk.ChangeVersion))
			{
				BufferAccessor<CraftingTimerSlotBuffer> bufferAccessor2 = batchInChunk.GetBufferAccessor(ref CraftingTimerSlotCrafter);
				for (int num18 = 0; num18 < batchInChunk.Count; num18++)
				{
					Entity entity20 = SerializedEntities[serializedChunk.StartIndex + num18];
					DynamicBuffer<CraftingTimerSlotBuffer> dynamicBuffer2 = bufferAccessor2[num18];
					DynamicBuffer<CraftingSlotTimerSerialized> buffer = EntityTransaction.GetBuffer<CraftingSlotTimerSerialized>(entity20);
					buffer.Clear();
					for (int num19 = 0; num19 < dynamicBuffer2.Length; num19++)
					{
						buffer.Add(new CraftingSlotTimerSerialized
						{
							TimeLeftToCraft = dynamicBuffer2[num19].timeLeftToCraft
						});
					}
				}
			}
			if (flag21 && batchInChunk.DidChange(ConsumedObjectCrafter, serializedChunk.ChangeVersion))
			{
				BufferAccessor<CraftingByConsumedObjectSlotBuffer> bufferAccessor3 = batchInChunk.GetBufferAccessor(ref ConsumedObjectCrafter);
				for (int num20 = 0; num20 < batchInChunk.Count; num20++)
				{
					Entity entity21 = SerializedEntities[serializedChunk.StartIndex + num20];
					DynamicBuffer<CraftingByConsumedObjectSlotBuffer> dynamicBuffer3 = bufferAccessor3[num20];
					DynamicBuffer<CraftingSlotByConsumedObjectsSerialized> buffer2 = EntityTransaction.GetBuffer<CraftingSlotByConsumedObjectsSerialized>(entity21);
					buffer2.Clear();
					for (int num21 = 0; num21 < dynamicBuffer3.Length; num21++)
					{
						buffer2.Add(new CraftingSlotByConsumedObjectsSerialized
						{
							ConsumedObject = new ContainedObjectsSerializedBuffer
							{
								ObjectData = dynamicBuffer3[num21].previousConsumedItem.objectData
							},
							ConsumedObjectAuxIndex = new ContainedObjectsAuxIndexSerializedBuffer
							{
								Value = dynamicBuffer3[num21].previousConsumedItem.auxDataIndex
							}
						});
					}
				}
			}
			if (flag20 && batchInChunk.DidChange(RecipeCrafter, serializedChunk.ChangeVersion))
			{
				BufferAccessor<CraftingByRecipeSlotBuffer> bufferAccessor4 = batchInChunk.GetBufferAccessor(ref RecipeCrafter);
				for (int num22 = 0; num22 < batchInChunk.Count; num22++)
				{
					Entity entity22 = SerializedEntities[serializedChunk.StartIndex + num22];
					DynamicBuffer<CraftingByRecipeSlotBuffer> dynamicBuffer4 = bufferAccessor4[num22];
					DynamicBuffer<CraftingSlotByRecipesSerialized> buffer3 = EntityTransaction.GetBuffer<CraftingSlotByRecipesSerialized>(entity22);
					buffer3.Clear();
					for (int num23 = 0; num23 < dynamicBuffer4.Length; num23++)
					{
						buffer3.Add(new CraftingSlotByRecipesSerialized
						{
							CurrentlyCrafting = dynamicBuffer4[num23].currentlyCraftingIndex
						});
					}
				}
			}
			if (flag22 && batchInChunk.DidChange(ObjectFilter, serializedChunk.ChangeVersion))
			{
				NativeArray<ObjectFilteringCD> nativeArray21 = batchInChunk.GetNativeArray(ObjectFilter);
				for (int num24 = 0; num24 < batchInChunk.Count; num24++)
				{
					Entity entity23 = SerializedEntities[serializedChunk.StartIndex + num24];
					ObjectFilteringCD objectFilteringCD = nativeArray21[num24];
					DynamicBuffer<FilteringSerializedBuffer> buffer4 = EntityTransaction.GetBuffer<FilteringSerializedBuffer>(entity23);
					buffer4.Clear();
					buffer4.Add(new FilteringSerializedBuffer
					{
						filterType = (int)objectFilteringCD.filterType,
						filterObject = objectFilteringCD.filterObject,
						filterVariation = objectFilteringCD.filterVariation
					});
				}
			}
			if (flag23 && batchInChunk.DidChange(PugAutomationMoverOrchestratorSynced, serializedChunk.ChangeVersion))
			{
				NativeArray<PugAutomationEnabledMoverSyncedCD> nativeArray22 = batchInChunk.GetNativeArray(PugAutomationMoverOrchestratorSynced);
				for (int num25 = 0; num25 < batchInChunk.Count; num25++)
				{
					Entity entity24 = SerializedEntities[serializedChunk.StartIndex + num25];
					PugAutomationEnabledMoverSyncedCD pugAutomationEnabledMoverSyncedCD = nativeArray22[num25];
					EntityTransaction.SetComponentData(entity24, new MoverOrchestratorSerialized
					{
						activeMoverIndex = pugAutomationEnabledMoverSyncedCD.moverIndex,
						nextMoverCycleIncrement = pugAutomationEnabledMoverSyncedCD.nextMoverCycleIncrement
					});
				}
			}
			if (flag24 && batchInChunk.DidChange(MoveeBigEntity, serializedChunk.ChangeVersion))
			{
				NativeArray<MoveeBigEntityCD> nativeArray23 = batchInChunk.GetNativeArray(MoveeBigEntity);
				for (int num26 = 0; num26 < batchInChunk.Count; num26++)
				{
					Entity entity25 = SerializedEntities[serializedChunk.StartIndex + num26];
					MoveeBigEntityCD moveeBigEntityCD = nativeArray23[num26];
					EntityTransaction.SetComponentData(entity25, new MoveeSerialized
					{
						target = moveeBigEntityCD.target,
						moveTimer = moveeBigEntityCD.moveTimer
					});
				}
			}
			if (flag25 && batchInChunk.DidChange(SnakeBossSegment, serializedChunk.ChangeVersion))
			{
				NativeArray<SnakeSegmentCD> nativeArray24 = batchInChunk.GetNativeArray(SnakeBossSegment);
				for (int num27 = 0; num27 < batchInChunk.Count; num27++)
				{
					Entity entity26 = SerializedEntities[serializedChunk.StartIndex + num27];
					SnakeSegmentCD snakeSegmentCD = nativeArray24[num27];
					EntityTransaction.SetComponentData(entity26, new SnakeBossSegmentSerializedCD
					{
						GroupIndex = snakeSegmentCD.groupIndex,
						Index = snakeSegmentCD.index
					});
				}
			}
			if (flag28 && batchInChunk.DidChange(ContainedObjects, serializedChunk.ChangeVersion))
			{
				BufferAccessor<ContainedObjectsBuffer> bufferAccessor5 = batchInChunk.GetBufferAccessor(ContainedObjects);
				for (int num28 = 0; num28 < batchInChunk.Count; num28++)
				{
					Entity entity27 = SerializedEntities[serializedChunk.StartIndex + num28];
					DynamicBuffer<ContainedObjectsBuffer> dynamicBuffer5 = bufferAccessor5[num28];
					DynamicBuffer<ContainedObjectsSerializedBuffer> buffer5 = EntityTransaction.GetBuffer<ContainedObjectsSerializedBuffer>(entity27);
					DynamicBuffer<ContainedObjectsAuxIndexSerializedBuffer> buffer6 = EntityTransaction.GetBuffer<ContainedObjectsAuxIndexSerializedBuffer>(entity27);
					buffer5.Clear();
					buffer6.Clear();
					for (int num29 = 0; num29 < dynamicBuffer5.Length; num29++)
					{
						buffer5.Add(new ContainedObjectsSerializedBuffer
						{
							ObjectData = dynamicBuffer5[num29].objectData
						});
						buffer6.Add(new ContainedObjectsAuxIndexSerializedBuffer
						{
							Value = dynamicBuffer5[num29].auxDataIndex
						});
					}
				}
			}
			if (flag29 && batchInChunk.DidChange(Conditions, serializedChunk.ChangeVersion))
			{
				BufferAccessor<ConditionsBuffer> bufferAccessor6 = batchInChunk.GetBufferAccessor(Conditions);
				for (int num30 = 0; num30 < batchInChunk.Count; num30++)
				{
					Entity entity28 = SerializedEntities[serializedChunk.StartIndex + num30];
					DynamicBuffer<ConditionsBuffer> dynamicBuffer6 = bufferAccessor6[num30];
					DynamicBuffer<ConditionsSerializedBuffer> buffer7 = EntityTransaction.GetBuffer<ConditionsSerializedBuffer>(entity28);
					buffer7.Clear();
					for (int num31 = 0; num31 < dynamicBuffer6.Length; num31++)
					{
						Condition condition = dynamicBuffer6[num31].condition;
						buffer7.Add(new ConditionsSerializedBuffer
						{
							Value = new ConditionSerialized
							{
								Id = (int)condition.conditionData.conditionID,
								Value = condition.conditionData.value,
								Duration = condition.conditionData.duration,
								Timer = NetworkTimeUtilities.TimeBetweenTicksInSeconds(CurrentTick, condition.removeTick, TickRate)
							}
						});
					}
				}
			}
			if (flag30 && (batchInChunk.DidChange(ActiveAffixState, serializedChunk.ChangeVersion) || batchInChunk.DidChange(ActiveAffixCondition, serializedChunk.ChangeVersion)))
			{
				BufferAccessor<ActiveAffixStateBuffer> bufferAccessor7 = batchInChunk.GetBufferAccessor(ActiveAffixState);
				BufferAccessor<ActiveAffixConditionsBuffer> bufferAccessor8 = batchInChunk.GetBufferAccessor(ActiveAffixCondition);
				for (int num32 = 0; num32 < batchInChunk.Count; num32++)
				{
					Entity entity29 = SerializedEntities[serializedChunk.StartIndex + num32];
					DynamicBuffer<ActiveAffixConditionsBuffer> dynamicBuffer7 = bufferAccessor8[num32];
					DynamicBuffer<ActiveAffixStateBuffer> dynamicBuffer8 = bufferAccessor7[num32];
					DynamicBuffer<AffixSerializedBuffer> buffer8 = EntityTransaction.GetBuffer<AffixSerializedBuffer>(entity29);
					buffer8.Clear();
					for (int num33 = 0; num33 < dynamicBuffer7.Length; num33++)
					{
						ActiveAffixConditionsBuffer activeAffixConditionsBuffer = dynamicBuffer7[num33];
						ActiveAffixStateBuffer activeAffixStateBuffer = default(ActiveAffixStateBuffer);
						if (num33 < dynamicBuffer8.Length)
						{
							activeAffixStateBuffer = dynamicBuffer8[num33];
						}
						buffer8.Add(new AffixSerializedBuffer
						{
							condition = new ConditionSerialized
							{
								Id = (int)activeAffixConditionsBuffer.conditionData.conditionID,
								Value = activeAffixConditionsBuffer.conditionData.value,
								Duration = activeAffixConditionsBuffer.conditionData.duration
							},
							state = (int)activeAffixStateBuffer.state,
							remainingCooldown = activeAffixStateBuffer.cooldownTimer.GetRemainingSeconds(in CurrentTick, TickRate)
						});
					}
				}
			}
			if (flag31 && batchInChunk.DidChange(DropsLoot, serializedChunk.ChangeVersion))
			{
				BufferAccessor<DropsLootBuffer> bufferAccessor9 = batchInChunk.GetBufferAccessor(DropsLoot);
				for (int num34 = 0; num34 < batchInChunk.Count; num34++)
				{
					Entity entity30 = SerializedEntities[serializedChunk.StartIndex + num34];
					DynamicBuffer<DropsLootBuffer> dynamicBuffer9 = bufferAccessor9[num34];
					DynamicBuffer<DropsLootSerializedBuffer> buffer9 = EntityTransaction.GetBuffer<DropsLootSerializedBuffer>(entity30);
					buffer9.Clear();
					for (int num35 = 0; num35 < dynamicBuffer9.Length; num35++)
					{
						DropsLootBuffer dropsLootBuffer = dynamicBuffer9[num35];
						buffer9.Add(new DropsLootSerializedBuffer
						{
							ObjectID = dropsLootBuffer.lootDropID,
							Amount = dropsLootBuffer.amount
						});
					}
				}
			}
			if (flag32 && batchInChunk.DidChange(Description, serializedChunk.ChangeVersion))
			{
				BufferAccessor<DescriptionBuffer> bufferAccessor10 = batchInChunk.GetBufferAccessor(Description);
				for (int num36 = 0; num36 < batchInChunk.Count; num36++)
				{
					Entity entity31 = SerializedEntities[serializedChunk.StartIndex + num36];
					DynamicBuffer<DescriptionBuffer> dynamicBuffer10 = bufferAccessor10[num36];
					DynamicBuffer<DescriptionSerializedBuffer> buffer10 = EntityTransaction.GetBuffer<DescriptionSerializedBuffer>(entity31);
					buffer10.Clear();
					buffer10.AddRange(dynamicBuffer10.Reinterpret<DescriptionSerializedBuffer>().AsNativeArray());
				}
			}
			if (flag33 && batchInChunk.DidChange(ImmunityZone, serializedChunk.ChangeVersion))
			{
				NativeArray<ImmunityZoneCD> nativeArray25 = batchInChunk.GetNativeArray(ImmunityZone);
				for (int num37 = 0; num37 < batchInChunk.Count; num37++)
				{
					Entity entity32 = SerializedEntities[serializedChunk.StartIndex + num37];
					EntityTransaction.SetComponentData(entity32, new ImmunityZoneShapeSerializedCD
					{
						ShapeType = (nativeArray25[num37].useRectangularBounds ? 1 : 0),
						Offset = nativeArray25[num37].offset,
						SizeValue1 = (nativeArray25[num37].useRectangularBounds ? ((float)nativeArray25[num37].rectangularWidth) : nativeArray25[num37].radius),
						SizeValue2 = (nativeArray25[num37].useRectangularBounds ? nativeArray25[num37].rectangularHeight : 0)
					});
				}
			}
			serializedChunk.ChangeVersion = GlobalSystemVersion;
			batchInChunk.SetChunkComponentData(SerializedChunk, serializedChunk);
			if (serializedChunk.StartIndex != 0)
			{
				Chunks[serializedChunk.ChunkListIndex] = serializedChunk;
			}
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	[BurstCompile]
	private struct SerializeInventoryAuxDataJob : IJobChunk
	{
		public ExclusiveEntityTransaction EntityTransaction;

		public NativeList<Entity> SerializedEntities;

		public NativeList<SerializeWorldDataCD.FreeEntityRange> FreeSerializedEntities;

		public NativeList<SerializedChunkData> Chunks;

		public NativeList<int> FreeChunks;

		public ComponentTypeHandle<SerializedChunkData> SerializedChunk;

		public uint GlobalSystemVersion;

		[ReadOnly]
		public ComponentTypeHandle<InventoryAuxDataCD> InventoryAuxData;

		[ReadOnly]
		public ComponentTypeHandle<InventoryAuxDataPrefabCD> InventoryAuxDataPrefab;

		[ReadOnly]
		public ComponentTypeHandle<NameCD> Name;

		[ReadOnly]
		public BufferTypeHandle<PetTalentBuffer> PetTalents;

		[ReadOnly]
		public ComponentTypeHandle<PetSkinCD> PetSkin;

		[ReadOnly]
		public ComponentTypeHandle<MealsEatenCD> MealsEaten;

		[ReadOnly]
		public ComponentTypeHandle<BreedToggleCD> BreedToggle;

		public unsafe void Execute(in ArchetypeChunk batchInChunk, int chunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			SerializedChunkData serializedChunk = batchInChunk.GetChunkComponentData(SerializedChunk);
			bool flag = batchInChunk.Has(Name);
			bool flag2 = batchInChunk.Has(PetTalents);
			bool flag3 = batchInChunk.Has(PetSkin);
			bool flag4 = batchInChunk.Has(MealsEaten);
			bool flag5 = batchInChunk.Has(BreedToggle);
			if (batchInChunk.DidOrderChange(serializedChunk.ChangeVersion))
			{
				serializedChunk.StartIndex = 0;
				serializedChunk.Count = 0;
				serializedChunk.ChunkListIndex = 0;
				serializedChunk.ChangeVersion = 0u;
			}
			if (serializedChunk.Count > batchInChunk.Count)
			{
				for (int i = batchInChunk.Count; i < serializedChunk.Count; i++)
				{
					EntityTransaction.DestroyEntity(SerializedEntities[serializedChunk.StartIndex + i]);
				}
			}
			else if (serializedChunk.Count < batchInChunk.Count)
			{
				if (serializedChunk.StartIndex == 0)
				{
					AllocateSerializedChunk(in batchInChunk, ref serializedChunk, SerializedEntities, FreeSerializedEntities, Chunks, FreeChunks);
				}
				NativeList<ComponentType> list = new NativeList<ComponentType>(Allocator.Temp);
				list.Add(ComponentType.ReadOnly<InventoryAuxDataSerializedCD>());
				if (flag)
				{
					list.Add(ComponentType.ReadOnly<NameSerializedCD>());
				}
				if (flag2)
				{
					list.Add(ComponentType.ReadOnly<TalentsSerializedCD>());
				}
				if (flag3)
				{
					list.Add(ComponentType.ReadOnly<PetSkinSerializedCD>());
				}
				if (flag4)
				{
					list.Add(ComponentType.ReadOnly<BreedStateSerializedCD>());
				}
				if (flag5)
				{
					list.Add(ComponentType.ReadOnly<BreedToggleSerializedCD>());
				}
				NativeArray<Entity> entities = new NativeArray<Entity>(batchInChunk.Count - serializedChunk.Count, Allocator.Temp);
				EntityArchetype archetype = EntityTransaction.CreateArchetype(list.GetUnsafeReadOnlyPtr(), list.Length);
				EntityTransaction.CreateEntity(archetype, entities);
				for (int j = serializedChunk.Count; j < batchInChunk.Count; j++)
				{
					SerializedEntities[serializedChunk.StartIndex + j] = entities[j - serializedChunk.Count];
				}
				entities.Dispose();
				list.Dispose();
			}
			serializedChunk.Count = batchInChunk.Count;
			if (batchInChunk.DidChange(InventoryAuxData, serializedChunk.ChangeVersion))
			{
				NativeArray<InventoryAuxDataCD> nativeArray = batchInChunk.GetNativeArray(InventoryAuxData);
				NativeArray<InventoryAuxDataPrefabCD> nativeArray2 = batchInChunk.GetNativeArray(InventoryAuxDataPrefab);
				for (int k = 0; k < batchInChunk.Count; k++)
				{
					Entity entity = SerializedEntities[serializedChunk.StartIndex + k];
					EntityTransaction.SetComponentData(entity, new InventoryAuxDataSerializedCD
					{
						Index = nativeArray[k].Index,
						TypeHash = nativeArray2[k].TypeHash
					});
				}
			}
			if (flag && batchInChunk.DidChange(Name, serializedChunk.ChangeVersion))
			{
				NativeArray<NameCD> nativeArray3 = batchInChunk.GetNativeArray(Name);
				for (int l = 0; l < batchInChunk.Count; l++)
				{
					Entity entity2 = SerializedEntities[serializedChunk.StartIndex + l];
					NameCD nameCD = nativeArray3[l];
					EntityTransaction.SetComponentData(entity2, new NameSerializedCD
					{
						Value = nameCD.Value
					});
				}
			}
			if (flag2 && batchInChunk.DidChange(PetTalents, serializedChunk.ChangeVersion))
			{
				BufferAccessor<PetTalentBuffer> bufferAccessor = batchInChunk.GetBufferAccessor(PetTalents);
				for (int m = 0; m < batchInChunk.Count; m++)
				{
					Entity entity3 = SerializedEntities[serializedChunk.StartIndex + m];
					DynamicBuffer<PetTalentBuffer> dynamicBuffer = bufferAccessor[m];
					DynamicBuffer<TalentsSerializedCD> buffer = EntityTransaction.GetBuffer<TalentsSerializedCD>(entity3);
					buffer.Clear();
					for (int n = 0; n < dynamicBuffer.Length; n++)
					{
						buffer.Add(new TalentsSerializedCD
						{
							Talent = (int)dynamicBuffer[n].petTalentID,
							Points = dynamicBuffer[n].points
						});
					}
				}
			}
			if (flag3 && batchInChunk.DidChange(PetSkin, serializedChunk.ChangeVersion))
			{
				NativeArray<PetSkinCD> nativeArray4 = batchInChunk.GetNativeArray(PetSkin);
				for (int num = 0; num < batchInChunk.Count; num++)
				{
					Entity entity4 = SerializedEntities[serializedChunk.StartIndex + num];
					PetSkinCD petSkinCD = nativeArray4[num];
					EntityTransaction.SetComponentData(entity4, new PetSkinSerializedCD
					{
						skinIndex = petSkinCD.skinIndex
					});
				}
			}
			if (flag4 && batchInChunk.DidChange(MealsEaten, serializedChunk.ChangeVersion))
			{
				NativeArray<MealsEatenCD> nativeArray5 = batchInChunk.GetNativeArray(MealsEaten);
				for (int num2 = 0; num2 < batchInChunk.Count; num2++)
				{
					Entity entity5 = SerializedEntities[serializedChunk.StartIndex + num2];
					MealsEatenCD mealsEatenCD = nativeArray5[num2];
					EntityTransaction.SetComponentData(entity5, new BreedStateSerializedCD
					{
						Value = mealsEatenCD.Value
					});
				}
			}
			if (flag5 && batchInChunk.DidChange(BreedToggle, serializedChunk.ChangeVersion))
			{
				NativeArray<BreedToggleCD> nativeArray6 = batchInChunk.GetNativeArray(BreedToggle);
				for (int num3 = 0; num3 < batchInChunk.Count; num3++)
				{
					Entity entity6 = SerializedEntities[serializedChunk.StartIndex + num3];
					BreedToggleCD breedToggleCD = nativeArray6[num3];
					EntityTransaction.SetComponentData(entity6, new BreedToggleSerializedCD
					{
						Value = (breedToggleCD.breedingDisabled ? 1 : 0)
					});
				}
			}
			serializedChunk.ChangeVersion = GlobalSystemVersion;
			batchInChunk.SetChunkComponentData(SerializedChunk, serializedChunk);
			if (serializedChunk.StartIndex != 0)
			{
				Chunks[serializedChunk.ChunkListIndex] = serializedChunk;
			}
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	[BurstCompile]
	private struct SerializeSubMapJob : IJobChunk
	{
		public ExclusiveEntityTransaction EntityTransaction;

		public uint GlobalSystemVersion;

		public NativeList<Entity> SerializedEntities;

		public NativeList<SerializeWorldDataCD.FreeEntityRange> FreeSerializedEntities;

		public NativeList<SerializedChunkData> Chunks;

		public NativeList<int> FreeChunks;

		public ComponentTypeHandle<SerializedChunkData> SerializeChunk;

		public EntityArchetype SerializedArchetype;

		[ReadOnly]
		public ComponentTypeHandle<LocalTransform> Transform;

		[ReadOnly]
		public ComponentTypeHandle<SubMapCD> SubMap;

		[ReadOnly]
		public BufferTypeHandle<SubMapLayerBuffer> SubMapLayerBuffer;

		public void Execute(in ArchetypeChunk batchInChunk, int chunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			SerializedChunkData serializedChunk = batchInChunk.GetChunkComponentData(SerializeChunk);
			uint changeVersion = serializedChunk.ChangeVersion;
			serializedChunk.ChangeVersion = GlobalSystemVersion;
			if (batchInChunk.DidOrderChange(changeVersion))
			{
				serializedChunk.StartIndex = 0;
				serializedChunk.Count = 0;
				serializedChunk.ChunkListIndex = 0;
				serializedChunk.ChangeVersion = 0u;
			}
			if (batchInChunk.DidChange(SubMapLayerBuffer, changeVersion))
			{
				if (serializedChunk.Count > batchInChunk.Count)
				{
					for (int i = batchInChunk.Count; i < serializedChunk.Count; i++)
					{
						EntityTransaction.DestroyEntity(SerializedEntities[serializedChunk.StartIndex + i]);
					}
				}
				else if (serializedChunk.Count < batchInChunk.Count)
				{
					if (serializedChunk.StartIndex == 0)
					{
						AllocateSerializedChunk(in batchInChunk, ref serializedChunk, SerializedEntities, FreeSerializedEntities, Chunks, FreeChunks);
					}
					NativeArray<Entity> entities = new NativeArray<Entity>(batchInChunk.Count - serializedChunk.Count, Allocator.Temp);
					EntityTransaction.CreateEntity(SerializedArchetype, entities);
					for (int j = serializedChunk.Count; j < batchInChunk.Count; j++)
					{
						SerializedEntities[serializedChunk.StartIndex + j] = entities[j - serializedChunk.Count];
					}
					entities.Dispose();
				}
				NativeArray<LocalTransform> nativeArray = batchInChunk.GetNativeArray(Transform);
				NativeArray<SubMapCD> nativeArray2 = batchInChunk.GetNativeArray(SubMap);
				BufferAccessor<SubMapLayerBuffer> bufferAccessor = batchInChunk.GetBufferAccessor(SubMapLayerBuffer);
				for (int k = 0; k < batchInChunk.Count; k++)
				{
					Entity entity = SerializedEntities[serializedChunk.StartIndex + k];
					EntityTransaction.SetComponentData(entity, new Translation
					{
						Value = nativeArray[k].Position
					});
					EntityTransaction.SetComponentData(entity, new SubMapSerializedCD
					{
						Position = nativeArray2[k].index
					});
					DynamicBuffer<SubMapLayerSerializedBuffer> dynamicBuffer = bufferAccessor[k].Reinterpret<SubMapLayerSerializedBuffer>();
					DynamicBuffer<SubMapLayerSerializedBuffer> buffer = EntityTransaction.GetBuffer<SubMapLayerSerializedBuffer>(entity);
					buffer.Clear();
					for (int l = 0; l < dynamicBuffer.Length; l++)
					{
						if (dynamicBuffer[l].data.layer.tileType != TileType.immune)
						{
							buffer.Add(dynamicBuffer[l]);
						}
					}
				}
			}
			serializedChunk.Count = batchInChunk.Count;
			batchInChunk.SetChunkComponentData(SerializeChunk, serializedChunk);
			if (serializedChunk.StartIndex != 0)
			{
				Chunks[serializedChunk.ChunkListIndex] = serializedChunk;
			}
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	[BurstCompile]
	private struct SerializePheromoneJob : IJobChunk
	{
		public ExclusiveEntityTransaction EntityTransaction;

		public uint GlobalSystemVersion;

		public NativeList<Entity> SerializedEntities;

		public NativeList<SerializeWorldDataCD.FreeEntityRange> FreeSerializedEntities;

		public NativeList<SerializedChunkData> Chunks;

		public NativeList<int> FreeChunks;

		public ComponentTypeHandle<SerializedChunkData> SerializeChunk;

		public EntityArchetype SerializedArchetype;

		[ReadOnly]
		public ComponentTypeHandle<PheromoneCD> Pheromone;

		public unsafe void Execute(in ArchetypeChunk batchInChunk, int chunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			SerializedChunkData serializedChunk = batchInChunk.GetChunkComponentData(SerializeChunk);
			uint changeVersion = serializedChunk.ChangeVersion;
			serializedChunk.ChangeVersion = GlobalSystemVersion;
			if (batchInChunk.DidChange(Pheromone, changeVersion))
			{
				if (serializedChunk.Count > batchInChunk.Count)
				{
					for (int i = batchInChunk.Count; i < serializedChunk.Count; i++)
					{
						EntityTransaction.DestroyEntity(SerializedEntities[serializedChunk.StartIndex + i]);
					}
				}
				else if (serializedChunk.Count < batchInChunk.Count)
				{
					if (serializedChunk.StartIndex == 0)
					{
						AllocateSerializedChunk(in batchInChunk, ref serializedChunk, SerializedEntities, FreeSerializedEntities, Chunks, FreeChunks);
					}
					NativeArray<Entity> entities = new NativeArray<Entity>(batchInChunk.Count - serializedChunk.Count, Allocator.Temp);
					EntityTransaction.CreateEntity(SerializedArchetype, entities);
					for (int j = serializedChunk.Count; j < batchInChunk.Count; j++)
					{
						SerializedEntities[serializedChunk.StartIndex + j] = entities[j - serializedChunk.Count];
					}
					entities.Dispose();
				}
				NativeArray<PheromoneCD> nativeArray = batchInChunk.GetNativeArray(Pheromone);
				for (int k = 0; k < batchInChunk.Count; k++)
				{
					Entity entity = SerializedEntities[serializedChunk.StartIndex + k];
					PheromoneCD pheromoneCD = nativeArray[k];
					PheromoneSerializedCD componentData = new PheromoneSerializedCD
					{
						Position = pheromoneCD.position
					};
					ushort* source = pheromoneCD.pheromone.values;
					UnsafeUtility.MemCpy(componentData.Values.GetUnsafePtr(), source, 2 * UnsafeUtility.SizeOf<ushort>());
					EntityTransaction.SetComponentData(entity, componentData);
				}
			}
			serializedChunk.Count = batchInChunk.Count;
			batchInChunk.SetChunkComponentData(SerializeChunk, serializedChunk);
			if (serializedChunk.StartIndex != 0)
			{
				Chunks[serializedChunk.ChunkListIndex] = serializedChunk;
			}
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	[BurstCompile]
	private struct CleanupRemovedChunksJob : IJob
	{
		public ExclusiveEntityTransaction EntityTransaction;

		public NativeList<Entity> SerializedEntities;

		public NativeList<SerializeWorldDataCD.FreeEntityRange> FreeSerializedEntities;

		public NativeList<SerializedChunkData> Chunks;

		public NativeList<int> FreeChunks;

		public void Execute()
		{
			for (int value = Chunks.Length - 1; value >= 0; value--)
			{
				SerializedChunkData serializedChunkData = Chunks[value];
				if (serializedChunkData.StartIndex != 0 && serializedChunkData.ChunkListIndex == -1)
				{
					if (serializedChunkData.StartIndex != 0)
					{
						for (int i = serializedChunkData.StartIndex; i < serializedChunkData.StartIndex + serializedChunkData.Count; i++)
						{
							EntityTransaction.DestroyEntity(SerializedEntities[i]);
						}
						ref NativeList<SerializeWorldDataCD.FreeEntityRange> freeSerializedEntities = ref FreeSerializedEntities;
						SerializeWorldDataCD.FreeEntityRange value2 = new SerializeWorldDataCD.FreeEntityRange
						{
							StartIndex = serializedChunkData.StartIndex,
							Capacity = serializedChunkData.Capacity
						};
						freeSerializedEntities.Add(in value2);
					}
					Chunks[value] = default(SerializedChunkData);
					FreeChunks.Add(in value);
				}
			}
		}
	}

	[BurstCompile]
	private struct SerializeSpawnedCustomSceneJob : IJobChunk
	{
		public ExclusiveEntityTransaction EntityTransaction;

		public EntityArchetype CustomSceneSerializedArchetypeWithPosition;

		public EntityArchetype CustomSceneSerializedArchetypeWithoutPosition;

		[ReadOnly]
		public ComponentTypeHandle<Translation> TranslationHandle;

		[ReadOnly]
		public ComponentTypeHandle<CustomSceneCD> CustomSceneHandle;

		public void Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			ChunkEntityEnumerator chunkEntityEnumerator = new ChunkEntityEnumerator(useEnabledMask, chunkEnabledMask, chunk.Count);
			NativeArray<CustomSceneCD> nativeArray = chunk.GetNativeArray(CustomSceneHandle);
			if (chunk.Has(TranslationHandle))
			{
				NativeArray<Translation> nativeArray2 = chunk.GetNativeArray(TranslationHandle);
				int nextIndex;
				while (chunkEntityEnumerator.NextEntityIndex(out nextIndex))
				{
					Entity entity = EntityTransaction.CreateEntity(CustomSceneSerializedArchetypeWithPosition);
					EntityTransaction.SetComponentData(entity, new Translation
					{
						Value = nativeArray2[nextIndex].Value
					});
					EntityTransaction.SetComponentData(entity, CustomSceneSerializedCD.FromFixedString32Bytes(nativeArray[nextIndex].name));
				}
			}
			else
			{
				int nextIndex2;
				while (chunkEntityEnumerator.NextEntityIndex(out nextIndex2))
				{
					Entity entity2 = EntityTransaction.CreateEntity(CustomSceneSerializedArchetypeWithoutPosition);
					EntityTransaction.SetComponentData(entity2, CustomSceneSerializedCD.FromFixedString32Bytes(nativeArray[nextIndex2].name));
				}
			}
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	[BurstCompile]
	[WithOptions(EntityQueryOptions.IncludeDisabledEntities)]
	private struct SerializeSpawnedDungeonJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<DungeonNameSerializedCD> __DungeonNameSerializedCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
					__DungeonNameSerializedCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<DungeonNameSerializedCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
					__DungeonNameSerializedCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<DungeonNameSerializedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeDisabledEntities);
				DefaultQuery = entityQueryBuilder2.Build(ref state);
				entityQueryBuilder.Reset();
				entityQueryBuilder.Dispose();
			}

			public void Init(ref SystemState state, bool assignDefaultQuery)
			{
				if (assignDefaultQuery)
				{
					__AssignQueries(ref state);
				}
				__TypeHandle.__AssignHandles(ref state);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void Run(ref SerializeSpawnedDungeonJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref SerializeSpawnedDungeonJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref SerializeSpawnedDungeonJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref SerializeSpawnedDungeonJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref SerializeSpawnedDungeonJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref SerializeSpawnedDungeonJob job, EntityManager entityManager)
			{
			}
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct InternalCompiler
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			public static void CheckForErrors(int scheduleType)
			{
			}
		}

		public ExclusiveEntityTransaction EntityTransaction;

		public EntityArchetype DungeonNameSerializedArchetype;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		public void Execute(in LocalTransform transform, in DungeonNameSerializedCD dungeonName)
		{
			Entity entity = EntityTransaction.CreateEntity(DungeonNameSerializedArchetype);
			EntityTransaction.SetComponentData(entity, new Translation
			{
				Value = transform.Position
			});
			EntityTransaction.SetComponentData(entity, dungeonName);
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__DungeonNameSerializedCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DungeonNameSerializedCD>(nativeArrayPtr2, i));
					num++;
				}
				return;
			}
			if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
			{
				int nextRangeBegin = 0;
				int nextRangeEnd = 0;
				while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out nextRangeBegin, out nextRangeEnd))
				{
					while (nextRangeBegin < nextRangeEnd)
					{
						Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DungeonNameSerializedCD>(nativeArrayPtr2, nextRangeBegin));
						nextRangeBegin++;
						num++;
					}
				}
				return;
			}
			ulong num2 = chunkEnabledMask.ULong0;
			int num3 = math.min(64, count);
			for (int j = 0; j < num3; j++)
			{
				if ((num2 & 1) != 0L)
				{
					Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DungeonNameSerializedCD>(nativeArrayPtr2, j));
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DungeonNameSerializedCD>(nativeArrayPtr2, k));
					num++;
				}
				num2 >>= 1;
			}
		}

		private JobHandle __ThrowCodeGenException()
		{
			throw new Exception("This method should have been replaced by source gen.");
		}

		public void Run()
		{
			__ThrowCodeGenException();
		}

		public void RunByRef()
		{
			__ThrowCodeGenException();
		}

		public void Run(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void RunByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public JobHandle Schedule(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleByRef(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle Schedule(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleByRef(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public void Schedule()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleByRef()
		{
			__ThrowCodeGenException();
		}

		public void Schedule(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void ScheduleByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
		{
			return __ThrowCodeGenException();
		}

		public void ScheduleParallel()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallelByRef()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallel(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallelByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	[BurstCompile]
	private struct SerializeScannedJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public ComponentTypeHandle<CanBeScannedCD> __CanBeScannedCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__CanBeScannedCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<CanBeScannedCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__CanBeScannedCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				DefaultQuery = entityQueryBuilder.WithAll<CanBeScannedCD>().Build(ref state);
				entityQueryBuilder.Reset();
				entityQueryBuilder.Dispose();
			}

			public void Init(ref SystemState state, bool assignDefaultQuery)
			{
				if (assignDefaultQuery)
				{
					__AssignQueries(ref state);
				}
				__TypeHandle.__AssignHandles(ref state);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void Run(ref SerializeScannedJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref SerializeScannedJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref SerializeScannedJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref SerializeScannedJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref SerializeScannedJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref SerializeScannedJob job, EntityManager entityManager)
			{
			}
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct InternalCompiler
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			public static void CheckForErrors(int scheduleType)
			{
			}
		}

		public ExclusiveEntityTransaction EntityTransaction;

		public EntityArchetype ScannedSerializedArchetype;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		public void Execute(in CanBeScannedCD canBeScanned)
		{
			Entity entity = EntityTransaction.CreateEntity(ScannedSerializedArchetype);
			EntityTransaction.SetComponentData(entity, (ObjectDataSerializedCD)canBeScanned.objectData);
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__CanBeScannedCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CanBeScannedCD>(nativeArrayPtr, i));
					num++;
				}
				return;
			}
			if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
			{
				int nextRangeBegin = 0;
				int nextRangeEnd = 0;
				while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out nextRangeBegin, out nextRangeEnd))
				{
					while (nextRangeBegin < nextRangeEnd)
					{
						Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CanBeScannedCD>(nativeArrayPtr, nextRangeBegin));
						nextRangeBegin++;
						num++;
					}
				}
				return;
			}
			ulong num2 = chunkEnabledMask.ULong0;
			int num3 = math.min(64, count);
			for (int j = 0; j < num3; j++)
			{
				if ((num2 & 1) != 0L)
				{
					Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CanBeScannedCD>(nativeArrayPtr, j));
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CanBeScannedCD>(nativeArrayPtr, k));
					num++;
				}
				num2 >>= 1;
			}
		}

		private JobHandle __ThrowCodeGenException()
		{
			throw new Exception("This method should have been replaced by source gen.");
		}

		public void Run()
		{
			__ThrowCodeGenException();
		}

		public void RunByRef()
		{
			__ThrowCodeGenException();
		}

		public void Run(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void RunByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public JobHandle Schedule(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleByRef(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle Schedule(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleByRef(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public void Schedule()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleByRef()
		{
			__ThrowCodeGenException();
		}

		public void Schedule(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void ScheduleByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
		{
			return __ThrowCodeGenException();
		}

		public void ScheduleParallel()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallelByRef()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallel(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallelByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	[BurstCompile]
	private struct SerializePendingScanJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public ComponentTypeHandle<PugScanCD> __PugScan_PugScanCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__PugScan_PugScanCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PugScanCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__PugScan_PugScanCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				DefaultQuery = entityQueryBuilder.WithAll<PugScanCD>().Build(ref state);
				entityQueryBuilder.Reset();
				entityQueryBuilder.Dispose();
			}

			public void Init(ref SystemState state, bool assignDefaultQuery)
			{
				if (assignDefaultQuery)
				{
					__AssignQueries(ref state);
				}
				__TypeHandle.__AssignHandles(ref state);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void Run(ref SerializePendingScanJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref SerializePendingScanJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref SerializePendingScanJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref SerializePendingScanJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref SerializePendingScanJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref SerializePendingScanJob job, EntityManager entityManager)
			{
			}
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct InternalCompiler
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			public static void CheckForErrors(int scheduleType)
			{
			}
		}

		public ExclusiveEntityTransaction EntityTransaction;

		public EntityArchetype ScannedSerializedArchetype;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		public void Execute(in PugScanCD scan)
		{
			Entity entity = EntityTransaction.CreateEntity(ScannedSerializedArchetype);
			EntityTransaction.SetComponentData(entity, (ObjectDataSerializedCD)scan.objectToScan);
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__PugScan_PugScanCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PugScanCD>(nativeArrayPtr, i));
					num++;
				}
				return;
			}
			if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
			{
				int nextRangeBegin = 0;
				int nextRangeEnd = 0;
				while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out nextRangeBegin, out nextRangeEnd))
				{
					while (nextRangeBegin < nextRangeEnd)
					{
						Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PugScanCD>(nativeArrayPtr, nextRangeBegin));
						nextRangeBegin++;
						num++;
					}
				}
				return;
			}
			ulong num2 = chunkEnabledMask.ULong0;
			int num3 = math.min(64, count);
			for (int j = 0; j < num3; j++)
			{
				if ((num2 & 1) != 0L)
				{
					Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PugScanCD>(nativeArrayPtr, j));
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PugScanCD>(nativeArrayPtr, k));
					num++;
				}
				num2 >>= 1;
			}
		}

		private JobHandle __ThrowCodeGenException()
		{
			throw new Exception("This method should have been replaced by source gen.");
		}

		public void Run()
		{
			__ThrowCodeGenException();
		}

		public void RunByRef()
		{
			__ThrowCodeGenException();
		}

		public void Run(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void RunByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public JobHandle Schedule(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleByRef(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle Schedule(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleByRef(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public void Schedule()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleByRef()
		{
			__ThrowCodeGenException();
		}

		public void Schedule(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void ScheduleByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
		{
			return __ThrowCodeGenException();
		}

		public void ScheduleParallel()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallelByRef()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallel(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallelByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	private struct SerializeJob : IJob
	{
		private static readonly ProfilerMarker ExtractHeaderMarker = new ProfilerMarker("ExtractHeader");

		private static readonly ProfilerMarker CompressionMarker = new ProfilerMarker("SerializeAndCompress");

		private const int DOTS_HEADER_SIZE = 152;

		private static readonly long DotsHeaderMagic = BitConverter.ToInt64(new byte[8] { 68, 79, 84, 83, 66, 73, 78, 33 });

		public EntityManager entityManager;

		public NativeList<byte> compressedData;

		public unsafe void Execute()
		{
			entityManager.EndExclusiveEntityTransaction();
			NativeList<byte> list = new NativeList<byte>(152, Allocator.Temp);
			using (NativeListOutputStream stream = new NativeListOutputStream(list))
			{
				using (ExtractHeaderMarker.Auto())
				{
					using StreamBinaryWriter writer = new StreamBinaryWriter(stream, 0, 152);
					SerializeUtility.SerializeWorld(entityManager, writer);
				}
			}
			using NativeListOutputStream stream2 = new NativeListOutputStream(compressedData);
			using BrotliStream brotliStream = new BrotliStream(stream2, System.IO.Compression.CompressionLevel.Fastest);
			using (CompressionMarker.Auto())
			{
				ReadOnlySpan<byte> buffer = new ReadOnlySpan<byte>(list.GetUnsafeReadOnlyPtr(), 152);
				brotliStream.Write(buffer);
				using StreamBinaryWriter writer2 = new StreamBinaryWriter(brotliStream, 152);
				SerializeUtility.SerializeWorld(entityManager, writer2);
			}
		}
	}

	private struct TypeHandle
	{
		public BufferLookup<KilledEnemiesBuffer> __KilledEnemiesBuffer_RW_BufferLookup;

		public BufferLookup<ActivatedContentBundlesBuffer> __ActivatedContentBundlesBuffer_RW_BufferLookup;

		public ComponentTypeHandle<SerializedChunkData> __SerializedChunkData_RW_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<ObjectDataCD> __ObjectDataCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<CharacterGuidCD> __CharacterGuidCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<ClaimedByCharacterGuidCD> __ClaimedByCharacterGuidCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<PlayerGuidCD> __PlayerGuidCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<ClaimedByPlayerGuidCD> __ClaimedByPlayerGuidCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<HealthCD> __HealthCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<GrowingCD> __GrowingCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<GrowTimerRefCD> __GrowTimerRefCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<HungerCD> __HungerCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<DropsLootFromLootTableCD> __DropsLootFromLootTableCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<PaintableObjectCD> __PaintableObjectCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<DirectionCD> __DirectionCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<HasBeenDiscoveredCD> __HasBeenDiscoveredCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<CustomSceneObjectCD> __CustomSceneObjectCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<ActiveEquipmentPresetCD> __ActiveEquipmentPresetCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<PlayerGhost> __PlayerGhost_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<PlayerLastSessionCD> __PlayerLastSessionCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<SpawnPointCD> __SpawnPointCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<NameCD> __NameCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<AuthorCD> __AuthorCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<CraftingCD> __CraftingCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<SnakeSegmentCD> __SnakeSegmentCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<MealsEatenCD> __MealsEatenCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<BreedToggleCD> __BreedToggleCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<ObjectFilteringCD> __ObjectFilteringCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<PugAutomationEnabledMoverSyncedCD> __Pug_Automation_PugAutomationEnabledMoverSyncedCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<MoveeBigEntityCD> __Pug_Automation_MoveeBigEntityCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<ImmunityZoneCD> __ImmunityZoneCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public BufferTypeHandle<ContainedObjectsBuffer> __ContainedObjectsBuffer_RO_BufferTypeHandle;

		[ReadOnly]
		public BufferTypeHandle<ConditionsBuffer> __ConditionsBuffer_RO_BufferTypeHandle;

		[ReadOnly]
		public BufferTypeHandle<ActiveAffixStateBuffer> __Affixes_Components_ActiveAffixStateBuffer_RO_BufferTypeHandle;

		[ReadOnly]
		public BufferTypeHandle<ActiveAffixConditionsBuffer> __ActiveAffixConditionsBuffer_RO_BufferTypeHandle;

		[ReadOnly]
		public BufferTypeHandle<DropsLootBuffer> __DropsLootBuffer_RO_BufferTypeHandle;

		[ReadOnly]
		public BufferTypeHandle<SummarizedConditionEffectsBuffer> __SummarizedConditionEffectsBuffer_RO_BufferTypeHandle;

		[ReadOnly]
		public BufferTypeHandle<DescriptionBuffer> __DescriptionBuffer_RO_BufferTypeHandle;

		[ReadOnly]
		public BufferTypeHandle<CraftingTimerSlotBuffer> __CraftingTimerSlotBuffer_RO_BufferTypeHandle;

		[ReadOnly]
		public BufferTypeHandle<CraftingByRecipeSlotBuffer> __CraftingByRecipeSlotBuffer_RO_BufferTypeHandle;

		[ReadOnly]
		public BufferTypeHandle<CraftingByConsumedObjectSlotBuffer> __CraftingByConsumedObjectSlotBuffer_RO_BufferTypeHandle;

		[ReadOnly]
		public ComponentLookup<GrowTimerCD> __GrowTimerCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentTypeHandle<InventoryAuxDataCD> __InventoryAuxDataCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<InventoryAuxDataPrefabCD> __InventoryAuxDataPrefabCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public BufferTypeHandle<PetTalentBuffer> __PetTalentBuffer_RO_BufferTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<PetSkinCD> __PetSkinCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<SubMapCD> __SubMapCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public BufferTypeHandle<SubMapLayerBuffer> __SubMapLayerBuffer_RO_BufferTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<PheromoneCD> __PheromoneCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<Translation> __Unity_Transforms_Translation_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<CustomSceneCD> __CustomSceneCD_RO_ComponentTypeHandle;

		public SerializeSpawnedDungeonJob.InternalCompilerQueryAndHandleData __SerializeWorldSystem_SerializeSpawnedDungeonJob_WithDefaultQuery_JobEntityTypeHandle;

		public SerializeScannedJob.InternalCompilerQueryAndHandleData __SerializeWorldSystem_SerializeScannedJob_WithDefaultQuery_JobEntityTypeHandle;

		public SerializePendingScanJob.InternalCompilerQueryAndHandleData __SerializeWorldSystem_SerializePendingScanJob_WithDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__KilledEnemiesBuffer_RW_BufferLookup = state.GetBufferLookup<KilledEnemiesBuffer>();
			__ActivatedContentBundlesBuffer_RW_BufferLookup = state.GetBufferLookup<ActivatedContentBundlesBuffer>();
			__SerializedChunkData_RW_ComponentTypeHandle = state.GetComponentTypeHandle<SerializedChunkData>();
			__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
			__ObjectDataCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ObjectDataCD>(isReadOnly: true);
			__CharacterGuidCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<CharacterGuidCD>(isReadOnly: true);
			__ClaimedByCharacterGuidCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ClaimedByCharacterGuidCD>(isReadOnly: true);
			__PlayerGuidCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PlayerGuidCD>(isReadOnly: true);
			__ClaimedByPlayerGuidCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ClaimedByPlayerGuidCD>(isReadOnly: true);
			__HealthCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<HealthCD>(isReadOnly: true);
			__GrowingCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<GrowingCD>(isReadOnly: true);
			__GrowTimerRefCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<GrowTimerRefCD>(isReadOnly: true);
			__HungerCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<HungerCD>(isReadOnly: true);
			__DropsLootFromLootTableCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<DropsLootFromLootTableCD>(isReadOnly: true);
			__PaintableObjectCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PaintableObjectCD>(isReadOnly: true);
			__DirectionCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<DirectionCD>(isReadOnly: true);
			__HasBeenDiscoveredCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<HasBeenDiscoveredCD>(isReadOnly: true);
			__CustomSceneObjectCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<CustomSceneObjectCD>(isReadOnly: true);
			__ActiveEquipmentPresetCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ActiveEquipmentPresetCD>(isReadOnly: true);
			__PlayerGhost_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PlayerGhost>(isReadOnly: true);
			__PlayerLastSessionCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PlayerLastSessionCD>(isReadOnly: true);
			__SpawnPointCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<SpawnPointCD>(isReadOnly: true);
			__NameCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<NameCD>(isReadOnly: true);
			__AuthorCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<AuthorCD>(isReadOnly: true);
			__CraftingCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<CraftingCD>(isReadOnly: true);
			__SnakeSegmentCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<SnakeSegmentCD>(isReadOnly: true);
			__MealsEatenCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<MealsEatenCD>(isReadOnly: true);
			__BreedToggleCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<BreedToggleCD>(isReadOnly: true);
			__ObjectFilteringCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ObjectFilteringCD>(isReadOnly: true);
			__Pug_Automation_PugAutomationEnabledMoverSyncedCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PugAutomationEnabledMoverSyncedCD>(isReadOnly: true);
			__Pug_Automation_MoveeBigEntityCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<MoveeBigEntityCD>(isReadOnly: true);
			__ImmunityZoneCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ImmunityZoneCD>(isReadOnly: true);
			__ContainedObjectsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<ContainedObjectsBuffer>(isReadOnly: true);
			__ConditionsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<ConditionsBuffer>(isReadOnly: true);
			__Affixes_Components_ActiveAffixStateBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<ActiveAffixStateBuffer>(isReadOnly: true);
			__ActiveAffixConditionsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<ActiveAffixConditionsBuffer>(isReadOnly: true);
			__DropsLootBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<DropsLootBuffer>(isReadOnly: true);
			__SummarizedConditionEffectsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<SummarizedConditionEffectsBuffer>(isReadOnly: true);
			__DescriptionBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<DescriptionBuffer>(isReadOnly: true);
			__CraftingTimerSlotBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<CraftingTimerSlotBuffer>(isReadOnly: true);
			__CraftingByRecipeSlotBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<CraftingByRecipeSlotBuffer>(isReadOnly: true);
			__CraftingByConsumedObjectSlotBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<CraftingByConsumedObjectSlotBuffer>(isReadOnly: true);
			__GrowTimerCD_RO_ComponentLookup = state.GetComponentLookup<GrowTimerCD>(isReadOnly: true);
			__InventoryAuxDataCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<InventoryAuxDataCD>(isReadOnly: true);
			__InventoryAuxDataPrefabCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<InventoryAuxDataPrefabCD>(isReadOnly: true);
			__PetTalentBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<PetTalentBuffer>(isReadOnly: true);
			__PetSkinCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PetSkinCD>(isReadOnly: true);
			__SubMapCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<SubMapCD>(isReadOnly: true);
			__SubMapLayerBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<SubMapLayerBuffer>(isReadOnly: true);
			__PheromoneCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PheromoneCD>(isReadOnly: true);
			__Unity_Transforms_Translation_RO_ComponentTypeHandle = state.GetComponentTypeHandle<Translation>(isReadOnly: true);
			__CustomSceneCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<CustomSceneCD>(isReadOnly: true);
			__SerializeWorldSystem_SerializeSpawnedDungeonJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__SerializeWorldSystem_SerializeScannedJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__SerializeWorldSystem_SerializePendingScanJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
		}
	}

	private static readonly ProfilerMarker FinishPendingSerializationsMarker = new ProfilerMarker("FinishPendingSerializations");

	private static readonly ProfilerMarker RunWorldSerializationThreadMarker = new ProfilerMarker("RunWorldSerializationThread");

	private const System.Threading.ThreadPriority STANDARD_SERIALIZER_THREAD_PRIORITY = System.Threading.ThreadPriority.BelowNormal;

	private const System.Threading.ThreadPriority INCREASED_SERIALIZER_THREAD_PRIORITY = System.Threading.ThreadPriority.Normal;

	private const float INCREASED_SERIALIZER_THREAD_PRIORITY_DELAY = 30f;

	public DateTime LastWorldWrite;

	private World outputWorld;

	private JobHandle pendingSerializationJobHandle;

	private NativeList<byte> serializedDataBuffer;

	private int _serializationFailed;

	private BeginSimulationEntityCommandBufferSystem ecbSystem;

	private EntityQuery triggerQ;

	private EntityQuery blockSaveQ;

	private EntityQuery outputWorldRemoveAfterSerializeQ;

	private EntityQuery activePlayerQ;

	private EntityArchetype _submapSerializedArchetype;

	private EntityArchetype _pheromoneSerializedArchetype;

	private EntityArchetype _customSceneWithPositionSerializedArchetype;

	private EntityArchetype _customSceneWithoutPositionSerializedArchetype;

	private EntityArchetype _dungeonNameSerializedArchetype;

	private EntityArchetype _scannedSerializedArchetype;

	private EntityArchetype _serverGuidSerializedArchetype;

	private EntityArchetype _serverSeedSerializedArchetype;

	private EntityArchetype _worldVersionSerializedArchetype;

	private EntityArchetype _killedEnemiesBufferSerializedArchetype;

	private EntityArchetype _worldGenerationSerializedArchetype;

	private EntityArchetype _worldGenerationParametersSerializedArchetype;

	private EntityArchetype _objectPropertiesSerializedArchetype;

	private EntityArchetype _removedObjectPropertiesSerializedArchetype;

	private EntityArchetype _theGreatWallStatusSerializedArchetype;

	private EntityArchetype _activatedContentBundlesSerializedArchetype;

	private EntityArchetype _worldCreationVersionSerializedArchetype;

	private EntityQuery _serializeObjectsQ;

	private EntityQuery _serializeInventoryAuxDataQ;

	private EntityQuery _serializeSubMapQ;

	private EntityQuery _serializePheromoneQ;

	private uint _lastSystemVersion;

	private Thread _serializeThread;

	private BlockingCollection<SerializeJob> _serializeQueue = new BlockingCollection<SerializeJob>();

	private ManualResetEvent _noPendingSerialization;

	private double _lastSerializationStartTime;

	private FixedList512Bytes<Entity> _whenSavedNotifyConnections;

	private ObjectLookupWriterCD _objectLookupWriter;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_783526210_0;

	private EntityQuery __query_783526210_1;

	private EntityQuery __query_783526210_2;

	private EntityQuery __query_783526210_3;

	private EntityQuery __query_783526210_4;

	private EntityQuery __query_783526210_5;

	private EntityQuery __query_783526210_6;

	private EntityQuery __query_783526210_7;

	private EntityQuery __query_783526210_8;

	private EntityQuery __query_783526210_9;

	private EntityQuery __query_783526210_10;

	private EntityQuery __query_783526210_11;

	private EntityQuery __query_783526210_12;

	private EntityQuery __query_783526210_13;

	private EntityQuery __query_783526210_14;

	private EntityQuery __query_783526210_15;

	private EntityQuery __query_783526210_16;

	public int SerializedDataBufferSize
	{
		get
		{
			if (!serializedDataBuffer.IsCreated)
			{
				return 0;
			}
			return serializedDataBuffer.Length;
		}
	}

	[Preserve]
	protected override void OnCreate()
	{
		RequireForUpdate<PugDatabase.DatabaseBankCD>();
		RequireForUpdate(GetEntityQuery(ComponentType.ReadWrite<SerializeWorldDataCD>()));
		RequireForUpdate<ObjectLookupWriterCD>();
		SerializeWorldDataCD componentData = new SerializeWorldDataCD
		{
			serializedEntities = new NativeList<Entity>(1048576, Allocator.Persistent),
			freeRangeList = new NativeList<SerializeWorldDataCD.FreeEntityRange>(Allocator.Persistent),
			chunks = new NativeList<SerializedChunkData>(Allocator.Persistent),
			freeChunks = new NativeList<int>(Allocator.Persistent),
			entityManager = default(EntityManager)
		};
		componentData.serializedEntities.Add(default(Entity));
		base.EntityManager.CreateSingleton(componentData);
		ecbSystem = base.World.GetExistingSystemManaged<BeginSimulationEntityCommandBufferSystem>();
		triggerQ = GetEntityQuery(typeof(SerializeWorld));
		blockSaveQ = GetEntityQuery(typeof(BlockSaveCD));
		EntityQueryDesc entityQueryDesc = new EntityQueryDesc();
		entityQueryDesc.All = new ComponentType[3]
		{
			ComponentType.ChunkComponent<SerializedChunkData>(),
			ComponentType.ReadOnly<ObjectDataCD>(),
			ComponentType.ReadOnly<LocalTransform>()
		};
		entityQueryDesc.None = new ComponentType[1] { ComponentType.ReadOnly<DontSerializeCD>() };
		entityQueryDesc.Options = EntityQueryOptions.IncludeDisabledEntities;
		EntityQueryDesc entityQueryDesc2 = entityQueryDesc;
		_serializeObjectsQ = GetEntityQuery(entityQueryDesc2);
		entityQueryDesc = new EntityQueryDesc();
		entityQueryDesc.All = new ComponentType[3]
		{
			ComponentType.ChunkComponent<SerializedChunkData>(),
			ComponentType.ReadOnly<InventoryAuxDataCD>(),
			ComponentType.ReadOnly<InventoryAuxDataPrefabCD>()
		};
		entityQueryDesc.None = new ComponentType[1] { ComponentType.ReadOnly<DontSerializeCD>() };
		entityQueryDesc.Options = EntityQueryOptions.IncludeDisabledEntities;
		EntityQueryDesc entityQueryDesc3 = entityQueryDesc;
		_serializeInventoryAuxDataQ = GetEntityQuery(entityQueryDesc3);
		entityQueryDesc = new EntityQueryDesc();
		entityQueryDesc.All = new ComponentType[2]
		{
			ComponentType.ChunkComponent<SerializedChunkData>(),
			ComponentType.ReadOnly<SubMapCD>()
		};
		entityQueryDesc.Options = EntityQueryOptions.IncludeDisabledEntities;
		EntityQueryDesc entityQueryDesc4 = entityQueryDesc;
		_serializeSubMapQ = GetEntityQuery(entityQueryDesc4);
		entityQueryDesc = new EntityQueryDesc();
		entityQueryDesc.All = new ComponentType[2]
		{
			ComponentType.ChunkComponent<SerializedChunkData>(),
			ComponentType.ReadOnly<PheromoneCD>()
		};
		entityQueryDesc.Options = EntityQueryOptions.IncludeDisabledEntities;
		EntityQueryDesc entityQueryDesc5 = entityQueryDesc;
		_serializePheromoneQ = GetEntityQuery(entityQueryDesc5);
		activePlayerQ = GetEntityQuery(typeof(PlayerGhost));
		_noPendingSerialization = new ManualResetEvent(initialState: true);
		_serializeThread = new Thread(SerializeWorldHandler)
		{
			Priority = System.Threading.ThreadPriority.BelowNormal,
			Name = "SerializeWorldSystem"
		};
		_serializeThread.Start();
		base.OnCreate();
	}

	[Preserve]
	protected override void OnStartRunning()
	{
		base.OnStartRunning();
		_objectLookupWriter = __query_783526210_1.GetSingleton<ObjectLookupWriterCD>();
	}

	private void OnSaveFileCorrupt()
	{
		Manager.menu.PopAllMenus();
		Manager.music.FadeOutVolume(1.4f);
		Manager.menu.centerPopUpText.StartNewDisplaySequence("Error/SaveFileCorrupt", null, menuInputCooldown: true, 0f, 1.5f, useUnscaledTime: true, 0f, 1f, localize: true, TextManager.FontFace.boldMedium, delegate
		{
			UnityMainThreadDispatcher.Instance().Enqueue(Manager.load.ExitGame);
		}, new List<string> { "ok" }, 10f);
		base.World.QuitUpdate = true;
	}

	private bool FinalizeSerializeWorld()
	{
		base.World.EntityManager.DestroyEntity(GetEntityQuery(typeof(DeserializeWorldTriggerCD)));
		using EntityQuery entityQuery = outputWorld.EntityManager.CreateEntityQuery(typeof(DeserializeWorldTriggerCD));
		outputWorld.EntityManager.DestroyEntity(entityQuery);
		using EntityQuery entityQuery2 = outputWorld.EntityManager.CreateEntityQuery(typeof(DeserializationStateCD));
		outputWorld.EntityManager.DestroyEntity(entityQuery2);
		using EntityQuery entityQuery3 = outputWorld.EntityManager.CreateEntityQuery(typeof(WorldVersionSerializedCD));
		if (entityQuery3.IsEmpty)
		{
			return true;
		}
		int version = entityQuery3.GetSingleton<WorldVersionSerializedCD>().Version;
		if (version > 12)
		{
			UnityEngine.Debug.LogWarning($"Tried to load a world with serialized version {version}, but the current version is {12}. Try updating to the most recent game version.");
			Manager.menu.PopAllMenus();
			Manager.music.FadeOutVolume(1.4f);
			Manager.menu.centerPopUpText.StartNewDisplaySequence("Error/WorldVersionTooHigh", null, menuInputCooldown: true, 0f, 1.5f, useUnscaledTime: true, 0f, 1f, localize: true, TextManager.FontFace.boldMedium, delegate
			{
				UnityMainThreadDispatcher.Instance().Enqueue(Manager.load.ExitGame);
			}, new List<string> { "ok" }, 10f, 0f, 0, 25f);
			base.World.QuitUpdate = true;
			return false;
		}
		return true;
	}

	private bool CheckSaveState(DeserializationStateCD state)
	{
		switch (state.state)
		{
		case DeserializationStates.Invalid:
		case DeserializationStates.SaveFileCorrupt:
			OnSaveFileCorrupt();
			return true;
		case DeserializationStates.FileNotFound:
		case DeserializationStates.Finished:
			FinalizeSerializeWorld();
			return true;
		default:
			return false;
		}
	}

	private void InitializeSerializeWorld()
	{
		LastWorldWrite = DateTime.Now;
		outputWorld = new World("SerializeWorld", WorldFlags.Streaming);
		outputWorldRemoveAfterSerializeQ = outputWorld.EntityManager.CreateEntityQuery(typeof(RemoveAfterSerialize));
		SerializeWorldDataCD singleton = __query_783526210_2.GetSingleton<SerializeWorldDataCD>();
		NativeList<Entity> serializedEntities = singleton.serializedEntities;
		NativeList<SerializedChunkData> chunks = singleton.chunks;
		serializedDataBuffer = new NativeList<byte>(8388608, Allocator.Persistent);
		using NativeList<Entity> nativeList = new NativeList<Entity>(Allocator.Persistent);
		using NativeList<UnloadedChunkCD> nativeList2 = new NativeList<UnloadedChunkCD>(Allocator.Persistent);
		using NativeHashMap<ObjectDataCD, bool> nativeHashMap = new NativeHashMap<ObjectDataCD, bool>(1024, Allocator.Persistent);
		FilesystemManager.File file = __query_783526210_3.GetSingleton<DeserializeWorldTriggerCD>().file;
		if (file.FileID != FilesystemManager.FileID.None && file.Exists())
		{
			DeserializationStates deserializationStates;
			if (!file.Exists())
			{
				deserializationStates = DeserializationStates.FileNotFound;
			}
			else
			{
				byte[] fileData = Manager.filesystemManager.Read(file, raw: true);
				deserializationStates = new WorldDeserializer().DeserializeWorld(outputWorld, fileData);
			}
			switch (deserializationStates)
			{
			case DeserializationStates.Finished:
				if (!FinalizeSerializeWorld())
				{
					return;
				}
				UnityEngine.Debug.Log("Deserialize world finishied");
				break;
			case DeserializationStates.Patching:
			{
				UnityEngine.Debug.Log("start PatchWorldWithPatchApplicationSystem");
				PatchWorldWithPatchApplicationSystem patchingSystem = base.World.CreateSystemManaged<PatchWorldWithPatchApplicationSystem>();
				patchingSystem.DeserializeWorld = outputWorld;
				patchingSystem.State = DeserializationStates.Patching;
				if (!(Manager.filesystemManager.platformImpl is StandaloneFilesystem standaloneFilesystem))
				{
					throw new NotSupportedException("Can't find path to save file for patcher without StandaloneFilesystem");
				}
				patchingSystem.SaveFilePath = standaloneFilesystem.Rel2Abs(file.GetFilePath());
				try
				{
					while (patchingSystem.State == DeserializationStates.Patching)
					{
						patchingSystem.Update();
					}
					if (patchingSystem.State != DeserializationStates.Finished)
					{
						UnityEngine.Debug.Log($"patching failed with state {patchingSystem.State}");
						base.World.QuitUpdate = true;
						return;
					}
					if (!FinalizeSerializeWorld())
					{
						return;
					}
				}
				catch (Exception exception)
				{
					UnityEngine.Debug.LogException(exception);
					UnityEngine.Debug.LogError("patching failed with exception");
					base.World.QuitUpdate = true;
					return;
				}
				finally
				{
					UnityMainThreadDispatcher.Instance().Enqueue(delegate
					{
						base.World.DestroySystemManaged(patchingSystem);
					});
				}
				break;
			}
			case DeserializationStates.SaveFileCorrupt:
				OnSaveFileCorrupt();
				return;
			case DeserializationStates.FileNotFound:
				UnityEngine.Debug.LogError("got unexpected FileNotFound");
				base.World.QuitUpdate = true;
				return;
			default:
				UnityEngine.Debug.LogError($"unknown error {deserializationStates}");
				base.World.QuitUpdate = true;
				return;
			}
			UnityEngine.Debug.Log("successfully loaded world file into SerializeWorld");
			ConvertInSerializeWorldSystemGroup convertInSerializeWorldSystemGroup = outputWorld.CreateSystemManaged<ConvertInSerializeWorldSystemGroup>();
			convertInSerializeWorldSystemGroup.ServerWorld = base.World;
			convertInSerializeWorldSystemGroup.Update();
			using NativeArray<ArchetypeChunk> nativeArray = outputWorld.EntityManager.GetAllChunks(Allocator.Persistent);
			ComponentTypeHandle<Translation> componentTypeHandle = outputWorld.EntityManager.GetComponentTypeHandle<Translation>(isReadOnly: true);
			ComponentTypeHandle<ObjectDataSerializedCD> componentTypeHandle2 = outputWorld.EntityManager.GetComponentTypeHandle<ObjectDataSerializedCD>(isReadOnly: true);
			ComponentTypeHandle<RotationSerializedCD> componentTypeHandle3 = outputWorld.EntityManager.GetComponentTypeHandle<RotationSerializedCD>(isReadOnly: true);
			EntityTypeHandle entityTypeHandle = outputWorld.EntityManager.GetEntityTypeHandle();
			UnityEngine.Debug.Log($"found {nativeArray.Length} chunks in serialized world");
			Dictionary<ulong, List<ArchetypeChunk>> dictionary = new Dictionary<ulong, List<ArchetypeChunk>>();
			foreach (ArchetypeChunk item2 in nativeArray)
			{
				if (!dictionary.TryGetValue(item2.Archetype.StableHash, out var value))
				{
					value = new List<ArchetypeChunk>();
					dictionary.Add(item2.Archetype.StableHash, value);
				}
				value.Add(item2);
			}
			EntityCommandBuffer ecb = ecbSystem.CreateCommandBuffer();
			Dictionary<int2, NativeList<Entity>> dictionary2 = new Dictionary<int2, NativeList<Entity>>();
			foreach (List<ArchetypeChunk> value5 in dictionary.Values)
			{
				foreach (NativeList<Entity> value6 in dictionary2.Values)
				{
					value6.Clear();
				}
				foreach (ArchetypeChunk item3 in value5)
				{
					NativeArray<Entity> nativeArray2 = item3.GetNativeArray(entityTypeHandle);
					if (item3.Has<ServerGuidCD>() || item3.Has<ServerSeedCD>() || item3.Has<KilledEnemiesSerializedBuffer>() || item3.Has<WorldVersionSerializedCD>() || item3.Has<WorldGenerationTypeCD>() || item3.Has<WorldGenerationParametersSerializedCD>() || item3.Has<ObjectPropertiesSerializedCD>() || item3.Has<RemovedObjectPropertiesSerializedCD>() || item3.Has<TheGreatWallStatusSerializedCD>() || item3.Has<ActivatedContentBundlesSerializedBuffer>() || item3.Has<WorldCreationVersionSerializedCD>())
					{
						nativeList.Add(nativeArray2[0]);
						continue;
					}
					if (item3.Has<SubMapSerializedCD>() || item3.Has<PheromoneSerializedCD>() || item3.Has<RemoveAfterSerialize>() || item3.Has<PlayerSerializedCD>())
					{
						nativeList.AddRange(nativeArray2);
						continue;
					}
					if (!item3.Has<ObjectDataSerializedCD>() || !item3.Has<Translation>())
					{
						nativeList.AddRange(nativeArray2);
						continue;
					}
					NativeArray<bool> nativeArray3 = new NativeArray<bool>(item3.Count, Allocator.Temp);
					NativeArray<ObjectDataSerializedCD> nativeArray4 = item3.GetNativeArray(componentTypeHandle2);
					for (int num = 0; num < item3.Count; num++)
					{
						ObjectDataSerializedCD objectDataSerializedCD = nativeArray4[num];
						if (!nativeHashMap.TryGetValue(objectDataSerializedCD, out var item))
						{
							item = PugDatabase.TryGetComponent<ObjectPropertiesCD>(objectDataSerializedCD, out var component) && component.Has(454668241);
							nativeHashMap.Add(objectDataSerializedCD, item);
						}
						nativeArray3[num] = !item;
					}
					NativeArray<Translation> nativeArray5 = item3.GetNativeArray(componentTypeHandle);
					for (int num2 = 0; num2 < nativeArray2.Length; num2++)
					{
						if (!nativeArray3[num2])
						{
							nativeList.Add(nativeArray2[num2]);
							continue;
						}
						int2 key = nativeArray5[num2].Value.RoundToInt2() >> 7;
						if (!dictionary2.TryGetValue(key, out var value2))
						{
							value2 = new NativeList<Entity>(1024, Allocator.Temp);
							dictionary2.Add(key, value2);
						}
						value2.Add(nativeArray2[num2]);
					}
					NativeArray<RotationSerializedCD> nativeArray6 = item3.GetNativeArray(componentTypeHandle3);
					if (nativeArray6.IsCreated)
					{
						for (int num3 = 0; num3 < item3.Count; num3++)
						{
							DirectionCD directionCD = new DirectionCD
							{
								direction = nativeArray6[num3].Value
							};
							_objectLookupWriter.Add(ecb, nativeArray4[num3].ObjectID, nativeArray4[num3].Variation, nativeArray5[num3].Value, hasDirection: true, directionCD);
						}
					}
					else
					{
						for (int num4 = 0; num4 < item3.Count; num4++)
						{
							_objectLookupWriter.Add(ecb, nativeArray4[num4].ObjectID, nativeArray4[num4].Variation, nativeArray5[num4].Value, hasDirection: false, default(DirectionCD));
						}
					}
				}
				foreach (var (int6, nativeList4) in dictionary2)
				{
					if (nativeList4.Length != 0)
					{
						int length = serializedEntities.Length;
						serializedEntities.AddRange(nativeList4);
						SerializedChunkData value3 = new SerializedChunkData
						{
							StartIndex = length,
							Count = nativeList4.Length,
							Capacity = nativeList4.Length,
							ChunkListIndex = -2
						};
						UnloadedChunkCD value4 = new UnloadedChunkCD
						{
							MinPosition = int6 << 7,
							MaxPosition = int6 + 1 << 7,
							ChunkListIndex = chunks.Length
						};
						chunks.Add(in value3);
						nativeList2.Add(in value4);
					}
				}
			}
		}
		else
		{
			UnityEngine.Debug.Log("no existing save file, starting with empty world");
			base.World.EntityManager.DestroyEntity(GetEntityQuery(typeof(DeserializeWorldTriggerCD)));
			base.EntityManager.CreateEntity(typeof(WorldHasBeenDeserializedCD));
		}
		if (nativeList.Length > 0)
		{
			base.EntityManager.CopyEntitiesFrom(outputWorld.EntityManager, nativeList);
			outputWorld.EntityManager.DestroyEntity(nativeList);
		}
		if (nativeList2.Length > 0)
		{
			EntityArchetype archetype = base.EntityManager.CreateArchetype(typeof(UnloadedChunkCD));
			using NativeArray<Entity> entities = new NativeArray<Entity>(nativeList2.Length, Allocator.Persistent);
			base.EntityManager.CreateEntity(archetype, entities);
			for (int num5 = 0; num5 < entities.Length; num5++)
			{
				base.EntityManager.SetComponentData(entities[num5], nativeList2[num5]);
			}
		}
		using (EntityQuery entityQuery = outputWorld.EntityManager.CreateEntityQuery(typeof(SerializedEntityPendingLoadCD)))
		{
			outputWorld.EntityManager.RemoveComponent<SerializedEntityPendingLoadCD>(entityQuery);
		}
		using EntityQuery entityQuery2 = outputWorld.EntityManager.CreateEntityQuery(ComponentType.ReadOnly<BlobAssetOwner>());
		outputWorld.EntityManager.RemoveComponent<BlobAssetOwner>(entityQuery2);
		_submapSerializedArchetype = outputWorld.EntityManager.CreateArchetype(typeof(Translation), typeof(SubMapSerializedCD), typeof(SubMapLayerSerializedBuffer));
		_pheromoneSerializedArchetype = outputWorld.EntityManager.CreateArchetype(typeof(PheromoneSerializedCD));
		_customSceneWithoutPositionSerializedArchetype = outputWorld.EntityManager.CreateArchetype(typeof(CustomSceneSerializedCD), typeof(RemoveAfterSerialize));
		_customSceneWithPositionSerializedArchetype = outputWorld.EntityManager.CreateArchetype(typeof(CustomSceneSerializedCD), typeof(Translation), typeof(RemoveAfterSerialize));
		_dungeonNameSerializedArchetype = outputWorld.EntityManager.CreateArchetype(typeof(DungeonNameSerializedCD), typeof(Translation), typeof(RemoveAfterSerialize));
		_scannedSerializedArchetype = outputWorld.EntityManager.CreateArchetype(typeof(ObjectDataSerializedCD), typeof(ScannedObjectSerializedCD), typeof(RemoveAfterSerialize));
		_serverGuidSerializedArchetype = outputWorld.EntityManager.CreateArchetype(typeof(ServerGuidCD), typeof(RemoveAfterSerialize));
		_serverSeedSerializedArchetype = outputWorld.EntityManager.CreateArchetype(typeof(ServerSeedCD), typeof(RemoveAfterSerialize));
		_worldVersionSerializedArchetype = outputWorld.EntityManager.CreateArchetype(typeof(WorldVersionSerializedCD), typeof(RemoveAfterSerialize));
		_killedEnemiesBufferSerializedArchetype = outputWorld.EntityManager.CreateArchetype(typeof(KilledEnemiesSerializedBuffer), typeof(RemoveAfterSerialize));
		_worldGenerationSerializedArchetype = outputWorld.EntityManager.CreateArchetype(typeof(WorldGenerationTypeCD), typeof(RemoveAfterSerialize));
		_worldGenerationParametersSerializedArchetype = outputWorld.EntityManager.CreateArchetype(typeof(WorldGenerationParametersSerializedCD), typeof(RemoveAfterSerialize));
		_objectPropertiesSerializedArchetype = outputWorld.EntityManager.CreateArchetype(typeof(ObjectPropertiesSerializedCD), typeof(RemoveAfterSerialize));
		_removedObjectPropertiesSerializedArchetype = outputWorld.EntityManager.CreateArchetype(typeof(RemovedObjectPropertiesSerializedCD), typeof(RemoveAfterSerialize));
		_theGreatWallStatusSerializedArchetype = outputWorld.EntityManager.CreateArchetype(typeof(TheGreatWallStatusSerializedCD), typeof(RemoveAfterSerialize));
		_activatedContentBundlesSerializedArchetype = outputWorld.EntityManager.CreateArchetype(typeof(ActivatedContentBundlesSerializedBuffer), typeof(RemoveAfterSerialize));
		_worldCreationVersionSerializedArchetype = outputWorld.EntityManager.CreateArchetype(typeof(WorldCreationVersionSerializedCD), typeof(RemoveAfterSerialize));
	}

	[Preserve]
	protected override void OnDestroy()
	{
		FinishPendingSerializationImmediately();
		_serializeQueue.CompleteAdding();
		_serializeThread.Join();
		_noPendingSerialization.Dispose();
		outputWorld?.Dispose();
		serializedDataBuffer.Dispose();
		SerializeWorldDataCD singleton = __query_783526210_2.GetSingleton<SerializeWorldDataCD>();
		singleton.serializedEntities.Dispose();
		singleton.freeRangeList.Dispose();
		singleton.chunks.Dispose();
		singleton.freeChunks.Dispose();
		base.EntityManager.DestroyEntity(__query_783526210_2.GetSingletonEntity());
		base.OnDestroy();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		SerializeWorldDataCD serializeWorldData = __query_783526210_2.GetSingleton<SerializeWorldDataCD>();
		if (serializeWorldData.entityManager == default(EntityManager))
		{
			if (!__query_783526210_3.HasSingleton<DeserializeWorldTriggerCD>())
			{
				return;
			}
			try
			{
				InitializeSerializeWorld();
			}
			catch (Exception exception)
			{
				UnityEngine.Debug.LogException(exception);
				UnityEngine.Debug.LogError("initialize SerializeWorld failed with exception");
				base.World.QuitUpdate = true;
				return;
			}
			serializeWorldData.entityManager = outputWorld.EntityManager;
		}
		switch (serializeWorldData.State)
		{
		case SerializeWorldState.Idle:
		{
			EntityCommandBuffer ecb2 = ecbSystem.CreateCommandBuffer();
			UpdateIdleState(ecb2, ref serializeWorldData);
			break;
		}
		case SerializeWorldState.UpdatingOutputWorld:
			UpdateUpdatingOutputWorldState(ref serializeWorldData);
			break;
		case SerializeWorldState.WaitForSerializeJob:
		{
			EntityCommandBuffer ecb = ecbSystem.CreateCommandBuffer();
			UpdateWaitForSerializeJobState(ecb, ref serializeWorldData);
			break;
		}
		}
		__query_783526210_4.SetSingleton(serializeWorldData);
	}

	private void UpdateIdleState(EntityCommandBuffer ecb, ref SerializeWorldDataCD serializeWorldData)
	{
		if (!triggerQ.IsEmpty && blockSaveQ.IsEmpty)
		{
			ScheduleOutputWorldUpdateJobs(in serializeWorldData);
			serializeWorldData.State = SerializeWorldState.UpdatingOutputWorld;
			_whenSavedNotifyConnections.Clear();
			NativeArray<PlayerGhost> nativeArray = activePlayerQ.ToComponentDataArray<PlayerGhost>(Allocator.Temp);
			for (int i = 0; i < nativeArray.Length; i++)
			{
				ref FixedList512Bytes<Entity> whenSavedNotifyConnections = ref _whenSavedNotifyConnections;
				PlayerGhost playerGhost = nativeArray[i];
				whenSavedNotifyConnections.Add(in playerGhost.connection);
			}
			ecb.DestroyEntity(triggerQ);
		}
	}

	private void UpdateUpdatingOutputWorldState(ref SerializeWorldDataCD serializeWorldData)
	{
		SubmitWorldSerializationJob();
		serializeWorldData.State = SerializeWorldState.WaitForSerializeJob;
	}

	private void UpdateWaitForSerializeJobState(EntityCommandBuffer ecb, ref SerializeWorldDataCD serializeWorldData)
	{
		if (HasPendingSerializationJob())
		{
			CheckSerializationThreadStarvation();
		}
		else if (Interlocked.Exchange(ref _serializationFailed, 0) != 0)
		{
			UnityEngine.Debug.LogError($"Skipping world save due to serialization failure. Compressed data size: {serializedDataBuffer.Length}");
			serializeWorldData.State = SerializeWorldState.Idle;
		}
		else if (serializedDataBuffer.Length <= 1024)
		{
			UnityEngine.Debug.LogError($"Skipping world save due to suspiciously small compressed data size: {serializedDataBuffer.Length} bytes. ");
			serializeWorldData.State = SerializeWorldState.Idle;
		}
		else
		{
			WriteSerializedDataToFile();
			serializeWorldData.State = SerializeWorldState.Idle;
			NotifyConnectionsOnSaveCompleted(ecb);
		}
	}

	private void ScheduleOutputWorldUpdateJobs(in SerializeWorldDataCD serializeWorldData)
	{
		base.Dependency.Complete();
		if (!outputWorld.EntityManager.CanBeginExclusiveEntityTransaction())
		{
			outputWorld.EntityManager.EndExclusiveEntityTransaction();
		}
		outputWorld.EntityManager.DestroyEntity(outputWorldRemoveAfterSerializeQ);
		ExclusiveEntityTransaction exclusiveEntityTransaction = outputWorld.EntityManager.BeginExclusiveEntityTransaction();
		NativeList<Entity> serializedEntities = serializeWorldData.serializedEntities;
		NativeList<SerializeWorldDataCD.FreeEntityRange> freeRangeList = serializeWorldData.freeRangeList;
		NativeList<SerializedChunkData> chunks = serializeWorldData.chunks;
		NativeList<int> freeChunks = serializeWorldData.freeChunks;
		SaveSingleton<ServerGuidCD>(_serverGuidSerializedArchetype, exclusiveEntityTransaction);
		SaveSingleton<ServerSeedCD>(_serverSeedSerializedArchetype, exclusiveEntityTransaction);
		SaveSingleton<WorldGenerationTypeCD>(_worldGenerationSerializedArchetype, exclusiveEntityTransaction);
		SaveSingleton<WorldGenerationParametersSerializedCD>(_worldGenerationParametersSerializedArchetype, exclusiveEntityTransaction);
		SaveSingleton<WorldCreationVersionSerializedCD>(_worldCreationVersionSerializedArchetype, exclusiveEntityTransaction);
		Entity entity = exclusiveEntityTransaction.CreateEntity(_worldVersionSerializedArchetype);
		exclusiveEntityTransaction.SetComponentData(entity, new WorldVersionSerializedCD
		{
			Version = 12
		});
		Entity entity2 = exclusiveEntityTransaction.CreateEntity(_theGreatWallStatusSerializedArchetype);
		exclusiveEntityTransaction.SetComponentData(entity2, new TheGreatWallStatusSerializedCD
		{
			HasBeenLowered = __query_783526210_5.HasSingleton<TheGreatWallHasBeenLoweredCD>()
		});
		if (__query_783526210_6.TryGetSingletonEntity<KilledEnemiesBuffer>(out var value))
		{
			Entity entity3 = exclusiveEntityTransaction.CreateEntity(_killedEnemiesBufferSerializedArchetype);
			DynamicBuffer<KilledEnemiesBuffer> bufferAfterCompletingDependency = InternalCompilerInterface.GetBufferAfterCompletingDependency(ref __TypeHandle.__KilledEnemiesBuffer_RW_BufferLookup, ref base.CheckedStateRef, value);
			DynamicBuffer<KilledEnemiesSerializedBuffer> buffer = exclusiveEntityTransaction.GetBuffer<KilledEnemiesSerializedBuffer>(entity3);
			buffer.Clear();
			for (int i = 0; i < bufferAfterCompletingDependency.Length; i++)
			{
				buffer.Add(new KilledEnemiesSerializedBuffer
				{
					ObjectData = bufferAfterCompletingDependency[i].objectData
				});
			}
		}
		if (__query_783526210_7.TryGetSingletonEntity<ActivatedContentBundlesBuffer>(out var value2))
		{
			Entity entity4 = exclusiveEntityTransaction.CreateEntity(_activatedContentBundlesSerializedArchetype);
			DynamicBuffer<ActivatedContentBundlesBuffer> bufferAfterCompletingDependency2 = InternalCompilerInterface.GetBufferAfterCompletingDependency(ref __TypeHandle.__ActivatedContentBundlesBuffer_RW_BufferLookup, ref base.CheckedStateRef, value2);
			DynamicBuffer<ActivatedContentBundlesSerializedBuffer> buffer2 = exclusiveEntityTransaction.GetBuffer<ActivatedContentBundlesSerializedBuffer>(entity4);
			buffer2.Clear();
			for (int j = 0; j < bufferAfterCompletingDependency2.Length; j++)
			{
				buffer2.Add(new ActivatedContentBundlesSerializedBuffer
				{
					ContentBundle = bufferAfterCompletingDependency2[j].ContentBundle
				});
			}
		}
		Entity entity5 = exclusiveEntityTransaction.CreateEntity(_objectPropertiesSerializedArchetype);
		exclusiveEntityTransaction.SetComponentData(entity5, new ObjectPropertiesSerializedCD
		{
			ObjectPropertyLookup = __query_783526210_8.GetSingleton<DatabaseCD>().ObjectPropertyLookup
		});
		SaveSingleton<RemovedObjectPropertiesSerializedCD>(_removedObjectPropertiesSerializedArchetype, exclusiveEntityTransaction);
		ComponentTypeHandle<SerializedChunkData> componentTypeHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__SerializedChunkData_RW_ComponentTypeHandle, ref base.CheckedStateRef);
		MarkChunksDirtyJob jobData = new MarkChunksDirtyJob
		{
			Chunks = chunks
		};
		base.Dependency = IJobExtensions.Schedule(jobData, base.Dependency);
		if (!__query_783526210_9.TryGetSingleton<ClientServerTickRate>(out var value3))
		{
			value3.ResolveDefaults();
		}
		__query_783526210_10.TryGetSingleton<NetworkTime>(out var value4);
		SerializeObjectJob jobData2 = new SerializeObjectJob
		{
			EntityTransaction = exclusiveEntityTransaction,
			SerializedEntities = serializedEntities,
			FreeSerializedEntities = freeRangeList,
			Chunks = chunks,
			FreeChunks = freeChunks,
			SerializedChunk = componentTypeHandle,
			GlobalSystemVersion = base.GlobalSystemVersion,
			Transform = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle, ref base.CheckedStateRef),
			ObjectData = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__ObjectDataCD_RO_ComponentTypeHandle, ref base.CheckedStateRef),
			CharacterGuid = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__CharacterGuidCD_RO_ComponentTypeHandle, ref base.CheckedStateRef),
			ClaimedByCharacterGuid = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__ClaimedByCharacterGuidCD_RO_ComponentTypeHandle, ref base.CheckedStateRef),
			PlayerGuid = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__PlayerGuidCD_RO_ComponentTypeHandle, ref base.CheckedStateRef),
			ClaimedByPlayerGuid = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__ClaimedByPlayerGuidCD_RO_ComponentTypeHandle, ref base.CheckedStateRef),
			Health = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__HealthCD_RO_ComponentTypeHandle, ref base.CheckedStateRef),
			Growing = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__GrowingCD_RO_ComponentTypeHandle, ref base.CheckedStateRef),
			GrowTimer = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__GrowTimerRefCD_RO_ComponentTypeHandle, ref base.CheckedStateRef),
			Hunger = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__HungerCD_RO_ComponentTypeHandle, ref base.CheckedStateRef),
			DropsLootFromLootTable = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__DropsLootFromLootTableCD_RO_ComponentTypeHandle, ref base.CheckedStateRef),
			PaintableObject = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__PaintableObjectCD_RO_ComponentTypeHandle, ref base.CheckedStateRef),
			Direction = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__DirectionCD_RO_ComponentTypeHandle, ref base.CheckedStateRef),
			HasBeenDiscovered = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__HasBeenDiscoveredCD_RO_ComponentTypeHandle, ref base.CheckedStateRef),
			CustomSceneObject = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__CustomSceneObjectCD_RO_ComponentTypeHandle, ref base.CheckedStateRef),
			ActiveEquipmentPreset = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__ActiveEquipmentPresetCD_RO_ComponentTypeHandle, ref base.CheckedStateRef),
			PlayerGhost = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__PlayerGhost_RO_ComponentTypeHandle, ref base.CheckedStateRef),
			PlayerLastSession = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__PlayerLastSessionCD_RO_ComponentTypeHandle, ref base.CheckedStateRef),
			SpawnPoint = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__SpawnPointCD_RO_ComponentTypeHandle, ref base.CheckedStateRef),
			Name = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__NameCD_RO_ComponentTypeHandle, ref base.CheckedStateRef),
			Author = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__AuthorCD_RO_ComponentTypeHandle, ref base.CheckedStateRef),
			Crafting = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__CraftingCD_RO_ComponentTypeHandle, ref base.CheckedStateRef),
			SnakeBossSegment = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__SnakeSegmentCD_RO_ComponentTypeHandle, ref base.CheckedStateRef),
			MealsEaten = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__MealsEatenCD_RO_ComponentTypeHandle, ref base.CheckedStateRef),
			BreedToggle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__BreedToggleCD_RO_ComponentTypeHandle, ref base.CheckedStateRef),
			ObjectFilter = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__ObjectFilteringCD_RO_ComponentTypeHandle, ref base.CheckedStateRef),
			PugAutomationMoverOrchestratorSynced = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__Pug_Automation_PugAutomationEnabledMoverSyncedCD_RO_ComponentTypeHandle, ref base.CheckedStateRef),
			MoveeBigEntity = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__Pug_Automation_MoveeBigEntityCD_RO_ComponentTypeHandle, ref base.CheckedStateRef),
			ImmunityZone = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__ImmunityZoneCD_RO_ComponentTypeHandle, ref base.CheckedStateRef),
			ContainedObjects = InternalCompilerInterface.GetBufferTypeHandle(ref __TypeHandle.__ContainedObjectsBuffer_RO_BufferTypeHandle, ref base.CheckedStateRef),
			Conditions = InternalCompilerInterface.GetBufferTypeHandle(ref __TypeHandle.__ConditionsBuffer_RO_BufferTypeHandle, ref base.CheckedStateRef),
			ActiveAffixState = InternalCompilerInterface.GetBufferTypeHandle(ref __TypeHandle.__Affixes_Components_ActiveAffixStateBuffer_RO_BufferTypeHandle, ref base.CheckedStateRef),
			ActiveAffixCondition = InternalCompilerInterface.GetBufferTypeHandle(ref __TypeHandle.__ActiveAffixConditionsBuffer_RO_BufferTypeHandle, ref base.CheckedStateRef),
			DropsLoot = InternalCompilerInterface.GetBufferTypeHandle(ref __TypeHandle.__DropsLootBuffer_RO_BufferTypeHandle, ref base.CheckedStateRef),
			SummarizedConditions = InternalCompilerInterface.GetBufferTypeHandle(ref __TypeHandle.__SummarizedConditionEffectsBuffer_RO_BufferTypeHandle, ref base.CheckedStateRef),
			Description = InternalCompilerInterface.GetBufferTypeHandle(ref __TypeHandle.__DescriptionBuffer_RO_BufferTypeHandle, ref base.CheckedStateRef),
			CraftingTimerSlotCrafter = InternalCompilerInterface.GetBufferTypeHandle(ref __TypeHandle.__CraftingTimerSlotBuffer_RO_BufferTypeHandle, ref base.CheckedStateRef),
			RecipeCrafter = InternalCompilerInterface.GetBufferTypeHandle(ref __TypeHandle.__CraftingByRecipeSlotBuffer_RO_BufferTypeHandle, ref base.CheckedStateRef),
			ConsumedObjectCrafter = InternalCompilerInterface.GetBufferTypeHandle(ref __TypeHandle.__CraftingByConsumedObjectSlotBuffer_RO_BufferTypeHandle, ref base.CheckedStateRef),
			GrowTimerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__GrowTimerCD_RO_ComponentLookup, ref base.CheckedStateRef),
			CurrentTick = value4.ServerTick,
			TickRate = (uint)value3.SimulationTickRate
		};
		base.Dependency = JobChunkExtensions.Schedule(jobData2, _serializeObjectsQ, base.Dependency);
		SerializeInventoryAuxDataJob jobData3 = new SerializeInventoryAuxDataJob
		{
			EntityTransaction = exclusiveEntityTransaction,
			SerializedEntities = serializedEntities,
			FreeSerializedEntities = freeRangeList,
			Chunks = chunks,
			FreeChunks = freeChunks,
			SerializedChunk = componentTypeHandle,
			GlobalSystemVersion = base.GlobalSystemVersion,
			InventoryAuxData = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__InventoryAuxDataCD_RO_ComponentTypeHandle, ref base.CheckedStateRef),
			InventoryAuxDataPrefab = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__InventoryAuxDataPrefabCD_RO_ComponentTypeHandle, ref base.CheckedStateRef),
			Name = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__NameCD_RO_ComponentTypeHandle, ref base.CheckedStateRef),
			PetTalents = InternalCompilerInterface.GetBufferTypeHandle(ref __TypeHandle.__PetTalentBuffer_RO_BufferTypeHandle, ref base.CheckedStateRef),
			PetSkin = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__PetSkinCD_RO_ComponentTypeHandle, ref base.CheckedStateRef),
			MealsEaten = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__MealsEatenCD_RO_ComponentTypeHandle, ref base.CheckedStateRef),
			BreedToggle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__BreedToggleCD_RO_ComponentTypeHandle, ref base.CheckedStateRef)
		};
		base.Dependency = JobChunkExtensions.Schedule(jobData3, _serializeInventoryAuxDataQ, base.Dependency);
		SerializeSubMapJob jobData4 = new SerializeSubMapJob
		{
			EntityTransaction = exclusiveEntityTransaction,
			GlobalSystemVersion = base.GlobalSystemVersion,
			SerializedEntities = serializedEntities,
			FreeSerializedEntities = freeRangeList,
			Chunks = chunks,
			FreeChunks = freeChunks,
			SerializeChunk = componentTypeHandle,
			SerializedArchetype = _submapSerializedArchetype,
			Transform = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle, ref base.CheckedStateRef),
			SubMap = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__SubMapCD_RO_ComponentTypeHandle, ref base.CheckedStateRef),
			SubMapLayerBuffer = InternalCompilerInterface.GetBufferTypeHandle(ref __TypeHandle.__SubMapLayerBuffer_RO_BufferTypeHandle, ref base.CheckedStateRef)
		};
		base.Dependency = JobChunkExtensions.Schedule(jobData4, _serializeSubMapQ, base.Dependency);
		SerializePheromoneJob jobData5 = new SerializePheromoneJob
		{
			EntityTransaction = exclusiveEntityTransaction,
			GlobalSystemVersion = base.GlobalSystemVersion,
			SerializedEntities = serializedEntities,
			FreeSerializedEntities = freeRangeList,
			Chunks = chunks,
			FreeChunks = freeChunks,
			SerializeChunk = componentTypeHandle,
			SerializedArchetype = _pheromoneSerializedArchetype,
			Pheromone = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__PheromoneCD_RO_ComponentTypeHandle, ref base.CheckedStateRef)
		};
		base.Dependency = JobChunkExtensions.Schedule(jobData5, _serializePheromoneQ, base.Dependency);
		CleanupRemovedChunksJob jobData6 = new CleanupRemovedChunksJob
		{
			EntityTransaction = exclusiveEntityTransaction,
			SerializedEntities = serializedEntities,
			FreeSerializedEntities = serializeWorldData.freeRangeList,
			Chunks = chunks,
			FreeChunks = serializeWorldData.freeChunks
		};
		base.Dependency = IJobExtensions.Schedule(jobData6, base.Dependency);
		EntityQuery _query_783526210_ = __query_783526210_0;
		SerializeSpawnedCustomSceneJob jobData7 = new SerializeSpawnedCustomSceneJob
		{
			EntityTransaction = exclusiveEntityTransaction,
			CustomSceneSerializedArchetypeWithPosition = _customSceneWithPositionSerializedArchetype,
			CustomSceneSerializedArchetypeWithoutPosition = _customSceneWithoutPositionSerializedArchetype,
			TranslationHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__Unity_Transforms_Translation_RO_ComponentTypeHandle, ref base.CheckedStateRef),
			CustomSceneHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__CustomSceneCD_RO_ComponentTypeHandle, ref base.CheckedStateRef)
		};
		base.Dependency = JobChunkExtensions.Schedule(jobData7, _query_783526210_, base.Dependency);
		SerializeSpawnedDungeonJob job = new SerializeSpawnedDungeonJob
		{
			EntityTransaction = exclusiveEntityTransaction,
			DungeonNameSerializedArchetype = _dungeonNameSerializedArchetype
		};
		base.Dependency = __ScheduleViaJobChunkExtension_0(job, __TypeHandle.__SerializeWorldSystem_SerializeSpawnedDungeonJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, base.Dependency, ref base.CheckedStateRef, hasUserDefinedQuery: false);
		SerializeScannedJob job2 = new SerializeScannedJob
		{
			EntityTransaction = exclusiveEntityTransaction,
			ScannedSerializedArchetype = _scannedSerializedArchetype
		};
		base.Dependency = __ScheduleViaJobChunkExtension_1(job2, __TypeHandle.__SerializeWorldSystem_SerializeScannedJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, base.Dependency, ref base.CheckedStateRef, hasUserDefinedQuery: false);
		SerializePendingScanJob job3 = new SerializePendingScanJob
		{
			EntityTransaction = exclusiveEntityTransaction,
			ScannedSerializedArchetype = _scannedSerializedArchetype
		};
		base.Dependency = __ScheduleViaJobChunkExtension_2(job3, __TypeHandle.__SerializeWorldSystem_SerializePendingScanJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, base.Dependency, ref base.CheckedStateRef, hasUserDefinedQuery: false);
	}

	private void SubmitWorldSerializationJob()
	{
		Interlocked.Exchange(ref _serializationFailed, 0);
		SerializeJob item = new SerializeJob
		{
			entityManager = outputWorld.EntityManager,
			compressedData = serializedDataBuffer
		};
		_noPendingSerialization.Reset();
		_serializeQueue.Add(item);
		_serializeThread.Priority = System.Threading.ThreadPriority.BelowNormal;
		_lastSerializationStartTime = base.CheckedStateRef.WorldUnmanaged.Time.ElapsedTime;
	}

	private unsafe void WriteSerializedDataToFile()
	{
		try
		{
			byte[] fileWriteBuffer = Manager.filesystemManager.GetFileWriteBuffer(FilesystemManager.FileID.WorldSave, serializedDataBuffer.Length);
			fixed (byte* destination = fileWriteBuffer)
			{
				UnsafeUtility.MemCpy(destination, serializedDataBuffer.GetUnsafePtr(), serializedDataBuffer.Length);
			}
			Manager.saves.WriteCompressedWorldData(fileWriteBuffer, serializedDataBuffer.Length);
			LastWorldWrite = DateTime.Now;
			WorldInfoCD singleton = __query_783526210_11.GetSingleton<WorldInfoCD>();
			WorldGenerationTypeCD singleton2 = __query_783526210_12.GetSingleton<WorldGenerationTypeCD>();
			Manager.saves.UpdateWorldInfo(__query_783526210_13.GetSingleton<ServerGuidCD>(), __query_783526210_14.GetSingleton<ServerSeedCD>(), singleton, singleton2, __query_783526210_15.GetSingletonBuffer<ActivatedContentBundlesBuffer>());
			Manager.saves.WriteWorldInfo();
			Manager.saves.WriteCharacter();
			if (singleton2.Value == WorldGenerationType.FullRelease)
			{
				Manager.saves.UpdateWorldGenerationParameters(__query_783526210_16.GetSingleton<WorldGenerationParametersSerializedCD>());
				Manager.saves.WriteWorldGenerationParameters();
			}
		}
		catch (Exception exception)
		{
			UnityEngine.Debug.LogException(exception);
		}
	}

	private void NotifyConnectionsOnSaveCompleted(EntityCommandBuffer ecb)
	{
		if (_whenSavedNotifyConnections.Length == 0 || !ecb.IsCreated)
		{
			_whenSavedNotifyConnections.Clear();
			return;
		}
		for (int i = 0; i < _whenSavedNotifyConnections.Length; i++)
		{
			if (base.EntityManager.HasComponent<NetworkId>(_whenSavedNotifyConnections[i]))
			{
				Entity e = ecb.CreateEntity();
				ecb.AddComponent(e, new SendRpcCommandRequest
				{
					TargetConnection = _whenSavedNotifyConnections[i]
				});
				ecb.AddComponent(e, new Rpc
				{
					command = Command.ServerSavedNotification
				});
			}
		}
		_whenSavedNotifyConnections.Clear();
	}

	private void SerializeWorldHandler()
	{
		while (!_serializeQueue.IsCompleted)
		{
			SerializeJob jobData;
			try
			{
				jobData = _serializeQueue.Take();
			}
			catch (InvalidOperationException)
			{
				break;
			}
			try
			{
				using (RunWorldSerializationThreadMarker.Auto())
				{
					IJobExtensions.RunByRef(ref jobData);
				}
			}
			catch (Exception exception)
			{
				UnityEngine.Debug.LogException(exception);
				Interlocked.Exchange(ref _serializationFailed, 1);
			}
			finally
			{
				_noPendingSerialization.Set();
			}
		}
	}

	private void SaveSingleton<TSingletonComponent>(EntityArchetype serializedArchetype, ExclusiveEntityTransaction transaction) where TSingletonComponent : unmanaged, IComponentData
	{
		if (InternalCompilerInterface.OnlyAllowedInSourceGeneratedCodeGetSingleQuery<TSingletonComponent>(this).TryGetSingleton<TSingletonComponent>(out var value))
		{
			Entity entity = transaction.CreateEntity(serializedArchetype);
			transaction.SetComponentData(entity, value);
		}
	}

	private void FinishPendingSerializationImmediately()
	{
		SerializeWorldDataCD serializeWorldData = __query_783526210_2.GetSingleton<SerializeWorldDataCD>();
		if (serializeWorldData.State == SerializeWorldState.UpdatingOutputWorld)
		{
			base.Dependency.Complete();
			UpdateUpdatingOutputWorldState(ref serializeWorldData);
		}
		if (serializeWorldData.State == SerializeWorldState.WaitForSerializeJob)
		{
			WaitForSerializationJobToComplete();
			UpdateWaitForSerializeJobState(default(EntityCommandBuffer), ref serializeWorldData);
		}
		__query_783526210_4.SetSingleton(serializeWorldData);
	}

	private bool HasPendingSerializationJob()
	{
		return !_noPendingSerialization.WaitOne(0);
	}

	private void CheckSerializationThreadStarvation()
	{
		double num = base.CheckedStateRef.WorldUnmanaged.Time.ElapsedTime - _lastSerializationStartTime;
		if (_serializeThread.Priority < System.Threading.ThreadPriority.Normal && num > 30.0)
		{
			UnityEngine.Debug.LogWarning("SerializeWorldSystem: serializer thread might be starved, bumping priority.");
			_serializeThread.Priority = System.Threading.ThreadPriority.Normal;
		}
	}

	internal void WaitForSerializationJobToComplete()
	{
		_noPendingSerialization.WaitOne();
	}

	private static void AllocateSerializedChunk(in ArchetypeChunk batchInChunk, ref SerializedChunkData serializedChunk, NativeList<Entity> SerializedEntities, NativeList<SerializeWorldDataCD.FreeEntityRange> FreeSerializedEntities, NativeList<SerializedChunkData> Chunks, NativeList<int> FreeChunks)
	{
		int i;
		for (i = 0; i < FreeSerializedEntities.Length; i++)
		{
			SerializeWorldDataCD.FreeEntityRange freeEntityRange = FreeSerializedEntities[i];
			if (freeEntityRange.Capacity == batchInChunk.Capacity)
			{
				serializedChunk.StartIndex = freeEntityRange.StartIndex;
				break;
			}
		}
		if (i == FreeSerializedEntities.Length)
		{
			serializedChunk.StartIndex = SerializedEntities.Length;
			SerializedEntities.ResizeUninitialized(SerializedEntities.Length + batchInChunk.Capacity);
		}
		else
		{
			FreeSerializedEntities.RemoveAtSwapBack(i);
		}
		serializedChunk.Capacity = batchInChunk.Capacity;
		if (FreeChunks.IsEmpty)
		{
			serializedChunk.ChunkListIndex = Chunks.Length;
			Chunks.Add(in serializedChunk);
		}
		else
		{
			int num = FreeChunks.Length - 1;
			serializedChunk.ChunkListIndex = FreeChunks[num];
			FreeChunks.Length = num;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(SerializeSpawnedDungeonJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__SerializeWorldSystem_SerializeSpawnedDungeonJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__SerializeWorldSystem_SerializeSpawnedDungeonJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__SerializeWorldSystem_SerializeSpawnedDungeonJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__SerializeWorldSystem_SerializeSpawnedDungeonJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_1(SerializeScannedJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__SerializeWorldSystem_SerializeScannedJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__SerializeWorldSystem_SerializeScannedJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__SerializeWorldSystem_SerializeScannedJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__SerializeWorldSystem_SerializeScannedJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_2(SerializePendingScanJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__SerializeWorldSystem_SerializePendingScanJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__SerializeWorldSystem_SerializePendingScanJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__SerializeWorldSystem_SerializePendingScanJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__SerializeWorldSystem_SerializePendingScanJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<CustomSceneCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeDisabledEntities);
		__query_783526210_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ObjectLookupWriterCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_783526210_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<SerializeWorldDataCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_783526210_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<DeserializeWorldTriggerCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_783526210_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAllRW<SerializeWorldDataCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_783526210_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<TheGreatWallHasBeenLoweredCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_783526210_5 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<KilledEnemiesBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_783526210_6 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ActivatedContentBundlesBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_783526210_7 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<DatabaseCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_783526210_8 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_783526210_9 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_783526210_10 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldInfoCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_783526210_11 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldGenerationTypeCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_783526210_12 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ServerGuidCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_783526210_13 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ServerSeedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_783526210_14 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAllRW<ActivatedContentBundlesBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_783526210_15 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldGenerationParametersSerializedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_783526210_16 = entityQueryBuilder2.Build(ref state);
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
	public SerializeWorldSystem()
	{
	}
}
