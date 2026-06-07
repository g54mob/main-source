using Galaxy.Api;
using UnityEngine;

public class GalaxyManager : MonoBehaviour
{
	public class AuthenticationListener : GlobalAuthListener
	{
		public override void OnAuthSuccess()
		{
		}

		public override void OnAuthFailure(FailureReason failureReason)
		{
		}

		public override void OnAuthLost()
		{
		}
	}

	public class GogServicesConnectionStateListener : GlobalGogServicesConnectionStateListener
	{
		public override void OnConnectionStateChange(GogServicesConnectionState connected)
		{
		}
	}

	public static bool ACTUALLY_QUITTING;

	private readonly string clientID;

	private readonly string clientSecret;

	public static GalaxyManager Instance;

	public StatsAndAchievements StatsAndAchievements;

	public Friends Friends;

	public Storage Storage;

	private static GalaxyID myGalaxyID;

	private bool galaxyFullyInitialized;

	public AuthenticationListener authListener;

	public GogServicesConnectionStateListener gogServicesConnectionStateListener;

	private bool shouldSyncAchievements;

	public GalaxyID MyGalaxyID => null;

	public bool GalaxyFullyInitialized => false;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void Update()
	{
	}

	private void OnDisable()
	{
	}

	private void OnApplicationQuit()
	{
	}

	private void ListenersInit()
	{
	}

	private void ListenersDispose()
	{
	}

	public void StartStatsAndAchievements()
	{
	}

	public void ShutdownStatsAndAchievements()
	{
	}

	public void StartFriends()
	{
	}

	public void ShutdownFriends()
	{
	}

	public void StartStorage()
	{
	}

	public void ShutdownStorage()
	{
	}

	public void ShutdownAllFeatureClasses()
	{
	}

	private void Init()
	{
	}

	public void SignInGalaxy()
	{
	}

	public void SignInCredentials(string username, string password)
	{
	}

	public void SignOut()
	{
	}

	public bool IsSignedIn(bool silent = false)
	{
		return false;
	}

	public bool IsLoggedOn(bool silent = false)
	{
		return false;
	}

	public bool IsDlcInstalled(ulong productID)
	{
		return false;
	}

	public string GetCurrentGameLanguage()
	{
		return null;
	}

	public void ShowOverlayWithWebPage(string url)
	{
	}

	public void SyncStatsAndAchievements()
	{
	}
}
