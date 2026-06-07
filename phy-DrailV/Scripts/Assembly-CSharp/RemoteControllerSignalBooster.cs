using System.Collections.Generic;
using UnityEngine;

public class RemoteControllerSignalBooster : MonoBehaviour
{
	public static List<RemoteControllerSignalBooster> signalBoosters = new List<RemoteControllerSignalBooster>();

	public float range = 2000f;

	private void OnEnable()
	{
		signalBoosters.Add(this);
	}

	private void OnDisable()
	{
		signalBoosters.Remove(this);
	}
}
