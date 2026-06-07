using UnityEngine;

namespace FractureField.UI.CommandConsole
{
	public class DroneUpgradesTabContent : CommandConsoleTabContent
	{
		[SerializeField]
		private CommandConsoleUpgradeRow _droneCountUpgradeRow;

		[SerializeField]
		private CommandConsoleUpgradeRow _droneMoveSpeedUpgradeRow;

		[SerializeField]
		private CommandConsoleUpgradeRow _droneHitSpeedUpgradeRow;

		[SerializeField]
		private CommandConsoleUpgradeRow _droneDamageUpgradeRow;

		protected override void Awake()
		{
		}

		private void Setup()
		{
		}
	}
}
