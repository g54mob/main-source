using UnityEngine;

public class OverworldTrollPosition : MonoBehaviour
{
	public Transform playerTransform;

	public float distanceToTeleport;

	public Vector3 teleportOffset;

	public void Update()
	{
		if (SaveSystem.currentPlayerSaveData.overworldState == OverworldTrollManager.OverworldState.ACT_II)
		{
			CheckForTeleport();
		}
	}

	private void CheckForTeleport()
	{
		if (playerTransform.position.y > base.transform.position.y + distanceToTeleport)
		{
			base.transform.position = new Vector3(base.transform.position.x, playerTransform.position.y - teleportOffset.y, base.transform.position.z);
		}
		else if (playerTransform.position.y < base.transform.position.y - distanceToTeleport)
		{
			base.transform.position = new Vector3(base.transform.position.x, playerTransform.position.y + teleportOffset.y, base.transform.position.z);
		}
	}
}
