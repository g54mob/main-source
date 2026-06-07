using System;
using System.Runtime.CompilerServices;

namespace Gh.Tk
{
	public static class GlobalSettings
	{
		public static string DefaultProfileId
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static int ShadowTextureSettingIndex
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public static float ShadowDistancePercentage
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public static int VSyncSettingIndex
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public static int FramerateLimit
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public static bool IsOnlineSystemInitialized
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static bool UseOnlineSystem
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static bool SendAnalytics
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static bool AllowSendingGameplayStats
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static bool OnlineRewardsEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static bool ShowLowPerformanceDialog
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static bool ShowLowPerformanceAlertBadge
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static bool DiscordRichPresenceEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static bool SteamRichPresenceEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static event EventHandler UseOnlineSystemSettingChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static void Reset()
		{
		}
	}
}
