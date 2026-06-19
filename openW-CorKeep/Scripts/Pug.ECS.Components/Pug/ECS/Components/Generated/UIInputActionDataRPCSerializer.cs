using System.Runtime.InteropServices;
using AOT;
using Inventory;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.NetCode;

namespace Pug.ECS.Components.Generated
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	[BurstCompile]
	internal struct UIInputActionDataRPCSerializer : IComponentData, IQueryTypeParameter, IRpcCommandSerializer<UIInputActionDataRPC>
	{
		private static readonly PortableFunctionPointer<RpcExecutor.ExecuteDelegate> InvokeExecuteFunctionPointer = new PortableFunctionPointer<RpcExecutor.ExecuteDelegate>(InvokeExecute);

		public void Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in UIInputActionDataRPC data)
		{
			writer.WriteUInt(data.tick.SerializedData);
			writer.WriteInt((int)data.actionData.action);
			writer.WriteFloat(data.actionData.position.x);
			writer.WriteFloat(data.actionData.position.y);
			if (state.GhostFromEntity.HasComponent(data.actionData.entity))
			{
				GhostInstance ghostInstance = state.GhostFromEntity[data.actionData.entity];
				writer.WriteInt(ghostInstance.ghostId);
				writer.WriteUInt(ghostInstance.spawnTick.SerializedData);
			}
			else
			{
				writer.WriteInt(0);
				writer.WriteUInt(NetworkTick.Invalid.SerializedData);
			}
			writer.WriteInt((int)data.actionData.inventoryChangeData.inventoryAction);
			if (state.GhostFromEntity.HasComponent(data.actionData.inventoryChangeData.inventory1))
			{
				GhostInstance ghostInstance2 = state.GhostFromEntity[data.actionData.inventoryChangeData.inventory1];
				writer.WriteInt(ghostInstance2.ghostId);
				writer.WriteUInt(ghostInstance2.spawnTick.SerializedData);
			}
			else
			{
				writer.WriteInt(0);
				writer.WriteUInt(NetworkTick.Invalid.SerializedData);
			}
			if (state.GhostFromEntity.HasComponent(data.actionData.inventoryChangeData.entityOrInventory2))
			{
				GhostInstance ghostInstance3 = state.GhostFromEntity[data.actionData.inventoryChangeData.entityOrInventory2];
				writer.WriteInt(ghostInstance3.ghostId);
				writer.WriteUInt(ghostInstance3.spawnTick.SerializedData);
			}
			else
			{
				writer.WriteInt(0);
				writer.WriteUInt(NetworkTick.Invalid.SerializedData);
			}
			if (state.GhostFromEntity.HasComponent(data.actionData.inventoryChangeData.entityOrInventory3))
			{
				GhostInstance ghostInstance4 = state.GhostFromEntity[data.actionData.inventoryChangeData.entityOrInventory3];
				writer.WriteInt(ghostInstance4.ghostId);
				writer.WriteUInt(ghostInstance4.spawnTick.SerializedData);
			}
			else
			{
				writer.WriteInt(0);
				writer.WriteUInt(NetworkTick.Invalid.SerializedData);
			}
			writer.WriteInt(data.actionData.inventoryChangeData.index1);
			writer.WriteInt(data.actionData.inventoryChangeData.index2);
			writer.WriteInt(data.actionData.inventoryChangeData.index3);
			writer.WriteInt(data.actionData.inventoryChangeData.index4);
			writer.WriteInt((int)data.actionData.inventoryChangeData.objectID);
			writer.WriteInt(data.actionData.inventoryChangeData.amount);
			writer.WriteInt(data.actionData.inventoryChangeData.variation);
			writer.WriteFloat(data.actionData.inventoryChangeData.position1.x);
			writer.WriteFloat(data.actionData.inventoryChangeData.position1.y);
			writer.WriteFloat(data.actionData.inventoryChangeData.position1.z);
			writer.WriteFloat(data.actionData.inventoryChangeData.position2.x);
			writer.WriteFloat(data.actionData.inventoryChangeData.position2.y);
			writer.WriteFloat(data.actionData.inventoryChangeData.position2.z);
			writer.WriteUInt(data.actionData.inventoryChangeData.bool1 ? 1u : 0u);
			writer.WriteUInt(data.actionData.inventoryChangeData.bool2 ? 1u : 0u);
			writer.WriteFixedString64(data.actionData.inventoryChangeData.string1);
			writer.WriteInt((int)data.actionData.craftActionData.craftAction);
			writer.WriteInt((int)data.actionData.craftActionData.objectId);
			writer.WriteInt(data.actionData.craftActionData.amount);
			writer.WriteInt(data.actionData.craftActionData.additionalFreeAmount);
			if (state.GhostFromEntity.HasComponent(data.actionData.craftActionData.playerEntity))
			{
				GhostInstance ghostInstance5 = state.GhostFromEntity[data.actionData.craftActionData.playerEntity];
				writer.WriteInt(ghostInstance5.ghostId);
				writer.WriteUInt(ghostInstance5.spawnTick.SerializedData);
			}
			else
			{
				writer.WriteInt(0);
				writer.WriteUInt(NetworkTick.Invalid.SerializedData);
			}
			if (state.GhostFromEntity.HasComponent(data.actionData.craftActionData.craftingEntity))
			{
				GhostInstance ghostInstance6 = state.GhostFromEntity[data.actionData.craftActionData.craftingEntity];
				writer.WriteInt(ghostInstance6.ghostId);
				writer.WriteUInt(ghostInstance6.spawnTick.SerializedData);
			}
			else
			{
				writer.WriteInt(0);
				writer.WriteUInt(NetworkTick.Invalid.SerializedData);
			}
			if (state.GhostFromEntity.HasComponent(data.actionData.craftActionData.mainInventoryEntity))
			{
				GhostInstance ghostInstance7 = state.GhostFromEntity[data.actionData.craftActionData.mainInventoryEntity];
				writer.WriteInt(ghostInstance7.ghostId);
				writer.WriteUInt(ghostInstance7.spawnTick.SerializedData);
			}
			else
			{
				writer.WriteInt(0);
				writer.WriteUInt(NetworkTick.Invalid.SerializedData);
			}
			if (state.GhostFromEntity.HasComponent(data.actionData.craftActionData.targetInventoryEntity))
			{
				GhostInstance ghostInstance8 = state.GhostFromEntity[data.actionData.craftActionData.targetInventoryEntity];
				writer.WriteInt(ghostInstance8.ghostId);
				writer.WriteUInt(ghostInstance8.spawnTick.SerializedData);
			}
			else
			{
				writer.WriteInt(0);
				writer.WriteUInt(NetworkTick.Invalid.SerializedData);
			}
			writer.WriteInt(data.actionData.craftActionData.int0);
			writer.WriteInt(data.actionData.craftActionData.int1);
			writer.WriteUInt(data.actionData.craftActionData.bool0 ? 1u : 0u);
			writer.WriteUInt(data.actionData.craftActionData.bool1 ? 1u : 0u);
		}

		public void Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref UIInputActionDataRPC data)
		{
			data.tick = new NetworkTick
			{
				SerializedData = reader.ReadUInt()
			};
			data.actionData.action = (UIInputAction)reader.ReadInt();
			data.actionData.position.x = reader.ReadFloat();
			data.actionData.position.y = reader.ReadFloat();
			int num = reader.ReadInt();
			NetworkTick spawnTick = new NetworkTick
			{
				SerializedData = reader.ReadUInt()
			};
			data.actionData.entity = Entity.Null;
			if (num != 0 && state.ghostMap.TryGetValue(new SpawnedGhost
			{
				ghostId = num,
				spawnTick = spawnTick
			}, out var item))
			{
				data.actionData.entity = item;
			}
			data.actionData.inventoryChangeData.inventoryAction = (InventoryAction)reader.ReadInt();
			int num2 = reader.ReadInt();
			NetworkTick spawnTick2 = new NetworkTick
			{
				SerializedData = reader.ReadUInt()
			};
			data.actionData.inventoryChangeData.inventory1 = Entity.Null;
			if (num2 != 0 && state.ghostMap.TryGetValue(new SpawnedGhost
			{
				ghostId = num2,
				spawnTick = spawnTick2
			}, out var item2))
			{
				data.actionData.inventoryChangeData.inventory1 = item2;
			}
			int num3 = reader.ReadInt();
			NetworkTick spawnTick3 = new NetworkTick
			{
				SerializedData = reader.ReadUInt()
			};
			data.actionData.inventoryChangeData.entityOrInventory2 = Entity.Null;
			if (num3 != 0 && state.ghostMap.TryGetValue(new SpawnedGhost
			{
				ghostId = num3,
				spawnTick = spawnTick3
			}, out var item3))
			{
				data.actionData.inventoryChangeData.entityOrInventory2 = item3;
			}
			int num4 = reader.ReadInt();
			NetworkTick spawnTick4 = new NetworkTick
			{
				SerializedData = reader.ReadUInt()
			};
			data.actionData.inventoryChangeData.entityOrInventory3 = Entity.Null;
			if (num4 != 0 && state.ghostMap.TryGetValue(new SpawnedGhost
			{
				ghostId = num4,
				spawnTick = spawnTick4
			}, out var item4))
			{
				data.actionData.inventoryChangeData.entityOrInventory3 = item4;
			}
			data.actionData.inventoryChangeData.index1 = reader.ReadInt();
			data.actionData.inventoryChangeData.index2 = reader.ReadInt();
			data.actionData.inventoryChangeData.index3 = reader.ReadInt();
			data.actionData.inventoryChangeData.index4 = reader.ReadInt();
			data.actionData.inventoryChangeData.objectID = (ObjectID)reader.ReadInt();
			data.actionData.inventoryChangeData.amount = reader.ReadInt();
			data.actionData.inventoryChangeData.variation = reader.ReadInt();
			data.actionData.inventoryChangeData.position1.x = reader.ReadFloat();
			data.actionData.inventoryChangeData.position1.y = reader.ReadFloat();
			data.actionData.inventoryChangeData.position1.z = reader.ReadFloat();
			data.actionData.inventoryChangeData.position2.x = reader.ReadFloat();
			data.actionData.inventoryChangeData.position2.y = reader.ReadFloat();
			data.actionData.inventoryChangeData.position2.z = reader.ReadFloat();
			data.actionData.inventoryChangeData.bool1 = ((reader.ReadUInt() != 0) ? true : false);
			data.actionData.inventoryChangeData.bool2 = ((reader.ReadUInt() != 0) ? true : false);
			data.actionData.inventoryChangeData.string1 = reader.ReadFixedString64();
			data.actionData.craftActionData.craftAction = (CraftAction)reader.ReadInt();
			data.actionData.craftActionData.objectId = (ObjectID)reader.ReadInt();
			data.actionData.craftActionData.amount = reader.ReadInt();
			data.actionData.craftActionData.additionalFreeAmount = reader.ReadInt();
			int num5 = reader.ReadInt();
			NetworkTick spawnTick5 = new NetworkTick
			{
				SerializedData = reader.ReadUInt()
			};
			data.actionData.craftActionData.playerEntity = Entity.Null;
			if (num5 != 0 && state.ghostMap.TryGetValue(new SpawnedGhost
			{
				ghostId = num5,
				spawnTick = spawnTick5
			}, out var item5))
			{
				data.actionData.craftActionData.playerEntity = item5;
			}
			int num6 = reader.ReadInt();
			NetworkTick spawnTick6 = new NetworkTick
			{
				SerializedData = reader.ReadUInt()
			};
			data.actionData.craftActionData.craftingEntity = Entity.Null;
			if (num6 != 0 && state.ghostMap.TryGetValue(new SpawnedGhost
			{
				ghostId = num6,
				spawnTick = spawnTick6
			}, out var item6))
			{
				data.actionData.craftActionData.craftingEntity = item6;
			}
			int num7 = reader.ReadInt();
			NetworkTick spawnTick7 = new NetworkTick
			{
				SerializedData = reader.ReadUInt()
			};
			data.actionData.craftActionData.mainInventoryEntity = Entity.Null;
			if (num7 != 0 && state.ghostMap.TryGetValue(new SpawnedGhost
			{
				ghostId = num7,
				spawnTick = spawnTick7
			}, out var item7))
			{
				data.actionData.craftActionData.mainInventoryEntity = item7;
			}
			int num8 = reader.ReadInt();
			NetworkTick spawnTick8 = new NetworkTick
			{
				SerializedData = reader.ReadUInt()
			};
			data.actionData.craftActionData.targetInventoryEntity = Entity.Null;
			if (num8 != 0 && state.ghostMap.TryGetValue(new SpawnedGhost
			{
				ghostId = num8,
				spawnTick = spawnTick8
			}, out var item8))
			{
				data.actionData.craftActionData.targetInventoryEntity = item8;
			}
			data.actionData.craftActionData.int0 = reader.ReadInt();
			data.actionData.craftActionData.int1 = reader.ReadInt();
			data.actionData.craftActionData.bool0 = ((reader.ReadUInt() != 0) ? true : false);
			data.actionData.craftActionData.bool1 = ((reader.ReadUInt() != 0) ? true : false);
		}

		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(RpcExecutor.ExecuteDelegate))]
		private static void InvokeExecute(ref RpcExecutor.Parameters parameters)
		{
			RpcExecutor.ExecuteCreateRequestComponent<UIInputActionDataRPCSerializer, UIInputActionDataRPC>(ref parameters);
		}

		public PortableFunctionPointer<RpcExecutor.ExecuteDelegate> CompileExecute()
		{
			return InvokeExecuteFunctionPointer;
		}

		void IRpcCommandSerializer<UIInputActionDataRPC>.Serialize(ref DataStreamWriter writer, in RpcSerializerState state, in UIInputActionDataRPC data)
		{
			Serialize(ref writer, in state, in data);
		}

		void IRpcCommandSerializer<UIInputActionDataRPC>.Deserialize(ref DataStreamReader reader, in RpcDeserializerState state, ref UIInputActionDataRPC data)
		{
			Deserialize(ref reader, in state, ref data);
		}
	}
}
