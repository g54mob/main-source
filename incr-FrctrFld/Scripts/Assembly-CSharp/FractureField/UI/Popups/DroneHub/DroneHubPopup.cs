using System.Collections.Generic;
using FractureField.Prestige.UI;
using FractureField.UI.Components;
using FractureField.UI.Components.Buttons;
using Reactivity.Unity.Components;
using TMPro;
using UnityEngine;

namespace FractureField.UI.Popups.DroneHub
{
	public class DroneHubPopup : Popup
	{
		[Header("References")]
		[SerializeField]
		private RButtonComponent _hideDescriptionsButton;

		[SerializeField]
		private GameObject _infoGO;

		[SerializeField]
		private TMP_Text _descriptionText;

		[SerializeField]
		private GameObject _demoBanner;

		[SerializeField]
		private RText _droneCoresText;

		[SerializeField]
		private RText _droneSlotsText;

		[SerializeField]
		private List<DroneHangarRow> _droneHangarRows;

		[SerializeField]
		private ToggleWithLabel _isEnabledToggle;

		[Header("Drone Counts")]
		[SerializeField]
		private RText _hammerCountText;

		[SerializeField]
		private RText _sentryCountText;

		[SerializeField]
		private RText _collectorCountText;

		[SerializeField]
		private RText _pierceCountText;

		[SerializeField]
		private RText _supervisorCountText;

		[SerializeField]
		private RText _shatterCountText;

		[SerializeField]
		private RText _boostCountText;

		[Header("Sentry Upgrade Rows")]
		[SerializeField]
		private PrestigeUpgradeRow _sentryChassisRow;

		[SerializeField]
		private PrestigeUpgradeRow _sentryRangefinderRow;

		[Header("Collector Upgrade Rows")]
		[SerializeField]
		private PrestigeUpgradeRow _collectorChassisRow;

		[SerializeField]
		private PrestigeUpgradeRow _collectorSiphonRateRow;

		[SerializeField]
		private PrestigeUpgradeRow _collectorSiphonExtractorRow;

		[Header("Pierce Upgrade Rows")]
		[SerializeField]
		private PrestigeUpgradeRow _pierceChassisRow;

		[SerializeField]
		private PrestigeUpgradeRow _pierceTungstenTipRow;

		[Header("Supervisor Upgrade Rows")]
		[SerializeField]
		private PrestigeUpgradeRow _supervisorChassisRow;

		[SerializeField]
		private PrestigeUpgradeRow _supervisorGetBackToWorkRow;

		[Header("Shatter Upgrade Rows")]
		[SerializeField]
		private PrestigeUpgradeRow _shatterChassisRow;

		[SerializeField]
		private PrestigeUpgradeRow _shatterBlastRadiusRow;

		[Header("Boost Upgrade Rows")]
		[SerializeField]
		private PrestigeUpgradeRow _boostChassisRow;

		[SerializeField]
		private PrestigeUpgradeRow _boostAuraRadiusRow;

		[SerializeField]
		private PrestigeUpgradeRow _boostAuraOfPowerRow;

		[SerializeField]
		private PrestigeUpgradeRow _boostAuraOfEfficiencyRow;

		[SerializeField]
		private PrestigeUpgradeRow _boostBuffDurationRow;

		protected override void Awake()
		{
		}

		private void Setup()
		{
		}

		public void ClickedHideDescriptions()
		{
		}

		private void OnPrioritiesChanged()
		{
		}
	}
}
