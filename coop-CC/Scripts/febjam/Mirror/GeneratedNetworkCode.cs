using System;
using System.Runtime.InteropServices;
using Aggro.Core;
using Aggro.Core.Networking;
using Dissonance.Integrations.MirrorIgnorance;
using FMODUnity;
using Mirror.Discovery;
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
				netId = reader.ReadVarUInt(),
				componentIndex = NetworkReaderExtensions.ReadByte(reader),
				functionHash = reader.ReadUShort(),
				payload = reader.ReadArraySegmentAndSize()
			};
		}

		public static void _Write_Mirror_002ECommandMessage(NetworkWriter writer, CommandMessage value)
		{
			writer.WriteVarUInt(value.netId);
			NetworkWriterExtensions.WriteByte(writer, value.componentIndex);
			writer.WriteUShort(value.functionHash);
			writer.WriteArraySegmentAndSize(value.payload);
		}

		public static RpcMessage _Read_Mirror_002ERpcMessage(NetworkReader reader)
		{
			return new RpcMessage
			{
				netId = reader.ReadVarUInt(),
				componentIndex = NetworkReaderExtensions.ReadByte(reader),
				functionHash = reader.ReadUShort(),
				payload = reader.ReadArraySegmentAndSize()
			};
		}

		public static void _Write_Mirror_002ERpcMessage(NetworkWriter writer, RpcMessage value)
		{
			writer.WriteVarUInt(value.netId);
			NetworkWriterExtensions.WriteByte(writer, value.componentIndex);
			writer.WriteUShort(value.functionHash);
			writer.WriteArraySegmentAndSize(value.payload);
		}

		public static SpawnMessage _Read_Mirror_002ESpawnMessage(NetworkReader reader)
		{
			return new SpawnMessage
			{
				netId = reader.ReadVarUInt(),
				spawnFlags = _Read_Mirror_002ESpawnFlags(reader),
				sceneId = reader.ReadVarULong(),
				assetId = reader.ReadVarUInt(),
				position = reader.ReadVector3(),
				rotation = reader.ReadQuaternion(),
				scale = reader.ReadVector3(),
				payload = reader.ReadArraySegmentAndSize()
			};
		}

		public static SpawnFlags _Read_Mirror_002ESpawnFlags(NetworkReader reader)
		{
			return (SpawnFlags)NetworkReaderExtensions.ReadByte(reader);
		}

		public static void _Write_Mirror_002ESpawnMessage(NetworkWriter writer, SpawnMessage value)
		{
			writer.WriteVarUInt(value.netId);
			_Write_Mirror_002ESpawnFlags(writer, value.spawnFlags);
			writer.WriteVarULong(value.sceneId);
			writer.WriteVarUInt(value.assetId);
			writer.WriteVector3(value.position);
			writer.WriteQuaternion(value.rotation);
			writer.WriteVector3(value.scale);
			writer.WriteArraySegmentAndSize(value.payload);
		}

		public static void _Write_Mirror_002ESpawnFlags(NetworkWriter writer, SpawnFlags value)
		{
			NetworkWriterExtensions.WriteByte(writer, (byte)value);
		}

		public static ChangeOwnerMessage _Read_Mirror_002EChangeOwnerMessage(NetworkReader reader)
		{
			return new ChangeOwnerMessage
			{
				netId = reader.ReadVarUInt(),
				spawnFlags = _Read_Mirror_002ESpawnFlags(reader)
			};
		}

		public static void _Write_Mirror_002EChangeOwnerMessage(NetworkWriter writer, ChangeOwnerMessage value)
		{
			writer.WriteVarUInt(value.netId);
			_Write_Mirror_002ESpawnFlags(writer, value.spawnFlags);
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
				netId = reader.ReadVarUInt()
			};
		}

		public static void _Write_Mirror_002EObjectDestroyMessage(NetworkWriter writer, ObjectDestroyMessage value)
		{
			writer.WriteVarUInt(value.netId);
		}

		public static ObjectHideMessage _Read_Mirror_002EObjectHideMessage(NetworkReader reader)
		{
			return new ObjectHideMessage
			{
				netId = reader.ReadVarUInt()
			};
		}

		public static void _Write_Mirror_002EObjectHideMessage(NetworkWriter writer, ObjectHideMessage value)
		{
			writer.WriteVarUInt(value.netId);
		}

		public static EntityStateMessage _Read_Mirror_002EEntityStateMessage(NetworkReader reader)
		{
			return new EntityStateMessage
			{
				netId = reader.ReadVarUInt(),
				payload = reader.ReadArraySegmentAndSize()
			};
		}

		public static void _Write_Mirror_002EEntityStateMessage(NetworkWriter writer, EntityStateMessage value)
		{
			writer.WriteVarUInt(value.netId);
			writer.WriteArraySegmentAndSize(value.payload);
		}

		public static NetworkPingMessage _Read_Mirror_002ENetworkPingMessage(NetworkReader reader)
		{
			return new NetworkPingMessage
			{
				localTime = reader.ReadDouble(),
				predictedTimeAdjusted = reader.ReadDouble()
			};
		}

		public static void _Write_Mirror_002ENetworkPingMessage(NetworkWriter writer, NetworkPingMessage value)
		{
			writer.WriteDouble(value.localTime);
			writer.WriteDouble(value.predictedTimeAdjusted);
		}

		public static NetworkPongMessage _Read_Mirror_002ENetworkPongMessage(NetworkReader reader)
		{
			return new NetworkPongMessage
			{
				localTime = reader.ReadDouble(),
				predictionErrorUnadjusted = reader.ReadDouble(),
				predictionErrorAdjusted = reader.ReadDouble()
			};
		}

		public static void _Write_Mirror_002ENetworkPongMessage(NetworkWriter writer, NetworkPongMessage value)
		{
			writer.WriteDouble(value.localTime);
			writer.WriteDouble(value.predictionErrorUnadjusted);
			writer.WriteDouble(value.predictionErrorAdjusted);
		}

		public static ServerRequest _Read_Mirror_002EDiscovery_002EServerRequest(NetworkReader reader)
		{
			return default(ServerRequest);
		}

		public static void _Write_Mirror_002EDiscovery_002EServerRequest(NetworkWriter writer, ServerRequest value)
		{
		}

		public static ServerResponse _Read_Mirror_002EDiscovery_002EServerResponse(NetworkReader reader)
		{
			return new ServerResponse
			{
				uri = reader.ReadUri(),
				serverId = reader.ReadVarLong()
			};
		}

		public static void _Write_Mirror_002EDiscovery_002EServerResponse(NetworkWriter writer, ServerResponse value)
		{
			writer.WriteUri(value.uri);
			writer.WriteVarLong(value.serverId);
		}

		public static NetMsgGameManagerLoad _Read_NetMsgGameManagerLoad(NetworkReader reader)
		{
			return new NetMsgGameManagerLoad
			{
				isRun = reader.ReadBool(),
				sceneName = reader.ReadString(),
				seed = reader.ReadVarInt(),
				contractIndex = reader.ReadSByte()
			};
		}

		public static void _Write_NetMsgGameManagerLoad(NetworkWriter writer, NetMsgGameManagerLoad value)
		{
			writer.WriteBool(value.isRun);
			writer.WriteString(value.sceneName);
			writer.WriteVarInt(value.seed);
			writer.WriteSByte(value.contractIndex);
		}

		public static NetMsgGameManagerReady _Read_NetMsgGameManagerReady(NetworkReader reader)
		{
			return default(NetMsgGameManagerReady);
		}

		public static void _Write_NetMsgGameManagerReady(NetworkWriter writer, NetMsgGameManagerReady value)
		{
		}

		public static NetMsgTeleported _Read_NetMsgTeleported(NetworkReader reader)
		{
			return new NetMsgTeleported
			{
				roomType = _Read_RoomType(reader)
			};
		}

		public static RoomType _Read_RoomType(NetworkReader reader)
		{
			return (RoomType)reader.ReadVarInt();
		}

		public static void _Write_NetMsgTeleported(NetworkWriter writer, NetMsgTeleported value)
		{
			_Write_RoomType(writer, value.roomType);
		}

		public static void _Write_RoomType(NetworkWriter writer, RoomType value)
		{
			writer.WriteVarInt((int)value);
		}

		public static NetMsgGameSettings _Read_NetMsgGameSettings(NetworkReader reader)
		{
			return new NetMsgGameSettings
			{
				versionGuid = reader.ReadGuid()
			};
		}

		public static void _Write_NetMsgGameSettings(NetworkWriter writer, NetMsgGameSettings value)
		{
			writer.WriteGuid(value.versionGuid);
		}

		public static NetMsgServerPlayerJoined _Read_NetMsgServerPlayerJoined(NetworkReader reader)
		{
			return new NetMsgServerPlayerJoined
			{
				playerName = reader.ReadString()
			};
		}

		public static void _Write_NetMsgServerPlayerJoined(NetworkWriter writer, NetMsgServerPlayerJoined value)
		{
			writer.WriteString(value.playerName);
		}

		public static NetMsgPlayerJoined _Read_NetMsgPlayerJoined(NetworkReader reader)
		{
			return new NetMsgPlayerJoined
			{
				playerName = reader.ReadString()
			};
		}

		public static void _Write_NetMsgPlayerJoined(NetworkWriter writer, NetMsgPlayerJoined value)
		{
			writer.WriteString(value.playerName);
		}

		public static NetMsgPlayerLeft _Read_NetMsgPlayerLeft(NetworkReader reader)
		{
			return new NetMsgPlayerLeft
			{
				playerName = reader.ReadString()
			};
		}

		public static void _Write_NetMsgPlayerLeft(NetworkWriter writer, NetMsgPlayerLeft value)
		{
			writer.WriteString(value.playerName);
		}

		public static void _Write_BoxCharge_002FChargeState(NetworkWriter writer, BoxCharge.ChargeState value)
		{
			NetworkWriterExtensions.WriteByte(writer, (byte)value);
		}

		public static BoxCharge.ChargeState _Read_BoxCharge_002FChargeState(NetworkReader reader)
		{
			return (BoxCharge.ChargeState)NetworkReaderExtensions.ReadByte(reader);
		}

		public static void _Write_BoxHaunted_002FHaunting(NetworkWriter writer, BoxHaunted.Haunting value)
		{
			writer.WriteVarInt(value.seed);
			writer.WriteFloat(value.startTime);
		}

		public static BoxHaunted.Haunting _Read_BoxHaunted_002FHaunting(NetworkReader reader)
		{
			return new BoxHaunted.Haunting
			{
				seed = reader.ReadVarInt(),
				startTime = reader.ReadFloat()
			};
		}

		public static void _Write_ActivatedFirework_002FState(NetworkWriter writer, ActivatedFirework.State value)
		{
			NetworkWriterExtensions.WriteByte(writer, (byte)value);
		}

		public static ActivatedFirework.State _Read_ActivatedFirework_002FState(NetworkReader reader)
		{
			return (ActivatedFirework.State)NetworkReaderExtensions.ReadByte(reader);
		}

		public static void _Write_ActivationContext(NetworkWriter writer, ActivationContext value)
		{
			_Write_ActivationContextType(writer, value.type);
			writer.WriteEntity(value.causer);
			_Write_ActivationContextSubType(writer, value.subType);
		}

		public static void _Write_ActivationContextType(NetworkWriter writer, ActivationContextType value)
		{
			NetworkWriterExtensions.WriteByte(writer, (byte)value);
		}

		public static void _Write_ActivationContextSubType(NetworkWriter writer, ActivationContextSubType value)
		{
			NetworkWriterExtensions.WriteByte(writer, (byte)value);
		}

		public static ActivationContext _Read_ActivationContext(NetworkReader reader)
		{
			return new ActivationContext
			{
				type = _Read_ActivationContextType(reader),
				causer = reader.ReadEntity(),
				subType = _Read_ActivationContextSubType(reader)
			};
		}

		public static ActivationContextType _Read_ActivationContextType(NetworkReader reader)
		{
			return (ActivationContextType)NetworkReaderExtensions.ReadByte(reader);
		}

		public static ActivationContextSubType _Read_ActivationContextSubType(NetworkReader reader)
		{
			return (ActivationContextSubType)NetworkReaderExtensions.ReadByte(reader);
		}

		public static void _Write_DamageType(NetworkWriter writer, DamageType value)
		{
			NetworkWriterExtensions.WriteByte(writer, (byte)value);
		}

		public static DamageType _Read_DamageType(NetworkReader reader)
		{
			return (DamageType)NetworkReaderExtensions.ReadByte(reader);
		}

		public static void _Write_DamageMask(NetworkWriter writer, DamageMask value)
		{
			NetworkWriterExtensions.WriteByte(writer, (byte)value);
		}

		public static DamageMask _Read_DamageMask(NetworkReader reader)
		{
			return (DamageMask)NetworkReaderExtensions.ReadByte(reader);
		}

		public static void _Write_Exploder_002FExplodeState(NetworkWriter writer, Exploder.ExplodeState value)
		{
			NetworkWriterExtensions.WriteByte(writer, (byte)value);
		}

		public static Exploder.ExplodeState _Read_Exploder_002FExplodeState(NetworkReader reader)
		{
			return (Exploder.ExplodeState)NetworkReaderExtensions.ReadByte(reader);
		}

		public static void _Write_FireState(NetworkWriter writer, FireState value)
		{
			NetworkWriterExtensions.WriteByte(writer, (byte)value);
		}

		public static FireState _Read_FireState(NetworkReader reader)
		{
			return (FireState)NetworkReaderExtensions.ReadByte(reader);
		}

		public static void _Write_LobbyPlayerClient_002FInfo(NetworkWriter writer, LobbyPlayerClient.Info value)
		{
			writer.WriteVarInt(value.contractIndex);
			writer.WriteVarInt(value.score);
		}

		public static LobbyPlayerClient.Info _Read_LobbyPlayerClient_002FInfo(NetworkReader reader)
		{
			return new LobbyPlayerClient.Info
			{
				contractIndex = reader.ReadVarInt(),
				score = reader.ReadVarInt()
			};
		}

		public static PlayersManager.VoteOption _Read_PlayersManager_002FVoteOption(NetworkReader reader)
		{
			return (PlayersManager.VoteOption)NetworkReaderExtensions.ReadByte(reader);
		}

		public static void _Write_PlayersManager_002FVoteOption(NetworkWriter writer, PlayersManager.VoteOption value)
		{
			NetworkWriterExtensions.WriteByte(writer, (byte)value);
		}

		public static ShiftManager.OrderCountNet _Read_ShiftManager_002FOrderCountNet(NetworkReader reader)
		{
			return new ShiftManager.OrderCountNet
			{
				assetId = reader.ReadVarUInt(),
				count = NetworkReaderExtensions.ReadByte(reader)
			};
		}

		public static void _Write_ShiftManager_002FOrderCountNet(NetworkWriter writer, ShiftManager.OrderCountNet value)
		{
			writer.WriteVarUInt(value.assetId);
			NetworkWriterExtensions.WriteByte(writer, value.count);
		}

		public static void _Write_ShiftPhase(NetworkWriter writer, ShiftPhase value)
		{
			NetworkWriterExtensions.WriteByte(writer, (byte)value);
		}

		public static ShiftPhase _Read_ShiftPhase(NetworkReader reader)
		{
			return (ShiftPhase)NetworkReaderExtensions.ReadByte(reader);
		}

		public static void _Write_ContractScore(NetworkWriter writer, ContractScore value)
		{
			NetworkWriterExtensions.WriteByte(writer, (byte)value);
		}

		public static ContractScore _Read_ContractScore(NetworkReader reader)
		{
			return (ContractScore)NetworkReaderExtensions.ReadByte(reader);
		}

		public static void _Write_PlayerResult_005B_005D(NetworkWriter writer, PlayerResult[] value)
		{
			writer.WriteArray(value);
		}

		public static void _Write_PlayerResult(NetworkWriter writer, PlayerResult value)
		{
			writer.WriteColor(value.color);
			writer.WriteShort(value.crashOuts);
			writer.WriteShort(value.nitroCount);
			writer.WriteVarInt(value.driftDistanceCount);
			NetworkWriterExtensions.WriteByte(writer, value.upgradeCount);
			writer.WriteString(value.name);
		}

		public static PlayerResult[] _Read_PlayerResult_005B_005D(NetworkReader reader)
		{
			return reader.ReadArray<PlayerResult>();
		}

		public static PlayerResult _Read_PlayerResult(NetworkReader reader)
		{
			return new PlayerResult
			{
				color = reader.ReadColor(),
				crashOuts = reader.ReadShort(),
				nitroCount = reader.ReadShort(),
				driftDistanceCount = reader.ReadVarInt(),
				upgradeCount = NetworkReaderExtensions.ReadByte(reader),
				name = reader.ReadString()
			};
		}

		public static void _Write_Cactus_002FState(NetworkWriter writer, Cactus.State value)
		{
			NetworkWriterExtensions.WriteByte(writer, (byte)value);
		}

		public static Cactus.State _Read_Cactus_002FState(NetworkReader reader)
		{
			return (Cactus.State)NetworkReaderExtensions.ReadByte(reader);
		}

		public static void _Write_ModifierLava_002FState(NetworkWriter writer, ModifierLava.State value)
		{
			NetworkWriterExtensions.WriteByte(writer, (byte)value);
		}

		public static ModifierLava.State _Read_ModifierLava_002FState(NetworkReader reader)
		{
			return (ModifierLava.State)NetworkReaderExtensions.ReadByte(reader);
		}

		public static void _Write_ModifierArtStyle(NetworkWriter writer, ModifierArtStyle value)
		{
			NetworkWriterExtensions.WriteByte(writer, (byte)value);
		}

		public static ModifierArtStyle _Read_ModifierArtStyle(NetworkReader reader)
		{
			return (ModifierArtStyle)NetworkReaderExtensions.ReadByte(reader);
		}

		public static void _Write_ModifierRoomSpawn_002FState(NetworkWriter writer, ModifierRoomSpawn.State value)
		{
			writer.WriteVarInt((int)value);
		}

		public static ModifierRoomSpawn.State _Read_ModifierRoomSpawn_002FState(NetworkReader reader)
		{
			return (ModifierRoomSpawn.State)reader.ReadVarInt();
		}

		public static void _Write_WarehouseButtonState(NetworkWriter writer, WarehouseButtonState value)
		{
			NetworkWriterExtensions.WriteByte(writer, (byte)value);
		}

		public static WarehouseButtonState _Read_WarehouseButtonState(NetworkReader reader)
		{
			return (WarehouseButtonState)NetworkReaderExtensions.ReadByte(reader);
		}

		public static void _Write_PlayerEffectContext(NetworkWriter writer, PlayerEffectContext value)
		{
			writer.WriteVarInt((int)value);
		}

		public static PlayerEffectContext _Read_PlayerEffectContext(NetworkReader reader)
		{
			return (PlayerEffectContext)reader.ReadVarInt();
		}

		public static void _Write_PlayerUpgrade(NetworkWriter writer, PlayerUpgrade value)
		{
			NetworkWriterExtensions.WriteByte(writer, (byte)value);
		}

		public static PlayerUpgrade _Read_PlayerUpgrade(NetworkReader reader)
		{
			return (PlayerUpgrade)NetworkReaderExtensions.ReadByte(reader);
		}

		public static void _Write_SprinklerManager_002FState(NetworkWriter writer, SprinklerManager.State value)
		{
			NetworkWriterExtensions.WriteByte(writer, (byte)value);
		}

		public static SprinklerManager.State _Read_SprinklerManager_002FState(NetworkReader reader)
		{
			return (SprinklerManager.State)NetworkReaderExtensions.ReadByte(reader);
		}

		public static void _Write_StationBoxDestroyer_002FDestroyerState(NetworkWriter writer, StationBoxDestroyer.DestroyerState value)
		{
			NetworkWriterExtensions.WriteByte(writer, (byte)value);
		}

		public static StationBoxDestroyer.DestroyerState _Read_StationBoxDestroyer_002FDestroyerState(NetworkReader reader)
		{
			return (StationBoxDestroyer.DestroyerState)NetworkReaderExtensions.ReadByte(reader);
		}

		public static void _Write_StationSprinkler_002FSprinklerPreventionState(NetworkWriter writer, StationSprinkler.SprinklerPreventionState value)
		{
			NetworkWriterExtensions.WriteByte(writer, (byte)value);
		}

		public static StationSprinkler.SprinklerPreventionState _Read_StationSprinkler_002FSprinklerPreventionState(NetworkReader reader)
		{
			return (StationSprinkler.SprinklerPreventionState)NetworkReaderExtensions.ReadByte(reader);
		}

		public static void _Write_StationTeleporterManager_002FState(NetworkWriter writer, StationTeleporterManager.State value)
		{
			NetworkWriterExtensions.WriteByte(writer, (byte)value);
		}

		public static StationTeleporterManager.State _Read_StationTeleporterManager_002FState(NetworkReader reader)
		{
			return (StationTeleporterManager.State)NetworkReaderExtensions.ReadByte(reader);
		}

		public static OutboundBay.Count _Read_OutboundBay_002FCount(NetworkReader reader)
		{
			return new OutboundBay.Count
			{
				total = reader.ReadVarInt(),
				current = reader.ReadVarInt()
			};
		}

		public static void _Write_OutboundBay_002FCount(NetworkWriter writer, OutboundBay.Count value)
		{
			writer.WriteVarInt(value.total);
			writer.WriteVarInt(value.current);
		}

		public static void _Write_OutboundBay_002FBayState(NetworkWriter writer, OutboundBay.BayState value)
		{
			NetworkWriterExtensions.WriteByte(writer, (byte)value);
		}

		public static OutboundBay.BayState _Read_OutboundBay_002FBayState(NetworkReader reader)
		{
			return (OutboundBay.BayState)NetworkReaderExtensions.ReadByte(reader);
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
			Writer<int>.write = NetworkWriterExtensions.WriteVarInt;
			Writer<int?>.write = NetworkWriterExtensions.WriteIntNullable;
			Writer<uint>.write = NetworkWriterExtensions.WriteVarUInt;
			Writer<uint?>.write = NetworkWriterExtensions.WriteUIntNullable;
			Writer<long>.write = NetworkWriterExtensions.WriteVarLong;
			Writer<long?>.write = NetworkWriterExtensions.WriteLongNullable;
			Writer<ulong>.write = NetworkWriterExtensions.WriteVarULong;
			Writer<ulong?>.write = NetworkWriterExtensions.WriteULongNullable;
			Writer<float>.write = NetworkWriterExtensions.WriteFloat;
			Writer<float?>.write = NetworkWriterExtensions.WriteFloatNullable;
			Writer<double>.write = NetworkWriterExtensions.WriteDouble;
			Writer<double?>.write = NetworkWriterExtensions.WriteDoubleNullable;
			Writer<decimal>.write = NetworkWriterExtensions.WriteDecimal;
			Writer<decimal?>.write = NetworkWriterExtensions.WriteDecimalNullable;
			Writer<Half>.write = NetworkWriterExtensions.WriteHalf;
			Writer<string>.write = NetworkWriterExtensions.WriteString;
			Writer<byte[]>.write = NetworkWriterExtensions.WriteBytesAndSize;
			Writer<ArraySegment<byte>>.write = NetworkWriterExtensions.WriteArraySegmentAndSize;
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
			Writer<LayerMask>.write = NetworkWriterExtensions.WriteLayerMask;
			Writer<LayerMask?>.write = NetworkWriterExtensions.WriteLayerMaskNullable;
			Writer<Matrix4x4>.write = NetworkWriterExtensions.WriteMatrix4x4;
			Writer<Matrix4x4?>.write = NetworkWriterExtensions.WriteMatrix4x4Nullable;
			Writer<Guid>.write = NetworkWriterExtensions.WriteGuid;
			Writer<Guid?>.write = NetworkWriterExtensions.WriteGuidNullable;
			Writer<NetworkIdentity>.write = NetworkWriterExtensions.WriteNetworkIdentity;
			Writer<NetworkBehaviour>.write = NetworkWriterExtensions.WriteNetworkBehaviour;
			Writer<Transform>.write = NetworkWriterExtensions.WriteTransform;
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
			Writer<SpawnFlags>.write = _Write_Mirror_002ESpawnFlags;
			Writer<ChangeOwnerMessage>.write = _Write_Mirror_002EChangeOwnerMessage;
			Writer<ObjectSpawnStartedMessage>.write = _Write_Mirror_002EObjectSpawnStartedMessage;
			Writer<ObjectSpawnFinishedMessage>.write = _Write_Mirror_002EObjectSpawnFinishedMessage;
			Writer<ObjectDestroyMessage>.write = _Write_Mirror_002EObjectDestroyMessage;
			Writer<ObjectHideMessage>.write = _Write_Mirror_002EObjectHideMessage;
			Writer<EntityStateMessage>.write = _Write_Mirror_002EEntityStateMessage;
			Writer<NetworkPingMessage>.write = _Write_Mirror_002ENetworkPingMessage;
			Writer<NetworkPongMessage>.write = _Write_Mirror_002ENetworkPongMessage;
			Writer<Entity>.write = Aggro.Core.Networking.NetworkSerialization.WriteEntity;
			Writer<NetScrobId>.write = Aggro.Core.Networking.NetworkSerialization.WriteNetworkScrob;
			Writer<NetBehaviourId>.write = Aggro.Core.Networking.NetworkSerialization.WriteNetworkBehaviour;
			Writer<GameObject>.write = Aggro.Core.Networking.NetworkSerialization.WriteGameObject;
			Writer<ValueTypeList4<Vector3>>.write = Aggro.Core.Networking.NetworkSerialization.WriteVector3ValueTypeList4;
			Writer<ValueTypeList4<Quaternion>>.write = Aggro.Core.Networking.NetworkSerialization.WriteQuaternionValueTypeList4;
			Writer<ValueTypeList4<Entity>>.write = Aggro.Core.Networking.NetworkSerialization.WriteEntityValueTypeList4;
			Writer<EventReference>.write = Aggro.Core.Networking.NetworkSerialization.WriteEventReference;
			Writer<SyncData>.write = SyncDataReaderWriter.WriteSyncData;
			Writer<PredictedSyncData>.write = PredictedSyncDataReadWrite.WritePredictedSyncData;
			Writer<ServerRequest>.write = _Write_Mirror_002EDiscovery_002EServerRequest;
			Writer<ServerResponse>.write = _Write_Mirror_002EDiscovery_002EServerResponse;
			Writer<DissonanceNetworkMessage>.write = DissonanceNetworkMessageExtensions.Serialize;
			Writer<NetMsgGameManagerLoad>.write = _Write_NetMsgGameManagerLoad;
			Writer<NetMsgGameManagerReady>.write = _Write_NetMsgGameManagerReady;
			Writer<NetMsgTeleported>.write = _Write_NetMsgTeleported;
			Writer<RoomType>.write = _Write_RoomType;
			Writer<NetMsgGameSettings>.write = _Write_NetMsgGameSettings;
			Writer<NetMsgServerPlayerJoined>.write = _Write_NetMsgServerPlayerJoined;
			Writer<NetMsgPlayerJoined>.write = _Write_NetMsgPlayerJoined;
			Writer<NetMsgPlayerLeft>.write = _Write_NetMsgPlayerLeft;
			Writer<BoxCharge.ChargeState>.write = _Write_BoxCharge_002FChargeState;
			Writer<BoxHaunted.Haunting>.write = _Write_BoxHaunted_002FHaunting;
			Writer<ActivatedFirework.State>.write = _Write_ActivatedFirework_002FState;
			Writer<ActivationContext>.write = _Write_ActivationContext;
			Writer<ActivationContextType>.write = _Write_ActivationContextType;
			Writer<ActivationContextSubType>.write = _Write_ActivationContextSubType;
			Writer<DamageType>.write = _Write_DamageType;
			Writer<DamageMask>.write = _Write_DamageMask;
			Writer<Exploder.ExplodeState>.write = _Write_Exploder_002FExplodeState;
			Writer<FireState>.write = _Write_FireState;
			Writer<LobbyPlayerClient.Info>.write = _Write_LobbyPlayerClient_002FInfo;
			Writer<PlayersManager.VoteOption>.write = _Write_PlayersManager_002FVoteOption;
			Writer<ShiftManager.OrderCountNet>.write = _Write_ShiftManager_002FOrderCountNet;
			Writer<ShiftPhase>.write = _Write_ShiftPhase;
			Writer<ContractScore>.write = _Write_ContractScore;
			Writer<PlayerResult[]>.write = _Write_PlayerResult_005B_005D;
			Writer<PlayerResult>.write = _Write_PlayerResult;
			Writer<Cactus.State>.write = _Write_Cactus_002FState;
			Writer<ModifierLava.State>.write = _Write_ModifierLava_002FState;
			Writer<ModifierArtStyle>.write = _Write_ModifierArtStyle;
			Writer<ModifierRoomSpawn.State>.write = _Write_ModifierRoomSpawn_002FState;
			Writer<WarehouseButtonState>.write = _Write_WarehouseButtonState;
			Writer<PlayerEffectContext>.write = _Write_PlayerEffectContext;
			Writer<PlayerUpgrade>.write = _Write_PlayerUpgrade;
			Writer<SprinklerManager.State>.write = _Write_SprinklerManager_002FState;
			Writer<StationBoxDestroyer.DestroyerState>.write = _Write_StationBoxDestroyer_002FDestroyerState;
			Writer<StationSprinkler.SprinklerPreventionState>.write = _Write_StationSprinkler_002FSprinklerPreventionState;
			Writer<StationTeleporterManager.State>.write = _Write_StationTeleporterManager_002FState;
			Writer<OutboundBay.Count>.write = _Write_OutboundBay_002FCount;
			Writer<OutboundBay.BayState>.write = _Write_OutboundBay_002FBayState;
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
			Reader<int>.read = NetworkReaderExtensions.ReadVarInt;
			Reader<int?>.read = NetworkReaderExtensions.ReadIntNullable;
			Reader<uint>.read = NetworkReaderExtensions.ReadVarUInt;
			Reader<uint?>.read = NetworkReaderExtensions.ReadUIntNullable;
			Reader<long>.read = NetworkReaderExtensions.ReadVarLong;
			Reader<long?>.read = NetworkReaderExtensions.ReadLongNullable;
			Reader<ulong>.read = NetworkReaderExtensions.ReadVarULong;
			Reader<ulong?>.read = NetworkReaderExtensions.ReadULongNullable;
			Reader<float>.read = NetworkReaderExtensions.ReadFloat;
			Reader<float?>.read = NetworkReaderExtensions.ReadFloatNullable;
			Reader<double>.read = NetworkReaderExtensions.ReadDouble;
			Reader<double?>.read = NetworkReaderExtensions.ReadDoubleNullable;
			Reader<decimal>.read = NetworkReaderExtensions.ReadDecimal;
			Reader<decimal?>.read = NetworkReaderExtensions.ReadDecimalNullable;
			Reader<Half>.read = NetworkReaderExtensions.ReadHalf;
			Reader<string>.read = NetworkReaderExtensions.ReadString;
			Reader<byte[]>.read = NetworkReaderExtensions.ReadBytesAndSize;
			Reader<ArraySegment<byte>>.read = NetworkReaderExtensions.ReadArraySegmentAndSize;
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
			Reader<LayerMask>.read = NetworkReaderExtensions.ReadLayerMask;
			Reader<LayerMask?>.read = NetworkReaderExtensions.ReadLayerMaskNullable;
			Reader<Matrix4x4>.read = NetworkReaderExtensions.ReadMatrix4x4;
			Reader<Matrix4x4?>.read = NetworkReaderExtensions.ReadMatrix4x4Nullable;
			Reader<Guid>.read = NetworkReaderExtensions.ReadGuid;
			Reader<Guid?>.read = NetworkReaderExtensions.ReadGuidNullable;
			Reader<NetworkIdentity>.read = NetworkReaderExtensions.ReadNetworkIdentity;
			Reader<NetworkBehaviour>.read = NetworkReaderExtensions.ReadNetworkBehaviour;
			Reader<NetworkBehaviourSyncVar>.read = NetworkReaderExtensions.ReadNetworkBehaviourSyncVar;
			Reader<Transform>.read = NetworkReaderExtensions.ReadTransform;
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
			Reader<SpawnFlags>.read = _Read_Mirror_002ESpawnFlags;
			Reader<ChangeOwnerMessage>.read = _Read_Mirror_002EChangeOwnerMessage;
			Reader<ObjectSpawnStartedMessage>.read = _Read_Mirror_002EObjectSpawnStartedMessage;
			Reader<ObjectSpawnFinishedMessage>.read = _Read_Mirror_002EObjectSpawnFinishedMessage;
			Reader<ObjectDestroyMessage>.read = _Read_Mirror_002EObjectDestroyMessage;
			Reader<ObjectHideMessage>.read = _Read_Mirror_002EObjectHideMessage;
			Reader<EntityStateMessage>.read = _Read_Mirror_002EEntityStateMessage;
			Reader<NetworkPingMessage>.read = _Read_Mirror_002ENetworkPingMessage;
			Reader<NetworkPongMessage>.read = _Read_Mirror_002ENetworkPongMessage;
			Reader<Entity>.read = Aggro.Core.Networking.NetworkSerialization.ReadEntity;
			Reader<NetScrobId>.read = Aggro.Core.Networking.NetworkSerialization.ReadNetworkScrob;
			Reader<NetBehaviourId>.read = Aggro.Core.Networking.NetworkSerialization.ReadNetworkBehaviour;
			Reader<GameObject>.read = Aggro.Core.Networking.NetworkSerialization.ReadGameObject;
			Reader<ValueTypeList4<Vector3>>.read = Aggro.Core.Networking.NetworkSerialization.ReadVector3ValueTypeList4;
			Reader<ValueTypeList4<Quaternion>>.read = Aggro.Core.Networking.NetworkSerialization.ReadQuaternionValueTypeList4;
			Reader<ValueTypeList4<Entity>>.read = Aggro.Core.Networking.NetworkSerialization.ReadValueTypeList4;
			Reader<EventReference>.read = Aggro.Core.Networking.NetworkSerialization.ReadEventReference;
			Reader<SyncData>.read = SyncDataReaderWriter.ReadSyncData;
			Reader<PredictedSyncData>.read = PredictedSyncDataReadWrite.ReadPredictedSyncData;
			Reader<ServerRequest>.read = _Read_Mirror_002EDiscovery_002EServerRequest;
			Reader<ServerResponse>.read = _Read_Mirror_002EDiscovery_002EServerResponse;
			Reader<DissonanceNetworkMessage>.read = DissonanceNetworkMessageExtensions.Deserialize;
			Reader<NetMsgGameManagerLoad>.read = _Read_NetMsgGameManagerLoad;
			Reader<NetMsgGameManagerReady>.read = _Read_NetMsgGameManagerReady;
			Reader<NetMsgTeleported>.read = _Read_NetMsgTeleported;
			Reader<RoomType>.read = _Read_RoomType;
			Reader<NetMsgGameSettings>.read = _Read_NetMsgGameSettings;
			Reader<NetMsgServerPlayerJoined>.read = _Read_NetMsgServerPlayerJoined;
			Reader<NetMsgPlayerJoined>.read = _Read_NetMsgPlayerJoined;
			Reader<NetMsgPlayerLeft>.read = _Read_NetMsgPlayerLeft;
			Reader<BoxCharge.ChargeState>.read = _Read_BoxCharge_002FChargeState;
			Reader<BoxHaunted.Haunting>.read = _Read_BoxHaunted_002FHaunting;
			Reader<ActivatedFirework.State>.read = _Read_ActivatedFirework_002FState;
			Reader<ActivationContext>.read = _Read_ActivationContext;
			Reader<ActivationContextType>.read = _Read_ActivationContextType;
			Reader<ActivationContextSubType>.read = _Read_ActivationContextSubType;
			Reader<DamageType>.read = _Read_DamageType;
			Reader<DamageMask>.read = _Read_DamageMask;
			Reader<Exploder.ExplodeState>.read = _Read_Exploder_002FExplodeState;
			Reader<FireState>.read = _Read_FireState;
			Reader<LobbyPlayerClient.Info>.read = _Read_LobbyPlayerClient_002FInfo;
			Reader<PlayersManager.VoteOption>.read = _Read_PlayersManager_002FVoteOption;
			Reader<ShiftManager.OrderCountNet>.read = _Read_ShiftManager_002FOrderCountNet;
			Reader<ShiftPhase>.read = _Read_ShiftPhase;
			Reader<ContractScore>.read = _Read_ContractScore;
			Reader<PlayerResult[]>.read = _Read_PlayerResult_005B_005D;
			Reader<PlayerResult>.read = _Read_PlayerResult;
			Reader<Cactus.State>.read = _Read_Cactus_002FState;
			Reader<ModifierLava.State>.read = _Read_ModifierLava_002FState;
			Reader<ModifierArtStyle>.read = _Read_ModifierArtStyle;
			Reader<ModifierRoomSpawn.State>.read = _Read_ModifierRoomSpawn_002FState;
			Reader<WarehouseButtonState>.read = _Read_WarehouseButtonState;
			Reader<PlayerEffectContext>.read = _Read_PlayerEffectContext;
			Reader<PlayerUpgrade>.read = _Read_PlayerUpgrade;
			Reader<SprinklerManager.State>.read = _Read_SprinklerManager_002FState;
			Reader<StationBoxDestroyer.DestroyerState>.read = _Read_StationBoxDestroyer_002FDestroyerState;
			Reader<StationSprinkler.SprinklerPreventionState>.read = _Read_StationSprinkler_002FSprinklerPreventionState;
			Reader<StationTeleporterManager.State>.read = _Read_StationTeleporterManager_002FState;
			Reader<OutboundBay.Count>.read = _Read_OutboundBay_002FCount;
			Reader<OutboundBay.BayState>.read = _Read_OutboundBay_002FBayState;
		}
	}
}
