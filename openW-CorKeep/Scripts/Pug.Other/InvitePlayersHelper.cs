using UnityEngine;

public class InvitePlayersHelper : MonoBehaviour
{
	[SerializeField]
	private RadicalPauseMenu_InvitePlayers _invitePlayersOption;

	private void OnEnable()
	{
		if (!(_invitePlayersOption == null))
		{
			_invitePlayersOption.gameObject.SetActive(value: true);
			_invitePlayersOption.UpdateState();
		}
	}
}
