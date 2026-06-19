using Aggro.Core;
using Aggro.Core.Networking;
using UnityEngine.UI;

public class LobbyButtonsUI : EntityBehaviourBase
{
	public Selectable inviteFriendsButton;

	protected override void OnUpdatePresentation()
	{
		inviteFriendsButton.interactable = Platform.HasPlatformInvite() && Platform.IsOnline() && !AggroNetworkManager.isSinglePlayer && NetworkAggroManagerBase<PlayersManager>.instance.playerCount < 4;
	}

	public void OpenInviteFriends()
	{
		Platform.OpenInviteList();
	}
}
