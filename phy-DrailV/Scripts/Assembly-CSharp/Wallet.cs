using DV.Interaction;
using DV.InventorySystem;
using DV.Localization;
using DV.Utils;
using TMPro;
using UnityEngine;

public class Wallet : MonoBehaviour, IMoney
{
	private TextMeshPro cashText;

	public double Amount
	{
		get
		{
			return SingletonBehaviour<Inventory>.Instance.PlayerMoney;
		}
		set
		{
			SingletonBehaviour<Inventory>.Instance.SetMoney(value);
		}
	}

	public bool ShouldDestroyOnUse => false;

	public AudioClip AddToInventorySound => null;

	public bool SoundAlreadyPlayed { get; set; }

	GameObject IMoney.gameObject => base.gameObject;

	private void Start()
	{
		cashText = GetComponentInChildren<TextMeshPro>();
		base.gameObject.AddComponent<MoneyUse>();
		UpdateText();
		SetupListeners(on: true);
	}

	private void OnDestroy()
	{
		if (!UnloadWatcher.isUnloading)
		{
			SetupListeners(on: false);
		}
	}

	private void SetupListeners(bool on)
	{
		if (on)
		{
			SingletonBehaviour<Inventory>.Instance.MoneyChanged += OnMoneyAddedToInventory;
		}
		else
		{
			SingletonBehaviour<Inventory>.Instance.MoneyChanged -= OnMoneyAddedToInventory;
		}
	}

	private void OnMoneyAddedToInventory(double _, double __)
	{
		UpdateText();
	}

	private void UpdateText()
	{
		cashText.enabled = false;
		cashText.text = "$" + Amount.ToString("N2", LocalizationAPI.CC);
		cashText.enabled = true;
	}

	public double TrySpend(double amountToSpend)
	{
		double amount = Amount;
		if (amount > amountToSpend)
		{
			SingletonBehaviour<Inventory>.Instance.RemoveMoney(amountToSpend);
			return amountToSpend;
		}
		if (amount > 0.0)
		{
			SingletonBehaviour<Inventory>.Instance.RemoveMoney(amount);
			return amount;
		}
		if (amount < 0.0)
		{
			Debug.LogError("There is negative amount of money in the wallet.", this);
		}
		return 0.0;
	}
}
