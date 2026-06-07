using DV.Platform.GeForceNOW;
using DV.Platform.Steam;
using Steamworks;
using UnityEngine;

namespace DV.Platform
{
	public class DVPlatformProvider : APlatformProvider
	{
		private static bool IsSteamVR => SteamVR.active;

		public override Platform CurrentPlatform => (Platform)((uint)base.CurrentPlatform | (uint)(DVSteamworks.IsSteamDeck ? 4 : 0) | (uint)(IsSteamVR ? 8 : 0) | (uint)(DVGeForceNOW.IsRunningInCloud ? 16 : 0));

		public override bool MustStayInGame
		{
			get
			{
				if (!DVGeForceNOW.IsRunningInCloud && !DVSteamworks.IsSteamDeck)
				{
					return DVSteamworks.IsSteamInBigPictureMode;
				}
				return true;
			}
		}

		public override bool SupportsBugReporting => !DVGeForceNOW.IsRunningInCloud;

		public override string RecommendedGraphicsPreset_NonVR
		{
			get
			{
				if (!DVSteamworks.IsSteamDeck)
				{
					return "Ultra";
				}
				return "Medium";
			}
		}

		public override string RecommendedGraphicsPreset_VR => "High";

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void StaticReload()
		{
			GameObject obj = new GameObject("[DVPlatformProvider]");
			obj.AddComponent<DVPlatformProvider>();
			Object.DontDestroyOnLoad(obj);
		}

		public override void OpenURL(string url)
		{
			if (MustStayInGame || IsSteamVR)
			{
				SteamFriends.OpenWebOverlay(url);
			}
			else
			{
				Application.OpenURL(url);
			}
		}
	}
}
