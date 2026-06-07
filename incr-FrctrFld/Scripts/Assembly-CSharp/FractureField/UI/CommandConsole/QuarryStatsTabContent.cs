using FractureField.UI.Components;
using Reactivity.Unity.Components;
using UnityEngine;

namespace FractureField.UI.CommandConsole
{
	public class QuarryStatsTabContent : CommandConsoleTabContent
	{
		[Header("References")]
		[SerializeField]
		private ToggleWithLabel _autoHitToggle;

		[SerializeField]
		private RComponent _quarryStatsGO;

		[SerializeField]
		private RComponent _rockStatsGO;

		[Header("Quarry References")]
		[SerializeField]
		private RText _totalRocksText;

		[SerializeField]
		private RText _stoneRocksText;

		[SerializeField]
		private RText _clayRocksText;

		[SerializeField]
		private RText _sandstoneRocksText;

		[SerializeField]
		private RText _quartzRocksText;

		[SerializeField]
		private RText _ironRocksText;

		[SerializeField]
		private RText _silverRocksText;

		[SerializeField]
		private RText _goldRocksText;

		[SerializeField]
		private RText _diamondRocksText;

		[SerializeField]
		private RText _obsidianRocksText;

		[SerializeField]
		private RText _starmetalRocksText;

		[SerializeField]
		private RText _voidstoneRocksText;

		[SerializeField]
		private RText _chroniteRocksText;

		[Header("Rock References")]
		[SerializeField]
		private RText _rockTitleText;

		[SerializeField]
		private RText _rockMaxHealthText;

		[SerializeField]
		private RText _rockHealthText;

		[SerializeField]
		private RText _rockHardnessText;

		[SerializeField]
		private RText _rockTotalYieldText;

		[SerializeField]
		private RText _rockDustYieldText;

		protected override void Awake()
		{
		}

		private void Setup()
		{
		}

		private void SetupQuarryStats()
		{
		}

		private void SetupRockStats()
		{
		}
	}
}
