using System.Collections.Generic;
using UnityEngine;

public class SelectSessionMenu : RadicalMenu, IScrollable
{
	[SerializeField]
	private SessionSlot _sessionSlotPrefab;

	[SerializeField]
	private Transform slotsContainer;

	[SerializeField]
	private UIScrollWindow _scrollWindow;

	[SerializeField]
	private GameObject _findingSessionsLabel;

	[SerializeField]
	private GameObject _noAvailableSessionsLabel;

	[SerializeField]
	private List<MenuHelperButtons.HelpButtonTypes> _helpButtonList;

	private List<PlatformSession> _sessions;

	private float _windowHeight;

	private bool _canOpenUserProfile = true;

	private bool _isRefreshingSessions;

	public override bool UseCustomHelpButtons => true;

	public override void Activate()
	{
		base.gameObject.SetActive(value: true);
		Manager.platform.RefreshPlatformFriends(getProfiles: true);
		RefreshSessions();
	}

	private void Update()
	{
		if (Manager.input.IsRefreshButtonDown() && !_isRefreshingSessions)
		{
			RefreshSessions();
		}
	}

	private void ClearMenuOptions()
	{
		foreach (RadicalMenuOption menuOption in menuOptions)
		{
			menuOption.forceDeactive = true;
			menuOption.canBeActivated = false;
		}
		base.Activate();
	}

	private void RefreshSessions()
	{
		if (!_isRefreshingSessions)
		{
			_isRefreshingSessions = true;
			Debug.Log("Refresh Sessions");
			ClearMenuOptions();
			_findingSessionsLabel.SetActive(value: true);
			_noAvailableSessionsLabel.SetActive(value: false);
			if (!Manager.platform.RefreshJoinableSessions(OnJoinableSessionsRefreshed))
			{
				OnJoinableSessionsRefreshed(PlatformInterface.SessionFetchStatus.Success, _sessions);
			}
		}
	}

	public void UpdateContainingElements(float scroll)
	{
	}

	public bool IsBottomElementSelected()
	{
		UIelement uIelement = null;
		foreach (RadicalMenuOption menuOption in menuOptions)
		{
			if (menuOption.gameObject.activeInHierarchy)
			{
				uIelement = menuOption;
			}
		}
		if (uIelement != null)
		{
			return uIelement == Manager.ui.currentSelectedUIElement;
		}
		return false;
	}

	public bool IsTopElementSelected()
	{
		foreach (RadicalMenuOption menuOption in menuOptions)
		{
			if (menuOption.gameObject.activeInHierarchy)
			{
				return menuOption == Manager.ui.currentSelectedUIElement;
			}
		}
		return false;
	}

	public float GetCurrentWindowHeight()
	{
		return _windowHeight;
	}

	public UIScrollWindow GetScrollWindow()
	{
		return _scrollWindow;
	}

	public override void UpdatePosition()
	{
		float num = menuEntryStartPositionY;
		_windowHeight = 0f;
		foreach (RadicalMenuOption allCurrentlyActiveMenuOption in GetAllCurrentlyActiveMenuOptions())
		{
			Transform obj = allCurrentlyActiveMenuOption.transform;
			Vector3 localPosition = obj.localPosition;
			Vector3 localPosition2 = new Vector3(localPosition.x, num, localPosition.z);
			obj.localPosition = localPosition2;
			num -= menuEntryVirtualHeight;
			_windowHeight += menuEntryVirtualHeight;
		}
	}

	private void OnJoinableSessionsRefreshed(PlatformInterface.SessionFetchStatus sessionStatus, List<PlatformSession> sessions)
	{
		Manager.input.EnableSystemInput();
		_isRefreshingSessions = false;
		_findingSessionsLabel.SetActive(value: false);
		if (sessionStatus == PlatformInterface.SessionFetchStatus.Failed || sessionStatus == PlatformInterface.SessionFetchStatus.Incomplete)
		{
			sessions = null;
			ClearMenuOptions();
			Manager.menu.centerPopUpText.StartNewDisplaySequence("Error/BadInternet", null, menuInputCooldown: true, 0f, 1.5f, useUnscaledTime: true, 0f, 1f, localize: true, TextManager.FontFace.boldMedium, delegate
			{
				Manager.menu.PopMenu();
			}, new List<string> { "ok" }, 10f, 0.95f, 0, 18f);
		}
		_sessions = sessions;
		if (_sessions == null || _sessions.Count == 0)
		{
			_noAvailableSessionsLabel.SetActive(value: true);
			DeselectAnyCurrentOption();
			return;
		}
		for (int num = 0; num < _sessions.Count; num++)
		{
			SessionSlot sessionSlot;
			if (menuOptions.Count <= num)
			{
				sessionSlot = Object.Instantiate(_sessionSlotPrefab, slotsContainer, worldPositionStays: true);
				sessionSlot.transform.localPosition = new Vector3(0f, 0f, 0f);
				menuOptions.Add(sessionSlot);
			}
			else
			{
				sessionSlot = (SessionSlot)menuOptions[num];
			}
			if (num > 0)
			{
				RadicalMenuOption radicalMenuOption = menuOptions[num - 1];
				radicalMenuOption.bottomUIElements = new List<UIelement> { sessionSlot };
				sessionSlot.topUIElements = new List<UIelement> { radicalMenuOption };
			}
			sessionSlot.forceDeactive = false;
			sessionSlot.canBeActivated = true;
			sessionSlot.Init(_sessions[num], this);
			sessionSlot.SetParentMenu(this);
			sessionSlot.SetAsInactive();
			sessionSlot.ResetSelectedOption();
		}
		UpdatePosition();
		SelectOptionIndex(0);
		GetSelectedMenuOption()?.OnSelected();
	}

	public override List<MenuHelperButtons.HelpButtonTypes> GetHelpButtonsToShow()
	{
		if (_helpButtonList.Contains(MenuHelperButtons.HelpButtonTypes.OPENPROFILE))
		{
			_helpButtonList.Remove(MenuHelperButtons.HelpButtonTypes.OPENPROFILE);
		}
		return _helpButtonList;
	}
}
