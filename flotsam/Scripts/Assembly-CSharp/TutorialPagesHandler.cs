using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialPagesHandler : MonoBehaviour
{
	[SerializeField]
	private List<GameObject> _tutorialPanels = new List<GameObject>();

	[SerializeField]
	private RewiredButtonDeprecated _prevButtonMouse;

	[SerializeField]
	private RewiredButtonDeprecated _nextButtonMouse;

	[SerializeField]
	private Button _prevButtonJoystick;

	[SerializeField]
	private Button _nextButtonJoystick;

	[SerializeField]
	private TextMeshProUGUI _labelPageNumberMouse;

	[SerializeField]
	private TextMeshProUGUI _labelPageNumberJoystick;

	private GameObject _activePanel;

	private List<GameObject> _tutorialPages = new List<GameObject>();

	private int _pageIndex;

	private string _inputDeviceString = string.Empty;

	private void OnEnable()
	{
		GameEventDispatcher.AddListener(GameEventType.ActiveInputUpdated, OnActiveInputUpdated);
	}

	private void OnDestroy()
	{
		GameEventDispatcher.RemoveListener(GameEventType.ActiveInputUpdated, OnActiveInputUpdated);
	}

	private void OnActiveInputUpdated(GameEvent gameEvent)
	{
		if (_activePanel != null)
		{
			UpdateActivePanelPages(_activePanel);
		}
	}

	public void UpdateActivePanelPages(GameObject activePanel)
	{
		CheckInputDevice();
		ResetPanel();
		PopulatePages(activePanel);
		GoToPage(_pageIndex);
		RefreshButtonStates();
	}

	private void CheckInputDevice()
	{
		if (FlotsamInputManager.ActiveInput == InputFlags.MouseAndKeyboard)
		{
			_inputDeviceString = "MouseAndKeyboard";
		}
		else if (FlotsamInputManager.ActiveInput == InputFlags.Joystick)
		{
			_inputDeviceString = "Joystick";
		}
	}

	private void ResetPanel()
	{
		_pageIndex = 0;
		foreach (GameObject tutorialPage in _tutorialPages)
		{
			tutorialPage.SetActive(value: false);
		}
		_prevButtonMouse.interactable = false;
		_nextButtonMouse.interactable = true;
		_prevButtonJoystick.interactable = false;
		_nextButtonJoystick.interactable = true;
	}

	private void PopulatePages(GameObject activeTab)
	{
		_activePanel = activeTab;
		_tutorialPages.Clear();
		if (_activePanel == null)
		{
			return;
		}
		for (int i = 0; i < _activePanel.transform.childCount; i++)
		{
			if (_activePanel.transform.GetChild(i).CompareTag(_inputDeviceString) || _activePanel.transform.GetChild(i).CompareTag("InputAll"))
			{
				_tutorialPages.Add(_activePanel.transform.GetChild(i).gameObject);
			}
		}
		RefreshPageNumber();
	}

	public void GoToNextPage()
	{
		NavigatePage(Mathf.Min(_pageIndex + 1, _tutorialPages.Count - 1));
		RefreshPageNumber();
	}

	public void GoToPreviousPage()
	{
		NavigatePage(Mathf.Max(_pageIndex - 1, 0));
		RefreshPageNumber();
	}

	private void NavigatePage(int newIndex)
	{
		if (_tutorialPages.Count != 0)
		{
			_pageIndex = newIndex;
			if (_pageIndex == 0)
			{
				_prevButtonMouse.interactable = false;
				_prevButtonJoystick.interactable = false;
			}
			else
			{
				_prevButtonMouse.interactable = true;
				_prevButtonJoystick.interactable = true;
			}
			if (_pageIndex == _tutorialPages.Count - 1)
			{
				_nextButtonMouse.interactable = false;
				_nextButtonJoystick.interactable = false;
			}
			else
			{
				_nextButtonMouse.interactable = true;
				_nextButtonJoystick.interactable = true;
			}
			GoToPage(_pageIndex);
		}
	}

	private void GoToPage(int pageIndex)
	{
		if (_tutorialPages.Count == 0 || pageIndex < 0 || pageIndex > _tutorialPages.Count)
		{
			return;
		}
		foreach (GameObject tutorialPage in _tutorialPages)
		{
			tutorialPage.SetActive(value: false);
		}
		_tutorialPages[pageIndex].SetActive(value: true);
	}

	private void RefreshPageNumber()
	{
		_labelPageNumberMouse.text = _pageIndex + 1 + " / " + _tutorialPages.Count;
		_labelPageNumberJoystick.text = _pageIndex + 1 + " / " + _tutorialPages.Count;
		if (_tutorialPages.Count <= 1)
		{
			_labelPageNumberMouse.gameObject.SetActive(value: false);
			_labelPageNumberJoystick.gameObject.SetActive(value: false);
		}
		else
		{
			_labelPageNumberMouse.gameObject.SetActive(value: true);
			_labelPageNumberJoystick.gameObject.SetActive(value: true);
		}
	}

	private void RefreshButtonStates()
	{
		if (_tutorialPages.Count <= 1)
		{
			_prevButtonMouse.gameObject.SetActive(value: false);
			_nextButtonMouse.gameObject.SetActive(value: false);
			_prevButtonJoystick.gameObject.SetActive(value: false);
			_nextButtonJoystick.gameObject.SetActive(value: false);
		}
		else
		{
			_prevButtonMouse.gameObject.SetActive(value: true);
			_nextButtonMouse.gameObject.SetActive(value: true);
			_prevButtonJoystick.gameObject.SetActive(value: true);
			_nextButtonJoystick.gameObject.SetActive(value: true);
		}
	}
}
