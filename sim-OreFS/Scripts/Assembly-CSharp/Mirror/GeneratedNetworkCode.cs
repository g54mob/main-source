using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
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

		public static EntityStateMessageUnreliableBaseline _Read_Mirror_002EEntityStateMessageUnreliableBaseline(NetworkReader reader)
		{
			return new EntityStateMessageUnreliableBaseline
			{
				baselineTick = NetworkReaderExtensions.ReadByte(reader),
				netId = reader.ReadVarUInt(),
				payload = reader.ReadArraySegmentAndSize()
			};
		}

		public static void _Write_Mirror_002EEntityStateMessageUnreliableBaseline(NetworkWriter writer, EntityStateMessageUnreliableBaseline value)
		{
			NetworkWriterExtensions.WriteByte(writer, value.baselineTick);
			writer.WriteVarUInt(value.netId);
			writer.WriteArraySegmentAndSize(value.payload);
		}

		public static EntityStateMessageUnreliableDelta _Read_Mirror_002EEntityStateMessageUnreliableDelta(NetworkReader reader)
		{
			return new EntityStateMessageUnreliableDelta
			{
				baselineTick = NetworkReaderExtensions.ReadByte(reader),
				netId = reader.ReadVarUInt(),
				payload = reader.ReadArraySegmentAndSize()
			};
		}

		public static void _Write_Mirror_002EEntityStateMessageUnreliableDelta(NetworkWriter writer, EntityStateMessageUnreliableDelta value)
		{
			NetworkWriterExtensions.WriteByte(writer, value.baselineTick);
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

		public static DiggerReplayMessenger.ClientReadyForReplayMsg _Read_DiggerReplayMessenger_002FClientReadyForReplayMsg(NetworkReader reader)
		{
			return new DiggerReplayMessenger.ClientReadyForReplayMsg
			{
				lastKnownIndex = reader.ReadVarInt()
			};
		}

		public static void _Write_DiggerReplayMessenger_002FClientReadyForReplayMsg(NetworkWriter writer, DiggerReplayMessenger.ClientReadyForReplayMsg value)
		{
			writer.WriteVarInt(value.lastKnownIndex);
		}

		public static DiggerReplayMessenger.ReplayBeginMsg _Read_DiggerReplayMessenger_002FReplayBeginMsg(NetworkReader reader)
		{
			return new DiggerReplayMessenger.ReplayBeginMsg
			{
				expectedTotal = reader.ReadVarInt(),
				startIndex = reader.ReadVarInt()
			};
		}

		public static void _Write_DiggerReplayMessenger_002FReplayBeginMsg(NetworkWriter writer, DiggerReplayMessenger.ReplayBeginMsg value)
		{
			writer.WriteVarInt(value.expectedTotal);
			writer.WriteVarInt(value.startIndex);
		}

		public static DiggerReplayMessenger.ReplayChunkMsg _Read_DiggerReplayMessenger_002FReplayChunkMsg(NetworkReader reader)
		{
			return new DiggerReplayMessenger.ReplayChunkMsg
			{
				chunk = _Read_System_002ECollections_002EGeneric_002EList_00601_003CDiggerReplayMessenger_002FReplayOp_003E(reader)
			};
		}

		public static List<DiggerReplayMessenger.ReplayOp> _Read_System_002ECollections_002EGeneric_002EList_00601_003CDiggerReplayMessenger_002FReplayOp_003E(NetworkReader reader)
		{
			return reader.ReadList<DiggerReplayMessenger.ReplayOp>();
		}

		public static DiggerReplayMessenger.ReplayOp _Read_DiggerReplayMessenger_002FReplayOp(NetworkReader reader)
		{
			return new DiggerReplayMessenger.ReplayOp
			{
				pos = reader.ReadVector3(),
				vfxPos = reader.ReadVector3(),
				vfxRot = reader.ReadVector3(),
				brush = NetworkReaderExtensions.ReadByte(reader),
				action = NetworkReaderExtensions.ReadByte(reader),
				size = reader.ReadFloat(),
				opacity = reader.ReadFloat(),
				textureIndex = reader.ReadSByte()
			};
		}

		public static void _Write_DiggerReplayMessenger_002FReplayChunkMsg(NetworkWriter writer, DiggerReplayMessenger.ReplayChunkMsg value)
		{
			_Write_System_002ECollections_002EGeneric_002EList_00601_003CDiggerReplayMessenger_002FReplayOp_003E(writer, value.chunk);
		}

		public static void _Write_System_002ECollections_002EGeneric_002EList_00601_003CDiggerReplayMessenger_002FReplayOp_003E(NetworkWriter writer, List<DiggerReplayMessenger.ReplayOp> value)
		{
			writer.WriteList(value);
		}

		public static void _Write_DiggerReplayMessenger_002FReplayOp(NetworkWriter writer, DiggerReplayMessenger.ReplayOp value)
		{
			writer.WriteVector3(value.pos);
			writer.WriteVector3(value.vfxPos);
			writer.WriteVector3(value.vfxRot);
			NetworkWriterExtensions.WriteByte(writer, value.brush);
			NetworkWriterExtensions.WriteByte(writer, value.action);
			writer.WriteFloat(value.size);
			writer.WriteFloat(value.opacity);
			writer.WriteSByte(value.textureIndex);
		}

		public static DiggerReplayMessenger.ReplayEndMsg _Read_DiggerReplayMessenger_002FReplayEndMsg(NetworkReader reader)
		{
			return default(DiggerReplayMessenger.ReplayEndMsg);
		}

		public static void _Write_DiggerReplayMessenger_002FReplayEndMsg(NetworkWriter writer, DiggerReplayMessenger.ReplayEndMsg value)
		{
		}

		public static DiggerReplayMessenger.ReplayCompleteMsg _Read_DiggerReplayMessenger_002FReplayCompleteMsg(NetworkReader reader)
		{
			return default(DiggerReplayMessenger.ReplayCompleteMsg);
		}

		public static void _Write_DiggerReplayMessenger_002FReplayCompleteMsg(NetworkWriter writer, DiggerReplayMessenger.ReplayCompleteMsg value)
		{
		}

		public static global::SceneMessage _Read_SceneMessage(NetworkReader reader)
		{
			return new global::SceneMessage
			{
				sceneName = reader.ReadString()
			};
		}

		public static void _Write_SceneMessage(NetworkWriter writer, global::SceneMessage value)
		{
			writer.WriteString(value.sceneName);
		}

		public static DisconnectReasonMessage _Read_DisconnectReasonMessage(NetworkReader reader)
		{
			return new DisconnectReasonMessage
			{
				reason = _Read_DisconnectReason(reader)
			};
		}

		public static DisconnectReason _Read_DisconnectReason(NetworkReader reader)
		{
			return (DisconnectReason)reader.ReadVarInt();
		}

		public static void _Write_DisconnectReasonMessage(NetworkWriter writer, DisconnectReasonMessage value)
		{
			_Write_DisconnectReason(writer, value.reason);
		}

		public static void _Write_DisconnectReason(NetworkWriter writer, DisconnectReason value)
		{
			writer.WriteVarInt((int)value);
		}

		public static ContractListingData _Read_ContractListingData(NetworkReader reader)
		{
			return new ContractListingData
			{
				listingId = reader.ReadString(),
				contractId = reader.ReadString(),
				propertyConfigId = reader.ReadString(),
				companyName = reader.ReadString(),
				price = reader.ReadVarInt(),
				deliveryDays = reader.ReadVarInt(),
				materialIds = _Read_System_002EString_005B_005D(reader),
				materialCounts = _Read_System_002EInt32_005B_005D(reader),
				sourceType = _Read_ContractSourceType(reader),
				logoIndex = reader.ReadVarInt(),
				backgroundIndex = reader.ReadVarInt(),
				listedTime = reader.ReadDouble(),
				listedDay = reader.ReadVarInt(),
				contractNumber = reader.ReadVarInt(),
				requiredLevel = reader.ReadVarInt()
			};
		}

		public static string[] _Read_System_002EString_005B_005D(NetworkReader reader)
		{
			return reader.ReadArray<string>();
		}

		public static int[] _Read_System_002EInt32_005B_005D(NetworkReader reader)
		{
			return reader.ReadArray<int>();
		}

		public static ContractSourceType _Read_ContractSourceType(NetworkReader reader)
		{
			return (ContractSourceType)reader.ReadVarInt();
		}

		public static void _Write_ContractListingData(NetworkWriter writer, ContractListingData value)
		{
			writer.WriteString(value.listingId);
			writer.WriteString(value.contractId);
			writer.WriteString(value.propertyConfigId);
			writer.WriteString(value.companyName);
			writer.WriteVarInt(value.price);
			writer.WriteVarInt(value.deliveryDays);
			_Write_System_002EString_005B_005D(writer, value.materialIds);
			_Write_System_002EInt32_005B_005D(writer, value.materialCounts);
			_Write_ContractSourceType(writer, value.sourceType);
			writer.WriteVarInt(value.logoIndex);
			writer.WriteVarInt(value.backgroundIndex);
			writer.WriteDouble(value.listedTime);
			writer.WriteVarInt(value.listedDay);
			writer.WriteVarInt(value.contractNumber);
			writer.WriteVarInt(value.requiredLevel);
		}

		public static void _Write_System_002EString_005B_005D(NetworkWriter writer, string[] value)
		{
			writer.WriteArray(value);
		}

		public static void _Write_System_002EInt32_005B_005D(NetworkWriter writer, int[] value)
		{
			writer.WriteArray(value);
		}

		public static void _Write_ContractSourceType(NetworkWriter writer, ContractSourceType value)
		{
			writer.WriteVarInt((int)value);
		}

		public static ActiveContractData _Read_ActiveContractData(NetworkReader reader)
		{
			return new ActiveContractData
			{
				activeId = reader.ReadString(),
				listingId = reader.ReadString(),
				contractId = reader.ReadString(),
				propertyConfigId = reader.ReadString(),
				companyName = reader.ReadString(),
				agreedPrice = reader.ReadVarInt(),
				deliveryDays = reader.ReadVarInt(),
				materialIds = _Read_System_002EString_005B_005D(reader),
				materialCounts = _Read_System_002EInt32_005B_005D(reader),
				deliveredCounts = _Read_System_002EInt32_005B_005D(reader),
				acceptedDay = reader.ReadVarInt(),
				deadlineDay = reader.ReadVarInt(),
				state = _Read_ActiveContractState(reader),
				contractNumber = reader.ReadVarInt()
			};
		}

		public static ActiveContractState _Read_ActiveContractState(NetworkReader reader)
		{
			return (ActiveContractState)reader.ReadVarInt();
		}

		public static void _Write_ActiveContractData(NetworkWriter writer, ActiveContractData value)
		{
			writer.WriteString(value.activeId);
			writer.WriteString(value.listingId);
			writer.WriteString(value.contractId);
			writer.WriteString(value.propertyConfigId);
			writer.WriteString(value.companyName);
			writer.WriteVarInt(value.agreedPrice);
			writer.WriteVarInt(value.deliveryDays);
			_Write_System_002EString_005B_005D(writer, value.materialIds);
			_Write_System_002EInt32_005B_005D(writer, value.materialCounts);
			_Write_System_002EInt32_005B_005D(writer, value.deliveredCounts);
			writer.WriteVarInt(value.acceptedDay);
			writer.WriteVarInt(value.deadlineDay);
			_Write_ActiveContractState(writer, value.state);
			writer.WriteVarInt(value.contractNumber);
		}

		public static void _Write_ActiveContractState(NetworkWriter writer, ActiveContractState value)
		{
			writer.WriteVarInt((int)value);
		}

		public static void _Write_ContractNegotiationData(NetworkWriter writer, ContractNegotiationData value)
		{
			writer.WriteString(value.listingId);
			writer.WriteVarUInt(value.negotiatorNetId);
			writer.WriteVarInt(value.basePrice);
			writer.WriteVarInt(value.rejectThreshold);
			writer.WriteVarInt(value.acceptCeiling);
			writer.WriteVarInt(value.npcCurrentTarget);
			writer.WriteVarInt(value.npcInitialTarget);
			writer.WriteVarInt(value.finalOfferThreshold);
			writer.WriteVarInt(value.offerCount);
			writer.WriteVarInt(value.lastOfferAmount);
			writer.WriteVarInt(value.bestOfferSoFar);
			_Write_NegotiationState(writer, value.state);
			writer.WriteDouble(value.startTime);
			writer.WriteString(value.buyerMessage);
		}

		public static void _Write_NegotiationState(NetworkWriter writer, NegotiationState value)
		{
			writer.WriteVarInt((int)value);
		}

		public static ContractNegotiationData _Read_ContractNegotiationData(NetworkReader reader)
		{
			return new ContractNegotiationData
			{
				listingId = reader.ReadString(),
				negotiatorNetId = reader.ReadVarUInt(),
				basePrice = reader.ReadVarInt(),
				rejectThreshold = reader.ReadVarInt(),
				acceptCeiling = reader.ReadVarInt(),
				npcCurrentTarget = reader.ReadVarInt(),
				npcInitialTarget = reader.ReadVarInt(),
				finalOfferThreshold = reader.ReadVarInt(),
				offerCount = reader.ReadVarInt(),
				lastOfferAmount = reader.ReadVarInt(),
				bestOfferSoFar = reader.ReadVarInt(),
				state = _Read_NegotiationState(reader),
				startTime = reader.ReadDouble(),
				buyerMessage = reader.ReadString()
			};
		}

		public static NegotiationState _Read_NegotiationState(NetworkReader reader)
		{
			return (NegotiationState)reader.ReadVarInt();
		}

		public static void _Write_ContractCompletionResult(NetworkWriter writer, ContractCompletionResult value)
		{
			_Write_ActiveContractData(writer, value.contract);
			_Write_System_002EInt32_005B_005D(writer, value.finalDeliveredCounts);
			writer.WriteVarInt(value.basePrice);
			writer.WriteVarInt(value.earlyDeliveryBonus);
			writer.WriteVarInt(value.missingDeliveryPenalty);
			writer.WriteVarInt(value.totalEarnings);
			writer.WriteVarInt(value.earnedXP);
			writer.WriteBool(value.isFullDelivery);
			writer.WriteBool(value.isEarlyDelivery);
			writer.WriteVarInt(value.remainingDays);
			writer.WriteVarInt(value.totalDays);
			writer.WriteFloat(value.deliveryCompletionRatio);
		}

		public static ContractCompletionResult _Read_ContractCompletionResult(NetworkReader reader)
		{
			return new ContractCompletionResult
			{
				contract = _Read_ActiveContractData(reader),
				finalDeliveredCounts = _Read_System_002EInt32_005B_005D(reader),
				basePrice = reader.ReadVarInt(),
				earlyDeliveryBonus = reader.ReadVarInt(),
				missingDeliveryPenalty = reader.ReadVarInt(),
				totalEarnings = reader.ReadVarInt(),
				earnedXP = reader.ReadVarInt(),
				isFullDelivery = reader.ReadBool(),
				isEarlyDelivery = reader.ReadBool(),
				remainingDays = reader.ReadVarInt(),
				totalDays = reader.ReadVarInt(),
				deliveryCompletionRatio = reader.ReadFloat()
			};
		}

		public static ShoppingCartItemData _Read_ShoppingCartItemData(NetworkReader reader)
		{
			return new ShoppingCartItemData
			{
				itemSOIndex = reader.ReadVarInt(),
				quantity = reader.ReadVarInt()
			};
		}

		public static void _Write_ShoppingCartItemData(NetworkWriter writer, ShoppingCartItemData value)
		{
			writer.WriteVarInt(value.itemSOIndex);
			writer.WriteVarInt(value.quantity);
		}

		public static void _Write_System_002ECollections_002EGeneric_002EList_00601_003CShoppingCartItemData_003E(NetworkWriter writer, List<ShoppingCartItemData> value)
		{
			writer.WriteList(value);
		}

		public static List<ShoppingCartItemData> _Read_System_002ECollections_002EGeneric_002EList_00601_003CShoppingCartItemData_003E(NetworkReader reader)
		{
			return reader.ReadList<ShoppingCartItemData>();
		}

		public static PropertyListingData _Read_PropertyListingData(NetworkReader reader)
		{
			return new PropertyListingData
			{
				listingId = reader.ReadString(),
				configId = reader.ReadString(),
				propertyName = reader.ReadString(),
				address = reader.ReadString(),
				propertyType = _Read_PropertyType(reader),
				propertyLevel = reader.ReadVarInt(),
				basePrice = reader.ReadVarInt(),
				size = reader.ReadVarInt(),
				linkedSceneName = reader.ReadString(),
				visualIndex = reader.ReadVarInt(),
				spawnProfileIndex = reader.ReadVarInt(),
				listedTime = reader.ReadDouble()
			};
		}

		public static PropertyType _Read_PropertyType(NetworkReader reader)
		{
			return (PropertyType)reader.ReadVarInt();
		}

		public static void _Write_PropertyListingData(NetworkWriter writer, PropertyListingData value)
		{
			writer.WriteString(value.listingId);
			writer.WriteString(value.configId);
			writer.WriteString(value.propertyName);
			writer.WriteString(value.address);
			_Write_PropertyType(writer, value.propertyType);
			writer.WriteVarInt(value.propertyLevel);
			writer.WriteVarInt(value.basePrice);
			writer.WriteVarInt(value.size);
			writer.WriteString(value.linkedSceneName);
			writer.WriteVarInt(value.visualIndex);
			writer.WriteVarInt(value.spawnProfileIndex);
			writer.WriteDouble(value.listedTime);
		}

		public static void _Write_PropertyType(NetworkWriter writer, PropertyType value)
		{
			writer.WriteVarInt((int)value);
		}

		public static void _Write_PropertyNegotiationData(NetworkWriter writer, PropertyNegotiationData value)
		{
			writer.WriteString(value.listingId);
			writer.WriteVarUInt(value.negotiatorNetId);
			writer.WriteVarInt(value.basePrice);
			writer.WriteVarInt(value.rejectThreshold);
			writer.WriteVarInt(value.acceptFloor);
			writer.WriteVarInt(value.npcCurrentTarget);
			writer.WriteVarInt(value.npcInitialTarget);
			writer.WriteVarInt(value.finalOfferThreshold);
			writer.WriteVarInt(value.offerCount);
			writer.WriteVarInt(value.lastOfferAmount);
			writer.WriteVarInt(value.bestOfferSoFar);
			_Write_NegotiationState(writer, value.state);
			writer.WriteDouble(value.startTime);
			writer.WriteString(value.sellerMessage);
		}

		public static PropertyNegotiationData _Read_PropertyNegotiationData(NetworkReader reader)
		{
			return new PropertyNegotiationData
			{
				listingId = reader.ReadString(),
				negotiatorNetId = reader.ReadVarUInt(),
				basePrice = reader.ReadVarInt(),
				rejectThreshold = reader.ReadVarInt(),
				acceptFloor = reader.ReadVarInt(),
				npcCurrentTarget = reader.ReadVarInt(),
				npcInitialTarget = reader.ReadVarInt(),
				finalOfferThreshold = reader.ReadVarInt(),
				offerCount = reader.ReadVarInt(),
				lastOfferAmount = reader.ReadVarInt(),
				bestOfferSoFar = reader.ReadVarInt(),
				state = _Read_NegotiationState(reader),
				startTime = reader.ReadDouble(),
				sellerMessage = reader.ReadString()
			};
		}

		public static StockDemandData _Read_StockDemandData(NetworkReader reader)
		{
			return new StockDemandData
			{
				demandId = reader.ReadString(),
				itemId = reader.ReadString(),
				companyId = reader.ReadString(),
				companyName = reader.ReadString(),
				demandedAmount = reader.ReadVarInt(),
				pricePerUnit = reader.ReadVarInt(),
				demandMultiplier = reader.ReadFloat(),
				createdTime = reader.ReadDouble()
			};
		}

		public static void _Write_StockDemandData(NetworkWriter writer, StockDemandData value)
		{
			writer.WriteString(value.demandId);
			writer.WriteString(value.itemId);
			writer.WriteString(value.companyId);
			writer.WriteString(value.companyName);
			writer.WriteVarInt(value.demandedAmount);
			writer.WriteVarInt(value.pricePerUnit);
			writer.WriteFloat(value.demandMultiplier);
			writer.WriteDouble(value.createdTime);
		}

		public static ItemPriceModifier _Read_ItemPriceModifier(NetworkReader reader)
		{
			return new ItemPriceModifier
			{
				itemId = reader.ReadString(),
				priceMultiplier = reader.ReadFloat()
			};
		}

		public static void _Write_ItemPriceModifier(NetworkWriter writer, ItemPriceModifier value)
		{
			writer.WriteString(value.itemId);
			writer.WriteFloat(value.priceMultiplier);
		}

		public static void _Write_EconomyEntry_005B_005D(NetworkWriter writer, EconomyEntry[] value)
		{
			writer.WriteArray(value);
		}

		public static void _Write_EconomyEntry(NetworkWriter writer, EconomyEntry value)
		{
			_Write_EconomyType(writer, value.type);
			writer.WriteVarInt(value.value);
		}

		public static void _Write_EconomyType(NetworkWriter writer, EconomyType value)
		{
			writer.WriteVarInt((int)value);
		}

		public static EconomyEntry[] _Read_EconomyEntry_005B_005D(NetworkReader reader)
		{
			return reader.ReadArray<EconomyEntry>();
		}

		public static EconomyEntry _Read_EconomyEntry(NetworkReader reader)
		{
			return new EconomyEntry
			{
				type = _Read_EconomyType(reader),
				value = reader.ReadVarInt()
			};
		}

		public static EconomyType _Read_EconomyType(NetworkReader reader)
		{
			return (EconomyType)reader.ReadVarInt();
		}

		public static void _Write_PlayerActionNotificationType(NetworkWriter writer, PlayerActionNotificationType value)
		{
			writer.WriteVarInt((int)value);
		}

		public static PlayerActionNotificationType _Read_PlayerActionNotificationType(NetworkReader reader)
		{
			return (PlayerActionNotificationType)reader.ReadVarInt();
		}

		public static void _Write_System_002ECollections_002EGeneric_002EList_00601_003CItemType_003E(NetworkWriter writer, List<ItemType> value)
		{
			writer.WriteList(value);
		}

		public static void _Write_ItemType(NetworkWriter writer, ItemType value)
		{
			writer.WriteVarInt((int)value);
		}

		public static void _Write_System_002ECollections_002EGeneric_002EList_00601_003CSystem_002EInt32_003E(NetworkWriter writer, List<int> value)
		{
			writer.WriteList(value);
		}

		public static List<ItemType> _Read_System_002ECollections_002EGeneric_002EList_00601_003CItemType_003E(NetworkReader reader)
		{
			return reader.ReadList<ItemType>();
		}

		public static ItemType _Read_ItemType(NetworkReader reader)
		{
			return (ItemType)reader.ReadVarInt();
		}

		public static List<int> _Read_System_002ECollections_002EGeneric_002EList_00601_003CSystem_002EInt32_003E(NetworkReader reader)
		{
			return reader.ReadList<int>();
		}

		public static void _Write_System_002ECollections_002EGeneric_002EList_00601_003CSystem_002EString_003E(NetworkWriter writer, List<string> value)
		{
			writer.WriteList(value);
		}

		public static List<string> _Read_System_002ECollections_002EGeneric_002EList_00601_003CSystem_002EString_003E(NetworkReader reader)
		{
			return reader.ReadList<string>();
		}

		public static ItemStack _Read_ItemStack(NetworkReader reader)
		{
			if (!reader.ReadBool())
			{
				return null;
			}
			ItemStack itemStack = new ItemStack();
			itemStack.itemId = reader.ReadString();
			itemStack.count = reader.ReadVarInt();
			return itemStack;
		}

		public static void _Write_ItemStack(NetworkWriter writer, ItemStack value)
		{
			if (value == null)
			{
				writer.WriteBool(value: false);
				return;
			}
			writer.WriteBool(value: true);
			writer.WriteString(value.itemId);
			writer.WriteVarInt(value.count);
		}

		public static void _Write_BuildingModeSource(NetworkWriter writer, BuildingModeSource value)
		{
			writer.WriteVarInt((int)value);
		}

		public static BuildingModeSource _Read_BuildingModeSource(NetworkReader reader)
		{
			return (BuildingModeSource)reader.ReadVarInt();
		}

		public static DartPlayerScore _Read_DartPlayerScore(NetworkReader reader)
		{
			return new DartPlayerScore
			{
				playerNetId = reader.ReadVarUInt(),
				playerName = reader.ReadString(),
				score = reader.ReadVarInt()
			};
		}

		public static void _Write_DartPlayerScore(NetworkWriter writer, DartPlayerScore value)
		{
			writer.WriteVarUInt(value.playerNetId);
			writer.WriteString(value.playerName);
			writer.WriteVarInt(value.score);
		}

		public static void _Write_DeliveryPalletSyncData(NetworkWriter writer, DeliveryPalletSyncData value)
		{
			writer.WriteString(value.activeContractId);
			_Write_System_002EString_005B_005D(writer, value.itemIds);
			_Write_System_002EInt32_005B_005D(writer, value.itemCounts);
			_Write_System_002EInt32_005B_005D(writer, value.maxCounts);
		}

		public static DeliveryPalletSyncData _Read_DeliveryPalletSyncData(NetworkReader reader)
		{
			return new DeliveryPalletSyncData
			{
				activeContractId = reader.ReadString(),
				itemIds = _Read_System_002EString_005B_005D(reader),
				itemCounts = _Read_System_002EInt32_005B_005D(reader),
				maxCounts = _Read_System_002EInt32_005B_005D(reader)
			};
		}

		public static void _Write_PalletMachineState(NetworkWriter writer, PalletMachineState value)
		{
			writer.WriteVarInt((int)value);
		}

		public static PalletMachineState _Read_PalletMachineState(NetworkReader reader)
		{
			return (PalletMachineState)reader.ReadVarInt();
		}

		public static void _Write_LoadingType(NetworkWriter writer, LoadingType value)
		{
			writer.WriteVarInt((int)value);
		}

		public static LoadingType _Read_LoadingType(NetworkReader reader)
		{
			return (LoadingType)reader.ReadVarInt();
		}

		public static void _Write_DiggerController_002FDigOp(NetworkWriter writer, DiggerController.DigOp value)
		{
			writer.WriteVector3(value.pos);
			writer.WriteVector3(value.vfxPos);
			writer.WriteVector3(value.vfxRot);
			NetworkWriterExtensions.WriteByte(writer, value.brush);
			NetworkWriterExtensions.WriteByte(writer, value.action);
			writer.WriteFloat(value.size);
			writer.WriteFloat(value.opacity);
			writer.WriteSByte(value.textureIndex);
			writer.WriteBool(value.isFromNodeLayer);
		}

		public static DiggerController.DigOp _Read_DiggerController_002FDigOp(NetworkReader reader)
		{
			return new DiggerController.DigOp
			{
				pos = reader.ReadVector3(),
				vfxPos = reader.ReadVector3(),
				vfxRot = reader.ReadVector3(),
				brush = NetworkReaderExtensions.ReadByte(reader),
				action = NetworkReaderExtensions.ReadByte(reader),
				size = reader.ReadFloat(),
				opacity = reader.ReadFloat(),
				textureIndex = reader.ReadSByte(),
				isFromNodeLayer = reader.ReadBool()
			};
		}

		public static UpgradeNodeState _Read_UpgradeNodeState(NetworkReader reader)
		{
			return new UpgradeNodeState
			{
				upgradeType = _Read_UpgradeType(reader),
				currentLevel = reader.ReadVarInt()
			};
		}

		public static UpgradeType _Read_UpgradeType(NetworkReader reader)
		{
			return (UpgradeType)reader.ReadVarInt();
		}

		public static void _Write_UpgradeNodeState(NetworkWriter writer, UpgradeNodeState value)
		{
			_Write_UpgradeType(writer, value.upgradeType);
			writer.WriteVarInt(value.currentLevel);
		}

		public static void _Write_UpgradeType(NetworkWriter writer, UpgradeType value)
		{
			writer.WriteVarInt((int)value);
		}

		public static void _Write_System_002ECollections_002EGeneric_002EList_00601_003CUpgradeType_003E(NetworkWriter writer, List<UpgradeType> value)
		{
			writer.WriteList(value);
		}

		public static List<UpgradeType> _Read_System_002ECollections_002EGeneric_002EList_00601_003CUpgradeType_003E(NetworkReader reader)
		{
			return reader.ReadList<UpgradeType>();
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
			Writer<SpawnFlags>.write = _Write_Mirror_002ESpawnFlags;
			Writer<ChangeOwnerMessage>.write = _Write_Mirror_002EChangeOwnerMessage;
			Writer<ObjectSpawnStartedMessage>.write = _Write_Mirror_002EObjectSpawnStartedMessage;
			Writer<ObjectSpawnFinishedMessage>.write = _Write_Mirror_002EObjectSpawnFinishedMessage;
			Writer<ObjectDestroyMessage>.write = _Write_Mirror_002EObjectDestroyMessage;
			Writer<ObjectHideMessage>.write = _Write_Mirror_002EObjectHideMessage;
			Writer<EntityStateMessage>.write = _Write_Mirror_002EEntityStateMessage;
			Writer<EntityStateMessageUnreliableBaseline>.write = _Write_Mirror_002EEntityStateMessageUnreliableBaseline;
			Writer<EntityStateMessageUnreliableDelta>.write = _Write_Mirror_002EEntityStateMessageUnreliableDelta;
			Writer<NetworkPingMessage>.write = _Write_Mirror_002ENetworkPingMessage;
			Writer<NetworkPongMessage>.write = _Write_Mirror_002ENetworkPongMessage;
			Writer<SyncData>.write = SyncDataReaderWriter.WriteSyncData;
			Writer<PredictedSyncData>.write = PredictedSyncDataReadWrite.WritePredictedSyncData;
			Writer<ServerRequest>.write = _Write_Mirror_002EDiscovery_002EServerRequest;
			Writer<ServerResponse>.write = _Write_Mirror_002EDiscovery_002EServerResponse;
			Writer<DiggerReplayMessenger.ClientReadyForReplayMsg>.write = _Write_DiggerReplayMessenger_002FClientReadyForReplayMsg;
			Writer<DiggerReplayMessenger.ReplayBeginMsg>.write = _Write_DiggerReplayMessenger_002FReplayBeginMsg;
			Writer<DiggerReplayMessenger.ReplayChunkMsg>.write = _Write_DiggerReplayMessenger_002FReplayChunkMsg;
			Writer<List<DiggerReplayMessenger.ReplayOp>>.write = _Write_System_002ECollections_002EGeneric_002EList_00601_003CDiggerReplayMessenger_002FReplayOp_003E;
			Writer<DiggerReplayMessenger.ReplayOp>.write = _Write_DiggerReplayMessenger_002FReplayOp;
			Writer<DiggerReplayMessenger.ReplayEndMsg>.write = _Write_DiggerReplayMessenger_002FReplayEndMsg;
			Writer<DiggerReplayMessenger.ReplayCompleteMsg>.write = _Write_DiggerReplayMessenger_002FReplayCompleteMsg;
			Writer<global::SceneMessage>.write = _Write_SceneMessage;
			Writer<DisconnectReasonMessage>.write = _Write_DisconnectReasonMessage;
			Writer<DisconnectReason>.write = _Write_DisconnectReason;
			Writer<ContractListingData>.write = _Write_ContractListingData;
			Writer<string[]>.write = _Write_System_002EString_005B_005D;
			Writer<int[]>.write = _Write_System_002EInt32_005B_005D;
			Writer<ContractSourceType>.write = _Write_ContractSourceType;
			Writer<ActiveContractData>.write = _Write_ActiveContractData;
			Writer<ActiveContractState>.write = _Write_ActiveContractState;
			Writer<ContractNegotiationData>.write = _Write_ContractNegotiationData;
			Writer<NegotiationState>.write = _Write_NegotiationState;
			Writer<ContractCompletionResult>.write = _Write_ContractCompletionResult;
			Writer<ShoppingCartItemData>.write = _Write_ShoppingCartItemData;
			Writer<List<ShoppingCartItemData>>.write = _Write_System_002ECollections_002EGeneric_002EList_00601_003CShoppingCartItemData_003E;
			Writer<PropertyListingData>.write = _Write_PropertyListingData;
			Writer<PropertyType>.write = _Write_PropertyType;
			Writer<PropertyNegotiationData>.write = _Write_PropertyNegotiationData;
			Writer<StockDemandData>.write = _Write_StockDemandData;
			Writer<ItemPriceModifier>.write = _Write_ItemPriceModifier;
			Writer<EconomyEntry[]>.write = _Write_EconomyEntry_005B_005D;
			Writer<EconomyEntry>.write = _Write_EconomyEntry;
			Writer<EconomyType>.write = _Write_EconomyType;
			Writer<PlayerActionNotificationType>.write = _Write_PlayerActionNotificationType;
			Writer<List<ItemType>>.write = _Write_System_002ECollections_002EGeneric_002EList_00601_003CItemType_003E;
			Writer<ItemType>.write = _Write_ItemType;
			Writer<List<int>>.write = _Write_System_002ECollections_002EGeneric_002EList_00601_003CSystem_002EInt32_003E;
			Writer<List<string>>.write = _Write_System_002ECollections_002EGeneric_002EList_00601_003CSystem_002EString_003E;
			Writer<ItemStack>.write = _Write_ItemStack;
			Writer<BuildingModeSource>.write = _Write_BuildingModeSource;
			Writer<DartPlayerScore>.write = _Write_DartPlayerScore;
			Writer<DeliveryPalletSyncData>.write = _Write_DeliveryPalletSyncData;
			Writer<PalletMachineState>.write = _Write_PalletMachineState;
			Writer<LoadingType>.write = _Write_LoadingType;
			Writer<DiggerController.DigOp>.write = _Write_DiggerController_002FDigOp;
			Writer<UpgradeNodeState>.write = _Write_UpgradeNodeState;
			Writer<UpgradeType>.write = _Write_UpgradeType;
			Writer<List<UpgradeType>>.write = _Write_System_002ECollections_002EGeneric_002EList_00601_003CUpgradeType_003E;
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
			Reader<SpawnFlags>.read = _Read_Mirror_002ESpawnFlags;
			Reader<ChangeOwnerMessage>.read = _Read_Mirror_002EChangeOwnerMessage;
			Reader<ObjectSpawnStartedMessage>.read = _Read_Mirror_002EObjectSpawnStartedMessage;
			Reader<ObjectSpawnFinishedMessage>.read = _Read_Mirror_002EObjectSpawnFinishedMessage;
			Reader<ObjectDestroyMessage>.read = _Read_Mirror_002EObjectDestroyMessage;
			Reader<ObjectHideMessage>.read = _Read_Mirror_002EObjectHideMessage;
			Reader<EntityStateMessage>.read = _Read_Mirror_002EEntityStateMessage;
			Reader<EntityStateMessageUnreliableBaseline>.read = _Read_Mirror_002EEntityStateMessageUnreliableBaseline;
			Reader<EntityStateMessageUnreliableDelta>.read = _Read_Mirror_002EEntityStateMessageUnreliableDelta;
			Reader<NetworkPingMessage>.read = _Read_Mirror_002ENetworkPingMessage;
			Reader<NetworkPongMessage>.read = _Read_Mirror_002ENetworkPongMessage;
			Reader<SyncData>.read = SyncDataReaderWriter.ReadSyncData;
			Reader<PredictedSyncData>.read = PredictedSyncDataReadWrite.ReadPredictedSyncData;
			Reader<ServerRequest>.read = _Read_Mirror_002EDiscovery_002EServerRequest;
			Reader<ServerResponse>.read = _Read_Mirror_002EDiscovery_002EServerResponse;
			Reader<DiggerReplayMessenger.ClientReadyForReplayMsg>.read = _Read_DiggerReplayMessenger_002FClientReadyForReplayMsg;
			Reader<DiggerReplayMessenger.ReplayBeginMsg>.read = _Read_DiggerReplayMessenger_002FReplayBeginMsg;
			Reader<DiggerReplayMessenger.ReplayChunkMsg>.read = _Read_DiggerReplayMessenger_002FReplayChunkMsg;
			Reader<List<DiggerReplayMessenger.ReplayOp>>.read = _Read_System_002ECollections_002EGeneric_002EList_00601_003CDiggerReplayMessenger_002FReplayOp_003E;
			Reader<DiggerReplayMessenger.ReplayOp>.read = _Read_DiggerReplayMessenger_002FReplayOp;
			Reader<DiggerReplayMessenger.ReplayEndMsg>.read = _Read_DiggerReplayMessenger_002FReplayEndMsg;
			Reader<DiggerReplayMessenger.ReplayCompleteMsg>.read = _Read_DiggerReplayMessenger_002FReplayCompleteMsg;
			Reader<global::SceneMessage>.read = _Read_SceneMessage;
			Reader<DisconnectReasonMessage>.read = _Read_DisconnectReasonMessage;
			Reader<DisconnectReason>.read = _Read_DisconnectReason;
			Reader<ContractListingData>.read = _Read_ContractListingData;
			Reader<string[]>.read = _Read_System_002EString_005B_005D;
			Reader<int[]>.read = _Read_System_002EInt32_005B_005D;
			Reader<ContractSourceType>.read = _Read_ContractSourceType;
			Reader<ActiveContractData>.read = _Read_ActiveContractData;
			Reader<ActiveContractState>.read = _Read_ActiveContractState;
			Reader<ContractNegotiationData>.read = _Read_ContractNegotiationData;
			Reader<NegotiationState>.read = _Read_NegotiationState;
			Reader<ContractCompletionResult>.read = _Read_ContractCompletionResult;
			Reader<ShoppingCartItemData>.read = _Read_ShoppingCartItemData;
			Reader<List<ShoppingCartItemData>>.read = _Read_System_002ECollections_002EGeneric_002EList_00601_003CShoppingCartItemData_003E;
			Reader<PropertyListingData>.read = _Read_PropertyListingData;
			Reader<PropertyType>.read = _Read_PropertyType;
			Reader<PropertyNegotiationData>.read = _Read_PropertyNegotiationData;
			Reader<StockDemandData>.read = _Read_StockDemandData;
			Reader<ItemPriceModifier>.read = _Read_ItemPriceModifier;
			Reader<EconomyEntry[]>.read = _Read_EconomyEntry_005B_005D;
			Reader<EconomyEntry>.read = _Read_EconomyEntry;
			Reader<EconomyType>.read = _Read_EconomyType;
			Reader<PlayerActionNotificationType>.read = _Read_PlayerActionNotificationType;
			Reader<List<ItemType>>.read = _Read_System_002ECollections_002EGeneric_002EList_00601_003CItemType_003E;
			Reader<ItemType>.read = _Read_ItemType;
			Reader<List<int>>.read = _Read_System_002ECollections_002EGeneric_002EList_00601_003CSystem_002EInt32_003E;
			Reader<List<string>>.read = _Read_System_002ECollections_002EGeneric_002EList_00601_003CSystem_002EString_003E;
			Reader<ItemStack>.read = _Read_ItemStack;
			Reader<BuildingModeSource>.read = _Read_BuildingModeSource;
			Reader<DartPlayerScore>.read = _Read_DartPlayerScore;
			Reader<DeliveryPalletSyncData>.read = _Read_DeliveryPalletSyncData;
			Reader<PalletMachineState>.read = _Read_PalletMachineState;
			Reader<LoadingType>.read = _Read_LoadingType;
			Reader<DiggerController.DigOp>.read = _Read_DiggerController_002FDigOp;
			Reader<UpgradeNodeState>.read = _Read_UpgradeNodeState;
			Reader<UpgradeType>.read = _Read_UpgradeType;
			Reader<List<UpgradeType>>.read = _Read_System_002ECollections_002EGeneric_002EList_00601_003CUpgradeType_003E;
		}
	}
}
