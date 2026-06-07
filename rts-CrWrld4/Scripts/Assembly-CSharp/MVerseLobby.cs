using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MVerseLobby : MonoBehaviour
{
	public GameObject beginButton;

	public GameObject waitingOnHostText;

	public MVerseChatPane chatControl;

	public MVerseLobbyBadge[] lobbyBadges;

	public GameObject steamFriends;

	public GameObject controlsSections;

	public GameObject buttons;

	public TMP_InputField manualInviteCodeTextField;

	private int hideUIOverrideInitialVal;

	private bool hosting;

	private bool started;

	private bool disconnecting;

	private HashSet<string> activePlayerNames;

	public void OnEnable()
	{
	}

	public void Init()
	{
	}

	public void OnDisable()
	{
	}

	public void OnBegin()
	{
	}

	public void OnCancel()
	{
	}

	public void OnCopyToClipboadInviteKey()
	{
	}

	public void OnAutoIPAddress()
	{
	}

	public void OnInviteSteamFriends()
	{
	}

	public void Update()
	{
	}
}
