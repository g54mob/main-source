using System;
using FuryStudios.FurySDK.Settings;

namespace FuryStudios.FurySDK
{
	public static class Platform
	{
		private static Type fallbackPlatformSDKType;

		private static Type platformSDKType;

		private static Type platformPlayerPrefsType;

		public static IPlatformSDK SDK { get; private set; }

		public static ILocalisationService Localisation { get; private set; }

		public static ISystemMessenger Messenger { get; private set; }

		public static IPlatformPlayerPrefs PlayerPrefs { get; private set; }

		public static void Init(PlatformSettings settings)
		{
		}

		private static void Init(PlatformSettings settings, bool reload)
		{
		}

		public static void RegisterPlatformSDK(Type type)
		{
		}

		public static void RegisterFallbackPlatformSDK(Type type)
		{
		}

		public static void RegisterPlayerPrefsType(Type type)
		{
		}
	}
}
