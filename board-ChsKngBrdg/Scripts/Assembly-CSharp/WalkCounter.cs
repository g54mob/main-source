using Steamworks;
using UnityEngine;

public class WalkCounter : MonoBehaviour
{
	public PlayerMovement playerMovement;

	private float elapsedTime;

	public void Update()
	{
		if (SaveSystem.currentPlayerSaveData.overworldState != OverworldTrollManager.OverworldState.ACT_II)
		{
			return;
		}
		if (playerMovement.rb.velocity.sqrMagnitude > 0f)
		{
			if (elapsedTime < 1f)
			{
				elapsedTime += Time.deltaTime;
				return;
			}
			elapsedTime = 0f;
			SteamUserStats.AddStat("WalkCounter", 1);
			SteamUserStats.StoreStats();
		}
		else
		{
			elapsedTime = 0f;
		}
	}
}
