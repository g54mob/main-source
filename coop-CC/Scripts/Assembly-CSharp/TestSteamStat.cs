using System.Collections;
using Aggro.Core;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestSteamStat : MonoBehaviour
{
	private void Update()
	{
		if (Keyboard.current.iKey.wasPressedThisFrame)
		{
			Platform.SetStat("TestLike3", 1);
			Debug.Log("Stat added!");
		}
		if (Keyboard.current.jKey.wasPressedThisFrame)
		{
			if (Platform.TryGetGlobalStat("TestLike3", out long stat))
			{
				Debug.Log($"Stat: {stat}!");
			}
			else
			{
				Debug.Log("TryGetGlobalStat failed!");
			}
		}
		if (Keyboard.current.kKey.wasPressedThisFrame)
		{
			StartCoroutine(RefreshGlobalStatsCo());
		}
	}

	private IEnumerator RefreshGlobalStatsCo()
	{
		Debug.Log("Refresh Started");
		yield return new WaitForTask(Platform.RefreshGlobalStatsAsync());
		Debug.Log("Refresh Finished");
	}
}
