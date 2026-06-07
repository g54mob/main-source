using System;
using System.Collections.Generic;
using Steamworks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;

public class InputManager : CSingleton<InputManager>
{
	public static InputManager m_Instance = null;

	public List<KeybindBaseKey> m_KeybindBaseKeyListDefault;

	public List<KeybindBaseGamepadControl> m_KeybindBaseJoystickCtrlListDefault;

	public static List<KeybindBaseKey> m_KeybindBaseKeyList = new List<KeybindBaseKey>();

	public static List<KeybindBaseGamepadControl> m_KeybindBaseJoystickCtrlList = new List<KeybindBaseGamepadControl>();

	public List<KeybindBaseKey> m_KeybindBaseKeyListBeforeEdit;

	public List<KeybindBaseGamepadControl> m_KeybindBaseJoystickCtrlListBeforeEdit;

	public List<GameActionBaseKeyData> m_GameActionBaseKeyDataList;

	public List<GameActionBaseKeyData> m_GameActionBaseJoystickCtrlDataList;

	public bool m_IsControllerActive;

	public bool m_IsUpdatingKeybind;

	public bool m_IsUpdatingGamepadKeybind;

	public bool m_IsPSController;

	public bool m_IsSteamDeck;

	private bool m_IsCursorVisible;

	private bool m_HasKeybindChanges;

	private bool m_IsSliderActive;

	private bool m_IsContollerDisabled;

	private int m_CurrentKeyboardIndex;

	private float m_CurrentLeftAnalogHorizontalAxis;

	private float m_CurrentLeftAnalogVerticalAxis;

	private float m_CurrentRightAnalogHorizontalAxis;

	private float m_CurrentRightAnalogVerticalAxis;

	private float m_AnalogAxisThresholdToRegisterAsDown = 0.5f;

	private float m_AnalogAxisThresholdToRegisterAsUp = 0.2f;

	public Gamepad m_CurrentGamepad;

	public Mouse m_CurrentMouse;

	private KeybindSetting m_CurrentKeybindSettingUI;

	private EGameBaseKey m_CurrentKeybindGameBaseKey;

	private EGameBaseKey m_CurrentKeybindGameBaseKeySecondary;

	private EGamepadControlBtn m_CheckPressedGamepadControlBtn = EGamepadControlBtn.None;

	private CSettingData m_SettingData;

	private CursorLockMode m_CurrentCursorLockMode;

	private void Awake()
	{
		if (m_Instance == null)
		{
			m_Instance = this;
		}
		else if (m_Instance != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		UnityEngine.Object.DontDestroyOnLoad(this);
		m_SettingData = CSettingData.instance;
		ResetToDefaultKeybind();
		if (CSaveLoad.LoadSetting())
		{
			CSettingData.instance.PropagateLoadSettingData(CSaveLoad.m_SavedSetting);
		}
		for (int i = 0; i < m_KeybindBaseKeyListDefault.Count; i++)
		{
			if (i >= m_KeybindBaseKeyList.Count || m_KeybindBaseKeyList[i] == null || m_KeybindBaseKeyList[i].bindKey == KeyCode.None)
			{
				KeybindBaseKey keybindBaseKey = new KeybindBaseKey();
				keybindBaseKey.baseKey = m_KeybindBaseKeyListDefault[i].baseKey;
				keybindBaseKey.bindKey = m_KeybindBaseKeyListDefault[i].bindKey;
				m_KeybindBaseKeyList.Add(keybindBaseKey);
			}
		}
		for (int j = 0; j < m_KeybindBaseJoystickCtrlListDefault.Count; j++)
		{
			if (j >= m_KeybindBaseJoystickCtrlList.Count)
			{
				KeybindBaseGamepadControl keybindBaseGamepadControl = new KeybindBaseGamepadControl();
				keybindBaseGamepadControl.baseKey = m_KeybindBaseJoystickCtrlListDefault[j].baseKey;
				keybindBaseGamepadControl.ctrlBtn = m_KeybindBaseJoystickCtrlListDefault[j].ctrlBtn;
				m_KeybindBaseJoystickCtrlList.Add(keybindBaseGamepadControl);
			}
			else if (m_KeybindBaseJoystickCtrlList[j] == null)
			{
				KeybindBaseGamepadControl keybindBaseGamepadControl2 = new KeybindBaseGamepadControl();
				keybindBaseGamepadControl2.baseKey = m_KeybindBaseJoystickCtrlListDefault[j].baseKey;
				keybindBaseGamepadControl2.ctrlBtn = m_KeybindBaseJoystickCtrlListDefault[j].ctrlBtn;
				m_KeybindBaseJoystickCtrlList[j] = keybindBaseGamepadControl2;
			}
			else if (m_KeybindBaseJoystickCtrlList[j].ctrlBtn == EGamepadControlBtn.None)
			{
				m_KeybindBaseJoystickCtrlList[j].ctrlBtn = m_KeybindBaseJoystickCtrlListDefault[j].ctrlBtn;
			}
		}
		RefreshKeybindBeforeEdit();
		try
		{
			m_IsSteamDeck = SteamUtils.IsSteamRunningOnSteamDeck();
			if (m_IsSteamDeck)
			{
				SetGamepadControllerActive(isActive: true);
			}
		}
		catch
		{
		}
	}

	public void SetIsControllerDisabledSetting(bool isDisabled)
	{
		if (!m_IsContollerDisabled && isDisabled)
		{
			SetGamepadControllerActive(isActive: false);
		}
		m_IsContollerDisabled = isDisabled;
	}

	private void SetGamepadControllerActive(bool isActive)
	{
		if (isActive && (CSingleton<CGameManager>.Instance.m_DisableController || m_IsContollerDisabled))
		{
			m_IsControllerActive = false;
			return;
		}
		if (isActive)
		{
			CheckIsPSController();
		}
		if (m_IsControllerActive == isActive)
		{
			return;
		}
		m_IsControllerActive = isActive;
		ControllerScreenUIExtManager.SetControllerActive(isActive);
		if (CSingleton<CGameManager>.Instance.m_IsGameLevel)
		{
			if ((bool)CSingleton<InteractionPlayerController>.Instance.m_InputTooltipListDisplay)
			{
				CSingleton<InteractionPlayerController>.Instance.m_InputTooltipListDisplay.UpdatePhoneAndAlbumTooltip();
				CSingleton<InteractionPlayerController>.Instance.m_InputTooltipListDisplay.RefreshActiveTooltip();
			}
			CSingleton<GameUIScreen>.Instance.UpdateGoNextDayText();
		}
		if (m_IsControllerActive)
		{
			Cursor.visible = false;
		}
		else if (GetCursorLockMode() == CursorLockMode.Confined || !CSingleton<CGameManager>.Instance.m_IsGameLevel)
		{
			Cursor.visible = true;
		}
		else
		{
			Cursor.visible = false;
		}
	}

	private void OnApplicationFocus(bool hasFocus)
	{
		if (hasFocus)
		{
			if (GetCursorLockMode() == CursorLockMode.Confined || !CSingleton<CGameManager>.Instance.m_IsGameLevel)
			{
				Cursor.visible = true;
			}
			else
			{
				Cursor.visible = false;
			}
		}
	}

	private void Start()
	{
		InputSystem.onDeviceChange += delegate(InputDevice device, InputDeviceChange change)
		{
			switch (change)
			{
			case InputDeviceChange.Added:
				m_CurrentGamepad = Gamepad.current;
				m_CurrentMouse = Mouse.current;
				SetGamepadControllerActive(isActive: true);
				break;
			case InputDeviceChange.Disconnected:
				SetGamepadControllerActive(isActive: false);
				m_CurrentGamepad = null;
				break;
			case InputDeviceChange.Reconnected:
				m_CurrentGamepad = Gamepad.current;
				SetGamepadControllerActive(isActive: true);
				break;
			case InputDeviceChange.Removed:
				SetGamepadControllerActive(isActive: false);
				m_CurrentGamepad = null;
				break;
			}
		};
		Init();
	}

	public static void OnLevelFinishedLoading()
	{
		CSingleton<InputManager>.Instance.Init();
	}

	private void Init()
	{
		m_CurrentMouse = Mouse.current;
		m_CurrentGamepad = Gamepad.current;
		if (m_CurrentGamepad != null)
		{
			SetGamepadControllerActive(isActive: true);
		}
		else
		{
			SetGamepadControllerActive(isActive: false);
		}
		ControllerScreenUIExtManager.SetControllerActive(m_IsControllerActive);
	}

	private void CheckIsPSController()
	{
		if (m_CurrentGamepad != null)
		{
			if (m_CurrentGamepad is DualShockGamepad || m_CurrentGamepad.layout == "DualSenseGamepadHID" || m_CurrentGamepad.layout == "DualSenseGamepad")
			{
				m_IsPSController = true;
			}
			else
			{
				m_IsPSController = false;
			}
		}
	}

	private void Update()
	{
		if (m_IsControllerActive)
		{
			if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
			{
				SetGamepadControllerActive(isActive: false);
			}
			else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
			{
				SetGamepadControllerActive(isActive: false);
			}
			else if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Escape))
			{
				SetGamepadControllerActive(isActive: false);
			}
			else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
			{
				SetGamepadControllerActive(isActive: false);
			}
			else if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Z))
			{
				SetGamepadControllerActive(isActive: false);
			}
		}
		else if (m_CurrentGamepad != null && m_CurrentGamepad.enabled)
		{
			if (Mathf.Abs(Input.GetAxis("LJoystick X")) > 0f || Mathf.Abs(Input.GetAxis("LJoystick Y")) > 0f)
			{
				SetGamepadControllerActive(isActive: true);
			}
			else if (GetGamepadButtonUp(EGamepadControlBtn.X) || GetGamepadButtonUp(EGamepadControlBtn.O) || GetGamepadButtonUp(EGamepadControlBtn.Triangle) || GetGamepadButtonUp(EGamepadControlBtn.Square))
			{
				SetGamepadControllerActive(isActive: true);
			}
			else if (GetGamepadButtonUp(EGamepadControlBtn.Start) || GetGamepadButtonUp(EGamepadControlBtn.Select) || GetGamepadButtonUp(EGamepadControlBtn.L1) || GetGamepadButtonUp(EGamepadControlBtn.R1))
			{
				SetGamepadControllerActive(isActive: true);
			}
			else if (GetGamepadButtonUp(EGamepadControlBtn.L2) || GetGamepadButtonUp(EGamepadControlBtn.R2) || GetGamepadButtonUp(EGamepadControlBtn.L3) || GetGamepadButtonUp(EGamepadControlBtn.R3))
			{
				SetGamepadControllerActive(isActive: true);
			}
			else if (GetGamepadButtonUp(EGamepadControlBtn.DpadUp) || GetGamepadButtonUp(EGamepadControlBtn.DpadDown) || GetGamepadButtonUp(EGamepadControlBtn.DpadLeft) || GetGamepadButtonUp(EGamepadControlBtn.DpadRight))
			{
				SetGamepadControllerActive(isActive: true);
			}
		}
		if (m_IsUpdatingKeybind)
		{
			foreach (KeyCode value in Enum.GetValues(typeof(KeyCode)))
			{
				if (Input.GetKey(value))
				{
					UpdateKeybind(m_CurrentKeybindGameBaseKey, value);
					if (m_CurrentKeybindGameBaseKeySecondary != EGameBaseKey.None)
					{
						UpdateKeybind(m_CurrentKeybindGameBaseKeySecondary, value);
						m_CurrentKeybindGameBaseKeySecondary = EGameBaseKey.None;
					}
					m_IsUpdatingKeybind = false;
					m_CurrentKeybindSettingUI.OnFinishSetKeybind(value);
					m_HasKeybindChanges = true;
				}
			}
			return;
		}
		if (!m_IsUpdatingGamepadKeybind)
		{
			return;
		}
		m_CheckPressedGamepadControlBtn = GetGamepadControlBtnEnum();
		if (m_CheckPressedGamepadControlBtn != EGamepadControlBtn.None)
		{
			UpdateGamepadKeybind(m_CurrentKeybindGameBaseKey, m_CheckPressedGamepadControlBtn);
			if (m_CurrentKeybindGameBaseKeySecondary != EGameBaseKey.None)
			{
				UpdateGamepadKeybind(m_CurrentKeybindGameBaseKeySecondary, m_CheckPressedGamepadControlBtn);
				m_CurrentKeybindGameBaseKeySecondary = EGameBaseKey.None;
			}
			m_IsUpdatingGamepadKeybind = false;
			m_CurrentKeybindSettingUI.OnFinishSetGamepadKeybind(m_CheckPressedGamepadControlBtn);
			m_CheckPressedGamepadControlBtn = EGamepadControlBtn.None;
			m_HasKeybindChanges = true;
		}
	}

	public void UndoKeybind()
	{
		m_HasKeybindChanges = false;
		m_KeybindBaseKeyList.Clear();
		for (int i = 0; i < m_KeybindBaseKeyListBeforeEdit.Count; i++)
		{
			KeybindBaseKey keybindBaseKey = new KeybindBaseKey();
			keybindBaseKey.baseKey = m_KeybindBaseKeyListBeforeEdit[i].baseKey;
			keybindBaseKey.bindKey = m_KeybindBaseKeyListBeforeEdit[i].bindKey;
			m_KeybindBaseKeyList.Add(keybindBaseKey);
		}
		m_KeybindBaseJoystickCtrlList.Clear();
		for (int j = 0; j < m_KeybindBaseJoystickCtrlListBeforeEdit.Count; j++)
		{
			KeybindBaseGamepadControl keybindBaseGamepadControl = new KeybindBaseGamepadControl();
			keybindBaseGamepadControl.baseKey = m_KeybindBaseJoystickCtrlListBeforeEdit[j].baseKey;
			keybindBaseGamepadControl.ctrlBtn = m_KeybindBaseJoystickCtrlListBeforeEdit[j].ctrlBtn;
			m_KeybindBaseJoystickCtrlList.Add(keybindBaseGamepadControl);
		}
	}

	public static void OnKeybindSettingSaved()
	{
		CSingleton<InputManager>.Instance.m_HasKeybindChanges = false;
		CSingleton<InputManager>.Instance.RefreshKeybindBeforeEdit();
	}

	public void ResetToDefaultKeybind()
	{
		m_KeybindBaseKeyList.Clear();
		for (int i = 0; i < m_KeybindBaseKeyListDefault.Count; i++)
		{
			KeybindBaseKey keybindBaseKey = new KeybindBaseKey();
			keybindBaseKey.baseKey = m_KeybindBaseKeyListDefault[i].baseKey;
			keybindBaseKey.bindKey = m_KeybindBaseKeyListDefault[i].bindKey;
			m_KeybindBaseKeyList.Add(keybindBaseKey);
		}
		m_KeybindBaseJoystickCtrlList.Clear();
		for (int j = 0; j < m_KeybindBaseJoystickCtrlListDefault.Count; j++)
		{
			KeybindBaseGamepadControl keybindBaseGamepadControl = new KeybindBaseGamepadControl();
			keybindBaseGamepadControl.baseKey = m_KeybindBaseJoystickCtrlListDefault[j].baseKey;
			keybindBaseGamepadControl.ctrlBtn = m_KeybindBaseJoystickCtrlListDefault[j].ctrlBtn;
			m_KeybindBaseJoystickCtrlList.Add(keybindBaseGamepadControl);
		}
	}

	public void RefreshKeybindBeforeEdit()
	{
		m_KeybindBaseKeyListBeforeEdit.Clear();
		for (int i = 0; i < m_KeybindBaseKeyList.Count; i++)
		{
			KeybindBaseKey keybindBaseKey = new KeybindBaseKey();
			keybindBaseKey.baseKey = m_KeybindBaseKeyList[i].baseKey;
			keybindBaseKey.bindKey = m_KeybindBaseKeyList[i].bindKey;
			m_KeybindBaseKeyListBeforeEdit.Add(keybindBaseKey);
		}
		m_KeybindBaseJoystickCtrlListBeforeEdit.Clear();
		for (int j = 0; j < m_KeybindBaseJoystickCtrlList.Count; j++)
		{
			KeybindBaseGamepadControl keybindBaseGamepadControl = new KeybindBaseGamepadControl();
			keybindBaseGamepadControl.baseKey = m_KeybindBaseJoystickCtrlList[j].baseKey;
			keybindBaseGamepadControl.ctrlBtn = m_KeybindBaseJoystickCtrlList[j].ctrlBtn;
			m_KeybindBaseJoystickCtrlListBeforeEdit.Add(keybindBaseGamepadControl);
		}
	}

	public static void OnPressKeybindButton(KeybindSetting keybindSettingUI, bool isGamepad, EGameBaseKey gameBaseKey, EGameBaseKey gameBaseKeySecondary)
	{
		CSingleton<InputManager>.Instance.m_CurrentKeybindSettingUI = keybindSettingUI;
		CSingleton<InputManager>.Instance.m_CurrentKeybindGameBaseKey = gameBaseKey;
		CSingleton<InputManager>.Instance.m_CurrentKeybindGameBaseKeySecondary = gameBaseKeySecondary;
		if (isGamepad)
		{
			CSingleton<InputManager>.Instance.m_IsUpdatingGamepadKeybind = true;
		}
		else
		{
			CSingleton<InputManager>.Instance.m_IsUpdatingKeybind = true;
		}
	}

	public static void OnKeyboardTypeUpdated(int keyboardIndex)
	{
		if (CSingleton<InputManager>.Instance.m_CurrentKeyboardIndex != keyboardIndex)
		{
			CSingleton<InputManager>.Instance.m_CurrentKeyboardIndex = keyboardIndex;
			switch (keyboardIndex)
			{
			case 0:
				UpdateKeybind(EGameBaseKey.Q, KeyCode.Q);
				UpdateKeybind(EGameBaseKey.A, KeyCode.A);
				UpdateKeybind(EGameBaseKey.W, KeyCode.W);
				break;
			case 1:
				UpdateKeybind(EGameBaseKey.Q, KeyCode.A);
				UpdateKeybind(EGameBaseKey.A, KeyCode.Q);
				UpdateKeybind(EGameBaseKey.W, KeyCode.Z);
				break;
			}
		}
	}

	public static List<KeyCode> GetActionBindedKeyList(EGameAction action)
	{
		List<EGameBaseKey> list = new List<EGameBaseKey>();
		for (int i = 0; i < CSingleton<InputManager>.Instance.m_GameActionBaseKeyDataList.Count; i++)
		{
			if (CSingleton<InputManager>.Instance.m_GameActionBaseKeyDataList[i].gameAction == action)
			{
				list.Add(CSingleton<InputManager>.Instance.m_GameActionBaseKeyDataList[i].baseKey);
			}
		}
		List<KeyCode> list2 = new List<KeyCode>();
		for (int j = 0; j < list.Count; j++)
		{
			for (int k = 0; k < m_KeybindBaseKeyList.Count; k++)
			{
				if (m_KeybindBaseKeyList[k].baseKey == list[j])
				{
					list2.Add(m_KeybindBaseKeyList[k].bindKey);
					break;
				}
			}
		}
		return list2;
	}

	public static List<EGamepadControlBtn> GetActionBindedGamepadBtnList(EGameAction action)
	{
		List<EGameBaseKey> list = new List<EGameBaseKey>();
		for (int i = 0; i < CSingleton<InputManager>.Instance.m_GameActionBaseJoystickCtrlDataList.Count; i++)
		{
			if (CSingleton<InputManager>.Instance.m_GameActionBaseJoystickCtrlDataList[i].gameAction == action)
			{
				list.Add(CSingleton<InputManager>.Instance.m_GameActionBaseJoystickCtrlDataList[i].baseKey);
			}
		}
		if (list.Count == 0)
		{
			for (int j = 0; j < CSingleton<InputManager>.Instance.m_GameActionBaseKeyDataList.Count; j++)
			{
				if (CSingleton<InputManager>.Instance.m_GameActionBaseKeyDataList[j].gameAction == action)
				{
					list.Add(CSingleton<InputManager>.Instance.m_GameActionBaseKeyDataList[j].baseKey);
				}
			}
		}
		List<EGamepadControlBtn> list2 = new List<EGamepadControlBtn>();
		for (int k = 0; k < list.Count; k++)
		{
			for (int l = 0; l < m_KeybindBaseJoystickCtrlList.Count; l++)
			{
				if (m_KeybindBaseJoystickCtrlList[l].baseKey == list[k])
				{
					list2.Add(m_KeybindBaseJoystickCtrlList[l].ctrlBtn);
					break;
				}
			}
		}
		return list2;
	}

	public static bool GetKeyUpAction(EGameAction action)
	{
		bool flag = false;
		if (CSingleton<InputManager>.Instance.m_IsControllerActive && CSingleton<InputManager>.Instance.m_CurrentGamepad != null)
		{
			for (int i = 0; i < CSingleton<InputManager>.Instance.m_GameActionBaseJoystickCtrlDataList.Count; i++)
			{
				if (CSingleton<InputManager>.Instance.m_GameActionBaseJoystickCtrlDataList[i].gameAction == action)
				{
					flag = true;
					if (GetKeyUp(CSingleton<InputManager>.Instance.m_GameActionBaseJoystickCtrlDataList[i].baseKey))
					{
						CSingleton<InputManager>.Instance.SetGamepadControllerActive(isActive: true);
						return true;
					}
				}
			}
		}
		if (flag)
		{
			return false;
		}
		for (int j = 0; j < CSingleton<InputManager>.Instance.m_GameActionBaseKeyDataList.Count; j++)
		{
			if (CSingleton<InputManager>.Instance.m_GameActionBaseKeyDataList[j].gameAction == action && GetKeyUp(CSingleton<InputManager>.Instance.m_GameActionBaseKeyDataList[j].baseKey))
			{
				return true;
			}
		}
		return false;
	}

	public static bool GetKeyDownAction(EGameAction action)
	{
		bool flag = false;
		if (CSingleton<InputManager>.Instance.m_IsControllerActive && CSingleton<InputManager>.Instance.m_CurrentGamepad != null)
		{
			for (int i = 0; i < CSingleton<InputManager>.Instance.m_GameActionBaseJoystickCtrlDataList.Count; i++)
			{
				if (CSingleton<InputManager>.Instance.m_GameActionBaseJoystickCtrlDataList[i].gameAction == action)
				{
					flag = true;
					if (GetKeyDown(CSingleton<InputManager>.Instance.m_GameActionBaseJoystickCtrlDataList[i].baseKey))
					{
						CSingleton<InputManager>.Instance.SetGamepadControllerActive(isActive: true);
						return true;
					}
				}
			}
		}
		if (flag)
		{
			return false;
		}
		for (int j = 0; j < CSingleton<InputManager>.Instance.m_GameActionBaseKeyDataList.Count; j++)
		{
			if (CSingleton<InputManager>.Instance.m_GameActionBaseKeyDataList[j].gameAction == action && GetKeyDown(CSingleton<InputManager>.Instance.m_GameActionBaseKeyDataList[j].baseKey))
			{
				return true;
			}
		}
		return false;
	}

	public static bool GetKeyHoldAction(EGameAction action)
	{
		bool flag = false;
		if (CSingleton<InputManager>.Instance.m_IsControllerActive && CSingleton<InputManager>.Instance.m_CurrentGamepad != null)
		{
			for (int i = 0; i < CSingleton<InputManager>.Instance.m_GameActionBaseJoystickCtrlDataList.Count; i++)
			{
				if (CSingleton<InputManager>.Instance.m_GameActionBaseJoystickCtrlDataList[i].gameAction == action)
				{
					flag = true;
					if (GetKeyHold(CSingleton<InputManager>.Instance.m_GameActionBaseJoystickCtrlDataList[i].baseKey))
					{
						return true;
					}
				}
			}
		}
		if (flag)
		{
			return false;
		}
		for (int j = 0; j < CSingleton<InputManager>.Instance.m_GameActionBaseKeyDataList.Count; j++)
		{
			if (CSingleton<InputManager>.Instance.m_GameActionBaseKeyDataList[j].gameAction == action && GetKeyHold(CSingleton<InputManager>.Instance.m_GameActionBaseKeyDataList[j].baseKey))
			{
				return true;
			}
		}
		return false;
	}

	public static string GetActionName(EGameAction action)
	{
		for (int i = 0; i < CSingleton<InputManager>.Instance.m_GameActionBaseKeyDataList.Count; i++)
		{
			if (CSingleton<InputManager>.Instance.m_GameActionBaseKeyDataList[i].gameAction == action)
			{
				return CSingleton<InputManager>.Instance.m_GameActionBaseKeyDataList[i].GetName();
			}
		}
		return "";
	}

	public static bool GetKeyUp(EGameBaseKey gameBaseKey)
	{
		if (CSingleton<InputManager>.Instance.m_CurrentGamepad != null)
		{
			for (int i = 0; i < m_KeybindBaseJoystickCtrlList.Count; i++)
			{
				if (m_KeybindBaseJoystickCtrlList[i].baseKey == gameBaseKey && GetGamepadButtonUp(m_KeybindBaseJoystickCtrlList[i].ctrlBtn))
				{
					CSingleton<InputManager>.Instance.SetGamepadControllerActive(isActive: true);
					return true;
				}
			}
		}
		for (int j = 0; j < m_KeybindBaseKeyList.Count; j++)
		{
			if (m_KeybindBaseKeyList[j].baseKey != gameBaseKey)
			{
				continue;
			}
			if (m_KeybindBaseKeyList[j].bindKey == KeyCode.Mouse0)
			{
				if (CSingleton<InputManager>.Instance.m_CurrentMouse != null && CSingleton<InputManager>.Instance.m_CurrentMouse.leftButton.wasReleasedThisFrame)
				{
					CSingleton<InputManager>.Instance.SetGamepadControllerActive(isActive: false);
					return true;
				}
			}
			else if (m_KeybindBaseKeyList[j].bindKey == KeyCode.Mouse1 && CSingleton<InputManager>.Instance.m_CurrentMouse != null && CSingleton<InputManager>.Instance.m_CurrentMouse.rightButton.wasReleasedThisFrame)
			{
				CSingleton<InputManager>.Instance.SetGamepadControllerActive(isActive: false);
				return true;
			}
			if (Input.GetKeyUp(m_KeybindBaseKeyList[j].bindKey))
			{
				CSingleton<InputManager>.Instance.SetGamepadControllerActive(isActive: false);
				return true;
			}
		}
		return false;
	}

	public static bool GetKeyDown(EGameBaseKey gameBaseKey)
	{
		if (CSingleton<InputManager>.Instance.m_CurrentGamepad != null)
		{
			for (int i = 0; i < m_KeybindBaseJoystickCtrlList.Count; i++)
			{
				if (m_KeybindBaseJoystickCtrlList[i].baseKey == gameBaseKey && GetGamepadButtonDown(m_KeybindBaseJoystickCtrlList[i].ctrlBtn))
				{
					CSingleton<InputManager>.Instance.SetGamepadControllerActive(isActive: true);
					return true;
				}
			}
		}
		for (int j = 0; j < m_KeybindBaseKeyList.Count; j++)
		{
			if (m_KeybindBaseKeyList[j].baseKey != gameBaseKey)
			{
				continue;
			}
			if (m_KeybindBaseKeyList[j].bindKey == KeyCode.Mouse0)
			{
				if (CSingleton<InputManager>.Instance.m_CurrentMouse != null && CSingleton<InputManager>.Instance.m_CurrentMouse.leftButton.wasPressedThisFrame)
				{
					CSingleton<InputManager>.Instance.SetGamepadControllerActive(isActive: false);
					return true;
				}
			}
			else if (m_KeybindBaseKeyList[j].bindKey == KeyCode.Mouse1 && CSingleton<InputManager>.Instance.m_CurrentMouse != null && CSingleton<InputManager>.Instance.m_CurrentMouse.rightButton.wasPressedThisFrame)
			{
				CSingleton<InputManager>.Instance.SetGamepadControllerActive(isActive: false);
				return true;
			}
			if (Input.GetKeyDown(m_KeybindBaseKeyList[j].bindKey))
			{
				CSingleton<InputManager>.Instance.SetGamepadControllerActive(isActive: false);
				return true;
			}
		}
		return false;
	}

	public static bool GetKeyHold(EGameBaseKey gameBaseKey)
	{
		if (CSingleton<InputManager>.Instance.m_CurrentGamepad != null)
		{
			for (int i = 0; i < m_KeybindBaseJoystickCtrlList.Count; i++)
			{
				if (m_KeybindBaseJoystickCtrlList[i].baseKey == gameBaseKey && GetGamepadButtonHold(m_KeybindBaseJoystickCtrlList[i].ctrlBtn))
				{
					CSingleton<InputManager>.Instance.SetGamepadControllerActive(isActive: true);
					return true;
				}
			}
		}
		for (int j = 0; j < m_KeybindBaseKeyList.Count; j++)
		{
			if (m_KeybindBaseKeyList[j].baseKey != gameBaseKey)
			{
				continue;
			}
			if (m_KeybindBaseKeyList[j].bindKey == KeyCode.Mouse0)
			{
				if (CSingleton<InputManager>.Instance.m_CurrentMouse != null && CSingleton<InputManager>.Instance.m_CurrentMouse.leftButton.isPressed)
				{
					CSingleton<InputManager>.Instance.SetGamepadControllerActive(isActive: false);
					return true;
				}
			}
			else if (m_KeybindBaseKeyList[j].bindKey == KeyCode.Mouse1 && CSingleton<InputManager>.Instance.m_CurrentMouse != null && CSingleton<InputManager>.Instance.m_CurrentMouse.rightButton.isPressed)
			{
				CSingleton<InputManager>.Instance.SetGamepadControllerActive(isActive: false);
				return true;
			}
			if (Input.GetKey(m_KeybindBaseKeyList[j].bindKey))
			{
				CSingleton<InputManager>.Instance.SetGamepadControllerActive(isActive: false);
				return true;
			}
		}
		return false;
	}

	public static bool GetLeftAnalogDown(int horizontalVerticalIndex, bool positiveValue)
	{
		if (CSingleton<InputManager>.Instance.m_CurrentGamepad == null)
		{
			return false;
		}
		if (horizontalVerticalIndex == 0)
		{
			if (positiveValue)
			{
				if (CSingleton<InputManager>.Instance.m_CurrentLeftAnalogHorizontalAxis <= 0f && CSingleton<InputManager>.Instance.m_CurrentGamepad.leftStick.x.value > CSingleton<InputManager>.Instance.m_AnalogAxisThresholdToRegisterAsDown)
				{
					CSingleton<InputManager>.Instance.m_CurrentLeftAnalogHorizontalAxis = 1f;
					return true;
				}
			}
			else if (CSingleton<InputManager>.Instance.m_CurrentLeftAnalogHorizontalAxis >= 0f && CSingleton<InputManager>.Instance.m_CurrentGamepad.leftStick.x.value < 0f - CSingleton<InputManager>.Instance.m_AnalogAxisThresholdToRegisterAsDown)
			{
				CSingleton<InputManager>.Instance.m_CurrentLeftAnalogHorizontalAxis = -1f;
				return true;
			}
		}
		else if (positiveValue)
		{
			if (CSingleton<InputManager>.Instance.m_CurrentLeftAnalogVerticalAxis <= 0f && CSingleton<InputManager>.Instance.m_CurrentGamepad.leftStick.y.value > CSingleton<InputManager>.Instance.m_AnalogAxisThresholdToRegisterAsDown)
			{
				CSingleton<InputManager>.Instance.m_CurrentLeftAnalogVerticalAxis = 1f;
				return true;
			}
		}
		else if (CSingleton<InputManager>.Instance.m_CurrentLeftAnalogVerticalAxis >= 0f && CSingleton<InputManager>.Instance.m_CurrentGamepad.leftStick.y.value < 0f - CSingleton<InputManager>.Instance.m_AnalogAxisThresholdToRegisterAsDown)
		{
			CSingleton<InputManager>.Instance.m_CurrentLeftAnalogVerticalAxis = -1f;
			return true;
		}
		return false;
	}

	public static bool GetLeftAnalogUp(int horizontalVerticalIndex, bool positiveValue)
	{
		if (CSingleton<InputManager>.Instance.m_CurrentGamepad == null)
		{
			return false;
		}
		if (horizontalVerticalIndex == 0)
		{
			if (positiveValue)
			{
				if (CSingleton<InputManager>.Instance.m_CurrentLeftAnalogHorizontalAxis > 0f && CSingleton<InputManager>.Instance.m_CurrentGamepad.leftStick.x.value <= CSingleton<InputManager>.Instance.m_AnalogAxisThresholdToRegisterAsUp)
				{
					CSingleton<InputManager>.Instance.m_CurrentLeftAnalogHorizontalAxis = 0f;
					return true;
				}
			}
			else if (CSingleton<InputManager>.Instance.m_CurrentLeftAnalogHorizontalAxis < 0f && CSingleton<InputManager>.Instance.m_CurrentGamepad.leftStick.x.value >= 0f - CSingleton<InputManager>.Instance.m_AnalogAxisThresholdToRegisterAsUp)
			{
				CSingleton<InputManager>.Instance.m_CurrentLeftAnalogHorizontalAxis = 0f;
				return true;
			}
		}
		else if (positiveValue)
		{
			if (CSingleton<InputManager>.Instance.m_CurrentLeftAnalogVerticalAxis > 0f && CSingleton<InputManager>.Instance.m_CurrentGamepad.leftStick.y.value <= CSingleton<InputManager>.Instance.m_AnalogAxisThresholdToRegisterAsUp)
			{
				CSingleton<InputManager>.Instance.m_CurrentLeftAnalogVerticalAxis = 0f;
				return true;
			}
		}
		else if (CSingleton<InputManager>.Instance.m_CurrentLeftAnalogVerticalAxis < 0f && CSingleton<InputManager>.Instance.m_CurrentGamepad.leftStick.y.value >= 0f - CSingleton<InputManager>.Instance.m_AnalogAxisThresholdToRegisterAsUp)
		{
			CSingleton<InputManager>.Instance.m_CurrentLeftAnalogVerticalAxis = 0f;
			return true;
		}
		return false;
	}

	public static bool GetRightAnalogDown(int horizontalVerticalIndex, bool positiveValue)
	{
		if (CSingleton<InputManager>.Instance.m_CurrentGamepad == null)
		{
			return false;
		}
		if (horizontalVerticalIndex == 0)
		{
			if (positiveValue)
			{
				if (CSingleton<InputManager>.Instance.m_CurrentRightAnalogHorizontalAxis <= 0f && CSingleton<InputManager>.Instance.m_CurrentGamepad.rightStick.x.value > CSingleton<InputManager>.Instance.m_AnalogAxisThresholdToRegisterAsDown)
				{
					CSingleton<InputManager>.Instance.m_CurrentRightAnalogHorizontalAxis = 1f;
					return true;
				}
			}
			else if (CSingleton<InputManager>.Instance.m_CurrentRightAnalogHorizontalAxis >= 0f && CSingleton<InputManager>.Instance.m_CurrentGamepad.rightStick.x.value < 0f - CSingleton<InputManager>.Instance.m_AnalogAxisThresholdToRegisterAsDown)
			{
				CSingleton<InputManager>.Instance.m_CurrentRightAnalogHorizontalAxis = -1f;
				return true;
			}
		}
		else if (positiveValue)
		{
			if (CSingleton<InputManager>.Instance.m_CurrentRightAnalogVerticalAxis <= 0f && CSingleton<InputManager>.Instance.m_CurrentGamepad.rightStick.y.value > CSingleton<InputManager>.Instance.m_AnalogAxisThresholdToRegisterAsDown)
			{
				CSingleton<InputManager>.Instance.m_CurrentRightAnalogVerticalAxis = 1f;
				return true;
			}
		}
		else if (CSingleton<InputManager>.Instance.m_CurrentRightAnalogVerticalAxis >= 0f && CSingleton<InputManager>.Instance.m_CurrentGamepad.rightStick.y.value < 0f - CSingleton<InputManager>.Instance.m_AnalogAxisThresholdToRegisterAsDown)
		{
			CSingleton<InputManager>.Instance.m_CurrentRightAnalogVerticalAxis = -1f;
			return true;
		}
		return false;
	}

	public static bool GetRightAnalogUp(int horizontalVerticalIndex, bool positiveValue)
	{
		if (CSingleton<InputManager>.Instance.m_CurrentGamepad == null)
		{
			return false;
		}
		if (horizontalVerticalIndex == 0)
		{
			if (positiveValue)
			{
				if (CSingleton<InputManager>.Instance.m_CurrentRightAnalogHorizontalAxis > 0f && CSingleton<InputManager>.Instance.m_CurrentGamepad.rightStick.x.value <= CSingleton<InputManager>.Instance.m_AnalogAxisThresholdToRegisterAsUp)
				{
					CSingleton<InputManager>.Instance.m_CurrentRightAnalogHorizontalAxis = 0f;
					return true;
				}
			}
			else if (CSingleton<InputManager>.Instance.m_CurrentRightAnalogHorizontalAxis < 0f && CSingleton<InputManager>.Instance.m_CurrentGamepad.rightStick.x.value >= 0f - CSingleton<InputManager>.Instance.m_AnalogAxisThresholdToRegisterAsUp)
			{
				CSingleton<InputManager>.Instance.m_CurrentRightAnalogHorizontalAxis = 0f;
				return true;
			}
		}
		else if (positiveValue)
		{
			if (CSingleton<InputManager>.Instance.m_CurrentRightAnalogVerticalAxis > 0f && CSingleton<InputManager>.Instance.m_CurrentGamepad.rightStick.y.value <= CSingleton<InputManager>.Instance.m_AnalogAxisThresholdToRegisterAsUp)
			{
				CSingleton<InputManager>.Instance.m_CurrentRightAnalogVerticalAxis = 0f;
				return true;
			}
		}
		else if (CSingleton<InputManager>.Instance.m_CurrentRightAnalogVerticalAxis < 0f && CSingleton<InputManager>.Instance.m_CurrentGamepad.rightStick.y.value >= 0f - CSingleton<InputManager>.Instance.m_AnalogAxisThresholdToRegisterAsUp)
		{
			CSingleton<InputManager>.Instance.m_CurrentRightAnalogVerticalAxis = 0f;
			return true;
		}
		return false;
	}

	public static bool IsMovingLeftThumbstick()
	{
		if (CSingleton<InputManager>.Instance.m_CurrentGamepad == null)
		{
			return false;
		}
		return CSingleton<InputManager>.Instance.m_CurrentGamepad.leftStick.magnitude > 0f;
	}

	public static bool IsMovingRightThumbstick()
	{
		if (CSingleton<InputManager>.Instance.m_CurrentGamepad == null)
		{
			return false;
		}
		return CSingleton<InputManager>.Instance.m_CurrentGamepad.rightStick.magnitude > 0f;
	}

	private static bool GetGamepadButtonUp(EGamepadControlBtn controlBtn)
	{
		if (CSingleton<InputManager>.Instance.m_CurrentGamepad == null)
		{
			return false;
		}
		return controlBtn switch
		{
			EGamepadControlBtn.X => CSingleton<InputManager>.Instance.m_CurrentGamepad.buttonSouth.wasReleasedThisFrame, 
			EGamepadControlBtn.O => CSingleton<InputManager>.Instance.m_CurrentGamepad.buttonEast.wasReleasedThisFrame, 
			EGamepadControlBtn.Square => CSingleton<InputManager>.Instance.m_CurrentGamepad.buttonWest.wasReleasedThisFrame, 
			EGamepadControlBtn.Triangle => CSingleton<InputManager>.Instance.m_CurrentGamepad.buttonNorth.wasReleasedThisFrame, 
			EGamepadControlBtn.L1 => CSingleton<InputManager>.Instance.m_CurrentGamepad.leftShoulder.wasReleasedThisFrame, 
			EGamepadControlBtn.R1 => CSingleton<InputManager>.Instance.m_CurrentGamepad.rightShoulder.wasReleasedThisFrame, 
			EGamepadControlBtn.L2 => CSingleton<InputManager>.Instance.m_CurrentGamepad.leftTrigger.wasReleasedThisFrame, 
			EGamepadControlBtn.R2 => CSingleton<InputManager>.Instance.m_CurrentGamepad.rightTrigger.wasReleasedThisFrame, 
			EGamepadControlBtn.L3 => CSingleton<InputManager>.Instance.m_CurrentGamepad.leftStickButton.wasReleasedThisFrame, 
			EGamepadControlBtn.R3 => CSingleton<InputManager>.Instance.m_CurrentGamepad.rightStickButton.wasReleasedThisFrame, 
			EGamepadControlBtn.DpadLeft => CSingleton<InputManager>.Instance.m_CurrentGamepad.dpad.left.wasReleasedThisFrame, 
			EGamepadControlBtn.DpadRight => CSingleton<InputManager>.Instance.m_CurrentGamepad.dpad.right.wasReleasedThisFrame, 
			EGamepadControlBtn.DpadUp => CSingleton<InputManager>.Instance.m_CurrentGamepad.dpad.up.wasReleasedThisFrame, 
			EGamepadControlBtn.DpadDown => CSingleton<InputManager>.Instance.m_CurrentGamepad.dpad.down.wasReleasedThisFrame, 
			EGamepadControlBtn.LStickLeft => false, 
			EGamepadControlBtn.LStickRight => false, 
			EGamepadControlBtn.LStickUp => false, 
			EGamepadControlBtn.LStickDown => false, 
			EGamepadControlBtn.RStickLeft => false, 
			EGamepadControlBtn.RStickRight => false, 
			EGamepadControlBtn.RStickUp => false, 
			EGamepadControlBtn.RStickDown => false, 
			EGamepadControlBtn.Start => CSingleton<InputManager>.Instance.m_CurrentGamepad.startButton.wasReleasedThisFrame, 
			EGamepadControlBtn.Select => CSingleton<InputManager>.Instance.m_CurrentGamepad.selectButton.wasReleasedThisFrame, 
			EGamepadControlBtn.Home => false, 
			_ => false, 
		};
	}

	private static bool GetGamepadButtonDown(EGamepadControlBtn controlBtn)
	{
		if (CSingleton<InputManager>.Instance.m_CurrentGamepad == null)
		{
			return false;
		}
		return controlBtn switch
		{
			EGamepadControlBtn.X => CSingleton<InputManager>.Instance.m_CurrentGamepad.buttonSouth.wasPressedThisFrame, 
			EGamepadControlBtn.O => CSingleton<InputManager>.Instance.m_CurrentGamepad.buttonEast.wasPressedThisFrame, 
			EGamepadControlBtn.Square => CSingleton<InputManager>.Instance.m_CurrentGamepad.buttonWest.wasPressedThisFrame, 
			EGamepadControlBtn.Triangle => CSingleton<InputManager>.Instance.m_CurrentGamepad.buttonNorth.wasPressedThisFrame, 
			EGamepadControlBtn.L1 => CSingleton<InputManager>.Instance.m_CurrentGamepad.leftShoulder.wasPressedThisFrame, 
			EGamepadControlBtn.R1 => CSingleton<InputManager>.Instance.m_CurrentGamepad.rightShoulder.wasPressedThisFrame, 
			EGamepadControlBtn.L2 => CSingleton<InputManager>.Instance.m_CurrentGamepad.leftTrigger.wasPressedThisFrame, 
			EGamepadControlBtn.R2 => CSingleton<InputManager>.Instance.m_CurrentGamepad.rightTrigger.wasPressedThisFrame, 
			EGamepadControlBtn.L3 => CSingleton<InputManager>.Instance.m_CurrentGamepad.leftStickButton.wasPressedThisFrame, 
			EGamepadControlBtn.R3 => CSingleton<InputManager>.Instance.m_CurrentGamepad.rightStickButton.wasPressedThisFrame, 
			EGamepadControlBtn.DpadLeft => CSingleton<InputManager>.Instance.m_CurrentGamepad.dpad.left.wasPressedThisFrame, 
			EGamepadControlBtn.DpadRight => CSingleton<InputManager>.Instance.m_CurrentGamepad.dpad.right.wasPressedThisFrame, 
			EGamepadControlBtn.DpadUp => CSingleton<InputManager>.Instance.m_CurrentGamepad.dpad.up.wasPressedThisFrame, 
			EGamepadControlBtn.DpadDown => CSingleton<InputManager>.Instance.m_CurrentGamepad.dpad.down.wasPressedThisFrame, 
			EGamepadControlBtn.LStickLeft => false, 
			EGamepadControlBtn.LStickRight => false, 
			EGamepadControlBtn.LStickUp => false, 
			EGamepadControlBtn.LStickDown => false, 
			EGamepadControlBtn.RStickLeft => false, 
			EGamepadControlBtn.RStickRight => false, 
			EGamepadControlBtn.RStickUp => false, 
			EGamepadControlBtn.RStickDown => false, 
			EGamepadControlBtn.Start => CSingleton<InputManager>.Instance.m_CurrentGamepad.startButton.wasPressedThisFrame, 
			EGamepadControlBtn.Select => CSingleton<InputManager>.Instance.m_CurrentGamepad.selectButton.wasPressedThisFrame, 
			EGamepadControlBtn.Home => false, 
			_ => false, 
		};
	}

	private static bool GetGamepadButtonHold(EGamepadControlBtn controlBtn)
	{
		if (CSingleton<InputManager>.Instance.m_CurrentGamepad == null)
		{
			return false;
		}
		return controlBtn switch
		{
			EGamepadControlBtn.X => CSingleton<InputManager>.Instance.m_CurrentGamepad.buttonSouth.isPressed, 
			EGamepadControlBtn.O => CSingleton<InputManager>.Instance.m_CurrentGamepad.buttonEast.isPressed, 
			EGamepadControlBtn.Square => CSingleton<InputManager>.Instance.m_CurrentGamepad.buttonWest.isPressed, 
			EGamepadControlBtn.Triangle => CSingleton<InputManager>.Instance.m_CurrentGamepad.buttonNorth.isPressed, 
			EGamepadControlBtn.L1 => CSingleton<InputManager>.Instance.m_CurrentGamepad.leftShoulder.isPressed, 
			EGamepadControlBtn.R1 => CSingleton<InputManager>.Instance.m_CurrentGamepad.rightShoulder.isPressed, 
			EGamepadControlBtn.L2 => CSingleton<InputManager>.Instance.m_CurrentGamepad.leftTrigger.isPressed, 
			EGamepadControlBtn.R2 => CSingleton<InputManager>.Instance.m_CurrentGamepad.rightTrigger.isPressed, 
			EGamepadControlBtn.L3 => CSingleton<InputManager>.Instance.m_CurrentGamepad.leftStickButton.isPressed, 
			EGamepadControlBtn.R3 => CSingleton<InputManager>.Instance.m_CurrentGamepad.rightStickButton.isPressed, 
			EGamepadControlBtn.DpadLeft => CSingleton<InputManager>.Instance.m_CurrentGamepad.dpad.left.isPressed, 
			EGamepadControlBtn.DpadRight => CSingleton<InputManager>.Instance.m_CurrentGamepad.dpad.right.isPressed, 
			EGamepadControlBtn.DpadUp => CSingleton<InputManager>.Instance.m_CurrentGamepad.dpad.up.isPressed, 
			EGamepadControlBtn.DpadDown => CSingleton<InputManager>.Instance.m_CurrentGamepad.dpad.down.isPressed, 
			EGamepadControlBtn.LStickLeft => false, 
			EGamepadControlBtn.LStickRight => false, 
			EGamepadControlBtn.LStickUp => false, 
			EGamepadControlBtn.LStickDown => false, 
			EGamepadControlBtn.RStickLeft => false, 
			EGamepadControlBtn.RStickRight => false, 
			EGamepadControlBtn.RStickUp => false, 
			EGamepadControlBtn.RStickDown => false, 
			EGamepadControlBtn.Start => CSingleton<InputManager>.Instance.m_CurrentGamepad.startButton.isPressed, 
			EGamepadControlBtn.Select => CSingleton<InputManager>.Instance.m_CurrentGamepad.selectButton.isPressed, 
			EGamepadControlBtn.Home => false, 
			_ => false, 
		};
	}

	private static EGamepadControlBtn GetGamepadControlBtnEnum()
	{
		if (CSingleton<InputManager>.Instance.m_CurrentGamepad == null)
		{
			return EGamepadControlBtn.None;
		}
		if (CSingleton<InputManager>.Instance.m_CurrentGamepad.buttonSouth.wasPressedThisFrame)
		{
			return EGamepadControlBtn.X;
		}
		if (CSingleton<InputManager>.Instance.m_CurrentGamepad.buttonEast.wasPressedThisFrame)
		{
			return EGamepadControlBtn.O;
		}
		if (CSingleton<InputManager>.Instance.m_CurrentGamepad.buttonWest.wasPressedThisFrame)
		{
			return EGamepadControlBtn.Square;
		}
		if (CSingleton<InputManager>.Instance.m_CurrentGamepad.buttonNorth.wasPressedThisFrame)
		{
			return EGamepadControlBtn.Triangle;
		}
		if (CSingleton<InputManager>.Instance.m_CurrentGamepad.leftShoulder.wasPressedThisFrame)
		{
			return EGamepadControlBtn.L1;
		}
		if (CSingleton<InputManager>.Instance.m_CurrentGamepad.rightShoulder.wasPressedThisFrame)
		{
			return EGamepadControlBtn.R1;
		}
		if (CSingleton<InputManager>.Instance.m_CurrentGamepad.leftTrigger.wasPressedThisFrame)
		{
			return EGamepadControlBtn.L2;
		}
		if (CSingleton<InputManager>.Instance.m_CurrentGamepad.rightTrigger.wasPressedThisFrame)
		{
			return EGamepadControlBtn.R2;
		}
		if (CSingleton<InputManager>.Instance.m_CurrentGamepad.leftStickButton.wasPressedThisFrame)
		{
			return EGamepadControlBtn.L3;
		}
		if (CSingleton<InputManager>.Instance.m_CurrentGamepad.rightStickButton.wasPressedThisFrame)
		{
			return EGamepadControlBtn.R3;
		}
		if (CSingleton<InputManager>.Instance.m_CurrentGamepad.dpad.left.wasPressedThisFrame)
		{
			return EGamepadControlBtn.DpadLeft;
		}
		if (CSingleton<InputManager>.Instance.m_CurrentGamepad.dpad.right.wasPressedThisFrame)
		{
			return EGamepadControlBtn.DpadRight;
		}
		if (CSingleton<InputManager>.Instance.m_CurrentGamepad.dpad.up.wasPressedThisFrame)
		{
			return EGamepadControlBtn.DpadUp;
		}
		if (CSingleton<InputManager>.Instance.m_CurrentGamepad.dpad.down.wasPressedThisFrame)
		{
			return EGamepadControlBtn.DpadDown;
		}
		if (CSingleton<InputManager>.Instance.m_CurrentGamepad.startButton.wasPressedThisFrame)
		{
			return EGamepadControlBtn.Start;
		}
		if (CSingleton<InputManager>.Instance.m_CurrentGamepad.selectButton.wasPressedThisFrame)
		{
			return EGamepadControlBtn.Select;
		}
		return EGamepadControlBtn.None;
	}

	public static KeyCode GetBaseKeycodeBind(EGameBaseKey gameBaseKey)
	{
		for (int i = 0; i < m_KeybindBaseKeyList.Count; i++)
		{
			if (m_KeybindBaseKeyList[i].baseKey == gameBaseKey)
			{
				return m_KeybindBaseKeyList[i].bindKey;
			}
		}
		return KeyCode.None;
	}

	public static EGamepadControlBtn GetBaseGamepadBtnBind(EGameBaseKey gameBaseKey)
	{
		for (int i = 0; i < m_KeybindBaseJoystickCtrlList.Count; i++)
		{
			if (m_KeybindBaseJoystickCtrlList[i].baseKey == gameBaseKey)
			{
				return m_KeybindBaseJoystickCtrlList[i].ctrlBtn;
			}
		}
		return EGamepadControlBtn.None;
	}

	public static void UpdateKeybind(EGameBaseKey gameBaseKey, KeyCode newKey)
	{
		for (int i = 0; i < m_KeybindBaseKeyList.Count; i++)
		{
			if (m_KeybindBaseKeyList[i].baseKey == gameBaseKey)
			{
				m_KeybindBaseKeyList[i].bindKey = newKey;
			}
		}
	}

	public static void UpdateGamepadKeybind(EGameBaseKey gameBaseKey, EGamepadControlBtn ctrlBtn)
	{
		for (int i = 0; i < m_KeybindBaseJoystickCtrlList.Count; i++)
		{
			if (m_KeybindBaseJoystickCtrlList[i].baseKey == gameBaseKey)
			{
				m_KeybindBaseJoystickCtrlList[i].ctrlBtn = ctrlBtn;
			}
		}
	}

	public static string GetGamepadButtonName(EGamepadControlBtn gamepadControlBtn)
	{
		return "";
	}

	public static string GetKeycodeName(KeyCode keycode)
	{
		return keycode.ToString();
	}

	public static bool HasKeybindChanges()
	{
		return CSingleton<InputManager>.Instance.m_HasKeybindChanges;
	}

	public static bool IsSliderActive()
	{
		return CSingleton<InputManager>.Instance.m_IsSliderActive;
	}

	public static void SetSliderActive(bool isActive)
	{
		CSingleton<InputManager>.Instance.m_IsSliderActive = isActive;
	}

	public static void SetCursorLockMode(CursorLockMode cursorLockMode)
	{
		CSingleton<InputManager>.Instance.m_CurrentCursorLockMode = cursorLockMode;
		if (cursorLockMode != CursorLockMode.Confined)
		{
			Cursor.lockState = cursorLockMode;
		}
		else if (CSingleton<CGameManager>.Instance.m_CanConfineMouseCursor)
		{
			Cursor.lockState = CursorLockMode.Confined;
		}
		else
		{
			Cursor.lockState = CursorLockMode.None;
		}
	}

	public static CursorLockMode GetCursorLockMode()
	{
		return CSingleton<InputManager>.Instance.m_CurrentCursorLockMode;
	}
}
