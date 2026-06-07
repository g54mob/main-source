using System.Collections.Generic;
using UnityEngine;

public class WorldDisabler : MonoBehaviour
{
	public List<GameObject> disableObjects;

	public void Awake()
	{
		if (SaveSystem.currentPlayerSaveData.overworldState != OverworldTrollManager.OverworldState.ACT_II)
		{
			return;
		}
		foreach (GameObject disableObject in disableObjects)
		{
			disableObject.gameObject.SetActive(value: false);
		}
	}
}
