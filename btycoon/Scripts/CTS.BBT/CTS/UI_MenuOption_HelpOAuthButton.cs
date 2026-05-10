using CTS.UI;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class UI_MenuOption_HelpOAuthButton : MonoBehaviour
	{
		[SerializeField]
		private CanvasGroupController _controllerHelpingPanel;

		private Button _thisButton;

		private void Awake()
		{
			_thisButton = GetComponent<Button>();
			_thisButton.onClick.AddListener(delegate
			{
				clickOnButton();
			});
		}

		private void clickOnButton()
		{
			if (_controllerHelpingPanel.IsHidden)
			{
				_controllerHelpingPanel.QuickShow();
			}
			else
			{
				_controllerHelpingPanel.QuickHide();
			}
		}
	}
}
