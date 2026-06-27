using Helpers.Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Restory.UI.Views
{
	public sealed class GUI_WebBrowserView : UIBehaviour
	{
		[SerializeField]
		private CanvasGroup canvasGroup;

		[SerializeField]
		private TextMeshProUGUI bankBalanceText;

		[SerializeField]
		private TextMeshProUGUI webAddressText;

		public bool IsVisible => canvasGroup.interactable;

		public void Show()
		{
			canvasGroup.blocksRaycasts = true;
			canvasGroup.interactable = true;
			canvasGroup.alpha = 1f;
		}

		public void Hide()
		{
			canvasGroup.blocksRaycasts = false;
			canvasGroup.interactable = false;
			canvasGroup.alpha = 0f;
		}

		public void SetBankBalanceInfo(int moneyInAccount)
		{
			bankBalanceText.text = moneyInAccount.ToReadableString();
		}

		public void SetWebAddressText(string webAddress)
		{
			webAddressText.text = webAddress;
		}
	}
}
