using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
	private static PlayerManager instance;

	protected List<PlayerMovement> registeredPlayers = new List<PlayerMovement>();

	public static PlayerManager Instance => instance;

	public PlayerMovement[] RegisteredPlayers => registeredPlayers.ToArray();

	private void Awake()
	{
		if (instance != null)
		{
			Object.Destroy(instance);
			Debug.LogWarning("Found more than one player manager in scene. Destroyed old one.");
		}
		instance = this;
	}

	public static void RegisterPlayer(PlayerMovement player)
	{
		if (!instance)
		{
			Debug.Log("No PlayerManager exists in scene.");
		}
		else
		{
			instance.registeredPlayers.Add(player);
		}
	}

	public static void UnregisterPlayer(PlayerMovement player)
	{
		if (!instance)
		{
			Debug.Log("No PlayerManager exists in scene.");
		}
		else
		{
			instance.registeredPlayers.Remove(player);
		}
	}

	public static PlayerMovement GetClosestPlayer(Vector3 position)
	{
		if (!instance)
		{
			Debug.Log("No PlayerManager exists in scene.");
			return null;
		}
		PlayerMovement result = null;
		float num = float.PositiveInfinity;
		foreach (PlayerMovement registeredPlayer in instance.registeredPlayers)
		{
			float num2 = Vector3.Distance(position, registeredPlayer.transform.position);
			if (num2 < num)
			{
				num = num2;
				result = registeredPlayer;
			}
		}
		return result;
	}
}
