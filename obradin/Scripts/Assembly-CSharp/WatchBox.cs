using System.Collections;
using UnityEngine;

public class WatchBox : MonoBehaviour, AnimEventHandler.IHost
{
	public WalkwayPusher proxityBlockerWalkwayPusher;

	public void OnAnimEvent(string id)
	{
		switch (id)
		{
		case "playsound open":
			proxityBlockerWalkwayPusher.gameObject.SetActive(false);
			break;
		case "tookbook":
			StartCoroutine(ShowBookNextFrame());
			break;
		case "nearend":
			Monitor.BlackOut(30);
			proxityBlockerWalkwayPusher.gameObject.SetActive(true);
			break;
		}
	}

	private IEnumerator ShowBookNextFrame()
	{
		Monitor.BlackOut(2);
		for (int i = 0; i < 2; i++)
		{
			Monitor.BlackOut(2);
			yield return new WaitForEndOfFrame();
		}
		Monitor.BlackOut(2);
		Game.instance.RevealBook();
	}
}
