using Reactivity.Unity.Components;
using UnityEngine;

namespace FractureField.UI.CommandConsole
{
	public class PlayerStatsTabContent : CommandConsoleTabContent
	{
		[SerializeField]
		private RText _fractureText;

		[SerializeField]
		private RText _hitSpeedText;

		[SerializeField]
		private RText _pierceText;

		[SerializeField]
		private RText _critChanceText;

		[SerializeField]
		private RText _critDamageText;

		protected override void Awake()
		{
		}

		private void SetupPlayerStats()
		{
		}
	}
}
