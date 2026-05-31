using System.Collections.Generic;
using ExitGames.Client.Photon;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using __Project__.Scripts.ControllerInputModule;

public class RoomSettingsManager : NoktaSingleton<RoomSettingsManager>
{
	[SerializeField]
	private Transform playerParentObject;

	[SerializeField]
	private RoomInfoPlayer playerPrefab;

	[SerializeField]
	private GameObject roomInfoPanel;

	[SerializeField]
	private TextMeshProUGUI roomCode;

	[SerializeField]
	private TextMeshProUGUI roomRegion;

	[SerializeField]
	private Button showButton;

	[SerializeField]
	private Button hideButton;

	[SerializeField]
	private Button copyButton;

	private bool m_IsRoomCodeShowing;

	private bool m_RoomMenuEnabled;

	private readonly Dictionary<string, RoomInfoPlayer> _roomInfoPlayers;

	[SerializeField]
	private GamePadUIPanel m_GamepadUIPanel;

	[SerializeField]
	private WindowTab m_Tab;

	[SerializeField]
	private GamepadSelectableParent m_GamepadSelectableParent;

	public bool RoomMenuEnabled => false;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	public void RoomInfoPanelSetActive(bool stat)
	{
	}

	public void UpdateList(bool isFromSetActive = false)
	{
	}

	public void OnPlayerPropertiesUpdateHook(Player target, Hashtable changed)
	{
	}

	private static ulong ConvertToUlong(object v)
	{
		return 0uL;
	}

	public void ShowRoomCode()
	{
	}

	public void HideRoomCode()
	{
	}

	public void CopyRoomCode()
	{
	}

	private void ShowRoomRegion()
	{
	}

	public void CopyCodeToClipboard(string code)
	{
	}

	private void ClearPlayerPrefabList()
	{
	}

	private void SetupGamepad(bool willOpen)
	{
	}

	public void RefreshGamepad(bool isConnected = true)
	{
	}

	public void GamepadBack()
	{
	}

	public void ToggleRoomCodeVisibility()
	{
	}

	public void RemoveFromUIList(string userId)
	{
	}
}
