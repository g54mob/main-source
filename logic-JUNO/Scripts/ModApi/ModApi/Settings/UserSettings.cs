using System;
using System.Threading.Tasks;
using Jundroo.Services.Ads;
using Jundroo.Services.Analytics;
using ModApi.Settings.Core;
using ModApi.Settings.Core.Events;
using ModApi.Ui;
using UnityEngine;

namespace ModApi.Settings
{
	public class UserSettings : SettingsCategory<UserSettings>
	{
		public enum AnalyticsState
		{
			[EnumOption("Disabled Pending Consent", "You have not yet made a choice regarding analytics. They will remain disabled until you choose to opt in.", State = SettingState.Hidden)]
			DisabledPendingConsent = 0,
			[EnumOption("Disabled", "You have chosen to opt out of analytics. They will remain disabled until you choose to opt back in.")]
			Disabled = 1,
			[EnumOption("Enabled", "You have chosen to opt in to analytics. Anonymous data may be collected to improve the gameplay experience.")]
			Enabled = 2
		}

		private bool _suppressAnalyticsConsentChangedCallback;

		public EnumSetting<AnalyticsState> Analytics { get; private set; }

		public AnalyticsConsentState AnalyticsConsent => Analytics.Value switch
		{
			AnalyticsState.DisabledPendingConsent => AnalyticsConsentState.NotSet, 
			AnalyticsState.Disabled => AnalyticsConsentState.OptOut, 
			AnalyticsState.Enabled => AnalyticsConsentState.OptIn, 
			_ => throw new NotSupportedException(), 
		};

		public override int Order => 20;

		public ButtonSetting PrivacyOptionsButton { get; private set; }

		protected static bool IsVisibleInBuild
		{
			get
			{
				if (!AnalyticsService.EnabledInBuild)
				{
					return AdsService.EnabledInBuild;
				}
				return true;
			}
		}

		public UserSettings()
			: base("User", (!IsVisibleInBuild) ? SettingState.Hidden : SettingState.Enabled)
		{
		}

		public async Task ShowAnalyticsConsentDialog()
		{
			if (!AnalyticsService.EnabledInBuild)
			{
				throw new InvalidOperationException("Attempted to display the analytics consent dialog with analytics fully disabled in the build.");
			}
			MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.ThreeButtons);
			messageDialogScript.MessageText = "This game may collect anonymous data that can be used to help improve the gameplay experience. We need your consent to collect this data. We totally understand if you would prefer to not participate. You can change your choice at any time in the game settings. Please select an option below.";
			messageDialogScript.ButtonTextMaxLines = 2;
			messageDialogScript.CancelButtonText = "More Info";
			messageDialogScript.MiddleButtonText = "I Do NOT Consent";
			messageDialogScript.OkayButtonText = "I Consent";
			messageDialogScript.CancelClicked += delegate
			{
				Application.OpenURL(AnalyticsService.PrivacyPolicyUrl);
			};
			messageDialogScript.MiddleClicked += delegate(MessageDialogScript d)
			{
				HandleAnalyticsConsentDialogChoice(d, consentProvided: false);
			};
			messageDialogScript.OkayClicked += delegate(MessageDialogScript d)
			{
				HandleAnalyticsConsentDialogChoice(d, consentProvided: true);
			};
			await messageDialogScript;
		}

		protected override void InitializeSettings()
		{
			Analytics = CreateEnum<AnalyticsState>("Analytics").SetDescription("The game may collect data for the developers to analyze and improve the gameplay experience. You may opt out of this by disabling this setting.").SetState((!AnalyticsService.EnabledInBuild) ? SettingState.Disabled : SettingState.Enabled).SetVisibility(() => (!AnalyticsService.Initialized) ? SettingVisibility.Hidden : SettingVisibility.Default)
				.SetDefault(AnalyticsState.DisabledPendingConsent)
				.OnChanged(OnAnalyticsConsentChanged);
			PrivacyOptionsButton = CreateButton("Privacy Options", "Modify").SetDescription("Click this button to modify your privacy preferences in accordance with the General Data Protection Regulation (GDPR).").SetState((!AdsService.EnabledInBuild) ? SettingState.Disabled : SettingState.Enabled).SetVisibility(() => (!AdsService.CanModifyPrivacyOptions) ? SettingVisibility.Hidden : SettingVisibility.Default)
				.AddClickEvent(PrivacyOptionsButtonClicked);
		}

		private void HandleAnalyticsConsentDialogChoice(MessageDialogScript dialog, bool consentProvided)
		{
			_suppressAnalyticsConsentChangedCallback = true;
			try
			{
				Analytics.UpdateAndCommit((!consentProvided) ? AnalyticsState.Disabled : AnalyticsState.Enabled);
			}
			finally
			{
				_suppressAnalyticsConsentChangedCallback = false;
			}
			Game.Instance.Settings.Save();
			dialog.Close();
		}

		private void OnAnalyticsConsentChanged(object sender, EventArgs e)
		{
			if (!_suppressAnalyticsConsentChangedCallback && AnalyticsService.Initialized)
			{
				AnalyticsService.OnAnalyticsConsentChanged();
			}
		}

		private void PrivacyOptionsButtonClicked(object sender, SettingChangedEventArgs<int> e)
		{
			AdsService.ShowPrivacyOptionsForm();
		}
	}
}
