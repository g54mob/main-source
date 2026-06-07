using DV.Interaction;
using DV.JObjectExtstensions;
using DV.UIFramework;
using DV.Utils;
using Newtonsoft.Json.Linq;
using UnityEngine;

[RequireComponent(typeof(ItemSaveData))]
public abstract class Money : NullCheckingMonoBehaviour, IMoney
{
	private const string AMOUNT_SAVE_KEY = "amount";

	protected double amount;

	[SerializeField]
	private AudioClip inventoryAddSound;

	private ItemSaveData itemSaveData;

	public bool ShouldDestroyOnUse => true;

	public bool SoundAlreadyPlayed { get; set; }

	protected abstract double DefaultAmount { get; }

	public abstract double Amount { get; set; }

	public AudioClip AddToInventorySound => inventoryAddSound;

	GameObject IMoney.gameObject => base.gameObject;

	protected override void Awake()
	{
		base.Awake();
		Amount = DefaultAmount;
		base.gameObject.AddComponent<MoneyUse>();
		if (!TryGetComponent<InventoryItemSpec>(out var component))
		{
			Debug.LogError("No InventoryItemSpec attached to GO!", this);
		}
		else
		{
			component.BelongsToPlayer = true;
			SingletonBehaviour<StorageController>.Instance.AddItemToWorldStorageAfterOneFrame(component.gameObject);
		}
		if (TryGetComponent<ItemSaveData>(out itemSaveData))
		{
			itemSaveData.ItemSaveDataRequested += OnItemSaveDataRequested;
			itemSaveData.ItemSaveDataLoaded += OnItemSaveDataLoaded;
		}
	}

	private void OnDestroy()
	{
		if (!UnloadWatcher.isUnloading && itemSaveData != null)
		{
			itemSaveData.ItemSaveDataRequested -= OnItemSaveDataRequested;
			itemSaveData.ItemSaveDataLoaded -= OnItemSaveDataLoaded;
		}
	}

	public double TrySpend(double amountToSpend)
	{
		double result = amount;
		amount = 0.0;
		return result;
	}

	private JObject OnItemSaveDataRequested(JObject data)
	{
		if (Mathd.Approximately(amount, DefaultAmount))
		{
			return null;
		}
		data.SetDouble("amount", amount);
		return data;
	}

	private void OnItemSaveDataLoaded(JObject data)
	{
		Amount = (data?.GetDouble("amount")).GetValueOrDefault(DefaultAmount);
	}
}
