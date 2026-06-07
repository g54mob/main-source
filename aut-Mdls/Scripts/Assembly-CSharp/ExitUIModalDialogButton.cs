using Presentation.Locators;
using UnityEngine;
using UnityEngine.UI;

public class ExitUIModalDialogButton : MonoBehaviour
{
	[SerializeField]
	private UIMenuManagerLocator _uiMenuManagerLocator;

	[SerializeField]
	private Button _exitButton;

	private void Awake()
	{
		if ((bool)_exitButton)
		{
			_exitButton.onClick.AddListener(Exit);
		}
	}

	private void OnDestroy()
	{
		if ((bool)_exitButton)
		{
			_exitButton.onClick.RemoveListener(Exit);
		}
	}

	private void Exit()
	{
		if ((bool)_uiMenuManagerLocator)
		{
			_uiMenuManagerLocator.UIMenuManager.GoBackModal();
		}
	}
}
