using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Enviro;
using GameCreator.Runtime.Common;
using Mirror;
using UnityEngine;

public class MarketPriceManager : NetworkBehaviour, IGameSave
{
	[Serializable]
	public class MarketPriceSaveData
	{
		public List<ItemPriceModifierSaveEntry> modifiers = new List<ItemPriceModifierSaveEntry>();
	}

	[Serializable]
	public class ItemPriceModifierSaveEntry
	{
		public string itemId;

		public float priceMultiplier;
	}

	[Header("Price Adjustment Settings")]
	[Tooltip("Satılan item'ın fiyat çarpanı birim başına ne kadar düşer (0.02 = %2)")]
	[SerializeField]
	private float decreasePerSale = 0.02f;

	[Tooltip("Diğer item'ların fiyat çarpanı birim başına ne kadar artar (0.003 = %0.3)")]
	[SerializeField]
	private float increasePerSale = 0.003f;

	[Header("Price Bounds")]
	[Tooltip("Minimum fiyat çarpanı (0.5 = baz fiyatın %50'si)")]
	[Range(0.1f, 1f)]
	[SerializeField]
	private float minPriceMultiplier = 0.5f;

	[Tooltip("Maximum fiyat çarpanı (1.5 = baz fiyatın %150'si)")]
	[Range(1f, 3f)]
	[SerializeField]
	private float maxPriceMultiplier = 1.5f;

	[Header("Daily Decay")]
	[Tooltip("Çarpanların günlük 1.0'a doğru normalleşme oranı (0=yok, 1=tam reset)")]
	[Range(0f, 1f)]
	[SerializeField]
	private float dailyDecayRate = 0.1f;

	private readonly SyncList<ItemPriceModifier> _priceModifiers = new SyncList<ItemPriceModifier>();

	public static MarketPriceManager Instance { get; private set; }

	private IReadOnlyList<T_ItemSO> allItemSOs => ScriptableListManager.Instance.AllItemSOs;

	public IReadOnlyList<ItemPriceModifier> PriceModifiers => _priceModifiers;

	public float MinPriceMultiplier => minPriceMultiplier;

	public float MaxPriceMultiplier => maxPriceMultiplier;

	public string SaveID => "market-price-manager";

	public bool IsShared => false;

	public Type SaveType => typeof(MarketPriceSaveData);

	public LoadMode LoadMode => LoadMode.Greedy;

	public event Action OnMarketPricesChanged;

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		else
		{
			Instance = this;
		}
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}

	public override void OnStartServer()
	{
		base.OnStartServer();
		if (_priceModifiers.Count == 0)
		{
			ServerInitializeModifiers();
		}
		if (DayNightManager.Instance != null)
		{
			DayNightManager.Instance.OnDayStarted += OnDayStarted;
		}
		Debug.Log("[MarketPriceManager] Server started.");
	}

	public override void OnStopServer()
	{
		base.OnStopServer();
		if (DayNightManager.Instance != null)
		{
			DayNightManager.Instance.OnDayStarted -= OnDayStarted;
		}
	}

	public override void OnStartClient()
	{
		base.OnStartClient();
		Debug.Log($"[MarketPriceManager] Client started. Modifiers: {_priceModifiers.Count}");
	}

	public int GetEffectivePrice(T_ItemSO item)
	{
		if (item == null)
		{
			return 0;
		}
		float priceMultiplier = GetPriceMultiplier(item.GetItemID());
		return Mathf.Max(1, Mathf.RoundToInt((float)item.Price * priceMultiplier));
	}

	public float GetPriceMultiplier(string itemId)
	{
		if (string.IsNullOrEmpty(itemId))
		{
			return 1f;
		}
		for (int i = 0; i < _priceModifiers.Count; i++)
		{
			if (_priceModifiers[i].itemId == itemId)
			{
				return _priceModifiers[i].priceMultiplier;
			}
		}
		return 1f;
	}

	public void OnItemSold(string soldItemId, int quantity)
	{
		if (base.isServer && !string.IsNullOrEmpty(soldItemId) && quantity > 0)
		{
			ServerApplyPriceChange(soldItemId, quantity);
		}
	}

	[Server]
	private void ServerInitializeModifiers()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void MarketPriceManager::ServerInitializeModifiers()' called when server was not active");
		}
		else
		{
			if (allItemSOs == null)
			{
				return;
			}
			foreach (T_ItemSO allItemSO in allItemSOs)
			{
				if (allItemSO == null)
				{
					continue;
				}
				string itemID = allItemSO.GetItemID();
				bool flag = false;
				for (int i = 0; i < _priceModifiers.Count; i++)
				{
					if (_priceModifiers[i].itemId == itemID)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					_priceModifiers.Add(new ItemPriceModifier(itemID));
				}
			}
			Debug.Log($"[MarketPriceManager] Modifier'lar initialize edildi. Toplam: {_priceModifiers.Count}");
		}
	}

	[Server]
	private void ServerApplyPriceChange(string soldItemId, int quantity)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void MarketPriceManager::ServerApplyPriceChange(System.String,System.Int32)' called when server was not active");
			return;
		}
		float num = decreasePerSale * (float)quantity;
		float num2 = increasePerSale * (float)quantity;
		for (int i = 0; i < _priceModifiers.Count; i++)
		{
			ItemPriceModifier value = _priceModifiers[i];
			if (value.itemId == soldItemId)
			{
				value.priceMultiplier = Mathf.Clamp(value.priceMultiplier - num, minPriceMultiplier, maxPriceMultiplier);
			}
			else
			{
				value.priceMultiplier = Mathf.Clamp(value.priceMultiplier + num2, minPriceMultiplier, maxPriceMultiplier);
			}
			_priceModifiers[i] = value;
		}
		Debug.Log($"[MarketPriceManager] Fiyat güncellendi - Satılan: {soldItemId} x{quantity}, " + $"Düşüş: -{num:F3}, Artış: +{num2:F3}");
		this.OnMarketPricesChanged?.Invoke();
	}

	private void OnDayStarted()
	{
		if (base.isServer)
		{
			ServerApplyDailyDecay();
		}
	}

	[Server]
	private void ServerApplyDailyDecay()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void MarketPriceManager::ServerApplyDailyDecay()' called when server was not active");
		}
		else
		{
			if (dailyDecayRate <= 0f)
			{
				return;
			}
			for (int i = 0; i < _priceModifiers.Count; i++)
			{
				ItemPriceModifier value = _priceModifiers[i];
				if (!Mathf.Approximately(value.priceMultiplier, 1f))
				{
					value.priceMultiplier = Mathf.Lerp(value.priceMultiplier, 1f, dailyDecayRate);
					if (Mathf.Abs(value.priceMultiplier - 1f) < 0.001f)
					{
						value.priceMultiplier = 1f;
					}
					_priceModifiers[i] = value;
				}
			}
			Debug.Log($"[MarketPriceManager] Günlük decay uygulandı (oran: {dailyDecayRate})");
		}
	}

	public object GetSaveData(bool includeNonSavable)
	{
		if (!base.isServer)
		{
			return null;
		}
		MarketPriceSaveData marketPriceSaveData = new MarketPriceSaveData();
		for (int i = 0; i < _priceModifiers.Count; i++)
		{
			marketPriceSaveData.modifiers.Add(new ItemPriceModifierSaveEntry
			{
				itemId = _priceModifiers[i].itemId,
				priceMultiplier = _priceModifiers[i].priceMultiplier
			});
		}
		Debug.Log($"[MarketPriceManager] Save - {marketPriceSaveData.modifiers.Count} modifier kaydedildi.");
		return marketPriceSaveData;
	}

	public Task OnLoad(object value)
	{
		if (!(value is MarketPriceSaveData marketPriceSaveData))
		{
			Debug.LogWarning("[MarketPriceManager] Load başarısız - geçersiz data");
			return Task.CompletedTask;
		}
		if (!base.isServer)
		{
			Debug.Log("[MarketPriceManager] Client - load atlanıyor, SyncList ile sync olacak");
			return Task.CompletedTask;
		}
		_priceModifiers.Clear();
		foreach (ItemPriceModifierSaveEntry modifier in marketPriceSaveData.modifiers)
		{
			_priceModifiers.Add(new ItemPriceModifier(modifier.itemId, modifier.priceMultiplier));
		}
		ServerInitializeModifiers();
		Debug.Log($"[MarketPriceManager] Load - {_priceModifiers.Count} modifier yüklendi.");
		return Task.CompletedTask;
	}

	private void OnEnable()
	{
		SaveLoadManager.Subscribe(this, 42);
		Debug.Log("[MarketPriceManager] SaveLoadManager'a subscribe olundu");
	}

	private void OnDisable()
	{
		SaveLoadManager.Unsubscribe(this);
	}

	[ContextMenu("Debug: Show All Price Modifiers")]
	private void DebugShowAllModifiers()
	{
		Debug.Log($"=== Piyasa Fiyat Çarpanları ({_priceModifiers.Count}) ===");
		foreach (ItemPriceModifier priceModifier in _priceModifiers)
		{
			T_ItemSO t_ItemSO = null;
			if (allItemSOs != null)
			{
				foreach (T_ItemSO allItemSO in allItemSOs)
				{
					if (allItemSO != null && allItemSO.GetItemID() == priceModifier.itemId)
					{
						t_ItemSO = allItemSO;
						break;
					}
				}
			}
			string text = ((t_ItemSO != null) ? t_ItemSO.Name : priceModifier.itemId);
			int num = t_ItemSO?.Price ?? 0;
			int num2 = ((t_ItemSO != null) ? GetEffectivePrice(t_ItemSO) : 0);
			Debug.Log($"  - {text}: x{priceModifier.priceMultiplier:F3} (Base: ${num} → Effective: ${num2})");
		}
	}

	[ContextMenu("Debug: Reset All Modifiers")]
	private void DebugResetAllModifiers()
	{
		if (!base.isServer)
		{
			Debug.LogWarning("[MarketPriceManager] Sadece server'da reset yapılabilir!");
			return;
		}
		for (int i = 0; i < _priceModifiers.Count; i++)
		{
			ItemPriceModifier value = _priceModifiers[i];
			value.priceMultiplier = 1f;
			_priceModifiers[i] = value;
		}
		Debug.Log("[MarketPriceManager] Tüm çarpanlar 1.0'a resetlendi.");
		this.OnMarketPricesChanged?.Invoke();
	}

	public MarketPriceManager()
	{
		InitSyncObject(_priceModifiers);
	}

	public override bool Weaved()
	{
		return true;
	}
}
