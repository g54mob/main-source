using System;
using System.Text;
using AOT;
using SteamIntegrations;
using Steamworks;
using UnityEngine;

[DisallowMultipleComponent]
public class SteamManager : MonoBehaviour
{
	public const int AppIDint = 2736860;

	public static readonly AppId_t AppID = (AppId_t)2736860u;

	public static string username;

	public static CSteamID userID;

	public static Texture2D avatar;

	public static Sprite avatarSprite;

	public SteamWorkshopManager workshopManager;

	protected static bool s_EverInitialized = false;

	protected static SteamManager s_instance;

	public bool forceEnable;

	[NonSerialized]
	public bool enable;

	protected bool m_bInitialized;

	[SerializeField]
	protected bool m_isDemo;

	protected SteamAPIWarningMessageHook_t m_SteamAPIWarningMessageHook;

	protected static SteamManager Instance
	{
		get
		{
			if (s_instance == null)
			{
				return new GameObject("SteamManager").AddComponent<SteamManager>();
			}
			return s_instance;
		}
	}

	public static bool Initialized => Instance.m_bInitialized;

	public static bool isDemo => Instance.m_isDemo;

	[MonoPInvokeCallback(typeof(SteamAPIWarningMessageHook_t))]
	protected static void SteamAPIDebugTextHook(int nSeverity, StringBuilder pchDebugText)
	{
		Debug.LogWarning(pchDebugText);
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	private static void InitOnPlayMode()
	{
		s_EverInitialized = false;
		s_instance = null;
	}

	protected virtual void Awake()
	{
		if (s_instance != null)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		s_instance = this;
		if (forceEnable)
		{
			enable = true;
		}
		if (!enable)
		{
			return;
		}
		if (s_EverInitialized)
		{
			throw new Exception("Tried to Initialize the SteamAPI twice in one session!");
		}
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		if (!Packsize.Test())
		{
			Debug.LogError("[Steamworks.NET] Packsize Test returned false, the wrong version of Steamworks.NET is being run in this platform.", this);
		}
		if (!DllCheck.Test())
		{
			Debug.LogError("[Steamworks.NET] DllCheck Test returned false, One or more of the Steamworks binaries seems to be the wrong version.", this);
		}
		try
		{
			if (SteamAPI.RestartAppIfNecessary((AppId_t)2736860u))
			{
				Application.Quit();
				return;
			}
		}
		catch (DllNotFoundException ex)
		{
			Debug.LogError("[Steamworks.NET] Could not load [lib]steam_api.dll/so/dylib. It's likely not in the correct location. Refer to the README for more details.\n" + ex, this);
			Application.Quit();
			return;
		}
		m_bInitialized = SteamAPI.Init();
		if (!m_bInitialized)
		{
			Debug.LogError("[Steamworks.NET] SteamAPI_Init() failed. Refer to Valve's documentation or the comment above this line for more information.", this);
			return;
		}
		s_EverInitialized = true;
		username = SteamFriends.GetPersonaName();
		userID = SteamUser.GetSteamID();
		int mediumFriendAvatar = SteamFriends.GetMediumFriendAvatar(userID);
		SteamUtils.GetImageSize(mediumFriendAvatar, out var pnWidth, out var pnHeight);
		byte[] array = new byte[4 * pnWidth * pnHeight];
		if (SteamUtils.GetImageRGBA(mediumFriendAvatar, array, (int)(4 * pnWidth * pnHeight)))
		{
			avatar = new Texture2D((int)pnWidth, (int)pnHeight, TextureFormat.RGBA32, mipChain: false, linear: true);
			avatar.LoadRawTextureData(array);
			avatar.Apply();
			avatarSprite = Sprite.Create(avatar, new Rect(0f, 0f, pnWidth, pnHeight), Vector2.zero);
		}
		workshopManager.InitializeWorkshop();
	}

	protected virtual void OnEnable()
	{
		if (s_instance == null)
		{
			s_instance = this;
		}
		if (m_bInitialized && m_SteamAPIWarningMessageHook == null)
		{
			m_SteamAPIWarningMessageHook = SteamAPIDebugTextHook;
			SteamClient.SetWarningMessageHook(m_SteamAPIWarningMessageHook);
		}
	}

	protected virtual void OnDestroy()
	{
		if (!(s_instance != this))
		{
			s_instance = null;
			if (m_bInitialized)
			{
				SteamAPI.Shutdown();
			}
		}
	}

	protected virtual void Update()
	{
		if (m_bInitialized)
		{
			SteamAPI.RunCallbacks();
		}
	}
}
