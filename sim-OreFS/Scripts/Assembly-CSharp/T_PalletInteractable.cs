using System.Collections.Generic;
using I2.Loc;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class T_PalletInteractable : NetworkBehaviour
{
	[Header("References")]
	[SerializeField]
	private T_Pallet pallet;

	[SerializeField]
	private Interactable interactable;

	[SerializeField]
	private GameObject sackPrefab;

	private T_Equipments localEquipments;

	private T_Sack currentSack;

	private void Awake()
	{
		if (pallet == null)
		{
			pallet = GetComponent<T_Pallet>();
		}
		if (pallet == null)
		{
			Debug.LogError("T_PalletInteractable: T_Pallet component'i bulunamadı!");
		}
		if (interactable == null)
		{
			interactable = GetComponent<Interactable>();
		}
		if (interactable == null)
		{
			Debug.LogWarning("T_PalletInteractable: Interactable component'i bulunamadı! onPrimaryInteract event'ine manuel bağlanmalı.");
		}
	}

	private void Start()
	{
		if (GameManager.Instance != null && GameManager.Instance.localEquipments != null)
		{
			localEquipments = GameManager.Instance.localEquipments;
		}
	}

	public void OnPrimaryInteracted()
	{
		if (pallet == null)
		{
			return;
		}
		if (localEquipments == null)
		{
			if (GameManager.Instance != null && GameManager.Instance.localEquipments != null)
			{
				localEquipments = GameManager.Instance.localEquipments;
			}
			if (localEquipments == null)
			{
				return;
			}
		}
		if (interactable == null)
		{
			Debug.LogWarning("T_PalletInteractable: Interactable component'i bulunamadı!");
			return;
		}
		switch (interactable.currentPrimaryState)
		{
		case PrimaryState.Pickup:
			if (TutorialManager.Instance != null && TutorialManager.Instance.IsTutorialRunning)
			{
				if (NotificationManager.Instance != null)
				{
					NotificationManager.Instance.ShowNotification(LocalizationManager.GetTranslation("Notification_NotAvailableDuringTutorial"));
				}
			}
			else
			{
				HandlePickup();
			}
			break;
		case PrimaryState.Place:
			HandlePlace();
			break;
		default:
			Debug.LogWarning($"T_PalletInteractable: Desteklenmeyen PrimaryState: {interactable.currentPrimaryState}");
			break;
		}
	}

	private void HandlePickup()
	{
		if (pallet.IsEmpty)
		{
			Debug.LogWarning("[PalletInteractable] Palet boş!");
			return;
		}
		if (localEquipments != null && localEquipments.pickupItem != null)
		{
			if (NotificationManager.Instance != null)
			{
				NotificationManager.Instance.ShowNotification(LocalizationManager.GetTranslation("Notification_NotPickupAvailable"));
			}
			return;
		}
		string paletItemId = pallet.PaletItemId;
		int paletItemCount = pallet.PaletItemCount;
		if (string.IsNullOrEmpty(paletItemId) || paletItemCount <= 0)
		{
			Debug.LogWarning("[PalletInteractable] Palette item yok!");
			return;
		}
		if (ItemSOManager.Instance == null)
		{
			Debug.LogError("[PalletInteractable] ItemSOManager.Instance null!");
			return;
		}
		T_ItemSO itemSOById = ItemSOManager.Instance.GetItemSOById(paletItemId);
		if (itemSOById == null)
		{
			Debug.LogWarning("[PalletInteractable] ItemSO bulunamadı! ItemId: " + paletItemId);
			return;
		}
		int num = paletItemCount;
		if (GameManager.Instance != null && GameManager.Instance.MaxItemsPerSack > 0)
		{
			num = Mathf.Min(num, GameManager.Instance.MaxItemsPerSack);
		}
		OpenPickerUIForPickup(itemSOById, num);
	}

	private void OpenPickerUIForPickup(T_ItemSO item, int availableCount)
	{
		if (GameManager.Instance == null || GameManager.Instance.UImanager == null)
		{
			Debug.LogWarning("[PalletInteractable] UIManager bulunamadı!");
			return;
		}
		PickerUI pickerUI = GameManager.Instance.UImanager.pickerUI;
		if (pickerUI == null)
		{
			Debug.LogWarning("[PalletInteractable] PickerUI bulunamadı!");
			return;
		}
		pickerUI.OpenUI(item, availableCount, OnPickerPickupRequested);
		Debug.Log($"[PalletInteractable] PickerUI açıldı (Pickup) - Item: {item.Name}, Available: {availableCount}");
	}

	private void OnPickerPickupRequested(T_ItemSO item, int quantity)
	{
		if (pallet == null || item == null || quantity <= 0)
		{
			Debug.LogWarning("[PalletInteractable] Pickup için gerekli referanslar eksik!");
			return;
		}
		if (!base.isServer)
		{
			CmdTakeItemsFromPallet(quantity);
		}
		else
		{
			ServerTakeItemsFromPallet(quantity);
		}
		Debug.Log($"[PalletInteractable] Pickup isteği gönderildi - Item: {item.Name}, Quantity: {quantity}");
	}

	[Command(requiresAuthority = false)]
	private void CmdTakeItemsFromPallet(int count, NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdTakeItemsFromPallet__Int32__NetworkConnectionToClient(count, sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(count);
		SendCommandInternal("System.Void T_PalletInteractable::CmdTakeItemsFromPallet(System.Int32,Mirror.NetworkConnectionToClient)", -906033003, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerTakeItemsFromPallet(int count, NetworkConnectionToClient sender = null)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_PalletInteractable::ServerTakeItemsFromPallet(System.Int32,Mirror.NetworkConnectionToClient)' called when server was not active");
		}
		else
		{
			if (pallet == null)
			{
				return;
			}
			string itemId;
			int num = pallet.ServerTakeItems(count, out itemId);
			if (num <= 0 || string.IsNullOrEmpty(itemId))
			{
				Debug.LogWarning("[PalletInteractable] Item alınamadı!");
				return;
			}
			Debug.Log($"[PalletInteractable] {num} adet item alındı - ItemId: {itemId}");
			if (ItemSOManager.Instance == null)
			{
				Debug.LogError("[PalletInteractable] ItemSOManager.Instance null!");
				return;
			}
			T_ItemSO itemSOById = ItemSOManager.Instance.GetItemSOById(itemId);
			if (itemSOById == null)
			{
				Debug.LogWarning("[PalletInteractable] ItemSO bulunamadı! ItemId: " + itemId);
				return;
			}
			if (sackPrefab == null)
			{
				Debug.LogError("[PalletInteractable] Sack prefab atanmamış!");
				return;
			}
			Vector3 position = base.transform.position + Vector3.up;
			if (sender != null && sender.identity != null)
			{
				position = sender.identity.transform.position + sender.identity.transform.forward * 1f + Vector3.up * 0.5f;
			}
			GameObject gameObject = Object.Instantiate(sackPrefab, position, Quaternion.identity);
			T_Sack component = gameObject.GetComponent<T_Sack>();
			if (component != null)
			{
				component.SetAsAutoPickupSack();
				NetworkServer.Spawn(gameObject);
				int num2 = Mathf.Min(num, T_Sack.MaxItemsPerSack);
				List<T_ItemSO> list = new List<T_ItemSO>();
				for (int i = 0; i < num2; i++)
				{
					list.Add(itemSOById);
				}
				component.ServerSetItems(list);
				NetworkConnectionToClient networkConnectionToClient = sender ?? NetworkServer.localConnection;
				if (networkConnectionToClient != null && networkConnectionToClient.identity != null)
				{
					uint sackNetId = gameObject.GetComponent<NetworkIdentity>().netId;
					GamePlayer component2 = networkConnectionToClient.identity.GetComponent<GamePlayer>();
					if (component2 != null)
					{
						component2.TargetRpcPickupSpawnedSack(networkConnectionToClient, sackNetId);
					}
				}
				Debug.Log($"[PalletInteractable] Sack oluşturuldu - {num} adet {itemId}");
			}
			else
			{
				Debug.LogError("[PalletInteractable] Sack prefab'inde T_Sack component'i bulunamadı!");
				Object.Destroy(gameObject);
			}
		}
	}

	private void HandlePlace()
	{
		if (localEquipments == null || localEquipments.pickupItem == null)
		{
			return;
		}
		T_Sack component = localEquipments.pickupItem.GetComponent<T_Sack>();
		if (component == null)
		{
			return;
		}
		Dictionary<string, int> storedItemCounts = component.GetStoredItemCounts();
		if (storedItemCounts.Count == 0)
		{
			Debug.LogWarning("[PalletInteractable] Sack boş!");
			return;
		}
		string text = null;
		int num = 0;
		string paletItemId = pallet.PaletItemId;
		bool isEmpty = pallet.IsEmpty;
		foreach (KeyValuePair<string, int> item in storedItemCounts)
		{
			if (isEmpty || item.Key == paletItemId)
			{
				text = item.Key;
				num = item.Value;
				break;
			}
		}
		if (string.IsNullOrEmpty(text) || num <= 0)
		{
			Debug.LogWarning("[PalletInteractable] Palete eklenebilecek item yok!");
			return;
		}
		if (ItemSOManager.Instance == null)
		{
			Debug.LogError("[PalletInteractable] ItemSOManager.Instance null!");
			return;
		}
		T_ItemSO itemSOById = ItemSOManager.Instance.GetItemSOById(text);
		if (itemSOById == null)
		{
			Debug.LogWarning("[PalletInteractable] ItemSO bulunamadı! ItemId: " + text);
			return;
		}
		int b = pallet.GetMaxItemCountForItem(itemSOById) - pallet.PaletItemCount;
		int num2 = Mathf.Min(num, b);
		if (num2 <= 0)
		{
			Debug.LogWarning("[PalletInteractable] Palet dolu!");
			return;
		}
		currentSack = component;
		OpenPickerUIForPlace(itemSOById, num2);
	}

	private void OpenPickerUIForPlace(T_ItemSO item, int maxAddable)
	{
		if (GameManager.Instance == null || GameManager.Instance.UImanager == null)
		{
			Debug.LogWarning("[PalletInteractable] UIManager bulunamadı!");
			return;
		}
		PickerUI pickerUI = GameManager.Instance.UImanager.pickerUI;
		if (pickerUI == null)
		{
			Debug.LogWarning("[PalletInteractable] PickerUI bulunamadı!");
			return;
		}
		pickerUI.OpenUI(item, maxAddable, OnPickerPlaceRequested);
		Debug.Log($"[PalletInteractable] PickerUI açıldı (Place) - Item: {item.Name}, MaxAddable: {maxAddable}");
	}

	private void OnPickerPlaceRequested(T_ItemSO item, int quantity)
	{
		if (pallet == null || currentSack == null || item == null || quantity <= 0)
		{
			Debug.LogWarning("[PalletInteractable] Place için gerekli referanslar eksik!");
			currentSack = null;
			return;
		}
		if (!base.isServer)
		{
			CmdAddPartialItemsFromSack(currentSack.netId, item.GetItemID(), quantity);
		}
		else
		{
			ServerAddPartialItemsFromSack(currentSack.netId, item.GetItemID(), quantity, NetworkServer.localConnection);
		}
		Debug.Log($"[PalletInteractable] Place isteği gönderildi - Item: {item.Name}, Quantity: {quantity}");
		currentSack = null;
	}

	[Command(requiresAuthority = false)]
	private void CmdAddPartialItemsFromSack(uint sackNetId, string itemId, int count, NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdAddPartialItemsFromSack__UInt32__String__Int32__NetworkConnectionToClient(sackNetId, itemId, count, sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarUInt(sackNetId);
		writer.WriteString(itemId);
		writer.WriteVarInt(count);
		SendCommandInternal("System.Void T_PalletInteractable::CmdAddPartialItemsFromSack(System.UInt32,System.String,System.Int32,Mirror.NetworkConnectionToClient)", -1503321522, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerAddPartialItemsFromSack(uint sackNetId, string itemId, int count, NetworkConnectionToClient sender)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_PalletInteractable::ServerAddPartialItemsFromSack(System.UInt32,System.String,System.Int32,Mirror.NetworkConnectionToClient)' called when server was not active");
			return;
		}
		if (sackNetId == 0 || string.IsNullOrEmpty(itemId) || count <= 0)
		{
			Debug.LogWarning("[PalletInteractable] ServerAddPartialItemsFromSack - Geçersiz parametreler!");
			return;
		}
		if (!NetworkServer.spawned.TryGetValue(sackNetId, out var value))
		{
			Debug.LogWarning($"[PalletInteractable] ServerAddPartialItemsFromSack - Sack NetId ({sackNetId}) bulunamadı!");
			return;
		}
		T_Sack component = value.GetComponent<T_Sack>();
		if (component == null)
		{
			Debug.LogWarning("[PalletInteractable] ServerAddPartialItemsFromSack - Bulunan obje T_Sack değil!");
			return;
		}
		Dictionary<string, int> storedItemCounts = component.GetStoredItemCounts();
		int num = (storedItemCounts.ContainsKey(itemId) ? storedItemCounts[itemId] : 0);
		if (num <= 0)
		{
			Debug.LogWarning("[PalletInteractable] Sack'te " + itemId + " yok!");
			return;
		}
		int requestedCount = Mathf.Min(count, num);
		int num2 = pallet.ServerAddPartialItemFromSack(itemId, requestedCount);
		if (num2 <= 0)
		{
			Debug.LogWarning("[PalletInteractable] Palete item eklenemedi!");
			return;
		}
		Dictionary<string, int> itemsToRemove = new Dictionary<string, int> { { itemId, num2 } };
		component.ServerRemoveItems(itemsToRemove);
		Debug.Log($"[PalletInteractable] {num2} adet {itemId} palete eklendi");
		if (component.ItemCount <= 0)
		{
			Debug.Log("[PalletInteractable] Sack boşaldı, destroy ediliyor");
			if (sender != null)
			{
				RpcClearPlayerPickupItem(sender);
			}
			NetworkServer.Destroy(component.gameObject);
		}
	}

	[TargetRpc]
	private void RpcClearPlayerPickupItem(NetworkConnection target)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendTargetRPCInternal(target, "System.Void T_PalletInteractable::RpcClearPlayerPickupItem(Mirror.NetworkConnection)", 705224213, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdTakeItemFromPallet(NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdTakeItemFromPallet__NetworkConnectionToClient(sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void T_PalletInteractable::CmdTakeItemFromPallet(Mirror.NetworkConnectionToClient)", -1649331751, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerTakeItemFromPallet()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_PalletInteractable::ServerTakeItemFromPallet()' called when server was not active");
		}
		else
		{
			if (pallet == null || !pallet.ServerTakeItem(out var itemId))
			{
				return;
			}
			if (ItemSOManager.Instance == null)
			{
				Debug.LogError("[PaletInteractable] ItemSOManager.Instance null!");
				return;
			}
			T_ItemSO itemSOById = ItemSOManager.Instance.GetItemSOById(itemId);
			if (itemSOById == null)
			{
				Debug.LogWarning("[PaletInteractable] ItemSO bulunamadı! ItemId: " + itemId);
			}
			else if (GameManager.Instance != null && GameManager.Instance.localBag != null)
			{
				GameManager.Instance.localBag.AddItem(itemSOById);
				Debug.Log("[PaletInteractable] Item alındı ve bag'e eklendi - ItemId: " + itemId);
			}
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdAddItemsFromSack(uint sackNetId, NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdAddItemsFromSack__UInt32__NetworkConnectionToClient(sackNetId, sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarUInt(sackNetId);
		SendCommandInternal("System.Void T_PalletInteractable::CmdAddItemsFromSack(System.UInt32,Mirror.NetworkConnectionToClient)", 394482104, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerAddItemsFromSack(uint sackNetId, NetworkConnectionToClient sender)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_PalletInteractable::ServerAddItemsFromSack(System.UInt32,Mirror.NetworkConnectionToClient)' called when server was not active");
			return;
		}
		if (sackNetId == 0)
		{
			Debug.LogWarning("[PaletInteractable] ServerAddItemsFromSack - Sack NetId geçersiz!");
			return;
		}
		if (!NetworkServer.spawned.TryGetValue(sackNetId, out var value))
		{
			Debug.LogWarning($"[PaletInteractable] ServerAddItemsFromSack - Sack NetId ({sackNetId}) bulunamadı!");
			return;
		}
		T_Sack component = value.GetComponent<T_Sack>();
		if (component == null)
		{
			Debug.LogWarning("[PaletInteractable] ServerAddItemsFromSack - Bulunan obje T_Sack değil!");
			return;
		}
		Dictionary<string, int> storedItemCounts = component.GetStoredItemCounts();
		if (storedItemCounts.Count == 0)
		{
			Debug.LogWarning("[PaletInteractable] Sack boş!");
			return;
		}
		string paletItemId = pallet.PaletItemId;
		bool isEmpty = pallet.IsEmpty;
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		Dictionary<string, int> dictionary2 = new Dictionary<string, int>();
		foreach (KeyValuePair<string, int> item in storedItemCounts)
		{
			if (isEmpty || item.Key == paletItemId)
			{
				int num = pallet.GetMaxItemCountForItem(item.Key) - pallet.PaletItemCount;
				if (num > 0)
				{
					int value2 = Mathf.Min(item.Value, num);
					dictionary[item.Key] = value2;
					dictionary2[item.Key] = value2;
				}
			}
		}
		if (dictionary.Count == 0)
		{
			Debug.LogWarning("[PaletInteractable] Palete eklenebilecek item yok!");
			return;
		}
		foreach (KeyValuePair<string, int> item2 in dictionary)
		{
			pallet.ServerTryAddItemFromSack(item2.Key, item2.Value);
		}
		component.ServerRemoveItems(dictionary2);
		if (component.ItemCount <= 0)
		{
			Debug.Log("[PaletInteractable] Sack boşaldı, destroy ediliyor");
			if (sender != null)
			{
				RpcClearPlayerPickupItem(sender);
			}
			NetworkServer.Destroy(component.gameObject);
		}
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdTakeItemsFromPallet__Int32__NetworkConnectionToClient(int count, NetworkConnectionToClient sender)
	{
		ServerTakeItemsFromPallet(count, sender);
	}

	protected static void InvokeUserCode_CmdTakeItemsFromPallet__Int32__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdTakeItemsFromPallet called on client.");
		}
		else
		{
			((T_PalletInteractable)obj).UserCode_CmdTakeItemsFromPallet__Int32__NetworkConnectionToClient(reader.ReadVarInt(), senderConnection);
		}
	}

	protected void UserCode_CmdAddPartialItemsFromSack__UInt32__String__Int32__NetworkConnectionToClient(uint sackNetId, string itemId, int count, NetworkConnectionToClient sender)
	{
		ServerAddPartialItemsFromSack(sackNetId, itemId, count, sender);
	}

	protected static void InvokeUserCode_CmdAddPartialItemsFromSack__UInt32__String__Int32__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdAddPartialItemsFromSack called on client.");
		}
		else
		{
			((T_PalletInteractable)obj).UserCode_CmdAddPartialItemsFromSack__UInt32__String__Int32__NetworkConnectionToClient(reader.ReadVarUInt(), reader.ReadString(), reader.ReadVarInt(), senderConnection);
		}
	}

	protected void UserCode_RpcClearPlayerPickupItem__NetworkConnection(NetworkConnection target)
	{
		if (GameManager.Instance != null && GameManager.Instance.localEquipments != null)
		{
			GameManager.Instance.localEquipments.ClearPickupItem();
			GameManager.Instance.localEquipments.TryUnequip();
			Debug.Log("[PalletInteractable] Player pickupItem temizlendi");
		}
	}

	protected static void InvokeUserCode_RpcClearPlayerPickupItem__NetworkConnection(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("TargetRPC RpcClearPlayerPickupItem called on server.");
		}
		else
		{
			((T_PalletInteractable)obj).UserCode_RpcClearPlayerPickupItem__NetworkConnection(null);
		}
	}

	protected void UserCode_CmdTakeItemFromPallet__NetworkConnectionToClient(NetworkConnectionToClient sender)
	{
		ServerTakeItemFromPallet();
	}

	protected static void InvokeUserCode_CmdTakeItemFromPallet__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdTakeItemFromPallet called on client.");
		}
		else
		{
			((T_PalletInteractable)obj).UserCode_CmdTakeItemFromPallet__NetworkConnectionToClient(senderConnection);
		}
	}

	protected void UserCode_CmdAddItemsFromSack__UInt32__NetworkConnectionToClient(uint sackNetId, NetworkConnectionToClient sender)
	{
		ServerAddItemsFromSack(sackNetId, sender);
	}

	protected static void InvokeUserCode_CmdAddItemsFromSack__UInt32__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdAddItemsFromSack called on client.");
		}
		else
		{
			((T_PalletInteractable)obj).UserCode_CmdAddItemsFromSack__UInt32__NetworkConnectionToClient(reader.ReadVarUInt(), senderConnection);
		}
	}

	static T_PalletInteractable()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(T_PalletInteractable), "System.Void T_PalletInteractable::CmdTakeItemsFromPallet(System.Int32,Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdTakeItemsFromPallet__Int32__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(T_PalletInteractable), "System.Void T_PalletInteractable::CmdAddPartialItemsFromSack(System.UInt32,System.String,System.Int32,Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdAddPartialItemsFromSack__UInt32__String__Int32__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(T_PalletInteractable), "System.Void T_PalletInteractable::CmdTakeItemFromPallet(Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdTakeItemFromPallet__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(T_PalletInteractable), "System.Void T_PalletInteractable::CmdAddItemsFromSack(System.UInt32,Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdAddItemsFromSack__UInt32__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(T_PalletInteractable), "System.Void T_PalletInteractable::RpcClearPlayerPickupItem(Mirror.NetworkConnection)", InvokeUserCode_RpcClearPlayerPickupItem__NetworkConnection);
	}
}
