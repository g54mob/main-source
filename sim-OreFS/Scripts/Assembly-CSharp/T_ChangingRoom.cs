using GameCreator.Runtime.Characters;
using Mirror;
using UnityEngine;

public class T_ChangingRoom : MonoBehaviour
{
	[Header("Teleport Point")]
	public Transform teleportPoint;

	public void TeleportLocalPlayer()
	{
		GamePlayer gamePlayer = NetworkClient.localPlayer?.GetComponent<GamePlayer>();
		if (!(gamePlayer == null) && !(teleportPoint == null))
		{
			gamePlayer.NetworkTeleport(teleportPoint.position, teleportPoint.rotation);
			Character component = gamePlayer.GetComponent<Character>();
			if (component != null && component.Facing != null)
			{
				Vector3 direction = teleportPoint.rotation * Vector3.forward;
				component.Facing.SetLayerDirection(0, direction, 0.5f);
			}
		}
	}
}
