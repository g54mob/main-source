using UnityEngine;

public class GameCanvasRaycastBlocker : MonoBehaviour
{
	private int _enableRequests;

	public static GameCanvasRaycastBlocker Instance { get; private set; }

	public bool Active => false;

	public void Initiate()
	{
	}

	public void AddRequest()
	{
	}

	public void RemoveRequest()
	{
	}
}
