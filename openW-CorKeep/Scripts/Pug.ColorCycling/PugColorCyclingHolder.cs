using System.Collections.Generic;
using UnityEngine;

public class PugColorCyclingHolder : MonoBehaviour
{
	public List<PugColorCyclingController> pugColorControllers;

	public void EnableControllerWithIndex(int index)
	{
		foreach (PugColorCyclingController pugColorController in pugColorControllers)
		{
			pugColorController.enabled = false;
		}
		pugColorControllers[index].enabled = true;
	}
}
