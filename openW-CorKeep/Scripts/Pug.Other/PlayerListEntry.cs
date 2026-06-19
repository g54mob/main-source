using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerListEntry : UIelement
{
	public string realCurrentName;

	public PugText nameText;

	public PlayerListEntryButton adminButton;

	public PlayerListEntryButton banButton;

	public PlayerListEntryButton inviteButton;

	public PlayerListEntryButton showPlayerInfoButton;

	public PlayerListEntryButton pvpTeamButton;

	public Sprite isAdminSprite;

	public Sprite isNotAdminSprite;

	private PlayersListType playersListType;

	private ListConnectedPlayers.PlayerUIEntry player;

	private bool _useUserName;

	private bool _processingUserName;

	private Color _previousColor = Color.clear;

	private Color _currentColor = Color.clear;

	private float _lockColorTimer;

	public bool IsProcessingName => _processingUserName;

	public ListConnectedPlayers listConnectedPlayers { get; private set; }

	public void Init(ListConnectedPlayers.PlayerUIEntry _player, ListConnectedPlayers _listConnectedPlayers, PlayersListType _playersListType, bool pvpButtonIsOn, bool useUserName)
	{
		_useUserName = useUserName;
		if (player.pc != _player.pc)
		{
			_previousColor = Color.clear;
		}
		player = _player;
		listConnectedPlayers = _listConnectedPlayers;
		this.playersListType = _playersListType;
		float num = 0f;
		PlayersListType playersListType = this.playersListType;
		bool flag = playersListType == PlayersListType.ACTIVE_PLAYERS || playersListType == PlayersListType.UNASSIGN_ADMIN;
		playersListType = this.playersListType;
		bool flag2 = playersListType == PlayersListType.ACTIVE_PLAYERS || playersListType == PlayersListType.UNBAN;
		bool flag3 = this.playersListType == PlayersListType.SEND_INVITE;
		bool flag4 = Manager.main.player != null && Manager.main.player.adminPrivileges != 0;
		bool flag5 = this.playersListType == PlayersListType.ACTIVE_PLAYERS && ((flag4 && pvpButtonIsOn) || (!flag4 && base.world.GetExistingSystemManaged<WorldInfoSystem>().WorldInfo.pvpEnabled));
		bool flag6 = false;
		adminButton.gameObject.SetActive(flag);
		if (flag)
		{
			if (player.isAdmin)
			{
				adminButton.spritesShownPressed[0].sprite = isAdminSprite;
				adminButton.spritesShownUnpressed[0].sprite = isAdminSprite;
			}
			else
			{
				adminButton.spritesShownPressed[0].sprite = isNotAdminSprite;
				adminButton.spritesShownUnpressed[0].sprite = isNotAdminSprite;
			}
			adminButton.transform.localPosition = new Vector3(num, 0f, 0f);
			num += ((flag2 || flag6) ? 0.75f : 0.4375f);
		}
		banButton.gameObject.SetActive(flag2);
		if (flag2)
		{
			banButton.transform.localPosition = new Vector3(num, 0f, 0f);
			num += ((flag6 || flag5) ? 0.75f : 0.4375f);
		}
		pvpTeamButton.gameObject.SetActive(flag5);
		if (flag5)
		{
			pvpTeamButton.transform.localPosition = new Vector3(num, 0f, 0f);
			num += (flag6 ? 0.75f : 0.4375f);
		}
		inviteButton.gameObject.SetActive(flag3);
		if (flag3)
		{
			inviteButton.transform.localPosition = new Vector3(num, 0f, 0f);
			num += (flag6 ? 0.75f : 0.4375f);
		}
		showPlayerInfoButton.gameObject.SetActive(flag6);
		if (flag6)
		{
			showPlayerInfoButton.transform.localPosition = new Vector3(num, 0f, 0f);
			num += 0.4375f;
		}
		nameText.transform.localPosition = new Vector3(num, 0f, 0f);
		Color color = (flag5 ? player.GetTeamColor() : player.GetPlayerColor(flag4));
		if (_useUserName && !_processingUserName)
		{
			_processingUserName = true;
			if (Manager.platform.platformImpl is IPlatformUserManager platformUserManager)
			{
				platformUserManager.GetUserProfile(player.platformUserId, UserImageSize.None, OnUserProfileFetched);
			}
		}
		else
		{
			UpdateName(color);
		}
	}

	private void UpdateName(Color color)
	{
		if ((_lockColorTimer == 0f && !_currentColor.Equals(color)) || (!_currentColor.Equals(color) && !_previousColor.Equals(color)))
		{
			_previousColor = _currentColor;
			_currentColor = color;
			_lockColorTimer = 0.5f;
		}
		_lockColorTimer = Mathf.Max(_lockColorTimer - Time.deltaTime, 0f);
		pvpTeamButton.SetButtonColor(_currentColor);
		nameText.SetTempColor(_currentColor);
		if (realCurrentName != player.playerName)
		{
			realCurrentName = player.playerName;
			if (_useUserName)
			{
				nameText.Render(realCurrentName);
				return;
			}
			nameText.Render("...");
			Manager.platform.parentalControlManager.RestrictInput(player.playerName, delegate(string filteredName)
			{
				nameText.Render(filteredName);
			});
		}
		else
		{
			nameText.Render(nameText.GetText());
		}
	}

	private void OnUserProfileFetched(UserPlatformProfile profile)
	{
		if (profile == null)
		{
			_processingUserName = false;
			return;
		}
		player = new ListConnectedPlayers.PlayerUIEntry(player.pc, profile.UserName, player.banIndex, player.adminIndex, player.adminPrivileges, player.platformUserId);
		_processingUserName = false;
		try
		{
			UpdateName(player.GetPlayerColor());
		}
		catch (InvalidOperationException exception)
		{
			Debug.LogWarning("PlayerListEntry.OnUserProfileFetched: callback called likely after the relevant ECS world was destroyed.");
			Debug.LogException(exception);
		}
	}

	[UsedImplicitly]
	public void MakePlayerAdmin()
	{
		string text;
		List<string> options;
		if (!Manager.networking.hasNetwork)
		{
			text = "Error/NoNetwork";
			options = new List<string> { "cancelDialogue" };
		}
		else if (Manager.main.player == null || Manager.main.player.adminPrivileges == 0)
		{
			text = (player.isAdmin ? "noPermissionToRemoveAdmin" : "noPermissionToGiveAdmin");
			options = new List<string> { "cancelDialogue" };
		}
		else if (player.adminPrivileges > 1)
		{
			text = "cantRemoveAdmin";
			options = new List<string> { "cancelDialogue" };
		}
		else
		{
			text = (player.isAdmin ? "removeAdmin" : "makeAdmin");
			options = new List<string> { "cancelDialogue", "yes" };
		}
		Manager.menu.centerPopUpText.StartNewDisplaySequence(text, null, menuInputCooldown: true, 0f, 1.5f, useUnscaledTime: true, 0f, 1f, localize: true, TextManager.FontFace.boldMedium, PopUpCallBackAdmin, options, 10f, 0.95f, 0, 18f);
	}

	[UsedImplicitly]
	public void BanPlayer()
	{
		string text;
		List<string> options;
		if (!Manager.networking.hasNetwork)
		{
			text = "Error/NoNetwork";
			options = new List<string> { "cancelDialogue" };
		}
		else if (Manager.main.player == null || Manager.main.player.adminPrivileges == 0)
		{
			text = ((playersListType == PlayersListType.UNBAN) ? "noPermissionToUnBan" : "noPermissionToBan");
			options = new List<string> { "cancelDialogue" };
		}
		else if (player.pc == Manager.main.player)
		{
			text = "cantBanYourself";
			options = new List<string> { "cancelDialogue" };
		}
		else if (player.adminPrivileges != 0)
		{
			text = "cantBanAdmin";
			options = new List<string> { "cancelDialogue" };
		}
		else
		{
			text = ((playersListType == PlayersListType.UNBAN) ? "unbanPlayerDialogue" : "banPlayerDialogue");
			options = new List<string> { "cancelDialogue", "yes" };
		}
		Manager.menu.centerPopUpText.StartNewDisplaySequence(text, null, menuInputCooldown: true, 0f, 1.5f, useUnscaledTime: true, 0f, 1f, localize: true, TextManager.FontFace.boldMedium, PopUpCallBackBan, options, 10f, 0.95f, 0, 18f);
	}

	[UsedImplicitly]
	public void ChangePlayerPvPTeam()
	{
		string text = "";
		List<string> list = null;
		if (!Manager.networking.hasNetwork)
		{
			text = "Error/NoNetwork";
			list = new List<string> { "cancelDialogue" };
		}
		else if (Manager.main.player == null || (Manager.main.player.adminPrivileges == 0 && player.pc != Manager.main.player))
		{
			text = "noPermissionToChangePvPTeam";
			list = new List<string> { "cancelDialogue" };
		}
		if (list != null)
		{
			Manager.menu.centerPopUpText.StartNewDisplaySequence(text, null, menuInputCooldown: true, 0f, 1.5f, useUnscaledTime: true, 0f, 1f, localize: true, TextManager.FontFace.boldMedium, PopUpCallBackChangeTeamFail, list, 10f, 0.95f, 0, 18f);
		}
		else if (player.pc != null)
		{
			Manager.networking.ChangePvPTeam(player.pc, base.world);
		}
	}

	[UsedImplicitly]
	public void SendInvite()
	{
		listConnectedPlayers.SendInvite(player.platformUserId, player.playerName);
	}

	[UsedImplicitly]
	public void ShowPlayerProfile()
	{
		PlatformUserID platformUserId = player.platformUserId;
		if (platformUserId != null)
		{
			Debug.Log("Try to open Player Profile");
			Manager.platform.platformUserImpl?.OpenUserProfile(platformUserId);
		}
		else
		{
			Debug.Log("Can't show player profile since player user id is null");
		}
	}

	public PlayerListEntryButton GetFirstActiveButton()
	{
		if (adminButton.isActiveAndEnabled)
		{
			return adminButton;
		}
		if (inviteButton.isActiveAndEnabled)
		{
			return inviteButton;
		}
		if (banButton.isActiveAndEnabled)
		{
			return banButton;
		}
		if (showPlayerInfoButton.isActiveAndEnabled)
		{
			return showPlayerInfoButton;
		}
		if (pvpTeamButton.isActiveAndEnabled)
		{
			return pvpTeamButton;
		}
		return null;
	}

	private void PopUpCallBackBan(PopupResponse response)
	{
		if (base.world == null)
		{
			Debug.LogError("Tried to ban without world set");
		}
		else if (!response.IsCancel)
		{
			if (playersListType == PlayersListType.UNBAN)
			{
				Manager.networking.UnbanPlayer(player.banIndex, base.world);
			}
			else if (player.pc != null)
			{
				Manager.networking.BanPlayer(player.pc, base.world);
			}
		}
	}

	private void PopUpCallBackAdmin(PopupResponse response)
	{
		if (base.world == null)
		{
			Debug.LogError("Tried to set admin without world set");
		}
		else
		{
			if (response.IsCancel)
			{
				return;
			}
			if (player.isAdmin)
			{
				if (player.pc != null)
				{
					Manager.networking.RemoveAdmin(player.pc, base.world);
				}
				else
				{
					Manager.networking.RemoveAdmin(player.adminIndex, base.world);
				}
			}
			else if (player.pc != null)
			{
				Manager.networking.AddAdmin(player.pc, base.world);
			}
			else
			{
				Debug.LogError("Something funky going on with admins");
			}
		}
	}

	private void PopUpCallBackChangeTeamFail(PopupResponse response)
	{
	}
}
