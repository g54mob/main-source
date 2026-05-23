using System;
using TMPro;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI moneyText;

	private void Start()
	{
		moneyText.text = FirstPersonController.S.money.ToString("F1");
		GameManager.S.OnMoneyUpdated += GameManager_OnMoneyUpdated;
	}

	private void OnDestroy()
	{
		GameManager.S.OnMoneyUpdated -= GameManager_OnMoneyUpdated;
	}

	private void GameManager_OnMoneyUpdated(object sender, EventArgs e)
	{
		moneyText.text = FirstPersonController.S.money.ToString("F1");
	}
}
