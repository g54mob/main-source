using UnityEngine;
using UnityEngine.UDP;

public class InitUDPListener : IInitListener
{
	public void OnInitialized(UserInfo userInfo)
	{
	}

	public void OnInitializeFailed(string message)
	{
		Debug.LogError("Initialization failed: " + message);
	}
}
