using System;
using Presentation.Locators;
using Presentation.UI.Menus;
using Presentation.UI.Menus.MenuEvents;
using Presentation.UI.Menus.MenuEvents.MenuData;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveUIEnabler : MonoBehaviour
{
	public Action OnObjectivesOpened;

	[SerializeField]
	private Button _objectivesButton;

	[SerializeField]
	private ShowUIMenuEvent _showObjectivesUIEvent;

	[SerializeField]
	private UIMenuManagerLocator _objectivesUIManagerLocator;

	[SerializeField]
	private UIMenuLocator _objectivesUILocator;

	[SerializeField]
	private GoBackSourceSO _objectiveUIEnablerGoBackSource;

	private bool _objectivesIsOpened;

	private void Awake()
	{
		_objectivesButton.onClick.AddListener(OnObjectivesButtonClicked);
	}

	private void OnDestroy()
	{
		_objectivesButton.onClick.RemoveListener(OnObjectivesButtonClicked);
	}

	private void OnObjectivesButtonClicked()
	{
		if (!_objectivesIsOpened)
		{
			_showObjectivesUIEvent.Fire(new UIPageMenuData(_objectivesUILocator.UIMenu));
			OnObjectivesOpened?.Invoke();
		}
		else
		{
			_objectivesUIManagerLocator.UIMenuManager.GoBack(_objectiveUIEnablerGoBackSource);
		}
		_objectivesIsOpened = !_objectivesIsOpened;
	}
}
