using System.Collections.Generic;
using UnityEngine;

public class ReadyPlayerTrigger_BreakRoomDoor : MonoBehaviour
{
	public List<Collider> playerCollidersInUs = new List<Collider>();

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			playerCollidersInUs.Add(other);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			playerCollidersInUs.Remove(other);
		}
	}
}
