using System.Collections.Generic;
using UnityEngine;

public class WalletSystem : MonoBehaviour
{
	[SerializeField]
	private int startBudget = 500;

	[SerializeField]
	private int bankruptcyValue = -500;

	private List<Wallet> wallets = new List<Wallet>();

	private static WalletSystem instance;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Object.Destroy(this);
		}
		Object.DontDestroyOnLoad(instance);
		GetComponent<Wallet>().Init(startBudget, 0);
	}

	internal static Wallet GetPlayerWallet()
	{
		return instance.wallets[0];
	}

	internal static Wallet GetWallet(int walletId)
	{
		return instance.wallets[walletId];
	}

	internal static int GetBankruptcyValue()
	{
		return instance.bankruptcyValue;
	}

	internal static int RegisterWallet(Wallet wallet)
	{
		instance.wallets.Add(wallet);
		return instance.wallets.Count;
	}

	internal static int RegisterWalletWithId(Wallet wallet, int id)
	{
		wallet.walletId = id;
		instance.wallets.Add(wallet);
		return id;
	}

	internal static void UnregisterWallet(Wallet wallet)
	{
		instance.wallets.Remove(wallet);
	}

	internal static bool CheckBankruptcy()
	{
		return GetPlayerWallet().GetCurrentBudget() < GetBankruptcyValue();
	}
}
