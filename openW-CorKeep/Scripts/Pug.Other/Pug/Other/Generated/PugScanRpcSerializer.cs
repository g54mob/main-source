using System.Runtime.InteropServices;
using AOT;
using PugScan;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.NetCode;

namespace Pug.Other.Generated
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	[BurstCompile]
	internal struct PugScanRpcSerializer : IComponentData, IQueryTypeParameter, IRpcCommandSerializer<PugScanRpc>
	{
		private static readonly PortableFunctionPointer<RpcExecutor.ExecuteDelegate> InvokeExecuteFunctionPointer = new PortableFunctionPointer<RpcExecutor.ExecuteDelegate>(InvokeExecute);

		public void Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in PugScanRpc data)
		{
			writer.WriteInt((int)data.scanRequestCD.objectToScan.objectID);
			writer.WriteInt(data.scanRequestCD.objectToScan.amount);
			writer.WriteInt(data.scanRequestCD.objectToScan.variation);
			writer.WriteInt(data.scanRequestCD.objectToScan.variationUpdateCount);
			if (state.GhostFromEntity.HasComponent(data.scanRequestCD.inventory))
			{
				GhostInstance ghostInstance = state.GhostFromEntity[data.scanRequestCD.inventory];
				writer.WriteInt(ghostInstance.ghostId);
				writer.WriteUInt(ghostInstance.spawnTick.SerializedData);
			}
			else
			{
				writer.WriteInt(0);
				writer.WriteUInt(NetworkTick.Invalid.SerializedData);
			}
			writer.WriteInt(data.scanRequestCD.inventorySlot);
			writer.WriteUInt(data.scanRequestCD.consumeItemFromInventory ? 1u : 0u);
			if (state.GhostFromEntity.HasComponent(data.scanRequestCD.sourceConnectionEntity))
			{
				GhostInstance ghostInstance2 = state.GhostFromEntity[data.scanRequestCD.sourceConnectionEntity];
				writer.WriteInt(ghostInstance2.ghostId);
				writer.WriteUInt(ghostInstance2.spawnTick.SerializedData);
			}
			else
			{
				writer.WriteInt(0);
				writer.WriteUInt(NetworkTick.Invalid.SerializedData);
			}
			writer.WriteUInt(data.scanRequestCD.sendResponse ? 1u : 0u);
			writer.WriteInt((int)data.scanRequestCD.typeOfRequest);
			writer.WriteFloat(data.scanRequestCD.position.x);
			writer.WriteFloat(data.scanRequestCD.position.y);
			writer.WriteFloat(data.scanRequestCD.position.z);
			if (state.GhostFromEntity.HasComponent(data.scanRequestCD.mapMarkerToScan))
			{
				GhostInstance ghostInstance3 = state.GhostFromEntity[data.scanRequestCD.mapMarkerToScan];
				writer.WriteInt(ghostInstance3.ghostId);
				writer.WriteUInt(ghostInstance3.spawnTick.SerializedData);
			}
			else
			{
				writer.WriteInt(0);
				writer.WriteUInt(NetworkTick.Invalid.SerializedData);
			}
		}

		public void Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref PugScanRpc data)
		{
			data.scanRequestCD.objectToScan.objectID = (ObjectID)reader.ReadInt();
			data.scanRequestCD.objectToScan.amount = reader.ReadInt();
			data.scanRequestCD.objectToScan.variation = reader.ReadInt();
			data.scanRequestCD.objectToScan.variationUpdateCount = reader.ReadInt();
			int num = reader.ReadInt();
			NetworkTick spawnTick = new NetworkTick
			{
				SerializedData = reader.ReadUInt()
			};
			data.scanRequestCD.inventory = Entity.Null;
			if (num != 0 && state.ghostMap.TryGetValue(new SpawnedGhost
			{
				ghostId = num,
				spawnTick = spawnTick
			}, out var item))
			{
				data.scanRequestCD.inventory = item;
			}
			data.scanRequestCD.inventorySlot = reader.ReadInt();
			data.scanRequestCD.consumeItemFromInventory = ((reader.ReadUInt() != 0) ? true : false);
			int num2 = reader.ReadInt();
			NetworkTick spawnTick2 = new NetworkTick
			{
				SerializedData = reader.ReadUInt()
			};
			data.scanRequestCD.sourceConnectionEntity = Entity.Null;
			if (num2 != 0 && state.ghostMap.TryGetValue(new SpawnedGhost
			{
				ghostId = num2,
				spawnTick = spawnTick2
			}, out var item2))
			{
				data.scanRequestCD.sourceConnectionEntity = item2;
			}
			data.scanRequestCD.sendResponse = ((reader.ReadUInt() != 0) ? true : false);
			data.scanRequestCD.typeOfRequest = (PugScanType)reader.ReadInt();
			data.scanRequestCD.position.x = reader.ReadFloat();
			data.scanRequestCD.position.y = reader.ReadFloat();
			data.scanRequestCD.position.z = reader.ReadFloat();
			int num3 = reader.ReadInt();
			NetworkTick spawnTick3 = new NetworkTick
			{
				SerializedData = reader.ReadUInt()
			};
			data.scanRequestCD.mapMarkerToScan = Entity.Null;
			if (num3 != 0 && state.ghostMap.TryGetValue(new SpawnedGhost
			{
				ghostId = num3,
				spawnTick = spawnTick3
			}, out var item3))
			{
				data.scanRequestCD.mapMarkerToScan = item3;
			}
		}

		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(RpcExecutor.ExecuteDelegate))]
		private static void InvokeExecute(ref RpcExecutor.Parameters parameters)
		{
			RpcExecutor.ExecuteCreateRequestComponent<PugScanRpcSerializer, PugScanRpc>(ref parameters);
		}

		public PortableFunctionPointer<RpcExecutor.ExecuteDelegate> CompileExecute()
		{
			return InvokeExecuteFunctionPointer;
		}

		void IRpcCommandSerializer<PugScanRpc>.Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in PugScanRpc data)
		{
			Serialize(ref writer, in state, in data);
		}

		void IRpcCommandSerializer<PugScanRpc>.Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref PugScanRpc data)
		{
			Deserialize(ref reader, in state, ref data);
		}
	}
}
