using UnityEngine;

public class PlayerManager : MonoBehaviour
{
	public static PlayerManager instance;

	public PlayerController playerController;

	public Transform cameraFollowPoint;

	public bool isPlayerActive;

	public void Awake()
	{
	}

	public static PlayerManager GetPlayerManager()
	{
		return null;
	}

	public void SetPlayerActive(bool active)
	{
	}

	public void SetPlayerActive(bool active, DefaultInterfaceSettings blockPlayerData)
	{
	}

	public void StopPlayerMovement()
	{
	}

	public void AddCameraToPlayer(Camera camera)
	{
	}

	public void SetPlayerGravityActive(bool active)
	{
	}

	public bool playerIsAgachado()
	{
		return false;
	}
}
