using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Jundroo.Services.Ads
{
	public static class AdsService
	{
		public class InitializationParameters
		{
			public DebugGeography DebugGeography { get; set; }

			public bool ForceTestAdsOnly { get; set; }

			public AdLoggingFlags LoggingFlags { get; set; }

			public bool ResetConsentInformation { get; set; }

			public List<string> TestDeviceIds { get; set; }

			public bool UnderAgeOfConsent { get; set; }

			public InitializationParameters()
			{
				UnderAgeOfConsent = false;
				DebugGeography = DebugGeography.Disabled;
				TestDeviceIds = new List<string>();
			}

			public InitializationParameters(bool underAgeOfConsent, bool resetConsentInformation, AdLoggingFlags loggingFlags, DebugGeography debugGeography, List<string> testDeviceIds)
			{
				UnderAgeOfConsent = underAgeOfConsent;
				ResetConsentInformation = resetConsentInformation;
				LoggingFlags = loggingFlags;
				DebugGeography = debugGeography;
				TestDeviceIds = testDeviceIds;
			}
		}

		private static bool _initialized;

		private static bool _mobileAdsInitialized;

		public static bool CanModifyPrivacyOptions => false;

		public static bool Enabled { get; private set; }

		public static bool EnabledInBuild => false;

		public static bool ForceTestAdsOnly { get; private set; }

		public static bool Initialized
		{
			get
			{
				if (EnabledInBuild)
				{
					return _initialized;
				}
				return false;
			}
		}

		public static AdLoggingFlags LoggingFlags { get; private set; }

		public static async Task Initialize(InitializationParameters initParams)
		{
			if (_initialized)
			{
				Debug.LogError("The advertising service is already initialized");
				return;
			}
			_initialized = true;
			await Task.CompletedTask;
		}

		public static void ResetConsentInformation()
		{
		}

		public static void SetApplicationVolume(float volume)
		{
		}

		public static void ShowPrivacyOptionsForm()
		{
			Debug.LogError("Attempting to show privacy options form when advertising has been disabled in the build.");
		}
	}
}
