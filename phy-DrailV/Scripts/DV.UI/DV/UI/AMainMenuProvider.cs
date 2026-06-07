using System;
using UnityEngine;

namespace DV.UI
{
	public abstract class AMainMenuProvider : MonoBehaviour
	{
		public abstract ASettingsProvider SettingsProvider { get; }

		public abstract AUserProfileProvider UserProfileProvider { get; }

		public abstract AScenarioProvider ScenarioProvider { get; }

		public abstract ABugReportDataProvider BugReportDataProvider { get; }

		public abstract sbyte? DefaultMenuIndexOverride { get; }

		public abstract string BuildVersionString { get; }

		public abstract bool HasLocalizationOverridesLoaded { get; }

		public event Action<string> PlatformIndicatorInitialized;

		public abstract void OpenChangelog();

		protected void CallPlatformIndicatorUpdate(string value)
		{
			this.PlatformIndicatorInitialized?.Invoke(value);
		}
	}
}
