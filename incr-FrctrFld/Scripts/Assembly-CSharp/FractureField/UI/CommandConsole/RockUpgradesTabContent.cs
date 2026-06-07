using System.Collections.Generic;
using FractureField.Rocks;
using UnityEngine;
using UnityEngine.UI;

namespace FractureField.UI.CommandConsole
{
	public class RockUpgradesTabContent : CommandConsoleTabContent
	{
		[Header("References")]
		[SerializeField]
		private CommandConsoleTabs _rockTabs1;

		[SerializeField]
		private CommandConsoleTabs _rockTabs2;

		[SerializeField]
		private CommandConsoleTabs _rockTabs3;

		[SerializeField]
		private CommandConsoleUpgradeRow _yieldUpgradeRow;

		[SerializeField]
		private CommandConsoleUpgradeRow _damageUpgradeRow;

		[SerializeField]
		private CommandConsoleUpgradeRow _hardnessUpgradeRow;

		[SerializeField]
		private CommandConsoleUpgradeRow _capacityUpgradeRow;

		[SerializeField]
		private CommandConsoleUpgradeRow _transitionChanceUpgradeRow;

		[SerializeField]
		private CommandConsoleUpgradeRow _layerPierceUpgradeRow;

		[SerializeField]
		private CommandConsoleUpgradeRow _unlockNextLayerRow;

		[SerializeField]
		private CommandConsoleUpgradeRow _unlockWorldFractureRow;

		[SerializeField]
		private CommandConsoleUpgradeRow _unlockRealityShatterRow;

		[SerializeField]
		private CommandConsoleUpgradeRow _unlockDroneHubRow;

		[SerializeField]
		private List<Image> _rockImages;

		[SerializeField]
		private List<Image> _rockCurrencyImages;

		[SerializeField]
		private List<Image> _previousRockImages;

		[SerializeField]
		private List<Image> _nextRockImages;

		private RockLayerType _layerType;

		protected override void Awake()
		{
		}

		private void Setup()
		{
		}

		private void OnPrestigeLayerReset()
		{
		}

		private void OnKeyPressed()
		{
		}

		private void OnRockTabs1Changed()
		{
		}

		private void OnRockTabs2Changed()
		{
		}

		private void OnRockTabs3Changed()
		{
		}

		public void SetLayerType(RockLayerType layerType)
		{
		}

		private void SetupRows()
		{
		}

		private void TrySetupRow(CommandConsoleUpgradeRow row, string upgradeId)
		{
		}
	}
}
