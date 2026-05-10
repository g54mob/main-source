using System;
using UnityEngine;
using __Project__.Scripts.Multiplayer;

public class MoneyManager : NoktaSingleton<MoneyManager>
{
	public enum TransitionType
	{
		NONE = 0,
		CHECKOUT_INCOME = 1,
		SUPPLY_COSTS = 2,
		UPGRADE_COSTS = 3,
		RENT = 4,
		BILLS = 5,
		LOAN_INCOME = 6,
		LOAN_PAYMENT = 7,
		STAFF = 8,
		FURNITURE_SALE = 9,
		CUSTOMIZATION = 10,
		FURNITURE_SELL = 11,
		GAS = 12,
		VENDING_MACHINE = 13
	}

	[SerializeField]
	private MoneyText m_MoneyText;

	private float _cachedMoney;

	public Action<float, TransitionType> onMoneyTransition;

	public Action onDisabled;

	private NetworkMoneyManager m_NetworkMoneyManager;

	public MoneyText MoneyText => null;

	public float CachedMoney
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public NetworkMoneyManager NetworkMoneyManager => null;

	public float Money
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public bool HasMoney(float amount)
	{
		return false;
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void MoneyTransition(float amount, TransitionType type, bool updateMoneyText = true)
	{
	}
}
