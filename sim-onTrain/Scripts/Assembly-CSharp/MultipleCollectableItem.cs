using System.Collections.Generic;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class MultipleCollectableItem : NetworkBehaviour
{
	public SyncList<DroppedItemData> droppedItems = new SyncList<DroppedItemData>();

	private void Start()
	{
		if (!GetComponent<Collider>())
		{
			SphereCollider sphereCollider = base.gameObject.AddComponent<SphereCollider>();
			sphereCollider.radius = 2f;
			sphereCollider.isTrigger = true;
		}
		if (!GetComponent<Rigidbody>())
		{
			Rigidbody rigidbody = base.gameObject.AddComponent<Rigidbody>();
			rigidbody.useGravity = true;
			rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
		}
	}

	[Server]
	public void SetInventoryData(List<InventorySlotsData> inventorySlots)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void MultipleCollectableItem::SetInventoryData(System.Collections.Generic.List`1<InventorySlotsData>)' called when server was not active");
			return;
		}
		droppedItems.Clear();
		foreach (InventorySlotsData inventorySlot in inventorySlots)
		{
			if (inventorySlot.item != null && inventorySlot.itemCountInSlot > 0)
			{
				DroppedItemData item = new DroppedItemData
				{
					itemName = inventorySlot.item.itemName,
					itemCount = inventorySlot.itemCountInSlot
				};
				droppedItems.Add(item);
			}
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (!other.TryGetComponent<PlayerInventory>(out var component))
		{
			return;
		}
		Debug.Log("sa");
		if (other.TryGetComponent<TSPlayerController>(out var component2))
		{
			Debug.Log("dskldsla");
			if (component2.isDeath)
			{
				return;
			}
		}
		CollectAllItems(component);
	}

	[Server]
	private void CollectAllItems(PlayerInventory player)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void MultipleCollectableItem::CollectAllItems(PlayerInventory)' called when server was not active");
			return;
		}
		bool flag = true;
		List<DroppedItemData> list = new List<DroppedItemData>();
		foreach (DroppedItemData droppedItem in droppedItems)
		{
			CollectableItemData collectableItemFromName = NetworkSceneObjectSpawner.Instance.GetCollectableItemFromName(droppedItem.itemName);
			if (!(collectableItemFromName != null))
			{
				continue;
			}
			if (player.CanAddToInventory(collectableItemFromName, droppedItem.itemCount))
			{
				player.AddItemInventory(collectableItemFromName, droppedItem.itemCount);
				if (player.TryGetComponent<NetworkIdentity>(out var component))
				{
					RpcShowCollectMessage(component.connectionToClient, droppedItem.itemName, droppedItem.itemCount);
				}
			}
			else
			{
				flag = false;
				list.Add(droppedItem);
			}
		}
		if (flag)
		{
			NetworkServer.Destroy(base.gameObject);
			return;
		}
		droppedItems.Clear();
		foreach (DroppedItemData item in list)
		{
			droppedItems.Add(item);
		}
	}

	[TargetRpc]
	private void RpcShowCollectMessage(NetworkConnection target, string itemName, int count)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(itemName);
		writer.WriteInt(count);
		SendTargetRPCInternal(target, "System.Void MultipleCollectableItem::RpcShowCollectMessage(Mirror.NetworkConnection,System.String,System.Int32)", -303662181, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	public MultipleCollectableItem()
	{
		InitSyncObject(droppedItems);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_RpcShowCollectMessage__NetworkConnection__String__Int32(NetworkConnection target, string itemName, int count)
	{
		UserMessagePanel userMessagePanel = Object.FindObjectOfType<UserMessagePanel>();
		if (userMessagePanel != null)
		{
			CollectableItemData collectableItemFromName = NetworkSceneObjectSpawner.Instance.GetCollectableItemFromName(itemName);
			if (collectableItemFromName != null)
			{
				userMessagePanel.SendMessageToPanel("+" + count + " " + collectableItemFromName.GetLocalizedDisplayName(), collectableItemFromName);
			}
		}
	}

	protected static void InvokeUserCode_RpcShowCollectMessage__NetworkConnection__String__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("TargetRPC RpcShowCollectMessage called on server.");
		}
		else
		{
			((MultipleCollectableItem)obj).UserCode_RpcShowCollectMessage__NetworkConnection__String__Int32(null, reader.ReadString(), reader.ReadInt());
		}
	}

	static MultipleCollectableItem()
	{
		RemoteProcedureCalls.RegisterRpc(typeof(MultipleCollectableItem), "System.Void MultipleCollectableItem::RpcShowCollectMessage(Mirror.NetworkConnection,System.String,System.Int32)", InvokeUserCode_RpcShowCollectMessage__NetworkConnection__String__Int32);
	}
}
