using Galaxy.Api;
using UnityEngine;

[DisallowMultipleComponent]
public class GogGalaxyManager : MonoBehaviour
{
	public string clientID;

	public string clientSecret;

	private static GogGalaxyManager singleton;

	private bool isInitialized;

	public static GogGalaxyManager Instance
	{
		get
		{
			if (singleton == null)
			{
				return new GameObject("GogGalaxyManager").AddComponent<GogGalaxyManager>();
			}
			return singleton;
		}
	}

	public static bool IsInitialized()
	{
		if (singleton != null)
		{
			return singleton.isInitialized;
		}
		return false;
	}

	private void Awake()
	{
		//IL_0043: Expected O, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected O, but got Unknown
		if (singleton != null)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		singleton = this;
		Object.DontDestroyOnLoad(base.gameObject);
		try
		{
			GalaxyInstance.Init(new InitParams(clientID, clientSecret));
		}
		catch (Error val)
		{
			Error val2 = val;
			Debug.LogError("Failed to initialize GOG Galaxy: Error = " + ((object)val2).ToString(), this);
			return;
		}
		Debug.Log("Galaxy SDK was initialized", this);
		isInitialized = true;
	}

	private void OnDestroy()
	{
		if (!(singleton != this))
		{
			singleton = null;
			if (isInitialized)
			{
				GalaxyInstance.Shutdown(true);
			}
		}
	}

	private void Update()
	{
		if (isInitialized)
		{
			GalaxyInstance.ProcessData();
		}
	}
}
