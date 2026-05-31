using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using __Project__.Scripts.ControllerInputModule;

public class EscapeMenuManager : NoktaSingleton<EscapeMenuManager>
{
	[SerializeField]
	private GameObject m_Menu;

	[SerializeField]
	private List<GameObject> m_NonXboxObjects;

	[SerializeField]
	private Button m_SaveButton;

	public SettingsMenuManager settingsMenu;

	public SettingsMenuManager xboxSettingsMenu;

	public RoomSettingsManager roomSettingsMenu;

	public GameObject firstObject;

	public GamePadUIPanel gamepadPanel;

	public bool isSaving;

	private bool m_Paused;

	private bool m_SubscribedOnCancel;

	private bool m_IsMaster;

	private GameObject m_FocusedObjectBeforeOpen;

	private bool m_CachedMovementInteraction;

	private bool m_CachedCameraInteraction;

	private bool m_CachedCursorVisibility;

	private CursorLockMode m_CachedCursorLockMode;

	private bool m_OpenEscapeMenu;

	private bool OpenEscapeMenu
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool IsPauseMenuOpened => false;

	public void SetPreviouslyFocusedObject(GameObject objectToSet)
	{
	}

	private void Awake()
	{
	}

	private void SwitchNonXboxObjects()
	{
	}

	private void OnApplicationFocused(bool b)
	{
	}

	private void PauseGameOnDisconnect(bool isGamepad)
	{
	}

	private void SetCursor(bool isGamepad)
	{
	}

	private void OnEnable()
	{
	}

	private void AddListeners(PlayerInstance playerInstance)
	{
	}

	private void OnDisable()
	{
	}

	public void Continue()
	{
	}

	public void Settings()
	{
	}

	public void Save()
	{
	}

	public void MainMenu()
	{
	}

	public void Quit()
	{
	}

	private void Pause()
	{
	}

	private void RemoveInputListeners()
	{
	}

	private void OnDestroy()
	{
	}
}
