using System;
using TwitchSDK;
using UnityEngine;

public class Twitch : MonoBehaviour
{
	private static object Lock = new object();

	private static Twitch _Twitch;

	private TwitchSDKApi Instance;

	public static TwitchSDKApi API
	{
		get
		{
			lock (Lock)
			{
				if (_Twitch != null && _Twitch.Instance != null)
				{
					return _Twitch.Instance;
				}
				try
				{
					_Twitch = UnityEngine.Object.FindObjectOfType<Twitch>();
				}
				catch (UnityException ex) when (ex.HResult == -2147467261)
				{
					throw new Exception("The Twitch API can only be initialized on the main thread. Make sure the first invocation of Twitch.API happens in the Unity Main thread (e.g. the Start or Update method, and not a constructor)");
				}
				if (_Twitch != null && _Twitch.Instance != null)
				{
					UnityEngine.Object.Destroy(_Twitch.gameObject);
				}
				if (_Twitch == null)
				{
					GameObject obj = new GameObject();
					_Twitch = obj.AddComponent<Twitch>();
					_Twitch.CreateInstance();
					obj.name = "TwitchApi (Singleton)";
					UnityEngine.Object.DontDestroyOnLoad(obj);
				}
				return _Twitch.Instance;
			}
		}
	}

	private void CreateInstance()
	{
		TwitchSDKSettings instance = TwitchSDKSettings.Instance;
		if (instance.ClientId == "Go to dev.twitch.tv to get a client-id")
		{
			Debug.LogError("Twitch: No OAuth ClientId set. Please open the Twitch settings at Twitch->Edit Settings.");
		}
		Instance = new UnityTwitch(instance.ClientId, instance.UseEventSubProxy);
		((UnityTwitch)Instance).InitializeInternally();
	}

	private void OnApplicationQuit()
	{
		if (Instance != null)
		{
			Debug.Log("OnApplicationQuit Twitch API");
			Instance.Dispose();
			Instance = null;
		}
	}

	private void OnDestroy()
	{
		if (Instance != null)
		{
			Debug.Log("OnDestroy Twitch API");
			Instance.Dispose();
			Instance = null;
		}
	}
}
