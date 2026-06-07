using System.Text;
using Steamworks;
using UnityEngine;

namespace Assets.Packages.SocialPlatforms.Steam
{
	public class SteamManager : MonoBehaviour, ISteamManager
	{
		private SteamAPIWarningMessageHook_t _steamAPIWarningMessageHook;

		public static SteamManager Instance { get; private set; }

		public MonoBehaviour MonoBehaviour => this;

		public Transform Transform => base.transform;

		private static void SteamAPIDebugTextHook(int severity, StringBuilder debugText)
		{
			switch (severity)
			{
			case 0:
				Debug.LogFormat("Steam Debug: {0}", debugText);
				break;
			case 1:
				Debug.LogWarningFormat("Steam Debug: {0}", debugText);
				break;
			default:
				Debug.LogErrorFormat("Steam Debug: {0}", debugText);
				break;
			}
		}

		private void Awake()
		{
			if (Instance != null)
			{
				Debug.LogErrorFormat("An instance of the SteamManager already exists.");
				Object.Destroy(this);
				return;
			}
			Instance = this;
			Object.DontDestroyOnLoad(base.gameObject);
			if (SocialExt.Steam.IsRunningOnSteamDeck() || SocialExt.Steam.IsRunningInBigPicture())
			{
				new GameObject("SteamVirtualKeyboardManager", typeof(SteamVirtualKeyboardManager)).transform.SetParent(base.transform);
			}
		}

		private void OnDestroy()
		{
			SteamAPI.Shutdown();
			Instance = null;
		}

		private void OnEnable()
		{
			if (_steamAPIWarningMessageHook == null)
			{
				_steamAPIWarningMessageHook = SteamAPIDebugTextHook;
				SteamClient.SetWarningMessageHook(_steamAPIWarningMessageHook);
			}
		}

		[ContextMenu("Reset All Achievements")]
		private void ResetAllAchievements()
		{
			SocialExt.ResetAllAchievements();
		}

		private void Update()
		{
			SteamAPI.RunCallbacks();
		}
	}
}
