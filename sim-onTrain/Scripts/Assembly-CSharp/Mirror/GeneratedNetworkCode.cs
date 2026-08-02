using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Dissonance.Integrations.MirrorIgnorance;
using UnityEngine;

namespace Mirror
{
	[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
	public static class GeneratedNetworkCode
	{
		public static TimeSnapshotMessage _Read_Mirror_002ETimeSnapshotMessage(NetworkReader reader)
		{
			return default(TimeSnapshotMessage);
		}

		public static void _Write_Mirror_002ETimeSnapshotMessage(NetworkWriter writer, TimeSnapshotMessage value)
		{
		}

		public static ReadyMessage _Read_Mirror_002EReadyMessage(NetworkReader reader)
		{
			return default(ReadyMessage);
		}

		public static void _Write_Mirror_002EReadyMessage(NetworkWriter writer, ReadyMessage value)
		{
		}

		public static NotReadyMessage _Read_Mirror_002ENotReadyMessage(NetworkReader reader)
		{
			return default(NotReadyMessage);
		}

		public static void _Write_Mirror_002ENotReadyMessage(NetworkWriter writer, NotReadyMessage value)
		{
		}

		public static AddPlayerMessage _Read_Mirror_002EAddPlayerMessage(NetworkReader reader)
		{
			return default(AddPlayerMessage);
		}

		public static void _Write_Mirror_002EAddPlayerMessage(NetworkWriter writer, AddPlayerMessage value)
		{
		}

		public static SceneMessage _Read_Mirror_002ESceneMessage(NetworkReader reader)
		{
			return new SceneMessage
			{
				sceneName = reader.ReadString(),
				sceneOperation = _Read_Mirror_002ESceneOperation(reader),
				customHandling = reader.ReadBool()
			};
		}

		public static SceneOperation _Read_Mirror_002ESceneOperation(NetworkReader reader)
		{
			return (SceneOperation)NetworkReaderExtensions.ReadByte(reader);
		}

		public static void _Write_Mirror_002ESceneMessage(NetworkWriter writer, SceneMessage value)
		{
			writer.WriteString(value.sceneName);
			_Write_Mirror_002ESceneOperation(writer, value.sceneOperation);
			writer.WriteBool(value.customHandling);
		}

		public static void _Write_Mirror_002ESceneOperation(NetworkWriter writer, SceneOperation value)
		{
			NetworkWriterExtensions.WriteByte(writer, (byte)value);
		}

		public static CommandMessage _Read_Mirror_002ECommandMessage(NetworkReader reader)
		{
			return new CommandMessage
			{
				netId = reader.ReadUInt(),
				componentIndex = NetworkReaderExtensions.ReadByte(reader),
				functionHash = reader.ReadUShort(),
				payload = reader.ReadBytesAndSizeSegment()
			};
		}

		public static void _Write_Mirror_002ECommandMessage(NetworkWriter writer, CommandMessage value)
		{
			writer.WriteUInt(value.netId);
			NetworkWriterExtensions.WriteByte(writer, value.componentIndex);
			writer.WriteUShort(value.functionHash);
			writer.WriteBytesAndSizeSegment(value.payload);
		}

		public static RpcMessage _Read_Mirror_002ERpcMessage(NetworkReader reader)
		{
			return new RpcMessage
			{
				netId = reader.ReadUInt(),
				componentIndex = NetworkReaderExtensions.ReadByte(reader),
				functionHash = reader.ReadUShort(),
				payload = reader.ReadBytesAndSizeSegment()
			};
		}

		public static void _Write_Mirror_002ERpcMessage(NetworkWriter writer, RpcMessage value)
		{
			writer.WriteUInt(value.netId);
			NetworkWriterExtensions.WriteByte(writer, value.componentIndex);
			writer.WriteUShort(value.functionHash);
			writer.WriteBytesAndSizeSegment(value.payload);
		}

		public static SpawnMessage _Read_Mirror_002ESpawnMessage(NetworkReader reader)
		{
			return new SpawnMessage
			{
				netId = reader.ReadUInt(),
				isLocalPlayer = reader.ReadBool(),
				isOwner = reader.ReadBool(),
				sceneId = reader.ReadULong(),
				assetId = reader.ReadUInt(),
				position = reader.ReadVector3(),
				rotation = reader.ReadQuaternion(),
				scale = reader.ReadVector3(),
				payload = reader.ReadBytesAndSizeSegment()
			};
		}

		public static void _Write_Mirror_002ESpawnMessage(NetworkWriter writer, SpawnMessage value)
		{
			writer.WriteUInt(value.netId);
			writer.WriteBool(value.isLocalPlayer);
			writer.WriteBool(value.isOwner);
			writer.WriteULong(value.sceneId);
			writer.WriteUInt(value.assetId);
			writer.WriteVector3(value.position);
			writer.WriteQuaternion(value.rotation);
			writer.WriteVector3(value.scale);
			writer.WriteBytesAndSizeSegment(value.payload);
		}

		public static ChangeOwnerMessage _Read_Mirror_002EChangeOwnerMessage(NetworkReader reader)
		{
			return new ChangeOwnerMessage
			{
				netId = reader.ReadUInt(),
				isOwner = reader.ReadBool(),
				isLocalPlayer = reader.ReadBool()
			};
		}

		public static void _Write_Mirror_002EChangeOwnerMessage(NetworkWriter writer, ChangeOwnerMessage value)
		{
			writer.WriteUInt(value.netId);
			writer.WriteBool(value.isOwner);
			writer.WriteBool(value.isLocalPlayer);
		}

		public static ObjectSpawnStartedMessage _Read_Mirror_002EObjectSpawnStartedMessage(NetworkReader reader)
		{
			return default(ObjectSpawnStartedMessage);
		}

		public static void _Write_Mirror_002EObjectSpawnStartedMessage(NetworkWriter writer, ObjectSpawnStartedMessage value)
		{
		}

		public static ObjectSpawnFinishedMessage _Read_Mirror_002EObjectSpawnFinishedMessage(NetworkReader reader)
		{
			return default(ObjectSpawnFinishedMessage);
		}

		public static void _Write_Mirror_002EObjectSpawnFinishedMessage(NetworkWriter writer, ObjectSpawnFinishedMessage value)
		{
		}

		public static ObjectDestroyMessage _Read_Mirror_002EObjectDestroyMessage(NetworkReader reader)
		{
			return new ObjectDestroyMessage
			{
				netId = reader.ReadUInt()
			};
		}

		public static void _Write_Mirror_002EObjectDestroyMessage(NetworkWriter writer, ObjectDestroyMessage value)
		{
			writer.WriteUInt(value.netId);
		}

		public static ObjectHideMessage _Read_Mirror_002EObjectHideMessage(NetworkReader reader)
		{
			return new ObjectHideMessage
			{
				netId = reader.ReadUInt()
			};
		}

		public static void _Write_Mirror_002EObjectHideMessage(NetworkWriter writer, ObjectHideMessage value)
		{
			writer.WriteUInt(value.netId);
		}

		public static EntityStateMessage _Read_Mirror_002EEntityStateMessage(NetworkReader reader)
		{
			return new EntityStateMessage
			{
				netId = reader.ReadUInt(),
				payload = reader.ReadBytesAndSizeSegment()
			};
		}

		public static void _Write_Mirror_002EEntityStateMessage(NetworkWriter writer, EntityStateMessage value)
		{
			writer.WriteUInt(value.netId);
			writer.WriteBytesAndSizeSegment(value.payload);
		}

		public static NetworkPingMessage _Read_Mirror_002ENetworkPingMessage(NetworkReader reader)
		{
			return new NetworkPingMessage
			{
				localTime = reader.ReadDouble()
			};
		}

		public static void _Write_Mirror_002ENetworkPingMessage(NetworkWriter writer, NetworkPingMessage value)
		{
			writer.WriteDouble(value.localTime);
		}

		public static NetworkPongMessage _Read_Mirror_002ENetworkPongMessage(NetworkReader reader)
		{
			return new NetworkPongMessage
			{
				localTime = reader.ReadDouble()
			};
		}

		public static void _Write_Mirror_002ENetworkPongMessage(NetworkWriter writer, NetworkPongMessage value)
		{
			writer.WriteDouble(value.localTime);
		}

		public static void _Write_UnityEngine_002EVector3_005B_005D(NetworkWriter writer, Vector3[] value)
		{
			writer.WriteArray(value);
		}

		public static Vector3[] _Read_UnityEngine_002EVector3_005B_005D(NetworkReader reader)
		{
			return reader.ReadArray<Vector3>();
		}

		public static void _Write_GameAudios(NetworkWriter writer, GameAudios value)
		{
			writer.WriteInt((int)value);
		}

		public static GameAudios _Read_GameAudios(NetworkReader reader)
		{
			return (GameAudios)reader.ReadInt();
		}

		public static ObjectServerData _Read_ObjectServerData(NetworkReader reader)
		{
			if (!reader.ReadBool())
			{
				return null;
			}
			ObjectServerData objectServerData = new ObjectServerData();
			objectServerData.health = reader.ReadFloat();
			objectServerData.cellID = reader.ReadInt();
			objectServerData.objectID = reader.ReadInt();
			objectServerData.isDestroyed = reader.ReadBool();
			objectServerData.isLootable = reader.ReadBool();
			return objectServerData;
		}

		public static void _Write_ObjectServerData(NetworkWriter writer, ObjectServerData value)
		{
			if (value == null)
			{
				writer.WriteBool(value: false);
				return;
			}
			writer.WriteBool(value: true);
			writer.WriteFloat(value.health);
			writer.WriteInt(value.cellID);
			writer.WriteInt(value.objectID);
			writer.WriteBool(value.isDestroyed);
			writer.WriteBool(value.isLootable);
		}

		public static NetworkBuildData _Read_NetworkBuildData(NetworkReader reader)
		{
			return new NetworkBuildData
			{
				itemName = reader.ReadString(),
				localPosition = reader.ReadVector3(),
				localEulerAngles = reader.ReadVector3(),
				health = reader.ReadFloat(),
				wagonID = reader.ReadInt(),
				itemID = reader.ReadString(),
				stateData = reader.ReadString(),
				isNetworkObject = reader.ReadBool(),
				parentObjectID = reader.ReadString(),
				parentLeafIndex = reader.ReadInt()
			};
		}

		public static void _Write_NetworkBuildData(NetworkWriter writer, NetworkBuildData value)
		{
			writer.WriteString(value.itemName);
			writer.WriteVector3(value.localPosition);
			writer.WriteVector3(value.localEulerAngles);
			writer.WriteFloat(value.health);
			writer.WriteInt(value.wagonID);
			writer.WriteString(value.itemID);
			writer.WriteString(value.stateData);
			writer.WriteBool(value.isNetworkObject);
			writer.WriteString(value.parentObjectID);
			writer.WriteInt(value.parentLeafIndex);
		}

		public static ChunkObjectData _Read_ChunkObjectData(NetworkReader reader)
		{
			return new ChunkObjectData
			{
				objectID = reader.ReadInt(),
				health = reader.ReadFloat(),
				isDestroyed = reader.ReadBool()
			};
		}

		public static void _Write_ChunkObjectData(NetworkWriter writer, ChunkObjectData value)
		{
			writer.WriteInt(value.objectID);
			writer.WriteFloat(value.health);
			writer.WriteBool(value.isDestroyed);
		}

		public static PlayerInventorySync _Read_PlayerInventorySync(NetworkReader reader)
		{
			return new PlayerInventorySync
			{
				playerID = reader.ReadString(),
				inventoryData = _Read_System_002ECollections_002EGeneric_002EList_00601_003CInventorySaveData_003E(reader)
			};
		}

		public static List<InventorySaveData> _Read_System_002ECollections_002EGeneric_002EList_00601_003CInventorySaveData_003E(NetworkReader reader)
		{
			return reader.ReadList<InventorySaveData>();
		}

		public static InventorySaveData _Read_InventorySaveData(NetworkReader reader)
		{
			if (!reader.ReadBool())
			{
				return null;
			}
			InventorySaveData inventorySaveData = new InventorySaveData();
			inventorySaveData.itemID = reader.ReadString();
			inventorySaveData.count = reader.ReadInt();
			inventorySaveData.inventoryID = reader.ReadInt();
			inventorySaveData.itemMagazineCount = reader.ReadInt();
			inventorySaveData.itemDurability = reader.ReadFloat();
			return inventorySaveData;
		}

		public static void _Write_PlayerInventorySync(NetworkWriter writer, PlayerInventorySync value)
		{
			writer.WriteString(value.playerID);
			_Write_System_002ECollections_002EGeneric_002EList_00601_003CInventorySaveData_003E(writer, value.inventoryData);
		}

		public static void _Write_System_002ECollections_002EGeneric_002EList_00601_003CInventorySaveData_003E(NetworkWriter writer, List<InventorySaveData> value)
		{
			writer.WriteList(value);
		}

		public static void _Write_InventorySaveData(NetworkWriter writer, InventorySaveData value)
		{
			if (value == null)
			{
				writer.WriteBool(value: false);
				return;
			}
			writer.WriteBool(value: true);
			writer.WriteString(value.itemID);
			writer.WriteInt(value.count);
			writer.WriteInt(value.inventoryID);
			writer.WriteInt(value.itemMagazineCount);
			writer.WriteFloat(value.itemDurability);
		}

		public static PlayerStatusSync _Read_PlayerStatusSync(NetworkReader reader)
		{
			return new PlayerStatusSync
			{
				playerID = reader.ReadString(),
				statusData = _Read_PlayerStatusSaveData(reader)
			};
		}

		public static PlayerStatusSaveData _Read_PlayerStatusSaveData(NetworkReader reader)
		{
			return new PlayerStatusSaveData
			{
				hasData = reader.ReadBool(),
				posX = reader.ReadFloat(),
				posY = reader.ReadFloat(),
				posZ = reader.ReadFloat(),
				rotX = reader.ReadFloat(),
				rotY = reader.ReadFloat(),
				rotZ = reader.ReadFloat(),
				health = reader.ReadFloat(),
				food = reader.ReadFloat(),
				water = reader.ReadFloat(),
				lastSelectedSlot = reader.ReadInt()
			};
		}

		public static void _Write_PlayerStatusSync(NetworkWriter writer, PlayerStatusSync value)
		{
			writer.WriteString(value.playerID);
			_Write_PlayerStatusSaveData(writer, value.statusData);
		}

		public static void _Write_PlayerStatusSaveData(NetworkWriter writer, PlayerStatusSaveData value)
		{
			writer.WriteBool(value.hasData);
			writer.WriteFloat(value.posX);
			writer.WriteFloat(value.posY);
			writer.WriteFloat(value.posZ);
			writer.WriteFloat(value.rotX);
			writer.WriteFloat(value.rotY);
			writer.WriteFloat(value.rotZ);
			writer.WriteFloat(value.health);
			writer.WriteFloat(value.food);
			writer.WriteFloat(value.water);
			writer.WriteInt(value.lastSelectedSlot);
		}

		public static PlayerTutorialSync _Read_PlayerTutorialSync(NetworkReader reader)
		{
			return new PlayerTutorialSync
			{
				playerID = reader.ReadString(),
				tutorialData = _Read_PlayerTutorialSaveData(reader)
			};
		}

		public static PlayerTutorialSaveData _Read_PlayerTutorialSaveData(NetworkReader reader)
		{
			return new PlayerTutorialSaveData
			{
				hasData = reader.ReadBool(),
				currentGroupIndex = reader.ReadInt(),
				taskEntries = _Read_System_002ECollections_002EGeneric_002EList_00601_003CTutorialTaskEntry_003E(reader)
			};
		}

		public static List<TutorialTaskEntry> _Read_System_002ECollections_002EGeneric_002EList_00601_003CTutorialTaskEntry_003E(NetworkReader reader)
		{
			return reader.ReadList<TutorialTaskEntry>();
		}

		public static TutorialTaskEntry _Read_TutorialTaskEntry(NetworkReader reader)
		{
			return new TutorialTaskEntry
			{
				groupIndex = reader.ReadInt(),
				taskIndex = reader.ReadInt(),
				progress = reader.ReadInt(),
				completed = reader.ReadBool()
			};
		}

		public static void _Write_PlayerTutorialSync(NetworkWriter writer, PlayerTutorialSync value)
		{
			writer.WriteString(value.playerID);
			_Write_PlayerTutorialSaveData(writer, value.tutorialData);
		}

		public static void _Write_PlayerTutorialSaveData(NetworkWriter writer, PlayerTutorialSaveData value)
		{
			writer.WriteBool(value.hasData);
			writer.WriteInt(value.currentGroupIndex);
			_Write_System_002ECollections_002EGeneric_002EList_00601_003CTutorialTaskEntry_003E(writer, value.taskEntries);
		}

		public static void _Write_System_002ECollections_002EGeneric_002EList_00601_003CTutorialTaskEntry_003E(NetworkWriter writer, List<TutorialTaskEntry> value)
		{
			writer.WriteList(value);
		}

		public static void _Write_TutorialTaskEntry(NetworkWriter writer, TutorialTaskEntry value)
		{
			writer.WriteInt(value.groupIndex);
			writer.WriteInt(value.taskIndex);
			writer.WriteInt(value.progress);
			writer.WriteBool(value.completed);
		}

		public static DroppedItemData _Read_DroppedItemData(NetworkReader reader)
		{
			return new DroppedItemData
			{
				itemName = reader.ReadString(),
				itemCount = reader.ReadInt()
			};
		}

		public static void _Write_DroppedItemData(NetworkWriter writer, DroppedItemData value)
		{
			writer.WriteString(value.itemName);
			writer.WriteInt(value.itemCount);
		}

		public static CollectableItemSync _Read_CollectableItemSync(NetworkReader reader)
		{
			return new CollectableItemSync
			{
				itemName = reader.ReadString(),
				isResearched = reader.ReadBool(),
				isLearned = reader.ReadBool()
			};
		}

		public static void _Write_CollectableItemSync(NetworkWriter writer, CollectableItemSync value)
		{
			writer.WriteString(value.itemName);
			writer.WriteBool(value.isResearched);
			writer.WriteBool(value.isLearned);
		}

		public static CategoryUnlockSync _Read_CategoryUnlockSync(NetworkReader reader)
		{
			return new CategoryUnlockSync
			{
				categoryName = reader.ReadString(),
				isUnlocked = reader.ReadBool()
			};
		}

		public static void _Write_CategoryUnlockSync(NetworkWriter writer, CategoryUnlockSync value)
		{
			writer.WriteString(value.categoryName);
			writer.WriteBool(value.isUnlocked);
		}

		public static void _Write_System_002ECollections_002EGeneric_002EList_00601_003CInventorySlotsDataNetwork_003E(NetworkWriter writer, List<InventorySlotsDataNetwork> value)
		{
			writer.WriteList(value);
		}

		public static void _Write_InventorySlotsDataNetwork(NetworkWriter writer, InventorySlotsDataNetwork value)
		{
			writer.WriteString(value.itemName);
			writer.WriteInt(value.slotID);
			writer.WriteInt(value.itemCountInSlot);
			writer.WriteInt(value.maxCapacity);
			writer.WriteInt(value.currentMagazineCount);
			writer.WriteFloat(value.currentDurability);
		}

		public static List<InventorySlotsDataNetwork> _Read_System_002ECollections_002EGeneric_002EList_00601_003CInventorySlotsDataNetwork_003E(NetworkReader reader)
		{
			return reader.ReadList<InventorySlotsDataNetwork>();
		}

		public static InventorySlotsDataNetwork _Read_InventorySlotsDataNetwork(NetworkReader reader)
		{
			return new InventorySlotsDataNetwork
			{
				itemName = reader.ReadString(),
				slotID = reader.ReadInt(),
				itemCountInSlot = reader.ReadInt(),
				maxCapacity = reader.ReadInt(),
				currentMagazineCount = reader.ReadInt(),
				currentDurability = reader.ReadFloat()
			};
		}

		public static void _Write_GameMode(NetworkWriter writer, GameMode value)
		{
			writer.WriteInt((int)value);
		}

		public static GameMode _Read_GameMode(NetworkReader reader)
		{
			return (GameMode)reader.ReadInt();
		}

		public static FuelSlotData _Read_FuelSlotData(NetworkReader reader)
		{
			if (!reader.ReadBool())
			{
				return null;
			}
			FuelSlotData fuelSlotData = new FuelSlotData();
			fuelSlotData.fuelItemName = reader.ReadString();
			fuelSlotData.isActive = reader.ReadBool();
			fuelSlotData.burningTimeRemaining = reader.ReadFloat();
			return fuelSlotData;
		}

		public static void _Write_FuelSlotData(NetworkWriter writer, FuelSlotData value)
		{
			if (value == null)
			{
				writer.WriteBool(value: false);
				return;
			}
			writer.WriteBool(value: true);
			writer.WriteString(value.fuelItemName);
			writer.WriteBool(value.isActive);
			writer.WriteFloat(value.burningTimeRemaining);
		}

		public static CookingSlotData _Read_CookingSlotData(NetworkReader reader)
		{
			if (!reader.ReadBool())
			{
				return null;
			}
			CookingSlotData cookingSlotData = new CookingSlotData();
			cookingSlotData.itemName = reader.ReadString();
			cookingSlotData.isPlaced = reader.ReadBool();
			cookingSlotData.cookingProgress = reader.ReadFloat();
			cookingSlotData.isCooked = reader.ReadBool();
			return cookingSlotData;
		}

		public static void _Write_CookingSlotData(NetworkWriter writer, CookingSlotData value)
		{
			if (value == null)
			{
				writer.WriteBool(value: false);
				return;
			}
			writer.WriteBool(value: true);
			writer.WriteString(value.itemName);
			writer.WriteBool(value.isPlaced);
			writer.WriteFloat(value.cookingProgress);
			writer.WriteBool(value.isCooked);
		}

		public static PlantData _Read_PlantData(NetworkReader reader)
		{
			if (!reader.ReadBool())
			{
				return null;
			}
			PlantData plantData = new PlantData();
			plantData.plantName = reader.ReadString();
			plantData.isPlanted = reader.ReadBool();
			plantData.itHasWater = reader.ReadBool();
			plantData.growingStatus = reader.ReadFloat();
			plantData.waterTimer = reader.ReadFloat();
			plantData.currentGrowLevel = reader.ReadInt();
			return plantData;
		}

		public static void _Write_PlantData(NetworkWriter writer, PlantData value)
		{
			if (value == null)
			{
				writer.WriteBool(value: false);
				return;
			}
			writer.WriteBool(value: true);
			writer.WriteString(value.plantName);
			writer.WriteBool(value.isPlanted);
			writer.WriteBool(value.itHasWater);
			writer.WriteFloat(value.growingStatus);
			writer.WriteFloat(value.waterTimer);
			writer.WriteInt(value.currentGrowLevel);
		}

		public static void _Write_InventorySlotsDataNetwork_005B_005D(NetworkWriter writer, InventorySlotsDataNetwork[] value)
		{
			writer.WriteArray(value);
		}

		public static InventorySlotsDataNetwork[] _Read_InventorySlotsDataNetwork_005B_005D(NetworkReader reader)
		{
			return reader.ReadArray<InventorySlotsDataNetwork>();
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		public static void InitReadWriters()
		{
			Writer<byte>.write = NetworkWriterExtensions.WriteByte;
			Writer<byte?>.write = NetworkWriterExtensions.WriteByteNullable;
			Writer<sbyte>.write = NetworkWriterExtensions.WriteSByte;
			Writer<sbyte?>.write = NetworkWriterExtensions.WriteSByteNullable;
			Writer<char>.write = NetworkWriterExtensions.WriteChar;
			Writer<char?>.write = NetworkWriterExtensions.WriteCharNullable;
			Writer<bool>.write = NetworkWriterExtensions.WriteBool;
			Writer<bool?>.write = NetworkWriterExtensions.WriteBoolNullable;
			Writer<short>.write = NetworkWriterExtensions.WriteShort;
			Writer<short?>.write = NetworkWriterExtensions.WriteShortNullable;
			Writer<ushort>.write = NetworkWriterExtensions.WriteUShort;
			Writer<ushort?>.write = NetworkWriterExtensions.WriteUShortNullable;
			Writer<int>.write = NetworkWriterExtensions.WriteInt;
			Writer<int?>.write = NetworkWriterExtensions.WriteIntNullable;
			Writer<uint>.write = NetworkWriterExtensions.WriteUInt;
			Writer<uint?>.write = NetworkWriterExtensions.WriteUIntNullable;
			Writer<long>.write = NetworkWriterExtensions.WriteLong;
			Writer<long?>.write = NetworkWriterExtensions.WriteLongNullable;
			Writer<ulong>.write = NetworkWriterExtensions.WriteULong;
			Writer<ulong?>.write = NetworkWriterExtensions.WriteULongNullable;
			Writer<float>.write = NetworkWriterExtensions.WriteFloat;
			Writer<float?>.write = NetworkWriterExtensions.WriteFloatNullable;
			Writer<double>.write = NetworkWriterExtensions.WriteDouble;
			Writer<double?>.write = NetworkWriterExtensions.WriteDoubleNullable;
			Writer<decimal>.write = NetworkWriterExtensions.WriteDecimal;
			Writer<decimal?>.write = NetworkWriterExtensions.WriteDecimalNullable;
			Writer<string>.write = NetworkWriterExtensions.WriteString;
			Writer<ArraySegment<byte>>.write = NetworkWriterExtensions.WriteBytesAndSizeSegment;
			Writer<byte[]>.write = NetworkWriterExtensions.WriteBytesAndSize;
			Writer<Vector2>.write = NetworkWriterExtensions.WriteVector2;
			Writer<Vector2?>.write = NetworkWriterExtensions.WriteVector2Nullable;
			Writer<Vector3>.write = NetworkWriterExtensions.WriteVector3;
			Writer<Vector3?>.write = NetworkWriterExtensions.WriteVector3Nullable;
			Writer<Vector4>.write = NetworkWriterExtensions.WriteVector4;
			Writer<Vector4?>.write = NetworkWriterExtensions.WriteVector4Nullable;
			Writer<Vector2Int>.write = NetworkWriterExtensions.WriteVector2Int;
			Writer<Vector2Int?>.write = NetworkWriterExtensions.WriteVector2IntNullable;
			Writer<Vector3Int>.write = NetworkWriterExtensions.WriteVector3Int;
			Writer<Vector3Int?>.write = NetworkWriterExtensions.WriteVector3IntNullable;
			Writer<Color>.write = NetworkWriterExtensions.WriteColor;
			Writer<Color?>.write = NetworkWriterExtensions.WriteColorNullable;
			Writer<Color32>.write = NetworkWriterExtensions.WriteColor32;
			Writer<Color32?>.write = NetworkWriterExtensions.WriteColor32Nullable;
			Writer<Quaternion>.write = NetworkWriterExtensions.WriteQuaternion;
			Writer<Quaternion?>.write = NetworkWriterExtensions.WriteQuaternionNullable;
			Writer<Rect>.write = NetworkWriterExtensions.WriteRect;
			Writer<Rect?>.write = NetworkWriterExtensions.WriteRectNullable;
			Writer<Plane>.write = NetworkWriterExtensions.WritePlane;
			Writer<Plane?>.write = NetworkWriterExtensions.WritePlaneNullable;
			Writer<Ray>.write = NetworkWriterExtensions.WriteRay;
			Writer<Ray?>.write = NetworkWriterExtensions.WriteRayNullable;
			Writer<Matrix4x4>.write = NetworkWriterExtensions.WriteMatrix4x4;
			Writer<Matrix4x4?>.write = NetworkWriterExtensions.WriteMatrix4x4Nullable;
			Writer<Guid>.write = NetworkWriterExtensions.WriteGuid;
			Writer<Guid?>.write = NetworkWriterExtensions.WriteGuidNullable;
			Writer<NetworkIdentity>.write = NetworkWriterExtensions.WriteNetworkIdentity;
			Writer<NetworkBehaviour>.write = NetworkWriterExtensions.WriteNetworkBehaviour;
			Writer<Transform>.write = NetworkWriterExtensions.WriteTransform;
			Writer<GameObject>.write = NetworkWriterExtensions.WriteGameObject;
			Writer<Uri>.write = NetworkWriterExtensions.WriteUri;
			Writer<Texture2D>.write = NetworkWriterExtensions.WriteTexture2D;
			Writer<Sprite>.write = NetworkWriterExtensions.WriteSprite;
			Writer<DateTime>.write = NetworkWriterExtensions.WriteDateTime;
			Writer<DateTime?>.write = NetworkWriterExtensions.WriteDateTimeNullable;
			Writer<TimeSnapshotMessage>.write = _Write_Mirror_002ETimeSnapshotMessage;
			Writer<ReadyMessage>.write = _Write_Mirror_002EReadyMessage;
			Writer<NotReadyMessage>.write = _Write_Mirror_002ENotReadyMessage;
			Writer<AddPlayerMessage>.write = _Write_Mirror_002EAddPlayerMessage;
			Writer<SceneMessage>.write = _Write_Mirror_002ESceneMessage;
			Writer<SceneOperation>.write = _Write_Mirror_002ESceneOperation;
			Writer<CommandMessage>.write = _Write_Mirror_002ECommandMessage;
			Writer<RpcMessage>.write = _Write_Mirror_002ERpcMessage;
			Writer<SpawnMessage>.write = _Write_Mirror_002ESpawnMessage;
			Writer<ChangeOwnerMessage>.write = _Write_Mirror_002EChangeOwnerMessage;
			Writer<ObjectSpawnStartedMessage>.write = _Write_Mirror_002EObjectSpawnStartedMessage;
			Writer<ObjectSpawnFinishedMessage>.write = _Write_Mirror_002EObjectSpawnFinishedMessage;
			Writer<ObjectDestroyMessage>.write = _Write_Mirror_002EObjectDestroyMessage;
			Writer<ObjectHideMessage>.write = _Write_Mirror_002EObjectHideMessage;
			Writer<EntityStateMessage>.write = _Write_Mirror_002EEntityStateMessage;
			Writer<NetworkPingMessage>.write = _Write_Mirror_002ENetworkPingMessage;
			Writer<NetworkPongMessage>.write = _Write_Mirror_002ENetworkPongMessage;
			Writer<DissonanceNetworkMessage>.write = DissonanceNetworkMessageExtensions.Serialize;
			Writer<Vector3[]>.write = _Write_UnityEngine_002EVector3_005B_005D;
			Writer<GameAudios>.write = _Write_GameAudios;
			Writer<ObjectServerData>.write = _Write_ObjectServerData;
			Writer<NetworkBuildData>.write = _Write_NetworkBuildData;
			Writer<ChunkObjectData>.write = _Write_ChunkObjectData;
			Writer<PlayerInventorySync>.write = _Write_PlayerInventorySync;
			Writer<List<InventorySaveData>>.write = _Write_System_002ECollections_002EGeneric_002EList_00601_003CInventorySaveData_003E;
			Writer<InventorySaveData>.write = _Write_InventorySaveData;
			Writer<PlayerStatusSync>.write = _Write_PlayerStatusSync;
			Writer<PlayerStatusSaveData>.write = _Write_PlayerStatusSaveData;
			Writer<PlayerTutorialSync>.write = _Write_PlayerTutorialSync;
			Writer<PlayerTutorialSaveData>.write = _Write_PlayerTutorialSaveData;
			Writer<List<TutorialTaskEntry>>.write = _Write_System_002ECollections_002EGeneric_002EList_00601_003CTutorialTaskEntry_003E;
			Writer<TutorialTaskEntry>.write = _Write_TutorialTaskEntry;
			Writer<DroppedItemData>.write = _Write_DroppedItemData;
			Writer<CollectableItemSync>.write = _Write_CollectableItemSync;
			Writer<CategoryUnlockSync>.write = _Write_CategoryUnlockSync;
			Writer<List<InventorySlotsDataNetwork>>.write = _Write_System_002ECollections_002EGeneric_002EList_00601_003CInventorySlotsDataNetwork_003E;
			Writer<InventorySlotsDataNetwork>.write = _Write_InventorySlotsDataNetwork;
			Writer<GameMode>.write = _Write_GameMode;
			Writer<FuelSlotData>.write = _Write_FuelSlotData;
			Writer<CookingSlotData>.write = _Write_CookingSlotData;
			Writer<PlantData>.write = _Write_PlantData;
			Writer<InventorySlotsDataNetwork[]>.write = _Write_InventorySlotsDataNetwork_005B_005D;
			Reader<byte>.read = NetworkReaderExtensions.ReadByte;
			Reader<byte?>.read = NetworkReaderExtensions.ReadByteNullable;
			Reader<sbyte>.read = NetworkReaderExtensions.ReadSByte;
			Reader<sbyte?>.read = NetworkReaderExtensions.ReadSByteNullable;
			Reader<char>.read = NetworkReaderExtensions.ReadChar;
			Reader<char?>.read = NetworkReaderExtensions.ReadCharNullable;
			Reader<bool>.read = NetworkReaderExtensions.ReadBool;
			Reader<bool?>.read = NetworkReaderExtensions.ReadBoolNullable;
			Reader<short>.read = NetworkReaderExtensions.ReadShort;
			Reader<short?>.read = NetworkReaderExtensions.ReadShortNullable;
			Reader<ushort>.read = NetworkReaderExtensions.ReadUShort;
			Reader<ushort?>.read = NetworkReaderExtensions.ReadUShortNullable;
			Reader<int>.read = NetworkReaderExtensions.ReadInt;
			Reader<int?>.read = NetworkReaderExtensions.ReadIntNullable;
			Reader<uint>.read = NetworkReaderExtensions.ReadUInt;
			Reader<uint?>.read = NetworkReaderExtensions.ReadUIntNullable;
			Reader<long>.read = NetworkReaderExtensions.ReadLong;
			Reader<long?>.read = NetworkReaderExtensions.ReadLongNullable;
			Reader<ulong>.read = NetworkReaderExtensions.ReadULong;
			Reader<ulong?>.read = NetworkReaderExtensions.ReadULongNullable;
			Reader<float>.read = NetworkReaderExtensions.ReadFloat;
			Reader<float?>.read = NetworkReaderExtensions.ReadFloatNullable;
			Reader<double>.read = NetworkReaderExtensions.ReadDouble;
			Reader<double?>.read = NetworkReaderExtensions.ReadDoubleNullable;
			Reader<decimal>.read = NetworkReaderExtensions.ReadDecimal;
			Reader<decimal?>.read = NetworkReaderExtensions.ReadDecimalNullable;
			Reader<string>.read = NetworkReaderExtensions.ReadString;
			Reader<byte[]>.read = NetworkReaderExtensions.ReadBytesAndSize;
			Reader<ArraySegment<byte>>.read = NetworkReaderExtensions.ReadBytesAndSizeSegment;
			Reader<Vector2>.read = NetworkReaderExtensions.ReadVector2;
			Reader<Vector2?>.read = NetworkReaderExtensions.ReadVector2Nullable;
			Reader<Vector3>.read = NetworkReaderExtensions.ReadVector3;
			Reader<Vector3?>.read = NetworkReaderExtensions.ReadVector3Nullable;
			Reader<Vector4>.read = NetworkReaderExtensions.ReadVector4;
			Reader<Vector4?>.read = NetworkReaderExtensions.ReadVector4Nullable;
			Reader<Vector2Int>.read = NetworkReaderExtensions.ReadVector2Int;
			Reader<Vector2Int?>.read = NetworkReaderExtensions.ReadVector2IntNullable;
			Reader<Vector3Int>.read = NetworkReaderExtensions.ReadVector3Int;
			Reader<Vector3Int?>.read = NetworkReaderExtensions.ReadVector3IntNullable;
			Reader<Color>.read = NetworkReaderExtensions.ReadColor;
			Reader<Color?>.read = NetworkReaderExtensions.ReadColorNullable;
			Reader<Color32>.read = NetworkReaderExtensions.ReadColor32;
			Reader<Color32?>.read = NetworkReaderExtensions.ReadColor32Nullable;
			Reader<Quaternion>.read = NetworkReaderExtensions.ReadQuaternion;
			Reader<Quaternion?>.read = NetworkReaderExtensions.ReadQuaternionNullable;
			Reader<Rect>.read = NetworkReaderExtensions.ReadRect;
			Reader<Rect?>.read = NetworkReaderExtensions.ReadRectNullable;
			Reader<Plane>.read = NetworkReaderExtensions.ReadPlane;
			Reader<Plane?>.read = NetworkReaderExtensions.ReadPlaneNullable;
			Reader<Ray>.read = NetworkReaderExtensions.ReadRay;
			Reader<Ray?>.read = NetworkReaderExtensions.ReadRayNullable;
			Reader<Matrix4x4>.read = NetworkReaderExtensions.ReadMatrix4x4;
			Reader<Matrix4x4?>.read = NetworkReaderExtensions.ReadMatrix4x4Nullable;
			Reader<Guid>.read = NetworkReaderExtensions.ReadGuid;
			Reader<Guid?>.read = NetworkReaderExtensions.ReadGuidNullable;
			Reader<NetworkIdentity>.read = NetworkReaderExtensions.ReadNetworkIdentity;
			Reader<NetworkBehaviour>.read = NetworkReaderExtensions.ReadNetworkBehaviour;
			Reader<NetworkBehaviourSyncVar>.read = NetworkReaderExtensions.ReadNetworkBehaviourSyncVar;
			Reader<Transform>.read = NetworkReaderExtensions.ReadTransform;
			Reader<GameObject>.read = NetworkReaderExtensions.ReadGameObject;
			Reader<Uri>.read = NetworkReaderExtensions.ReadUri;
			Reader<Texture2D>.read = NetworkReaderExtensions.ReadTexture2D;
			Reader<Sprite>.read = NetworkReaderExtensions.ReadSprite;
			Reader<DateTime>.read = NetworkReaderExtensions.ReadDateTime;
			Reader<DateTime?>.read = NetworkReaderExtensions.ReadDateTimeNullable;
			Reader<TimeSnapshotMessage>.read = _Read_Mirror_002ETimeSnapshotMessage;
			Reader<ReadyMessage>.read = _Read_Mirror_002EReadyMessage;
			Reader<NotReadyMessage>.read = _Read_Mirror_002ENotReadyMessage;
			Reader<AddPlayerMessage>.read = _Read_Mirror_002EAddPlayerMessage;
			Reader<SceneMessage>.read = _Read_Mirror_002ESceneMessage;
			Reader<SceneOperation>.read = _Read_Mirror_002ESceneOperation;
			Reader<CommandMessage>.read = _Read_Mirror_002ECommandMessage;
			Reader<RpcMessage>.read = _Read_Mirror_002ERpcMessage;
			Reader<SpawnMessage>.read = _Read_Mirror_002ESpawnMessage;
			Reader<ChangeOwnerMessage>.read = _Read_Mirror_002EChangeOwnerMessage;
			Reader<ObjectSpawnStartedMessage>.read = _Read_Mirror_002EObjectSpawnStartedMessage;
			Reader<ObjectSpawnFinishedMessage>.read = _Read_Mirror_002EObjectSpawnFinishedMessage;
			Reader<ObjectDestroyMessage>.read = _Read_Mirror_002EObjectDestroyMessage;
			Reader<ObjectHideMessage>.read = _Read_Mirror_002EObjectHideMessage;
			Reader<EntityStateMessage>.read = _Read_Mirror_002EEntityStateMessage;
			Reader<NetworkPingMessage>.read = _Read_Mirror_002ENetworkPingMessage;
			Reader<NetworkPongMessage>.read = _Read_Mirror_002ENetworkPongMessage;
			Reader<DissonanceNetworkMessage>.read = DissonanceNetworkMessageExtensions.Deserialize;
			Reader<Vector3[]>.read = _Read_UnityEngine_002EVector3_005B_005D;
			Reader<GameAudios>.read = _Read_GameAudios;
			Reader<ObjectServerData>.read = _Read_ObjectServerData;
			Reader<NetworkBuildData>.read = _Read_NetworkBuildData;
			Reader<ChunkObjectData>.read = _Read_ChunkObjectData;
			Reader<PlayerInventorySync>.read = _Read_PlayerInventorySync;
			Reader<List<InventorySaveData>>.read = _Read_System_002ECollections_002EGeneric_002EList_00601_003CInventorySaveData_003E;
			Reader<InventorySaveData>.read = _Read_InventorySaveData;
			Reader<PlayerStatusSync>.read = _Read_PlayerStatusSync;
			Reader<PlayerStatusSaveData>.read = _Read_PlayerStatusSaveData;
			Reader<PlayerTutorialSync>.read = _Read_PlayerTutorialSync;
			Reader<PlayerTutorialSaveData>.read = _Read_PlayerTutorialSaveData;
			Reader<List<TutorialTaskEntry>>.read = _Read_System_002ECollections_002EGeneric_002EList_00601_003CTutorialTaskEntry_003E;
			Reader<TutorialTaskEntry>.read = _Read_TutorialTaskEntry;
			Reader<DroppedItemData>.read = _Read_DroppedItemData;
			Reader<CollectableItemSync>.read = _Read_CollectableItemSync;
			Reader<CategoryUnlockSync>.read = _Read_CategoryUnlockSync;
			Reader<List<InventorySlotsDataNetwork>>.read = _Read_System_002ECollections_002EGeneric_002EList_00601_003CInventorySlotsDataNetwork_003E;
			Reader<InventorySlotsDataNetwork>.read = _Read_InventorySlotsDataNetwork;
			Reader<GameMode>.read = _Read_GameMode;
			Reader<FuelSlotData>.read = _Read_FuelSlotData;
			Reader<CookingSlotData>.read = _Read_CookingSlotData;
			Reader<PlantData>.read = _Read_PlantData;
			Reader<InventorySlotsDataNetwork[]>.read = _Read_InventorySlotsDataNetwork_005B_005D;
		}
	}
}
