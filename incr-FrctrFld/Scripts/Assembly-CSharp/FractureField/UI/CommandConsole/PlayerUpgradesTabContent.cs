using UnityEngine;

namespace FractureField.UI.CommandConsole
{
	public class PlayerUpgradesTabContent : CommandConsoleTabContent
	{
		[SerializeField]
		private CommandConsoleUpgradeRow _fractureUpgradeRow;

		[SerializeField]
		private CommandConsoleUpgradeRow _hitSpeedUpgradeRow;

		[SerializeField]
		private CommandConsoleUpgradeRow _critChanceUpgradeRow;

		[SerializeField]
		private CommandConsoleUpgradeRow _critMultiplierUpgradeRow;

		[SerializeField]
		private CommandConsoleUpgradeRow _pierceUpgradeRow;

		protected override void Awake()
		{
		}

		private void SetupUpgradeRows()
		{
		}
	}
}
