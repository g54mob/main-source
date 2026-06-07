using System;
using UnityEngine;
using VoxelBusters.CoreLibrary;

namespace VoxelBusters.EssentialKit
{
	[Serializable]
	public class RateMyAppUnitySettings : SettingsPropertyGroup
	{
		[SerializeField]
		[Tooltip("Automatically show the rating prompt when conditions are met. This presents as soon as conditions are met on app launch. Disable this if you want to control on when to show it with the help of RateMyApp.IsAllowedToRate + RateMyApp.AskForReviewNow methods.")]
		private bool m_autoShow;

		[Tooltip("Allow users to rate the app again in a new version, even if they have rated it previously. If enabled, users will be prompted to provide feedback on the new version.")]
		[SerializeField]
		private bool m_allowReratingForNewVersion;

		[Space]
		[SerializeField]
		[Tooltip("Confirmation dialog settings.")]
		private RateMyAppConfirmationDialogSettings m_confirmationDialogSettings;

		[SerializeField]
		[Tooltip("Constraints to meet for rating.")]
		private RateMyAppConstraints m_contraintsSettings;

		public bool AllowReratingForNewVersion => false;

		public bool AutoShow => false;

		public RateMyAppConfirmationDialogSettings ConfirmationDialogSettings => null;

		public RateMyAppConstraints ConstraintsSettings => null;

		public RateMyAppUnitySettings(bool isEnabled = true, RateMyAppConfirmationDialogSettings dialogSettings = null, RateMyAppConstraints defaultValidatorSettings = null, bool allowRatingAgainForNewVersion = false, bool autoShowWhenConditionsAreMet = true)
			: base(null, isEnabled: false)
		{
		}
	}
}
