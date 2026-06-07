using Extensions;
using UnityEngine;

public class InviteFriendsButton : MonoBehaviour
{
	public void OnInviteFriendsClick()
	{
		if (MonoSingleton<LobbyManager>.Instance == null)
		{
			Debug.LogError("[InviteFriendsButton] LobbyManager.Instance is null!");
		}
		else
		{
			MonoSingleton<LobbyManager>.Instance.InviteFriend();
		}
	}
}
