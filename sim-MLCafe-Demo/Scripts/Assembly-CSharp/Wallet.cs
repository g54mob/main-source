using UnityEngine;
using UnityEngine.Events;

public class Wallet : MonoBehaviour
{
	[SerializeField]
	private int minBudget = -1;

	[SerializeField]
	private int maxBudget = -1;

	[SerializeField]
	private int budget;

	[SerializeField]
	private int overdrawBudget = 1000;

	[SerializeField]
	private bool runtimeWallet = true;

	public int walletId;

	public UnityEvent<int> OnBudgetChange;

	public UnityEvent<int> OnBudgetOverdraw;

	private void Start()
	{
		if (runtimeWallet)
		{
			Init();
		}
	}

	public void Init(int startBudget = 0, int staticId = -1)
	{
		budget = startBudget;
		if (staticId >= 0)
		{
			walletId = WalletSystem.RegisterWalletWithId(this, staticId);
		}
		else
		{
			walletId = WalletSystem.RegisterWallet(this);
		}
		OnBudgetChange.Invoke(budget);
	}

	public int GetOverdraw()
	{
		return overdrawBudget;
	}

	public int GetCurrentBudget()
	{
		return budget;
	}

	public int GetBudgetIncludingOverdraw()
	{
		if (budget < 0)
		{
			return -budget + overdrawBudget;
		}
		return budget + overdrawBudget;
	}

	public string GetFormattedBudget()
	{
		string text = "";
		if (budget >= 0)
		{
			return budget.ToString();
		}
		return PopupMessageManager.GetHighlightBegin("red") + budget + PopupMessageManager.GetHighlightEnd();
	}

	public static string FormatBudget(int value)
	{
		return value.ToString();
	}

	public void SetBudget(int budget)
	{
		this.budget = budget;
	}

	public bool HasAmount(int amount)
	{
		return budget >= amount;
	}

	public void AddAmount(int amount)
	{
		bool flag = budget < 0;
		budget += amount;
		if (budget >= 0 && flag)
		{
			OnBudgetOverdraw.Invoke(budget);
		}
		if (budget < 0)
		{
			OnBudgetOverdraw.Invoke(budget);
		}
		OnBudgetChange.Invoke(budget);
	}

	public bool TryRemoveAmount(int amount)
	{
		if (budget - amount < 0)
		{
			return false;
		}
		budget -= amount;
		if (budget < 0)
		{
			OnBudgetOverdraw.Invoke(budget);
		}
		OnBudgetChange.Invoke(budget);
		return true;
	}

	public bool ForceRemoveAmount(int amount)
	{
		budget -= amount;
		if (budget < 0)
		{
			OnBudgetOverdraw.Invoke(budget);
		}
		OnBudgetChange.Invoke(budget);
		return true;
	}
}
