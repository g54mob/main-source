using MLCN_Localization;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class BankrubtcyWarningComponent : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[SerializeField]
	private GameObject content;

	[SerializeField]
	private UIContentAnimator animatorWarning;

	[SerializeField]
	private UIContentAnimator animatorWarningDescription;

	[SerializeField]
	private string localizationBankruptcyWarning;

	[SerializeField]
	private TMP_Text labelDescription;

	[SerializeField]
	private bool isVisible;

	private void Start()
	{
		LocalizationManager.OnLanguageChange.AddListener(delegate
		{
			labelDescription.text = LocalizationManager.GetLocalizedString(localizationBankruptcyWarning, LocalizationDataTable.Tables.ComputerElements);
		});
		animatorWarning.OnFinishedReverse.AddListener(delegate
		{
			content.SetActive(value: false);
		});
		WalletSystem.GetPlayerWallet().OnBudgetOverdraw.AddListener(delegate(int budget)
		{
			if (budget < WalletSystem.GetBankruptcyValue())
			{
				ShowWarning();
			}
			else
			{
				HideWarning();
			}
		});
		HideWarning();
	}

	public void ShowWarning()
	{
		content.SetActive(value: true);
		animatorWarning.OnPlay();
		isVisible = true;
	}

	public void HideWarning()
	{
		animatorWarning.OnReverse();
		isVisible = false;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (isVisible)
		{
			animatorWarningDescription.OnPlay();
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		animatorWarningDescription.OnReverse();
	}
}
