using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using __Project__.Scripts.ControllerInputModule;

public class MainMenuManager : MonoBehaviour
{
	[SerializeField]
	private Button m_ContinueButton;

	[SerializeField]
	private GameObject m_ApproveNewGameMenu;

	[SerializeField]
	private SettingsMenuManager m_SettingsMenu;

	[SerializeField]
	private SettingsMenuManager m_XboxSettingsMenu;

	[SerializeField]
	private List<GameObject> m_NonXboxObjects;

	[SerializeField]
	private GamePadUIPanel m_GamePadUIPanel;

	[SerializeField]
	private SaveSlotsPanel m_LoadPanel;

	[SerializeField]
	private Button m_LoadButton;

	public GamePadUIPanel GamePadUIPanel => null;

	private void Awake()
	{
	}

	private void LoadSaveProgress()
	{
	}

	private void Start()
	{
	}

	private void SwitchNonConsoleObjects(bool val)
	{
	}

	private void OnDestroy()
	{
	}

	private void SetCursor(bool isGamepad)
	{
	}

	public void Load()
	{
	}

	public void Continue()
	{
	}

	public void DisapproveNewGame()
	{
	}

	public void NewGame()
	{
	}

	public void Settings()
	{
	}

	public void Quit()
	{
	}
}
