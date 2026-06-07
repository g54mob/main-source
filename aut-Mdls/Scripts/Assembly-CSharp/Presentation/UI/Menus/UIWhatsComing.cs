using Presentation.Locators;
using Presentation.UI.Menus.MenuEvents.MenuData;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.Menus
{
	public class UIWhatsComing : UIMenu
	{
		[SerializeField]
		protected UIMenuManagerLocator _uiMenuManagerLocator;

		[SerializeField]
		private TextMeshProUGUI _successButtonText;

		[SerializeField]
		private Button _successButton;

		[SerializeField]
		private GoBackSourceSO _uiWhatsComingGoBackSource;

		private bool _proceedToExit;

		public override void ShowMenu(AbstractUIMenuData menuData)
		{
			_proceedToExit = (menuData as WhatsComingUIMenuData).ProceedToExit;
			base.gameObject.SetActive(value: true);
			if (_proceedToExit)
			{
				_successButtonText.SetText(LocalizationUtility.GetLocalizedText("IntroScreen.ButtonExitGame"));
			}
			else
			{
				_successButtonText.SetText(LocalizationUtility.GetLocalizedText("ModalGeneric.ContinueButton"));
			}
			_successButton.onClick.AddListener(OnSuccessButtonClicked);
		}

		public override void HideMenu()
		{
			_successButton.onClick.RemoveListener(OnSuccessButtonClicked);
			base.gameObject.SetActive(value: false);
		}

		private void OnSuccessButtonClicked()
		{
			if (_proceedToExit)
			{
				ApplicationUtils.QuitApplication();
			}
			else
			{
				_uiMenuManagerLocator.UIMenuManager.GoBack(_uiWhatsComingGoBackSource);
			}
		}
	}
}
