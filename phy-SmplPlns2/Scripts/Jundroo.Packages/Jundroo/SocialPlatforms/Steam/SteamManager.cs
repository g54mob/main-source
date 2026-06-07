using System.Text;
using Steamworks;
using UnityEngine;

namespace Jundroo.SocialPlatforms.Steam
{
	public class SteamManager : MonoBehaviour
	{
		private SteamAPIWarningMessageHook_t _steamAPIWarningMessageHook;

		public static SteamManager Instance { get; private set; }

		protected virtual void Awake()
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

		protected virtual void OnDestroy()
		{
			SteamAPI.Shutdown();
			Instance = null;
		}

		protected virtual void OnEnable()
		{
			if (_steamAPIWarningMessageHook == null)
			{
				_steamAPIWarningMessageHook = SteamAPIDebugTextHook;
				SteamClient.SetWarningMessageHook(_steamAPIWarningMessageHook);
			}
		}

		protected virtual void Update()
		{
			SteamAPI.RunCallbacks();
		}

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

		[ContextMenu("Reset All Achievements")]
		private void ResetAllAchievements()
		{
			SocialExt.ResetAllAchievements();
		}
	}
}
