using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CampCell : MonoBehaviour
{
	[SerializeField]
	private CampType _campType;

	[SerializeField]
	private GameObject _frame_OFF;

	[SerializeField]
	private GameObject _frame_ON;

	[SerializeField]
	private TextMeshProUGUI _costText;

	[SerializeField]
	private Button _buyButton;

	private Action _buyCompleted;

	public void Init(Action buyCompleted)
	{
		_buyCompleted = buyCompleted;
	}

	public void UpdateUI()
	{
		bool campState = MonoSingleton<CampManager>.Instance.GetCampState(_campType);
		_buyButton.gameObject.SetActive(!campState);
		long campCost = MonoSingleton<CampManager>.Instance.GetCampCost(_campType);
		bool flag = Wallet.Instance.HasEnoughGold(campCost);
		_costText.color = (flag ? Color.white : Color.red);
		_frame_OFF.SetActive(!flag);
		_frame_ON.SetActive(flag);
		_costText.text = NumberFormatter.FormatWithComma(campCost) ?? "";
	}

	public void OnClickBuyButton()
	{
		if (MonoSingleton<CampManager>.Instance.BuyCamp(_campType))
		{
			UpdateUI();
			_buyCompleted?.Invoke();
		}
	}
}
