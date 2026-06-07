using Reactivity.Unity.Components;
using UnityEngine;

namespace FractureField.UI.CommandConsole
{
	public class GeneralStatsTabContent : CommandConsoleTabContent
	{
		[Header("General")]
		[SerializeField]
		private RText _timePlayedText;

		[Header("Mining")]
		[SerializeField]
		private RText _manualHitsText;

		[SerializeField]
		private RText _manualDamageText;

		[SerializeField]
		private RText _droneHitsText;

		[SerializeField]
		private RText _droneDamageText;

		[SerializeField]
		private RText _bombsUsedText;

		[SerializeField]
		private RText _bombHitsText;

		[SerializeField]
		private RText _bombDamageText;

		[SerializeField]
		private RText _highestManualDamageText;

		[SerializeField]
		private RText _totalLayersDestroyedText;

		[Header("Economy")]
		[SerializeField]
		private RText _upgradesPurchasedText;

		protected override void Awake()
		{
		}

		private void SetupStats()
		{
		}
	}
}
