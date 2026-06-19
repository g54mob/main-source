using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.NetCode;
using UnityEngine;

[BurstCompile]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(BeforePredictedFixedStepSimulationSystemGroup), OrderFirst = true)]
public struct SummarizeConditionsSystem : ISystem, ISystemCompilerGenerated
{
	[BurstCompile]
	private struct SummarizeConditionsJob : IJobChunk
	{
		[ReadOnly]
		public NativeParallelMultiHashMap<int, SetBonusData> SetBonusesLookUp;

		[ReadOnly]
		public NativeParallelHashMap<int, SetBonusID> ObjectIDToSetBonus;

		[ReadOnly]
		public NativeParallelHashMap<int, PetInfosTable.PetTalentInfoBlittable> PetTalentsLookUp;

		[ReadOnly]
		public NativeParallelMultiHashMap<int, PetInfosTable.PetTalentMultiplierOverride> PetTalentsMultiplierOverridesLookUp;

		public BufferTypeHandle<SummarizedConditionEffectsBuffer> SumConditionEffectsBufferTypeHandle;

		public BufferTypeHandle<SummarizedConditionsBuffer> SumConditionsBufferTypeHandle;

		[ReadOnly]
		public BufferTypeHandle<ConditionsBuffer> ConditionsBufferTypeHandle;

		[ReadOnly]
		public BufferTypeHandle<ContainedObjectsBuffer> ContainedObjectsBufferTypeHandle;

		[ReadOnly]
		public BufferTypeHandle<SkillConditionsBuffer> SkillConditionsBufferTypeHandle;

		[ReadOnly]
		public BufferTypeHandle<SkillTalentConditionsBuffer> SkillTalentConditionsBufferTypeHandle;

		[ReadOnly]
		public BufferTypeHandle<ActiveAffixConditionsBuffer> AffixConditionsBufferTypeHandle;

		[ReadOnly]
		public BufferTypeHandle<SoulsConditionsBuffer> SoulsConditionsBufferTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<EquipmentCD> EquipmentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<PetOwnerCD> PetOwnerTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<EquippedObjectCD> EquippedObjectTypeHandle;

		public ComponentTypeHandle<HasAuraConditionCD> HasAuraConditionTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<ObjectDataCD> ObjectDataTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<PetCD> PetTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<CollectedAndEnabledSoulsMask> SoulsMaskTypeHandle;

		[ReadOnly]
		public BufferLookup<ConditionsBuffer> ConditionsBufferLookup;

		[ReadOnly]
		public BufferLookup<GivesConditionsWhenEquippedBuffer> GivesConditionsWhenEquippedBufferLookup;

		[ReadOnly]
		public BufferLookup<LevelEntitiesBuffer> LevelEntityBufferLookup;

		[ReadOnly]
		public BufferLookup<PetTalentBuffer> PetTalentBufferLookup;

		[ReadOnly]
		public ComponentLookup<DurabilityCD> DurabilityLookup;

		[ReadOnly]
		public ComponentLookup<GivesConditionWhenHeldInHand> GivesConditionWhenHeldInHandLookup;

		[ReadOnly]
		public ComponentLookup<LevelCD> LevelLookup;

		[ReadOnly]
		public ComponentLookup<PetCD> PetLookup;

		public BlobAssetReference<ConditionsTableBlob> ConditionsTable;

		public BlobAssetReference<PugDatabase.PugDatabaseBank> Database;

		[ReadOnly]
		public InventoryAuxDataAccessor InventoryAuxDataAccessor;

		public uint LastChangeVersion;

		[BurstCompile]
		public void Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			if (!chunk.DidOrderChange(LastChangeVersion) && (!chunk.Has(ConditionsBufferTypeHandle) || !chunk.DidChange(ref ConditionsBufferTypeHandle, LastChangeVersion)) && (!chunk.Has(SkillConditionsBufferTypeHandle) || !chunk.DidChange(ref SkillConditionsBufferTypeHandle, LastChangeVersion)) && (!chunk.Has(SkillTalentConditionsBufferTypeHandle) || !chunk.DidChange(ref SkillTalentConditionsBufferTypeHandle, LastChangeVersion)) && (!chunk.Has(AffixConditionsBufferTypeHandle) || !chunk.DidChange(ref AffixConditionsBufferTypeHandle, LastChangeVersion)) && (!chunk.Has(SoulsConditionsBufferTypeHandle) || (!chunk.DidChange(ref SoulsConditionsBufferTypeHandle, LastChangeVersion) && !chunk.DidChange(ref SoulsMaskTypeHandle, LastChangeVersion))) && (!chunk.Has(EquipmentTypeHandle) || (!chunk.DidChange(ref EquippedObjectTypeHandle, LastChangeVersion) && !chunk.DidChange(ref ContainedObjectsBufferTypeHandle, LastChangeVersion))) && (!chunk.Has(PetOwnerTypeHandle) || !chunk.DidChange(ref PetOwnerTypeHandle, LastChangeVersion)) && (!chunk.Has(PetTypeHandle) || !chunk.DidChange(ref PetTypeHandle, LastChangeVersion)))
			{
				return;
			}
			BufferAccessor<SummarizedConditionEffectsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref SumConditionEffectsBufferTypeHandle);
			BufferAccessor<SummarizedConditionsBuffer> bufferAccessor2 = chunk.GetBufferAccessor(ref SumConditionsBufferTypeHandle);
			NativeArray<PetCD> nativeArray = (chunk.Has(PetTypeHandle) ? chunk.GetNativeArray(ref PetTypeHandle) : default(NativeArray<PetCD>));
			NativeList<ConditionData> result = new NativeList<ConditionData>(Allocator.Temp);
			ChunkEntityEnumerator chunkEntityEnumerator = new ChunkEntityEnumerator(useEnabledMask, chunkEnabledMask, chunk.Count);
			int nextIndex;
			while (chunkEntityEnumerator.NextEntityIndex(out nextIndex))
			{
				for (int i = 0; i < 143; i++)
				{
					bufferAccessor[nextIndex].ElementAt(i) = default(SummarizedConditionEffectsBuffer);
				}
				for (int j = 0; j < 357; j++)
				{
					bufferAccessor2[nextIndex].ElementAt(j) = default(SummarizedConditionsBuffer);
				}
			}
			if (chunk.Has(ConditionsBufferTypeHandle))
			{
				BufferAccessor<ConditionsBuffer> bufferAccessor3 = chunk.GetBufferAccessor(ref ConditionsBufferTypeHandle);
				ChunkEntityEnumerator chunkEntityEnumerator2 = new ChunkEntityEnumerator(useEnabledMask, chunkEnabledMask, chunk.Count);
				int nextIndex2;
				while (chunkEntityEnumerator2.NextEntityIndex(out nextIndex2))
				{
					bool flag = nativeArray.IsCreated && nativeArray[nextIndex2].buffsOwner;
					DynamicBuffer<ConditionsBuffer> dynamicBuffer = bufferAccessor3[nextIndex2];
					for (int k = 0; k < dynamicBuffer.Length; k++)
					{
						if (!flag || dynamicBuffer[k].condition.conditionData.conditionID == ConditionID.PetBuffsIncrease)
						{
							AddConditionToSummarizedBuffers(dynamicBuffer[k].condition.conditionData, bufferAccessor2[nextIndex2], bufferAccessor[nextIndex2]);
						}
					}
				}
			}
			if (chunk.Has(SkillConditionsBufferTypeHandle))
			{
				BufferAccessor<SkillConditionsBuffer> bufferAccessor4 = chunk.GetBufferAccessor(ref SkillConditionsBufferTypeHandle);
				ChunkEntityEnumerator chunkEntityEnumerator3 = new ChunkEntityEnumerator(useEnabledMask, chunkEnabledMask, chunk.Count);
				int nextIndex3;
				while (chunkEntityEnumerator3.NextEntityIndex(out nextIndex3))
				{
					for (int l = 0; l < bufferAccessor4[nextIndex3].Length; l++)
					{
						AddConditionToSummarizedBuffers(bufferAccessor4[nextIndex3][l].conditionData, bufferAccessor2[nextIndex3], bufferAccessor[nextIndex3]);
					}
				}
			}
			if (chunk.Has(SkillTalentConditionsBufferTypeHandle))
			{
				BufferAccessor<SkillTalentConditionsBuffer> bufferAccessor5 = chunk.GetBufferAccessor(ref SkillTalentConditionsBufferTypeHandle);
				ChunkEntityEnumerator chunkEntityEnumerator4 = new ChunkEntityEnumerator(useEnabledMask, chunkEnabledMask, chunk.Count);
				int nextIndex4;
				while (chunkEntityEnumerator4.NextEntityIndex(out nextIndex4))
				{
					for (int m = 0; m < bufferAccessor5[nextIndex4].Length; m++)
					{
						AddConditionToSummarizedBuffers(bufferAccessor5[nextIndex4][m].conditionData, bufferAccessor2[nextIndex4], bufferAccessor[nextIndex4]);
					}
				}
			}
			if (chunk.Has(AffixConditionsBufferTypeHandle))
			{
				BufferAccessor<ActiveAffixConditionsBuffer> bufferAccessor6 = chunk.GetBufferAccessor(ref AffixConditionsBufferTypeHandle);
				ChunkEntityEnumerator chunkEntityEnumerator5 = new ChunkEntityEnumerator(useEnabledMask, chunkEnabledMask, chunk.Count);
				int nextIndex5;
				while (chunkEntityEnumerator5.NextEntityIndex(out nextIndex5))
				{
					for (int n = 0; n < bufferAccessor6[nextIndex5].Length; n++)
					{
						AddConditionToSummarizedBuffers(bufferAccessor6[nextIndex5][n].conditionData, bufferAccessor2[nextIndex5], bufferAccessor[nextIndex5]);
					}
				}
			}
			if (chunk.Has(SoulsConditionsBufferTypeHandle) && chunk.Has(SoulsMaskTypeHandle))
			{
				BufferAccessor<SoulsConditionsBuffer> bufferAccessor7 = chunk.GetBufferAccessor(ref SoulsConditionsBufferTypeHandle);
				NativeArray<CollectedAndEnabledSoulsMask> nativeArray2 = chunk.GetNativeArray(ref SoulsMaskTypeHandle);
				ChunkEntityEnumerator chunkEntityEnumerator6 = new ChunkEntityEnumerator(useEnabledMask, chunkEnabledMask, chunk.Count);
				int nextIndex6;
				while (chunkEntityEnumerator6.NextEntityIndex(out nextIndex6))
				{
					for (int num = 0; num < bufferAccessor7[nextIndex6].Length; num++)
					{
						if (nativeArray2[nextIndex6].HasSoulEnabled(bufferAccessor7[nextIndex6][num].soulID))
						{
							AddConditionToSummarizedBuffers(bufferAccessor7[nextIndex6][num].conditionData, bufferAccessor2[nextIndex6], bufferAccessor[nextIndex6]);
						}
					}
				}
			}
			if (chunk.Has(EquipmentTypeHandle) && chunk.Has(ContainedObjectsBufferTypeHandle))
			{
				NativeArray<EquipmentCD> nativeArray3 = chunk.GetNativeArray(ref EquipmentTypeHandle);
				BufferAccessor<ContainedObjectsBuffer> bufferAccessor8 = chunk.GetBufferAccessor(ref ContainedObjectsBufferTypeHandle);
				NativeArray<PetOwnerCD> nativeArray4 = (chunk.Has(PetOwnerTypeHandle) ? chunk.GetNativeArray(ref PetOwnerTypeHandle) : default(NativeArray<PetOwnerCD>));
				NativeArray<EquippedObjectCD> nativeArray5 = (chunk.Has(EquippedObjectTypeHandle) ? chunk.GetNativeArray(ref EquippedObjectTypeHandle) : default(NativeArray<EquippedObjectCD>));
				NativeParallelHashMap<int, int> nativeParallelHashMap = new NativeParallelHashMap<int, int>(16, Allocator.Temp);
				NativeParallelHashSet<int> nativeParallelHashSet = new NativeParallelHashSet<int>(16, Allocator.Temp);
				NativeList<ObjectDataCD> nativeList = new NativeList<ObjectDataCD>(16, Allocator.Temp);
				ChunkEntityEnumerator chunkEntityEnumerator7 = new ChunkEntityEnumerator(useEnabledMask, chunkEnabledMask, chunk.Count);
				int nextIndex7;
				while (chunkEntityEnumerator7.NextEntityIndex(out nextIndex7))
				{
					EquipmentCD equipmentCD = nativeArray3[nextIndex7];
					nativeList.Clear();
					DynamicBuffer<ContainedObjectsBuffer> dynamicBuffer2 = bufferAccessor8[nextIndex7];
					ContainedObjectsBuffer containedObjectsBuffer = dynamicBuffer2[equipmentCD.helmSlotIndex];
					nativeList.Add(in containedObjectsBuffer.objectData);
					containedObjectsBuffer = dynamicBuffer2[equipmentCD.necklaceSlotIndex];
					nativeList.Add(in containedObjectsBuffer.objectData);
					containedObjectsBuffer = dynamicBuffer2[equipmentCD.breastSlotIndex];
					nativeList.Add(in containedObjectsBuffer.objectData);
					containedObjectsBuffer = dynamicBuffer2[equipmentCD.pantsSlotIndex];
					nativeList.Add(in containedObjectsBuffer.objectData);
					containedObjectsBuffer = dynamicBuffer2[equipmentCD.ring1SlotIndex];
					nativeList.Add(in containedObjectsBuffer.objectData);
					containedObjectsBuffer = dynamicBuffer2[equipmentCD.ring2SlotIndex];
					nativeList.Add(in containedObjectsBuffer.objectData);
					containedObjectsBuffer = dynamicBuffer2[equipmentCD.offHandIndex];
					nativeList.Add(in containedObjectsBuffer.objectData);
					containedObjectsBuffer = dynamicBuffer2[equipmentCD.bagIndex];
					nativeList.Add(in containedObjectsBuffer.objectData);
					containedObjectsBuffer = dynamicBuffer2[equipmentCD.lanternIndex];
					nativeList.Add(in containedObjectsBuffer.objectData);
					ObjectID objectID = (nativeArray4.IsCreated ? dynamicBuffer2[nativeArray4[nextIndex7].SlotIndex].objectData.objectID : ObjectID.None);
					if (objectID != ObjectID.None)
					{
						Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(objectID, Database);
						if (PetLookup.TryGetComponent(primaryPrefabEntity, out var componentData) && componentData.buffsOwner)
						{
							if (ConditionsBufferLookup.TryGetBuffer(primaryPrefabEntity, out var bufferData))
							{
								for (int num2 = 0; num2 < bufferData.Length; num2++)
								{
									AddConditionToSummarizedBuffers(bufferData[num2].condition.conditionData, bufferAccessor2[nextIndex7], bufferAccessor[nextIndex7]);
								}
							}
							int auxDataIndex = dynamicBuffer2[nativeArray4[nextIndex7].SlotIndex].auxDataIndex;
							if (auxDataIndex != 0 && InventoryAuxDataAccessor.TryGetBuffer(auxDataIndex, PetTalentBufferLookup, out var buffer))
							{
								float buffMultiplier = 1f + (float)bufferAccessor[nextIndex7][95].value / 100f;
								result.Clear();
								PetExtensions.GetNativeActiveConditions(objectID, buffer, PetTalentsLookUp, PetTalentsMultiplierOverridesLookUp, componentData, buffMultiplier, result);
								foreach (ConditionData item3 in result)
								{
									int value = (int)math.round((float)item3.value * item3.valueMultiplier);
									AddConditionToSummarizedBuffers(item3.conditionID, value, bufferAccessor2[nextIndex7], bufferAccessor[nextIndex7]);
								}
							}
						}
					}
					if (nativeArray5.IsCreated)
					{
						int equippedSlotIndex = nativeArray5[nextIndex7].equippedSlotIndex;
						ObjectDataCD value2 = dynamicBuffer2[equippedSlotIndex].objectData;
						Entity primaryPrefabEntity2 = PugDatabase.GetPrimaryPrefabEntity(value2.objectID, Database);
						if (equippedSlotIndex >= 0 && equippedSlotIndex < dynamicBuffer2.Length && GivesConditionWhenHeldInHandLookup.HasComponent(primaryPrefabEntity2))
						{
							nativeList.Add(in value2);
						}
					}
					nativeParallelHashMap.Clear();
					nativeParallelHashSet.Clear();
					foreach (ObjectDataCD item4 in nativeList)
					{
						Entity primaryPrefabEntity3 = PugDatabase.GetPrimaryPrefabEntity(item4.objectID, Database);
						if (DurabilityLookup.HasComponent(primaryPrefabEntity3) && item4.amount <= 0)
						{
							continue;
						}
						if (LevelEntityBufferLookup.TryGetBuffer(primaryPrefabEntity3, out var bufferData2) && LevelLookup.TryGetComponent(primaryPrefabEntity3, out var componentData2))
						{
							int index = ((item4.variation > 0) ? math.min(item4.variation, LevelScaling.GetMaxLevel()) : componentData2.level);
							Entity entity = bufferData2[index].entity;
							DynamicBuffer<GivesConditionsWhenEquippedBuffer> dynamicBuffer3 = GivesConditionsWhenEquippedBufferLookup[entity];
							DurabilityCD componentData3;
							bool flag2 = DurabilityLookup.TryGetComponent(primaryPrefabEntity3, out componentData3) && componentData3.IsReinforced(item4.amount);
							for (int num3 = 0; num3 < dynamicBuffer3.Length; num3++)
							{
								EquipmentCondition equipmentCondition = dynamicBuffer3[num3].equipmentCondition;
								int id = (int)equipmentCondition.id;
								int num4 = equipmentCondition.value;
								if (!ConditionsTable.Value.infos[id].isUnique && flag2 && ConditionsTable.Value.infos[id].effect != ConditionEffect.MaxMinions)
								{
									int num5 = 0;
									if (equipmentCondition.value < 0)
									{
										num5 = (int)math.round(math.min(-1f, (float)equipmentCondition.value * 0.14999998f));
										if (ConditionsTable.Value.infos[id].isNegative)
										{
											num5 = -num5;
										}
									}
									else
									{
										num5 = (int)math.round(math.max(1f, (float)equipmentCondition.value * 0.14999998f));
									}
									num4 += num5;
								}
								AddConditionToSummarizedBuffers(equipmentCondition.id, num4, bufferAccessor2[nextIndex7], bufferAccessor[nextIndex7]);
							}
						}
						if (ObjectIDToSetBonus.TryGetValue((int)item4.objectID, out var item) && !nativeParallelHashSet.Contains((int)item4.objectID))
						{
							if (!nativeParallelHashMap.TryGetValue((int)item, out var item2))
							{
								nativeParallelHashMap.Add((int)item, 1);
							}
							else
							{
								nativeParallelHashMap[(int)item] = item2 + 1;
							}
							nativeParallelHashSet.Add((int)item4.objectID);
						}
					}
					foreach (KeyValue<int, int> item5 in nativeParallelHashMap)
					{
						int key = item5.Key;
						int value3 = item5.Value;
						foreach (SetBonusData item6 in SetBonusesLookUp.GetValuesForKey(key))
						{
							if (value3 >= item6.requiredPieces)
							{
								AddConditionToSummarizedBuffers(item6.conditionData, bufferAccessor2[nextIndex7], bufferAccessor[nextIndex7]);
							}
						}
					}
				}
				nativeParallelHashMap.Dispose();
				nativeParallelHashSet.Dispose();
				nativeList.Dispose();
			}
			if (chunk.Has(PetTypeHandle) && chunk.Has(ObjectDataTypeHandle))
			{
				NativeArray<ObjectDataCD> nativeArray6 = chunk.GetNativeArray(ref ObjectDataTypeHandle);
				ChunkEntityEnumerator chunkEntityEnumerator8 = new ChunkEntityEnumerator(useEnabledMask, chunkEnabledMask, chunk.Count);
				int nextIndex8;
				while (chunkEntityEnumerator8.NextEntityIndex(out nextIndex8))
				{
					if (nativeArray[nextIndex8].buffsOwner)
					{
						continue;
					}
					int inventoryAuxDataIndex = nativeArray[nextIndex8].inventoryAuxDataIndex;
					if (inventoryAuxDataIndex == 0 || !InventoryAuxDataAccessor.TryGetBuffer(inventoryAuxDataIndex, PetTalentBufferLookup, out var buffer2))
					{
						continue;
					}
					float buffMultiplier2 = 1f + (float)bufferAccessor[nextIndex8][95].value / 100f;
					result.Clear();
					PetExtensions.GetNativeActiveConditions(nativeArray6[nextIndex8].objectID, buffer2, PetTalentsLookUp, PetTalentsMultiplierOverridesLookUp, nativeArray[nextIndex8], buffMultiplier2, result);
					foreach (ConditionData item7 in result)
					{
						int value4 = (int)math.round((float)item7.value * item7.valueMultiplier);
						AddConditionToSummarizedBuffers(item7.conditionID, value4, bufferAccessor2[nextIndex8], bufferAccessor[nextIndex8]);
					}
				}
			}
			if (chunk.Has(HasAuraConditionTypeHandle))
			{
				ChunkEntityEnumerator chunkEntityEnumerator9 = new ChunkEntityEnumerator(useEnabledMask, chunkEnabledMask, chunk.Count);
				int nextIndex9;
				while (chunkEntityEnumerator9.NextEntityIndex(out nextIndex9))
				{
					bool value5 = HasAnyAuraEffect(bufferAccessor2[nextIndex9]);
					chunk.SetComponentEnabled(HasAuraConditionTypeHandle, nextIndex9, value5);
				}
			}
			ChunkEntityEnumerator chunkEntityEnumerator10 = new ChunkEntityEnumerator(useEnabledMask, chunkEnabledMask, chunk.Count);
			int nextIndex10;
			while (chunkEntityEnumerator10.NextEntityIndex(out nextIndex10))
			{
				int cap = 90;
				if (bufferAccessor2[nextIndex10][320].value > 0)
				{
					cap = 100;
				}
				LowerCapConditionEffect(ConditionEffect.MovementSpeed, -900, bufferAccessor[nextIndex10]);
				UpperCapConditionEffect(ConditionEffect.DodgeChance, cap, bufferAccessor[nextIndex10]);
				UpperCapConditionEffect(ConditionEffect.DamageTakenPercentage, 900, bufferAccessor[nextIndex10]);
				UpperCapConditionEffect(ConditionEffect.ReducedDamageFromBosses, 90, bufferAccessor[nextIndex10]);
				UpperCapConditionEffect(ConditionEffect.ReducedDamageFromExplosions, 90, bufferAccessor[nextIndex10]);
				UpperCapConditionEffect(ConditionEffect.CritChance, 100, bufferAccessor[nextIndex10]);
			}
		}

		private bool HasAnyAuraEffect(DynamicBuffer<SummarizedConditionsBuffer> conditionsBuffer)
		{
			if (conditionsBuffer[77].value == 0 && conditionsBuffer[144].value == 0 && conditionsBuffer[146].value == 0 && conditionsBuffer[163].value == 0 && conditionsBuffer[160].value == 0 && conditionsBuffer[206].value == 0 && conditionsBuffer[248].value == 0)
			{
				return conditionsBuffer[250].value != 0;
			}
			return true;
		}

		private static void LowerCapConditionEffect(ConditionEffect effect, int cap, DynamicBuffer<SummarizedConditionEffectsBuffer> sumEffects)
		{
			sumEffects.ElementAt((int)effect) = new SummarizedConditionEffectsBuffer
			{
				value = math.max(sumEffects[(int)effect].value, cap)
			};
		}

		private static void UpperCapConditionEffect(ConditionEffect effect, int cap, DynamicBuffer<SummarizedConditionEffectsBuffer> sumEffects)
		{
			sumEffects.ElementAt((int)effect) = new SummarizedConditionEffectsBuffer
			{
				value = math.min(sumEffects[(int)effect].value, cap)
			};
		}

		private void AddConditionToSummarizedBuffers(ConditionData conditionData, DynamicBuffer<SummarizedConditionsBuffer> sumConditionsBuffer, DynamicBuffer<SummarizedConditionEffectsBuffer> sumConditionEffectsBuffer)
		{
			AddConditionToSummarizedBuffers(conditionData.conditionID, conditionData.value, sumConditionsBuffer, sumConditionEffectsBuffer);
		}

		private void AddConditionToSummarizedBuffers(ConditionID id, int value, DynamicBuffer<SummarizedConditionsBuffer> sumConditionsBuffer, DynamicBuffer<SummarizedConditionEffectsBuffer> sumConditionEffectsBuffer)
		{
			if (id < ConditionID.None || (int)id >= ConditionsTable.Value.infos.Length)
			{
				UnityEngine.Debug.LogError($"Condition id {(int)id} is out of bounds for conditions table of length {ConditionsTable.Value.infos.Length}.");
				return;
			}
			int effect = (int)ConditionsTable.Value.infos[(int)id].effect;
			sumConditionsBuffer.ElementAt((int)id) = new SummarizedConditionsBuffer
			{
				value = sumConditionsBuffer[(int)id].value + value
			};
			sumConditionEffectsBuffer.ElementAt(effect) = new SummarizedConditionEffectsBuffer
			{
				value = sumConditionEffectsBuffer[effect].value + value
			};
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	[BurstCompile]
	[WithAll(new Type[] { typeof(Simulate) })]
	private struct ApplyOwnerBuffsToPetJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<PetCD> __PetCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<OwnerReferenceCD> __OwnerReferenceCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__PetCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PetCD>(isReadOnly: true);
					__OwnerReferenceCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<OwnerReferenceCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__PetCD_RO_ComponentTypeHandle.Update(ref state);
					__OwnerReferenceCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<PetCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<OwnerReferenceCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
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
			public void Run(ref ApplyOwnerBuffsToPetJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref ApplyOwnerBuffsToPetJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref ApplyOwnerBuffsToPetJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref ApplyOwnerBuffsToPetJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref ApplyOwnerBuffsToPetJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref ApplyOwnerBuffsToPetJob job, EntityManager entityManager)
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

		[ReadOnly]
		public BufferLookup<SummarizedConditionEffectsBuffer> SumConditionEffectsBufferLookup;

		public EntityCommandBuffer Ecb;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		[BurstCompile]
		public void Execute(Entity entity, in PetCD pet, in OwnerReferenceCD ownerReference)
		{
			if (SumConditionEffectsBufferLookup.TryGetBuffer(ownerReference.owner, out var bufferData))
			{
				int value = bufferData[90].value;
				int value2 = bufferData[93].value;
				int value3 = bufferData[92].value;
				int value4 = bufferData[91].value;
				int value5 = bufferData[94].value;
				if (pet.petType == PetType.Melee)
				{
					AddOrRemoveCondition(entity, ConditionID.PetMeleeDamageIncrease, value);
					AddOrRemoveCondition(entity, ConditionID.PetMeleeAttackSpeedIncrease, value2);
				}
				else if (pet.petType == PetType.Range)
				{
					AddOrRemoveCondition(entity, ConditionID.PetRangeDamageIncrease, value);
					AddOrRemoveCondition(entity, ConditionID.PetRangeAttackSpeedIncrease, value2);
				}
				if (!pet.buffsOwner)
				{
					AddOrRemoveCondition(entity, ConditionID.PetCritChanceIncrease, value3);
					AddOrRemoveCondition(entity, ConditionID.PetCritDamageIncrease, value4);
				}
				else
				{
					EntityUtility.RemoveCondition(entity, Ecb, ConditionID.PetCritChanceIncrease);
					EntityUtility.RemoveCondition(entity, Ecb, ConditionID.PetCritDamageIncrease);
				}
				AddOrRemoveCondition(entity, ConditionID.PetBuffsIncrease, value5);
			}
		}

		private void AddOrRemoveCondition(Entity entity, ConditionID conditionID, int conditionValue)
		{
			if (conditionValue != 0)
			{
				EntityUtility.AddNewCondition(entity, Ecb, new ConditionData
				{
					conditionID = conditionID,
					value = conditionValue
				});
			}
			else
			{
				EntityUtility.RemoveCondition(entity, Ecb, conditionID);
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__PetCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__OwnerReferenceCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PetCD>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<OwnerReferenceCD>(nativeArrayPtr3, i));
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
						Entity entity2 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, nextRangeBegin);
						Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PetCD>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<OwnerReferenceCD>(nativeArrayPtr3, nextRangeBegin));
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
					Entity entity3 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j);
					Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PetCD>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<OwnerReferenceCD>(nativeArrayPtr3, j));
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					Entity entity4 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k);
					Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PetCD>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<OwnerReferenceCD>(nativeArrayPtr3, k));
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

	private struct TypeHandle
	{
		public BufferTypeHandle<SummarizedConditionEffectsBuffer> __SummarizedConditionEffectsBuffer_RW_BufferTypeHandle;

		public BufferTypeHandle<SummarizedConditionsBuffer> __SummarizedConditionsBuffer_RW_BufferTypeHandle;

		[ReadOnly]
		public BufferTypeHandle<ConditionsBuffer> __ConditionsBuffer_RO_BufferTypeHandle;

		[ReadOnly]
		public BufferTypeHandle<ContainedObjectsBuffer> __ContainedObjectsBuffer_RO_BufferTypeHandle;

		[ReadOnly]
		public BufferTypeHandle<SkillConditionsBuffer> __SkillConditionsBuffer_RO_BufferTypeHandle;

		[ReadOnly]
		public BufferTypeHandle<SkillTalentConditionsBuffer> __SkillTalentConditionsBuffer_RO_BufferTypeHandle;

		[ReadOnly]
		public BufferTypeHandle<ActiveAffixConditionsBuffer> __ActiveAffixConditionsBuffer_RO_BufferTypeHandle;

		[ReadOnly]
		public BufferTypeHandle<SoulsConditionsBuffer> __SoulsConditionsBuffer_RO_BufferTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<EquipmentCD> __EquipmentCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<PetOwnerCD> __PetOwnerCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<EquippedObjectCD> __EquippedObjectCD_RO_ComponentTypeHandle;

		public ComponentTypeHandle<HasAuraConditionCD> __HasAuraConditionCD_RW_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<ObjectDataCD> __ObjectDataCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<PetCD> __PetCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<CollectedAndEnabledSoulsMask> __CollectedAndEnabledSoulsMask_RO_ComponentTypeHandle;

		[ReadOnly]
		public BufferLookup<ConditionsBuffer> __ConditionsBuffer_RO_BufferLookup;

		[ReadOnly]
		public BufferLookup<GivesConditionsWhenEquippedBuffer> __GivesConditionsWhenEquippedBuffer_RO_BufferLookup;

		[ReadOnly]
		public BufferLookup<LevelEntitiesBuffer> __LevelEntitiesBuffer_RO_BufferLookup;

		[ReadOnly]
		public BufferLookup<PetTalentBuffer> __PetTalentBuffer_RO_BufferLookup;

		[ReadOnly]
		public ComponentLookup<DurabilityCD> __DurabilityCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<GivesConditionWhenHeldInHand> __GivesConditionWhenHeldInHand_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<LevelCD> __LevelCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PetCD> __PetCD_RO_ComponentLookup;

		[ReadOnly]
		public BufferLookup<SummarizedConditionEffectsBuffer> __SummarizedConditionEffectsBuffer_RO_BufferLookup;

		public ApplyOwnerBuffsToPetJob.InternalCompilerQueryAndHandleData __SummarizeConditionsSystem_ApplyOwnerBuffsToPetJob_WithDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__SummarizedConditionEffectsBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<SummarizedConditionEffectsBuffer>();
			__SummarizedConditionsBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<SummarizedConditionsBuffer>();
			__ConditionsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<ConditionsBuffer>(isReadOnly: true);
			__ContainedObjectsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<ContainedObjectsBuffer>(isReadOnly: true);
			__SkillConditionsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<SkillConditionsBuffer>(isReadOnly: true);
			__SkillTalentConditionsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<SkillTalentConditionsBuffer>(isReadOnly: true);
			__ActiveAffixConditionsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<ActiveAffixConditionsBuffer>(isReadOnly: true);
			__SoulsConditionsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<SoulsConditionsBuffer>(isReadOnly: true);
			__EquipmentCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<EquipmentCD>(isReadOnly: true);
			__PetOwnerCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PetOwnerCD>(isReadOnly: true);
			__EquippedObjectCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<EquippedObjectCD>(isReadOnly: true);
			__HasAuraConditionCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<HasAuraConditionCD>();
			__ObjectDataCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ObjectDataCD>(isReadOnly: true);
			__PetCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PetCD>(isReadOnly: true);
			__CollectedAndEnabledSoulsMask_RO_ComponentTypeHandle = state.GetComponentTypeHandle<CollectedAndEnabledSoulsMask>(isReadOnly: true);
			__ConditionsBuffer_RO_BufferLookup = state.GetBufferLookup<ConditionsBuffer>(isReadOnly: true);
			__GivesConditionsWhenEquippedBuffer_RO_BufferLookup = state.GetBufferLookup<GivesConditionsWhenEquippedBuffer>(isReadOnly: true);
			__LevelEntitiesBuffer_RO_BufferLookup = state.GetBufferLookup<LevelEntitiesBuffer>(isReadOnly: true);
			__PetTalentBuffer_RO_BufferLookup = state.GetBufferLookup<PetTalentBuffer>(isReadOnly: true);
			__DurabilityCD_RO_ComponentLookup = state.GetComponentLookup<DurabilityCD>(isReadOnly: true);
			__GivesConditionWhenHeldInHand_RO_ComponentLookup = state.GetComponentLookup<GivesConditionWhenHeldInHand>(isReadOnly: true);
			__LevelCD_RO_ComponentLookup = state.GetComponentLookup<LevelCD>(isReadOnly: true);
			__PetCD_RO_ComponentLookup = state.GetComponentLookup<PetCD>(isReadOnly: true);
			__SummarizedConditionEffectsBuffer_RO_BufferLookup = state.GetBufferLookup<SummarizedConditionEffectsBuffer>(isReadOnly: true);
			__SummarizeConditionsSystem_ApplyOwnerBuffsToPetJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnUpdate_0000150D_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_0000150D_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_0000150D_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(IntPtr self, IntPtr state)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)functionPointer)(self, state);
					return;
				}
			}
			__codegen__OnUpdate_0024BurstManaged(self, state);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnDestroy_0000150E_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnDestroy_0000150E_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnDestroy_0000150E_0024PostfixBurstDelegate>(__codegen__OnDestroy).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(IntPtr self, IntPtr state)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)functionPointer)(self, state);
					return;
				}
			}
			__codegen__OnDestroy_0024BurstManaged(self, state);
		}
	}

	private NativeParallelMultiHashMap<int, SetBonusData> _setBonusesLookUp;

	private NativeParallelHashMap<int, SetBonusID> _objectIDToSetBonus;

	private NativeParallelHashMap<int, PetInfosTable.PetTalentInfoBlittable> _petTalentsLookUp;

	private NativeParallelMultiHashMap<int, PetInfosTable.PetTalentMultiplierOverride> _petTalentsMultiplierOverridesLookUp;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1382883716_0;

	private EntityQuery __query_1382883716_1;

	private EntityQuery __query_1382883716_2;

	private EntityQuery __query_1382883716_3;

	private EntityQuery __query_1382883716_4;

	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<PugDatabase.DatabaseBankCD>();
		state.RequireForUpdate<ConditionsTableCD>();
		state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
		SetBonusesTable setBonusesTable = Resources.Load<SetBonusesTable>("SetBonusesTable");
		if (setBonusesTable == null)
		{
			UnityEngine.Debug.LogError("Could not find SetBonusesTable asset, conditions are disabled.");
			state.Enabled = false;
			return;
		}
		setBonusesTable.UpdateSetBonusDatas();
		_objectIDToSetBonus = new NativeParallelHashMap<int, SetBonusID>(setBonusesTable.setBonuses.Count * 2 * 3, Allocator.Persistent);
		_setBonusesLookUp = new NativeParallelMultiHashMap<int, SetBonusData>(setBonusesTable.setBonuses.Count * 2, Allocator.Persistent);
		foreach (SetBonusInfo setBonuse in setBonusesTable.setBonuses)
		{
			foreach (ObjectID availablePiece in setBonuse.availablePieces)
			{
				_objectIDToSetBonus.Add((int)availablePiece, setBonuse.setBonusID);
			}
			foreach (SetBonusData setBonusData in setBonuse.setBonusDatas)
			{
				_setBonusesLookUp.Add((int)setBonuse.setBonusID, setBonusData);
			}
		}
		PetInfosTable table = PetInfosTable.GetTable();
		if (table == null)
		{
			UnityEngine.Debug.LogError("Could not find PetInfosTable asset, conditions are disabled.");
			state.Enabled = false;
			return;
		}
		_petTalentsLookUp = new NativeParallelHashMap<int, PetInfosTable.PetTalentInfoBlittable>(table.petTalents.Count * 2, Allocator.Persistent);
		_petTalentsMultiplierOverridesLookUp = new NativeParallelMultiHashMap<int, PetInfosTable.PetTalentMultiplierOverride>(table.petTalents.Count * 2, Allocator.Persistent);
		foreach (PetInfosTable.PetTalentInfo petTalent in table.petTalents)
		{
			_petTalentsLookUp.Add((int)petTalent.petTalentID, new PetInfosTable.PetTalentInfoBlittable
			{
				value = petTalent.value,
				buffValue = petTalent.buffValue,
				conditionID = petTalent.conditionID,
				petTalentID = petTalent.petTalentID
			});
			foreach (PetInfosTable.PetTalentMultiplierOverride multiplierOverride in petTalent.multiplierOverrides)
			{
				_petTalentsMultiplierOverridesLookUp.Add((int)petTalent.petTalentID, new PetInfosTable.PetTalentMultiplierOverride
				{
					petId = multiplierOverride.petId,
					multiplier = multiplierOverride.multiplier
				});
			}
		}
	}

	[BurstCompile]
	public void OnDestroy(ref SystemState state)
	{
		if (_setBonusesLookUp.IsCreated)
		{
			_setBonusesLookUp.Dispose();
		}
		if (_objectIDToSetBonus.IsCreated)
		{
			_objectIDToSetBonus.Dispose();
		}
		if (_petTalentsLookUp.IsCreated)
		{
			_petTalentsLookUp.Dispose();
		}
		if (_petTalentsMultiplierOverridesLookUp.IsCreated)
		{
			_petTalentsMultiplierOverridesLookUp.Dispose();
		}
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		bool num = state.WorldUnmanaged.IsClient();
		EntityCommandBuffer ecb = __query_1382883716_1.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
		SummarizeConditionsJob jobData = new SummarizeConditionsJob
		{
			SetBonusesLookUp = _setBonusesLookUp,
			ObjectIDToSetBonus = _objectIDToSetBonus,
			PetTalentsLookUp = _petTalentsLookUp,
			PetTalentsMultiplierOverridesLookUp = _petTalentsMultiplierOverridesLookUp,
			SumConditionEffectsBufferTypeHandle = InternalCompilerInterface.GetBufferTypeHandle(ref __TypeHandle.__SummarizedConditionEffectsBuffer_RW_BufferTypeHandle, ref state),
			SumConditionsBufferTypeHandle = InternalCompilerInterface.GetBufferTypeHandle(ref __TypeHandle.__SummarizedConditionsBuffer_RW_BufferTypeHandle, ref state),
			ConditionsBufferTypeHandle = InternalCompilerInterface.GetBufferTypeHandle(ref __TypeHandle.__ConditionsBuffer_RO_BufferTypeHandle, ref state),
			ContainedObjectsBufferTypeHandle = InternalCompilerInterface.GetBufferTypeHandle(ref __TypeHandle.__ContainedObjectsBuffer_RO_BufferTypeHandle, ref state),
			SkillConditionsBufferTypeHandle = InternalCompilerInterface.GetBufferTypeHandle(ref __TypeHandle.__SkillConditionsBuffer_RO_BufferTypeHandle, ref state),
			SkillTalentConditionsBufferTypeHandle = InternalCompilerInterface.GetBufferTypeHandle(ref __TypeHandle.__SkillTalentConditionsBuffer_RO_BufferTypeHandle, ref state),
			AffixConditionsBufferTypeHandle = InternalCompilerInterface.GetBufferTypeHandle(ref __TypeHandle.__ActiveAffixConditionsBuffer_RO_BufferTypeHandle, ref state),
			SoulsConditionsBufferTypeHandle = InternalCompilerInterface.GetBufferTypeHandle(ref __TypeHandle.__SoulsConditionsBuffer_RO_BufferTypeHandle, ref state),
			EquipmentTypeHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__EquipmentCD_RO_ComponentTypeHandle, ref state),
			PetOwnerTypeHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__PetOwnerCD_RO_ComponentTypeHandle, ref state),
			EquippedObjectTypeHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__EquippedObjectCD_RO_ComponentTypeHandle, ref state),
			HasAuraConditionTypeHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__HasAuraConditionCD_RW_ComponentTypeHandle, ref state),
			ObjectDataTypeHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__ObjectDataCD_RO_ComponentTypeHandle, ref state),
			PetTypeHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__PetCD_RO_ComponentTypeHandle, ref state),
			SoulsMaskTypeHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__CollectedAndEnabledSoulsMask_RO_ComponentTypeHandle, ref state),
			ConditionsBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__ConditionsBuffer_RO_BufferLookup, ref state),
			GivesConditionsWhenEquippedBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__GivesConditionsWhenEquippedBuffer_RO_BufferLookup, ref state),
			LevelEntityBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__LevelEntitiesBuffer_RO_BufferLookup, ref state),
			PetTalentBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__PetTalentBuffer_RO_BufferLookup, ref state),
			DurabilityLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DurabilityCD_RO_ComponentLookup, ref state),
			GivesConditionWhenHeldInHandLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__GivesConditionWhenHeldInHand_RO_ComponentLookup, ref state),
			LevelLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__LevelCD_RO_ComponentLookup, ref state),
			PetLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PetCD_RO_ComponentLookup, ref state),
			ConditionsTable = __query_1382883716_2.GetSingleton<ConditionsTableCD>().Value,
			Database = __query_1382883716_3.GetSingleton<PugDatabase.DatabaseBankCD>().databaseBankBlob,
			InventoryAuxDataAccessor = __query_1382883716_4.GetSingleton<InventoryAuxDataSystemDataCD>().GetAccessor(),
			LastChangeVersion = state.LastSystemVersion
		};
		state.Dependency = JobChunkExtensions.ScheduleParallel(jobData, __query_1382883716_0, state.Dependency);
		if (!num)
		{
			ApplyOwnerBuffsToPetJob job = new ApplyOwnerBuffsToPetJob
			{
				Ecb = ecb,
				SumConditionEffectsBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__SummarizedConditionEffectsBuffer_RO_BufferLookup, ref state)
			};
			state.Dependency = __ScheduleViaJobChunkExtension_0(job, __TypeHandle.__SummarizeConditionsSystem_ApplyOwnerBuffsToPetJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(ApplyOwnerBuffsToPetJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__SummarizeConditionsSystem_ApplyOwnerBuffsToPetJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__SummarizeConditionsSystem_ApplyOwnerBuffsToPetJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__SummarizeConditionsSystem_ApplyOwnerBuffsToPetJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__SummarizeConditionsSystem_ApplyOwnerBuffsToPetJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<SummarizedConditionsBuffer, SummarizedConditionEffectsBuffer>();
		__query_1382883716_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1382883716_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ConditionsTableCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1382883716_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1382883716_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<InventoryAuxDataSystemDataCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1382883716_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder.Dispose();
	}

	public void OnCreateForCompiler(ref SystemState state)
	{
		__AssignQueries(ref state);
		__TypeHandle.__AssignHandles(ref state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate(IntPtr self, IntPtr state)
	{
		((SummarizeConditionsSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_0000150D_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnDestroy(IntPtr self, IntPtr state)
	{
		__codegen__OnDestroy_0000150E_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((SummarizeConditionsSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((SummarizeConditionsSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnDestroy_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((SummarizeConditionsSystem*)self.ToPointer())->OnDestroy(ref *(SystemState*)state.ToPointer());
	}
}
