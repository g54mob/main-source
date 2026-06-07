using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jundroo.Services.Unity;
using UnityEngine;

namespace Jundroo.Services.Analytics
{
	public static class AnalyticsService
	{
		public delegate AnalyticsConsentState GetConsentStateDelegate();

		public delegate Task ShowConsentDialogDelegate();

		public class InitializationParameters
		{
			public GetConsentStateDelegate GetConsentStateDelegate { get; set; }

			public ShowConsentDialogDelegate ShowConsentDialogDelegate { get; set; }

			public InitializationParameters()
			{
			}

			public InitializationParameters(GetConsentStateDelegate getConsentStateDelegate, ShowConsentDialogDelegate showConsentDialogDelegate)
			{
				GetConsentStateDelegate = getConsentStateDelegate;
				ShowConsentDialogDelegate = showConsentDialogDelegate;
			}
		}

		private static GetConsentStateDelegate _getConsentState;

		private static bool _initialized;

		private static ShowConsentDialogDelegate _showConsentDialog;

		public static AnalyticsConsentState ConsentState => _getConsentState?.Invoke() ?? AnalyticsConsentState.NotSet;

		public static bool Enabled { get; private set; }

		public static bool EnabledInBuild => false;

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

		public static string PrivacyPolicyUrl => string.Empty;

		public static async Task Initialize(InitializationParameters initParams)
		{
			if (_initialized)
			{
				Debug.LogError("The analytics service is already initialized");
				return;
			}
			_initialized = true;
			_getConsentState = initParams?.GetConsentStateDelegate;
			_showConsentDialog = initParams?.ShowConsentDialogDelegate;
			await Task.CompletedTask;
		}

		public static void LogEvent(string eventName)
		{
			Debug.LogWarning("Attempting to log analytics data with analytics completely disabled in the build. This is likely inefficient and the analytics code should be wrapped in an if statement checking to see if analytics are enabled.");
		}

		public static void LogEvent(string eventName, Dictionary<string, object> eventData)
		{
			Debug.LogWarning("Attempting to log analytics data with analytics completely disabled in the build. This is likely inefficient and the analytics code should be wrapped in an if statement checking to see if analytics are enabled.");
		}

		public static void OnAnalyticsConsentChanged()
		{
		}

		public static async Task ShowConsentDialog()
		{
			await Task.CompletedTask;
		}

		private static void SetEnabled(bool enabled)
		{
		}

		private static void VerifyUnityServicesAreInitialized()
		{
			if (UnityServices.State != ServicesInitializationState.Initialized)
			{
				throw new InvalidOperationException("The Unity Analytics service is not available because the Unity Services Core has not be initialized.");
			}
		}
	}
}
