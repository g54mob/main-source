using System;
using UnityEngine;

public class DetectionAdapter : MonoBehaviour
{
	public DetectionMode thisMode;

	private Action<DetectionMode, bool> act;

	public void Setup(Action<DetectionMode, bool> action)
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	private void OnTriggerExit(Collider other)
	{
	}

	public void EnterCrosshair()
	{
	}

	public void ExitCrosshair()
	{
	}
}
