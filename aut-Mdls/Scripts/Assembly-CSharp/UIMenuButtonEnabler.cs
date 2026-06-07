using NaughtyAttributes;
using Presentation.Locators;
using Presentation.UI.Menus;
using Presentation.UI.Menus.MenuEvents;
using Presentation.UI.Menus.MenuEvents.MenuData;
using UnityEngine;
using UnityEngine.UI;

public class UIMenuButtonEnabler : MonoBehaviour
{
	[SerializeField]
	private Button _button;

	[SerializeField]
	private ShowUIMenuEvent _showUIMenuEvent;

	[SerializeField]
	private UIMenuManagerLocator _uiMenuManagerLocator;

	[SerializeField]
	private UIMenuLocator _uiMenuLocator;

	[SerializeField]
	private GoBackSourceSO _goBackSource;

	[SerializeField]
	[EnumFlags]
	private AbstractUIMenuData.ToggleTypes _uiToggles;

	[SerializeField]
	private AbstractUIMenuData.UIDomain _uiDomain;

	private void Start()
	{
		_button.onClick.AddListener(OnButtonClicked);
	}

	private void OnDestroy()
	{
		_button.onClick.RemoveListener(OnButtonClicked);
	}

	private void OnButtonClicked()
	{
		if (_uiMenuManagerLocator.UIMenuManager.IsCurrentlyShowing(_uiMenuLocator.UIMenu))
		{
			_uiMenuManagerLocator.UIMenuManager.GoBack(_goBackSource);
		}
		else
		{
			_showUIMenuEvent.Fire(new UIMenuEmptyData(_uiMenuLocator.UIMenu, _uiDomain, _uiToggles));
		}
	}

	private void Reset()
	{
		TryGetComponent<Button>(out _button);
	}
}
