using UnityEngine;

namespace FractureField.UI.CommandConsole
{
	public class BombUpgradesTabContent : CommandConsoleTabContent
	{
		[SerializeField]
		private CommandConsoleUpgradeRow _bombMaxChargesUpgradeRow;

		[SerializeField]
		private CommandConsoleUpgradeRow _bombBlastRadiusUpgradeRow;

		[SerializeField]
		private CommandConsoleUpgradeRow _bombCooldownUpgradeRow;

		[SerializeField]
		private CommandConsoleUpgradeRow _bombDamageUpgradeRow;

		protected override void Awake()
		{
		}

		private void Setup()
		{
		}
	}
}
