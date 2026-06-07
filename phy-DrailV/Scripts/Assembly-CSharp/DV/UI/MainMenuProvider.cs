using System.Collections;
using DV.Localization;
using DV.VRTK_Extensions;
using UnityEngine;

namespace DV.UI
{
	public class MainMenuProvider : AMainMenuProvider
	{
		private const string CHANGELOG_URL = "https://www.derailvalley.com/changelog";

		public ASettingsProvider settingsProvider;

		public AUserProfileProvider userProfileProvider;

		public AScenarioProvider scenarioProvider;

		public ABugReportDataProvider bugReportProvider;

		private sbyte? defaultMainMenuPageOverride;

		public override ASettingsProvider SettingsProvider => settingsProvider;

		public override AUserProfileProvider UserProfileProvider => userProfileProvider;

		public override AScenarioProvider ScenarioProvider => scenarioProvider;

		public override ABugReportDataProvider BugReportDataProvider => bugReportProvider;

		public override sbyte? DefaultMenuIndexOverride => defaultMainMenuPageOverride;

		public override string BuildVersionString
		{
			get
			{
				if (BuildInfo.BUILD_VERSION_MAJOR != 99)
				{
					Debug.LogError("NEED TO UPDATE THE VERSION IN MainMenuProvider", this);
				}
				return "99.6";
			}
		}

		public override bool HasLocalizationOverridesLoaded => LocalizationLoader.numCSVsLoaded > 0;

		private void Awake()
		{
			for (int i = 0; i < Bootstrap.commandLineArgs.Length; i++)
			{
				if (i + 1 < Bootstrap.commandLineArgs.Length && !(Bootstrap.commandLineArgs[i] != "-main-menu-page"))
				{
					string text = Bootstrap.commandLineArgs[i + 1];
					if (sbyte.TryParse(text, out var result))
					{
						defaultMainMenuPageOverride = result;
						Debug.Log($"Setting default main menu page to {defaultMainMenuPageOverride}");
					}
					else
					{
						Debug.LogError("Invalid main menu page index " + text + "!");
					}
				}
			}
		}

		private IEnumerator Start()
		{
			yield return null;
			yield return null;
			string value = (VRManager.IsVREnabled() ? HeadsetUtils.GetHeadsetTypeDV().ToString() : "PC");
			CallPlatformIndicatorUpdate(value);
		}

		public override void OpenChangelog()
		{
			Util.OpenURL("https://www.derailvalley.com/changelog");
		}
	}
}
