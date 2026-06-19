using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using PlayerEquipment;
using Pug.Automation;
using Pug.Properties;
using Pug.UnityExtensions;
using PugTilemap;
using PugTilemap.Quads;
using QFSW.QC;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Physics.Authoring;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Scripting;

public class PlacementHandler : MonoBehaviour
{
	public struct EntityAndInfoFromPlacement
	{
		public ObjectID objectID;

		public Entity entity;

		public int3 pos;

		public TileType tileType;

		public int tileset;

		public EntityAndInfoFromPlacement(ObjectID objectID, TileType tileType, int tileset, Entity entity, int3 pos)
		{
			this.objectID = objectID;
			this.tileType = tileType;
			this.tileset = tileset;
			this.entity = entity;
			this.pos = pos;
		}

		public EntityAndInfoFromPlacement(Entity entity, int3 pos)
		{
			objectID = ObjectID.None;
			tileType = TileType.none;
			tileset = 0;
			this.entity = entity;
			this.pos = pos;
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct AllowPlacingAnywhereKey
	{
	}

	public struct CanPlaceSharedData
	{
		[ReadOnly]
		public ComponentLookup<ObjectDataCD> objectDataLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> localTransformLookup;

		[ReadOnly]
		public ComponentLookup<PetCD> petLookup;

		[ReadOnly]
		public ComponentLookup<TileCD> tileLookup;

		[ReadOnly]
		public ComponentLookup<ObjectPropertiesCD> objectPropertiesLookup;

		[ReadOnly]
		public ComponentLookup<PlayerGhost> playerGhostLookup;

		[ReadOnly]
		public ComponentLookup<MinionCD> minionLookup;

		[ReadOnly]
		public ComponentLookup<IndestructibleCD> indestructibleLookup;

		public ComponentLookup<PlantCD> plantLookup;

		[ReadOnly]
		public ComponentLookup<CritterCD> critterLookup;

		[ReadOnly]
		public ComponentLookup<FireflyCD> fireflyLookup;

		[ReadOnly]
		public ComponentLookup<RequiresDrillCD> requiresDrillLookup;

		[ReadOnly]
		public ComponentLookup<SurfacePriorityCD> surfacePriorityLookup;

		[ReadOnly]
		public ComponentLookup<ElectricityCD> electricityLookup;

		[ReadOnly]
		public ComponentLookup<EventTerminalCD> eventTerminalLookup;

		[ReadOnly]
		public ComponentLookup<PseudoTileCD> pseudoTileLookup;

		[ReadOnly]
		public ComponentLookup<WayPointCD> waypointLookup;

		public PugDatabase.DatabaseBankCD databaseBank;

		public TileAccessor tileAccessor;

		public TileWithTilesetToObjectDataMapCD tileWithTilesetToObjectDataMapCD;
	}

	public PlacementIcon placeableIcon;

	private static readonly SharedStatic<bool> allowPlacingAnywhere = SharedStatic<bool>.GetOrCreateUnsafe(0u, -8534557879481629966L, 0L);

	public World world => Manager.ecs.ClientWorld;

	[Preserve]
	[Conditional("UNITY_EDITOR")]
	[Conditional("FORCE_DEBUG_MODE")]
	[Conditional("PUG_MARKETING_BUILD")]
	[Command("allowPlacingAnywhere", "Set whether the player can place things anywhere (for debugging).", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	public static void SetAllowPlacingAnywhere(bool trueOrFalse)
	{
		allowPlacingAnywhere.Data = trueOrFalse;
	}

	public static bool ObjectCanBeToggledToNewNonRotationOption(Entity placementPrefab, ComponentLookup<ObjectPropertiesCD> objectPropertiesLookup)
	{
		if (objectPropertiesLookup.TryGetComponent(placementPrefab, out var componentData))
		{
			return componentData.Has(-11102812);
		}
		return false;
	}

	public static bool ObjectCanBeRotated(Entity placementPrefab, ComponentLookup<DirectionBasedOnVariationCD> directionBasedOnVariationLookup, ComponentLookup<ObjectPropertiesCD> objectPropertiesLookup, ComponentLookup<DirectionCD> directionLookup)
	{
		if (directionBasedOnVariationLookup.HasComponent(placementPrefab) && objectPropertiesLookup.TryGetComponent(placementPrefab, out var componentData))
		{
			return !componentData.Has(121328368);
		}
		return directionLookup.HasComponent(placementPrefab);
	}

	public static bool PlacementCanBeResized(Entity placementPrefab, ComponentLookup<ResizableTileSizeCD> resizeLookup)
	{
		return resizeLookup.HasComponent(placementPrefab);
	}

	public static bool ShouldRotatePhysics(Entity placementPrefab, ComponentLookup<DirectionCD> directionLookup)
	{
		return directionLookup.HasComponent(placementPrefab);
	}

	private static float GetMaxReachDistance(in ObjectDataCD equippedObjectData)
	{
		if (!HasLimitedPlacementRange(in equippedObjectData))
		{
			return 1.5f;
		}
		return 1f;
	}

	private static float GetReachDistance(in ObjectDataCD equippedObjectData)
	{
		if (!HasLimitedPlacementRange(in equippedObjectData))
		{
			return 1f;
		}
		return 0.75f;
	}

	private static float GetShortReachDistance(in ObjectDataCD equippedObjectData)
	{
		if (!HasLimitedPlacementRange(in equippedObjectData))
		{
			return 0.5f;
		}
		return 0.25f;
	}

	private static bool HasLimitedPlacementRange(in ObjectDataCD equippedObjectData)
	{
		ObjectID objectID = equippedObjectData.objectID;
		if (objectID != ObjectID.Boat)
		{
			return objectID == ObjectID.SpeederBoat;
		}
		return true;
	}

	public static void UpdatePlaceablePosition(Entity placementPrefab, ref NativeList<EntityAndInfoFromPlacement> diggableEntityAndInfos, in EquipmentUpdateAspect equipmentUpdateAspect, in EquipmentUpdateSharedData equipmentUpdateSharedData, in LookupEquipmentUpdateData equipmentUpdateLookupData)
	{
		ref PlacementCD valueRW = ref equipmentUpdateAspect.placementCD.ValueRW;
		int2 currentSize = GetCurrentSize(placementPrefab, equipmentUpdateAspect.equippedObjectCD.ValueRO.containedObject.objectData, in valueRW, equipmentUpdateAspect.placementSizeByEquipmentTypeBuffer, equipmentUpdateAspect.equipmentSlotCD.ValueRO, equipmentUpdateSharedData.databaseBank, equipmentUpdateLookupData.directionBasedOnVariationLookup, equipmentUpdateLookupData.objectPropertiesLookup, equipmentUpdateLookupData.directionLookup, equipmentUpdateLookupData.sizeVariationLookup);
		valueRW.canPlaceObject = true;
		NativeHashMap<int3, bool> tilesChecked = new NativeHashMap<int3, bool>(32, Allocator.Temp);
		if (!FindPlaceablePositionFromMouseOrJoystick(placementPrefab, currentSize.x, currentSize.y, tilesChecked, ref diggableEntityAndInfos, in equipmentUpdateAspect, in equipmentUpdateSharedData, in equipmentUpdateLookupData))
		{
			FindPlaceablePositionFromOwnerDirection(placementPrefab, currentSize.x, currentSize.y, tilesChecked, ref diggableEntityAndInfos, in equipmentUpdateAspect, in equipmentUpdateSharedData, in equipmentUpdateLookupData);
		}
	}

	private static bool FindPlaceablePositionFromMouseOrJoystick(Entity placementPrefab, int width, int height, NativeHashMap<int3, bool> tilesChecked, ref NativeList<EntityAndInfoFromPlacement> diggableEntityAndInfos, in EquipmentUpdateAspect equipmentUpdateAspect, in EquipmentUpdateSharedData equipmentUpdateSharedData, in LookupEquipmentUpdateData equipmentUpdateLookupData)
	{
		float3 position = equipmentUpdateLookupData.localTransformLookup.GetRefRO(equipmentUpdateAspect.entity).ValueRO.Position;
		int num = width * height;
		ref readonly ClientInput valueRO = ref equipmentUpdateAspect.clientInput.ValueRO;
		if (!valueRO.prefersKeyboardAndMouse && !valueRO.wasAiming)
		{
			return false;
		}
		ObjectDataCD equippedObjectData = equipmentUpdateAspect.equippedObjectCD.ValueRO.containedObject.objectData;
		float3 float5 = valueRO.mouseOrJoystickWorldPoint.ToFloat3();
		float3 float6 = new float3((float)(width - 1) / 2f, 0f, (float)(height - 1) / 2f);
		float5 -= float6;
		int3 int5 = ExtensionMethods.RoundToInt3(new Bounds(position - float6, new Vector3((float)width + GetMaxReachDistance(in equippedObjectData), 0f, (float)height + GetMaxReachDistance(in equippedObjectData))).ClosestPoint(float5));
		ref PlacementCD valueRW = ref equipmentUpdateAspect.placementCD.ValueRW;
		valueRW.canPlaceObject = num == CanPlaceObjectAtPositionForSlotType(placementPrefab, int5, width, height, tilesChecked, ref diggableEntityAndInfos, in equipmentUpdateAspect, in equipmentUpdateSharedData, in equipmentUpdateLookupData);
		valueRW.bestPositionToPlaceAt = int5;
		return true;
	}

	private static void FindPlaceablePositionFromOwnerDirection(Entity placementPrefab, int width, int height, NativeHashMap<int3, bool> tilesChecked, ref NativeList<EntityAndInfoFromPlacement> diggableEntityAndInfos, in EquipmentUpdateAspect equipmentUpdateAspect, in EquipmentUpdateSharedData equipmentUpdateSharedData, in LookupEquipmentUpdateData equipmentUpdateLookupData)
	{
		Direction facingDirection = equipmentUpdateAspect.animationOrientationCD.ValueRO.facingDirection;
		float3 position = equipmentUpdateLookupData.localTransformLookup.GetRefRO(equipmentUpdateAspect.entity).ValueRO.Position;
		int3 int5 = position.RoundToInt3();
		int num = width * height;
		ObjectDataCD equippedObjectData = equipmentUpdateAspect.equippedObjectCD.ValueRO.containedObject.objectData;
		int3 value = (position + facingDirection.f3 * GetReachDistance(in equippedObjectData)).RoundToInt3();
		int3 value2 = (position + facingDirection.f3 * GetShortReachDistance(in equippedObjectData)).RoundToInt3();
		NativeList<int3> nativeList = new NativeList<int3>(2, Allocator.Temp);
		nativeList.Add(in value2);
		if (math.all(value2 != value))
		{
			nativeList.Add(in value);
		}
		ref PlacementCD valueRW = ref equipmentUpdateAspect.placementCD.ValueRW;
		int num2 = 0;
		foreach (int3 item in nativeList)
		{
			int num3 = -(width - 1) / 2;
			int num4 = -(height - 1) / 2;
			bool flag = false;
			if (facingDirection.id == Direction.Id.back || facingDirection.id == Direction.Id.zero)
			{
				flag = true;
				num4 = -height + 1;
			}
			else if (facingDirection.id == Direction.Id.forward)
			{
				flag = true;
				num4 = 0;
			}
			else if (facingDirection.id == Direction.Id.left)
			{
				num3 = -width + 1;
			}
			else if (facingDirection.id == Direction.Id.right)
			{
				num3 = 0;
			}
			valueRW.canPlaceObject = false;
			int num5 = (flag ? (width / 2) : 0);
			int num6 = ((!flag) ? (height / 2) : 0);
			bool flag2 = (flag ? (width % 2 == 0) : (height % 2 == 0));
			for (int i = 0; i <= num5; i++)
			{
				for (int j = 0; j <= num6; j++)
				{
					int x = num3 + i;
					int z = num4 + j;
					int3 int6 = new int3(x, 0, z);
					int3 int7 = item + int6;
					int num7 = CanPlaceObjectAtPositionForSlotType(placementPrefab, int7, width, height, tilesChecked, ref diggableEntityAndInfos, in equipmentUpdateAspect, in equipmentUpdateSharedData, in equipmentUpdateLookupData);
					if ((!flag2 || i != num5 || j != num6) && num7 > num2)
					{
						num2 = num7;
						valueRW.bestPositionToPlaceAt = int7;
						if (num2 == num)
						{
							valueRW.canPlaceObject = true;
							break;
						}
					}
					else
					{
						if (i <= 0 && j <= 0)
						{
							continue;
						}
						x = num3 - i;
						z = num4 - j;
						int6 = new int3(x, 0, z);
						int7 = item + int6;
						num7 = CanPlaceObjectAtPositionForSlotType(placementPrefab, int7, width, height, tilesChecked, ref diggableEntityAndInfos, in equipmentUpdateAspect, in equipmentUpdateSharedData, in equipmentUpdateLookupData);
						if (num7 > num2)
						{
							num2 = num7;
							valueRW.bestPositionToPlaceAt = int7;
							if (num2 == num)
							{
								valueRW.canPlaceObject = true;
								break;
							}
						}
					}
				}
				if (valueRW.canPlaceObject)
				{
					break;
				}
			}
			if (valueRW.canPlaceObject)
			{
				break;
			}
		}
		nativeList.Dispose();
		if (!valueRW.canPlaceObject && valueRW.canBePlacedOnPlayer)
		{
			num2 = CanPlaceObjectAtPositionForSlotType(placementPrefab, int5, width, height, tilesChecked, ref diggableEntityAndInfos, in equipmentUpdateAspect, in equipmentUpdateSharedData, in equipmentUpdateLookupData);
			if (num2 == num)
			{
				valueRW.bestPositionToPlaceAt = int5;
				valueRW.canPlaceObject = true;
			}
		}
		if (num2 == 0)
		{
			int x2 = -(width - 1) / 2;
			int z2 = -(height - 1) / 2;
			if (facingDirection.id == Direction.Id.back || facingDirection.id == Direction.Id.zero)
			{
				z2 = -height + 1;
			}
			else if (facingDirection.id == Direction.Id.forward)
			{
				z2 = 0;
			}
			else if (facingDirection.id == Direction.Id.left)
			{
				x2 = -width + 1;
			}
			else if (facingDirection.id == Direction.Id.right)
			{
				x2 = 0;
			}
			valueRW.bestPositionToPlaceAt = int5 + new int3(x2, 0, z2);
		}
	}

	public static int CanPlaceObjectAtPositionForSlotType(Entity placementPrefab, int3 posToPlaceAt, int width, int height, NativeHashMap<int3, bool> tilesChecked, ref NativeList<EntityAndInfoFromPlacement> diggableEntityAndInfos, in EquipmentUpdateAspect equipmentUpdateAspect, in EquipmentUpdateSharedData equipmentUpdateSharedData, in LookupEquipmentUpdateData equipmentUpdateLookupData)
	{
		switch (equipmentUpdateAspect.equipmentSlotCD.ValueRO.slotType)
		{
		case EquipmentSlotType.PlaceObjectSlot:
			return CanPlaceObjectAtPosition(placementPrefab, posToPlaceAt, width, height, tilesChecked, in equipmentUpdateAspect, in equipmentUpdateSharedData, in equipmentUpdateLookupData);
		case EquipmentSlotType.BucketSlot:
			return PlacementHandlerBucket.CanPlaceObjectAtPosition(placementPrefab, posToPlaceAt, width, height, tilesChecked, in equipmentUpdateAspect, in equipmentUpdateSharedData, in equipmentUpdateLookupData);
		case EquipmentSlotType.ShovelSlot:
		case EquipmentSlotType.HoeSlot:
			return PlacementHandlerDigging.CanPlaceObjectAtPosition(placementPrefab, posToPlaceAt, width, height, ref diggableEntityAndInfos, in equipmentUpdateAspect, in equipmentUpdateSharedData, in equipmentUpdateLookupData);
		case EquipmentSlotType.SeederSlot:
			return PlacementHandlerSeeder.CanPlaceObjectAtPosition(placementPrefab, posToPlaceAt, width, height, ref diggableEntityAndInfos, in equipmentUpdateAspect, in equipmentUpdateSharedData, in equipmentUpdateLookupData);
		case EquipmentSlotType.PaintToolSlot:
			return PlacementHandlerPainting.CanPlaceObjectAtPosition(placementPrefab, posToPlaceAt, width, height, tilesChecked, in equipmentUpdateAspect, in equipmentUpdateSharedData, in equipmentUpdateLookupData);
		case EquipmentSlotType.RoofingToolSlot:
			return PlacementHandlerRoofingTool.CanPlaceObjectAtPosition(placementPrefab, posToPlaceAt, width, height, in equipmentUpdateAspect, in equipmentUpdateSharedData, in equipmentUpdateLookupData);
		case EquipmentSlotType.WaterCanSlot:
			return PlacementHandlerWatering.CanPlaceObjectAtPosition(placementPrefab, posToPlaceAt, width, height, tilesChecked, ref diggableEntityAndInfos, equipmentUpdateAspect, equipmentUpdateSharedData, in equipmentUpdateLookupData);
		default:
			UnityEngine.Debug.LogError("Non implemented slot in canPlaceObjectAtPosition");
			return 0;
		}
	}

	private static int CanPlaceObjectAtPosition(Entity placementPrefab, int3 posToPlaceAt, int width, int height, NativeHashMap<int3, bool> tilesChecked, in EquipmentUpdateAspect equipmentUpdateAspect, in EquipmentUpdateSharedData equipmentUpdateSharedData, in LookupEquipmentUpdateData equipmentUpdateLookupData)
	{
		ref PlacementCD valueRW = ref equipmentUpdateAspect.placementCD.ValueRW;
		ref PugDatabase.EntityObjectInfo entityObjectInfo = ref PugDatabase.GetEntityObjectInfo(equipmentUpdateAspect.equippedObjectCD.ValueRO.containedObject.objectData.objectID, equipmentUpdateSharedData.databaseBank.databaseBankBlob, valueRW.currentPrefabVariation);
		if (allowPlacingAnywhere.Data)
		{
			return width * height;
		}
		equipmentUpdateLookupData.objectPropertiesLookup.TryGetComponent(placementPrefab, out var componentData);
		float3 playerPosition = equipmentUpdateLookupData.localTransformLookup.GetRefRO(equipmentUpdateAspect.entity).ValueRO.Position;
		int totalTilesOK = 0;
		if (!componentData.IsValid || !componentData.TryGetList(1757427560, out NativeArray<ObjectID> value, (AllocatorManager.AllocatorHandle)Allocator.Temp))
		{
			value = new NativeArray<ObjectID>(0, Allocator.Temp);
		}
		if (!componentData.IsValid || !componentData.TryGetList(-789473209, out NativeArray<ObjectID> value2, (AllocatorManager.AllocatorHandle)Allocator.Temp))
		{
			value2 = new NativeArray<ObjectID>(0, Allocator.Temp);
		}
		TileCD prevTile = default(TileCD);
		TileAccessor tileAccessor = equipmentUpdateSharedData.tileAccessor;
		PhysicsCategoryTags collidesWith = equipmentUpdateAspect.equipmentSlotConstantCD.ValueRO.equipmentData.Value.GetEquipmentInfo(equipmentUpdateAspect.equipmentSlotCD.ValueRO.slotType).collidesWith;
		ColliderCacheCD colliderCacheCD = equipmentUpdateSharedData.colliderCacheCD;
		for (int i = 0; i < width; i++)
		{
			for (int j = 0; j < height; j++)
			{
				int3 pos = posToPlaceAt + new int3(i, 0, j);
				if (tilesChecked.ContainsKey(pos))
				{
					if (tilesChecked[pos])
					{
						totalTilesOK++;
					}
					continue;
				}
				if (IsNonAllowedImmuneTilePlacement(componentData, tileAccessor, pos))
				{
					return 0;
				}
				CanPlaceSharedData canPlaceSharedData = new CanPlaceSharedData
				{
					objectDataLookup = equipmentUpdateLookupData.objectDataLookup,
					localTransformLookup = equipmentUpdateLookupData.localTransformLookup,
					petLookup = equipmentUpdateLookupData.petLookup,
					tileLookup = equipmentUpdateLookupData.tileLookup,
					objectPropertiesLookup = equipmentUpdateLookupData.objectPropertiesLookup,
					playerGhostLookup = equipmentUpdateLookupData.playerGhostLookup,
					minionLookup = equipmentUpdateLookupData.minionLookup,
					indestructibleLookup = equipmentUpdateLookupData.indestructibleLookup,
					plantLookup = equipmentUpdateLookupData.plantLookup,
					critterLookup = equipmentUpdateLookupData.critterLookup,
					fireflyLookup = equipmentUpdateLookupData.fireflyLookup,
					requiresDrillLookup = equipmentUpdateLookupData.requiresDrillLookup,
					surfacePriorityLookup = equipmentUpdateLookupData.surfacePriorityLookup,
					electricityLookup = equipmentUpdateLookupData.electricityLookup,
					eventTerminalLookup = equipmentUpdateLookupData.eventTerminalLookup,
					pseudoTileLookup = equipmentUpdateLookupData.pseudoTileLookup,
					waypointLookup = equipmentUpdateLookupData.waypointLookup,
					databaseBank = equipmentUpdateSharedData.databaseBank,
					tileAccessor = equipmentUpdateSharedData.tileAccessor,
					tileWithTilesetToObjectDataMapCD = equipmentUpdateSharedData.tileWithTilesetToObjectDataMapCD
				};
				if (!ShouldCheckPlaceObjectOnTile(placementPrefab, ref valueRW, ref pos, ref totalTilesOK, in playerPosition, ref prevTile, ref entityObjectInfo, in componentData, tilesChecked, value2, value, out var isPlacingElectronic, out var foundValidTileToPlaceOn, out var tileData, in canPlaceSharedData))
				{
					continue;
				}
				bool num = i == 0;
				bool flag = i == width - 1;
				bool flag2 = j == 0;
				bool flag3 = j == height - 1;
				bool isPlacedOnEdge = num || flag || flag2 || flag3;
				bool foundValidObjectToPlaceOn = false;
				bool flag4 = false;
				PhysicsWorld physicsWorld = equipmentUpdateSharedData.physicsWorld;
				equipmentUpdateSharedData.physicsWorldHistory.GetCollisionWorldFromTick(equipmentUpdateSharedData.currentTick, 1u, ref physicsWorld, out var collWorld);
				float3 float5 = pos + new float3(0f, 1f, 0f) * 0.5f;
				NativeList<ColliderCastHit> allHits = new NativeList<ColliderCastHit>(Allocator.Temp);
				if (collWorld.CastCollider(PhysicsManager.GetColliderCastInput(float5, float5, PhysicsManager.GetBoxCollider(float3.zero, new float3(0.9f, 0.9f, 0.9f), collidesWith.Value, colliderCacheCD)), ref allHits) && allHits.Length > 0)
				{
					for (int k = 0; k < allHits.Length; k++)
					{
						flag4 = CheckEntityIsBlockingPlacement(allHits[k].Entity, in valueRW, foundValidTileToPlaceOn, tileData, ref entityObjectInfo, isPlacingElectronic, isPlacedOnEdge, posToPlaceAt, width, height, value2, value, in canPlaceSharedData, ref foundValidObjectToPlaceOn);
						if (flag4)
						{
							break;
						}
					}
				}
				allHits.Dispose();
				bool flag5 = false;
				NativeList<ColliderCastHit> allHits2 = new NativeList<ColliderCastHit>(Allocator.Temp);
				if (collWorld.CastCollider(PhysicsManager.GetColliderCastInput(float5, float5, PhysicsManager.GetBoxCollider(float3.zero, new float3(0.9f, 0.9f, 0.9f), 1024u, colliderCacheCD)), ref allHits2))
				{
					for (int l = 0; l < allHits2.Length; l++)
					{
						if (!equipmentUpdateLookupData.objectDataLookup.TryGetComponent(allHits2[l].Entity, out var componentData2))
						{
							continue;
						}
						ObjectID objectID = componentData2.objectID;
						bool flag6 = false;
						foreach (ObjectID item in value)
						{
							if (item == objectID)
							{
								flag6 = true;
								break;
							}
						}
						if (objectID == entityObjectInfo.objectID || flag6)
						{
							flag5 = true;
							break;
						}
					}
				}
				allHits2.Dispose();
				bool flag7 = (foundValidTileToPlaceOn || foundValidObjectToPlaceOn) && !flag4 && !flag5;
				if (flag7 && equipmentUpdateLookupData.adaptiveEntityBufferLookup.TryGetBuffer(placementPrefab, out var bufferData) && bufferData.Length > 0)
				{
					int2 int5 = new int2(pos.x, pos.z);
					TileCD top = tileAccessor.GetTop(int5 + AdjacentDir.GetInt2(1));
					TileCD top2 = tileAccessor.GetTop(int5 + AdjacentDir.GetInt2(16));
					TileCD top3 = tileAccessor.GetTop(int5 + AdjacentDir.GetInt2(64));
					TileCD top4 = tileAccessor.GetTop(int5 + AdjacentDir.GetInt2(4));
					flag7 = AdaptiveVariationCanBePlaced(-1, out var _, bufferData, top, top2, top3, top4);
				}
				if (flag7)
				{
					tilesChecked.Add(pos, item: true);
					totalTilesOK++;
				}
				else
				{
					tilesChecked.Add(pos, item: false);
				}
			}
		}
		value.Dispose();
		return totalTilesOK;
	}

	public static bool IsNonAllowedImmuneTilePlacement(ObjectPropertiesCD objectProperties, TileAccessor tileLookup, int3 pos)
	{
		if (objectProperties.IsValid && !objectProperties.Has(1380904855))
		{
			return tileLookup.HasType(pos.ToInt2(), TileType.immune);
		}
		return false;
	}

	public static bool ShouldCheckPlaceObjectOnTile(Entity placementPrefab, ref PlacementCD placementCD, ref int3 pos, ref int totalTilesOK, in float3 playerPosition, ref TileCD prevTile, ref PugDatabase.EntityObjectInfo infoAboutObjectToPlace, in ObjectPropertiesCD objectProperties, NativeHashMap<int3, bool> tilesChecked, NativeArray<ObjectID> canBePlacedOnObjects, NativeArray<ObjectID> canNotBePlaceOnObjects, out bool isPlacingElectronic, out bool foundValidTileToPlaceOn, out TileCD tileData, in CanPlaceSharedData canPlaceSharedData)
	{
		isPlacingElectronic = false;
		foundValidTileToPlaceOn = false;
		tileData = default(TileCD);
		if (infoAboutObjectToPlace.tileType != TileType.none && canPlaceSharedData.tileAccessor.HasType(pos.ToInt2(), infoAboutObjectToPlace.tileType))
		{
			return false;
		}
		tileData = canPlaceSharedData.tileAccessor.GetTop(pos.ToInt2());
		ObjectDataCD objectDataCD = PugDatabase.TryGetTileItemInfo(tileData.tileType, (Tileset)tileData.tileset, in canPlaceSharedData.tileWithTilesetToObjectDataMapCD);
		bool flag = placementCD.canPlaceOnWalkableTiles && tileData.tileType.IsWalkableTile();
		bool flag2 = placementCD.canBePlacedOnLowColliders && tileData.tileType.IsLowCollider();
		bool flag3 = placementCD.canPlaceOnWater && tileData.tileType == TileType.water && tileData.tileset != 3;
		bool flag4 = placementCD.canBePlacedOnLava && tileData.tileType == TileType.water && tileData.tileset == 3;
		bool flag5 = placementCD.canPlaceOnPit && tileData.tileType == TileType.pit;
		int2 sideToPlaceOn = int2.zero;
		bool flag6 = (placementCD.placeObjectOnWall = placementCD.canPlaceOnSideOfWall && tileData.tileType == TileType.wall && GetWallSideToPlaceOn(pos.ToInt2(), playerPosition, out sideToPlaceOn, canPlaceSharedData.tileAccessor));
		placementCD.wallSideToPlaceObject = sideToPlaceOn;
		if (flag6)
		{
			pos += placementCD.wallSideToPlaceObject.ToInt3();
			placementCD.canBePlacedOnBlockingObjects = true;
			if (tilesChecked.ContainsKey(pos))
			{
				if (!tilesChecked[pos])
				{
					return false;
				}
				totalTilesOK++;
				return false;
			}
		}
		else
		{
			placementCD.canBePlacedOnBlockingObjects = objectProperties.IsValid && objectProperties.Has(119039444);
		}
		foundValidTileToPlaceOn = (flag || flag2 || flag3 || flag4 || flag5 || flag6 || (placementCD.canBePlacedOnBlockingObjects && tileData.tileType == TileType.fence)) && infoAboutObjectToPlace.tileType != tileData.tileType && (placementCD.isWalkableTile || tileData.tileType != TileType.rail);
		bool flag7 = prevTile.tileType == TileType.water && prevTile.tileset != 3;
		if (prevTile.tileType != TileType.none && ((flag7 && !flag3) || (!flag7 && flag3)))
		{
			foundValidTileToPlaceOn = false;
		}
		bool flag8 = prevTile.tileType == TileType.water && prevTile.tileset == 3;
		if (prevTile.tileType != TileType.none && ((flag8 && !flag4) || (!flag8 && flag4)))
		{
			foundValidTileToPlaceOn = false;
		}
		bool flag9 = prevTile.tileType == TileType.pit;
		if (prevTile.tileType != TileType.none && ((flag9 && !flag5) || (!flag9 && flag5)))
		{
			foundValidTileToPlaceOn = false;
		}
		prevTile = tileData;
		isPlacingElectronic = canPlaceSharedData.electricityLookup.HasComponent(placementPrefab) && infoAboutObjectToPlace.tileType != TileType.circuitPlate;
		if (objectDataCD.objectID != ObjectID.None && ObjectCanBePlacedOnObject(objectDataCD.objectID, ref infoAboutObjectToPlace, canNotBePlaceOnObjects, canBePlacedOnObjects, canPlaceSharedData.objectPropertiesLookup, canPlaceSharedData.databaseBank))
		{
			foundValidTileToPlaceOn = true;
		}
		NativeArray<TileCD> nativeArray = canPlaceSharedData.tileAccessor.Get(pos.ToInt2(), Allocator.Temp);
		foreach (TileCD item in nativeArray)
		{
			TileType tileType = item.tileType;
			if (tileType == TileType.floorCrack || tileType == TileType.wallCrack)
			{
				continue;
			}
			ObjectDataCD objectDataCD2 = PugDatabase.TryGetTileItemInfo(item.tileType, (Tileset)item.tileset, in canPlaceSharedData.tileWithTilesetToObjectDataMapCD);
			if (objectDataCD2.objectID != ObjectID.None)
			{
				foreach (ObjectID item2 in canNotBePlaceOnObjects)
				{
					if (objectDataCD2.objectID == item2)
					{
						foundValidTileToPlaceOn = false;
						break;
					}
				}
			}
			if (!foundValidTileToPlaceOn)
			{
				break;
			}
		}
		nativeArray.Dispose();
		return true;
	}

	public static bool CheckEntityIsBlockingPlacement(Entity hitEntity, in PlacementCD placementCD, bool foundValidTileToPlaceOn, TileCD tileData, ref PugDatabase.EntityObjectInfo infoAboutObjectToPlace, bool isPlacingElectronic, bool isPlacedOnEdge, int3 posToPlaceAt, int width, int height, NativeArray<ObjectID> canBePlacedOnObjects, NativeArray<ObjectID> canNotBePlaceOnObjects, in CanPlaceSharedData canPlaceSharedData, ref bool foundValidObjectToPlaceOn)
	{
		bool flag = canPlaceSharedData.tileLookup.HasComponent(hitEntity);
		canPlaceSharedData.objectDataLookup.TryGetComponent(hitEntity, out var componentData);
		ObjectID objectID = componentData.objectID;
		bool flag2 = canPlaceSharedData.playerGhostLookup.HasComponent(hitEntity);
		bool flag3 = canPlaceSharedData.petLookup.HasComponent(hitEntity);
		bool flag4 = canPlaceSharedData.minionLookup.HasComponent(hitEntity);
		bool flag5 = ObjectCanBePlacedOnObject(objectID, ref infoAboutObjectToPlace, canNotBePlaceOnObjects, canBePlacedOnObjects, canPlaceSharedData.objectPropertiesLookup, canPlaceSharedData.databaseBank);
		ObjectPropertiesCD componentData2;
		bool flag6 = canPlaceSharedData.objectPropertiesLookup.TryGetComponent(hitEntity, out componentData2);
		bool flag7 = flag6 && componentData2.Has(119039444);
		bool flag8 = placementCD.placeObjectOnWall && flag6 && componentData2.Has(-1832234709);
		bool flag9 = placementCD.blockedByObjectsOnWalls && flag6 && componentData2.Has(-1171081164);
		bool flag10 = canPlaceSharedData.indestructibleLookup.HasAndIsComponentEnabled(hitEntity);
		bool flag11 = canPlaceSharedData.waypointLookup.HasComponent(hitEntity);
		if (canPlaceSharedData.plantLookup.HasComponent(hitEntity))
		{
			_ = 1;
		}
		else if (flag6)
		{
			componentData2.Has(-440732150);
		}
		else
			_ = 0;
		bool flag12 = canPlaceSharedData.critterLookup.HasComponent(hitEntity);
		bool flag13 = canPlaceSharedData.fireflyLookup.HasComponent(hitEntity);
		bool flag14 = canPlaceSharedData.pseudoTileLookup.HasComponent(hitEntity);
		bool flag15 = canPlaceSharedData.requiresDrillLookup.HasComponent(hitEntity);
		SurfacePriorityCD componentData3;
		bool flag16 = !foundValidTileToPlaceOn || !canPlaceSharedData.surfacePriorityLookup.TryGetComponent(hitEntity, out componentData3) || componentData3.Value > tileData.tileType.GetSurfacePriorityFromJob();
		if (flag2)
		{
			if (!placementCD.canBePlacedOnPlayer && isPlacedOnEdge)
			{
				float3 position = canPlaceSharedData.localTransformLookup[hitEntity].Position;
				if (IsPlayerInsideTileArea(posToPlaceAt, width, height, position, 0.1f))
				{
					return true;
				}
			}
		}
		else
		{
			if (flag3 || flag4)
			{
				return false;
			}
			if (flag14 && canPlaceSharedData.pseudoTileLookup[hitEntity].tileType == TileType.ancientCircuitPlate)
			{
				return false;
			}
			if ((objectID == infoAboutObjectToPlace.objectID && !flag13) || (!flag && !flag7 && !flag5 && !placementCD.canBePlacedOnBlockingObjects && !flag12 && flag16) || flag10 || flag15 || flag8 || flag9 || flag11)
			{
				return true;
			}
			if (isPlacingElectronic && canPlaceSharedData.electricityLookup.HasComponent(hitEntity) && (!flag14 || canPlaceSharedData.pseudoTileLookup[hitEntity].tileType != TileType.circuitPlate))
			{
				return true;
			}
			if (canPlaceSharedData.eventTerminalLookup.HasComponent(hitEntity))
			{
				return true;
			}
			if (flag5)
			{
				foundValidObjectToPlaceOn = true;
			}
			else if (infoAboutObjectToPlace.tileType != TileType.none && flag14 && canPlaceSharedData.pseudoTileLookup[hitEntity].tileType == infoAboutObjectToPlace.tileType)
			{
				return true;
			}
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool IsPlayerInsideTileArea(float3 placePosition, float width, float height, float3 playerPosition, float allowedEdgePenetration)
	{
		float num = width - 2f * allowedEdgePenetration;
		float num2 = height - 2f * allowedEdgePenetration;
		float3 float5 = placePosition + new float3(-0.5f + allowedEdgePenetration, 0f, -0.5f + allowedEdgePenetration);
		if (playerPosition.x >= float5.x && playerPosition.x <= float5.x + num && playerPosition.z >= float5.z)
		{
			return playerPosition.z <= float5.z + num2;
		}
		return false;
	}

	private static bool ObjectCanBePlacedOnObject(ObjectID idToCheck, ref PugDatabase.EntityObjectInfo infoAboutObjectToPlace, NativeArray<ObjectID> canNotBePlaceOnObjects, NativeArray<ObjectID> canBePlaceOnObjects, ComponentLookup<ObjectPropertiesCD> objectPropertiesLookup, PugDatabase.DatabaseBankCD databaseBankCD)
	{
		foreach (ObjectID item in canNotBePlaceOnObjects)
		{
			if (item == idToCheck)
			{
				return false;
			}
		}
		foreach (ObjectID item2 in canBePlaceOnObjects)
		{
			if (item2 == idToCheck)
			{
				return true;
			}
		}
		Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(idToCheck, databaseBankCD.databaseBankBlob);
		if (!objectPropertiesLookup.TryGetComponent(primaryPrefabEntity, out var componentData) || infoAboutObjectToPlace.objectID == ObjectID.None || !componentData.TryGetList(-789473209, out NativeArray<ObjectID> value, (AllocatorManager.AllocatorHandle)Allocator.Temp))
		{
			return false;
		}
		bool result = false;
		foreach (ObjectID item3 in value)
		{
			if (item3 == infoAboutObjectToPlace.objectID)
			{
				result = true;
				break;
			}
		}
		value.Dispose();
		return result;
	}

	public void UpdatePlaceIcon(bool immediate, in PlacementCD placementCD, ObjectDataCD infoAboutObjectToPlace, DynamicBuffer<PlacementSizeByEquipmentTypeBuffer> placementSizeByEquipmentTypeBuffer, EquipmentSlotCD equipmentSlotCD, Entity placementPrefab, ComponentLookup<DirectionCD> directionLookup, ComponentLookup<ResizableTileSizeCD> sizeVariationLookup, ComponentLookup<DirectionBasedOnVariationCD> directionBasedOnVariationLookup, ComponentLookup<ObjectPropertiesCD> objectPropertiesLookup, PugDatabase.DatabaseBankCD databaseBankCD)
	{
		int num = infoAboutObjectToPlace.variation;
		bool flag = ObjectCanBeRotated(placementPrefab, directionBasedOnVariationLookup, objectPropertiesLookup, directionLookup);
		bool flag2 = ObjectCanBeToggledToNewNonRotationOption(placementPrefab, objectPropertiesLookup);
		DisplayPlaceableType value = DisplayPlaceableType.Default;
		if (flag)
		{
			num = placementCD.rotationVariationToPlace;
		}
		else if (flag2)
		{
			num = placementCD.nonRotationVariationToPlace;
		}
		if (flag || flag2)
		{
			if (flag)
			{
				num = (num + GetIconRotationOffset(placementPrefab, directionLookup)) % 4;
			}
			if (objectPropertiesLookup.TryGetComponent(placementPrefab, out var componentData))
			{
				componentData.TryGet<DisplayPlaceableType>(-1446308993, out value);
			}
		}
		Vector3Int p = new Vector3Int(placementCD.bestPositionToPlaceAt.x, placementCD.bestPositionToPlaceAt.y, placementCD.bestPositionToPlaceAt.z);
		p = EntityMonoBehaviour.ToRenderFromWorld(p);
		placeableIcon.SetPosition(p, immediate);
		placeableIcon.SetState(placementCD.canPlaceObject, num, flag || flag2, value);
		int2 currentSize = GetCurrentSize(placementPrefab, infoAboutObjectToPlace, in placementCD, placementSizeByEquipmentTypeBuffer, equipmentSlotCD, databaseBankCD, directionBasedOnVariationLookup, objectPropertiesLookup, directionLookup, sizeVariationLookup);
		placeableIcon.SetSize(currentSize.x, currentSize.y);
	}

	public int GetIconRotationOffset(Entity placementPrefab, ComponentLookup<DirectionCD> directionLookup)
	{
		directionLookup.TryGetComponent(placementPrefab, out var componentData);
		return componentData.rotationIconOffset;
	}

	public static int2 GetCurrentSize(Entity placementPrefab, ObjectDataCD placementObjectData, in PlacementCD placementCD, DynamicBuffer<PlacementSizeByEquipmentTypeBuffer> placementSizeByEquipmentTypeBuffer, EquipmentSlotCD equipmentSlotCD, PugDatabase.DatabaseBankCD databaseCD, ComponentLookup<DirectionBasedOnVariationCD> directionBasedOnVariationLookup, ComponentLookup<ObjectPropertiesCD> objectPropertiesLookup, ComponentLookup<DirectionCD> directionLookup, ComponentLookup<ResizableTileSizeCD> resizableTileSizeLookup)
	{
		int variation = placementObjectData.variation;
		bool num = ObjectCanBeRotated(placementPrefab, directionBasedOnVariationLookup, objectPropertiesLookup, directionLookup);
		bool flag = ObjectCanBeToggledToNewNonRotationOption(placementPrefab, objectPropertiesLookup);
		if (num)
		{
			variation = placementCD.rotationVariationToPlace;
		}
		else if (flag)
		{
			variation = placementCD.nonRotationVariationToPlace;
		}
		ref PugDatabase.EntityObjectInfo entityObjectInfo = ref PugDatabase.GetEntityObjectInfo(placementObjectData.objectID, databaseCD.databaseBankBlob, variation);
		int2 result = new int2(1, 1);
		if (ShouldRotatePhysics(placementPrefab, directionLookup) && entityObjectInfo.objectID != ObjectID.None)
		{
			return DirectionCD.GetPrefabTileSize(entityObjectInfo.prefabTileSize, DirectionBasedOnVariationCD.GetDirectionFromVariation(placementCD.rotationVariationToPlace));
		}
		if (entityObjectInfo.objectID != ObjectID.None)
		{
			result = entityObjectInfo.prefabTileSize;
			if (resizableTileSizeLookup.TryGetComponent(placementPrefab, out var _))
			{
				result = EquipmentSlot.GetTileSizeFromVariation(in equipmentSlotCD, in placementSizeByEquipmentTypeBuffer, entityObjectInfo.prefabTileSize);
			}
		}
		return result;
	}

	public void Enable()
	{
		placeableIcon.transform.parent = Manager.camera.VolatileRenderAnchor;
		placeableIcon.transform.SetLocalScale();
		base.gameObject.SetActive(value: true);
	}

	public void Disable()
	{
		placeableIcon.transform.parent = base.transform;
		base.gameObject.SetActive(value: false);
	}

	public static void Activate(ref PlacementCD placementCD, Entity placementPrefab, ComponentLookup<ObjectPropertiesCD> objectPropertiesLookup, ComponentLookup<TileCD> tileLookup, ComponentLookup<PseudoTileCD> pseudoTileLookup)
	{
		placementCD.canPlaceOnWalkableTiles = true;
		placementCD.canPlaceOnWater = false;
		placementCD.canBePlacedOnLava = false;
		placementCD.canPlaceOnPit = false;
		placementCD.canPlaceOnSideOfWall = false;
		placementCD.canBePlacedOnPlayer = false;
		placementCD.blockedByObjectsOnWalls = false;
		placementCD.canBePlacedOnLowColliders = false;
		if (objectPropertiesLookup.TryGetComponent(placementPrefab, out var componentData) && componentData.Has(-975748197))
		{
			placementCD.canPlaceOnWalkableTiles = componentData.Has(1497889171);
			placementCD.isWalkableTile = IsWalkableTile(placementPrefab, tileLookup, pseudoTileLookup);
			placementCD.canPlaceOnWater = componentData.Has(-1324171664);
			placementCD.canBePlacedOnLava = componentData.Has(-1535225238);
			placementCD.canPlaceOnPit = componentData.Has(-1827158511);
			placementCD.canPlaceOnSideOfWall = componentData.Has(121328368);
			placementCD.canBePlacedOnPlayer = componentData.Has(-1370484423);
			placementCD.canBePlacedOnBlockingObjects = componentData.Has(119039444);
			placementCD.blockedByObjectsOnWalls = componentData.Has(-1832234709);
			placementCD.canBePlacedOnLowColliders = componentData.Has(-1242875768);
		}
	}

	private static bool IsWalkableTile(Entity prefab, ComponentLookup<TileCD> tileLookup, ComponentLookup<PseudoTileCD> pseudoTileLookup)
	{
		if (!tileLookup.TryGetComponent(prefab, out var componentData) || !componentData.tileType.IsWalkableTile())
		{
			if (pseudoTileLookup.TryGetComponent(prefab, out var componentData2))
			{
				return componentData2.tileType.IsWalkableTile();
			}
			return false;
		}
		return true;
	}

	public static bool AdaptiveVariationCanBePlaced(int activeVariation, out int newVariation, DynamicBuffer<AdaptiveEntityBuffer> adaptiveBuffer, TileInfo leftTile, TileInfo rightTile, TileInfo forwardTile, TileInfo backTile)
	{
		return AdaptiveVariationCanBePlaced(activeVariation, out newVariation, adaptiveBuffer, new TileCD
		{
			tileType = leftTile.tileType,
			tileset = leftTile.tileset
		}, new TileCD
		{
			tileType = rightTile.tileType,
			tileset = rightTile.tileset
		}, new TileCD
		{
			tileType = forwardTile.tileType,
			tileset = forwardTile.tileset
		}, new TileCD
		{
			tileType = backTile.tileType,
			tileset = backTile.tileset
		});
	}

	public static bool AdaptiveVariationCanBePlaced(int activeVariation, out int newVariation, DynamicBuffer<AdaptiveEntityBuffer> adaptiveBuffer, TileCD leftTile, TileCD rightTile, TileCD forwardTile, TileCD backTile)
	{
		newVariation = activeVariation;
		int index = 0;
		int num = 0;
		int num2 = 0;
		bool flag = false;
		int num3 = 0;
		for (int i = 0; i < adaptiveBuffer.Length; i++)
		{
			num2 = 0;
			AdaptiveCondition adaptiveCondition = adaptiveBuffer[i].adaptiveCondition;
			if (IsMatchingTiles(adaptiveCondition.leftTile, leftTile, adaptiveCondition.allowAnyTilesetToMatch))
			{
				num2++;
			}
			if (IsMatchingTiles(adaptiveCondition.rightTile, rightTile, adaptiveCondition.allowAnyTilesetToMatch))
			{
				num2++;
			}
			if (IsMatchingTiles(adaptiveCondition.forwardTile, forwardTile, adaptiveCondition.allowAnyTilesetToMatch))
			{
				num2++;
			}
			if (IsMatchingTiles(adaptiveCondition.backTile, backTile, adaptiveCondition.allowAnyTilesetToMatch))
			{
				num2++;
			}
			bool flag2 = adaptiveBuffer[i].adaptiveCondition.matchesNeeded == num2;
			if (num2 >= num && flag2)
			{
				index = i;
				num = num2;
				flag = true;
				if (activeVariation == adaptiveBuffer[i].adaptiveCondition.variation)
				{
					num3 = num2;
				}
			}
		}
		if (flag && num3 < num)
		{
			newVariation = adaptiveBuffer[index].adaptiveCondition.variation;
		}
		return flag;
	}

	public static bool IsMatchingTiles(TileCondition tileCondition, TileCD tile, bool allowAnyTilesetToMatch)
	{
		if (tileCondition.tileType == TileType.wall)
		{
			if (tile.tileType.IsWallTile() && tile.tileType != TileType.greatWall)
			{
				if (!allowAnyTilesetToMatch)
				{
					return tileCondition.tileset == (Tileset)tile.tileset;
				}
				return true;
			}
			return false;
		}
		if (tileCondition.tileType == tile.tileType)
		{
			if (allowAnyTilesetToMatch || tileCondition.tileset == (Tileset)tile.tileset)
			{
				return true;
			}
			if (tile.tileType == TileType.fence)
			{
				if (!IsPaintedTile(tile.tileset))
				{
					return IsPaintedTile((int)tileCondition.tileset);
				}
				return true;
			}
		}
		return false;
	}

	public static bool IsPaintedGlass(int tileset)
	{
		switch (tileset)
		{
		case 41:
		case 42:
		case 43:
		case 44:
		case 45:
		case 46:
		case 47:
		case 48:
		case 49:
		case 50:
		case 51:
		case 52:
		case 63:
		case 64:
			return true;
		default:
			return false;
		}
	}

	private static bool IsPaintedTile(int tileset)
	{
		switch (tileset)
		{
		case 15:
		case 16:
		case 17:
		case 18:
		case 19:
		case 20:
		case 21:
		case 22:
		case 37:
		case 38:
		case 39:
		case 40:
		case 61:
		case 62:
			return true;
		default:
			return false;
		}
	}

	public static bool GetWallSideToPlaceOn(int2 wallTilePos, float3 placerPosition, out int2 sideToPlaceOn, TileAccessor tileAccessor)
	{
		sideToPlaceOn = int2.zero;
		float num = 99f;
		for (int i = 0; i < Direction.allFourClockwise.Length; i++)
		{
			int2 i2 = Direction.allFourClockwise[i].i2;
			int2 worldPosition = wallTilePos + i2;
			if (!tileAccessor.HasType(worldPosition, TileType.wall))
			{
				float num2 = math.distancesq(placerPosition, (wallTilePos + i2).ToFloat3());
				if (num2 < num)
				{
					num = num2;
					sideToPlaceOn = i2;
				}
			}
		}
		if (num < 99f)
		{
			return true;
		}
		return false;
	}
}
