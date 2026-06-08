using System;
using Galaxy.Api;
using Helpers;
using UnityEngine;

public class GalaxyManager : MonoBehaviour
{
	public class AuthenticationListener : GlobalAuthListener
	{
		public override void OnAuthSuccess()
		{
			myGalaxyID = GalaxyInstance.User().GetGalaxyID();
			Debug.Log("Successfully signed in as user: " + (object)myGalaxyID);
			GalaxyManager.OnSignInSuccessful?.Invoke();
		}

		public unsafe override void OnAuthFailure(FailureReason failureReason)
		{
			Debug.LogWarning("Failed to sign in for reason " + ((object)(*(FailureReason*)(&failureReason))/*cast due to .constrained prefix*/).ToString());
		}

		public override void OnAuthLost()
		{
			Debug.LogWarning("Authorization lost");
		}
	}

	public class GogServicesConnectionStateListener : GlobalGogServicesConnectionStateListener
	{
		public unsafe override void OnConnectionStateChange(GogServicesConnectionState connected)
		{
			Debug.Log("Connection state to GOG services changed to " + ((object)(*(GogServicesConnectionState*)(&connected))/*cast due to .constrained prefix*/).ToString());
		}
	}

	public string clientID = "54182862800736750";

	public string clientSecret = "3377483d2da91cef14937db8723803ea7c7a798df9c757d8f8f1eaf7696cc572";

	public static GalaxyManager Instance;

	private static GalaxyID myGalaxyID;

	private bool galaxyFullyInitialized;

	public AuthenticationListener authListener;

	public GogServicesConnectionStateListener gogServicesConnectionStateListener;

	public GalaxyID MyGalaxyID => myGalaxyID;

	public bool GalaxyFullyInitialized => galaxyFullyInitialized;

	public static event Action OnSignInSuccessful;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		}
		else
		{
			UnityEngine.Object.Destroy(this);
		}
	}

	private void OnEnable()
	{
		Init();
		ListenersInit();
		SignInGalaxy();
	}

	private void Update()
	{
		GalaxyInstance.ProcessData();
	}

	private void OnDisable()
	{
		ListenersDispose();
	}

	private void OnApplicationQuit()
	{
		GalaxyInstance.Shutdown(true);
		Instance = null;
		UnityEngine.Object.Destroy(this);
	}

	private void ListenersInit()
	{
		Listener.Create(ref authListener);
		Listener.Create(ref gogServicesConnectionStateListener);
	}

	private void ListenersDispose()
	{
		Listener.Dispose<AuthenticationListener>(ref authListener);
		Listener.Dispose<GogServicesConnectionStateListener>(ref gogServicesConnectionStateListener);
	}

	private void Init()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		//IL_002c: Expected O, but got Unknown
		InitParams val = new InitParams(clientID, clientSecret);
		Debug.Log("Initializing GalaxyPeer instance...");
		try
		{
			GalaxyInstance.Init(val);
			galaxyFullyInitialized = true;
		}
		catch (Error val2)
		{
			Debug.LogWarning("Init failed for reason " + (object)val2);
			galaxyFullyInitialized = false;
		}
	}

	public void SignInGalaxy()
	{
		//IL_0017: Expected O, but got Unknown
		Debug.Log("Signing user in using Galaxy client...");
		try
		{
			GalaxyInstance.User().SignInGalaxy();
		}
		catch (Error val)
		{
			Debug.LogWarning("SignInGalaxy failed for reason " + (object)val);
		}
	}

	public void SignInCredentials(string username, string password)
	{
		//IL_0019: Expected O, but got Unknown
		Debug.Log("Signing user in using credentials...");
		try
		{
			GalaxyInstance.User().SignInCredentials(username, password);
		}
		catch (Error val)
		{
			Debug.LogWarning("SignInCredentials failed for reason " + (object)val);
		}
	}

	public void SignOut()
	{
		//IL_0017: Expected O, but got Unknown
		Debug.Log("Singing user out...");
		try
		{
			GalaxyInstance.User().SignOut();
		}
		catch (Error val)
		{
			Debug.LogWarning("SignOut failed for reason " + (object)val);
		}
	}

	public bool IsSignedIn(bool silent = false)
	{
		//IL_0037: Expected O, but got Unknown
		bool result = false;
		if (!silent)
		{
			Debug.Log("Checking SignedIn status...");
		}
		try
		{
			result = GalaxyInstance.User().SignedIn();
			if (!silent)
			{
				Debug.Log("User SignedIn: " + result);
			}
		}
		catch (Error val)
		{
			Error val2 = val;
			if (!silent)
			{
				Debug.LogWarning("Could not check user signed in status for reason " + (object)val2);
			}
		}
		return result;
	}

	public bool IsLoggedOn(bool silent = false)
	{
		//IL_0037: Expected O, but got Unknown
		bool result = false;
		if (!silent)
		{
			Debug.Log("Checking LoggedOn status...");
		}
		try
		{
			result = GalaxyInstance.User().IsLoggedOn();
			if (!silent)
			{
				Debug.Log("User logged on: " + result);
			}
		}
		catch (Error val)
		{
			Error val2 = val;
			if (!silent)
			{
				Debug.LogWarning("Could not check user logged on status for reason " + (object)val2);
			}
		}
		return result;
	}

	public bool IsDlcInstalled(ulong productID)
	{
		//IL_004e: Expected O, but got Unknown
		bool result = false;
		Debug.Log("Checking is DLC " + productID + " installed");
		try
		{
			result = GalaxyInstance.Apps().IsDlcInstalled(productID);
			Debug.Log("DLC " + productID + " installed " + result);
		}
		catch (Error val)
		{
			Debug.LogWarning("Could not check is DLC " + productID + " installed for reason " + (object)val);
		}
		return result;
	}

	public string GetCurrentGameLanguage()
	{
		//IL_002a: Expected O, but got Unknown
		string text = null;
		Debug.Log("Checking current game language");
		try
		{
			text = GalaxyInstance.Apps().GetCurrentGameLanguage();
			Debug.Log("Current game language is " + text);
		}
		catch (Error val)
		{
			Debug.Log("Could not check current game language for reason " + (object)val);
		}
		return text;
	}

	public void ShowOverlayWithWebPage(string url)
	{
		//IL_002e: Expected O, but got Unknown
		Debug.Log("Opening overlay with web page " + url);
		try
		{
			GalaxyInstance.Utils().ShowOverlayWithWebPage(url);
			Debug.Log("Opened overlay with web page " + url);
		}
		catch (Error val)
		{
			Debug.Log("Could not open overlay with web page " + url + " for reason " + (object)val);
		}
	}
}
