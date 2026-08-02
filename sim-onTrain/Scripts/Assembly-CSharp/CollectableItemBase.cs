using System;
using System.Runtime.InteropServices;
using Mirror;
using UnityEngine;

public class CollectableItemBase : NetworkBehaviour, IItem
{
	public CollectableItemData collectableItemData;

	[SyncVar]
	public string itemName = "";

	[SyncVar]
	public int itemCount = 1;

	[SyncVar]
	public float itemDurability = -1f;

	public string NetworkitemName
	{
		get
		{
			return itemName;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref itemName, 1uL, null);
		}
	}

	public int NetworkitemCount
	{
		get
		{
			return itemCount;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref itemCount, 2uL, null);
		}
	}

	public float NetworkitemDurability
	{
		get
		{
			return itemDurability;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref itemDurability, 4uL, null);
		}
	}

	public virtual void Start()
	{
		if (base.isServer && collectableItemData != null && collectableItemData.hasDurability && itemDurability < 0f)
		{
			NetworkitemDurability = collectableItemData.maxDurabilityCapacity;
		}
	}

	public override void OnStartClient()
	{
		base.OnStartClient();
		if (!string.IsNullOrEmpty(itemName))
		{
			LoadCollectableData();
		}
	}

	public void LoadCollectableData()
	{
		if (NetworkSceneObjectSpawner.Instance != null)
		{
			collectableItemData = NetworkSceneObjectSpawner.Instance.GetCollectableItemFromName(itemName);
			if (collectableItemData == null)
			{
				Debug.LogError("Collectable data not found for: " + itemName);
			}
		}
	}

	[Server]
	public void SetItemData(string name, int count)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void CollectableItemBase::SetItemData(System.String,System.Int32)' called when server was not active");
			return;
		}
		NetworkitemName = name;
		NetworkitemCount = count;
		LoadCollectableData();
		if (collectableItemData != null && collectableItemData.hasDurability && itemDurability < 0f)
		{
			NetworkitemDurability = collectableItemData.maxDurabilityCapacity;
		}
	}

	[Server]
	public void SetItemDataWithDurability(string name, int count, float durability)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void CollectableItemBase::SetItemDataWithDurability(System.String,System.Int32,System.Single)' called when server was not active");
			return;
		}
		NetworkitemName = name;
		NetworkitemCount = count;
		NetworkitemDurability = durability;
		LoadCollectableData();
	}

	public virtual void Collect(PlayerInventory player)
	{
		if (collectableItemData != null)
		{
			float maxDurabilityCapacity = itemDurability;
			if (collectableItemData.hasDurability && maxDurabilityCapacity < 0f)
			{
				maxDurabilityCapacity = collectableItemData.maxDurabilityCapacity;
			}
			player.AddItemInventory(collectableItemData, itemCount, maxDurabilityCapacity);
		}
	}

	public virtual void DestroyItem()
	{
		NetworkSceneObjectSpawner.Instance.CmdDestroyObject(base.gameObject);
	}

	public void AutoDestroy(float time)
	{
		throw new NotImplementedException();
	}

	public void Drop()
	{
		Debug.Log("drop");
		throw new NotImplementedException();
	}

	public void Take()
	{
		if (Singleton<UserMessagePanel>.Instance != null)
		{
			Singleton<UserMessagePanel>.Instance.SendMessageToPanel("+" + itemCount + " " + collectableItemData.GetLocalizedDisplayName(), collectableItemData);
		}
	}

	public override bool Weaved()
	{
		return true;
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteString(itemName);
			writer.WriteInt(itemCount);
			writer.WriteFloat(itemDurability);
			return;
		}
		writer.WriteULong(base.syncVarDirtyBits);
		if ((base.syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteString(itemName);
		}
		if ((base.syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteInt(itemCount);
		}
		if ((base.syncVarDirtyBits & 4L) != 0L)
		{
			writer.WriteFloat(itemDurability);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref itemName, null, reader.ReadString());
			GeneratedSyncVarDeserialize(ref itemCount, null, reader.ReadInt());
			GeneratedSyncVarDeserialize(ref itemDurability, null, reader.ReadFloat());
			return;
		}
		long num = (long)reader.ReadULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref itemName, null, reader.ReadString());
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref itemCount, null, reader.ReadInt());
		}
		if ((num & 4L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref itemDurability, null, reader.ReadFloat());
		}
	}
}
