using System;
using System.Collections.Generic;
using System.Linq;
using I2.Loc;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;
using UnityEngine.Events;

public class ComputerMarketplaceManager : NetworkBehaviour
{
	private BuildingManager _buildingManager;

	[Header("Events")]
	public UnityEvent<ShoppingCartItemData> onCartItemAdded;

	public UnityEvent<ShoppingCartItemData> onCartItemRemoved;

	public UnityEvent<ShoppingCartItemData> onCartItemUpdated;

	public UnityEvent onCartCleared;

	public UnityEvent<List<ShoppingCartItemData>> onPurchaseCompleted;

	[SerializeField]
	private SyncList<ShoppingCartItemData> _shoppingCart = new SyncList<ShoppingCartItemData>();

	[SerializeField]
	private List<ShoppingCartItemData> _shoppingCartListForEditor = new List<ShoppingCartItemData>();

	public static ComputerMarketplaceManager Instance { get; private set; }

	private BuildingManager buildingManager
	{
		get
		{
			if (_buildingManager == null)
			{
				_buildingManager = UnityEngine.Object.FindFirstObjectByType<BuildingManager>();
				if (_buildingManager == null)
				{
					Debug.LogError("[ComputerMarketplaceManager] Sahnede BuildingManager bulunamadı!");
				}
			}
			return _buildingManager;
		}
	}

	private IReadOnlyList<T_BuildingItemSO> marketplaceItemList => ScriptableListManager.Instance.AllBuildingItemSOs;

	public IReadOnlyList<T_BuildingItemSO> MarketplaceItemList => marketplaceItemList;

	public IReadOnlyList<ShoppingCartItemData> ShoppingCart => _shoppingCart;

	public List<ShoppingCartItemData> ShoppingCartListForEditor => _shoppingCartListForEditor;

	public int CartItemCount => _shoppingCart.Count;

	public int CartTotalPrice
	{
		get
		{
			int num = 0;
			foreach (ShoppingCartItemData item in _shoppingCart)
			{
				if (item.itemSOIndex >= 0 && item.itemSOIndex < marketplaceItemList.Count)
				{
					T_BuildingItemSO t_BuildingItemSO = marketplaceItemList[item.itemSOIndex];
					if (t_BuildingItemSO != null)
					{
						num += item.GetTotalPrice(t_BuildingItemSO);
					}
				}
			}
			return num;
		}
	}

	public bool IsCartEmpty => _shoppingCart.Count == 0;

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		Instance = this;
		SyncList<ShoppingCartItemData> shoppingCart = _shoppingCart;
		shoppingCart.Callback = (Action<SyncList<ShoppingCartItemData>.Operation, int, ShoppingCartItemData, ShoppingCartItemData>)Delegate.Combine(shoppingCart.Callback, new Action<SyncList<ShoppingCartItemData>.Operation, int, ShoppingCartItemData, ShoppingCartItemData>(OnShoppingCartChanged));
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
		SyncList<ShoppingCartItemData> shoppingCart = _shoppingCart;
		shoppingCart.Callback = (Action<SyncList<ShoppingCartItemData>.Operation, int, ShoppingCartItemData, ShoppingCartItemData>)Delegate.Remove(shoppingCart.Callback, new Action<SyncList<ShoppingCartItemData>.Operation, int, ShoppingCartItemData, ShoppingCartItemData>(OnShoppingCartChanged));
	}

	public void RequestAddToCart(int itemSOIndex)
	{
		if (marketplaceItemList.Count == 0)
		{
			Debug.LogWarning("[ComputerMarketplaceManager] marketplaceItemList boş! ScriptableListManager'da listeyi doldurmalısın.");
		}
		else if (base.isServer)
		{
			ServerAddToCart(itemSOIndex);
		}
		else if (base.isClient)
		{
			CmdAddToCart(itemSOIndex);
		}
	}

	public void RequestRemoveFromCart(int itemSOIndex)
	{
		if (base.isServer)
		{
			ServerRemoveFromCart(itemSOIndex);
		}
		else if (base.isClient)
		{
			CmdRemoveFromCart(itemSOIndex);
		}
	}

	public void RequestClearCart()
	{
		if (base.isServer)
		{
			ServerClearCart();
		}
		else if (base.isClient)
		{
			CmdClearShoppingCart();
		}
	}

	public void RequestPurchase()
	{
		if (base.isServer)
		{
			ServerPurchase();
		}
		else if (base.isClient)
		{
			CmdPurchase();
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdAddToCart(int itemSOIndex)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdAddToCart__Int32(itemSOIndex);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(itemSOIndex);
		SendCommandInternal("System.Void ComputerMarketplaceManager::CmdAddToCart(System.Int32)", 1354462861, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdRemoveFromCart(int itemSOIndex)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdRemoveFromCart__Int32(itemSOIndex);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(itemSOIndex);
		SendCommandInternal("System.Void ComputerMarketplaceManager::CmdRemoveFromCart(System.Int32)", -160078603, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdClearShoppingCart()
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdClearShoppingCart();
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void ComputerMarketplaceManager::CmdClearShoppingCart()", 577105419, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdPurchase()
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdPurchase();
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void ComputerMarketplaceManager::CmdPurchase()", -263379663, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerAddToCart(int itemSOIndex)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void ComputerMarketplaceManager::ServerAddToCart(System.Int32)' called when server was not active");
			return;
		}
		if (marketplaceItemList.Count == 0)
		{
			Debug.LogWarning("[ComputerMarketplaceManager] marketplaceItemList boş!");
			return;
		}
		if (itemSOIndex < 0 || itemSOIndex >= marketplaceItemList.Count)
		{
			Debug.LogWarning($"[ComputerMarketplaceManager] Geçersiz itemSOIndex: {itemSOIndex}");
			return;
		}
		T_BuildingItemSO t_BuildingItemSO = marketplaceItemList[itemSOIndex];
		if (t_BuildingItemSO == null || !t_BuildingItemSO.canBeSoldInMarket)
		{
			Debug.LogWarning($"[ComputerMarketplaceManager] Item markette satılabilir değil: {itemSOIndex}");
			return;
		}
		int num = -1;
		for (int i = 0; i < _shoppingCart.Count; i++)
		{
			if (_shoppingCart[i].itemSOIndex == itemSOIndex)
			{
				num = i;
				break;
			}
		}
		if (num >= 0)
		{
			ShoppingCartItemData value = _shoppingCart[num];
			value.quantity++;
			_shoppingCart[num] = value;
		}
		else
		{
			ShoppingCartItemData item = new ShoppingCartItemData
			{
				itemSOIndex = itemSOIndex,
				quantity = 1
			};
			_shoppingCart.Add(item);
		}
		Debug.Log($"[ComputerMarketplaceManager] Sepete eklendi: {t_BuildingItemSO.Name} (Index: {itemSOIndex})");
	}

	[Server]
	private void ServerRemoveFromCart(int itemSOIndex)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void ComputerMarketplaceManager::ServerRemoveFromCart(System.Int32)' called when server was not active");
			return;
		}
		int num = -1;
		for (int i = 0; i < _shoppingCart.Count; i++)
		{
			if (_shoppingCart[i].itemSOIndex == itemSOIndex)
			{
				num = i;
				break;
			}
		}
		if (num < 0)
		{
			Debug.LogWarning($"[ComputerMarketplaceManager] Sepette item bulunamadı: {itemSOIndex}");
			return;
		}
		ShoppingCartItemData value = _shoppingCart[num];
		value.quantity--;
		if (value.quantity <= 0)
		{
			_shoppingCart.RemoveAt(num);
		}
		else
		{
			_shoppingCart[num] = value;
		}
		Debug.Log($"[ComputerMarketplaceManager] Sepetten çıkarıldı: Index {itemSOIndex}");
	}

	[Server]
	private void ServerClearCart()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void ComputerMarketplaceManager::ServerClearCart()' called when server was not active");
			return;
		}
		_shoppingCart.Clear();
		Debug.Log("[ComputerMarketplaceManager] Sepet temizlendi");
		RpcShowCartClearedNotification();
	}

	[Server]
	private void ServerPurchase()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void ComputerMarketplaceManager::ServerPurchase()' called when server was not active");
			return;
		}
		if (_shoppingCart.Count == 0)
		{
			Debug.LogWarning("[ComputerMarketplaceManager] Sepet boş, satın alma yapılamaz!");
			return;
		}
		int num = 0;
		List<ShoppingCartItemData> list = new List<ShoppingCartItemData>();
		foreach (ShoppingCartItemData item in _shoppingCart)
		{
			if (item.itemSOIndex >= 0 && item.itemSOIndex < marketplaceItemList.Count)
			{
				T_BuildingItemSO t_BuildingItemSO = marketplaceItemList[item.itemSOIndex];
				if (t_BuildingItemSO != null)
				{
					num += item.GetTotalPrice(t_BuildingItemSO);
					list.Add(item);
				}
			}
		}
		if (FactoryManager.Instance != null)
		{
			if (!FactoryManager.Instance.TryPurchase(num, EconomyType.EconomyType_Purchase))
			{
				Debug.LogWarning($"[ComputerMarketplaceManager] Yetersiz bakiye! Gerekli: ${num:N0}");
				NotificationManager.Instance?.ShowNotification(LocalizationManager.GetTranslation("Notification_InsufficientBalance"), isComputer: true);
				return;
			}
			Debug.Log($"[ComputerMarketplaceManager] Satın alma tamamlandı: ${num:N0}");
		}
		List<ShoppingCartItemData> list2 = new List<ShoppingCartItemData>(list);
		ServerSpawnPurchasedBuildingBoxes(list);
		_shoppingCart.Clear();
		RpcShowOrderPlacedNotification();
		if (NetworkServer.active && NetworkClient.isConnected)
		{
			onPurchaseCompleted?.Invoke(list2);
		}
		RpcOnPurchaseCompleted(list2);
	}

	[Server]
	private void ServerSpawnPurchasedBuildingBoxes(List<ShoppingCartItemData> purchaseItems)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void ComputerMarketplaceManager::ServerSpawnPurchasedBuildingBoxes(System.Collections.Generic.List`1<ShoppingCartItemData>)' called when server was not active");
			return;
		}
		if (buildingManager == null || buildingManager.buildingBoxPrefab == null)
		{
			Debug.LogWarning("[ComputerMarketplaceManager] BuildingManager veya buildingBoxPrefab atanmamış! Building box spawn edilemiyor.");
			return;
		}
		if (CargoAreaManager.Instance == null)
		{
			Debug.LogWarning("[ComputerMarketplaceManager] CargoAreaManager bulunamadı! Building box spawn edilemiyor.");
			return;
		}
		int num = 0;
		foreach (ShoppingCartItemData purchaseItem in purchaseItems)
		{
			T_BuildingItemSO itemSO = GetItemSO(purchaseItem.itemSOIndex);
			if (itemSO == null)
			{
				Debug.LogWarning($"[ComputerMarketplaceManager] ItemSO bulunamadı: Index {purchaseItem.itemSOIndex}");
				continue;
			}
			for (int i = 0; i < purchaseItem.quantity; i++)
			{
				Vector3 spawnPosition = CargoAreaManager.Instance.GetSpawnPosition(num);
				GameObject gameObject = UnityEngine.Object.Instantiate(buildingManager.buildingBoxPrefab, spawnPosition, Quaternion.identity);
				if (gameObject == null)
				{
					Debug.LogError("[ComputerMarketplaceManager] Building box Instantiate başarısız!");
					continue;
				}
				if (gameObject.GetComponent<NetworkIdentity>() == null)
				{
					Debug.LogError("[ComputerMarketplaceManager] Building box prefab'ında NetworkIdentity yok!");
					UnityEngine.Object.Destroy(gameObject);
					continue;
				}
				NetworkServer.Spawn(gameObject);
				T_Building component = gameObject.GetComponent<T_Building>();
				if (component != null)
				{
					int itemSOIndex = purchaseItem.itemSOIndex;
					if (itemSOIndex >= 0)
					{
						component.SetBuildingItemSO(itemSO);
						component.SetBuildingItemSOIndex(itemSOIndex);
						RpcSetPurchasedBuildingItemSO(gameObject, itemSOIndex);
						Debug.Log($"[ComputerMarketplaceManager] Building box spawn edildi: {itemSO.Name}, Pozisyon: {spawnPosition}");
					}
					else
					{
						Debug.LogWarning("[ComputerMarketplaceManager] ItemSO BuildingManager listesinde bulunamadı: " + itemSO.Name);
					}
				}
				num++;
			}
		}
		Debug.Log($"[ComputerMarketplaceManager] Toplam {num} building box cargo area'ya spawn edildi.");
	}

	[ClientRpc]
	private void RpcOnPurchaseCompleted(List<ShoppingCartItemData> orderSummary)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		GeneratedNetworkCode._Write_System_002ECollections_002EGeneric_002EList_00601_003CShoppingCartItemData_003E(writer, orderSummary);
		SendRPCInternal("System.Void ComputerMarketplaceManager::RpcOnPurchaseCompleted(System.Collections.Generic.List`1<ShoppingCartItemData>)", 1148897117, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcShowOrderPlacedNotification()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void ComputerMarketplaceManager::RpcShowOrderPlacedNotification()", 1394542628, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcShowCartClearedNotification()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void ComputerMarketplaceManager::RpcShowCartClearedNotification()", 1329042823, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcSetPurchasedBuildingItemSO(GameObject buildingBoxInstance, int soIndex)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteGameObject(buildingBoxInstance);
		writer.WriteVarInt(soIndex);
		SendRPCInternal("System.Void ComputerMarketplaceManager::RpcSetPurchasedBuildingItemSO(UnityEngine.GameObject,System.Int32)", 782285054, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void OnShoppingCartChanged(SyncList<ShoppingCartItemData>.Operation op, int itemIndex, ShoppingCartItemData oldItem, ShoppingCartItemData newItem)
	{
		Debug.Log($"[ComputerMarketplaceManager] OnShoppingCartChanged - Operation: {op}, ItemIndex: {itemIndex}, OldQuantity: {oldItem.quantity}, NewQuantity: {newItem.quantity}");
		UpdateEditorList();
		switch (op)
		{
		case SyncList<ShoppingCartItemData>.Operation.OP_ADD:
			Debug.Log($"[ComputerMarketplaceManager] OP_ADD - ItemIndex: {newItem.itemSOIndex}, Quantity: {newItem.quantity}");
			onCartItemAdded?.Invoke(newItem);
			break;
		case SyncList<ShoppingCartItemData>.Operation.OP_REMOVEAT:
			Debug.Log($"[ComputerMarketplaceManager] OP_REMOVEAT - ItemIndex: {oldItem.itemSOIndex}");
			onCartItemRemoved?.Invoke(oldItem);
			break;
		case SyncList<ShoppingCartItemData>.Operation.OP_CLEAR:
			Debug.Log("[ComputerMarketplaceManager] OP_CLEAR");
			onCartCleared?.Invoke();
			break;
		case SyncList<ShoppingCartItemData>.Operation.OP_SET:
			Debug.Log($"[ComputerMarketplaceManager] OP_SET - ItemIndex: {newItem.itemSOIndex}, OldQuantity: {oldItem.quantity}, NewQuantity: {newItem.quantity}");
			onCartItemUpdated?.Invoke(newItem);
			break;
		case SyncList<ShoppingCartItemData>.Operation.OP_INSERT:
			break;
		}
	}

	private void UpdateEditorList()
	{
		_shoppingCartListForEditor.Clear();
		foreach (ShoppingCartItemData item in _shoppingCart)
		{
			_shoppingCartListForEditor.Add(item);
		}
	}

	public bool IsItemInCart(int itemSOIndex)
	{
		return _shoppingCart.Any((ShoppingCartItemData item) => item.itemSOIndex == itemSOIndex);
	}

	public int GetItemQuantity(int itemSOIndex)
	{
		ShoppingCartItemData shoppingCartItemData = _shoppingCart.FirstOrDefault((ShoppingCartItemData i) => i.itemSOIndex == itemSOIndex);
		if (!shoppingCartItemData.IsValid)
		{
			return 0;
		}
		return shoppingCartItemData.quantity;
	}

	public int GetItemIndex(T_BuildingItemSO itemSO)
	{
		for (int i = 0; i < marketplaceItemList.Count; i++)
		{
			if (marketplaceItemList[i] == itemSO)
			{
				return i;
			}
		}
		return -1;
	}

	public T_BuildingItemSO GetItemSO(int index)
	{
		if (index < 0 || index >= marketplaceItemList.Count)
		{
			return null;
		}
		return marketplaceItemList[index];
	}

	public ComputerMarketplaceManager()
	{
		InitSyncObject(_shoppingCart);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdAddToCart__Int32(int itemSOIndex)
	{
		ServerAddToCart(itemSOIndex);
	}

	protected static void InvokeUserCode_CmdAddToCart__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdAddToCart called on client.");
		}
		else
		{
			((ComputerMarketplaceManager)obj).UserCode_CmdAddToCart__Int32(reader.ReadVarInt());
		}
	}

	protected void UserCode_CmdRemoveFromCart__Int32(int itemSOIndex)
	{
		ServerRemoveFromCart(itemSOIndex);
	}

	protected static void InvokeUserCode_CmdRemoveFromCart__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdRemoveFromCart called on client.");
		}
		else
		{
			((ComputerMarketplaceManager)obj).UserCode_CmdRemoveFromCart__Int32(reader.ReadVarInt());
		}
	}

	protected void UserCode_CmdClearShoppingCart()
	{
		ServerClearCart();
	}

	protected static void InvokeUserCode_CmdClearShoppingCart(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdClearShoppingCart called on client.");
		}
		else
		{
			((ComputerMarketplaceManager)obj).UserCode_CmdClearShoppingCart();
		}
	}

	protected void UserCode_CmdPurchase()
	{
		ServerPurchase();
	}

	protected static void InvokeUserCode_CmdPurchase(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdPurchase called on client.");
		}
		else
		{
			((ComputerMarketplaceManager)obj).UserCode_CmdPurchase();
		}
	}

	protected void UserCode_RpcOnPurchaseCompleted__List_00601(List<ShoppingCartItemData> orderSummary)
	{
		if (!NetworkServer.active)
		{
			onPurchaseCompleted?.Invoke(orderSummary);
		}
	}

	protected static void InvokeUserCode_RpcOnPurchaseCompleted__List_00601(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcOnPurchaseCompleted called on server.");
		}
		else
		{
			((ComputerMarketplaceManager)obj).UserCode_RpcOnPurchaseCompleted__List_00601(GeneratedNetworkCode._Read_System_002ECollections_002EGeneric_002EList_00601_003CShoppingCartItemData_003E(reader));
		}
	}

	protected void UserCode_RpcShowOrderPlacedNotification()
	{
	}

	protected static void InvokeUserCode_RpcShowOrderPlacedNotification(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcShowOrderPlacedNotification called on server.");
		}
		else
		{
			((ComputerMarketplaceManager)obj).UserCode_RpcShowOrderPlacedNotification();
		}
	}

	protected void UserCode_RpcShowCartClearedNotification()
	{
	}

	protected static void InvokeUserCode_RpcShowCartClearedNotification(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcShowCartClearedNotification called on server.");
		}
		else
		{
			((ComputerMarketplaceManager)obj).UserCode_RpcShowCartClearedNotification();
		}
	}

	protected void UserCode_RpcSetPurchasedBuildingItemSO__GameObject__Int32(GameObject buildingBoxInstance, int soIndex)
	{
		if (buildingBoxInstance == null)
		{
			Debug.LogWarning("[ComputerMarketplaceManager] RpcSetPurchasedBuildingItemSO: buildingBoxInstance null!");
			return;
		}
		if (soIndex < 0 || soIndex >= marketplaceItemList.Count)
		{
			Debug.LogWarning($"[ComputerMarketplaceManager] RpcSetPurchasedBuildingItemSO: Geçersiz SO index! Index: {soIndex}");
			return;
		}
		T_BuildingItemSO t_BuildingItemSO = marketplaceItemList[soIndex];
		if (t_BuildingItemSO == null)
		{
			Debug.LogWarning($"[ComputerMarketplaceManager] RpcSetPurchasedBuildingItemSO: Seçilen SO null! Index: {soIndex}");
			return;
		}
		T_Building component = buildingBoxInstance.GetComponent<T_Building>();
		if (component != null)
		{
			component.SetBuildingItemSO(t_BuildingItemSO);
			component.SetIcon(t_BuildingItemSO.Icon);
			Debug.Log("[ComputerMarketplaceManager] RpcSetPurchasedBuildingItemSO: BuildingItemSO set edildi: " + t_BuildingItemSO.Name);
		}
	}

	protected static void InvokeUserCode_RpcSetPurchasedBuildingItemSO__GameObject__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcSetPurchasedBuildingItemSO called on server.");
		}
		else
		{
			((ComputerMarketplaceManager)obj).UserCode_RpcSetPurchasedBuildingItemSO__GameObject__Int32(reader.ReadGameObject(), reader.ReadVarInt());
		}
	}

	static ComputerMarketplaceManager()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(ComputerMarketplaceManager), "System.Void ComputerMarketplaceManager::CmdAddToCart(System.Int32)", InvokeUserCode_CmdAddToCart__Int32, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ComputerMarketplaceManager), "System.Void ComputerMarketplaceManager::CmdRemoveFromCart(System.Int32)", InvokeUserCode_CmdRemoveFromCart__Int32, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ComputerMarketplaceManager), "System.Void ComputerMarketplaceManager::CmdClearShoppingCart()", InvokeUserCode_CmdClearShoppingCart, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ComputerMarketplaceManager), "System.Void ComputerMarketplaceManager::CmdPurchase()", InvokeUserCode_CmdPurchase, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(ComputerMarketplaceManager), "System.Void ComputerMarketplaceManager::RpcOnPurchaseCompleted(System.Collections.Generic.List`1<ShoppingCartItemData>)", InvokeUserCode_RpcOnPurchaseCompleted__List_00601);
		RemoteProcedureCalls.RegisterRpc(typeof(ComputerMarketplaceManager), "System.Void ComputerMarketplaceManager::RpcShowOrderPlacedNotification()", InvokeUserCode_RpcShowOrderPlacedNotification);
		RemoteProcedureCalls.RegisterRpc(typeof(ComputerMarketplaceManager), "System.Void ComputerMarketplaceManager::RpcShowCartClearedNotification()", InvokeUserCode_RpcShowCartClearedNotification);
		RemoteProcedureCalls.RegisterRpc(typeof(ComputerMarketplaceManager), "System.Void ComputerMarketplaceManager::RpcSetPurchasedBuildingItemSO(UnityEngine.GameObject,System.Int32)", InvokeUserCode_RpcSetPurchasedBuildingItemSO__GameObject__Int32);
	}
}
