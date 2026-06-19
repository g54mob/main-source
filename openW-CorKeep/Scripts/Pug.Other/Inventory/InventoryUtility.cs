using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using PlayerCommand;
using Pug.Automation;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Physics;
using Unity.Transforms;
using UnityEngine;

namespace Inventory
{
	[BurstCompile]
	public static class InventoryUtility
	{
		private struct ObjectDataCDComparer : IComparer<ObjectDataCD>
		{
			private BlobAssetReference<PugDatabase.PugDatabaseBank> database;

			public ObjectDataCDComparer(BlobAssetReference<PugDatabase.PugDatabaseBank> database)
			{
				this.database = database;
			}

			public int Compare(ObjectDataCD x, ObjectDataCD y)
			{
				if (x.objectID == ObjectID.None)
				{
					if (y.objectID != ObjectID.None)
					{
						return 1;
					}
					return 0;
				}
				if (y.objectID == ObjectID.None)
				{
					if (x.objectID != ObjectID.None)
					{
						return -1;
					}
					return 0;
				}
				ref PugDatabase.EntityObjectInfo entityObjectInfo = ref PugDatabase.GetEntityObjectInfo(x.objectID, database, x.variation);
				ref PugDatabase.EntityObjectInfo entityObjectInfo2 = ref PugDatabase.GetEntityObjectInfo(y.objectID, database, y.variation);
				int num = entityObjectInfo.isStackable.CompareTo(entityObjectInfo2.isStackable);
				if (num != 0)
				{
					return num;
				}
				int objectType = (int)entityObjectInfo.objectType;
				int num2 = objectType.CompareTo((int)entityObjectInfo2.objectType);
				if (num2 != 0)
				{
					return num2;
				}
				objectType = (int)x.objectID;
				int num3 = objectType.CompareTo((int)y.objectID);
				if (num3 != 0)
				{
					return num3;
				}
				int num4 = x.variation.CompareTo(y.variation);
				if (num4 != 0)
				{
					return num4;
				}
				return y.amount.CompareTo(x.amount);
			}
		}

		public enum SlotRequirementFulfillment
		{
			NoRequirementFound = 0,
			FailedRequirement = 1,
			FulfilledRequirement = 2
		}

		public struct EntityDistance : IComparable<EntityDistance>
		{
			public Entity entity;

			public float distance;

			public float3 position;

			private const float DISTANCE_MARGIN_ERROR = 0.05f;

			public int CompareTo(EntityDistance other)
			{
				if (math.abs(distance - other.distance) <= 0.05f)
				{
					int num = position.x.CompareTo(other.position.x);
					if (num != 0)
					{
						return num;
					}
					return position.z.CompareTo(other.position.z);
				}
				return distance.CompareTo(other.distance);
			}
		}

		private struct ObjectWithVariation : IEquatable<ObjectWithVariation>
		{
			public ObjectID objectID;

			public int variation;

			public ObjectWithVariation(ObjectID objectID, int variation)
			{
				this.objectID = objectID;
				this.variation = variation;
			}

			public bool Equals(ObjectWithVariation other)
			{
				if (objectID == other.objectID)
				{
					return variation == other.variation;
				}
				return false;
			}

			public override bool Equals(object obj)
			{
				if (obj is ObjectWithVariation other)
				{
					return Equals(other);
				}
				return false;
			}

			public override int GetHashCode()
			{
				return (int)math.hash(new int2((int)objectID, variation));
			}
		}

		private struct AutoStackChestRemainingData
		{
			public NativeHashMap<ObjectWithVariation, int> objectToRemainingSpaceAmount;

			public int remainingStacks;
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void GetNearbyChestsForCraftingByDistance_00007390_0024PostfixBurstDelegate(in float3 position, in CollisionWorld collisionWorld, in ComponentLookup<InventoryAutoTransferEnabledCD> inventoryAutoTransferEnabledLookup, in ComponentLookup<LocalTransform> localTransformLookup, ref NativeList<Entity> inventories);

		internal static class GetNearbyChestsForCraftingByDistance_00007390_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<GetNearbyChestsForCraftingByDistance_00007390_0024PostfixBurstDelegate>(GetNearbyChestsForCraftingByDistance).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static void Invoke(in float3 position, in CollisionWorld collisionWorld, in ComponentLookup<InventoryAutoTransferEnabledCD> inventoryAutoTransferEnabledLookup, in ComponentLookup<LocalTransform> localTransformLookup, ref NativeList<Entity> inventories)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<ref float3, ref CollisionWorld, ref ComponentLookup<InventoryAutoTransferEnabledCD>, ref ComponentLookup<LocalTransform>, ref NativeList<Entity>, void>)functionPointer)(ref position, ref collisionWorld, ref inventoryAutoTransferEnabledLookup, ref localTransformLookup, ref inventories);
						return;
					}
				}
				GetNearbyChestsForCraftingByDistance_0024BurstManaged(in position, in collisionWorld, in inventoryAutoTransferEnabledLookup, in localTransformLookup, ref inventories);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void GetNearbyChestsByDistance_00007391_0024PostfixBurstDelegate(in float3 position, in CollisionWorld collisionWorld, in ComponentLookup<InventoryAutoTransferEnabledCD> inventoryAutoTransferEnabledLookup, in ComponentLookup<LocalTransform> localTransformLookup, ref NativeList<Entity> inventories, float maxDistance, int maxInventories);

		internal static class GetNearbyChestsByDistance_00007391_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<GetNearbyChestsByDistance_00007391_0024PostfixBurstDelegate>(GetNearbyChestsByDistance).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static void Invoke(in float3 position, in CollisionWorld collisionWorld, in ComponentLookup<InventoryAutoTransferEnabledCD> inventoryAutoTransferEnabledLookup, in ComponentLookup<LocalTransform> localTransformLookup, ref NativeList<Entity> inventories, float maxDistance, int maxInventories)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<ref float3, ref CollisionWorld, ref ComponentLookup<InventoryAutoTransferEnabledCD>, ref ComponentLookup<LocalTransform>, ref NativeList<Entity>, float, int, void>)functionPointer)(ref position, ref collisionWorld, ref inventoryAutoTransferEnabledLookup, ref localTransformLookup, ref inventories, maxDistance, maxInventories);
						return;
					}
				}
				GetNearbyChestsByDistance_0024BurstManaged(in position, in collisionWorld, in inventoryAutoTransferEnabledLookup, in localTransformLookup, ref inventories, maxDistance, maxInventories);
			}
		}

		[GenerateTestsForBurstCompatibility]
		public static int GetTotalAmount(in InventoryHandlerShared inventoryHandlerShared, Entity inventory, ObjectID objectID)
		{
			return GetTotalAmount(inventoryHandlerShared.containedObjectsBufferLookup, inventoryHandlerShared.inventoryLookup, inventoryHandlerShared.databaseBankCD, inventory, objectID);
		}

		[GenerateTestsForBurstCompatibility]
		public static int GetTotalAmount(BufferLookup<ContainedObjectsBuffer> containedObjectsBufferLookup, BufferLookup<InventoryBuffer> inventoryBufferLookup, PugDatabase.DatabaseBankCD databaseBankCD, Entity inventoryEntity, ObjectID objectID)
		{
			bool isStackable = PugDatabase.GetEntityObjectInfo(objectID, databaseBankCD.databaseBankBlob).isStackable;
			int num = 0;
			DynamicBuffer<ContainedObjectsBuffer> dynamicBuffer = containedObjectsBufferLookup[inventoryEntity];
			foreach (InventoryBuffer item in inventoryBufferLookup[inventoryEntity])
			{
				for (int i = item.startIndex; i < item.startIndex + item.size; i++)
				{
					if (dynamicBuffer[i].objectID == objectID)
					{
						num = ((!isStackable) ? (num + 1) : (num + dynamicBuffer[i].amount));
					}
				}
			}
			return num;
		}

		[GenerateTestsForBurstCompatibility]
		public static int ConsumeObject(in InventoryHandlerShared inventoryHandlerShared, Entity inventory, ObjectID objectID, int amount)
		{
			int num = amount;
			DynamicBuffer<ContainedObjectsBuffer> dynamicBuffer = inventoryHandlerShared.containedObjectsBufferLookup[inventory];
			for (int i = 0; i < dynamicBuffer.Length; i++)
			{
				if (dynamicBuffer[i].objectID == objectID)
				{
					num -= TryConsume(in inventoryHandlerShared, inventory, i, num, destroy: true, default(float3));
				}
			}
			return amount - num;
		}

		[GenerateTestsForBurstCompatibility]
		public static int ConsumeObjectWithTag(in InventoryHandlerShared inventoryHandlerShared, Entity inventory, ObjectCategoryTag objectTag, int amount)
		{
			int num = amount;
			DynamicBuffer<ContainedObjectsBuffer> dynamicBuffer = inventoryHandlerShared.containedObjectsBufferLookup[inventory];
			for (int i = 0; i < dynamicBuffer.Length; i++)
			{
				Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(dynamicBuffer[i].objectID, inventoryHandlerShared.databaseBankCD.databaseBankBlob);
				if (inventoryHandlerShared.objectCategoryTagsLookup.HasComponent(primaryPrefabEntity) && ObjectCategoryTagsCD.HasTag(inventoryHandlerShared.objectCategoryTagsLookup[primaryPrefabEntity].tagsBitMask, objectTag))
				{
					num -= TryConsume(in inventoryHandlerShared, inventory, i, num, destroy: true, default(float3));
				}
			}
			return amount - num;
		}

		[GenerateTestsForBurstCompatibility]
		public static bool ConsumeEntityAt(in InventoryHandlerShared inventoryHandlerShared, Entity inventory, int index, int amount, bool destroy, float3 position, int variationToInstatiate = -1, float3 direction = default(float3), ObjectID optionalTargetObjectID = ObjectID.None)
		{
			if (optionalTargetObjectID != ObjectID.None && inventoryHandlerShared.containedObjectsBufferLookup[inventory][index].objectID != optionalTargetObjectID)
			{
				return false;
			}
			if (TryConsume(in inventoryHandlerShared, inventory, index, amount, destroy, position, variationToInstatiate, direction) < amount)
			{
				Debug.LogWarning("tried to consume more than existing amount");
				return false;
			}
			return true;
		}

		[GenerateTestsForBurstCompatibility]
		private static int TryConsume(in InventoryHandlerShared inventoryHandlerShared, Entity inventory, int index, int amount, bool destroy, float3 position, int variationToInstatiate = -1, float3 direction = default(float3))
		{
			DynamicBuffer<ContainedObjectsBuffer> dynamicBuffer = inventoryHandlerShared.containedObjectsBufferLookup[inventory];
			ContainedObjectsBuffer containedObjectsBuffer = dynamicBuffer[index];
			ref PugDatabase.EntityObjectInfo entityObjectInfo = ref PugDatabase.GetEntityObjectInfo(containedObjectsBuffer.objectID, inventoryHandlerShared.databaseBankCD.databaseBankBlob);
			Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(containedObjectsBuffer.objectID, inventoryHandlerShared.databaseBankCD.databaseBankBlob);
			int num = math.min(containedObjectsBuffer.amount, amount);
			if (!destroy && (num > 0 || inventoryHandlerShared.cattleLookUp.HasComponent(primaryPrefabEntity)) && inventoryHandlerShared.isFirstTimeFullyPredictingTick)
			{
				Entity primaryPrefabEntity2 = PugDatabase.GetPrimaryPrefabEntity(containedObjectsBuffer.objectID, inventoryHandlerShared.databaseBankCD.databaseBankBlob, containedObjectsBuffer.variation);
				CreateEntity(in inventoryHandlerShared, primaryPrefabEntity2, inventory, position, containedObjectsBuffer, num, direction, variationToInstatiate);
			}
			if (entityObjectInfo.isStackable)
			{
				containedObjectsBuffer.objectData.amount -= num;
			}
			else if (num > 0)
			{
				containedObjectsBuffer.objectData.amount = 0;
			}
			dynamicBuffer[index] = ((containedObjectsBuffer.amount > 0) ? containedObjectsBuffer : default(ContainedObjectsBuffer));
			if (containedObjectsBuffer.amount <= 0)
			{
				ResetLockedObject(in inventoryHandlerShared, inventory, index);
			}
			return num;
		}

		[GenerateTestsForBurstCompatibility]
		public static void CreateEntityWithoutConsume(in InventoryHandlerShared inventoryHandlerShared, Entity inventory, int index, int amount, float3 position, int variationToInstatiate = -1, float3 direction = default(float3), ObjectID optionalTargetObjectID = ObjectID.None)
		{
			if (!inventoryHandlerShared.isFirstTimeFullyPredictingTick)
			{
				return;
			}
			ContainedObjectsBuffer containedObject = inventoryHandlerShared.containedObjectsBufferLookup[inventory][index];
			if (optionalTargetObjectID == ObjectID.None || containedObject.objectID == optionalTargetObjectID)
			{
				int num = math.min(containedObject.amount, amount);
				Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(containedObject.objectID, inventoryHandlerShared.databaseBankCD.databaseBankBlob, containedObject.variation);
				if (num > 0 || inventoryHandlerShared.cattleLookUp.HasComponent(primaryPrefabEntity))
				{
					CreateEntity(in inventoryHandlerShared, primaryPrefabEntity, inventory, position, containedObject, num, direction, variationToInstatiate);
				}
			}
		}

		private static void CreateEntity(in InventoryHandlerShared inventoryHandlerShared, Entity prefabEntity, Entity inventory, float3 position, ContainedObjectsBuffer containedObject, int amountToConsume, float3 direction, int variationToInstatiate)
		{
			Entity entity = EntityUtility.CreateEntity(inventoryHandlerShared.ecb, containedObject.objectID, amountToConsume, inventoryHandlerShared.databaseBankCD.databaseBankBlob, (variationToInstatiate > -1) ? variationToInstatiate : 0);
			inventoryHandlerShared.ecb.SetComponent(entity, LocalTransform.FromPosition(position));
			if (inventoryHandlerShared.randomLookup.HasComponent(inventory))
			{
				ref RandomCD valueRW = ref inventoryHandlerShared.randomLookup.GetRefRW(inventory).ValueRW;
				inventoryHandlerShared.ecb.SetComponent(entity, new RandomCD
				{
					Value = PugRandom.InheritRngFromEntity(ref valueRW.Value)
				});
			}
			if (inventoryHandlerShared.ownerLookup.HasComponent(prefabEntity))
			{
				inventoryHandlerShared.ecb.SetComponent(entity, new OwnerReferenceCD
				{
					owner = inventory
				});
			}
			if (inventoryHandlerShared.isExplosiveLookup.TryGetComponent(prefabEntity, out var componentData))
			{
				if (componentData.bombInheritsFaction && inventoryHandlerShared.factionLookup.HasComponent(prefabEntity))
				{
					EntityUtility.InheritFaction(inventoryHandlerShared.ecb, inventory, entity, inventoryHandlerShared.factionLookup);
				}
				if (inventoryHandlerShared.summarizedConditionsBufferLookup.HasComponent(prefabEntity))
				{
					EntityUtility.InheritConditionsForBomb(inventoryHandlerShared.ecb, inventory, entity, inventoryHandlerShared.summarizedConditionsBufferLookup);
				}
			}
			inventoryHandlerShared.ecb.AddComponent<DestroyEntityIfPlacementNotValidCD>(entity);
			if (math.any(direction != 0f))
			{
				inventoryHandlerShared.ecb.SetComponent(entity, new DirectionCD
				{
					direction = direction
				});
				if (inventoryHandlerShared.animationOrientationLookup.TryGetComponent(prefabEntity, out var componentData2))
				{
					componentData2.SetFacingDirectionFromVector(direction);
					inventoryHandlerShared.ecb.SetComponent(entity, componentData2);
				}
			}
			EntityUtility.ApplyAuxDataToEntity(inventoryHandlerShared.ecb, entity, containedObject.auxDataIndex, inventoryHandlerShared.inventoryAuxDataSystemDataCD.GetAccessor(), inventoryHandlerShared.nameLookup, inventoryHandlerShared.mealsEatenLookup, inventoryHandlerShared.breedToggleLookup);
		}

		[GenerateTestsForBurstCompatibility]
		public static void CreateObject(in InventoryHandlerShared inventoryHandlerShared, Entity inventory, int index, ObjectID objectID, int amount, float3 position, int variation)
		{
			if (objectID == ObjectID.None || amount <= 0)
			{
				Debug.LogError("Trying to create none or empty");
				return;
			}
			ref PugDatabase.EntityObjectInfo entityObjectInfo = ref PugDatabase.GetEntityObjectInfo(objectID, inventoryHandlerShared.databaseBankCD.databaseBankBlob, variation);
			if (entityObjectInfo.objectID == ObjectID.None)
			{
				Debug.LogError("Trying to create an item that does not exist in pugdatabase");
				return;
			}
			if (!entityObjectInfo.isStackable)
			{
				amount *= entityObjectInfo.initialAmount;
			}
			while (amount >= 0)
			{
				int num = TryFindSlotToAddTo(in inventoryHandlerShared, objectID, inventory, index, -1, variation);
				int num2 = (entityObjectInfo.isStackable ? math.min(amount, 9999) : entityObjectInfo.initialAmount);
				if (num == -1)
				{
					if (inventoryHandlerShared.isFirstTimeFullyPredictingTick)
					{
						EntityUtility.DropNewEntity(inventoryHandlerShared.ecb, new ContainedObjectsBuffer
						{
							objectData = new ObjectDataCD
							{
								objectID = objectID,
								amount = num2,
								variation = variation
							}
						}, position, inventoryHandlerShared.databaseBankCD.databaseBankBlob);
					}
				}
				else
				{
					DynamicBuffer<ContainedObjectsBuffer> dynamicBuffer = inventoryHandlerShared.containedObjectsBufferLookup[inventory];
					ContainedObjectsBuffer value = dynamicBuffer[num];
					if (entityObjectInfo.isStackable)
					{
						num2 = math.min(num2, 9999 - value.amount);
					}
					value.objectData.objectID = objectID;
					value.objectData.amount += num2;
					value.objectData.variation = variation;
					dynamicBuffer[num] = value;
				}
				amount -= num2;
				if (amount <= 0)
				{
					break;
				}
			}
		}

		[GenerateTestsForBurstCompatibility]
		public static void AddAmount(in InventoryHandlerShared inventoryHandlerShared, Entity inventory, int index, ObjectID objectID, int amount)
		{
			DynamicBuffer<ContainedObjectsBuffer> dynamicBuffer = inventoryHandlerShared.containedObjectsBufferLookup[inventory];
			ContainedObjectsBuffer value = dynamicBuffer[index];
			if (value.objectID == objectID)
			{
				value.objectData.amount += amount;
				dynamicBuffer[index] = value;
			}
		}

		[GenerateTestsForBurstCompatibility]
		public static void SetAmount(in InventoryHandlerShared inventoryHandlerShared, Entity inventory, int index, ObjectID objectID, int amount)
		{
			DynamicBuffer<ContainedObjectsBuffer> dynamicBuffer = inventoryHandlerShared.containedObjectsBufferLookup[inventory];
			ContainedObjectsBuffer value = dynamicBuffer[index];
			if (value.objectID == objectID)
			{
				value.objectData.amount = amount;
				dynamicBuffer[index] = value;
			}
		}

		[GenerateTestsForBurstCompatibility]
		public static void SetVariation(in InventoryHandlerShared inventoryHandlerShared, Entity inventory, int index, ObjectID objectID, int variation)
		{
			DynamicBuffer<ContainedObjectsBuffer> dynamicBuffer = inventoryHandlerShared.containedObjectsBufferLookup[inventory];
			ContainedObjectsBuffer value = dynamicBuffer[index];
			if (value.objectID == objectID)
			{
				value.objectData.variation = variation;
				dynamicBuffer[index] = value;
			}
		}

		public static int GetAuxDataIndex(BufferLookup<ContainedObjectsBuffer> containedObjectsBufferLookup, Entity inventory, int index, ObjectID objectID)
		{
			DynamicBuffer<ContainedObjectsBuffer> dynamicBuffer = containedObjectsBufferLookup[inventory];
			if (index >= dynamicBuffer.Length || dynamicBuffer[index].objectID != objectID)
			{
				return 0;
			}
			return dynamicBuffer[index].auxDataIndex;
		}

		public static void SetAuxDataIndex(in InventoryHandlerShared inventoryHandlerShared, Entity inventory, int index, ObjectID objectID, int auxDataIndex)
		{
			DynamicBuffer<ContainedObjectsBuffer> dynamicBuffer = inventoryHandlerShared.containedObjectsBufferLookup[inventory];
			if (index < dynamicBuffer.Length && dynamicBuffer[index].objectID == objectID)
			{
				ContainedObjectsBuffer value = dynamicBuffer[index];
				value.auxDataIndex = auxDataIndex;
				dynamicBuffer[index] = value;
			}
		}

		[GenerateTestsForBurstCompatibility]
		public static int TryFindSlotToAddTo(in InventoryHandlerShared inventoryHandlerShared, ObjectID objectID, Entity inventoryEntity, int indexHint, int endIndex, int variation, bool isQuickStacking = false)
		{
			DynamicBuffer<InventoryBuffer> inventoryBuffer = inventoryHandlerShared.inventoryLookup[inventoryEntity];
			DynamicBuffer<InventorySlotRequirementBuffer> inventorySlotsRequirements = inventoryHandlerShared.inventorySlotRequirementBufferLookup[inventoryEntity];
			bool flag = inventoryHandlerShared.playerGhostLookup.HasComponent(inventoryEntity);
			bool flag2 = isQuickStacking;
			DynamicBuffer<ContainedObjectsBuffer> dynamicBuffer = inventoryHandlerShared.containedObjectsBufferLookup[inventoryEntity];
			DynamicBuffer<LockedObjectsBuffer> bufferData;
			bool flag3 = inventoryHandlerShared.lockedObjectsBufferLookup.TryGetBuffer(inventoryEntity, out bufferData);
			bool flag4 = !CheckIfCanOnlyContainOneItemPerSlot(inventoryBuffer);
			int num = -1;
			int num2 = -1;
			for (int i = 0; i < inventoryBuffer.Length; i++)
			{
				InventoryBuffer inventoryBuffer2 = inventoryBuffer[i];
				bool flag5 = false;
				bool flag6 = PugDatabase.GetEntityObjectInfo(objectID, inventoryHandlerShared.databaseBankCD.databaseBankBlob).isStackable && !CheckIfCantAddObjectsToInventory(inventoryBuffer, indexHint);
				int num3 = endIndex;
				int size = inventoryBuffer2.size;
				int num4;
				if (num3 == -1 && indexHint >= size)
				{
					num4 = indexHint;
					num3 = indexHint + 1;
				}
				else if (num3 <= size)
				{
					num4 = inventoryBuffer2.startIndex;
					num3 = inventoryBuffer2.startIndex + size;
				}
				else
				{
					num4 = math.max(inventoryBuffer2.startIndex, indexHint);
				}
				Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(objectID, inventoryHandlerShared.databaseBankCD.databaseBankBlob, variation);
				ObjectCategoryTagsCD objectTagCD = (inventoryHandlerShared.objectCategoryTagsLookup.HasComponent(primaryPrefabEntity) ? inventoryHandlerShared.objectCategoryTagsLookup[primaryPrefabEntity] : default(ObjectCategoryTagsCD));
				for (int j = num4; j < num3; j++)
				{
					if (flag && isQuickStacking)
					{
						flag2 = (i != 0 || j >= 10) && isQuickStacking;
					}
					if ((isQuickStacking && flag3 && bufferData[j].Value) || !ObjectIsValidToPutInInventory(inventorySlotsRequirements, objectTagCD, objectID, inventoryBuffer, inventoryHandlerShared.overrideAlwaysAllowToBeTrashedLookup, out var indexFulfillingRequirements, inventoryHandlerShared.databaseBankCD, j))
					{
						continue;
					}
					ObjectID objectID2 = dynamicBuffer[j].objectData.objectID;
					bool flag7 = flag4 && flag6 && objectID2 == objectID && dynamicBuffer[j].objectData.variation == variation && dynamicBuffer[j].objectData.amount < 9999;
					if ((num == -1 && objectID2 == ObjectID.None) || (!flag5 && flag7))
					{
						num = j;
						flag5 = flag7;
					}
					if (objectID2 == ObjectID.None && indexFulfillingRequirements > -1 && num2 == -1)
					{
						num2 = indexFulfillingRequirements;
					}
					if (indexHint == j && (objectID2 == ObjectID.None || flag7))
					{
						if (!flag2 || indexFulfillingRequirements != -1)
						{
							return j;
						}
						num = j;
					}
					else if (indexHint < j && flag7)
					{
						if (!flag2 || indexFulfillingRequirements != -1)
						{
							return j;
						}
						num = j;
					}
				}
			}
			if (num2 == -1)
			{
				return num;
			}
			return num2;
		}

		public static bool TryMoveAll(in InventoryHandlerShared inventoryHandlerShared, Entity inventoryFrom, int indexFrom, Entity inventoryTo, int indexToHint, int endIndex, int amount = int.MaxValue, bool isQuickStacking = false)
		{
			DynamicBuffer<ContainedObjectsBuffer> dynamicBuffer = inventoryHandlerShared.containedObjectsBufferLookup[inventoryFrom];
			int num = 0;
			int amount2;
			bool result;
			do
			{
				amount2 = dynamicBuffer[indexFrom].objectData.amount;
				result = TryMove(in inventoryHandlerShared, inventoryFrom, indexFrom, inventoryTo, indexToHint, endIndex, amount, destroyExisting: false, isQuickStacking);
				num += amount2 - dynamicBuffer[indexFrom].objectData.amount;
			}
			while (dynamicBuffer[indexFrom].objectData.amount != amount2 && num < amount);
			return result;
		}

		[GenerateTestsForBurstCompatibility]
		public static bool TryMove(in InventoryHandlerShared inventoryHandlerShared, Entity inventoryFrom, int indexFrom, Entity inventoryTo, int indexToHint, int endIndex, int amount = int.MaxValue, bool destroyExisting = false, bool isQuickStacking = false)
		{
			DynamicBuffer<ContainedObjectsBuffer> dynamicBuffer = inventoryHandlerShared.containedObjectsBufferLookup[inventoryFrom];
			ContainedObjectsBuffer value = dynamicBuffer[indexFrom];
			if (value.objectID == ObjectID.None)
			{
				return true;
			}
			int num = TryFindSlotToAddTo(in inventoryHandlerShared, value.objectID, inventoryTo, indexToHint, endIndex, value.variation, isQuickStacking);
			if (num == -1)
			{
				return false;
			}
			if (inventoryFrom == inventoryTo && indexFrom == num)
			{
				return true;
			}
			ContainedObjectsBuffer value2 = inventoryHandlerShared.containedObjectsBufferLookup[inventoryTo][num];
			if (destroyExisting && value2.objectID != ObjectID.None)
			{
				DestroyInventoryObject(in inventoryHandlerShared, inventoryTo, value.objectID, num);
				value2 = inventoryHandlerShared.containedObjectsBufferLookup[inventoryTo][num];
			}
			DynamicBuffer<ContainedObjectsBuffer> dynamicBuffer2 = inventoryHandlerShared.containedObjectsBufferLookup[inventoryTo];
			amount = GetAmountToMoveToInventory(in inventoryHandlerShared, inventoryTo, value.objectData, value2.objectData, amount);
			value.objectData.amount -= amount;
			value2.objectData.objectID = value.objectData.objectID;
			value2.objectData.variation = value.objectData.variation;
			value2.objectData.amount += amount;
			value2.auxDataIndex = value.auxDataIndex;
			if (value.objectData.amount == 0)
			{
				value = default(ContainedObjectsBuffer);
			}
			bool indexToWasEmpty = dynamicBuffer2[num].objectID == ObjectID.None;
			bool indexFromBecameEmpty = value.objectID == ObjectID.None;
			dynamicBuffer[indexFrom] = value;
			dynamicBuffer2[num] = value2;
			UpdateLockedObjects(in inventoryHandlerShared, inventoryFrom, inventoryTo, indexFrom, num, indexToWasEmpty, indexFromBecameEmpty);
			return true;
		}

		[GenerateTestsForBurstCompatibility]
		public static void UpdateLockedObjects(in InventoryHandlerShared inventoryHandlerShared, Entity inventoryFrom, Entity inventoryTo, int indexFrom, int indexTo, bool indexToWasEmpty, bool indexFromBecameEmpty)
		{
			if (inventoryHandlerShared.lockedObjectsBufferLookup.TryGetBuffer(inventoryFrom, out var bufferData))
			{
				if (indexToWasEmpty && indexFromBecameEmpty && inventoryHandlerShared.lockedObjectsBufferLookup.TryGetBuffer(inventoryTo, out var bufferData2))
				{
					LockedObjectsBuffer value = bufferData2[indexTo];
					value.Value = bufferData[indexFrom].Value;
					bufferData2[indexTo] = value;
				}
				if (indexFromBecameEmpty)
				{
					bufferData[indexFrom] = default(LockedObjectsBuffer);
				}
			}
		}

		[GenerateTestsForBurstCompatibility]
		public static void Swap(in InventoryHandlerShared inventoryHandlerShared, Entity inventory1, Entity inventory2, int index1, int index2)
		{
			DynamicBuffer<ContainedObjectsBuffer> dynamicBuffer = inventoryHandlerShared.containedObjectsBufferLookup[inventory1];
			DynamicBuffer<ContainedObjectsBuffer> dynamicBuffer2 = inventoryHandlerShared.containedObjectsBufferLookup[inventory2];
			ContainedObjectsBuffer containedObjectsBuffer = dynamicBuffer2[index2];
			ContainedObjectsBuffer containedObjectsBuffer2 = dynamicBuffer[index1];
			ContainedObjectsBuffer containedObjectsBuffer3 = (dynamicBuffer[index1] = containedObjectsBuffer);
			containedObjectsBuffer3 = (dynamicBuffer2[index2] = containedObjectsBuffer2);
			DynamicBuffer<LockedObjectsBuffer> bufferData;
			bool num = inventoryHandlerShared.lockedObjectsBufferLookup.TryGetBuffer(inventory1, out bufferData);
			DynamicBuffer<LockedObjectsBuffer> bufferData2;
			bool flag = inventoryHandlerShared.lockedObjectsBufferLookup.TryGetBuffer(inventory2, out bufferData2);
			bool value = flag && bufferData2[index2].Value && dynamicBuffer[index1].objectID != ObjectID.None;
			bool value2 = num && bufferData[index1].Value && dynamicBuffer2[index2].objectID != ObjectID.None;
			if (num)
			{
				LockedObjectsBuffer value3 = bufferData[index1];
				value3.Value = value;
				bufferData[index1] = value3;
			}
			if (flag)
			{
				LockedObjectsBuffer value4 = bufferData2[index2];
				value4.Value = value2;
				bufferData2[index2] = value4;
			}
		}

		[GenerateTestsForBurstCompatibility]
		public static void DropItem(in InventoryHandlerShared inventoryHandlerShared, Entity inventory, int index, int amount, float3 position, Entity blockPickupFor = default(Entity), Entity pullTowardsEntity = default(Entity), bool ignoreRayChecksForPickup = false)
		{
			DynamicBuffer<ContainedObjectsBuffer> dynamicBuffer = inventoryHandlerShared.containedObjectsBufferLookup[inventory];
			ContainedObjectsBuffer value = dynamicBuffer[index];
			if (value.objectID == ObjectID.None)
			{
				return;
			}
			int amountToMoveFromInventory = GetAmountToMoveFromInventory(in inventoryHandlerShared, inventory, value.objectData, amount);
			value.objectData.amount -= amountToMoveFromInventory;
			if (inventoryHandlerShared.isFirstTimeFullyPredictingTick)
			{
				Entity e = EntityUtility.DropNewEntity(inventoryHandlerShared.ecb, new ContainedObjectsBuffer
				{
					objectData = new ObjectDataCD
					{
						objectID = value.objectID,
						amount = amountToMoveFromInventory,
						variation = value.variation
					},
					auxDataIndex = value.auxDataIndex
				}, position, inventoryHandlerShared.databaseBankCD.databaseBankBlob, pullTowardsEntity, ignoreRayChecksForPickup);
				if (blockPickupFor != Entity.Null)
				{
					inventoryHandlerShared.ecb.SetComponent(e, new PickUpItemCD
					{
						state = PickUpItemState.BlockPickupUntilReEnterStart,
						targetEntity = blockPickupFor
					});
				}
			}
			if (value.amount == 0)
			{
				value = default(ContainedObjectsBuffer);
				if (inventoryHandlerShared.lockedObjectsBufferLookup.TryGetBuffer(inventory, out var bufferData))
				{
					bufferData[index] = default(LockedObjectsBuffer);
				}
			}
			dynamicBuffer[index] = value;
		}

		public static void SplitItemAndDropFromMover(Entity inventoryEntity, DynamicBuffer<MoversWithSharedStateBuffer> moversWithSharedStateBuffers, ComponentLookup<MoverCD> moverLookup, int index, Vector3 position, int splits, in MoverCD currentMover, BufferLookup<ContainedObjectsBuffer> containedObjectsBufferLookup, EntityCommandBuffer ecb, PugDatabase.DatabaseBankCD databaseBankCD, out int moverIncrement)
		{
			moverIncrement = 1;
			if (!containedObjectsBufferLookup.TryGetBuffer(inventoryEntity, out var bufferData))
			{
				return;
			}
			ContainedObjectsBuffer value = bufferData[index];
			if (value.objectID != ObjectID.None && value.objectData.amount > 1 && PugDatabase.GetEntityObjectInfo(value.objectID, databaseBankCD.databaseBankBlob).isStackable)
			{
				int num = value.objectData.amount / splits;
				int remainder = (moverIncrement = value.objectData.amount % splits);
				if (remainder > 0)
				{
					remainder--;
				}
				value.objectData.amount -= num * (splits - 1) + remainder;
				bufferData[index] = value;
				ObjectID objectID = value.objectData.objectID;
				int variation = value.objectData.variation;
				int indexInOrchestrator = currentMover.indexInOrchestrator;
				for (int i = indexInOrchestrator + 1; i < moversWithSharedStateBuffers.Length; i++)
				{
					MoverCD moverCD = moverLookup[moversWithSharedStateBuffers[i].moverEntity];
					SplitIntoItem(objectID, variation, num, ref remainder, position, in moverCD, ecb, databaseBankCD);
				}
				for (int j = 0; j < indexInOrchestrator; j++)
				{
					MoverCD moverCD2 = moverLookup[moversWithSharedStateBuffers[j].moverEntity];
					SplitIntoItem(objectID, variation, num, ref remainder, position, in moverCD2, ecb, databaseBankCD);
				}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void SplitIntoItem(ObjectID objectID, int variation, int equalSplitAmount, ref int remainder, float3 position, in MoverCD moverCD, EntityCommandBuffer ecb, PugDatabase.DatabaseBankCD databaseBankCD)
		{
			int amount = equalSplitAmount + ((remainder > 0) ? 1 : 0);
			remainder--;
			Entity e = EntityUtility.DropNewEntity(ecb, new ContainedObjectsBuffer
			{
				objectData = new ObjectDataCD
				{
					objectID = objectID,
					amount = amount,
					variation = variation
				}
			}, position, databaseBankCD.databaseBankBlob);
			ecb.SetComponent(e, new MoveeBigEntityCD
			{
				moveTimer = MoverUtilities.CalculateMoveTimer(in moverCD, position.ToFloat2()),
				target = moverCD.stop
			});
		}

		[GenerateTestsForBurstCompatibility]
		public static void PickUpObject(in InventoryHandlerShared inventoryHandlerShared, Entity entityToPickUp, int index, Entity inventory, float3 position, NativeParallelHashSet<Entity> pickedUpObjects)
		{
			if (entityToPickUp != Entity.Null && !pickedUpObjects.Contains(entityToPickUp) && inventoryHandlerShared.objectDataLookup.TryGetComponent(entityToPickUp, out var componentData))
			{
				CreateObject(in inventoryHandlerShared, inventory, index, componentData.objectID, 1, position, 0);
				if (inventoryHandlerShared.ghostEffectEventBufferLookup.TryGetBuffer(inventory, out var bufferData))
				{
					RefRW<GhostEffectEventBufferPointerCD> refRW = inventoryHandlerShared.ghostEffectEventBufferPointerLookup.GetRefRW(inventory);
					DynamicBuffer<GhostEffectEventBuffer> buffer = bufferData;
					ref GhostEffectEventBufferPointerCD valueRW = ref refRW.ValueRW;
					GhostEffectEventBuffer item = new GhostEffectEventBuffer
					{
						Tick = inventoryHandlerShared.currentTick,
						value = new EffectEventCD
						{
							position1 = position,
							effectID = EffectID.PickUpCritter
						}
					};
					buffer.AddToRingBuffer(ref valueRW, in item);
				}
				if (inventoryHandlerShared.triggerAnimationOnDeathCD.HasComponent(entityToPickUp))
				{
					inventoryHandlerShared.triggerAnimationOnDeathCD.SetComponentEnabled(entityToPickUp, value: false);
				}
				if (inventoryHandlerShared.entityDestroyedLookup.HasComponent(entityToPickUp))
				{
					inventoryHandlerShared.entityDestroyedLookup.SetComponentEnabled(entityToPickUp, value: true);
				}
				else
				{
					Debug.LogError($"Missing entityDestroyed on entity with id: {entityToPickUp.Index}");
				}
				pickedUpObjects.Add(entityToPickUp);
			}
		}

		[GenerateTestsForBurstCompatibility]
		public static void MoveAmount(in InventoryHandlerShared inventoryHandlerShared, Entity inventoryFrom, int indexFrom, Entity inventoryTo, int indexHint, int endIndex, int amount, bool destroyExisting = false)
		{
			TryMove(in inventoryHandlerShared, inventoryFrom, indexFrom, inventoryTo, indexHint, endIndex, amount, destroyExisting);
		}

		[GenerateTestsForBurstCompatibility]
		public static void MoveOrDrop(in InventoryHandlerShared inventoryHandlerShared, Entity inventoryFrom, int indexFrom, Entity inventoryTo, int indexHint, int endIndex, int amount, float3 position)
		{
			if (!TryMoveAll(in inventoryHandlerShared, inventoryFrom, indexFrom, inventoryTo, indexHint, endIndex, amount))
			{
				DropItem(in inventoryHandlerShared, inventoryFrom, indexFrom, amount, position);
			}
		}

		[GenerateTestsForBurstCompatibility]
		public static void MoveOrDropAllItems(in InventoryHandlerShared inventoryHandlerShared, Entity inventoryFrom, Entity inventoryTo, int indexHint, int endIndex, float3 position)
		{
			int length = inventoryHandlerShared.containedObjectsBufferLookup[inventoryFrom].Length;
			for (int i = 0; i < length; i++)
			{
				if (!TryMoveAll(in inventoryHandlerShared, inventoryFrom, i, inventoryTo, indexHint, endIndex))
				{
					DropItem(in inventoryHandlerShared, inventoryFrom, i, int.MaxValue, position);
				}
			}
		}

		[GenerateTestsForBurstCompatibility]
		public static void MoveOrDropItems(in InventoryHandlerShared inventoryHandlerShared, Entity inventoryFrom, int fromStartIndex, int fromEndIndex, Entity inventoryTo, int toIndexHint, int toEndIndex, float3 position)
		{
			_ = inventoryHandlerShared.containedObjectsBufferLookup[inventoryFrom].Length;
			for (int i = fromStartIndex; i < fromEndIndex; i++)
			{
				if (!TryMoveAll(in inventoryHandlerShared, inventoryFrom, i, inventoryTo, toIndexHint, toEndIndex))
				{
					DropItem(in inventoryHandlerShared, inventoryFrom, i, int.MaxValue, position);
				}
			}
		}

		[GenerateTestsForBurstCompatibility]
		public static void DropAllItems(in InventoryHandlerShared inventoryHandlerShared, Entity inventoryFrom, float3 position, Entity blockImmediatePickFor = default(Entity), bool randomOffset = false)
		{
			int length = inventoryHandlerShared.containedObjectsBufferLookup[inventoryFrom].Length;
			for (int i = 0; i < length; i++)
			{
				float3 position2 = position;
				if (randomOffset && inventoryHandlerShared.randomLookup.HasComponent(inventoryFrom))
				{
					float2 float5 = math.normalizesafe(inventoryHandlerShared.randomLookup.GetRefRW(inventoryFrom).ValueRW.Value.NextFloat2(new float2(-1f, -1f), new float2(-1f, -1f))) * 0.3f;
					position2.x += float5.x;
					position2.z += float5.y;
				}
				DropItem(in inventoryHandlerShared, inventoryFrom, i, int.MaxValue, position2, blockImmediatePickFor);
			}
		}

		[GenerateTestsForBurstCompatibility]
		public static void QuickStack(in InventoryHandlerShared inventoryHandlerShared, Entity inventoryFrom, Entity inventoryTo)
		{
			if (CheckIfCanOnlyContainOneItemPerSlot(inventoryHandlerShared.inventoryLookup[inventoryTo]))
			{
				return;
			}
			DynamicBuffer<LockedObjectsBuffer> bufferData;
			bool flag = inventoryHandlerShared.lockedObjectsBufferLookup.TryGetBuffer(inventoryFrom, out bufferData);
			for (int i = 0; i < inventoryHandlerShared.inventoryLookup[inventoryFrom].Length; i++)
			{
				InventoryBuffer inventoryBuffer = inventoryHandlerShared.inventoryLookup[inventoryFrom][i];
				int size = inventoryBuffer.size;
				DynamicBuffer<ContainedObjectsBuffer> dynamicBuffer = inventoryHandlerShared.containedObjectsBufferLookup[inventoryFrom];
				for (int j = inventoryBuffer.startIndex; j < inventoryBuffer.startIndex + size; j++)
				{
					if (!flag || !bufferData[j].Value)
					{
						ObjectDataCD objectData = dynamicBuffer[j].objectData;
						if (objectData.objectID != ObjectID.None && PugDatabase.GetEntityObjectInfo(objectData.objectID, inventoryHandlerShared.databaseBankCD.databaseBankBlob).isStackable && HasObject(in inventoryHandlerShared, inventoryTo, objectData.objectID, 1, objectData.variation))
						{
							TryMoveAll(in inventoryHandlerShared, inventoryFrom, j, inventoryTo, -1, -1, int.MaxValue, isQuickStacking: true);
						}
					}
				}
			}
		}

		[GenerateTestsForBurstCompatibility]
		public static void Sort(in InventoryHandlerShared inventoryHandlerShared, Entity inventory, bool isPlayerInventory)
		{
			QuickStack(in inventoryHandlerShared, inventory, inventory);
			ObjectDataCDComparer objectDataCDComparer = new ObjectDataCDComparer(inventoryHandlerShared.databaseBankCD.databaseBankBlob);
			DynamicBuffer<LockedObjectsBuffer> bufferData;
			bool flag = inventoryHandlerShared.lockedObjectsBufferLookup.TryGetBuffer(inventory, out bufferData);
			for (int i = 0; i < inventoryHandlerShared.inventoryLookup[inventory].Length; i++)
			{
				InventoryBuffer inventoryBuffer = inventoryHandlerShared.inventoryLookup[inventory][i];
				int num = inventoryBuffer.startIndex + inventoryBuffer.size;
				DynamicBuffer<ContainedObjectsBuffer> dynamicBuffer = inventoryHandlerShared.containedObjectsBufferLookup[inventory];
				for (int j = inventoryBuffer.startIndex + ((isPlayerInventory && i == 0) ? 10 : 0); j < num; j++)
				{
					if (flag && bufferData[j].Value)
					{
						continue;
					}
					ContainedObjectsBuffer value = dynamicBuffer[j];
					for (int k = j + 1; k < num; k++)
					{
						if ((!flag || !bufferData[k].Value) && objectDataCDComparer.Compare(value.objectData, dynamicBuffer[k].objectData) > 0)
						{
							dynamicBuffer[j] = dynamicBuffer[k];
							dynamicBuffer[k] = value;
							value = dynamicBuffer[j];
						}
					}
				}
			}
		}

		[GenerateTestsForBurstCompatibility]
		public static void ToggleLock(in InventoryHandlerShared inventoryHandlerShared, Entity inventory, int index)
		{
			if (inventoryHandlerShared.lockedObjectsBufferLookup.TryGetBuffer(inventory, out var bufferData))
			{
				LockedObjectsBuffer value = bufferData[index];
				value.Value = !value.Value;
				bufferData[index] = value;
			}
		}

		[GenerateTestsForBurstCompatibility]
		public static void MoveInventory(in InventoryHandlerShared inventoryHandlerShared, Entity inventoryFrom, Entity inventoryTo, int fromStartIndex = 0, int amountOfSlots = -1, int toStartIndex = 0)
		{
			DynamicBuffer<ContainedObjectsBuffer> dynamicBuffer = inventoryHandlerShared.containedObjectsBufferLookup[inventoryFrom];
			DynamicBuffer<ContainedObjectsBuffer> dynamicBuffer2 = inventoryHandlerShared.containedObjectsBufferLookup[inventoryTo];
			int x = dynamicBuffer.Length;
			if (inventoryHandlerShared.inventoryLookup.TryGetBuffer(inventoryTo, out var bufferData))
			{
				for (int i = 0; i < bufferData.Length; i++)
				{
					InventoryBuffer value = bufferData[i];
					value.extraSize = value.maxSize - value.sizeX * value.sizeY;
					bufferData[i] = value;
				}
			}
			if (amountOfSlots >= 0)
			{
				x = fromStartIndex + amountOfSlots;
			}
			toStartIndex = math.max(0, toStartIndex);
			int num = fromStartIndex;
			int num2 = toStartIndex;
			while (num < math.min(x, dynamicBuffer.Length))
			{
				if (num2 >= dynamicBuffer2.Length)
				{
					dynamicBuffer2.Add(dynamicBuffer[num]);
					dynamicBuffer[num] = default(ContainedObjectsBuffer);
					ResetLockedObject(in inventoryHandlerShared, inventoryFrom, num);
				}
				else if (dynamicBuffer2[num2].objectData.objectID == ObjectID.None)
				{
					dynamicBuffer2[num2] = dynamicBuffer[num];
					dynamicBuffer[num] = default(ContainedObjectsBuffer);
					ResetLockedObject(in inventoryHandlerShared, inventoryFrom, num);
				}
				num++;
				num2++;
			}
		}

		[GenerateTestsForBurstCompatibility]
		public static void DestroyInventoryObject(in InventoryHandlerShared inventoryHandlerShared, Entity inventoryEntity, ObjectID objectID, int index)
		{
			DynamicBuffer<ContainedObjectsBuffer> dynamicBuffer = inventoryHandlerShared.containedObjectsBufferLookup[inventoryEntity];
			if (dynamicBuffer[index].objectData.objectID == objectID)
			{
				dynamicBuffer[index] = new ContainedObjectsBuffer
				{
					objectData = default(ObjectDataCD)
				};
				ResetLockedObject(in inventoryHandlerShared, inventoryEntity, index);
			}
		}

		[GenerateTestsForBurstCompatibility]
		public static void DestroyInventoryObject(in InventoryHandlerShared inventoryHandlerShared, Entity inventoryEntity, int index)
		{
			DynamicBuffer<ContainedObjectsBuffer> dynamicBuffer = inventoryHandlerShared.containedObjectsBufferLookup[inventoryEntity];
			dynamicBuffer[index] = new ContainedObjectsBuffer
			{
				objectData = default(ObjectDataCD)
			};
			ResetLockedObject(in inventoryHandlerShared, inventoryEntity, index);
		}

		private static void ResetLockedObject(in InventoryHandlerShared inventoryHandlerShared, Entity inventoryEntity, int index)
		{
			if (inventoryHandlerShared.lockedObjectsBufferLookup.TryGetBuffer(inventoryEntity, out var bufferData))
			{
				bufferData[index] = default(LockedObjectsBuffer);
			}
		}

		public static void SellAll(in InventoryHandlerShared inventoryHandlerShared, int startIndex, int size, float3 position, Entity inventoryEntity, Entity sellToInventory = default(Entity))
		{
			bool flag = false;
			int num = startIndex + size;
			for (int i = startIndex; i < num; i++)
			{
				if (TrySell(in inventoryHandlerShared, i, position, inventoryEntity, sellToInventory))
				{
					flag = true;
				}
			}
			if (flag)
			{
				DynamicBuffer<GhostEffectEventBuffer> buffer = inventoryHandlerShared.ghostEffectEventBufferLookup[inventoryEntity];
				ref GhostEffectEventBufferPointerCD valueRW = ref inventoryHandlerShared.ghostEffectEventBufferPointerLookup.GetRefRW(inventoryEntity).ValueRW;
				GhostEffectEventBuffer item = new GhostEffectEventBuffer
				{
					Tick = inventoryHandlerShared.currentTick,
					value = EffectEventExtensions.CreateSingleAudioSFX(localOnlyEffect: true, SfxID.coin, inventoryEntity, 0.9f, 1.2f, 0.1f, useSpatialSound: false)
				};
				buffer.AddToRingBuffer(ref valueRW, in item);
			}
		}

		private static bool TrySell(in InventoryHandlerShared inventoryHandlerShared, int index, float3 position, Entity inventoryEntity, Entity sellToInventory)
		{
			ContainedObjectsBuffer containedObjectsBuffer = inventoryHandlerShared.containedObjectsBufferLookup[inventoryEntity][index];
			if (containedObjectsBuffer.objectID == ObjectID.None)
			{
				return false;
			}
			ref PugDatabase.EntityObjectInfo entityObjectInfo = ref PugDatabase.GetEntityObjectInfo(containedObjectsBuffer.objectID, inventoryHandlerShared.databaseBankCD.databaseBankBlob, containedObjectsBuffer.variation);
			Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(containedObjectsBuffer.objectID, inventoryHandlerShared.databaseBankCD.databaseBankBlob, containedObjectsBuffer.variation);
			if (inventoryHandlerShared.cantBeSoldLookup.HasComponent(primaryPrefabEntity) || entityObjectInfo.rarity == Rarity.Legendary)
			{
				return false;
			}
			int coinValue = GetCoinValue(in inventoryHandlerShared, containedObjectsBuffer.objectData, buy: false);
			if (coinValue > 0)
			{
				SellObject(in inventoryHandlerShared, inventoryEntity, index, sellToInventory, -1, -1, containedObjectsBuffer.objectID, containedObjectsBuffer.amount, coinValue, position);
			}
			else
			{
				DestroyInventoryObject(in inventoryHandlerShared, inventoryEntity, containedObjectsBuffer.objectID, index);
			}
			return true;
		}

		public static int GetCoinValue(in InventoryHandlerShared inventoryHandlerShared, ObjectDataCD objectData, bool buy)
		{
			return GetCoinValue(inventoryHandlerShared.databaseBankCD, inventoryHandlerShared.upgradeCostsTableCD, inventoryHandlerShared.cantBeSoldLookup, inventoryHandlerShared.cookedFoodLookup, inventoryHandlerShared.objectCategoryTagsLookup, inventoryHandlerShared.levelLookup, objectData, buy);
		}

		public static int GetCoinValue(PugDatabase.DatabaseBankCD databaseBankCD, UpgradeCostsTableCD upgradeCostsTableCD, ComponentLookup<CantBeSoldCD> cantBeSoldLookup, ComponentLookup<CookedFoodCD> cookedFoodLookup, ComponentLookup<ObjectCategoryTagsCD> objectCategoryTagsLookup, ComponentLookup<LevelCD> levelLookup, ObjectDataCD objectData, bool buy)
		{
			ObjectID objectID = objectData.objectID;
			if (objectID == ObjectID.None)
			{
				return 0;
			}
			ref PugDatabase.EntityObjectInfo entityObjectInfo = ref PugDatabase.GetEntityObjectInfo(objectID, databaseBankCD.databaseBankBlob, objectData.variation);
			Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(objectID, databaseBankCD.databaseBankBlob, objectData.variation);
			if (entityObjectInfo.objectID == ObjectID.None || cantBeSoldLookup.HasComponent(primaryPrefabEntity) || entityObjectInfo.rarity == Rarity.Legendary)
			{
				return 0;
			}
			int num = entityObjectInfo.sellValue;
			if (num < 0)
			{
				num = GetRaritySellValue(entityObjectInfo.rarity);
				if (cookedFoodLookup.HasComponent(primaryPrefabEntity))
				{
					ObjectID primaryIngredientFromVariation = CookedFoodCD.GetPrimaryIngredientFromVariation(objectData.variation);
					ObjectID secondaryIngredientFromVariation = CookedFoodCD.GetSecondaryIngredientFromVariation(objectData.variation);
					num = GetCoinValue(databaseBankCD, upgradeCostsTableCD, cantBeSoldLookup, cookedFoodLookup, objectCategoryTagsLookup, levelLookup, new ObjectDataCD
					{
						objectID = primaryIngredientFromVariation,
						amount = 1
					}, buy) + GetCoinValue(databaseBankCD, upgradeCostsTableCD, cantBeSoldLookup, cookedFoodLookup, objectCategoryTagsLookup, levelLookup, new ObjectDataCD
					{
						objectID = secondaryIngredientFromVariation,
						amount = 1
					}, buy);
				}
				else
				{
					int num2 = 0;
					ref BlobArray<ObjectWithAmount> requiredObjectsToCraft = ref entityObjectInfo.requiredObjectsToCraft;
					for (int i = 0; i < requiredObjectsToCraft.Length; i++)
					{
						ref PugDatabase.EntityObjectInfo entityObjectInfo2 = ref PugDatabase.GetEntityObjectInfo(requiredObjectsToCraft[i].objectID, databaseBankCD.databaseBankBlob);
						if (entityObjectInfo2.sellValue != 0)
						{
							num2 += GetRaritySellValue(entityObjectInfo2.rarity) * requiredObjectsToCraft[i].amount;
						}
					}
					if (num2 > 0)
					{
						num = (int)math.round(math.max(1f, (float)num * 0.3f) + (float)num2);
					}
					if (objectData.variation > 0 && objectCategoryTagsLookup.TryGetComponent(primaryPrefabEntity, out var componentData) && ObjectCategoryTagsCD.HasTag(componentData.tagsBitMask, ObjectCategoryTag.CanBeUpgraded))
					{
						int level = levelLookup[primaryPrefabEntity].level;
						int num3 = 0;
						for (int j = level + 1; j <= objectData.variation; j++)
						{
							ref BlobArray<UpgradeCostBlob> upgradeCost = ref upgradeCostsTableCD.GetUpgradeCost(j);
							for (int k = 0; k < upgradeCost.Length; k++)
							{
								ref PugDatabase.EntityObjectInfo entityObjectInfo3 = ref PugDatabase.GetEntityObjectInfo(upgradeCost[k].item, databaseBankCD.databaseBankBlob);
								if (entityObjectInfo3.objectID == ObjectID.AncientCoin)
								{
									num3 += upgradeCost[k].amount;
								}
								else if (entityObjectInfo3.sellValue != 0)
								{
									num3 += GetRaritySellValue(entityObjectInfo3.rarity) * upgradeCost[k].amount;
								}
							}
						}
						num += (int)math.round((float)num3 * 0.25f);
					}
				}
				float num4 = Unity.Mathematics.Random.CreateFromIndex((uint)objectID).NextFloat(-0.1f, 0.1f);
				num = math.max(1, num + (int)math.round((float)num * num4));
			}
			if (buy)
			{
				num = math.max(1, num);
				float buyValueMultiplier = entityObjectInfo.buyValueMultiplier;
				return (int)math.round((float)num * 5f * buyValueMultiplier);
			}
			return num * ((!entityObjectInfo.isStackable) ? 1 : objectData.amount);
		}

		private static int GetRaritySellValue(Rarity rarity)
		{
			return 1 + math.max(0, (int)rarity) * 5;
		}

		[GenerateTestsForBurstCompatibility]
		public static void SellObject(in InventoryHandlerShared inventoryHandlerShared, Entity inventorySeller, int indexSell, Entity inventoryBuyer, int indexBuy, int endIndex, ObjectID objectID, int amount, int coinAmount, float3 position)
		{
			DynamicBuffer<ContainedObjectsBuffer> dynamicBuffer = inventoryHandlerShared.containedObjectsBufferLookup[inventorySeller];
			bool isStackable = PugDatabase.GetEntityObjectInfo(objectID, inventoryHandlerShared.databaseBankCD.databaseBankBlob).isStackable;
			int num = 0;
			if (inventoryBuyer != Entity.Null && inventoryBuyer != inventorySeller)
			{
				num = GetTotalAmount(in inventoryHandlerShared, inventoryBuyer, ObjectID.AncientCoin) - coinAmount;
			}
			if (dynamicBuffer[indexSell].objectData.objectID == objectID && (!isStackable || dynamicBuffer[indexSell].objectData.amount >= amount) && num >= 0)
			{
				if (inventoryBuyer != Entity.Null)
				{
					MoveOrDrop(in inventoryHandlerShared, inventorySeller, indexSell, inventoryBuyer, indexBuy, endIndex, amount, position);
					ConsumeObject(in inventoryHandlerShared, inventoryBuyer, ObjectID.AncientCoin, coinAmount);
				}
				else
				{
					TryConsume(in inventoryHandlerShared, inventorySeller, indexSell, amount, destroy: true, position);
					CreateObject(in inventoryHandlerShared, inventorySeller, -1, ObjectID.AncientCoin, coinAmount, position, 0);
				}
			}
		}

		[GenerateTestsForBurstCompatibility]
		public static void SalvageAll(in InventoryHandlerShared inventoryHandlerShared, Entity inventorySalvage, Entity inventoryToGetScrapParts, float3 position, int indexStart, int size)
		{
			DynamicBuffer<ContainedObjectsBuffer> dynamicBuffer = inventoryHandlerShared.containedObjectsBufferLookup[inventorySalvage];
			NativeHashMap<int, int> materialsToPrint = new NativeHashMap<int, int>(4, Allocator.Temp);
			bool flag = false;
			int totalScrapParts = 0;
			int num = math.min(indexStart + size, dynamicBuffer.Length);
			for (int i = indexStart; i < num; i++)
			{
				flag |= TrySalvageObject(in inventoryHandlerShared, inventorySalvage, i, inventoryToGetScrapParts, position, ref totalScrapParts, materialsToPrint);
			}
			if (!flag)
			{
				materialsToPrint.Dispose();
				return;
			}
			CreateObject(in inventoryHandlerShared, inventoryToGetScrapParts, 0, ObjectID.ScrapPart, totalScrapParts, position, 0);
			materialsToPrint.Add(1648, totalScrapParts);
			using (NativeHashMap<int, int>.Enumerator enumerator = materialsToPrint.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (inventoryHandlerShared.ghostEffectEventBufferLookup.TryGetBuffer(inventoryToGetScrapParts, out var bufferData))
					{
						RefRW<GhostEffectEventBufferPointerCD> refRW = inventoryHandlerShared.ghostEffectEventBufferPointerLookup.GetRefRW(inventoryToGetScrapParts);
						DynamicBuffer<GhostEffectEventBuffer> buffer = bufferData;
						ref GhostEffectEventBufferPointerCD valueRW = ref refRW.ValueRW;
						GhostEffectEventBuffer item = new GhostEffectEventBuffer
						{
							Tick = inventoryHandlerShared.currentTick,
							value = new EffectEventCD
							{
								entity = inventoryToGetScrapParts,
								localOnlyEffect = 1,
								effectID = EffectID.ReceivedItemsChatMessage,
								value1 = enumerator.Current.Key,
								value2 = enumerator.Current.Value
							}
						};
						buffer.AddToRingBuffer(ref valueRW, in item);
					}
				}
			}
			materialsToPrint.Dispose();
		}

		private static int GetScrapPartsValue(PugDatabase.DatabaseBankCD databaseBankCD, ComponentLookup<DurabilityCD> durabilityLookup, ComponentLookup<LevelCD> levelLookup, ObjectDataCD objectData, bool salvaging)
		{
			Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(objectData.objectID, databaseBankCD.databaseBankBlob, objectData.variation);
			if (!durabilityLookup.TryGetComponent(primaryPrefabEntity, out var componentData) || !levelLookup.TryGetComponent(primaryPrefabEntity, out var componentData2))
			{
				return 1;
			}
			float num = componentData.repairCostMultiplier;
			if (salvaging)
			{
				num *= 2f;
			}
			return (int)math.max(1f, math.round((float)(componentData2.level * 2) * num));
		}

		[GenerateTestsForBurstCompatibility]
		private static bool TrySalvageObject(in InventoryHandlerShared inventoryHandlerShared, Entity inventorySalvage, int indexSalvage, Entity inventoryToGetScrapParts, float3 position, ref int totalScrapParts, NativeHashMap<int, int> materialsToPrint = default(NativeHashMap<int, int>))
		{
			ContainedObjectsBuffer containedObjectsBuffer = inventoryHandlerShared.containedObjectsBufferLookup[inventorySalvage][indexSalvage];
			ObjectID objectID = containedObjectsBuffer.objectID;
			ref PugDatabase.EntityObjectInfo entityObjectInfo = ref PugDatabase.GetEntityObjectInfo(objectID, inventoryHandlerShared.databaseBankCD.databaseBankBlob);
			bool isStackable = entityObjectInfo.isStackable;
			Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(objectID, inventoryHandlerShared.databaseBankCD.databaseBankBlob);
			ObjectCategoryTagsCD componentData;
			bool num = inventoryHandlerShared.objectCategoryTagsLookup.TryGetComponent(primaryPrefabEntity, out componentData) && ObjectCategoryTagsCD.HasTag(componentData.tagsBitMask, ObjectCategoryTag.CanBeSalvaged);
			bool flag = inventoryHandlerShared.levelEntitiesBufferLookup.HasComponent(primaryPrefabEntity);
			if (!num && (isStackable || !flag || entityObjectInfo.rarity == Rarity.Legendary))
			{
				return false;
			}
			DestroyInventoryObject(in inventoryHandlerShared, inventorySalvage, objectID, indexSalvage);
			int num2 = ((!isStackable) ? 1 : containedObjectsBuffer.amount);
			totalScrapParts += (int)math.round(math.max(1, GetScrapPartsValue(inventoryHandlerShared.databaseBankCD, inventoryHandlerShared.durabilityLookup, inventoryHandlerShared.levelLookup, containedObjectsBuffer.objectData, salvaging: true))) * num2;
			int amount = containedObjectsBuffer.amount;
			DurabilityCD componentData2;
			float t = math.min(inventoryHandlerShared.durabilityLookup.TryGetComponent(primaryPrefabEntity, out componentData2) ? ((float)amount / (float)componentData2.maxDurability) : 1f, 1f);
			float num3 = math.lerp(0.3f, 0.49f, t);
			num3 *= (float)num2;
			RefRW<RandomCD> refRWOptional = inventoryHandlerShared.randomLookup.GetRefRWOptional(inventorySalvage);
			if (!refRWOptional.IsValid)
			{
				Debug.LogError("Inventory to salvage from missing random");
				return false;
			}
			num3 *= entityObjectInfo.salvageMultiplier;
			for (int i = 0; i < entityObjectInfo.requiredObjectsToCraft.Length; i++)
			{
				ObjectWithAmount objectWithAmount = entityObjectInfo.requiredObjectsToCraft[i];
				float num4 = (float)objectWithAmount.amount * num3;
				int num5 = (int)num4 + ((refRWOptional.ValueRW.Value.NextFloat() < num4 % 1f) ? 1 : 0);
				if (num5 <= 0)
				{
					continue;
				}
				if (inventoryToGetScrapParts == Entity.Null)
				{
					ContainedObjectsBuffer containedObject = new ContainedObjectsBuffer
					{
						objectData = new ObjectDataCD
						{
							objectID = objectWithAmount.objectID,
							variation = 0,
							amount = num5
						}
					};
					EntityUtility.DropNewEntity(inventoryHandlerShared.ecb, containedObject, position, inventoryHandlerShared.databaseBankCD.databaseBankBlob);
				}
				else
				{
					CreateObject(in inventoryHandlerShared, inventoryToGetScrapParts, -1, objectWithAmount.objectID, num5, position, 0);
				}
				if (materialsToPrint.IsCreated)
				{
					if (!materialsToPrint.ContainsKey((int)entityObjectInfo.requiredObjectsToCraft[i].objectID))
					{
						materialsToPrint.Add((int)entityObjectInfo.requiredObjectsToCraft[i].objectID, num5);
					}
					else
					{
						materialsToPrint[(int)entityObjectInfo.requiredObjectsToCraft[i].objectID] += num5;
					}
				}
			}
			return true;
		}

		[GenerateTestsForBurstCompatibility]
		public static bool AutomatedPickup(Entity inventoryFromEntity, Entity inventoryToEntity, in MoverCD moverCD, in MoverFilterCD moverFilterCD, bool plantsInEndOfMove, BufferLookup<ContainedObjectsBuffer> containedObjectsBufferLookup, ComponentLookup<CraftingCD> craftingLookup, ComponentLookup<ObjectCategoryTagsCD> objectCategoryTagsLookup, ComponentLookup<AutomatedPlantableSeedCD> automatedPlantableSeedLookup, BufferLookup<InventorySlotRequirementBuffer> inventorySlotRequirementBufferLookup, ComponentLookup<OverrideLegendaryForSlotRequirementsCD> overrideAlwaysAllowToBeTrashedLookup, in ObjectLookupCD objectLookup, PugDatabase.DatabaseBankCD databaseBankCD, in PlacementHandler.CanPlaceSharedData canPlaceSharedData)
		{
			DynamicBuffer<ContainedObjectsBuffer> containerTo = containedObjectsBufferLookup[inventoryToEntity];
			if (containerTo[0].objectData.objectID != ObjectID.None)
			{
				Debug.LogError("AutomatedPickup: Already picked up");
				return false;
			}
			DynamicBuffer<ContainedObjectsBuffer> containerFrom = containedObjectsBufferLookup[inventoryFromEntity];
			if (craftingLookup.TryGetComponent(inventoryFromEntity, out var componentData))
			{
				if (componentData.outputSlotIndex >= 0)
				{
					ContainedObjectsBuffer targetObjectInInventory = containerFrom[componentData.outputSlotIndex];
					if (targetObjectInInventory.objectID == ObjectID.None || !PredictCanFinishMoveByMover(in moverCD, targetObjectInInventory, containedObjectsBufferLookup, in canPlaceSharedData, in objectLookup, plantsInEndOfMove) || !IsValidItemForAutomatedPickup(targetObjectInInventory.objectID, targetObjectInInventory.variation, in moverFilterCD, objectCategoryTagsLookup, automatedPlantableSeedLookup, databaseBankCD))
					{
						return false;
					}
					SimpleMoveBetweenInventoriesFromAutomatedPickup(containerFrom, componentData.outputSlotIndex, containerTo, 0, plantsInEndOfMove, databaseBankCD);
					return true;
				}
				if (componentData.craftingOutputsInInputSlot)
				{
					DynamicBuffer<InventorySlotRequirementBuffer> inventorySlotsRequirements = inventorySlotRequirementBufferLookup[inventoryFromEntity];
					for (int i = 0; i < containerFrom.Length; i++)
					{
						ContainedObjectsBuffer targetObjectInInventory2 = containerFrom[i];
						if (targetObjectInInventory2.objectID != ObjectID.None)
						{
							Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(targetObjectInInventory2.objectID, databaseBankCD.databaseBankBlob, targetObjectInInventory2.variation);
							objectCategoryTagsLookup.TryGetComponent(primaryPrefabEntity, out var componentData2);
							if (ObjectFulfillsRequirementsAtIndex(targetObjectInInventory2.objectID, i, 0, componentData2, inventorySlotsRequirements, overrideAlwaysAllowToBeTrashedLookup, databaseBankCD) != SlotRequirementFulfillment.FulfilledRequirement && PredictCanFinishMoveByMover(in moverCD, targetObjectInInventory2, containedObjectsBufferLookup, in canPlaceSharedData, in objectLookup, plantsInEndOfMove) && IsValidItemForAutomatedPickup(targetObjectInInventory2.objectID, targetObjectInInventory2.variation, in moverFilterCD, objectCategoryTagsLookup, automatedPlantableSeedLookup, databaseBankCD))
							{
								SimpleMoveBetweenInventoriesFromAutomatedPickup(containerFrom, i, containerTo, 0, plantsInEndOfMove, databaseBankCD);
								return true;
							}
						}
					}
					return false;
				}
				return false;
			}
			for (int j = 0; j < containerFrom.Length; j++)
			{
				ContainedObjectsBuffer targetObjectInInventory3 = containerFrom[j];
				if (targetObjectInInventory3.objectID != ObjectID.None && PredictCanFinishMoveByMover(in moverCD, targetObjectInInventory3, containedObjectsBufferLookup, in canPlaceSharedData, in objectLookup, plantsInEndOfMove) && IsValidItemForAutomatedPickup(targetObjectInInventory3.objectID, targetObjectInInventory3.variation, in moverFilterCD, objectCategoryTagsLookup, automatedPlantableSeedLookup, databaseBankCD))
				{
					SimpleMoveBetweenInventoriesFromAutomatedPickup(containerFrom, j, containerTo, 0, plantsInEndOfMove, databaseBankCD);
					return true;
				}
			}
			return false;
		}

		public static bool PredictCanFinishMoveByMover(in MoverCD mover, ContainedObjectsBuffer targetObjectInInventory, BufferLookup<ContainedObjectsBuffer> containerLookup, in PlacementHandler.CanPlaceSharedData canPlaceSharedData, in ObjectLookupCD objectLookupCD, bool plantsInEndOfMove)
		{
			if (plantsInEndOfMove)
			{
				int3 placeAtPos = mover.stop.ToInt3();
				return CanPlaceSeed(mover.inventoryEntity, targetObjectInInventory.objectID, targetObjectInInventory.variation, placeAtPos, containerLookup, in canPlaceSharedData, in objectLookupCD);
			}
			return true;
		}

		public static bool CanPlaceSeed(Entity moverInventoryEntity, ObjectID seedObjectID, int seedVariation, int3 placeAtPos, BufferLookup<ContainedObjectsBuffer> containedObjectsLookup, in PlacementHandler.CanPlaceSharedData canPlaceSharedData, in ObjectLookupCD objectLookupCD)
		{
			int2 xz = placeAtPos.xz;
			ref PugDatabase.EntityObjectInfo entityObjectInfo = ref PugDatabase.GetEntityObjectInfo(seedObjectID, canPlaceSharedData.databaseBank.databaseBankBlob, seedVariation);
			Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(seedObjectID, canPlaceSharedData.databaseBank.databaseBankBlob, seedVariation);
			PlacementCD placementCD = default(PlacementCD);
			PlacementHandler.Activate(ref placementCD, primaryPrefabEntity, canPlaceSharedData.objectPropertiesLookup, canPlaceSharedData.tileLookup, canPlaceSharedData.pseudoTileLookup);
			canPlaceSharedData.objectPropertiesLookup.TryGetComponent(primaryPrefabEntity, out var componentData);
			if (!componentData.IsValid || !componentData.Has(-975748197))
			{
				return false;
			}
			canPlaceSharedData.localTransformLookup.TryGetComponent(moverInventoryEntity, out var componentData2);
			float3 playerPosition = componentData2.Position;
			int totalTilesOK = 0;
			if (!componentData.TryGetList(1757427560, out NativeArray<ObjectID> value, (AllocatorManager.AllocatorHandle)Allocator.Temp))
			{
				value = new NativeArray<ObjectID>(0, Allocator.Temp);
			}
			if (!componentData.TryGetList(-789473209, out NativeArray<ObjectID> value2, (AllocatorManager.AllocatorHandle)Allocator.Temp))
			{
				value2 = new NativeArray<ObjectID>(0, Allocator.Temp);
			}
			if (PlacementHandler.IsNonAllowedImmuneTilePlacement(componentData, canPlaceSharedData.tileAccessor, placeAtPos))
			{
				return false;
			}
			TileCD prevTile = default(TileCD);
			NativeHashMap<int3, bool> tilesChecked = new NativeHashMap<int3, bool>(1, Allocator.Temp);
			PlacementHandler.ShouldCheckPlaceObjectOnTile(primaryPrefabEntity, ref placementCD, ref placeAtPos, ref totalTilesOK, in playerPosition, ref prevTile, ref entityObjectInfo, in componentData, tilesChecked, value2, value, out var isPlacingElectronic, out var foundValidTileToPlaceOn, out var tileData, in canPlaceSharedData);
			bool isPlacedOnEdge = true;
			int width = 1;
			int height = 1;
			bool foundValidObjectToPlaceOn = false;
			bool flag = false;
			NativeList<ObjectLookupEntry> objects = objectLookupCD.lookup.GetObjects(xz, Allocator.Temp);
			for (int i = 0; i < objects.Length; i++)
			{
				ObjectID objectId = objects[i].objectId;
				Entity entity = objects[i].optionalEntityIfLoaded;
				if (entity == Entity.Null)
				{
					entity = PugDatabase.GetPrimaryPrefabEntity(objectId, canPlaceSharedData.databaseBank.databaseBankBlob);
					if (entity == Entity.Null)
					{
						continue;
					}
				}
				flag = PlacementHandler.CheckEntityIsBlockingPlacement(entity, in placementCD, foundValidTileToPlaceOn, tileData, ref entityObjectInfo, isPlacingElectronic, isPlacedOnEdge, placeAtPos, width, height, value2, value, in canPlaceSharedData, ref foundValidObjectToPlaceOn);
				if (flag)
				{
					break;
				}
			}
			if (foundValidTileToPlaceOn || foundValidObjectToPlaceOn)
			{
				return !flag;
			}
			return false;
		}

		private static void SimpleMoveBetweenInventoriesFromAutomatedPickup(DynamicBuffer<ContainedObjectsBuffer> containerFrom, int fromIndex, DynamicBuffer<ContainedObjectsBuffer> containerTo, int toIndex, bool isSingleStackMover, PugDatabase.DatabaseBankCD databaseBankCD)
		{
			ContainedObjectsBuffer value = containerFrom[fromIndex];
			if (isSingleStackMover && PugDatabase.GetEntityObjectInfo(value.objectID, databaseBankCD.databaseBankBlob, value.variation).isStackable)
			{
				containerTo[toIndex] = new ContainedObjectsBuffer
				{
					objectData = new ObjectDataCD
					{
						objectID = value.objectID,
						variation = value.variation,
						amount = 1
					}
				};
				value.objectData.amount--;
				if (value.amount == 0)
				{
					value = default(ContainedObjectsBuffer);
				}
				containerFrom[fromIndex] = value;
			}
			else
			{
				containerFrom[fromIndex] = default(ContainedObjectsBuffer);
				containerTo[toIndex] = value;
			}
		}

		private static bool IsValidItemForAutomatedPickup(ObjectID objectID, int variation, in MoverFilterCD moverFilterCD, ComponentLookup<ObjectCategoryTagsCD> objectCategoryTagsLookup, ComponentLookup<AutomatedPlantableSeedCD> automatedPlantableSeedLookup, PugDatabase.DatabaseBankCD databaseBankCD)
		{
			if (moverFilterCD.filterCategory != ObjectCategoryTag.None)
			{
				return ItemMatchesCategoryFilter(objectID, objectCategoryTagsLookup, automatedPlantableSeedLookup, databaseBankCD);
			}
			return ItemMatchesObjectFilter(objectID, variation, in moverFilterCD, objectCategoryTagsLookup, databaseBankCD);
		}

		private static bool ItemMatchesCategoryFilter(ObjectID objectID, ComponentLookup<ObjectCategoryTagsCD> objectCategoryTagsLookup, ComponentLookup<AutomatedPlantableSeedCD> automatedPlantableSeedLookup, PugDatabase.DatabaseBankCD databaseBankCD)
		{
			Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(objectID, databaseBankCD.databaseBankBlob);
			if (objectCategoryTagsLookup.TryGetComponent(primaryPrefabEntity, out var componentData) && ObjectCategoryTagsCD.HasTag(componentData.tagsBitMask, ObjectCategoryTag.Seed))
			{
				return automatedPlantableSeedLookup.HasComponent(primaryPrefabEntity);
			}
			return false;
		}

		public static bool ItemMatchesObjectFilter(ObjectID objectID, int variation, in MoverFilterCD moverFilterCD, ComponentLookup<ObjectCategoryTagsCD> objectCategoryTagsLookup, PugDatabase.DatabaseBankCD databaseBankCD)
		{
			if (moverFilterCD.filterType == FilterType.None)
			{
				return true;
			}
			Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(objectID, databaseBankCD.databaseBankBlob);
			ObjectCategoryTagsCD componentData;
			bool num = objectCategoryTagsLookup.TryGetComponent(primaryPrefabEntity, out componentData) && ObjectCategoryTagsCD.HasTag(componentData.tagsBitMask, ObjectCategoryTag.CanBeUpgraded);
			bool flag = objectID == moverFilterCD.filterObject;
			if (!num)
			{
				flag &= variation == moverFilterCD.filterVariation;
			}
			bool flag2 = moverFilterCD.filterType == FilterType.Whitelist;
			return flag == flag2;
		}

		public static bool AutomatedHarvest(BufferLookup<ContainedObjectsBuffer> containedObjectsBufferLookup, ComponentLookup<PlantCD> plantLookup, ComponentLookup<HasFinishedGrowingCD> hasFinishedGrowingLookup, ComponentLookup<EntityDestroyedCD> entityDestroyedLookup, ComponentLookup<DontDropLootCD> dontDropLootLookup, ComponentLookup<DontDropSelfCD> dontDropSelfLookup, Entity harvestInventory, Entity moveToInventory)
		{
			if (!hasFinishedGrowingLookup.HasComponent(harvestInventory))
			{
				return false;
			}
			DynamicBuffer<ContainedObjectsBuffer> dynamicBuffer = containedObjectsBufferLookup[moveToInventory];
			if (dynamicBuffer[0].objectData.objectID != ObjectID.None)
			{
				Debug.LogError("AutomatedHarvest: Already harvested");
				return false;
			}
			if (entityDestroyedLookup.HasAndIsComponentEnabled(harvestInventory))
			{
				return false;
			}
			if (!plantLookup.TryGetComponent(harvestInventory, out var componentData))
			{
				Debug.LogError("AutomatedHarvest: No PlantCD on target");
				return false;
			}
			ContainedObjectsBuffer value = new ContainedObjectsBuffer
			{
				objectData = new ObjectDataCD
				{
					objectID = componentData.objectToDropWhenHarvested,
					amount = componentData.numberOfPlantsToDrop
				}
			};
			dynamicBuffer[0] = value;
			dontDropLootLookup.SetComponentEnabled(harvestInventory, value: true);
			dontDropSelfLookup.SetComponentEnabled(harvestInventory, value: true);
			entityDestroyedLookup.SetComponentEnabled(harvestInventory, value: true);
			return true;
		}

		[GenerateTestsForBurstCompatibility]
		public static bool CanPickup(BufferLookup<ContainedObjectsBuffer> containedObjectsBufferLookup, ComponentLookup<CraftingCD> craftingLookup, BufferLookup<InventorySlotRequirementBuffer> inventorySlotRequirementBufferLookup, ComponentLookup<ObjectCategoryTagsCD> objectCategoryTagsLookup, ComponentLookup<OverrideLegendaryForSlotRequirementsCD> overrideAlwaysAllowToBeTrashedLookup, Entity inventoryFromEntity, PugDatabase.DatabaseBankCD databaseBankCD)
		{
			DynamicBuffer<ContainedObjectsBuffer> dynamicBuffer = containedObjectsBufferLookup[inventoryFromEntity];
			if (craftingLookup.TryGetComponent(inventoryFromEntity, out var componentData))
			{
				if (componentData.outputSlotIndex >= 0)
				{
					if (dynamicBuffer[componentData.outputSlotIndex].objectID == ObjectID.None)
					{
						return false;
					}
					return true;
				}
				if (componentData.craftingOutputsInInputSlot)
				{
					DynamicBuffer<InventorySlotRequirementBuffer> inventorySlotsRequirements = inventorySlotRequirementBufferLookup[inventoryFromEntity];
					for (int i = 0; i < dynamicBuffer.Length; i++)
					{
						ContainedObjectsBuffer containedObjectsBuffer = dynamicBuffer[i];
						if (containedObjectsBuffer.objectID != ObjectID.None)
						{
							Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(containedObjectsBuffer.objectID, databaseBankCD.databaseBankBlob, containedObjectsBuffer.variation);
							objectCategoryTagsLookup.TryGetComponent(primaryPrefabEntity, out var componentData2);
							if (ObjectFulfillsRequirementsAtIndex(containedObjectsBuffer.objectID, i, 0, componentData2, inventorySlotsRequirements, overrideAlwaysAllowToBeTrashedLookup, databaseBankCD) != SlotRequirementFulfillment.FulfilledRequirement)
							{
								return true;
							}
						}
					}
					return false;
				}
				return false;
			}
			for (int j = 0; j < dynamicBuffer.Length; j++)
			{
				if (dynamicBuffer[j].objectID != ObjectID.None)
				{
					return true;
				}
			}
			return false;
		}

		public static bool CanCraft(in InventoryHandlerShared inventoryHandlerShared, Entity mainEntity, ObjectDataCD mainEntityObjectData, NativeList<Entity> inventoryEntities, CanCraftObjectsBuffer objectToCraft, float costMultiplier = 1f)
		{
			return CanCraft(inventoryHandlerShared.craftingLookup[mainEntity], inventoryHandlerShared.containedObjectsBufferLookup, inventoryHandlerShared.ingredientLookup, inventoryHandlerShared.objectCategoryTagsLookup, inventoryHandlerShared.databaseBankCD, mainEntity, mainEntityObjectData, inventoryEntities, objectToCraft, costMultiplier);
		}

		[GenerateTestsForBurstCompatibility]
		public static bool CanCraft(in CraftingCD crafting, BufferLookup<ContainedObjectsBuffer> containedObjectsBufferLookup, ComponentLookup<CookingIngredientCD> ingredientLookup, ComponentLookup<ObjectCategoryTagsCD> objectCategoryTagsLookup, PugDatabase.DatabaseBankCD databaseBankCD, Entity mainEntity, ObjectDataCD mainEntityObjectData, NativeList<Entity> inventoryEntities, CanCraftObjectsBuffer objectToCraft, float costMultiplier = 1f)
		{
			if (crafting.craftingType == CraftingType.Cooking)
			{
				DynamicBuffer<ContainedObjectsBuffer> dynamicBuffer = containedObjectsBufferLookup[inventoryEntities[0]];
				if (dynamicBuffer[0].objectData.objectID == ObjectID.None || dynamicBuffer[1].objectData.objectID == ObjectID.None)
				{
					return false;
				}
				if (dynamicBuffer[0].objectData.amount < objectToCraft.amount || dynamicBuffer[1].objectData.amount < objectToCraft.amount)
				{
					return false;
				}
				Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(CookedFoodCD.GetPrimaryIngredient(dynamicBuffer[0].objectData.objectID, dynamicBuffer[1].objectData.objectID), databaseBankCD.databaseBankBlob);
				if (!ingredientLookup.HasComponent(primaryPrefabEntity))
				{
					return false;
				}
				int foodVariation = CookedFoodCD.GetFoodVariation(dynamicBuffer[0].objectData.objectID, dynamicBuffer[1].objectData.objectID);
				ObjectDataCD objectData = dynamicBuffer[crafting.outputSlotIndex].objectData;
				ObjectID turnsIntoFood = ingredientLookup[primaryPrefabEntity].turnsIntoFood;
				if ((objectData.objectID != ObjectID.None && (objectData.objectID != turnsIntoFood || objectData.variation != foodVariation)) || objectData.amount + objectToCraft.amount > 9999)
				{
					return false;
				}
			}
			else if (crafting.craftingConsumesEntityAmount)
			{
				if (mainEntityObjectData.amount < objectToCraft.entityAmountToConsume)
				{
					return false;
				}
			}
			else
			{
				DynamicBuffer<ContainedObjectsBuffer> dynamicBuffer2 = containedObjectsBufferLookup[inventoryEntities[0]];
				ref PugDatabase.EntityObjectInfo entityObjectInfo = ref PugDatabase.GetEntityObjectInfo(objectToCraft.objectID, databaseBankCD.databaseBankBlob);
				ObjectDataCD objectData2 = dynamicBuffer2[crafting.outputSlotIndex].objectData;
				if (objectData2.objectID != ObjectID.None && (!entityObjectInfo.isStackable || objectData2.objectID != objectToCraft.objectID || objectData2.amount >= 9999))
				{
					return false;
				}
				if (entityObjectInfo.CraftingSettings.canOnlyUseAnyMaterialsWithTag != ObjectCategoryTag.None)
				{
					for (int i = 0; i < inventoryEntities.Length; i++)
					{
						if (!containedObjectsBufferLookup.HasComponent(inventoryEntities[i]))
						{
							continue;
						}
						DynamicBuffer<ContainedObjectsBuffer> dynamicBuffer3 = containedObjectsBufferLookup[inventoryEntities[i]];
						for (int j = 0; j < dynamicBuffer3.Length; j++)
						{
							Entity primaryPrefabEntity2 = PugDatabase.GetPrimaryPrefabEntity(dynamicBuffer3[j].objectData.objectID, databaseBankCD.databaseBankBlob);
							if (objectCategoryTagsLookup.HasComponent(primaryPrefabEntity2) && ObjectCategoryTagsCD.HasTag(objectCategoryTagsLookup[primaryPrefabEntity2].tagsBitMask, entityObjectInfo.CraftingSettings.canOnlyUseAnyMaterialsWithTag))
							{
								return true;
							}
						}
					}
					return false;
				}
				ref BlobArray<ObjectWithAmount> requiredObjectsToCraft = ref PugDatabase.GetRequiredObjectsToCraft(objectToCraft.objectID, databaseBankCD.databaseBankBlob);
				NativeArray<int> nativeArray = new NativeArray<int>(requiredObjectsToCraft.Length, Allocator.Temp);
				for (int k = 0; k < inventoryEntities.Length; k++)
				{
					if (!containedObjectsBufferLookup.HasComponent(inventoryEntities[k]))
					{
						continue;
					}
					DynamicBuffer<ContainedObjectsBuffer> dynamicBuffer4 = containedObjectsBufferLookup[inventoryEntities[k]];
					for (int l = 0; l < dynamicBuffer4.Length; l++)
					{
						ObjectDataCD objectData3 = dynamicBuffer4[l].objectData;
						for (int m = 0; m < requiredObjectsToCraft.Length; m++)
						{
							ObjectWithAmount objectWithAmount = requiredObjectsToCraft[m];
							if (objectData3.objectID == objectWithAmount.objectID)
							{
								nativeArray[m] += math.min((int)math.round((float)requiredObjectsToCraft[m].amount * costMultiplier) * objectToCraft.amount - nativeArray[m], objectData3.amount);
							}
						}
					}
				}
				for (int n = 0; n < requiredObjectsToCraft.Length; n++)
				{
					if (nativeArray[n] != (int)math.round((float)requiredObjectsToCraft[n].amount * costMultiplier) * objectToCraft.amount)
					{
						nativeArray.Dispose();
						return false;
					}
				}
				nativeArray.Dispose();
			}
			return true;
		}

		[GenerateTestsForBurstCompatibility]
		public static bool Craft(in InventoryHandlerShared inventoryHandlerShared, Entity mainEntity, ObjectDataCD mainEntityObjectData, NativeList<Entity> inventoryEntities, CanCraftObjectsBuffer objectToCraft, int additionalFreeAmount, float3 entityPosition, bool useCraftingCostMultiplier, Entity playerEntity = default(Entity), Entity craftingEntity = default(Entity))
		{
			float num = (useCraftingCostMultiplier ? GetAnyMaterialCostMultiplier(in inventoryHandlerShared, craftingEntity, playerEntity) : 1f);
			if (!CanCraft(in inventoryHandlerShared, mainEntity, mainEntityObjectData, inventoryEntities, objectToCraft, num))
			{
				return false;
			}
			CraftingCD craftingCD = inventoryHandlerShared.craftingLookup[mainEntity];
			if (craftingCD.craftingType == CraftingType.Cooking)
			{
				DynamicBuffer<ContainedObjectsBuffer> dynamicBuffer = inventoryHandlerShared.containedObjectsBufferLookup[mainEntity];
				Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(CookedFoodCD.GetPrimaryIngredient(dynamicBuffer[0].objectData.objectID, dynamicBuffer[1].objectData.objectID), inventoryHandlerShared.databaseBankCD.databaseBankBlob);
				int foodVariation = CookedFoodCD.GetFoodVariation(dynamicBuffer[0].objectData.objectID, dynamicBuffer[1].objectData.objectID);
				ObjectDataCD objectData = dynamicBuffer[craftingCD.outputSlotIndex].objectData;
				ObjectID turnsIntoFood = inventoryHandlerShared.ingredientLookup[primaryPrefabEntity].turnsIntoFood;
				ContainedObjectsBuffer value = dynamicBuffer[0];
				ContainedObjectsBuffer value2 = dynamicBuffer[1];
				value.objectData.amount -= objectToCraft.amount;
				value2.objectData.amount -= objectToCraft.amount;
				if (value.objectData.amount <= 0)
				{
					value.objectData = default(ObjectDataCD);
				}
				if (value2.objectData.amount <= 0)
				{
					value2.objectData = default(ObjectDataCD);
				}
				dynamicBuffer[0] = value;
				dynamicBuffer[1] = value2;
				if (objectData.objectID != turnsIntoFood || objectData.variation != foodVariation)
				{
					objectData = new ObjectDataCD
					{
						objectID = turnsIntoFood,
						variation = foodVariation,
						amount = objectToCraft.amount
					};
				}
				else
				{
					objectData.amount += objectToCraft.amount;
				}
				dynamicBuffer[craftingCD.outputSlotIndex] = new ContainedObjectsBuffer
				{
					objectData = objectData
				};
			}
			else
			{
				int num2 = 0;
				ref PugDatabase.EntityObjectInfo entityObjectInfo = ref PugDatabase.GetEntityObjectInfo(objectToCraft.objectID, inventoryHandlerShared.databaseBankCD.databaseBankBlob);
				if (craftingCD.craftingConsumesEntityAmount)
				{
					if (mainEntityObjectData.amount >= objectToCraft.entityAmountToConsume)
					{
						mainEntityObjectData.amount -= objectToCraft.entityAmountToConsume;
						inventoryHandlerShared.ecb.SetComponent(mainEntity, mainEntityObjectData);
						if (PugDatabase.GetEntityObjectInfo(mainEntityObjectData.objectID, inventoryHandlerShared.databaseBankCD.databaseBankBlob).sellValue != 0)
						{
							num2 += objectToCraft.entityAmountToConsume;
						}
					}
				}
				else if (entityObjectInfo.CraftingSettings.canOnlyUseAnyMaterialsWithTag == ObjectCategoryTag.None)
				{
					ref BlobArray<ObjectWithAmount> requiredObjectsToCraft = ref PugDatabase.GetRequiredObjectsToCraft(objectToCraft.objectID, inventoryHandlerShared.databaseBankCD.databaseBankBlob);
					NativeArray<int> nativeArray = new NativeArray<int>(requiredObjectsToCraft.Length, Allocator.Temp);
					for (int i = 0; i < requiredObjectsToCraft.Length; i++)
					{
						nativeArray[i] = (int)math.round((float)requiredObjectsToCraft[i].amount * num) * objectToCraft.amount;
						if (PugDatabase.GetEntityObjectInfo(requiredObjectsToCraft[i].objectID, inventoryHandlerShared.databaseBankCD.databaseBankBlob).sellValue != 0)
						{
							num2 += nativeArray[i];
						}
					}
					for (int j = 0; j < requiredObjectsToCraft.Length; j++)
					{
						for (int k = 0; k < inventoryEntities.Length; k++)
						{
							if (inventoryHandlerShared.containedObjectsBufferLookup.HasComponent(inventoryEntities[k]))
							{
								nativeArray[j] -= ConsumeObject(in inventoryHandlerShared, inventoryEntities[k], requiredObjectsToCraft[j].objectID, nativeArray[j]);
							}
						}
					}
					nativeArray.Dispose();
				}
				else
				{
					NativeArray<int> nativeArray2 = new NativeArray<int>(1, Allocator.Temp);
					nativeArray2[0] = (int)math.round(1f * num) * objectToCraft.amount;
					for (int l = 0; l < inventoryEntities.Length; l++)
					{
						if (inventoryHandlerShared.containedObjectsBufferLookup.HasComponent(inventoryEntities[l]))
						{
							nativeArray2[0] -= ConsumeObjectWithTag(in inventoryHandlerShared, inventoryEntities[l], entityObjectInfo.CraftingSettings.canOnlyUseAnyMaterialsWithTag, nativeArray2[0]);
						}
					}
					nativeArray2.Dispose();
				}
				int num3 = ((objectToCraft.amount > 0) ? (entityObjectInfo.isStackable ? (entityObjectInfo.initialAmount * objectToCraft.amount) : entityObjectInfo.initialAmount) : 0);
				if (craftingCD.craftingType == CraftingType.Cattle)
				{
					if (objectToCraft.objectID != ObjectID.None)
					{
						EntityUtility.DropNewEntity(inventoryHandlerShared.ecb, new ContainedObjectsBuffer
						{
							objectData = new ObjectDataCD
							{
								objectID = objectToCraft.objectID,
								amount = num3 + additionalFreeAmount
							}
						}, entityPosition + new float3(0f, 0f, -0.2f), inventoryHandlerShared.databaseBankCD.databaseBankBlob);
					}
				}
				else
				{
					DynamicBuffer<ContainedObjectsBuffer> dynamicBuffer2 = inventoryHandlerShared.containedObjectsBufferLookup[mainEntity];
					ObjectDataCD objectData2 = dynamicBuffer2[craftingCD.outputSlotIndex].objectData;
					if (objectData2.objectID == ObjectID.None)
					{
						objectData2 = new ObjectDataCD
						{
							objectID = objectToCraft.objectID,
							amount = num3 + additionalFreeAmount
						};
					}
					else
					{
						objectData2.amount += num3 + additionalFreeAmount;
					}
					dynamicBuffer2[craftingCD.outputSlotIndex] = new ContainedObjectsBuffer
					{
						objectData = objectData2
					};
				}
				if (num2 == 0)
				{
					num2 = 2 * objectToCraft.amount;
				}
				if (playerEntity != Entity.Null)
				{
					PlayerController.AddSkill(playerEntity, SkillID.Crafting, num2, inventoryHandlerShared.ecb, inventoryHandlerShared.isServer);
				}
			}
			return true;
		}

		[GenerateTestsForBurstCompatibility]
		public static void CraftParchmentRecipe(in InventoryHandlerShared inventoryHandlerShared, Entity playerEntity, ObjectID equippedObjectID, int variation, int equippedIndex)
		{
			Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(equippedObjectID, inventoryHandlerShared.databaseBankCD.databaseBankBlob, variation);
			if (!inventoryHandlerShared.parchmentRecipeLookup.TryGetComponent(primaryPrefabEntity, out var componentData))
			{
				return;
			}
			ref PugDatabase.EntityObjectInfo entityObjectInfo = ref PugDatabase.GetEntityObjectInfo(componentData.objectToCraft.objectID, inventoryHandlerShared.databaseBankCD.databaseBankBlob, componentData.objectToCraft.variation);
			ObjectWithAmount objectWithAmount = new ObjectWithAmount
			{
				objectID = entityObjectInfo.objectID,
				amount = componentData.objectToCraft.amount
			};
			using NativeList<ObjectWithAmount> requiredObjectsToCraft = new NativeList<ObjectWithAmount>(entityObjectInfo.requiredObjectsToCraft.Length, Allocator.Temp);
			for (int i = 0; i < entityObjectInfo.requiredObjectsToCraft.Length; i++)
			{
				requiredObjectsToCraft.Add(new ObjectWithAmount
				{
					objectID = entityObjectInfo.requiredObjectsToCraft[i].objectID,
					amount = entityObjectInfo.requiredObjectsToCraft[i].amount
				});
			}
			using NativeList<Entity> inventoryEntities = new NativeList<Entity>(1, Allocator.Temp);
			inventoryEntities.Add(in playerEntity);
			if (!HasMaterialsInCraftingInventoryToCraftRecipe(in inventoryHandlerShared, playerEntity, playerEntity, inventoryEntities, requiredObjectsToCraft))
			{
				return;
			}
			ObjectDataCD objectDataCD = new ObjectDataCD
			{
				objectID = objectWithAmount.objectID,
				amount = objectWithAmount.amount
			};
			int amount = objectDataCD.amount;
			ObjectID objectID = objectDataCD.objectID;
			bool flag = false;
			foreach (ObjectWithAmount item2 in requiredObjectsToCraft)
			{
				if (!flag && item2.objectID == equippedObjectID)
				{
					flag = true;
				}
				int num = item2.amount;
				foreach (Entity item3 in inventoryEntities)
				{
					if (num > 0 && inventoryHandlerShared.inventoryLookup.TryGetBuffer(item3, out var bufferData))
					{
						for (int j = 0; j < bufferData.Length; j++)
						{
							InventoryBuffer inventoryBuffer = bufferData[j];
							num = DestroyUpToAmountOfEntity(in inventoryHandlerShared, item3, inventoryBuffer.startIndex, inventoryBuffer.startIndex + inventoryBuffer.size, item2.objectID, num);
						}
					}
				}
				if (num != 0)
				{
					Debug.LogError($"Crafted {objectDataCD} when there wasnt enough {item2.objectID}, missing {num}");
				}
			}
			if (inventoryHandlerShared.ghostEffectEventBufferLookup.TryGetBuffer(playerEntity, out var bufferData2))
			{
				RefRW<GhostEffectEventBufferPointerCD> refRW = inventoryHandlerShared.ghostEffectEventBufferPointerLookup.GetRefRW(playerEntity);
				DynamicBuffer<GhostEffectEventBuffer> buffer = bufferData2;
				ref GhostEffectEventBufferPointerCD valueRW = ref refRW.ValueRW;
				GhostEffectEventBuffer item = new GhostEffectEventBuffer
				{
					Tick = inventoryHandlerShared.currentTick,
					value = new EffectEventCD
					{
						entity = playerEntity,
						localOnlyEffect = 1,
						effectID = EffectID.GainedItemChatMessage,
						value1 = (int)objectID
					}
				};
				buffer.AddToRingBuffer(ref valueRW, in item);
			}
			float3 position = inventoryHandlerShared.localTransformLookup[playerEntity].Position;
			if (!flag)
			{
				ConsumeEntityAt(in inventoryHandlerShared, playerEntity, equippedIndex, 1, destroy: true, position);
			}
			CreateObject(in inventoryHandlerShared, playerEntity, equippedIndex, objectID, amount, position, 0);
		}

		public static void UpgradeAllItemsInInventory(in InventoryHandlerShared inventoryHandlerShared, Entity inventory, int targetUpgradeLevel)
		{
			inventoryHandlerShared.containedObjectsBufferLookup.TryGetBuffer(inventory, out var bufferData);
			for (int i = 0; i < bufferData.Length; i++)
			{
				UpgradeItemInInventory(in inventoryHandlerShared, inventory, i, targetUpgradeLevel);
			}
		}

		public static void UpgradeItemInInventory(in InventoryHandlerShared inventoryHandlerShared, Entity inventory, int containedIndex, int targetUpgradeLevel)
		{
			ContainedObjectsBuffer containedObjectsBuffer = inventoryHandlerShared.containedObjectsBufferLookup[inventory][containedIndex];
			if (containedObjectsBuffer.objectID != ObjectID.None)
			{
				Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(containedObjectsBuffer.objectID, inventoryHandlerShared.databaseBankCD.databaseBankBlob, containedObjectsBuffer.variation);
				if (CanBeUpgraded(in inventoryHandlerShared, primaryPrefabEntity))
				{
					int maxLevel = LevelScaling.GetMaxLevel();
					int variation = math.clamp(targetUpgradeLevel, 1, maxLevel);
					SetVariation(in inventoryHandlerShared, inventory, containedIndex, containedObjectsBuffer.objectID, variation);
				}
			}
		}

		public static void Upgrade(in InventoryHandlerShared inventoryHandlerShared, Entity inventoryEntity, int index, ObjectID objectID, NativeList<Entity> inventoryEntities, int chestsStartIndex, bool craftingMaterialsAreNotRequired)
		{
			ContainedObjectsBuffer containedObjectsBuffer = inventoryHandlerShared.containedObjectsBufferLookup[inventoryEntity][index];
			if (containedObjectsBuffer.objectID != objectID)
			{
				return;
			}
			Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(containedObjectsBuffer.objectID, inventoryHandlerShared.databaseBankCD.databaseBankBlob, containedObjectsBuffer.variation);
			if (!CanBeUpgraded(in inventoryHandlerShared, primaryPrefabEntity) || IsFullyUpgraded(primaryPrefabEntity, containedObjectsBuffer.variation, inventoryHandlerShared.levelLookup))
			{
				return;
			}
			int num = ((containedObjectsBuffer.variation > 0) ? containedObjectsBuffer.variation : inventoryHandlerShared.levelLookup[primaryPrefabEntity].level);
			using NativeList<PugDatabase.MaterialInfoData> nativeList = GetCraftingMaterialInfosForUpgrade(in inventoryHandlerShared, num + 1, inventoryEntities, chestsStartIndex, Allocator.Temp);
			if (!craftingMaterialsAreNotRequired)
			{
				foreach (PugDatabase.MaterialInfoData item2 in nativeList)
				{
					if (item2.amountAvailable < item2.amountNeeded)
					{
						return;
					}
				}
				foreach (PugDatabase.MaterialInfoData item3 in nativeList)
				{
					int num2 = item3.amountNeeded;
					foreach (Entity item4 in inventoryEntities)
					{
						if (inventoryHandlerShared.containedObjectsBufferLookup.HasComponent(item4) && num2 > 0)
						{
							num2 -= ConsumeObject(in inventoryHandlerShared, item4, item3.objectID, num2);
						}
					}
					if (num2 != 0)
					{
						Debug.LogError($"Upgraded {objectID} when there wasnt enough {item3.objectID}, missing {num2}");
					}
				}
			}
			int maxLevel = LevelScaling.GetMaxLevel();
			SetVariation(in inventoryHandlerShared, inventoryEntity, index, objectID, math.min(maxLevel, num + 1));
			if (inventoryHandlerShared.ghostEffectEventBufferLookup.TryGetBuffer(inventoryEntity, out var bufferData))
			{
				RefRW<GhostEffectEventBufferPointerCD> refRW = inventoryHandlerShared.ghostEffectEventBufferPointerLookup.GetRefRW(inventoryEntity);
				DynamicBuffer<GhostEffectEventBuffer> buffer = bufferData;
				ref GhostEffectEventBufferPointerCD valueRW = ref refRW.ValueRW;
				GhostEffectEventBuffer item = new GhostEffectEventBuffer
				{
					Tick = inventoryHandlerShared.currentTick,
					value = new EffectEventCD
					{
						entity = inventoryEntity,
						localOnlyEffect = 1,
						effectID = EffectID.UpgradeSFX,
						value1 = num
					}
				};
				buffer.AddToRingBuffer(ref valueRW, in item);
			}
		}

		private static bool CanBeUpgraded(in InventoryHandlerShared inventoryHandlerShared, Entity itemPrefab)
		{
			return CanBeUpgraded(inventoryHandlerShared.levelEntitiesBufferLookup, inventoryHandlerShared.objectCategoryTagsLookup, itemPrefab);
		}

		public static bool CanBeUpgraded(BufferLookup<LevelEntitiesBuffer> levelEntitiesBufferLookup, ComponentLookup<ObjectCategoryTagsCD> objectCategoryTagsLookup, Entity itemPrefab)
		{
			if (levelEntitiesBufferLookup.HasComponent(itemPrefab) && objectCategoryTagsLookup.TryGetComponent(itemPrefab, out var componentData))
			{
				return ObjectCategoryTagsCD.HasTag(componentData.tagsBitMask, ObjectCategoryTag.CanBeUpgraded);
			}
			return false;
		}

		private static bool IsFullyUpgraded(Entity itemPrefab, int variation, ComponentLookup<LevelCD> levelLookup)
		{
			if (!levelLookup.TryGetComponent(itemPrefab, out var componentData))
			{
				return false;
			}
			return ((variation > 0) ? variation : componentData.level) >= LevelScaling.GetMaxLevel();
		}

		public static NativeList<PugDatabase.MaterialInfoData> GetCraftingMaterialInfosForUpgrade(in InventoryHandlerShared inventoryHandlerShared, int level, NativeList<Entity> inventories, int chestsStartIndex, Allocator allocator)
		{
			return GetCraftingMaterialInfosForUpgrade(inventoryHandlerShared.containedObjectsBufferLookup, inventoryHandlerShared.inventoryLookup, inventoryHandlerShared.databaseBankCD, inventoryHandlerShared.upgradeCostsTableCD, level, inventories, chestsStartIndex, allocator);
		}

		public static NativeList<PugDatabase.MaterialInfoData> GetCraftingMaterialInfosForUpgrade(BufferLookup<ContainedObjectsBuffer> containedObjectsBufferLookup, BufferLookup<InventoryBuffer> inventoryBufferLookup, PugDatabase.DatabaseBankCD databaseBankCD, UpgradeCostsTableCD upgradeCostsTableCD, int level, NativeList<Entity> inventories, int chestsStartIndex, Allocator allocator)
		{
			ref BlobArray<UpgradeCostBlob> upgradeCost = ref upgradeCostsTableCD.GetUpgradeCost(level);
			using NativeList<ObjectWithAmount> objectsRequired = new NativeList<ObjectWithAmount>(upgradeCost.Length, Allocator.Temp);
			for (int i = 0; i < upgradeCost.Length; i++)
			{
				objectsRequired.Add(new ObjectWithAmount
				{
					objectID = upgradeCost[i].item,
					amount = upgradeCost[i].amount
				});
			}
			return GetMaterialInfos(containedObjectsBufferLookup, inventoryBufferLookup, databaseBankCD, objectsRequired, 1f, inventories, chestsStartIndex, allocator);
		}

		public static NativeList<PugDatabase.MaterialInfoData> GetMaterialInfos(in InventoryHandlerShared inventoryHandlerShared, NativeList<ObjectWithAmount> objectsRequired, float costMultiplier, NativeList<Entity> inventories, int chestsStartIndex, Allocator allocator)
		{
			return GetMaterialInfos(inventoryHandlerShared.containedObjectsBufferLookup, inventoryHandlerShared.inventoryLookup, inventoryHandlerShared.databaseBankCD, objectsRequired, costMultiplier, inventories, chestsStartIndex, allocator);
		}

		public static NativeList<PugDatabase.MaterialInfoData> GetMaterialInfos(BufferLookup<ContainedObjectsBuffer> containedObjectsBufferLookup, BufferLookup<InventoryBuffer> inventoryBufferLookup, PugDatabase.DatabaseBankCD databaseBankCD, NativeList<ObjectWithAmount> objectsRequired, float costMultiplier, NativeList<Entity> inventories, int chestsStartIndex, Allocator allocator)
		{
			NativeList<PugDatabase.MaterialInfoData> result = new NativeList<PugDatabase.MaterialInfoData>(objectsRequired.Length, allocator);
			for (int i = 0; i < objectsRequired.Length; i++)
			{
				int num = (int)math.max(1f, math.round((float)objectsRequired[i].amount * costMultiplier));
				ObjectID objectID = objectsRequired[i].objectID;
				bool flag = false;
				for (int j = 0; j < result.Length; j++)
				{
					if (objectID == result[j].objectID)
					{
						result.ElementAt(j).amountNeeded += num;
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					int amountInChests;
					Entity materialsFromInventoriesAndGetClosestChest = GetMaterialsFromInventoriesAndGetClosestChest(containedObjectsBufferLookup, inventoryBufferLookup, databaseBankCD, objectID, inventories, chestsStartIndex, out amountInChests);
					result.Add(new PugDatabase.MaterialInfoData(objectID, num, amountInChests, materialsFromInventoriesAndGetClosestChest));
				}
			}
			return result;
		}

		private static Entity GetMaterialsFromInventoriesAndGetClosestChest(BufferLookup<ContainedObjectsBuffer> containedObjectsBufferLookup, BufferLookup<InventoryBuffer> inventoryBufferLookup, PugDatabase.DatabaseBankCD databaseBankCD, ObjectID objectID, NativeList<Entity> inventories, int chestStartIndex, out int amountInChests)
		{
			Entity entity = Entity.Null;
			amountInChests = 0;
			for (int i = 0; i < inventories.Length; i++)
			{
				Entity entity2 = inventories[i];
				if (containedObjectsBufferLookup.HasComponent(entity2))
				{
					int totalAmount = GetTotalAmount(containedObjectsBufferLookup, inventoryBufferLookup, databaseBankCD, entity2, objectID);
					amountInChests += totalAmount;
					if (totalAmount > 0 && entity == Entity.Null && i >= chestStartIndex)
					{
						entity = entity2;
					}
				}
			}
			return entity;
		}

		public static void RepairAllItems(in InventoryHandlerShared inventoryHandlerShared, Entity inventoryEntity, NativeList<Entity> inventoryEntities, Entity craftingEntity, Entity playerEntity, bool reinforce)
		{
			inventoryHandlerShared.containedObjectsBufferLookup.TryGetBuffer(inventoryEntity, out var bufferData);
			for (int i = 0; i < bufferData.Length; i++)
			{
				ContainedObjectsBuffer containedObjectsBuffer = bufferData[i];
				if (containedObjectsBuffer.objectID != ObjectID.None)
				{
					RepairOrReinforce(in inventoryHandlerShared, inventoryEntity, i, containedObjectsBuffer.objectID, inventoryEntities, 1, craftingEntity, playerEntity, reinforce, craftingMaterialsAreNotRequired: true);
				}
			}
		}

		public static void RepairOrReinforce(in InventoryHandlerShared inventoryHandlerShared, Entity inventoryEntity, int index, ObjectID objectID, NativeList<Entity> inventoryEntities, int chestsStartIndex, Entity craftingEntity, Entity playerEntity, bool reinforce, bool craftingMaterialsAreNotRequired = false)
		{
			ContainedObjectsBuffer objectData = inventoryHandlerShared.containedObjectsBufferLookup[inventoryEntity][index];
			if (objectData.objectID != objectID)
			{
				return;
			}
			Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(objectData.objectID, inventoryHandlerShared.databaseBankCD.databaseBankBlob, objectData.variation);
			if (!CanBeRepaired(primaryPrefabEntity, objectData, inventoryHandlerShared.levelEntitiesBufferLookup, inventoryHandlerShared.durabilityLookup, reinforce))
			{
				return;
			}
			ObjectWithAmount recipeInfo = new ObjectWithAmount
			{
				objectID = objectData.objectID,
				amount = objectData.amount
			};
			using NativeList<PugDatabase.MaterialInfoData> nativeList = GetCraftingMaterialInfosForRecipe(in inventoryHandlerShared, recipeInfo, inventoryEntities, chestsStartIndex, isRepairing: true, reinforce, craftingEntity, playerEntity, Allocator.Temp);
			if (!craftingMaterialsAreNotRequired)
			{
				foreach (PugDatabase.MaterialInfoData item in nativeList)
				{
					if (item.amountAvailable < item.amountNeeded)
					{
						return;
					}
				}
				foreach (PugDatabase.MaterialInfoData item2 in nativeList)
				{
					int num = item2.amountNeeded;
					foreach (Entity item3 in inventoryEntities)
					{
						if (inventoryHandlerShared.containedObjectsBufferLookup.HasComponent(item3) && num > 0)
						{
							num -= ConsumeObject(in inventoryHandlerShared, item3, item2.objectID, num);
						}
					}
					if (num != 0)
					{
						Debug.LogError($"Repaired {recipeInfo.objectID} when there wasnt enough {item2.objectID}, missing {num}");
					}
				}
			}
			int num2 = inventoryHandlerShared.durabilityLookup[primaryPrefabEntity].maxDurability;
			if (reinforce)
			{
				num2 = (int)math.round(2f * (float)num2);
			}
			SetAmount(in inventoryHandlerShared, inventoryEntity, index, objectID, num2);
			inventoryHandlerShared.ghostEffectEventBufferLookup[playerEntity].AddToRingBuffer(ref inventoryHandlerShared.ghostEffectEventBufferPointerLookup.GetRefRW(playerEntity).ValueRW, new GhostEffectEventBuffer
			{
				Tick = inventoryHandlerShared.currentTick,
				value = EffectEventExtensions.CreateSingleAudioSFXUI(localOnlyEffect: true, SfxID.metalImpactSmall, 0.7f, 0.6f, 0.1f)
			});
		}

		public static bool CanBeRepaired(Entity itemPrefab, ContainedObjectsBuffer objectData, BufferLookup<LevelEntitiesBuffer> levelEntitiesBufferLookup, ComponentLookup<DurabilityCD> durabilityLookup, bool isReinforcing)
		{
			if (!levelEntitiesBufferLookup.HasComponent(itemPrefab) || !durabilityLookup.TryGetComponent(itemPrefab, out var componentData))
			{
				return false;
			}
			if (isReinforcing || objectData.amount < componentData.maxDurability)
			{
				if (isReinforcing)
				{
					return !((float)objectData.amount >= (float)componentData.maxDurability * 2f);
				}
				return true;
			}
			return false;
		}

		public static NativeList<PugDatabase.MaterialInfoData> GetCraftingMaterialInfosForRecipe(in InventoryHandlerShared inventoryHandlerShared, int index, NativeList<Entity> inventoryEntities, int chestsStartIndex, bool isRepairing, bool isReinforcing, Entity craftingEntity, Entity playerEntity, Allocator allocator)
		{
			ObjectWithAmount recipeInfo = GetRecipeInfo(inventoryHandlerShared.databaseBankCD, index, craftingEntity, inventoryHandlerShared.canCraftObjectsBufferLookup);
			return GetCraftingMaterialInfosForRecipe(in inventoryHandlerShared, recipeInfo, inventoryEntities, chestsStartIndex, isRepairing, isReinforcing, craftingEntity, playerEntity, allocator);
		}

		public static ObjectWithAmount GetRecipeInfo(PugDatabase.DatabaseBankCD databaseBankCD, int index, Entity craftingEntity, BufferLookup<CanCraftObjectsBuffer> canCraftObjectsBufferLookup)
		{
			if (canCraftObjectsBufferLookup.TryGetBuffer(craftingEntity, out var bufferData))
			{
				CanCraftObjectsBuffer canCraftObjectsBuffer = ((bufferData.Length > index) ? bufferData[index] : default(CanCraftObjectsBuffer));
				return GetRecipeInfo(databaseBankCD, canCraftObjectsBuffer.objectID, canCraftObjectsBuffer.amount);
			}
			return default(ObjectWithAmount);
		}

		public static ObjectWithAmount GetRecipeInfo(PugDatabase.DatabaseBankCD databaseBankCD, ObjectID objectId, int amount = 1)
		{
			if (PugDatabase.HasObject(objectId, databaseBankCD.databaseBankBlob))
			{
				return new ObjectWithAmount
				{
					objectID = objectId,
					amount = amount
				};
			}
			return default(ObjectWithAmount);
		}

		public static NativeList<PugDatabase.MaterialInfoData> GetCraftingMaterialInfosForRecipe(in InventoryHandlerShared inventoryHandlerShared, ObjectWithAmount recipeInfo, NativeList<Entity> inventoryEntities, int chestsStartIndex, bool isRepairing, bool isReinforcing, Entity craftingEntity, Entity playerEntity, Allocator allocator)
		{
			return GetCraftingMaterialInfosForRecipe(inventoryHandlerShared.databaseBankCD, inventoryHandlerShared.containedObjectsBufferLookup, inventoryHandlerShared.inventoryLookup, inventoryHandlerShared.anvilLookup, inventoryHandlerShared.objectDataLookup, inventoryHandlerShared.summarizedConditionsBufferLookup, inventoryHandlerShared.durabilityLookup, inventoryHandlerShared.prioritizedRepairMaterialLookup, inventoryHandlerShared.levelLookup, recipeInfo, default(NativeList<ObjectWithAmount>), inventoryEntities, chestsStartIndex, isRepairing, isReinforcing, craftingEntity, playerEntity, allocator);
		}

		public static NativeList<PugDatabase.MaterialInfoData> GetCraftingMaterialInfosForRecipe(PugDatabase.DatabaseBankCD databaseBankCD, BufferLookup<ContainedObjectsBuffer> containedObjectsBufferLookup, BufferLookup<InventoryBuffer> inventoryBufferLookup, ComponentLookup<AnvilCD> anvilLookup, ComponentLookup<ObjectDataCD> objectDataLookup, BufferLookup<SummarizedConditionsBuffer> summarizedConditionsBufferLookup, ComponentLookup<DurabilityCD> durabilityLookup, ComponentLookup<PrioritizedRepairMaterialCD> prioritizedRepairMaterialLookup, ComponentLookup<LevelCD> levelLookup, ObjectWithAmount recipeInfo, NativeList<ObjectWithAmount> cookingIngredientsRequired, NativeList<Entity> inventoryEntities, int chestsStartIndex, bool isRepairing, bool isReinforcing, Entity craftingEntity, Entity playerEntity, Allocator allocator)
		{
			if (recipeInfo.objectID == ObjectID.None)
			{
				return default(NativeList<PugDatabase.MaterialInfoData>);
			}
			ref PugDatabase.EntityObjectInfo entityObjectInfo = ref PugDatabase.GetEntityObjectInfo(recipeInfo.objectID, databaseBankCD.databaseBankBlob);
			NativeList<ObjectWithAmount> objectsRequired = new NativeList<ObjectWithAmount>(entityObjectInfo.requiredObjectsToCraft.Length + 1, Allocator.Temp);
			if (cookingIngredientsRequired.IsCreated)
			{
				for (int i = 0; i < cookingIngredientsRequired.Length; i++)
				{
					ObjectWithAmount objectWithAmount = cookingIngredientsRequired[i];
					objectsRequired.Add(new ObjectWithAmount
					{
						objectID = objectWithAmount.objectID,
						amount = objectWithAmount.amount
					});
				}
			}
			for (int j = 0; j < entityObjectInfo.requiredObjectsToCraft.Length; j++)
			{
				ObjectWithAmount value = entityObjectInfo.requiredObjectsToCraft[j];
				objectsRequired.Add(in value);
			}
			if (isRepairing || isReinforcing)
			{
				int scrapPartsValue = GetScrapPartsValue(databaseBankCD, durabilityLookup, levelLookup, new ObjectDataCD
				{
					objectID = recipeInfo.objectID
				}, salvaging: false);
				if (scrapPartsValue > 0)
				{
					if (!isReinforcing)
					{
						objectsRequired.Clear();
					}
					objectsRequired.Add(new ObjectWithAmount
					{
						objectID = ObjectID.ScrapPart,
						amount = scrapPartsValue
					});
				}
			}
			float anyMaterialCostMultiplier = GetAnyMaterialCostMultiplier(anvilLookup, objectDataLookup, summarizedConditionsBufferLookup, craftingEntity, playerEntity);
			NativeList<PugDatabase.MaterialInfoData> materialInfos = GetMaterialInfos(containedObjectsBufferLookup, inventoryBufferLookup, databaseBankCD, objectsRequired, anyMaterialCostMultiplier, inventoryEntities, chestsStartIndex, allocator);
			if (!isRepairing && !isReinforcing)
			{
				return materialInfos;
			}
			float t = 1f;
			float t2 = 1f;
			float num = 1f;
			Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(recipeInfo.objectID, databaseBankCD.databaseBankBlob);
			if (durabilityLookup.TryGetComponent(primaryPrefabEntity, out var componentData))
			{
				float num2 = componentData.maxDurability;
				t = (float)recipeInfo.amount / num2;
				t2 = math.max(recipeInfo.amount, num2) / (num2 * 2f);
				num = componentData.reinforceCostMultiplier;
			}
			float num3 = math.lerp(1f, 0f, t);
			float num4 = math.lerp(0.5f, 0f, t2);
			num4 *= num;
			materialInfos.Sort();
			NativeList<PugDatabase.MaterialInfoData> result = new NativeList<PugDatabase.MaterialInfoData>(materialInfos.Length + 1, allocator);
			bool flag = false;
			for (int k = 0; k < materialInfos.Length; k++)
			{
				Entity primaryPrefabEntity2 = PugDatabase.GetPrimaryPrefabEntity(materialInfos[k].objectID, databaseBankCD.databaseBankBlob);
				if (materialInfos[k].objectID == ObjectID.ScrapPart)
				{
					result.Add(materialInfos[k]);
				}
				else if (!flag && prioritizedRepairMaterialLookup.HasComponent(primaryPrefabEntity2))
				{
					result.Add(materialInfos[k]);
					flag = true;
				}
			}
			if (!flag)
			{
				for (int l = 0; l < materialInfos.Length; l++)
				{
					if (materialInfos[l].objectID != ObjectID.ScrapPart)
					{
						result.Add(materialInfos[l]);
						break;
					}
				}
			}
			for (int num5 = result.Length - 1; num5 >= 0; num5--)
			{
				if (result[num5].objectID == ObjectID.ScrapPart)
				{
					result.ElementAt(num5).amountNeeded = (int)math.ceil((float)result[num5].amountNeeded * num3);
					if (result[num5].amountNeeded <= 0)
					{
						result.RemoveAt(num5);
					}
				}
				else
				{
					result.ElementAt(num5).amountNeeded = (int)math.max(1f, math.ceil((float)result[num5].amountNeeded * num4));
				}
			}
			materialInfos.Dispose();
			return result;
		}

		public static float GetAnyMaterialCostMultiplier(in InventoryHandlerShared inventoryHandlerShared, Entity craftingEntity, Entity playerEntity)
		{
			return GetAnyMaterialCostMultiplier(inventoryHandlerShared.anvilLookup, inventoryHandlerShared.objectDataLookup, inventoryHandlerShared.summarizedConditionsBufferLookup, craftingEntity, playerEntity);
		}

		public static float GetAnyMaterialCostMultiplier(ComponentLookup<AnvilCD> anvilLookup, ComponentLookup<ObjectDataCD> objectDataLookup, BufferLookup<SummarizedConditionsBuffer> summarizedConditionsBufferLookup, Entity craftingEntity, Entity playerEntity)
		{
			float num = 1f;
			if (anvilLookup.HasComponent(craftingEntity) || (objectDataLookup.TryGetComponent(craftingEntity, out var componentData) && componentData.objectID == ObjectID.SalvageAndRepairStation))
			{
				num -= (float)EntityUtility.GetConditionValue(ConditionID.ReducedAnvilEquipmentCosts, playerEntity, summarizedConditionsBufferLookup) / 100f;
			}
			return num;
		}

		[GenerateTestsForBurstCompatibility]
		public static bool ObjectIsValidToPutInInventory(DynamicBuffer<InventorySlotRequirementBuffer> inventorySlotsRequirements, ObjectCategoryTagsCD objectTagCD, ObjectID objectID, DynamicBuffer<InventoryBuffer> inventoryBuffer, ComponentLookup<OverrideLegendaryForSlotRequirementsCD> overrideAlwaysAllowToBeTrashedLookup, out int indexFulfillingRequirements, PugDatabase.DatabaseBankCD databaseBankCD, int checkSpecificIndexOnly = -1)
		{
			indexFulfillingRequirements = -1;
			if (objectID == ObjectID.None)
			{
				return true;
			}
			bool flag = checkSpecificIndexOnly > -1;
			int num = -1;
			if (flag)
			{
				num = GetInventoryIndex(checkSpecificIndexOnly, inventoryBuffer, out var internalSlotIndex);
				checkSpecificIndexOnly = internalSlotIndex;
			}
			bool result = false;
			for (int i = 0; i < inventoryBuffer.Length; i++)
			{
				if (flag && i != num)
				{
					continue;
				}
				InventoryBuffer inventoryBuffer2 = inventoryBuffer[i];
				if (inventoryBuffer2.cantAddObjectsToInventory)
				{
					continue;
				}
				if (inventorySlotsRequirements.Length == 0)
				{
					return true;
				}
				int num2 = (flag ? checkSpecificIndexOnly : inventoryBuffer2.startIndex);
				int num3 = (flag ? (checkSpecificIndexOnly + 1) : (inventoryBuffer2.startIndex + inventoryBuffer2.size));
				for (int j = num2; j < num3; j++)
				{
					switch (ObjectFulfillsRequirementsAtIndex(objectID, j, i, objectTagCD, inventorySlotsRequirements, overrideAlwaysAllowToBeTrashedLookup, databaseBankCD))
					{
					case SlotRequirementFulfillment.FulfilledRequirement:
						indexFulfillingRequirements = inventoryBuffer2.startIndex + j;
						return true;
					case SlotRequirementFulfillment.NoRequirementFound:
						result = true;
						break;
					}
				}
			}
			return result;
		}

		[GenerateTestsForBurstCompatibility]
		private static SlotRequirementFulfillment ObjectFulfillsRequirementsAtIndex(ObjectID objectID, int slotIndex, int inventoryIndex, ObjectCategoryTagsCD objectTagCD, DynamicBuffer<InventorySlotRequirementBuffer> inventorySlotsRequirements, ComponentLookup<OverrideLegendaryForSlotRequirementsCD> overrideAlwaysAllowToBeTrashedLookup, PugDatabase.DatabaseBankCD databaseBankCD)
		{
			for (int i = 0; i < inventorySlotsRequirements.Length; i++)
			{
				InventorySlotRequirementBuffer inventorySlotRequirementBuffer = inventorySlotsRequirements[i];
				if (inventorySlotRequirementBuffer.inventoryIndex != inventoryIndex || (!inventorySlotRequirementBuffer.requirementAppliesToAllSlots && inventorySlotRequirementBuffer.slotIndex != slotIndex))
				{
					continue;
				}
				if (inventorySlotRequirementBuffer.denyLegendaryRarity)
				{
					Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(objectID, databaseBankCD.databaseBankBlob);
					if (!overrideAlwaysAllowToBeTrashedLookup.HasComponent(primaryPrefabEntity) && PugDatabase.GetEntityObjectInfo(objectID, databaseBankCD.databaseBankBlob).rarity == Rarity.Legendary)
					{
						return SlotRequirementFulfillment.FailedRequirement;
					}
				}
				if (inventorySlotRequirementBuffer.acceptsObjectsWithTags != 0L)
				{
					if (ObjectCategoryTagsCD.HasAnyMatches(inventorySlotRequirementBuffer.acceptsObjectsWithTags, objectTagCD.tagsBitMask))
					{
						return SlotRequirementFulfillment.FulfilledRequirement;
					}
					return SlotRequirementFulfillment.FailedRequirement;
				}
				if (inventorySlotRequirementBuffer.acceptsObjectIds.Length > 0)
				{
					for (int j = 0; j < inventorySlotRequirementBuffer.acceptsObjectIds.Length; j++)
					{
						if (inventorySlotRequirementBuffer.acceptsObjectIds[j] == objectID)
						{
							return SlotRequirementFulfillment.FulfilledRequirement;
						}
					}
					return SlotRequirementFulfillment.FailedRequirement;
				}
				return SlotRequirementFulfillment.NoRequirementFound;
			}
			return SlotRequirementFulfillment.NoRequirementFound;
		}

		[GenerateTestsForBurstCompatibility]
		public static bool HasRoomForObject(in InventoryHandlerShared inventoryHandlerShared, DynamicBuffer<ContainedObjectsBuffer> containedObjectsBuffer, DynamicBuffer<InventoryBuffer> inventoryBuffer, ObjectID objectID, int variation = 0)
		{
			return HasRoomForObject(in inventoryHandlerShared, containedObjectsBuffer, inventoryBuffer, objectID, variation);
		}

		[GenerateTestsForBurstCompatibility]
		public static bool HasRoomForObject(PugDatabase.DatabaseBankCD databaseBankCD, DynamicBuffer<ContainedObjectsBuffer> containedObjectsBuffer, DynamicBuffer<InventoryBuffer> inventoryBuffer, DynamicBuffer<InventorySlotRequirementBuffer> slotRequirementsBuffer, ComponentLookup<OverrideLegendaryForSlotRequirementsCD> overrideAlwaysAllowToBeTrashedLookup, ObjectCategoryTagsCD objectTagCD, ObjectID objectID, int variation = 0)
		{
			bool isStackable = PugDatabase.GetEntityObjectInfo(objectID, databaseBankCD.databaseBankBlob).isStackable;
			bool flag = CheckIfCanOnlyContainOneItemPerSlot(inventoryBuffer);
			for (int i = 0; i < inventoryBuffer.Length; i++)
			{
				InventoryBuffer inventoryBuffer2 = inventoryBuffer[i];
				for (int j = inventoryBuffer2.startIndex; j < inventoryBuffer2.startIndex + inventoryBuffer2.size; j++)
				{
					if (ObjectFulfillsRequirementsAtIndex(objectID, j, i, objectTagCD, slotRequirementsBuffer, overrideAlwaysAllowToBeTrashedLookup, databaseBankCD) != SlotRequirementFulfillment.FailedRequirement)
					{
						ObjectDataCD objectData = containedObjectsBuffer[j].objectData;
						if (objectData.objectID == ObjectID.None || (!flag && isStackable && objectData.objectID == objectID && objectData.variation == variation && objectData.amount < 9999))
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		public static bool HasRoomForObject(in InventoryHandlerShared inventoryHandlerShared, ContainedObjectsBuffer containedObject, Entity objectEntity, int indexToHint, out int firstPos, in DynamicBuffer<ContainedObjectsBuffer> containedObjectsBuffer, in DynamicBuffer<InventorySlotRequirementBuffer> inventorySlotRequirementBuffer, int inventoryStart, int inventorySize, bool canOnlyContainOneItemPerSlot, DynamicBuffer<InventoryBuffer> inventoryBuffer)
		{
			return HasRoomForObject(containedObject, objectEntity, indexToHint, out firstPos, inventoryHandlerShared.objectCategoryTagsLookup, in containedObjectsBuffer, in inventorySlotRequirementBuffer, inventoryHandlerShared.overrideAlwaysAllowToBeTrashedLookup, inventoryStart, inventorySize, canOnlyContainOneItemPerSlot, inventoryHandlerShared.databaseBankCD, inventoryBuffer);
		}

		public static bool HasRoomForObject(ContainedObjectsBuffer containedObject, Entity objectEntity, int indexToHint, out int firstPos, ComponentLookup<ObjectCategoryTagsCD> objectCategoryTagsLookup, in DynamicBuffer<ContainedObjectsBuffer> containedObjectsBuffer, in DynamicBuffer<InventorySlotRequirementBuffer> inventorySlotRequirementBuffer, ComponentLookup<OverrideLegendaryForSlotRequirementsCD> overrideAlwaysAllowToBeTrashedLookup, int inventoryStart, int inventorySize, bool canOnlyContainOneItemPerSlot, PugDatabase.DatabaseBankCD databaseBankCD, DynamicBuffer<InventoryBuffer> inventoryBuffer)
		{
			int num = containedObject.amount;
			firstPos = 0;
			int num2 = inventoryStart + inventorySize - 1;
			bool isStackable = PugDatabase.GetEntityObjectInfo(containedObject.objectID, databaseBankCD.databaseBankBlob, containedObject.variation).isStackable;
			for (int num3 = num2; num3 >= inventoryStart; num3--)
			{
				ContainedObjectsBuffer containedObjectsBuffer2 = containedObjectsBuffer[num3];
				objectCategoryTagsLookup.TryGetComponent(objectEntity, out var componentData);
				if (ObjectIsValidToPutInInventory(inventorySlotRequirementBuffer, componentData, containedObject.objectID, inventoryBuffer, overrideAlwaysAllowToBeTrashedLookup, out var _, databaseBankCD, num3) && (containedObjectsBuffer2.objectID == ObjectID.None || (isStackable && containedObjectsBuffer2.Equals(containedObject) && !canOnlyContainOneItemPerSlot)))
				{
					if (firstPos != indexToHint)
					{
						firstPos = num3;
					}
					num -= 9999 - containedObjectsBuffer2.amount;
				}
			}
			return num <= 0;
		}

		[GenerateTestsForBurstCompatibility]
		public static bool HasObject(in InventoryHandlerShared inventoryHandlerShared, Entity inventory, ObjectID objectID, int amount = 1, int variation = 0)
		{
			return HasObject(inventoryHandlerShared.containedObjectsBufferLookup, inventory, objectID, amount, variation);
		}

		[GenerateTestsForBurstCompatibility]
		public static bool HasObject(BufferLookup<ContainedObjectsBuffer> containedObjectsBufferLookup, Entity inventory, ObjectID objectID, int amount = 1, int variation = 0)
		{
			if (!containedObjectsBufferLookup.HasComponent(inventory))
			{
				return false;
			}
			DynamicBuffer<ContainedObjectsBuffer> dynamicBuffer = containedObjectsBufferLookup[inventory];
			for (int i = 0; i < dynamicBuffer.Length; i++)
			{
				if (dynamicBuffer[i].objectID == objectID && dynamicBuffer[i].variation == variation)
				{
					amount -= dynamicBuffer[i].amount;
				}
			}
			return amount <= 0;
		}

		[GenerateTestsForBurstCompatibility]
		private static int GetAmountToMoveFromInventory(in InventoryHandlerShared inventoryHandlerShared, Entity inventoryFrom, ObjectDataCD objectData, int amount)
		{
			if (PugDatabase.GetEntityObjectInfo(objectData.objectID, inventoryHandlerShared.databaseBankCD.databaseBankBlob).isStackable)
			{
				return math.max(0, math.min(math.min(objectData.amount, amount), 9999));
			}
			return objectData.amount;
		}

		[GenerateTestsForBurstCompatibility]
		private static int GetAmountToMoveToInventory(in InventoryHandlerShared inventoryHandlerShared, Entity inventoryTo, ObjectDataCD objectData, ObjectDataCD objectDataTo, int amount)
		{
			if (PugDatabase.GetEntityObjectInfo(objectData.objectID, inventoryHandlerShared.databaseBankCD.databaseBankBlob).isStackable)
			{
				if (CheckIfCanOnlyContainOneItemPerSlot(inventoryHandlerShared.inventoryLookup[inventoryTo]))
				{
					if (objectDataTo.amount != 0)
					{
						return 0;
					}
					return 1;
				}
				return math.max(0, math.min(math.min(objectData.amount, amount), 9999 - objectDataTo.amount));
			}
			return objectData.amount;
		}

		public static void UpdateInventoryRequirements(in InventoryHandlerShared inventoryHandlerShared, Entity inventoryEntity, ExtraInventoryCD extraInventory, int inventoryIndex)
		{
			if (!inventoryHandlerShared.playerGhostLookup.HasComponent(inventoryEntity) || !inventoryHandlerShared.inventorySlotRequirementBufferLookup.TryGetBuffer(inventoryEntity, out var bufferData))
			{
				return;
			}
			int num = -1;
			for (int i = 0; i < bufferData.Length; i++)
			{
				if (bufferData[i].inventoryIndex == inventoryIndex)
				{
					num = i;
					break;
				}
			}
			if (num == -1)
			{
				bufferData.Add(new InventorySlotRequirementBuffer
				{
					acceptsObjectsWithTags = extraInventory.categoryTagsMask,
					inventoryIndex = inventoryIndex,
					requirementAppliesToAllSlots = true
				});
			}
			else
			{
				InventorySlotRequirementBuffer value = bufferData[num];
				value.acceptsObjectsWithTags = extraInventory.categoryTagsMask;
				bufferData[num] = value;
			}
		}

		public static InventoryBuffer UpdateInventorySize(in InventoryHandlerShared inventoryHandlerShared, Entity inventoryEntity, ExtraInventoryCD extraInventory, float3 position, InventoryBuffer inventory, int inventoryIndex, bool updateWholeInventory)
		{
			DynamicBuffer<ContainedObjectsBuffer> dynamicBuffer = inventoryHandlerShared.containedObjectsBufferLookup[inventoryEntity];
			DynamicBuffer<InventorySlotRequirementBuffer> bufferData;
			bool flag = inventoryHandlerShared.inventorySlotRequirementBufferLookup.TryGetBuffer(inventoryEntity, out bufferData);
			bool flag2 = extraInventory.size >= inventory.extraSize;
			int maxSize = inventory.maxSize;
			inventory.extraSize = extraInventory.size;
			inventory.extraInventoryCategoryTagsMask = extraInventory.categoryTagsMask;
			int size = inventory.size;
			for (int i = inventory.startIndex + ((!updateWholeInventory) ? size : 0); i < inventory.startIndex + maxSize; i++)
			{
				ObjectID objectID = dynamicBuffer[i].objectData.objectID;
				if (objectID == ObjectID.None)
				{
					continue;
				}
				if (flag2)
				{
					Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(objectID, inventoryHandlerShared.databaseBankCD.databaseBankBlob);
					ObjectCategoryTagsCD objectTagCD = inventoryHandlerShared.objectCategoryTagsLookup[primaryPrefabEntity];
					if (flag && ObjectFulfillsRequirementsAtIndex(objectID, i, inventoryIndex, objectTagCD, bufferData, inventoryHandlerShared.overrideAlwaysAllowToBeTrashedLookup, inventoryHandlerShared.databaseBankCD) != SlotRequirementFulfillment.FailedRequirement)
					{
						continue;
					}
				}
				DropItem(in inventoryHandlerShared, inventoryEntity, i, int.MaxValue, position);
			}
			return inventory;
		}

		public static void SetupCookBookRecipe(in InventoryHandlerShared inventoryHandlerShared, Entity craftingEntity, Entity playerEntity, Entity craftingInventory, bool mod1, NativeList<Entity> inventoryEntities, ObjectID objectID, int variation)
		{
			ObjectID primaryIngredientFromVariation = CookedFoodCD.GetPrimaryIngredientFromVariation(variation);
			ObjectID secondaryIngredientFromVariation = CookedFoodCD.GetSecondaryIngredientFromVariation(variation);
			NativeList<ObjectWithAmount> requiredObjectsToCraft = new NativeList<ObjectWithAmount>(2, Allocator.Temp);
			ObjectWithAmount value = new ObjectWithAmount
			{
				objectID = primaryIngredientFromVariation,
				amount = 1
			};
			requiredObjectsToCraft.Add(in value);
			value = new ObjectWithAmount
			{
				objectID = secondaryIngredientFromVariation,
				amount = 1
			};
			requiredObjectsToCraft.Add(in value);
			if (!HasMaterialsInCraftingInventoryToCraftRecipe(in inventoryHandlerShared, craftingEntity, playerEntity, inventoryEntities, requiredObjectsToCraft))
			{
				return;
			}
			DynamicBuffer<ContainedObjectsBuffer> dynamicBuffer = inventoryHandlerShared.containedObjectsBufferLookup[craftingInventory];
			_ = inventoryHandlerShared.inventoryLookup[playerEntity];
			float3 position = inventoryHandlerShared.localTransformLookup[playerEntity].Position;
			ContainedObjectsBuffer containedObjectsBuffer = dynamicBuffer[0];
			if (containedObjectsBuffer.objectID != primaryIngredientFromVariation && containedObjectsBuffer.objectID != ObjectID.None)
			{
				MoveAllToOrDrop(in inventoryHandlerShared, craftingInventory, 0, playerEntity, 0, -1, position);
				containedObjectsBuffer.objectData.amount = 0;
			}
			ContainedObjectsBuffer containedObjectsBuffer2 = dynamicBuffer[1];
			if (containedObjectsBuffer2.objectID != secondaryIngredientFromVariation && containedObjectsBuffer2.objectID != ObjectID.None)
			{
				MoveAllToOrDrop(in inventoryHandlerShared, craftingEntity, 1, playerEntity, 0, -1, position);
				containedObjectsBuffer2.objectData.amount = 0;
			}
			inventoryHandlerShared.craftingLookup.TryGetComponent(craftingEntity, out var componentData);
			int outputSlotIndex = componentData.outputSlotIndex;
			ContainedObjectsBuffer containedObjectsBuffer3 = dynamicBuffer[outputSlotIndex];
			if (containedObjectsBuffer3.objectID != objectID || containedObjectsBuffer3.variation != variation)
			{
				IncreaseCookingSkillAndSpawnExtraFoodIfWeShould(in inventoryHandlerShared, containedObjectsBuffer3.objectData, containedObjectsBuffer3.amount, playerEntity, 0, position, playerEntity);
				MoveAllToOrDrop(in inventoryHandlerShared, craftingEntity, outputSlotIndex, playerEntity, 0, -1, position);
			}
			int num = GetAmountOfAvailableMaterialsToUse(in inventoryHandlerShared, primaryIngredientFromVariation, inventoryEntities);
			int num2 = GetAmountOfAvailableMaterialsToUse(in inventoryHandlerShared, secondaryIngredientFromVariation, inventoryEntities);
			if (primaryIngredientFromVariation == secondaryIngredientFromVariation)
			{
				num2 /= 2;
				num -= num2;
			}
			int b = ((!mod1) ? 1 : 10);
			int num3 = Mathf.Min(num, b);
			if (containedObjectsBuffer.amount < containedObjectsBuffer2.amount)
			{
				num3 = Mathf.Min(num3, containedObjectsBuffer2.amount - containedObjectsBuffer.amount);
			}
			else if (containedObjectsBuffer.amount > containedObjectsBuffer2.amount)
			{
				num3 = 0;
			}
			int num4 = Mathf.Min(num2, b);
			if (containedObjectsBuffer2.amount < containedObjectsBuffer.amount)
			{
				num4 = Mathf.Min(num4, containedObjectsBuffer.amount - containedObjectsBuffer2.amount);
			}
			else if (containedObjectsBuffer2.amount > containedObjectsBuffer.amount)
			{
				num4 = 0;
			}
			if (containedObjectsBuffer.amount == containedObjectsBuffer2.amount)
			{
				if (num3 > num4)
				{
					num3 = num4;
				}
				else if (num4 > num3)
				{
					num4 = num3;
				}
			}
			if (num3 > 0)
			{
				FindAndMoveTo(in inventoryHandlerShared, new ObjectDataCD
				{
					objectID = primaryIngredientFromVariation
				}, craftingEntity, 0, 1, inventoryEntities, num3, 0);
			}
			if (num4 > 0)
			{
				FindAndMoveTo(in inventoryHandlerShared, new ObjectDataCD
				{
					objectID = secondaryIngredientFromVariation
				}, craftingEntity, 0, 1, inventoryEntities, num4, 1);
			}
		}

		private static int GetAmountOfAvailableMaterialsToUse(in InventoryHandlerShared inventoryHandlerShared, ObjectID material, NativeList<Entity> inventoryEntities)
		{
			int num = 0;
			foreach (Entity item in inventoryEntities)
			{
				if (inventoryHandlerShared.containedObjectsBufferLookup.HasComponent(item))
				{
					num += GetTotalAmount(in inventoryHandlerShared, item, material);
				}
			}
			return num;
		}

		public static bool HasMaterialsInCraftingInventoryToCraftRecipe(in InventoryHandlerShared inventoryHandlerShared, Entity craftingEntity, Entity playerEntity, NativeList<Entity> inventoryEntities, NativeList<ObjectWithAmount> requiredObjectsToCraft, int multiplier = 1)
		{
			return HasMaterialsInCraftingInventoryToCraftRecipe(inventoryHandlerShared.containedObjectsBufferLookup, inventoryHandlerShared.inventoryLookup, inventoryHandlerShared.databaseBankCD, inventoryHandlerShared.anvilLookup, inventoryHandlerShared.objectDataLookup, inventoryHandlerShared.summarizedConditionsBufferLookup, craftingEntity, playerEntity, inventoryEntities, requiredObjectsToCraft, multiplier);
		}

		public static bool HasMaterialsInCraftingInventoryToCraftRecipe(BufferLookup<ContainedObjectsBuffer> containedObjectsBufferLookup, BufferLookup<InventoryBuffer> inventoryBufferLookup, PugDatabase.DatabaseBankCD databaseBankCD, ComponentLookup<AnvilCD> anvilLookup, ComponentLookup<ObjectDataCD> objectDataLookup, BufferLookup<SummarizedConditionsBuffer> summarizedConditionsBufferLookup, Entity craftingEntity, Entity playerEntity, NativeList<Entity> inventoryEntities, NativeList<ObjectWithAmount> requiredObjectsToCraft, int multiplier = 1)
		{
			float anyMaterialCostMultiplier = GetAnyMaterialCostMultiplier(anvilLookup, objectDataLookup, summarizedConditionsBufferLookup, craftingEntity, playerEntity);
			for (int i = 0; i < requiredObjectsToCraft.Length; i++)
			{
				ObjectID objectID = requiredObjectsToCraft[i].objectID;
				int num = (int)math.max(1f, math.round((float)requiredObjectsToCraft[i].amount * anyMaterialCostMultiplier)) * multiplier;
				int num2 = 0;
				foreach (Entity item in inventoryEntities)
				{
					if (containedObjectsBufferLookup.HasComponent(item))
					{
						num2 += GetTotalAmount(containedObjectsBufferLookup, inventoryBufferLookup, databaseBankCD, item, objectID);
					}
				}
				if (num2 < num)
				{
					return false;
				}
			}
			return true;
		}

		public static void FindAndMoveTo(in InventoryHandlerShared inventoryHandlerShared, ObjectDataCD objectData, Entity moveToInventory, int moveToStartIndex, int moveToSize, NativeList<Entity> inventoriesToMoveFrom, int amount = 1, int indexToHint = -1)
		{
			int num = ((indexToHint != -1 || moveToStartIndex == 0) ? indexToHint : 0);
			int num2 = amount;
			foreach (Entity item in inventoriesToMoveFrom)
			{
				if (!inventoryHandlerShared.inventoryLookup.TryGetBuffer(item, out var bufferData) || !inventoryHandlerShared.containedObjectsBufferLookup.TryGetBuffer(item, out var bufferData2))
				{
					continue;
				}
				for (int i = 0; i < bufferData.Length; i++)
				{
					InventoryBuffer inventoryBuffer = bufferData[i];
					for (int j = inventoryBuffer.startIndex; j < inventoryBuffer.startIndex + inventoryBuffer.size; j++)
					{
						if (bufferData2[j].objectID == objectData.objectID && bufferData2[j].variation == objectData.variation)
						{
							int num3 = math.min(num2, bufferData2[j].amount);
							num2 -= num3;
							MoveAmount(in inventoryHandlerShared, item, j, moveToInventory, moveToStartIndex + num, -1, num3);
							if (num2 <= 0)
							{
								return;
							}
						}
					}
				}
			}
		}

		public static void IncreaseCookingSkillAndSpawnExtraFoodIfWeShould(in InventoryHandlerShared inventoryHandlerShared, ObjectDataCD food, int amount, Entity otherInventory, int index, float3 dropPosition, Entity playerEntity)
		{
			if (amount <= 0)
			{
				return;
			}
			ref PugDatabase.EntityObjectInfo entityObjectInfo = ref PugDatabase.GetEntityObjectInfo(food.objectID, inventoryHandlerShared.databaseBankCD.databaseBankBlob);
			Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(food.objectID, inventoryHandlerShared.databaseBankCD.databaseBankBlob, food.variation);
			if (entityObjectInfo.objectID == ObjectID.None || !inventoryHandlerShared.cookedFoodLookup.HasComponent(primaryPrefabEntity))
			{
				return;
			}
			PlayerController.AddSkill(playerEntity, SkillID.Cooking, amount, inventoryHandlerShared.ecb, inventoryHandlerShared.isServer);
			float num = (float)EntityUtility.GetConditionEffectValue(ConditionEffect.ChanceToGainExtraCookedFood, playerEntity, inventoryHandlerShared.summarizedConditionsEffectsBufferLookup) / 1000f;
			float num2 = (float)EntityUtility.GetConditionValue(ConditionID.ChanceForExtraCookedFoodToBeRare, playerEntity, inventoryHandlerShared.summarizedConditionsBufferLookup) / 100f;
			ObjectID primaryIngredientFromVariation = CookedFoodCD.GetPrimaryIngredientFromVariation(food.variation);
			ObjectID secondaryIngredientFromVariation = CookedFoodCD.GetSecondaryIngredientFromVariation(food.variation);
			bool flag = false;
			Entity primaryPrefabEntity2 = PugDatabase.GetPrimaryPrefabEntity(primaryIngredientFromVariation, inventoryHandlerShared.databaseBankCD.databaseBankBlob);
			Entity primaryPrefabEntity3 = PugDatabase.GetPrimaryPrefabEntity(secondaryIngredientFromVariation, inventoryHandlerShared.databaseBankCD.databaseBankBlob);
			ref PugDatabase.EntityObjectInfo entityObjectInfo2 = ref PugDatabase.GetEntityObjectInfo(primaryIngredientFromVariation, inventoryHandlerShared.databaseBankCD.databaseBankBlob);
			ref PugDatabase.EntityObjectInfo entityObjectInfo3 = ref PugDatabase.GetEntityObjectInfo(secondaryIngredientFromVariation, inventoryHandlerShared.databaseBankCD.databaseBankBlob);
			if (inventoryHandlerShared.flowerLookup.HasComponent(primaryPrefabEntity2))
			{
				flag = entityObjectInfo2.rarity == Rarity.Rare;
			}
			if (!flag && inventoryHandlerShared.flowerLookup.HasComponent(primaryPrefabEntity3))
			{
				flag = entityObjectInfo3.rarity == Rarity.Rare;
			}
			if (!flag && (entityObjectInfo2.rarity == Rarity.Legendary || entityObjectInfo3.rarity == Rarity.Legendary))
			{
				flag = true;
			}
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			ref RandomCD valueRW = ref inventoryHandlerShared.randomLookup.GetRefRW(playerEntity).ValueRW;
			for (int i = 0; i < amount; i++)
			{
				if (!(valueRW.Value.NextFloat() < num))
				{
					continue;
				}
				if (valueRW.Value.NextFloat() < num2)
				{
					if (flag)
					{
						num5++;
					}
					else
					{
						num4++;
					}
				}
				else if (flag)
				{
					num4++;
				}
				else
				{
					num3++;
				}
			}
			if (!inventoryHandlerShared.cookedFoodLookup.TryGetComponent(primaryPrefabEntity, out var componentData))
			{
				return;
			}
			DynamicBuffer<GhostEffectEventBuffer> buffer = inventoryHandlerShared.ghostEffectEventBufferLookup[playerEntity];
			GhostEffectEventBufferPointerCD pointer = inventoryHandlerShared.ghostEffectEventBufferPointerLookup.GetRefRW(playerEntity).ValueRW;
			if (num3 > 0)
			{
				CreateObject(in inventoryHandlerShared, otherInventory, index, food.objectID, num3, dropPosition, food.variation);
				GhostEffectEventBuffer item = new GhostEffectEventBuffer
				{
					Tick = inventoryHandlerShared.currentTick,
					value = EffectEventExtensions.CreateInfoTextItemAndAmount(ChatWindow.MessageTextType.AdditionalItemGained, food.objectID, food.variation, num3, Rarity.Uncommon)
				};
				buffer.AddToRingBuffer(ref pointer, in item);
			}
			if (num4 > 0)
			{
				ObjectID rareVersion = componentData.rareVersion;
				Entity primaryPrefabEntity4 = PugDatabase.GetPrimaryPrefabEntity(rareVersion, inventoryHandlerShared.databaseBankCD.databaseBankBlob);
				if (rareVersion != ObjectID.None && inventoryHandlerShared.cookedFoodLookup.HasComponent(primaryPrefabEntity4))
				{
					food.objectID = rareVersion;
					CreateObject(in inventoryHandlerShared, otherInventory, index, rareVersion, num4, dropPosition, food.variation);
					GhostEffectEventBuffer item = new GhostEffectEventBuffer
					{
						Tick = inventoryHandlerShared.currentTick,
						value = EffectEventExtensions.CreateInfoTextItemAndAmount(ChatWindow.MessageTextType.AdditionalItemGained, food.objectID, food.variation, num4, Rarity.Rare)
					};
					buffer.AddToRingBuffer(ref pointer, in item);
				}
			}
			if (num5 > 0)
			{
				ObjectID epicVersion = componentData.epicVersion;
				Entity primaryPrefabEntity5 = PugDatabase.GetPrimaryPrefabEntity(epicVersion, inventoryHandlerShared.databaseBankCD.databaseBankBlob);
				if (epicVersion != ObjectID.None && inventoryHandlerShared.cookedFoodLookup.HasComponent(primaryPrefabEntity5))
				{
					food.objectID = epicVersion;
					CreateObject(in inventoryHandlerShared, otherInventory, index, epicVersion, num5, dropPosition, food.variation);
					GhostEffectEventBuffer item = new GhostEffectEventBuffer
					{
						Tick = inventoryHandlerShared.currentTick,
						value = EffectEventExtensions.CreateInfoTextItemAndAmount(ChatWindow.MessageTextType.AdditionalItemGained, food.objectID, food.variation, num5, Rarity.Epic)
					};
					buffer.AddToRingBuffer(ref pointer, in item);
				}
			}
		}

		public static void ResetSkillTalentTree(in InventoryHandlerShared inventoryHandlerShared, Entity playerEntity, SkillID currentShowingSkillTreeID, bool forceReset)
		{
			if (forceReset || CanResetSkillTalents(in inventoryHandlerShared, playerEntity, currentShowingSkillTreeID))
			{
				ref SkillTalentTreeBlob skillTalentTree = ref inventoryHandlerShared.skillTalentsTableCD.GetSkillTalentTree(currentShowingSkillTreeID);
				for (int i = 0; i < skillTalentTree.skillTalents.Length; i++)
				{
					ConditionData conditionDataForSkillTalent = skillTalentTree.GetConditionDataForSkillTalent(i, 0);
					ConditionData conditionData = new ConditionData
					{
						conditionID = conditionDataForSkillTalent.conditionID,
						value = conditionDataForSkillTalent.value
					};
					EntityUtility.SetSkillTalentCondition(playerEntity, conditionData, inventoryHandlerShared.skillTalentConditionsBufferLookup);
				}
				if (inventoryHandlerShared.isServer)
				{
					Entity e = inventoryHandlerShared.ecb.CreateEntity();
					inventoryHandlerShared.ecb.AddComponent(e, new SendRpcCommandRequest
					{
						TargetConnection = inventoryHandlerShared.playerGhostLookup[playerEntity].connection
					});
					inventoryHandlerShared.ecb.AddComponent(e, new Rpc
					{
						command = Command.ResetSkillTalentTree,
						entity0 = playerEntity,
						int0 = (int)currentShowingSkillTreeID
					});
				}
				if (!forceReset)
				{
					inventoryHandlerShared.inventoryLookup.TryGetBuffer(playerEntity, out var _);
					DestroyUpToAmountOfEntity(in inventoryHandlerShared, playerEntity, 0, -1, ObjectID.AncientCoin, 200);
					DynamicBuffer<GhostEffectEventBuffer> buffer = inventoryHandlerShared.ghostEffectEventBufferLookup[playerEntity];
					ref GhostEffectEventBufferPointerCD valueRW = ref inventoryHandlerShared.ghostEffectEventBufferPointerLookup.GetRefRW(playerEntity).ValueRW;
					GhostEffectEventBuffer item = new GhostEffectEventBuffer
					{
						Tick = inventoryHandlerShared.currentTick,
						value = EffectEventExtensions.CreateSingleAudioSFX(localOnlyEffect: true, SfxID.coin, playerEntity, 0.9f, 1.2f, 0.1f, useSpatialSound: false)
					};
					buffer.AddToRingBuffer(ref valueRW, in item);
				}
			}
		}

		public static bool CanResetSkillTalents(in InventoryHandlerShared inventoryHandlerShared, Entity inventoryEntity, SkillID currentShowingSkillTreeID)
		{
			return CanResetSkillTalents(inventoryEntity, currentShowingSkillTreeID, inventoryHandlerShared.inventoryLookup, inventoryHandlerShared.containedObjectsBufferLookup, inventoryHandlerShared.skillTalentConditionsBufferLookup, inventoryHandlerShared.skillTalentsTableCD, inventoryHandlerShared.databaseBankCD);
		}

		public static bool CanResetSkillTalents(Entity playerEntity, SkillID currentShowingSkillTreeID, BufferLookup<InventoryBuffer> inventoryBufferLookup, BufferLookup<ContainedObjectsBuffer> containedObjectsBufferLookup, BufferLookup<SkillTalentConditionsBuffer> skillTalentConditionsBufferLookup, SkillTalentsTableCD skillTalentsTableCD, PugDatabase.DatabaseBankCD databaseBankCD)
		{
			if (!HasPlacedAnySkillTalentPoints(playerEntity, currentShowingSkillTreeID, skillTalentConditionsBufferLookup, skillTalentsTableCD))
			{
				return false;
			}
			return GetTotalAmount(containedObjectsBufferLookup, inventoryBufferLookup, databaseBankCD, playerEntity, ObjectID.AncientCoin) >= 200;
		}

		private static bool HasPlacedAnySkillTalentPoints(Entity playerEntity, SkillID currentShowingSkillTreeID, BufferLookup<SkillTalentConditionsBuffer> skillTalentConditionsBufferLookup, SkillTalentsTableCD skillTalentsTableCD)
		{
			if (!skillTalentConditionsBufferLookup.TryGetBuffer(playerEntity, out var bufferData))
			{
				return false;
			}
			ref SkillTalentTreeBlob skillTalentTree = ref skillTalentsTableCD.GetSkillTalentTree(currentShowingSkillTreeID);
			for (int i = 0; i < skillTalentTree.skillTalents.Length; i++)
			{
				ConditionData conditionDataForSkillTalent = skillTalentTree.GetConditionDataForSkillTalent(i, 0);
				for (int j = 0; j < bufferData.Length; j++)
				{
					if (bufferData[j].conditionData.conditionID == conditionDataForSkillTalent.conditionID)
					{
						return true;
					}
				}
			}
			return false;
		}

		public static void ResetPetTalentTree(in InventoryHandlerShared inventoryHandlerShared, Entity playerEntity, bool forceReset)
		{
			if (forceReset || CanResetPetTalents(playerEntity, inventoryHandlerShared.petOwnerLookup, inventoryHandlerShared.inventoryLookup, inventoryHandlerShared.containedObjectsBufferLookup, inventoryHandlerShared.petTalentBuffer, inventoryHandlerShared.inventoryAuxDataSystemDataCD, inventoryHandlerShared.databaseBankCD))
			{
				ContainedObjectsBuffer containedPetObjectData = GetContainedPetObjectData(inventoryHandlerShared.petOwnerLookup, inventoryHandlerShared.containedObjectsBufferLookup, playerEntity);
				inventoryHandlerShared.petOwnerLookup.TryGetComponent(playerEntity, out var componentData);
				ResetPetTalentPoints(in inventoryHandlerShared, playerEntity, componentData.SlotIndex, containedPetObjectData.objectID);
				if (!forceReset)
				{
					inventoryHandlerShared.inventoryLookup.TryGetBuffer(playerEntity, out var _);
					DestroyUpToAmountOfEntity(in inventoryHandlerShared, playerEntity, 0, -1, ObjectID.AncientCoin, 200);
					DynamicBuffer<GhostEffectEventBuffer> buffer = inventoryHandlerShared.ghostEffectEventBufferLookup[playerEntity];
					ref GhostEffectEventBufferPointerCD valueRW = ref inventoryHandlerShared.ghostEffectEventBufferPointerLookup.GetRefRW(playerEntity).ValueRW;
					GhostEffectEventBuffer item = new GhostEffectEventBuffer
					{
						Tick = inventoryHandlerShared.currentTick,
						value = EffectEventExtensions.CreateSingleAudioSFX(localOnlyEffect: true, SfxID.coin, playerEntity, 0.9f, 1.2f, 0.1f, useSpatialSound: false)
					};
					buffer.AddToRingBuffer(ref valueRW, in item);
				}
			}
		}

		private static ContainedObjectsBuffer GetContainedPetObjectData(ComponentLookup<PetOwnerCD> petOwnerLookup, BufferLookup<ContainedObjectsBuffer> containedObjectsBufferLookup, Entity inventoryEntity)
		{
			petOwnerLookup.TryGetComponent(inventoryEntity, out var componentData);
			containedObjectsBufferLookup.TryGetBuffer(inventoryEntity, out var bufferData);
			return bufferData[componentData.SlotIndex];
		}

		public static bool CanResetPetTalents(Entity playerEntity, ComponentLookup<PetOwnerCD> petOwnerLookup, BufferLookup<InventoryBuffer> inventoryBufferLookup, BufferLookup<ContainedObjectsBuffer> containedObjectsBufferLookup, BufferLookup<PetTalentBuffer> petTalentBuffer, InventoryAuxDataSystemDataCD inventoryAuxDataSystemDataCD, PugDatabase.DatabaseBankCD databaseBankCD)
		{
			if (!HasPlacedAnyPetTalentPoints(playerEntity, petOwnerLookup, containedObjectsBufferLookup, petTalentBuffer, inventoryAuxDataSystemDataCD))
			{
				return false;
			}
			return GetTotalAmount(containedObjectsBufferLookup, inventoryBufferLookup, databaseBankCD, playerEntity, ObjectID.AncientCoin) >= 200;
		}

		public static void ResetPetTalentPoints(in InventoryHandlerShared inventoryHandlerShared, Entity inventory, int index, ObjectID objectID)
		{
			int auxDataIndex = GetAuxDataIndex(inventoryHandlerShared.containedObjectsBufferLookup, inventory, index, objectID);
			if (!inventoryHandlerShared.inventoryAuxDataSystemDataCD.GetAccessor().TryGetBuffer(auxDataIndex, inventoryHandlerShared.petTalentBuffer, out var buffer))
			{
				return;
			}
			Entity entity;
			uint typeHash;
			UnsafeList<Entity> lookup;
			bool flag = inventoryHandlerShared.inventoryAuxDataSystemDataCD.TryGetEntity<PetTalentBuffer>(auxDataIndex, out entity, out typeHash, out lookup) && inventoryHandlerShared.simulateLookup.HasComponent(entity) && inventoryHandlerShared.simulateLookup.IsComponentEnabled(entity);
			if (buffer.IsCreated && flag)
			{
				for (int i = 0; i < buffer.Length; i++)
				{
					PetTalentBuffer value = buffer[i];
					value.points = 0;
					buffer[i] = value;
				}
			}
		}

		public static void SetPetTalentPoints(in InventoryHandlerShared inventoryHandlerShared, Entity inventory, int index, ObjectID objectID, int talentIndex, int points)
		{
			int auxDataIndex = GetAuxDataIndex(inventoryHandlerShared.containedObjectsBufferLookup, inventory, index, objectID);
			if (inventoryHandlerShared.inventoryAuxDataSystemDataCD.GetAccessor().TryGetBuffer(auxDataIndex, inventoryHandlerShared.petTalentBuffer, out var buffer))
			{
				Entity entity;
				uint typeHash;
				UnsafeList<Entity> lookup;
				bool flag = inventoryHandlerShared.inventoryAuxDataSystemDataCD.TryGetEntity<PetTalentBuffer>(auxDataIndex, out entity, out typeHash, out lookup) && inventoryHandlerShared.simulateLookup.HasComponent(entity) && inventoryHandlerShared.simulateLookup.IsComponentEnabled(entity);
				if (buffer.IsCreated && flag && buffer.Length > talentIndex)
				{
					PetTalentBuffer value = buffer[talentIndex];
					value.points = points;
					buffer[talentIndex] = value;
				}
			}
		}

		public static void ActivateRecipeSlot(in InventoryHandlerShared inventoryHandlerShared, Entity craftingEntity, Entity playerEntity, NativeList<Entity> inventoryEntities, int multiplier, bool mod1, int recipeIndex)
		{
			ObjectWithAmount recipeInfo = GetRecipeInfo(inventoryHandlerShared.databaseBankCD, recipeIndex, craftingEntity, inventoryHandlerShared.canCraftObjectsBufferLookup);
			if (recipeInfo.objectID == ObjectID.None)
			{
				return;
			}
			ref PugDatabase.EntityObjectInfo entityObjectInfo = ref PugDatabase.GetEntityObjectInfo(recipeInfo.objectID, inventoryHandlerShared.databaseBankCD.databaseBankBlob);
			NativeList<ObjectWithAmount> requiredObjectsToCraft = new NativeList<ObjectWithAmount>(entityObjectInfo.requiredObjectsToCraft.Length, Allocator.Temp);
			for (int i = 0; i < entityObjectInfo.requiredObjectsToCraft.Length; i++)
			{
				requiredObjectsToCraft.Add(new ObjectWithAmount
				{
					objectID = entityObjectInfo.requiredObjectsToCraft[i].objectID,
					amount = entityObjectInfo.requiredObjectsToCraft[i].amount
				});
			}
			if (requiredObjectsToCraft.Length == 1 && HasMaterialsInCraftingInventoryToCraftRecipe(in inventoryHandlerShared, craftingEntity, playerEntity, inventoryEntities, requiredObjectsToCraft, multiplier))
			{
				float3 position = inventoryHandlerShared.localTransformLookup[playerEntity].Position;
				ObjectWithAmount objectWithAmount = requiredObjectsToCraft[0];
				DynamicBuffer<ContainedObjectsBuffer> dynamicBuffer = inventoryHandlerShared.containedObjectsBufferLookup[craftingEntity];
				ContainedObjectsBuffer containedObjectsBuffer = dynamicBuffer[0];
				if (containedObjectsBuffer.objectID != ObjectID.None && containedObjectsBuffer.objectID != objectWithAmount.objectID)
				{
					MoveAllToOrDrop(in inventoryHandlerShared, craftingEntity, 0, playerEntity, 0, -1, position);
				}
				inventoryHandlerShared.craftingLookup.TryGetComponent(craftingEntity, out var componentData);
				ContainedObjectsBuffer containedObjectsBuffer2 = dynamicBuffer[componentData.outputSlotIndex];
				if (containedObjectsBuffer2.objectID != ObjectID.None && containedObjectsBuffer2.objectID != recipeInfo.objectID)
				{
					MoveAllToOrDrop(in inventoryHandlerShared, craftingEntity, componentData.outputSlotIndex, playerEntity, 0, -1, position);
				}
				int amount = (mod1 ? (requiredObjectsToCraft[0].amount * 10) : requiredObjectsToCraft[0].amount);
				FindAndMoveTo(in inventoryHandlerShared, new ObjectDataCD
				{
					objectID = objectWithAmount.objectID
				}, craftingEntity, 0, -1, inventoryEntities, amount, 0);
			}
		}

		private static bool HasPlacedAnyPetTalentPoints(Entity playerEntity, ComponentLookup<PetOwnerCD> petOwnerLookup, BufferLookup<ContainedObjectsBuffer> containedObjectsBufferLookup, BufferLookup<PetTalentBuffer> petTalentBuffer, InventoryAuxDataSystemDataCD inventoryAuxDataSystemDataCD)
		{
			ContainedObjectsBuffer containedPetObjectData = GetContainedPetObjectData(petOwnerLookup, containedObjectsBufferLookup, playerEntity);
			petOwnerLookup.TryGetComponent(playerEntity, out var componentData);
			int slotIndex = componentData.SlotIndex;
			ObjectID objectID = containedPetObjectData.objectID;
			int auxDataIndex = GetAuxDataIndex(containedObjectsBufferLookup, playerEntity, slotIndex, objectID);
			if (!inventoryAuxDataSystemDataCD.GetAccessor().TryGetBuffer(auxDataIndex, petTalentBuffer, out var buffer))
			{
				return false;
			}
			Entity entity;
			uint typeHash;
			UnsafeList<Entity> lookup;
			bool flag = inventoryAuxDataSystemDataCD.TryGetEntity<PetTalentBuffer>(auxDataIndex, out entity, out typeHash, out lookup);
			if (!buffer.IsCreated || !flag)
			{
				return false;
			}
			for (int i = 0; i < buffer.Length; i++)
			{
				if (buffer[i].points != 0)
				{
					return true;
				}
			}
			return false;
		}

		public static int DestroyUpToAmountOfEntity(in InventoryHandlerShared inventoryHandlerShared, Entity inventoryEntity, int startIndex, int endIndex, ObjectID objectID, int amount)
		{
			DynamicBuffer<ContainedObjectsBuffer> dynamicBuffer = inventoryHandlerShared.containedObjectsBufferLookup[inventoryEntity];
			int num = amount;
			bool flag = PugDatabase.AmountIsDurabilityOrFullnessOrXp(inventoryHandlerShared.databaseBankCD, inventoryHandlerShared.durabilityLookup, inventoryHandlerShared.fullnessLookup, inventoryHandlerShared.petLookup, objectID);
			if (endIndex == -1)
			{
				endIndex = dynamicBuffer.Length;
			}
			for (int i = startIndex; i < endIndex; i++)
			{
				if (num <= 0)
				{
					break;
				}
				ContainedObjectsBuffer containedObjectsBuffer = dynamicBuffer[i];
				if (containedObjectsBuffer.objectID != objectID)
				{
					continue;
				}
				if (flag)
				{
					ConsumeEntityAt(in inventoryHandlerShared, inventoryEntity, i, containedObjectsBuffer.amount, destroy: true, default(float3));
					num--;
					continue;
				}
				if (containedObjectsBuffer.amount >= num)
				{
					ConsumeEntityAt(in inventoryHandlerShared, inventoryEntity, i, num, destroy: true, default(float3));
					return 0;
				}
				num -= containedObjectsBuffer.amount;
				ConsumeEntityAt(in inventoryHandlerShared, inventoryEntity, i, containedObjectsBuffer.amount, destroy: true, default(float3));
			}
			return num;
		}

		public static void TryReplaceBrokenObject(in InventoryHandlerShared inventoryHandlerShared, Entity inventoryEntity, int brokenItemIndex)
		{
			DynamicBuffer<ContainedObjectsBuffer> containedObjectsBuffers = inventoryHandlerShared.containedObjectsBufferLookup[inventoryEntity];
			ContainedObjectsBuffer containedObjectsBuffer = containedObjectsBuffers[brokenItemIndex];
			ref PugDatabase.EntityObjectInfo entityObjectInfo = ref PugDatabase.GetEntityObjectInfo(containedObjectsBuffer.objectID, inventoryHandlerShared.databaseBankCD.databaseBankBlob, containedObjectsBuffer.variation);
			if (entityObjectInfo.objectID != ObjectID.None)
			{
				int num = FindFirstNonBrokenOccurenceOfObjectType(in inventoryHandlerShared, entityObjectInfo.objectType, containedObjectsBuffers, brokenItemIndex);
				if (num >= 0)
				{
					Swap(in inventoryHandlerShared, inventoryEntity, inventoryEntity, brokenItemIndex, num);
				}
			}
		}

		private static int FindFirstNonBrokenOccurenceOfObjectType(in InventoryHandlerShared inventoryHandlerShared, ObjectType objectType, DynamicBuffer<ContainedObjectsBuffer> containedObjectsBuffers, int excludeIndex = -1)
		{
			for (int i = 0; i < containedObjectsBuffers.Length; i++)
			{
				if (containedObjectsBuffers[i].objectID != ObjectID.None && containedObjectsBuffers[i].amount > 0 && i != excludeIndex && PugDatabase.GetEntityObjectInfo(containedObjectsBuffers[i].objectID, inventoryHandlerShared.databaseBankCD.databaseBankBlob).objectType == objectType)
				{
					return i;
				}
			}
			return -1;
		}

		public static int FindFirstOccurenceOfObject(ObjectID objectID, DynamicBuffer<ContainedObjectsBuffer> containedObjectsBuffers, PugDatabase.DatabaseBankCD databaseBankCD, int excludeIndex = -1)
		{
			for (int i = 0; i < containedObjectsBuffers.Length; i++)
			{
				if (containedObjectsBuffers[i].objectID != ObjectID.None && i != excludeIndex && PugDatabase.GetEntityObjectInfo(containedObjectsBuffers[i].objectID, databaseBankCD.databaseBankBlob).objectID == objectID)
				{
					return i;
				}
			}
			return -1;
		}

		public static void MoveAllToOrDrop(in InventoryHandlerShared inventoryHandlerShared, Entity ourInventoryEntity, int indexFrom, Entity otherInventoryEntity, int otherStartIndex, int otherEndIndex, Vector3 position, int indexToHint = -1)
		{
			DynamicBuffer<InventoryBuffer> inventoryBuffer = inventoryHandlerShared.inventoryLookup[otherInventoryEntity];
			DynamicBuffer<ContainedObjectsBuffer> dynamicBuffer = inventoryHandlerShared.containedObjectsBufferLookup[ourInventoryEntity];
			DynamicBuffer<ContainedObjectsBuffer> containedObjectsBuffers = inventoryHandlerShared.containedObjectsBufferLookup[otherInventoryEntity];
			ref ContainedObjectsBuffer reference = ref dynamicBuffer.ElementAt(indexFrom);
			DynamicBuffer<InventorySlotRequirementBuffer> inventorySlotsRequirements = inventoryHandlerShared.inventorySlotRequirementBufferLookup[otherInventoryEntity];
			Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(reference.objectID, inventoryHandlerShared.databaseBankCD.databaseBankBlob, reference.variation);
			if (indexToHint != -1 && HasRoomForObjectAt(in inventoryHandlerShared, inventoryBuffer, containedObjectsBuffers, inventorySlotsRequirements, reference, primaryPrefabEntity, indexToHint, out var amount))
			{
				TryMove(in inventoryHandlerShared, ourInventoryEntity, indexFrom, otherInventoryEntity, indexToHint, otherEndIndex, amount);
			}
			for (int i = otherStartIndex; i < otherEndIndex; i++)
			{
				if (reference.objectID == ObjectID.None)
				{
					break;
				}
				if (containedObjectsBuffers[i].Equals(reference) && HasRoomForObjectAt(in inventoryHandlerShared, inventoryBuffer, containedObjectsBuffers, inventorySlotsRequirements, reference, primaryPrefabEntity, i, out amount))
				{
					TryMove(in inventoryHandlerShared, ourInventoryEntity, indexFrom, otherInventoryEntity, i, otherEndIndex, amount);
				}
			}
			for (int j = otherStartIndex; j < otherEndIndex; j++)
			{
				if (reference.objectID == ObjectID.None)
				{
					break;
				}
				if (HasRoomForObjectAt(in inventoryHandlerShared, inventoryBuffer, containedObjectsBuffers, inventorySlotsRequirements, reference, primaryPrefabEntity, j, out amount))
				{
					TryMove(in inventoryHandlerShared, ourInventoryEntity, indexFrom, otherInventoryEntity, j, otherEndIndex, amount);
				}
			}
			if (reference.objectID != ObjectID.None)
			{
				DropItem(in inventoryHandlerShared, ourInventoryEntity, indexFrom, int.MaxValue, position);
			}
		}

		private static bool HasRoomForObjectAt(in InventoryHandlerShared inventoryHandlerShared, DynamicBuffer<InventoryBuffer> inventoryBuffer, DynamicBuffer<ContainedObjectsBuffer> containedObjectsBuffers, DynamicBuffer<InventorySlotRequirementBuffer> inventorySlotsRequirements, ContainedObjectsBuffer containedObject, Entity objectPrefab, int index, out int amount)
		{
			ContainedObjectsBuffer containedObjectsBuffer = containedObjectsBuffers[index];
			amount = 9999 - containedObjectsBuffer.amount;
			inventoryHandlerShared.objectCategoryTagsLookup.TryGetComponent(objectPrefab, out var componentData);
			if (!ObjectIsValidToPutInInventory(inventorySlotsRequirements, componentData, containedObject.objectID, inventoryBuffer, inventoryHandlerShared.overrideAlwaysAllowToBeTrashedLookup, out var _, inventoryHandlerShared.databaseBankCD, index))
			{
				return false;
			}
			if (containedObjectsBuffer.objectID != ObjectID.None)
			{
				if (containedObjectsBuffer.Equals(containedObject))
				{
					return amount > 0;
				}
				return false;
			}
			return true;
		}

		public static void Buy(in InventoryHandlerShared inventoryHandlerShared, Entity sellerInventoryEntity, int sellItemIndex, Entity buyerInventoryEntity, int buyerInventoryStart, int buyerInventorySize)
		{
			ContainedObjectsBuffer containedObject = default(ContainedObjectsBuffer);
			if (inventoryHandlerShared.inventoryLookup.HasComponent(sellerInventoryEntity))
			{
				containedObject = inventoryHandlerShared.containedObjectsBufferLookup[sellerInventoryEntity][sellItemIndex];
			}
			else if (inventoryHandlerShared.vendingMachineLookup.HasComponent(sellerInventoryEntity))
			{
				containedObject = new ContainedObjectsBuffer
				{
					objectData = new ObjectDataCD
					{
						objectID = inventoryHandlerShared.vendingMachineItemBufferLookup[sellerInventoryEntity][sellItemIndex].objectID,
						amount = 1
					}
				};
			}
			int coinValue = GetCoinValue(in inventoryHandlerShared, containedObject.objectData, buy: true);
			if (coinValue > 0)
			{
				Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(containedObject.objectID, inventoryHandlerShared.databaseBankCD.databaseBankBlob, containedObject.variation);
				DynamicBuffer<ContainedObjectsBuffer> containedObjectsBuffer = inventoryHandlerShared.containedObjectsBufferLookup[buyerInventoryEntity];
				DynamicBuffer<InventorySlotRequirementBuffer> inventorySlotRequirementBuffer = inventoryHandlerShared.inventorySlotRequirementBufferLookup[buyerInventoryEntity];
				DynamicBuffer<InventoryBuffer> inventoryBuffer = inventoryHandlerShared.inventoryLookup[buyerInventoryEntity];
				float3 position = inventoryHandlerShared.localTransformLookup[buyerInventoryEntity].Position;
				if (!HasRoomForObject(in inventoryHandlerShared, containedObject, primaryPrefabEntity, buyerInventoryStart, out var _, in containedObjectsBuffer, in inventorySlotRequirementBuffer, buyerInventoryStart, buyerInventorySize, CheckIfCantAddObjectsToInventory(inventoryBuffer), inventoryBuffer))
				{
					MoveAllToOrDrop(in inventoryHandlerShared, buyerInventoryEntity, buyerInventoryStart, buyerInventoryEntity, 0, -1, position);
				}
				int indexBuy = ((buyerInventoryStart > 0) ? buyerInventoryStart : (-1));
				if (inventoryHandlerShared.inventoryLookup.HasComponent(sellerInventoryEntity))
				{
					SellObject(in inventoryHandlerShared, sellerInventoryEntity, sellItemIndex, buyerInventoryEntity, indexBuy, buyerInventoryStart + buyerInventorySize, containedObject.objectID, 1, coinValue, position);
				}
				else if (inventoryHandlerShared.vendingMachineLookup.HasComponent(sellerInventoryEntity))
				{
					DestroyUpToAmountOfEntity(in inventoryHandlerShared, buyerInventoryEntity, 0, -1, ObjectID.AncientCoin, coinValue);
					CreateObject(in inventoryHandlerShared, buyerInventoryEntity, 0, containedObject.objectID, 1, position, 0);
				}
				if (inventoryHandlerShared.ghostEffectEventBufferLookup.TryGetBuffer(buyerInventoryEntity, out var bufferData))
				{
					RefRW<GhostEffectEventBufferPointerCD> refRW = inventoryHandlerShared.ghostEffectEventBufferPointerLookup.GetRefRW(buyerInventoryEntity);
					DynamicBuffer<GhostEffectEventBuffer> buffer = bufferData;
					ref GhostEffectEventBufferPointerCD valueRW = ref refRW.ValueRW;
					GhostEffectEventBuffer item = new GhostEffectEventBuffer
					{
						Tick = inventoryHandlerShared.currentTick,
						value = EffectEventExtensions.CreateSingleAudioSFX(localOnlyEffect: true, SfxID.coin, buyerInventoryEntity, 0.9f, 1.2f, 0.1f, useSpatialSound: false)
					};
					buffer.AddToRingBuffer(ref valueRW, in item);
				}
			}
		}

		public static int GetInventoryIndex(int index, DynamicBuffer<InventoryBuffer> inventoryBuffer, out int internalSlotIndex)
		{
			internalSlotIndex = index;
			if (index < 0 || inventoryBuffer.Length < 2)
			{
				return 0;
			}
			for (int i = 0; i < inventoryBuffer.Length; i++)
			{
				InventoryBuffer inventoryBuffer2 = inventoryBuffer[i];
				if (inventoryBuffer2.startIndex <= index && index < inventoryBuffer2.startIndex + inventoryBuffer2.maxSize)
				{
					internalSlotIndex = index - inventoryBuffer2.startIndex;
					return i;
				}
			}
			return 0;
		}

		public static bool CheckIfCantAddObjectsToInventory(DynamicBuffer<InventoryBuffer> inventoryBuffer, int slotIndex = -1)
		{
			for (int i = 0; i < inventoryBuffer.Length; i++)
			{
				InventoryBuffer inventoryBuffer2 = inventoryBuffer[i];
				if (inventoryBuffer2.cantAddObjectsToInventory && (slotIndex == -1 || (inventoryBuffer2.startIndex <= slotIndex && slotIndex < inventoryBuffer2.startIndex + inventoryBuffer2.maxSize)))
				{
					return true;
				}
			}
			return false;
		}

		public static bool CheckIfCanOnlyContainOneItemPerSlot(DynamicBuffer<InventoryBuffer> inventoryBuffer, int slotIndex = -1)
		{
			for (int i = 0; i < inventoryBuffer.Length; i++)
			{
				InventoryBuffer inventoryBuffer2 = inventoryBuffer[i];
				if (inventoryBuffer2.canOnlyContainOneItemPerSlot && (slotIndex == -1 || (inventoryBuffer2.startIndex <= slotIndex && slotIndex < inventoryBuffer2.startIndex + inventoryBuffer2.maxSize)))
				{
					return true;
				}
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[MonoPInvokeCallback(typeof(Inventory_002EGetNearbyChestsForCraftingByDistance_00007390_0024PostfixBurstDelegate))]
		public static void GetNearbyChestsForCraftingByDistance(in float3 position, in CollisionWorld collisionWorld, in ComponentLookup<InventoryAutoTransferEnabledCD> inventoryAutoTransferEnabledLookup, in ComponentLookup<LocalTransform> localTransformLookup, ref NativeList<Entity> inventories)
		{
			GetNearbyChestsForCraftingByDistance_00007390_0024BurstDirectCall.Invoke(in position, in collisionWorld, in inventoryAutoTransferEnabledLookup, in localTransformLookup, ref inventories);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[MonoPInvokeCallback(typeof(Inventory_002EGetNearbyChestsByDistance_00007391_0024PostfixBurstDelegate))]
		public static void GetNearbyChestsByDistance(in float3 position, in CollisionWorld collisionWorld, in ComponentLookup<InventoryAutoTransferEnabledCD> inventoryAutoTransferEnabledLookup, in ComponentLookup<LocalTransform> localTransformLookup, ref NativeList<Entity> inventories, float maxDistance, int maxInventories)
		{
			GetNearbyChestsByDistance_00007391_0024BurstDirectCall.Invoke(in position, in collisionWorld, in inventoryAutoTransferEnabledLookup, in localTransformLookup, ref inventories, maxDistance, maxInventories);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static NativeList<Entity> GetNearbyChestsForAutoStackingByDistance(float3 position, CollisionWorld collisionWorld, ComponentLookup<InventoryAutoTransferEnabledCD> inventoryAutoTransferEnabledLookup, ComponentLookup<LocalTransform> localTransformLookup, Allocator allocator)
		{
			return GetNearbyChestsByDistance(position, collisionWorld, inventoryAutoTransferEnabledLookup, localTransformLookup, 10f, 20, allocator);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static NativeList<Entity> GetNearbyChestsByDistance(float3 position, CollisionWorld collisionWorld, ComponentLookup<InventoryAutoTransferEnabledCD> inventoryAutoTransferEnabledLookup, ComponentLookup<LocalTransform> localTransformLookup, float maxDistance, int maxInventories, Allocator allocator)
		{
			NativeList<EntityDistance> nearbyChestsEntityWithDistanceSorted = GetNearbyChestsEntityWithDistanceSorted(position, collisionWorld, inventoryAutoTransferEnabledLookup, localTransformLookup, maxDistance, allocator);
			NativeList<Entity> result = new NativeList<Entity>(math.min(nearbyChestsEntityWithDistanceSorted.Length, maxInventories), allocator);
			int num = math.min(nearbyChestsEntityWithDistanceSorted.Length, maxInventories);
			for (int i = 0; i < num; i++)
			{
				EntityDistance entityDistance = nearbyChestsEntityWithDistanceSorted[i];
				result.Add(in entityDistance.entity);
			}
			nearbyChestsEntityWithDistanceSorted.Dispose();
			return result;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static NativeList<EntityDistance> GetNearbyChestsEntityWithDistanceSorted(float3 position, CollisionWorld collisionWorld, ComponentLookup<InventoryAutoTransferEnabledCD> inventoryAutoTransferEnabledLookup, ComponentLookup<LocalTransform> localTransformLookup, float maxDistance, Allocator allocator)
		{
			NativeList<EntityDistance> nativeList = new NativeList<EntityDistance>(allocator);
			NativeList<DistanceHit> outHits = new NativeList<DistanceHit>(Allocator.Temp);
			CollisionFilter filter = new CollisionFilter
			{
				BelongsTo = uint.MaxValue,
				CollidesWith = 1u
			};
			if (!collisionWorld.OverlapSphere(position, maxDistance, ref outHits, filter))
			{
				return nativeList;
			}
			for (int i = 0; i < outHits.Length; i++)
			{
				if (inventoryAutoTransferEnabledLookup.HasComponent(outHits[i].Entity) && localTransformLookup.TryGetComponent(outHits[i].Entity, out var componentData))
				{
					EntityDistance value = new EntityDistance
					{
						entity = outHits[i].Entity,
						distance = outHits[i].Distance,
						position = componentData.Position
					};
					nativeList.Add(in value);
				}
			}
			nativeList.Sort();
			outHits.Dispose();
			return nativeList;
		}

		public static void QuickStackToNearbyChests(in InventoryHandlerShared inventoryHandlerShared, Entity fromInventory, NativeList<Entity> nearbyChestsInOrderInventories)
		{
			DynamicBuffer<ContainedObjectsBuffer> containedObjectsBuffer = inventoryHandlerShared.containedObjectsBufferLookup[fromInventory];
			DynamicBuffer<InventoryBuffer> dynamicBuffer = inventoryHandlerShared.inventoryLookup[fromInventory];
			NativeList<AutoStackChestRemainingData> chestCache = new NativeList<AutoStackChestRemainingData>(nearbyChestsInOrderInventories.Length, Allocator.Temp);
			float3 position = inventoryHandlerShared.localTransformLookup[fromInventory].Position;
			DynamicBuffer<LockedObjectsBuffer> bufferData;
			bool hasLockedObjectBuffer = inventoryHandlerShared.lockedObjectsBufferLookup.TryGetBuffer(fromInventory, out bufferData);
			for (int i = 0; i < dynamicBuffer.Length; i++)
			{
				QuicktackToNearbyChestsFromInventory(in inventoryHandlerShared, fromInventory, position, containedObjectsBuffer, inventoryHandlerShared.databaseBankCD.databaseBankBlob, dynamicBuffer[i], nearbyChestsInOrderInventories, chestCache, hasLockedObjectBuffer, bufferData);
			}
			chestCache.Dispose();
		}

		private static void QuicktackToNearbyChestsFromInventory(in InventoryHandlerShared inventoryHandlerShared, Entity fromInventory, float3 fromPosition, DynamicBuffer<ContainedObjectsBuffer> containedObjectsBuffer, BlobAssetReference<PugDatabase.PugDatabaseBank> databaseBankBlob, InventoryBuffer inventoryBuffer, NativeList<Entity> nearbyChestsInOrderInventories, NativeList<AutoStackChestRemainingData> chestCache, bool hasLockedObjectBuffer, DynamicBuffer<LockedObjectsBuffer> lockedObjectsBuffer)
		{
			int startIndex = inventoryBuffer.startIndex;
			int num = startIndex + inventoryBuffer.size;
			for (int i = startIndex; i < num; i++)
			{
				ContainedObjectsBuffer containedObjectsBuffer2 = containedObjectsBuffer[i];
				ObjectID objectID = containedObjectsBuffer2.objectID;
				if (objectID != ObjectID.None && (!hasLockedObjectBuffer || !lockedObjectsBuffer[i].Value))
				{
					bool isStackable = PugDatabase.GetEntityObjectInfo(objectID, databaseBankBlob).isStackable;
					QuickStackItemToNearbyChests(objectWithVariation: new ObjectWithVariation(objectID, containedObjectsBuffer2.variation), inventoryHandlerShared: in inventoryHandlerShared, fromInventory: fromInventory, fromPosition: fromPosition, fromContainedObjectsBuffer: containedObjectsBuffer, fromIndex: i, isStackable: isStackable, chestInventories: nearbyChestsInOrderInventories, chestsRemainingDataCache: chestCache);
				}
			}
		}

		private static void QuickStackItemToNearbyChests(in InventoryHandlerShared inventoryHandlerShared, Entity fromInventory, float3 fromPosition, DynamicBuffer<ContainedObjectsBuffer> fromContainedObjectsBuffer, int fromIndex, ObjectWithVariation objectWithVariation, bool isStackable, NativeList<Entity> chestInventories, NativeList<AutoStackChestRemainingData> chestsRemainingDataCache)
		{
			for (int i = 0; i < chestInventories.Length; i++)
			{
				if (fromContainedObjectsBuffer[fromIndex].objectID == ObjectID.None)
				{
					break;
				}
				int amount = fromContainedObjectsBuffer[fromIndex].amount;
				Entity chestInventory = chestInventories[i];
				TryQuickStackItemIntoChest(in inventoryHandlerShared, fromInventory, fromPosition, i, chestInventory, objectWithVariation, chestsRemainingDataCache, fromIndex, amount, isStackable);
			}
		}

		private static void TryQuickStackItemIntoChest(in InventoryHandlerShared inventoryHandlerShared, Entity fromInventory, float3 fromPosition, int chestIndex, Entity chestInventory, ObjectWithVariation objectWithVariation, NativeList<AutoStackChestRemainingData> chestsRemainingDataCache, int fromItemIndex, int amountLeft, bool isStackable)
		{
			if (chestIndex >= chestsRemainingDataCache.Length)
			{
				chestsRemainingDataCache.Add(GetQuickStackChestsRemainingDataFromChest(in inventoryHandlerShared, chestInventory, Allocator.Temp));
			}
			AutoStackChestRemainingData autoStackChestRemainingData = chestsRemainingDataCache[chestIndex];
			if (autoStackChestRemainingData.objectToRemainingSpaceAmount.TryGetValue(objectWithVariation, out var item) && (item != 0 || autoStackChestRemainingData.remainingStacks > 0))
			{
				if (isStackable)
				{
					int num = math.min(amountLeft, item);
					amountLeft -= num;
					int y = (int)math.ceil((float)amountLeft / 9999f);
					int num2 = math.min(autoStackChestRemainingData.remainingStacks, y);
					int num3 = math.min(num2 * 9999, amountLeft);
					int amount = num + num3;
					chestsRemainingDataCache.ElementAt(chestIndex).objectToRemainingSpaceAmount[objectWithVariation] += num2 * 9999 - num;
					chestsRemainingDataCache.ElementAt(chestIndex).remainingStacks -= num2;
					DropItem(in inventoryHandlerShared, fromInventory, fromItemIndex, amount, fromPosition, default(Entity), chestInventory, ignoreRayChecksForPickup: true);
				}
				else
				{
					chestsRemainingDataCache.ElementAt(chestIndex).remainingStacks--;
					DropItem(in inventoryHandlerShared, fromInventory, fromItemIndex, amountLeft, fromPosition, default(Entity), chestInventory, ignoreRayChecksForPickup: true);
				}
			}
		}

		private static AutoStackChestRemainingData GetQuickStackChestsRemainingDataFromChest(in InventoryHandlerShared inventoryHandlerShared, Entity chestInventory, Allocator allocator)
		{
			DynamicBuffer<ContainedObjectsBuffer> containedObjectsBuffer = inventoryHandlerShared.containedObjectsBufferLookup[chestInventory];
			NativeHashMap<ObjectWithVariation, int> objectToRemainingSpaceAmount = new NativeHashMap<ObjectWithVariation, int>(containedObjectsBuffer.Length, allocator);
			int remainingStacks = 0;
			DynamicBuffer<InventoryBuffer> dynamicBuffer = inventoryHandlerShared.inventoryLookup[chestInventory];
			for (int i = 0; i < dynamicBuffer.Length; i++)
			{
				GetQuickStackChestsRemainingDataFromChestFromInventory(dynamicBuffer[i], containedObjectsBuffer, ref remainingStacks, objectToRemainingSpaceAmount, inventoryHandlerShared.databaseBankCD.databaseBankBlob);
			}
			return new AutoStackChestRemainingData
			{
				objectToRemainingSpaceAmount = objectToRemainingSpaceAmount,
				remainingStacks = remainingStacks
			};
		}

		private static void GetQuickStackChestsRemainingDataFromChestFromInventory(InventoryBuffer inventory, DynamicBuffer<ContainedObjectsBuffer> containedObjectsBuffer, ref int remainingStacks, NativeHashMap<ObjectWithVariation, int> objectToRemainingSpaceAmount, BlobAssetReference<PugDatabase.PugDatabaseBank> databaseBankBlob)
		{
			int startIndex = inventory.startIndex;
			int num = startIndex + inventory.size;
			for (int i = startIndex; i < num; i++)
			{
				ObjectID objectID = containedObjectsBuffer[i].objectID;
				ObjectWithVariation key = new ObjectWithVariation(objectID, containedObjectsBuffer[i].variation);
				bool isStackable = PugDatabase.GetEntityObjectInfo(objectID, databaseBankBlob).isStackable;
				if (objectID == ObjectID.None)
				{
					remainingStacks++;
					continue;
				}
				int num2 = (isStackable ? (9999 - containedObjectsBuffer[i].amount) : 0);
				if (objectToRemainingSpaceAmount.ContainsKey(key))
				{
					objectToRemainingSpaceAmount[key] += num2;
				}
				else
				{
					objectToRemainingSpaceAmount.Add(key, num2);
				}
			}
		}

		public static bool ItemMatchesSlot(SlotUIBase slot, ObjectInfo objectInfo)
		{
			if ((slot.slotType == ItemSlotsUIType.HelmSlot && objectInfo.objectType == ObjectType.Helm) || (slot.slotType == ItemSlotsUIType.BreastSlot && objectInfo.objectType == ObjectType.BreastArmor) || (slot.slotType == ItemSlotsUIType.PantsSlot && objectInfo.objectType == ObjectType.PantsArmor) || (slot.slotType == ItemSlotsUIType.NecklaceSlot && objectInfo.objectType == ObjectType.Necklace) || ((slot.slotType == ItemSlotsUIType.RingSlot1 || slot.slotType == ItemSlotsUIType.RingSlot2) && objectInfo.objectType == ObjectType.Ring) || (slot.slotType == ItemSlotsUIType.OffhandSlot && objectInfo.objectType == ObjectType.Offhand) || (slot.slotType == ItemSlotsUIType.BagSlot && objectInfo.objectType == ObjectType.Bag) || (slot.slotType == ItemSlotsUIType.PetSlot && objectInfo.objectType == ObjectType.Pet) || (slot.slotType == ItemSlotsUIType.LanternSlot && objectInfo.objectType == ObjectType.Lantern) || (slot.slotType == ItemSlotsUIType.HelmVanitySlot && objectInfo.objectType == ObjectType.Helm) || (slot.slotType == ItemSlotsUIType.BreastVanitySlot && objectInfo.objectType == ObjectType.BreastArmor) || (slot.slotType == ItemSlotsUIType.PantsVanitySlot && objectInfo.objectType == ObjectType.PantsArmor) || ((slot.slotType == ItemSlotsUIType.Pouch1 || slot.slotType == ItemSlotsUIType.Pouch2 || slot.slotType == ItemSlotsUIType.Pouch3 || slot.slotType == ItemSlotsUIType.Pouch4) && objectInfo.objectType == ObjectType.Pouch))
			{
				return true;
			}
			return false;
		}

		public static bool CanExtract(BufferLookup<ContainedObjectsBuffer> containedObjectsBufferLookup, Entity inventory, int extractSlotIndex, out ExtractableCD extractableCD, ComponentLookup<ExtractorCD> extractorLookup, ComponentLookup<ObjectCategoryTagsCD> objectCategoryTagsLookup, ComponentLookup<ExtractableCD> extractableLookup, PugDatabase.DatabaseBankCD databaseBankCD)
		{
			extractableCD = default(ExtractableCD);
			if (!containedObjectsBufferLookup.TryGetBuffer(inventory, out var bufferData) || !extractorLookup.TryGetComponent(inventory, out var componentData))
			{
				return false;
			}
			ObjectDataCD objectData = bufferData[extractSlotIndex].objectData;
			if (objectData.objectID == ObjectID.None)
			{
				return false;
			}
			Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(objectData.objectID, databaseBankCD.databaseBankBlob, objectData.variation);
			if (!objectCategoryTagsLookup.TryGetComponent(primaryPrefabEntity, out var componentData2) || !ObjectCategoryTagsCD.HasTag(componentData2.tagsBitMask, componentData.extractableType))
			{
				return false;
			}
			return extractableLookup.TryGetComponent(primaryPrefabEntity, out extractableCD);
		}

		public static void Extract(InventoryHandlerShared inventoryHandlerShared, Entity inventory, int extractSlotIndex, float3 entityPositionPosition, ref Unity.Mathematics.Random random, float2 defaultMinMaxRandomExtractedOutputAmount, int maxExtractStacks)
		{
			if (!inventoryHandlerShared.containedObjectsBufferLookup.TryGetBuffer(inventory, out var bufferData))
			{
				return;
			}
			ContainedObjectsBuffer containedObjectData = bufferData[extractSlotIndex];
			if (containedObjectData.objectID == ObjectID.None)
			{
				return;
			}
			Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(containedObjectData.objectID, inventoryHandlerShared.databaseBankCD.databaseBankBlob, containedObjectData.variation);
			if (inventoryHandlerShared.extractableLookup.TryGetComponent(primaryPrefabEntity, out var componentData))
			{
				ref ExtractableData value = ref componentData.extractableData.Value;
				if (value.extractableType == ExtractableType.SpecificObject)
				{
					ExtractSpecificObject(in inventoryHandlerShared, containedObjectData, extractSlotIndex, bufferData, defaultMinMaxRandomExtractedOutputAmount, maxExtractStacks, ref value, ref componentData.extractedObjectOutputArray, ref random, entityPositionPosition);
				}
				else if (value.extractableType == ExtractableType.Salvageable)
				{
					int totalScrapParts = 0;
					float3 position = entityPositionPosition + new float3(0f, 0f, -0.2f);
					TrySalvageObject(in inventoryHandlerShared, inventory, extractSlotIndex, Entity.Null, position, ref totalScrapParts);
					ContainedObjectsBuffer containedObject = new ContainedObjectsBuffer
					{
						objectData = new ObjectDataCD
						{
							objectID = ObjectID.ScrapPart,
							amount = totalScrapParts
						}
					};
					EntityUtility.DropNewEntity(inventoryHandlerShared.ecb, containedObject, position, inventoryHandlerShared.databaseBankCD.databaseBankBlob);
				}
			}
		}

		private static void ExtractSpecificObject(in InventoryHandlerShared inventoryHandlerShared, ContainedObjectsBuffer containedObjectData, int extractSlotIndex, DynamicBuffer<ContainedObjectsBuffer> containedObjectsBuffer, float2 defaultMinMaxRandomExtractedOutputAmount, int maxExtractStacks, ref ExtractableData extractableData, ref BlobAssetReference<BlobArray<ExtractedObjectOutputElementData>> extractedObjectOutputArray, ref Unity.Mathematics.Random rand, float3 entityPositionPosition)
		{
			ref PugDatabase.EntityObjectInfo entityObjectInfo = ref PugDatabase.GetEntityObjectInfo(containedObjectData.objectID, inventoryHandlerShared.databaseBankCD.databaseBankBlob);
			int num = (entityObjectInfo.isStackable ? math.min(containedObjectData.amount, maxExtractStacks) : containedObjectData.amount);
			containedObjectData.objectData.amount -= num;
			int num2 = ((!entityObjectInfo.isStackable) ? 1 : num);
			if (containedObjectData.amount <= 0)
			{
				containedObjectData.objectData = default(ObjectDataCD);
			}
			containedObjectsBuffer[extractSlotIndex] = containedObjectData;
			for (int i = 0; i < extractedObjectOutputArray.Value.Length; i++)
			{
				ref ExtractedObjectOutputElementData reference = ref extractedObjectOutputArray.Value[i];
				float2 float5 = defaultMinMaxRandomExtractedOutputAmount;
				if (!math.all(reference.minMaxRandomAmountOverride == float2.zero))
				{
					float5 = reference.minMaxRandomAmountOverride;
				}
				int amount = (int)math.round((float)num2 * rand.NextFloat(float5.x, float5.y));
				ContainedObjectsBuffer containedObject = new ContainedObjectsBuffer
				{
					objectData = new ObjectDataCD
					{
						objectID = reference.objectID,
						variation = reference.variation,
						amount = amount
					}
				};
				EntityUtility.DropNewEntity(inventoryHandlerShared.ecb, containedObject, entityPositionPosition + new float3(0f, 0f, -0.2f), inventoryHandlerShared.databaseBankCD.databaseBankBlob);
			}
		}

		public static bool CanIncinerate(BufferLookup<ContainedObjectsBuffer> containedObjectsBufferLookup, Entity inventory, int incinerateSlotIndex, ComponentLookup<IncineratorCD> incineratorLookup, ComponentLookup<OverrideLegendaryForSlotRequirementsCD> overrideAlwaysAllowToBeIncineratedLookup, PugDatabase.DatabaseBankCD databaseBankCD)
		{
			if (!containedObjectsBufferLookup.TryGetBuffer(inventory, out var bufferData) || !incineratorLookup.TryGetComponent(inventory, out var _))
			{
				return false;
			}
			ObjectDataCD objectData = bufferData[incinerateSlotIndex].objectData;
			if (objectData.objectID == ObjectID.None)
			{
				return false;
			}
			Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(objectData.objectID, databaseBankCD.databaseBankBlob, objectData.variation);
			if (overrideAlwaysAllowToBeIncineratedLookup.HasComponent(primaryPrefabEntity))
			{
				return true;
			}
			return PugDatabase.GetEntityObjectInfo(objectData.objectID, databaseBankCD.databaseBankBlob, objectData.variation).rarity != Rarity.Legendary;
		}

		public static bool CanFish(Entity inventory, int baitSlotIndex, BufferLookup<ContainedObjectsBuffer> containedObjectsBufferLookup, ComponentLookup<ObjectCategoryTagsCD> objectCategoryTagsLookup, PugDatabase.DatabaseBankCD databaseBankCD)
		{
			if (!containedObjectsBufferLookup.TryGetBuffer(inventory, out var bufferData))
			{
				return false;
			}
			ObjectDataCD objectData = bufferData[baitSlotIndex].objectData;
			if (objectData.objectID == ObjectID.None)
			{
				return false;
			}
			Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(objectData.objectID, databaseBankCD.databaseBankBlob, objectData.variation);
			if (!objectCategoryTagsLookup.TryGetComponent(primaryPrefabEntity, out var componentData) || !ObjectCategoryTagsCD.HasTag(componentData.tagsBitMask, ObjectCategoryTag.Critter))
			{
				return false;
			}
			return true;
		}

		public static void Fish(Entity inventory, int fishSlotIndex, float3 baitPosition, FishingTableCD fishingTableCD, LootTableBankCD lootTableBankCD, TileAccessor tileAccessor, BiomeLookup biomeLookup, BufferLookup<ContainedObjectsBuffer> containedObjectsBufferLookup, ComponentLookup<RandomCD> randomLookup, PugDatabase.DatabaseBankCD databaseBankCD)
		{
			if (!containedObjectsBufferLookup.TryGetBuffer(inventory, out var bufferData) || bufferData[fishSlotIndex].objectID == ObjectID.None)
			{
				return;
			}
			RefRW<RandomCD> refRWOptional = randomLookup.GetRefRWOptional(inventory);
			if (!refRWOptional.IsValid)
			{
				return;
			}
			int2 worldPosition = baitPosition.RoundToInt2();
			Tileset tileset = (Tileset)tileAccessor.GetTop(worldPosition).tileset;
			Biome biome = biomeLookup.GetBiome(worldPosition);
			fishingTableCD.GetFishingStats(tileset, biome, out var fishingInfo, out var _);
			using NativeList<PugDatabase.EntityLootData> nativeList = PugDatabase.GetRandomLoot(fishingInfo.fishLootTableID, ref refRWOptional.ValueRW.Value, lootTableBankCD.Value, databaseBankCD.databaseBankBlob, biome);
			if (nativeList.Length != 0)
			{
				bufferData[fishSlotIndex] = new ContainedObjectsBuffer
				{
					objectData = new ObjectDataCD
					{
						objectID = nativeList[0].objectID,
						amount = 1
					}
				};
			}
		}

		public static bool CanCatchCritter(Entity inventory, int baitSlotIndex, BufferLookup<ContainedObjectsBuffer> containedObjectsBufferLookup, ComponentLookup<ObjectCategoryTagsCD> objectCategoryTagsLookup, PugDatabase.DatabaseBankCD databaseBankCD)
		{
			if (!containedObjectsBufferLookup.TryGetBuffer(inventory, out var bufferData))
			{
				return false;
			}
			ObjectDataCD objectData = bufferData[baitSlotIndex].objectData;
			if (objectData.objectID == ObjectID.None)
			{
				return false;
			}
			Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(objectData.objectID, databaseBankCD.databaseBankBlob, objectData.variation);
			if (!objectCategoryTagsLookup.TryGetComponent(primaryPrefabEntity, out var componentData) || !ObjectCategoryTagsCD.HasTag(componentData.tagsBitMask, ObjectCategoryTag.Plant))
			{
				return false;
			}
			return true;
		}

		public static void CatchCritter(Entity inventory, int fishSlotIndex, float3 baitPosition, TileAccessor tileAccessor, BiomeLookup biomeLookup, BufferLookup<ContainedObjectsBuffer> containedObjectsBufferLookup, ComponentLookup<RandomCD> randomLookup, NativeParallelMultiHashMap<int, ObjectData> biomeToCritterMap, NativeParallelMultiHashMap<int, ObjectData> tilesetToCritterMap)
		{
			if (!containedObjectsBufferLookup.TryGetBuffer(inventory, out var bufferData) || bufferData[fishSlotIndex].objectID == ObjectID.None)
			{
				return;
			}
			RefRW<RandomCD> refRWOptional = randomLookup.GetRefRWOptional(inventory);
			if (refRWOptional.IsValid)
			{
				int2 worldPosition = baitPosition.RoundToInt2();
				Tileset tileset = (Tileset)tileAccessor.GetTop(worldPosition).tileset;
				Biome biome = biomeLookup.GetBiome(worldPosition);
				NativeList<ObjectData> validCritters = new NativeList<ObjectData>(16, Allocator.Temp);
				AddMatchingPrefabsToListFromMap(validCritters, (int)biome, biomeToCritterMap);
				AddMatchingPrefabsToListFromMap(validCritters, (int)tileset, tilesetToCritterMap);
				if (validCritters.Length == 0)
				{
					AddMatchingPrefabsToListFromMap(validCritters, 0, biomeToCritterMap);
				}
				ObjectData objectData = new ObjectData
				{
					objectID = ObjectID.CritterWorm,
					amount = 1
				};
				if (validCritters.Length > 0)
				{
					objectData = validCritters[refRWOptional.ValueRW.Value.NextInt(validCritters.Length)];
				}
				bufferData[fishSlotIndex] = new ContainedObjectsBuffer
				{
					objectData = objectData
				};
			}
		}

		private static void AddMatchingPrefabsToListFromMap(NativeList<ObjectData> validCritters, int biome, NativeParallelMultiHashMap<int, ObjectData> biomeToCritterMap)
		{
			if (biomeToCritterMap.TryGetFirstValue(biome, out var item, out var it))
			{
				do
				{
					validCritters.Add(in item);
				}
				while (biomeToCritterMap.TryGetNextValue(out item, ref it));
			}
		}

		public static void AddFilter(in InventoryHandlerShared inventoryHandlerShared, Entity inventory, ObjectID objectID, int variation)
		{
			if (inventoryHandlerShared.objectFilteringLookup.HasComponent(inventory))
			{
				ref ObjectFilteringCD valueRW = ref inventoryHandlerShared.objectFilteringLookup.GetRefRW(inventory).ValueRW;
				valueRW.filterType = ((objectID != ObjectID.None) ? FilterType.Whitelist : FilterType.None);
				valueRW.filterObject = objectID;
				valueRW.filterVariation = variation;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void GetNearbyChestsForCraftingByDistance_0024BurstManaged(in float3 position, in CollisionWorld collisionWorld, in ComponentLookup<InventoryAutoTransferEnabledCD> inventoryAutoTransferEnabledLookup, in ComponentLookup<LocalTransform> localTransformLookup, ref NativeList<Entity> inventories)
		{
			GetNearbyChestsByDistance(in position, in collisionWorld, in inventoryAutoTransferEnabledLookup, in localTransformLookup, ref inventories, 10f, 20);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void GetNearbyChestsByDistance_0024BurstManaged(in float3 position, in CollisionWorld collisionWorld, in ComponentLookup<InventoryAutoTransferEnabledCD> inventoryAutoTransferEnabledLookup, in ComponentLookup<LocalTransform> localTransformLookup, ref NativeList<Entity> inventories, float maxDistance, int maxInventories)
		{
			NativeList<EntityDistance> nearbyChestsEntityWithDistanceSorted = GetNearbyChestsEntityWithDistanceSorted(position, collisionWorld, inventoryAutoTransferEnabledLookup, localTransformLookup, maxDistance, Allocator.Temp);
			inventories.SetCapacity(inventories.Length + maxInventories);
			for (int i = 0; i < math.min(nearbyChestsEntityWithDistanceSorted.Length, maxInventories); i++)
			{
				EntityDistance entityDistance = nearbyChestsEntityWithDistanceSorted[i];
				inventories.Add(in entityDistance.entity);
			}
			nearbyChestsEntityWithDistanceSorted.Dispose();
		}
	}
}
