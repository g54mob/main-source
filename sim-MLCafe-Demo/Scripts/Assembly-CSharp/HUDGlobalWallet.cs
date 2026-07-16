using TMPro;
using UnityEngine;

public class HUDGlobalWallet : MonoBehaviour
{
	[SerializeField]
	private TMP_Text label_budget;

	private void Awake()
	{
	}

	private void Start()
	{
		WalletSystem.GetWallet(0).OnBudgetChange.AddListener(UpdateWalletDisplay);
		UpdateWalletDisplay(WalletSystem.GetWallet(0).GetCurrentBudget());
	}

	private void UpdateWalletDisplay(int budget)
	{
		label_budget.text = budget.ToString();
	}
}
