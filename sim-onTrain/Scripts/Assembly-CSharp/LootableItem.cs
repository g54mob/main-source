using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using EPOOutline;
using Mirror;
using UnityEngine;

public class LootableItem : CollectableItemBase, IItem, IInteractable
{
	private bool isActive = true;

	private List<Outlinable> outline;

	private bool isInteracting;

	private bool isCollected;

	private PlayerInventory player;

	[SerializeField]
	private Transform interactionParent;

	[SerializeField]
	private LayerMask trainLayer;

	private bool isOnTrain;

	[SyncVar(hook = "OnTrainStateChanged")]
	private bool networkIsOnTrain;

	[SyncVar(hook = "OnConnectedTrainChanged")]
	private uint connectedTrainNetId;

	[SyncVar(hook = "OnConnectedWagonChanged")]
	private int connectedWagonId = -1;

	public bool IsActive
	{
		get
		{
			return isActive;
		}
		set
		{
			isActive = value;
		}
	}

	public List<Outlinable> Outline
	{
		get
		{
			if (outline != null)
			{
				return outline;
			}
			return GetComponentsInChildren<Outlinable>().ToList();
		}
	}

	public Transform InteractionParent
	{
		get
		{
			return interactionParent;
		}
		set
		{
			interactionParent = value;
		}
	}

	public bool NetworknetworkIsOnTrain
	{
		get
		{
			return networkIsOnTrain;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref networkIsOnTrain, 8uL, OnTrainStateChanged);
		}
	}

	public uint NetworkconnectedTrainNetId
	{
		get
		{
			return connectedTrainNetId;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref connectedTrainNetId, 16uL, OnConnectedTrainChanged);
		}
	}

	public int NetworkconnectedWagonId
	{
		get
		{
			return connectedWagonId;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref connectedWagonId, 32uL, OnConnectedWagonChanged);
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (!base.isServer || isOnTrain || ((1 << collision.collider.gameObject.layer) & (int)trainLayer) == 0)
		{
			return;
		}
		TrainController componentInParent = collision.collider.GetComponentInParent<TrainController>();
		if (componentInParent == null)
		{
			return;
		}
		NetworkIdentity component = componentInParent.GetComponent<NetworkIdentity>();
		if (!(component == null))
		{
			WagonController componentInParent2 = collision.collider.GetComponentInParent<WagonController>();
			int networkconnectedWagonId = ((componentInParent2 != null) ? componentInParent2.wagonID : (-1));
			Transform parent = ((componentInParent2 != null) ? componentInParent2.transform : componentInParent.transform);
			base.transform.SetParent(parent, worldPositionStays: true);
			Rigidbody component2 = GetComponent<Rigidbody>();
			if (component2 != null)
			{
				component2.constraints = (RigidbodyConstraints)10;
			}
			NetworkconnectedTrainNetId = component.netId;
			NetworkconnectedWagonId = networkconnectedWagonId;
			NetworknetworkIsOnTrain = true;
			isOnTrain = true;
		}
	}

	private void OnTrainStateChanged(bool oldValue, bool newValue)
	{
		if (!base.isServer)
		{
			if (newValue && connectedTrainNetId != 0)
			{
				UpdateTrainParentFromNetwork();
			}
			else if (!newValue)
			{
				base.transform.SetParent(null, worldPositionStays: true);
			}
		}
	}

	private void OnConnectedTrainChanged(uint oldValue, uint newValue)
	{
		if (!base.isServer && networkIsOnTrain && newValue != 0)
		{
			UpdateTrainParentFromNetwork();
		}
	}

	private void OnConnectedWagonChanged(int oldValue, int newValue)
	{
		if (!base.isServer && networkIsOnTrain)
		{
			UpdateTrainParentFromNetwork();
		}
	}

	private void UpdateTrainParentFromNetwork()
	{
		if (connectedTrainNetId == 0 || !NetworkClient.spawned.TryGetValue(connectedTrainNetId, out var value))
		{
			return;
		}
		TrainController component = value.GetComponent<TrainController>();
		if (component == null)
		{
			return;
		}
		Transform parent = component.transform;
		if (connectedWagonId >= 0)
		{
			WagonController wagonByID = component.GetWagonByID(connectedWagonId);
			if (wagonByID != null)
			{
				parent = wagonByID.transform;
			}
		}
		base.transform.SetParent(parent, worldPositionStays: true);
	}

	public void Interact(PlayerInventory playerInventory, Vector3 hitPoint)
	{
		if (isCollected)
		{
			return;
		}
		if (isInteracting)
		{
			if (Input.GetKeyDown(Singleton<UserPrefencesManager>.Instance.keyData.InteractKey))
			{
				Take(playerInventory);
			}
			return;
		}
		player = playerInventory;
		isInteracting = true;
		foreach (Outlinable item in Outline)
		{
			item.enabled = true;
		}
		InteractionPanel.Instance.ShowInteractionOverlay(base.transform, player.transform, Singleton<UserPrefencesManager>.Instance.keyData.InteractKey, collectableItemData.GetLocalizedDisplayName() + " (" + itemCount + ")");
	}

	public void StopInteract()
	{
		isInteracting = false;
		foreach (Outlinable item in Outline)
		{
			item.enabled = false;
		}
		InteractionPanel.Instance.HideAllInteractions();
		player.GetComponent<Interactor>().lastInteractable = null;
	}

	public void Take(PlayerInventory player)
	{
		isCollected = true;
		if (NetworkSoundPlayer.Instance != null)
		{
			NetworkSoundPlayer.Instance.PlaySound2DLocal(GameAudios.TakeItemGeneralSound);
		}
		float maxDurabilityCapacity = itemDurability;
		if (collectableItemData != null && collectableItemData.hasDurability && maxDurabilityCapacity < 0f)
		{
			maxDurabilityCapacity = collectableItemData.maxDurabilityCapacity;
		}
		int availableSpaceForItem = player.GetAvailableSpaceForItem(collectableItemData);
		int num = Mathf.Min(itemCount, availableSpaceForItem);
		int num2 = itemCount - num;
		if (num > 0)
		{
			player.AddItemInventory(collectableItemData, num, maxDurabilityCapacity);
			if (Singleton<UserMessagePanel>.Instance != null)
			{
				Singleton<UserMessagePanel>.Instance.SendMessageToPanel("+" + num + " " + collectableItemData.GetLocalizedDisplayName(), collectableItemData);
			}
		}
		if (num2 > 0)
		{
			DropOverflow(player, num2, maxDurabilityCapacity);
			if (Singleton<UserMessagePanel>.Instance != null)
			{
				Singleton<UserMessagePanel>.Instance.ShowInventoryFullMessage();
			}
		}
		GetComponent<Collider>().enabled = false;
		StopInteract();
		NetworkObjectDestroyer.Instance.CmdDestroyObject(base.gameObject);
	}

	private void DropOverflow(PlayerInventory player, int amount, float durability)
	{
		Transform transform = player.GetComponent<TSPlayerController>().activeCamera.transform;
		Vector3 spawnPoint = transform.position + transform.forward;
		Vector3 spawnForward = transform.position + transform.forward * 2f;
		if (collectableItemData.hasDurability)
		{
			NetworkSceneObjectSpawner.Instance.SpawnDropItemClientWithDurability(collectableItemData.itemName, amount, spawnPoint, spawnForward, durability);
		}
		else
		{
			NetworkSceneObjectSpawner.Instance.SpawnDropItemClient(collectableItemData.itemName, amount, spawnPoint, spawnForward);
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
			writer.WriteBool(networkIsOnTrain);
			writer.WriteUInt(connectedTrainNetId);
			writer.WriteInt(connectedWagonId);
			return;
		}
		writer.WriteULong(base.syncVarDirtyBits);
		if ((base.syncVarDirtyBits & 8L) != 0L)
		{
			writer.WriteBool(networkIsOnTrain);
		}
		if ((base.syncVarDirtyBits & 0x10L) != 0L)
		{
			writer.WriteUInt(connectedTrainNetId);
		}
		if ((base.syncVarDirtyBits & 0x20L) != 0L)
		{
			writer.WriteInt(connectedWagonId);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref networkIsOnTrain, OnTrainStateChanged, reader.ReadBool());
			GeneratedSyncVarDeserialize(ref connectedTrainNetId, OnConnectedTrainChanged, reader.ReadUInt());
			GeneratedSyncVarDeserialize(ref connectedWagonId, OnConnectedWagonChanged, reader.ReadInt());
			return;
		}
		long num = (long)reader.ReadULong();
		if ((num & 8L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref networkIsOnTrain, OnTrainStateChanged, reader.ReadBool());
		}
		if ((num & 0x10L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref connectedTrainNetId, OnConnectedTrainChanged, reader.ReadUInt());
		}
		if ((num & 0x20L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref connectedWagonId, OnConnectedWagonChanged, reader.ReadInt());
		}
	}
}
