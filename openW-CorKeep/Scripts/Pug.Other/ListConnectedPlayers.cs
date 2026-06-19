using System;
using System.Collections.Generic;
using System.Linq;
using Pug.UnityExtensions;
using Unity.Mathematics;
using UnityEngine;

public class ListConnectedPlayers : RadicalMenuOption, IScrollable
{
	public struct PlayerUIEntry
	{
		public readonly PlayerController pc;

		public readonly string playerName;

		public readonly int banIndex;

		public readonly int adminIndex;

		public readonly int adminPrivileges;

		public readonly PlatformUserID platformUserId;

		public bool isAdmin
		{
			get
			{
				if (adminIndex == -1)
				{
					if (pc != null)
					{
						return pc.adminPrivileges != 0;
					}
					return false;
				}
				return true;
			}
		}

		public PlayerUIEntry(PlayerController pc, string playerName, int banIndex, int adminIndex, int adminPrivileges, PlatformUserID platformUserId = null)
		{
			this.pc = pc;
			this.playerName = playerName;
			this.banIndex = banIndex;
			this.adminIndex = adminIndex;
			this.adminPrivileges = adminPrivileges;
			this.platformUserId = platformUserId ?? pc?.platformID ?? new PlatformUserID();
		}

		public Color GetPlayerColor(bool ignoreTeamColor = false)
		{
			if (pc != null)
			{
				return pc.GetPlayerColor(ignoreTeamColor);
			}
			return Color.white;
		}

		public Color GetTeamColor()
		{
			if (pc != null)
			{
				return pc.GetTeamColor();
			}
			return Color.white;
		}
	}

	private class InviteeInfo
	{
		public PlatformUserID UserId;

		public string UserName;

		public InviteeInfo(PlatformUserID userId, string userName)
		{
			UserId = userId;
			UserName = userName;
		}
	}

	private const int maxPlayerCount = 8;

	private const int maxShownPlayerCount = 100;

	public PlayersListType menuType;

	public GameObject playerEntryPrefab;

	public GameObject infoText;

	public Transform playerEntriesParent;

	public List<PlayerListEntry> players;

	public UIScrollWindow scrollWindow;

	public TogglePvPButton togglePvPButton;

	[Tooltip("How many player names to show per page. Leave 0 for unlimited. Currently implemented only for invite mode.")]
	public int playersPerPage;

	[SerializeField]
	private PugText _pageLabel;

	[SerializeField]
	private bool _useUserName;

	private SortedList<int, PlayerUIEntry> sortedPlayers = new SortedList<int, PlayerUIEntry>();

	private int _currentPage;

	private readonly Direction.Id[] ON_DISABLE_MOVE_DIRECTIONS = new Direction.Id[3]
	{
		Direction.Id.forward,
		Direction.Id.back,
		Direction.Id.left
	};

	private PlayerListEntry playerElementToSelect;

	private UIelement lastSelectedPlayerButton;

	private InviteeInfo _invitee;

	protected override void Awake()
	{
		if (infoText != null)
		{
			infoText.GetComponent<PugText>().formatFields = new string[1] { 8.ToString() };
		}
	}

	public override void OnActivated()
	{
		base.OnActivated();
		if (Manager.ui.currentSelectedUIElement is PlayerListEntryButton playerListEntryButton)
		{
			playerListEntryButton.OnLeftClicked(mod1: false, mod2: false);
		}
	}

	public override void OnParentMenuActivation()
	{
		base.OnParentMenuActivation();
		_currentPage = 0;
		if (menuType == PlayersListType.SEND_INVITE && Manager.platform.PlatformFriends != null)
		{
			int num = Mathf.CeilToInt((float)Manager.platform.PlatformFriends.Count / (float)playersPerPage);
			if (_pageLabel != null)
			{
				_pageLabel.Render($"{_currentPage + 1} / {num}");
			}
		}
	}

	public override void OnSelected()
	{
		base.OnSelected();
		Update();
		if (playerElementToSelect == null && players.Count > 0)
		{
			playerElementToSelect = players[0];
		}
		if (playerElementToSelect != null)
		{
			if (playerElementToSelect.adminButton.gameObject.activeSelf)
			{
				lastSelectedPlayerButton = playerElementToSelect.adminButton;
			}
			else
			{
				lastSelectedPlayerButton = playerElementToSelect.banButton;
			}
			lastSelectedPlayerButton.Select();
		}
		else
		{
			lastSelectedPlayerButton = null;
		}
	}

	public override void OnPreSelected(UIelement previousInternalOption)
	{
		base.OnPreSelected(previousInternalOption);
		if (!(previousInternalOption != null))
		{
			return;
		}
		Update();
		playerElementToSelect = null;
		float num = float.MaxValue;
		foreach (PlayerListEntry player in players)
		{
			float num2 = math.distancesq(previousInternalOption.transform.position, player.transform.position);
			if (num2 < num)
			{
				num = num2;
				playerElementToSelect = player;
			}
		}
	}

	public override UIelement GetInternalOption()
	{
		if (lastSelectedPlayerButton != null)
		{
			return lastSelectedPlayerButton;
		}
		return base.GetInternalOption();
	}

	public override bool NavigateInternally(Direction.Id id)
	{
		UIelement uIelement = null;
		if (Manager.ui.currentSelectedUIElement != null && Manager.ui.currentSelectedUIElement is PlayerListEntryButton playerListEntryButton)
		{
			uIelement = playerListEntryButton.GetAdjacentUIElement(id, playerListEntryButton.transform.position);
			if (uIelement is PlayerListEntryButton)
			{
				lastSelectedPlayerButton = uIelement;
			}
		}
		if (uIelement != null)
		{
			uIelement.Select();
			return true;
		}
		return false;
	}

	protected override void Update()
	{
		sortedPlayers.Clear();
		if (_invitee == null && menuType == PlayersListType.SEND_INVITE)
		{
			if (Manager.input.IsMenuLeftButtonDown())
			{
				ChangePage(_currentPage - 1);
			}
			else if (Manager.input.IsMenuRightButtonDown())
			{
				ChangePage(_currentPage + 1);
			}
		}
		NetworkCommandClientSystem networkCommandClientSystem = Manager.ecs.ClientWorld?.GetExistingSystemManaged<NetworkCommandClientSystem>();
		if (menuType == PlayersListType.UNBAN)
		{
			if (Manager.ecs.ClientWorld != null)
			{
				foreach (NetworkCommandClientSystem.PlayerEntry bannedPlayer in networkCommandClientSystem.bannedPlayers)
				{
					if (!sortedPlayers.TryAdd(bannedPlayer.index, new PlayerUIEntry(null, bannedPlayer.name, bannedPlayer.index, -1, bannedPlayer.privileges, new PlatformUserID(bannedPlayer.onlineId))))
					{
						Debug.LogError(string.Format("{0}: trying to add an already existing key {1} as banned. Player entry is for player name {2} with online id of {3}.", "ListConnectedPlayers", bannedPlayer.index, bannedPlayer.name, bannedPlayer.onlineId));
					}
				}
			}
		}
		else if (menuType == PlayersListType.UNASSIGN_ADMIN)
		{
			if (Manager.ecs.ClientWorld != null)
			{
				foreach (NetworkCommandClientSystem.PlayerEntry adminPlayer in networkCommandClientSystem.adminPlayers)
				{
					if (!sortedPlayers.TryAdd(adminPlayer.index, new PlayerUIEntry(null, adminPlayer.name, -1, adminPlayer.index, adminPlayer.privileges, new PlatformUserID(adminPlayer.onlineId))))
					{
						Debug.LogError(string.Format("{0}: trying to add an already existing key {1} as admin. Player entry is for player name {2} with online id of {3}.", "ListConnectedPlayers", adminPlayer.index, adminPlayer.name, adminPlayer.onlineId));
					}
				}
			}
		}
		else if (menuType == PlayersListType.ACTIVE_PLAYERS)
		{
			foreach (PlayerController allPlayer in Manager.main.allPlayers)
			{
				if (allPlayer.playerIndex > 0 && !sortedPlayers.TryAdd(allPlayer.playerIndex, new PlayerUIEntry(allPlayer, allPlayer.playerName, -1, -1, allPlayer.adminPrivileges)))
				{
					Debug.LogError(string.Format("{0}: trying to add an already existing key {1} as an active player. Player entry is for player name {2}.", "ListConnectedPlayers", allPlayer.playerIndex, allPlayer.name));
				}
			}
			if (Time.timeScale == 0f && sortedPlayers.Count > 1)
			{
				sortedPlayers.Clear();
				PlayerController player = Manager.main.player;
				if (!sortedPlayers.TryAdd(player.playerIndex, new PlayerUIEntry(player, player.playerName, -1, -1, player.adminPrivileges)))
				{
					Debug.LogError(string.Format("{0}: trying to add an already existing key {1} as an active player (pause fix). Player entry is for player name {2}.", "ListConnectedPlayers", player.playerIndex, player.playerName));
				}
			}
		}
		else if (menuType == PlayersListType.SEND_INVITE)
		{
			List<PlatformUserID> list = Manager.platform.PlatformFriends.Skip(_currentPage * playersPerPage).Take(playersPerPage).ToList();
			for (int i = 0; i < list.Count; i++)
			{
				PlatformUserID platformUserID = list[i];
				if (!sortedPlayers.TryAdd(i, new PlayerUIEntry(null, "...", -1, -1, -1, platformUserID)))
				{
					Debug.LogError(string.Format("{0}: trying to add an already existing key {1} as an online friend for invite. Player entry is for player online id {2}.", "ListConnectedPlayers", i, platformUserID.GetPlatformOnlineId()));
				}
			}
		}
		for (int num = players.Count - 1; num >= sortedPlayers.Count; num--)
		{
			if (Manager.ui.currentSelectedUIElement == players[num].adminButton || Manager.ui.currentSelectedUIElement == players[num].banButton)
			{
				UIelement uIelement = null;
				Direction.Id[] oN_DISABLE_MOVE_DIRECTIONS = ON_DISABLE_MOVE_DIRECTIONS;
				foreach (Direction.Id dir in oN_DISABLE_MOVE_DIRECTIONS)
				{
					uIelement = Manager.ui.currentSelectedUIElement.GetAdjacentUIElement(dir, Manager.ui.currentSelectedUIElement.transform.position);
					if ((bool)uIelement)
					{
						if (uIelement is PlayerListEntryButton)
						{
							lastSelectedPlayerButton = uIelement;
						}
						uIelement.Select();
						break;
					}
				}
			}
			UnityEngine.Object.Destroy(players[num].gameObject);
			players.RemoveAt(num);
		}
		for (int k = 0; k < players.Count; k++)
		{
			players[k].Init(sortedPlayers.Values[k], this, menuType, togglePvPButton != null && togglePvPButton.currentPvPSetting, _useUserName);
		}
		for (int l = players.Count; l < Mathf.Min(100, sortedPlayers.Count); l++)
		{
			PlayerListEntry component = UnityEngine.Object.Instantiate(playerEntryPrefab, playerEntriesParent).GetComponent<PlayerListEntry>();
			Transform obj = component.transform;
			Vector3 localPosition = obj.localPosition;
			localPosition.y -= l;
			obj.localPosition = localPosition;
			component.Init(sortedPlayers.Values[l], this, menuType, togglePvPButton != null && togglePvPButton.currentPvPSetting, _useUserName);
			players.Add(component);
		}
		infoText?.SetActive((menuType == PlayersListType.ACTIVE_PLAYERS && sortedPlayers.Count > 8) || (menuType == PlayersListType.UNBAN && sortedPlayers.Count == 0) || (menuType == PlayersListType.UNASSIGN_ADMIN && sortedPlayers.Count == 0) || (menuType == PlayersListType.SEND_INVITE && sortedPlayers.Count == 0));
		UpdateNavigation();
	}

	private void UpdateNavigation()
	{
		PlayerListEntry playerListEntry = null;
		for (int i = 0; i < players.Count; i++)
		{
			players[i].banButton.topUIElements.Clear();
			players[i].banButton.bottomUIElements.Clear();
			players[i].adminButton.topUIElements.Clear();
			players[i].adminButton.bottomUIElements.Clear();
			players[i].inviteButton.topUIElements.Clear();
			players[i].inviteButton.bottomUIElements.Clear();
			players[i].pvpTeamButton.bottomUIElements.Clear();
			if (playerListEntry != null)
			{
				players[i].banButton.topUIElements.Add(playerListEntry.banButton);
				playerListEntry.banButton.bottomUIElements.Add(players[i].banButton);
				players[i].adminButton.topUIElements.Add(playerListEntry.adminButton);
				playerListEntry.adminButton.bottomUIElements.Add(players[i].adminButton);
				players[i].inviteButton.topUIElements.Add(playerListEntry.inviteButton);
				playerListEntry.inviteButton.bottomUIElements.Add(players[i].inviteButton);
				players[i].showPlayerInfoButton.topUIElements.Add(playerListEntry.showPlayerInfoButton);
				playerListEntry.showPlayerInfoButton.bottomUIElements.Add(players[i].showPlayerInfoButton);
				players[i].pvpTeamButton.topUIElements.Add(playerListEntry.pvpTeamButton);
				playerListEntry.pvpTeamButton.bottomUIElements.Add(players[i].pvpTeamButton);
			}
			playerListEntry = players[i];
		}
	}

	public void UpdateContainingElements(float scroll)
	{
	}

	public bool IsBottomElementSelected()
	{
		if (players.Count > 0)
		{
			if (!(Manager.ui.currentSelectedUIElement == players[players.Count - 1].adminButton) && !(Manager.ui.currentSelectedUIElement == players[players.Count - 1].banButton))
			{
				return Manager.ui.currentSelectedUIElement == players[players.Count - 1].inviteButton;
			}
			return true;
		}
		return false;
	}

	public bool IsTopElementSelected()
	{
		if (players.Count > 0)
		{
			if (!(Manager.ui.currentSelectedUIElement == players[0].adminButton) && !(Manager.ui.currentSelectedUIElement == players[0].banButton))
			{
				return Manager.ui.currentSelectedUIElement == players[0].inviteButton;
			}
			return true;
		}
		return false;
	}

	public float GetCurrentWindowHeight()
	{
		if (players.Count > 0)
		{
			return players[0].transform.position.y - players[players.Count - 1].transform.position.y + 1.25f;
		}
		return 0f;
	}

	public UIScrollWindow GetScrollWindow()
	{
		return scrollWindow;
	}

	public void ChangePage(int pageIndex)
	{
		if (players.Any((PlayerListEntry p) => p.IsProcessingName))
		{
			Debug.LogWarning("ListConnectedPlayers: some user entries are still updating player names. We need to wait until those are completed before changing to a new page.");
		}
		else
		{
			if (Manager.platform.PlatformFriends == null)
			{
				return;
			}
			int num = Mathf.CeilToInt((float)Manager.platform.PlatformFriends.Count / (float)playersPerPage);
			if (num != 0)
			{
				int currentPage = _currentPage;
				_currentPage = Math.Clamp(pageIndex, 0, num - 1);
				if (currentPage != _currentPage && players.Count > 0)
				{
					players[0].GetFirstActiveButton().Select();
				}
				if (_pageLabel != null)
				{
					_pageLabel.Render($"{_currentPage + 1} / {num}");
				}
			}
		}
	}

	public void SendInvite(PlatformUserID playerPlatformUserId, string playerName)
	{
		string text = "Consoles/ConfirmSendInvites";
		List<string> options = new List<string> { "cancelDialogue", "yes" };
		_invitee = new InviteeInfo(playerPlatformUserId, playerName);
		Manager.menu.centerPopUpText.StartNewDisplaySequence(text, optionsCallback: PopupSendInvitesConfirmation, formatFields: new string[1] { playerName }, menuInputCooldown: true, fadeTime: 0f, staticTime: 1.5f, useUnscaledTime: true, yPosition: 0f, textBackgroundAlpha: 1f, localize: true, fontFace: TextManager.FontFace.boldMedium, options: options, minWidth: 10f, backgroundAlpha: 0.95f, priority: 0, textMaxWidth: 18f, secondOptionPopsAllMenus: false, pauseGame: true, holdToConfirm: false, localizePlaceholders: false);
	}

	private void PopupSendInvitesConfirmation(PopupResponse response)
	{
		if (response.IsCancel)
		{
			_invitee = null;
			return;
		}
		Manager.input.DisableSystemInput();
		List<PlatformUserID> list = new List<PlatformUserID>();
		list.Add(_invitee.UserId);
		Manager.networking.SendSessionInvitations(list, delegate(bool sendSuccessful)
		{
			Manager.input.EnableSystemInput();
			string text = (sendSuccessful ? "Consoles/InvitesSent" : "Consoles/InvitesFailed");
			List<string> options = new List<string> { "ok" };
			Manager.menu.centerPopUpText.StartNewDisplaySequence(text, new string[1] { _invitee.UserName }, menuInputCooldown: true, 0f, 1.5f, useUnscaledTime: true, 0f, 1f, localize: true, TextManager.FontFace.boldMedium, delegate
			{
				_invitee = null;
			}, options, 10f, 0.95f, 0, 18f, secondOptionPopsAllMenus: false, pauseGame: true, holdToConfirm: false, localizePlaceholders: false);
		});
	}
}
