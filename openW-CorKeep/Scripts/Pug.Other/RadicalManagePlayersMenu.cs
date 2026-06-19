public class RadicalManagePlayersMenu : RadicalMenu
{
	public ListConnectedPlayers adminList;

	public ListConnectedPlayers banList;

	public ListConnectedPlayers inviteeList;

	public override void Activate()
	{
		base.Activate();
		if (adminList != null && adminList.players != null && adminList.players.Count > 0)
		{
			adminList.players[0].adminButton.Select();
		}
		else if (banList != null && banList.players != null && banList.players.Count > 0)
		{
			banList.players[0].banButton.Select();
		}
		else if (inviteeList != null && inviteeList.players != null && inviteeList.players.Count > 0)
		{
			inviteeList.players[0].inviteButton.Select();
		}
	}
}
