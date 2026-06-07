using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Enviro;
using I2.Loc;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;
using UnityEngine.Events;

public class ComputerStockSellManager : NetworkBehaviour
{
	[Header("Demand Generation Settings")]
	[Tooltip("Bir item için oluşturulacak minimum talep sayısı")]
	[Min(1f)]
	[SerializeField]
	private int minDemandsPerItem = 3;

	[Tooltip("Bir item için oluşturulacak maximum talep sayısı")]
	[Min(1f)]
	[SerializeField]
	private int maxDemandsPerItem = 3;

	[Tooltip("Talep edilen minimum adet")]
	[Min(1f)]
	[SerializeField]
	private int minDemandAmount = 5;

	[Tooltip("Talep edilen maximum adet")]
	[Min(1f)]
	[SerializeField]
	private int maxDemandAmount = 20;

	[Header("Price Settings")]
	[Tooltip("Item base price'ına uygulanacak minimum çarpan (0.8 = %80)")]
	[Range(0.5f, 1f)]
	[SerializeField]
	private float priceMultiplierMin = 0.8f;

	[Tooltip("Item base price'ına uygulanacak maximum çarpan (1.2 = %120)")]
	[Range(1f, 2f)]
	[SerializeField]
	private float priceMultiplierMax = 1.2f;

	[Tooltip("Fiyat yuvarlama değeri")]
	[Min(1f)]
	[SerializeField]
	private int priceRoundingStep = 10;

	[Header("Events")]
	public UnityEvent<string> onDemandsGenerated;

	public UnityEvent<string> onDemandsCleared;

	public UnityEvent<StockDemandData> onDemandAccepted;

	public UnityEvent<StockDemandData> onSaleCompleted;

	public UnityEvent onWarehouseUpdated;

	public UnityEvent onDemandsListChanged;

	private readonly SyncList<StockDemandData> _activeDemands = new SyncList<StockDemandData>();

	private readonly SyncList<string> _itemsWithGeneratedDemands = new SyncList<string>();

	[SyncVar(hook = "OnSelectedItemChanged")]
	private string _selectedItemId;

	public Action<string, string> _Mirror_SyncVarHookDelegate__selectedItemId;

	public static ComputerStockSellManager Instance { get; private set; }

	private IReadOnlyList<T_ItemSO> allItemSOs => ScriptableListManager.Instance.AllItemSOs;

	private IReadOnlyList<CompanySO> allCompanies => ScriptableListManager.Instance.AllCompanies;

	public IReadOnlyList<StockDemandData> ActiveDemands => _activeDemands;

	public string SelectedItemId => _selectedItemId;

	public bool HasDemandsForSelectedItem
	{
		get
		{
			if (!string.IsNullOrEmpty(_selectedItemId))
			{
				return _activeDemands.Any((StockDemandData d) => d.itemId == _selectedItemId);
			}
			return false;
		}
	}

	public IReadOnlyList<T_ItemSO> AllItems => allItemSOs;

	public IReadOnlyList<CompanySO> AllCompanies => allCompanies;

	public string Network_selectedItemId
	{
		get
		{
			return _selectedItemId;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _selectedItemId, 1uL, _Mirror_SyncVarHookDelegate__selectedItemId);
		}
	}

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		Instance = this;
		if (onDemandsGenerated == null)
		{
			onDemandsGenerated = new UnityEvent<string>();
		}
		if (onDemandsCleared == null)
		{
			onDemandsCleared = new UnityEvent<string>();
		}
		if (onDemandAccepted == null)
		{
			onDemandAccepted = new UnityEvent<StockDemandData>();
		}
		if (onSaleCompleted == null)
		{
			onSaleCompleted = new UnityEvent<StockDemandData>();
		}
		if (onWarehouseUpdated == null)
		{
			onWarehouseUpdated = new UnityEvent();
		}
		if (onDemandsListChanged == null)
		{
			onDemandsListChanged = new UnityEvent();
		}
		SyncList<StockDemandData> activeDemands = _activeDemands;
		activeDemands.Callback = (Action<SyncList<StockDemandData>.Operation, int, StockDemandData, StockDemandData>)Delegate.Combine(activeDemands.Callback, new Action<SyncList<StockDemandData>.Operation, int, StockDemandData, StockDemandData>(OnActiveDemandsChanged));
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
		SyncList<StockDemandData> activeDemands = _activeDemands;
		activeDemands.Callback = (Action<SyncList<StockDemandData>.Operation, int, StockDemandData, StockDemandData>)Delegate.Remove(activeDemands.Callback, new Action<SyncList<StockDemandData>.Operation, int, StockDemandData, StockDemandData>(OnActiveDemandsChanged));
	}

	public override void OnStartServer()
	{
		base.OnStartServer();
		if (DayNightManager.Instance != null)
		{
			DayNightManager.Instance.OnDayStarted += OnDayStarted;
		}
		if (MarketPriceManager.Instance != null)
		{
			MarketPriceManager.Instance.OnMarketPricesChanged += ServerUpdateExistingDemandPrices;
		}
		Debug.Log("[ComputerStockSellManager] Server started.");
	}

	public override void OnStopServer()
	{
		base.OnStopServer();
		if (DayNightManager.Instance != null)
		{
			DayNightManager.Instance.OnDayStarted -= OnDayStarted;
		}
		if (MarketPriceManager.Instance != null)
		{
			MarketPriceManager.Instance.OnMarketPricesChanged -= ServerUpdateExistingDemandPrices;
		}
	}

	private void OnDayStarted()
	{
		if (base.isServer)
		{
			_activeDemands.Clear();
			_itemsWithGeneratedDemands.Clear();
			Network_selectedItemId = string.Empty;
			Debug.Log("[ComputerStockSellManager] Yeni gun - tum teklifler sifirlandi.");
		}
	}

	public override void OnStartClient()
	{
		base.OnStartClient();
		Debug.Log($"[ComputerStockSellManager] Client started. Active demands: {_activeDemands.Count}");
	}

	public void RequestSelectItem(string itemId)
	{
		if (string.IsNullOrEmpty(itemId))
		{
			Debug.LogWarning("[ComputerStockSellManager] ItemId boş!");
		}
		else if (base.isServer)
		{
			ServerSelectItem(itemId);
		}
		else
		{
			CmdRequestSelectItem(itemId);
		}
	}

	public void RequestSelectItem(T_ItemSO item)
	{
		if (item == null)
		{
			Debug.LogWarning("[ComputerStockSellManager] Item null!");
		}
		else
		{
			RequestSelectItem(item.GetItemID());
		}
	}

	public void RequestClearSelection()
	{
		if (base.isServer)
		{
			ServerClearSelection();
		}
		else
		{
			CmdRequestClearSelection();
		}
	}

	public void RequestRefreshDemands()
	{
		if (string.IsNullOrEmpty(_selectedItemId))
		{
			Debug.LogWarning("[ComputerStockSellManager] Seçili item yok!");
		}
		else if (base.isServer)
		{
			ServerGenerateDemandsForItem(_selectedItemId);
		}
		else
		{
			CmdRequestRefreshDemands();
		}
	}

	public void RequestAcceptDemand(string demandId)
	{
		if (string.IsNullOrEmpty(demandId))
		{
			Debug.LogWarning("[ComputerStockSellManager] DemandId boş!");
		}
		else if (base.isServer)
		{
			ServerAcceptDemand(demandId);
		}
		else
		{
			CmdRequestAcceptDemand(demandId);
		}
	}

	public void RequestAcceptPartialDemand(string demandId, int quantity)
	{
		if (string.IsNullOrEmpty(demandId) || quantity <= 0)
		{
			Debug.LogWarning("[ComputerStockSellManager] DemandId boş veya quantity geçersiz!");
		}
		else if (base.isServer)
		{
			ServerAcceptPartialDemand(demandId, quantity);
		}
		else
		{
			CmdRequestAcceptPartialDemand(demandId, quantity);
		}
	}

	public List<WarehouseItemInfo> GetWarehouseItems()
	{
		if (T_Warehouse.Instance == null)
		{
			Debug.LogWarning("[ComputerStockSellManager] T_Warehouse.Instance null!");
			return new List<WarehouseItemInfo>();
		}
		List<WarehouseItemInfo> allWarehouseItems = T_Warehouse.Instance.GetAllWarehouseItems();
		Debug.Log($"[ComputerStockSellManager] GetWarehouseItems - PalletCount: {T_Warehouse.Instance.PalletCount}, TotalItemCount: {T_Warehouse.Instance.TotalItemCount}, ReturnedItems: {allWarehouseItems.Count}");
		return allWarehouseItems;
	}

	public int GetWarehouseItemCount(string itemId)
	{
		if (T_Warehouse.Instance == null || string.IsNullOrEmpty(itemId))
		{
			return 0;
		}
		return T_Warehouse.Instance.GetItemCount(itemId);
	}

	public int GetWarehouseItemCount(T_ItemSO item)
	{
		if (item == null)
		{
			return 0;
		}
		return GetWarehouseItemCount(item.GetItemID());
	}

	public List<StockDemandData> GetDemandsForSelectedItem()
	{
		if (string.IsNullOrEmpty(_selectedItemId))
		{
			return new List<StockDemandData>();
		}
		return _activeDemands.Where((StockDemandData d) => d.itemId == _selectedItemId).ToList();
	}

	public List<StockDemandData> GetDemandsForItem(string itemId)
	{
		if (string.IsNullOrEmpty(itemId))
		{
			return new List<StockDemandData>();
		}
		return _activeDemands.Where((StockDemandData d) => d.itemId == itemId).ToList();
	}

	[Command(requiresAuthority = false)]
	private void CmdRequestSelectItem(string itemId)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdRequestSelectItem__String(itemId);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(itemId);
		SendCommandInternal("System.Void ComputerStockSellManager::CmdRequestSelectItem(System.String)", 625687857, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdRequestClearSelection()
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdRequestClearSelection();
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void ComputerStockSellManager::CmdRequestClearSelection()", 335660655, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdRequestRefreshDemands()
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdRequestRefreshDemands();
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void ComputerStockSellManager::CmdRequestRefreshDemands()", 754640815, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdRequestAcceptDemand(string demandId)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdRequestAcceptDemand__String(demandId);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(demandId);
		SendCommandInternal("System.Void ComputerStockSellManager::CmdRequestAcceptDemand(System.String)", -1418922563, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	private void CmdRequestAcceptPartialDemand(string demandId, int quantity)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdRequestAcceptPartialDemand__String__Int32(demandId, quantity);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(demandId);
		writer.WriteVarInt(quantity);
		SendCommandInternal("System.Void ComputerStockSellManager::CmdRequestAcceptPartialDemand(System.String,System.Int32)", -645667673, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerSelectItem(string itemId)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void ComputerStockSellManager::ServerSelectItem(System.String)' called when server was not active");
			return;
		}
		if (string.IsNullOrEmpty(itemId))
		{
			Debug.LogWarning("[ComputerStockSellManager] ServerSelectItem: ItemId boş!");
			return;
		}
		Network_selectedItemId = itemId;
		if (_itemsWithGeneratedDemands.Contains(itemId))
		{
			Debug.Log("[ComputerStockSellManager] Item seçildi (teklifler daha önce oluşturulmuş): " + itemId);
			onDemandsGenerated?.Invoke(itemId);
		}
		else
		{
			ServerGenerateDemandsForItem(itemId);
			_itemsWithGeneratedDemands.Add(itemId);
			Debug.Log("[ComputerStockSellManager] Item seçildi (yeni teklifler oluşturuldu): " + itemId);
		}
	}

	[Server]
	private void ServerClearSelection()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void ComputerStockSellManager::ServerClearSelection()' called when server was not active");
			return;
		}
		Network_selectedItemId = string.Empty;
		Debug.Log("[ComputerStockSellManager] Seçim temizlendi (teklifler korunuyor).");
	}

	[Server]
	private void ServerGenerateDemandsForItem(string itemId)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void ComputerStockSellManager::ServerGenerateDemandsForItem(System.String)' called when server was not active");
			return;
		}
		if (string.IsNullOrEmpty(itemId))
		{
			Debug.LogWarning("[ComputerStockSellManager] ServerGenerateDemandsForItem: ItemId boş!");
			return;
		}
		if (allCompanies == null || allCompanies.Count == 0)
		{
			Debug.LogWarning("[ComputerStockSellManager] Şirket listesi boş!");
			return;
		}
		ServerClearDemandsForItem(itemId);
		T_ItemSO item = FindItemById(itemId);
		if (item == null)
		{
			Debug.LogWarning("[ComputerStockSellManager] Item bulunamadı: " + itemId);
			return;
		}
		List<CompanySO> list = allCompanies.Where((CompanySO c) => c != null && c.IsInterestedIn(item)).ToList();
		if (list.Count == 0)
		{
			Debug.LogWarning("[ComputerStockSellManager] " + item.Name + " ile ilgilenen şirket yok!");
			return;
		}
		int a = UnityEngine.Random.Range(minDemandsPerItem, maxDemandsPerItem + 1);
		a = Mathf.Min(a, list.Count);
		foreach (CompanySO item3 in list.OrderBy((CompanySO c) => UnityEngine.Random.value).Take(a).ToList())
		{
			if (!(item3 == null))
			{
				int num = UnityEngine.Random.Range((TutorialManager.Instance != null && TutorialManager.Instance.IsTutorialRunning) ? Mathf.Max(minDemandAmount, 6) : minDemandAmount, maxDemandAmount + 1);
				int num2 = ((MarketPriceManager.Instance != null) ? MarketPriceManager.Instance.GetEffectivePrice(item) : item.Price);
				float num3 = UnityEngine.Random.Range(priceMultiplierMin, priceMultiplierMax);
				int num4 = RoundToStep(Mathf.RoundToInt((float)num2 * num3), priceRoundingStep);
				if (num4 < 1)
				{
					num4 = 1;
				}
				StockDemandData item2 = StockDemandData.Create(itemId, item3, num, num4, num3);
				if (item2.IsValid)
				{
					_activeDemands.Add(item2);
					Debug.Log($"[ComputerStockSellManager] Talep oluşturuldu: {item3.companyName} - {item.Name} x{num} @ ${num4}/adet");
				}
			}
		}
		Debug.Log($"[ComputerStockSellManager] {itemId} için {a} talep oluşturuldu.");
		onDemandsGenerated?.Invoke(itemId);
	}

	[Server]
	private void ServerClearDemandsForItem(string itemId)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void ComputerStockSellManager::ServerClearDemandsForItem(System.String)' called when server was not active");
		}
		else
		{
			if (string.IsNullOrEmpty(itemId))
			{
				return;
			}
			for (int num = _activeDemands.Count - 1; num >= 0; num--)
			{
				if (_activeDemands[num].itemId == itemId)
				{
					_activeDemands.RemoveAt(num);
				}
			}
			Debug.Log("[ComputerStockSellManager] " + itemId + " için talepler temizlendi.");
			onDemandsCleared?.Invoke(itemId);
		}
	}

	[Server]
	private void ServerClearAllDemands()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void ComputerStockSellManager::ServerClearAllDemands()' called when server was not active");
			return;
		}
		_activeDemands.Clear();
		Debug.Log("[ComputerStockSellManager] Tüm talepler temizlendi.");
	}

	[Server]
	private void ServerUpdateExistingDemandPrices()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void ComputerStockSellManager::ServerUpdateExistingDemandPrices()' called when server was not active");
			return;
		}
		for (int i = 0; i < _activeDemands.Count; i++)
		{
			StockDemandData stockDemandData = _activeDemands[i];
			if (stockDemandData.demandMultiplier <= 0f)
			{
				continue;
			}
			T_ItemSO t_ItemSO = FindItemById(stockDemandData.itemId);
			if (!(t_ItemSO == null))
			{
				int num = ((MarketPriceManager.Instance != null) ? MarketPriceManager.Instance.GetEffectivePrice(t_ItemSO) : t_ItemSO.Price);
				int num2 = RoundToStep(Mathf.RoundToInt((float)num * stockDemandData.demandMultiplier), priceRoundingStep);
				if (num2 < 1)
				{
					num2 = 1;
				}
				if (num2 != stockDemandData.pricePerUnit)
				{
					StockDemandData value = stockDemandData;
					value.pricePerUnit = num2;
					_activeDemands[i] = value;
				}
			}
		}
		Debug.Log("[ComputerStockSellManager] Mevcut teklifler piyasa fiyatına göre güncellendi.");
	}

	[Server]
	private void ServerAcceptPartialDemand(string demandId, int quantity)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void ComputerStockSellManager::ServerAcceptPartialDemand(System.String,System.Int32)' called when server was not active");
			return;
		}
		if (string.IsNullOrEmpty(demandId) || quantity <= 0)
		{
			Debug.LogWarning("[ComputerStockSellManager] ServerAcceptPartialDemand: DemandId boş veya quantity geçersiz!");
			return;
		}
		int num = -1;
		for (int i = 0; i < _activeDemands.Count; i++)
		{
			if (_activeDemands[i].demandId == demandId)
			{
				num = i;
				break;
			}
		}
		if (num == -1)
		{
			Debug.LogWarning("[ComputerStockSellManager] Talep bulunamadı: " + demandId);
			return;
		}
		StockDemandData arg = _activeDemands[num];
		Debug.Log($"[ComputerStockSellManager] ServerAcceptPartialDemand - DemandId: {demandId}, ItemId: {arg.itemId}, Quantity: {quantity}");
		if (quantity > arg.demandedAmount)
		{
			Debug.LogWarning($"[ComputerStockSellManager] İstenen miktar talepten fazla! İstenen: {quantity}, Talep: {arg.demandedAmount}");
			quantity = arg.demandedAmount;
		}
		int warehouseItemCount = GetWarehouseItemCount(arg.itemId);
		Debug.Log($"[ComputerStockSellManager] WarehouseCount for {arg.itemId}: {warehouseItemCount}, Required: {quantity}");
		if (warehouseItemCount < quantity)
		{
			Debug.LogWarning($"[ComputerStockSellManager] Yetersiz stok! Gerekli: {quantity}, Mevcut: {warehouseItemCount}");
			NotificationManager.Instance?.ShowNotification(LocalizationManager.GetTranslation("Notification_InsufficientStock"), isComputer: true);
			return;
		}
		if (!ServerRemoveItemsFromWarehouse(arg.itemId, quantity))
		{
			Debug.LogWarning("[ComputerStockSellManager] Warehouse'dan item çıkarılamadı!");
			return;
		}
		int num2 = quantity * arg.pricePerUnit;
		if (FactoryManager.Instance != null)
		{
			FactoryManager.Instance.AddMoney(num2, EconomyType.EconomyType_StockSale);
			int num3 = CalculateStockSellXP(arg.pricePerUnit, quantity);
			FactoryManager.Instance.AddXP(num3, EconomyType.EconomyType_StockSale);
			Debug.Log($"[ComputerStockSellManager] Kısmi satış tamamlandı! Miktar: {quantity}, Para: ${num2:N0}, XP: {num3}");
		}
		MarketPriceManager.Instance?.OnItemSold(arg.itemId, quantity);
		int num4 = arg.demandedAmount - quantity;
		if (num4 > 0)
		{
			StockDemandData value = new StockDemandData
			{
				demandId = arg.demandId,
				itemId = arg.itemId,
				companyId = arg.companyId,
				companyName = arg.companyName,
				demandedAmount = num4,
				pricePerUnit = arg.pricePerUnit,
				demandMultiplier = arg.demandMultiplier,
				createdTime = arg.createdTime
			};
			_activeDemands[num] = value;
			Debug.Log($"[ComputerStockSellManager] Teklif güncellendi - Kalan miktar: {num4}, SyncList[{num}].demandedAmount: {_activeDemands[num].demandedAmount}");
		}
		else
		{
			_activeDemands.RemoveAt(num);
			Debug.Log("[ComputerStockSellManager] Teklif tamamen karşılandı ve silindi.");
		}
		onDemandAccepted?.Invoke(arg);
		onSaleCompleted?.Invoke(arg);
		onWarehouseUpdated?.Invoke();
	}

	[Server]
	private void ServerAcceptDemand(string demandId)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void ComputerStockSellManager::ServerAcceptDemand(System.String)' called when server was not active");
			return;
		}
		if (string.IsNullOrEmpty(demandId))
		{
			Debug.LogWarning("[ComputerStockSellManager] ServerAcceptDemand: DemandId boş!");
			return;
		}
		int num = -1;
		for (int i = 0; i < _activeDemands.Count; i++)
		{
			if (_activeDemands[i].demandId == demandId)
			{
				num = i;
				break;
			}
		}
		if (num == -1)
		{
			Debug.LogWarning("[ComputerStockSellManager] Talep bulunamadı: " + demandId);
			return;
		}
		StockDemandData arg = _activeDemands[num];
		int warehouseItemCount = GetWarehouseItemCount(arg.itemId);
		if (warehouseItemCount < arg.demandedAmount)
		{
			Debug.LogWarning($"[ComputerStockSellManager] Yetersiz stok! Gerekli: {arg.demandedAmount}, Mevcut: {warehouseItemCount}");
			NotificationManager.Instance?.ShowNotification(LocalizationManager.GetTranslation("Notification_InsufficientStock"), isComputer: true);
			return;
		}
		if (!ServerRemoveItemsFromWarehouse(arg.itemId, arg.demandedAmount))
		{
			Debug.LogWarning("[ComputerStockSellManager] Warehouse'dan item çıkarılamadı!");
			return;
		}
		if (FactoryManager.Instance != null)
		{
			FactoryManager.Instance.AddMoney(arg.TotalPrice, EconomyType.EconomyType_StockSale);
			int num2 = CalculateStockSellXP(arg.pricePerUnit, arg.demandedAmount);
			FactoryManager.Instance.AddXP(num2, EconomyType.EconomyType_StockSale);
			Debug.Log($"[ComputerStockSellManager] Satış tamamlandı! Para: ${arg.TotalPrice:N0}, XP: {num2}");
		}
		MarketPriceManager.Instance?.OnItemSold(arg.itemId, arg.demandedAmount);
		_activeDemands.RemoveAt(num);
		onDemandAccepted?.Invoke(arg);
		onSaleCompleted?.Invoke(arg);
		onWarehouseUpdated?.Invoke();
	}

	[Server]
	private bool ServerRemoveItemsFromWarehouse(string itemId, int amount)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Boolean ComputerStockSellManager::ServerRemoveItemsFromWarehouse(System.String,System.Int32)' called when server was not active");
			return default(bool);
		}
		if (T_Warehouse.Instance == null || string.IsNullOrEmpty(itemId) || amount <= 0)
		{
			return false;
		}
		List<T_Pallet> palletsInWarehouse = T_Warehouse.Instance.GetPalletsInWarehouse();
		int num = amount;
		int num2 = 0;
		foreach (T_Pallet item in palletsInWarehouse)
		{
			if (!(item == null) && !item.IsEmpty && !(item.PaletItemId != itemId))
			{
				int paletItemCount = item.PaletItemCount;
				if (paletItemCount <= num)
				{
					num -= paletItemCount;
					num2 += paletItemCount;
					item.ServerClearPallet();
				}
				else
				{
					num2 += num;
					item.ServerRemoveItems(num);
					num = 0;
				}
				if (num <= 0)
				{
					break;
				}
			}
		}
		if (num2 > 0)
		{
			T_Warehouse.Instance.RemoveItemsFromCache(itemId, num2);
		}
		if (num > 0 && T_Warehouse.Instance.RemoveItemsFromCache(itemId, num))
		{
			num = 0;
		}
		return num <= 0;
	}

	private void OnSelectedItemChanged(string oldValue, string newValue)
	{
		Debug.Log("[ComputerStockSellManager] Seçili item değişti: " + oldValue + " -> " + newValue);
	}

	private void OnActiveDemandsChanged(SyncList<StockDemandData>.Operation op, int index, StockDemandData oldItem, StockDemandData newItem)
	{
		Debug.Log($"[ComputerStockSellManager] Talep listesi değişti: {op} index: {index} - Toplam: {_activeDemands.Count}" + (((uint)op == 1u) ? $" | Old Amount: {oldItem.demandedAmount} -> New Amount: {newItem.demandedAmount}" : ""));
		onDemandsListChanged?.Invoke();
	}

	public T_ItemSO FindItemById(string itemId)
	{
		if (string.IsNullOrEmpty(itemId))
		{
			return null;
		}
		foreach (T_ItemSO allItemSO in allItemSOs)
		{
			if (allItemSO != null && allItemSO.GetItemID() == itemId)
			{
				return allItemSO;
			}
		}
		return null;
	}

	public CompanySO FindCompanyById(string companyId)
	{
		if (string.IsNullOrEmpty(companyId))
		{
			return null;
		}
		foreach (CompanySO allCompany in allCompanies)
		{
			if (allCompany != null && allCompany.CompanyId == companyId)
			{
				return allCompany;
			}
		}
		return null;
	}

	public T_ItemSO GetItemByIndex(int index)
	{
		if (index < 0 || index >= allItemSOs.Count)
		{
			return null;
		}
		return allItemSOs[index];
	}

	public int GetItemIndex(T_ItemSO item)
	{
		if (item == null)
		{
			return -1;
		}
		for (int i = 0; i < allItemSOs.Count; i++)
		{
			if (allItemSOs[i] == item)
			{
				return i;
			}
		}
		return -1;
	}

	private int RoundToStep(int value, int step)
	{
		if (step <= 0)
		{
			return value;
		}
		return Mathf.RoundToInt((float)value / (float)step) * step;
	}

	private int CalculateStockSellXP(int itemPrice, int quantity)
	{
		int num = ((itemPrice >= 150) ? 20 : ((itemPrice >= 100) ? 15 : ((itemPrice < 50) ? 5 : 10)));
		return num * quantity;
	}

	[ContextMenu("Test: Select First Item")]
	private void TestSelectFirstItem()
	{
		if (allItemSOs.Count > 0)
		{
			RequestSelectItem(allItemSOs[0]);
		}
	}

	[ContextMenu("Test: Clear Selection")]
	private void TestClearSelection()
	{
		RequestClearSelection();
	}

	[ContextMenu("Test: Refresh Demands")]
	private void TestRefreshDemands()
	{
		RequestRefreshDemands();
	}

	[ContextMenu("Debug: Show All Demands")]
	private void DebugShowAllDemands()
	{
		Debug.Log($"=== Aktif Talepler ({_activeDemands.Count}) ===");
		foreach (StockDemandData activeDemand in _activeDemands)
		{
			Debug.Log($"  - {activeDemand.companyName} | {activeDemand.itemId} x{activeDemand.demandedAmount} @ ${activeDemand.pricePerUnit}/adet = ${activeDemand.TotalPrice:N0}");
		}
	}

	[ContextMenu("Debug: Show Warehouse Items")]
	private void DebugShowWarehouseItems()
	{
		List<WarehouseItemInfo> warehouseItems = GetWarehouseItems();
		Debug.Log($"=== Warehouse İtemleri ({warehouseItems.Count}) ===");
		foreach (WarehouseItemInfo item in warehouseItems)
		{
			Debug.Log($"  - {item.Name}: {item.count} adet");
		}
	}

	public ComputerStockSellManager()
	{
		InitSyncObject(_activeDemands);
		InitSyncObject(_itemsWithGeneratedDemands);
		_Mirror_SyncVarHookDelegate__selectedItemId = OnSelectedItemChanged;
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdRequestSelectItem__String(string itemId)
	{
		ServerSelectItem(itemId);
	}

	protected static void InvokeUserCode_CmdRequestSelectItem__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdRequestSelectItem called on client.");
		}
		else
		{
			((ComputerStockSellManager)obj).UserCode_CmdRequestSelectItem__String(reader.ReadString());
		}
	}

	protected void UserCode_CmdRequestClearSelection()
	{
		ServerClearSelection();
	}

	protected static void InvokeUserCode_CmdRequestClearSelection(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdRequestClearSelection called on client.");
		}
		else
		{
			((ComputerStockSellManager)obj).UserCode_CmdRequestClearSelection();
		}
	}

	protected void UserCode_CmdRequestRefreshDemands()
	{
		if (!string.IsNullOrEmpty(_selectedItemId))
		{
			ServerGenerateDemandsForItem(_selectedItemId);
		}
	}

	protected static void InvokeUserCode_CmdRequestRefreshDemands(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdRequestRefreshDemands called on client.");
		}
		else
		{
			((ComputerStockSellManager)obj).UserCode_CmdRequestRefreshDemands();
		}
	}

	protected void UserCode_CmdRequestAcceptDemand__String(string demandId)
	{
		ServerAcceptDemand(demandId);
	}

	protected static void InvokeUserCode_CmdRequestAcceptDemand__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdRequestAcceptDemand called on client.");
		}
		else
		{
			((ComputerStockSellManager)obj).UserCode_CmdRequestAcceptDemand__String(reader.ReadString());
		}
	}

	protected void UserCode_CmdRequestAcceptPartialDemand__String__Int32(string demandId, int quantity)
	{
		ServerAcceptPartialDemand(demandId, quantity);
	}

	protected static void InvokeUserCode_CmdRequestAcceptPartialDemand__String__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdRequestAcceptPartialDemand called on client.");
		}
		else
		{
			((ComputerStockSellManager)obj).UserCode_CmdRequestAcceptPartialDemand__String__Int32(reader.ReadString(), reader.ReadVarInt());
		}
	}

	static ComputerStockSellManager()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(ComputerStockSellManager), "System.Void ComputerStockSellManager::CmdRequestSelectItem(System.String)", InvokeUserCode_CmdRequestSelectItem__String, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ComputerStockSellManager), "System.Void ComputerStockSellManager::CmdRequestClearSelection()", InvokeUserCode_CmdRequestClearSelection, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ComputerStockSellManager), "System.Void ComputerStockSellManager::CmdRequestRefreshDemands()", InvokeUserCode_CmdRequestRefreshDemands, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ComputerStockSellManager), "System.Void ComputerStockSellManager::CmdRequestAcceptDemand(System.String)", InvokeUserCode_CmdRequestAcceptDemand__String, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ComputerStockSellManager), "System.Void ComputerStockSellManager::CmdRequestAcceptPartialDemand(System.String,System.Int32)", InvokeUserCode_CmdRequestAcceptPartialDemand__String__Int32, requiresAuthority: false);
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteString(_selectedItemId);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteString(_selectedItemId);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref _selectedItemId, _Mirror_SyncVarHookDelegate__selectedItemId, reader.ReadString());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _selectedItemId, _Mirror_SyncVarHookDelegate__selectedItemId, reader.ReadString());
		}
	}
}
