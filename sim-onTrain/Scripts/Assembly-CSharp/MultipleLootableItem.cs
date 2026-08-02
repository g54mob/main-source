using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using EPOOutline;
using Mirror;
using UnityEngine;

public class MultipleLootableItem : NetworkBehaviour, IInteractable
{
	private bool isActive = true;

	private List<Outlinable> outline;

	private bool isInteracting;

	private bool isCollected;

	private PlayerInventory player;

	public SyncList<DroppedItemData> droppedItems = new SyncList<DroppedItemData>();

	[SerializeField]
	private Transform interactionParent;

	private const float MAX_LIFETIME = 180f;

	private float spawnTime;

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
			GeneratedSyncVarSetter(value, ref networkIsOnTrain, 1uL, OnTrainStateChanged);
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
			GeneratedSyncVarSetter(value, ref connectedTrainNetId, 2uL, OnConnectedTrainChanged);
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
			GeneratedSyncVarSetter(value, ref connectedWagonId, 4uL, OnConnectedWagonChanged);
		}
	}

	private void Start()
	{
		spawnTime = Time.time;
	}

	private void Update()
	{
		if (base.isServer && !isCollected)
		{
			if (base.transform.position.y < -100f)
			{
				NetworkServer.Destroy(base.gameObject);
			}
			else if (Time.time - spawnTime >= 180f)
			{
				NetworkServer.Destroy(base.gameObject);
			}
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

	[Server]
	public void AddDroppedItem(string itemName, int count)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void MultipleLootableItem::AddDroppedItem(System.String,System.Int32)' called when server was not active");
			return;
		}
		DroppedItemData item = new DroppedItemData
		{
			itemName = itemName,
			itemCount = count
		};
		droppedItems.Add(item);
	}

	[Server]
	public void SetDroppedItems(List<LootableItemEntry> items)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void MultipleLootableItem::SetDroppedItems(System.Collections.Generic.List`1<LootableItemEntry>)' called when server was not active");
			return;
		}
		droppedItems.Clear();
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		Dictionary<string, CollectableItemData> dictionary2 = new Dictionary<string, CollectableItemData>();
		foreach (LootableItemEntry item2 in items)
		{
			if (item2.collectableData != null && item2.count > 0)
			{
				string itemName = item2.collectableData.itemName;
				if (dictionary.ContainsKey(itemName))
				{
					dictionary[itemName] += item2.count;
					continue;
				}
				dictionary[itemName] = item2.count;
				dictionary2[itemName] = item2.collectableData;
			}
		}
		foreach (KeyValuePair<string, int> item3 in dictionary)
		{
			DroppedItemData item = new DroppedItemData
			{
				itemName = item3.Key,
				itemCount = item3.Value
			};
			droppedItems.Add(item);
		}
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
		string lootText = GetLootText();
		InteractionPanel.Instance.ShowInteractionOverlay(base.transform, player.transform, Singleton<UserPrefencesManager>.Instance.keyData.InteractKey, lootText);
	}

	private string GetLootText()
	{
		if (droppedItems.Count == 0)
		{
			return "Loot";
		}
		if (droppedItems.Count == 1)
		{
			DroppedItemData droppedItemData = droppedItems[0];
			CollectableItemData collectableItemFromName = NetworkSceneObjectSpawner.Instance.GetCollectableItemFromName(droppedItemData.itemName);
			string arg = ((collectableItemFromName != null) ? collectableItemFromName.GetLocalizedDisplayName() : droppedItemData.itemName);
			return $"{arg} ({droppedItemData.itemCount})";
		}
		return $"Loot ({droppedItems.Count} items)";
	}

	public void StopInteract()
	{
		isInteracting = false;
		foreach (Outlinable item in Outline)
		{
			item.enabled = false;
		}
		InteractionPanel.Instance.HideAllInteractions();
		if (player != null)
		{
			Interactor component = player.GetComponent<Interactor>();
			if (component != null)
			{
				component.lastInteractable = null;
			}
		}
	}

	public void Take(PlayerInventory player)
	{
		if (isCollected)
		{
			return;
		}
		if (droppedItems == null || droppedItems.Count == 0)
		{
			Debug.LogWarning("No items to loot!");
			return;
		}
		isCollected = true;
		if (NetworkSoundPlayer.Instance != null)
		{
			NetworkSoundPlayer.Instance.PlaySound2DLocal(GameAudios.TakeItemGeneralSound);
		}
		foreach (DroppedItemData droppedItem in droppedItems)
		{
			CollectableItemData collectableItemFromName = NetworkSceneObjectSpawner.Instance.GetCollectableItemFromName(droppedItem.itemName);
			if (!(collectableItemFromName != null) || droppedItem.itemCount <= 0)
			{
				continue;
			}
			int availableSpaceForItem = player.GetAvailableSpaceForItem(collectableItemFromName);
			int num = Mathf.Min(droppedItem.itemCount, availableSpaceForItem);
			int num2 = droppedItem.itemCount - num;
			if (num > 0)
			{
				player.AddItemInventory(collectableItemFromName, num);
				Singleton<UserMessagePanel>.Instance.SendMessageToPanel("+" + num + " " + collectableItemFromName.GetLocalizedDisplayName(), collectableItemFromName);
			}
			if (num2 > 0)
			{
				DropOverflow(player, collectableItemFromName, num2);
				if (Singleton<UserMessagePanel>.Instance != null)
				{
					Singleton<UserMessagePanel>.Instance.ShowInventoryFullMessage();
				}
			}
		}
		Collider component = GetComponent<Collider>();
		if (component != null)
		{
			component.enabled = false;
		}
		StopInteract();
		NetworkObjectDestroyer.Instance.CmdDestroyObject(base.gameObject);
	}

	private void DropOverflow(PlayerInventory player, CollectableItemData item, int amount)
	{
		Transform transform = player.GetComponent<TSPlayerController>().activeCamera.transform;
		Vector3 spawnPoint = transform.position + transform.forward;
		Vector3 spawnForward = transform.position + transform.forward * 2f;
		if (item.hasDurability)
		{
			NetworkSceneObjectSpawner.Instance.SpawnDropItemClientWithDurability(item.itemName, amount, spawnPoint, spawnForward, item.startDurability);
		}
		else
		{
			NetworkSceneObjectSpawner.Instance.SpawnDropItemClient(item.itemName, amount, spawnPoint, spawnForward);
		}
	}

	public MultipleLootableItem()
	{
		InitSyncObject(droppedItems);
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
		if ((base.syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteBool(networkIsOnTrain);
		}
		if ((base.syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteUInt(connectedTrainNetId);
		}
		if ((base.syncVarDirtyBits & 4L) != 0L)
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
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref networkIsOnTrain, OnTrainStateChanged, reader.ReadBool());
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref connectedTrainNetId, OnConnectedTrainChanged, reader.ReadUInt());
		}
		if ((num & 4L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref connectedWagonId, OnConnectedWagonChanged, reader.ReadInt());
		}
	}
}
