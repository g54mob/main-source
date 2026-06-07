using System.Collections.Generic;
using FractureField.QuarryForeman;
using FractureField.UI.CommandConsole;
using FractureField.UI.Components;
using FractureField.UI.Components.Buttons;
using FractureField.Upgrades;
using Reactivity.Unity.Components;
using UnityEngine;

namespace FractureField.UI.Popups.QuarryForeman
{
	public class QuarryForemanPriorityRow : RComponent
	{
		[Header("Variables")]
		public QuarryForemanAutomationType PriorityType;

		[Header("References")]
		[SerializeField]
		private ToggleWithLabel _toggleWithLabel;

		[SerializeField]
		private RText _intervalText;

		[SerializeField]
		private RButtonComponent _upgradeButton;

		[SerializeField]
		private RComponent _upgradesEnabledGO;

		[SerializeField]
		private RText _upgradesEnabledText;

		[SerializeField]
		private RButtonComponent _manageUpgradesButton;

		[SerializeField]
		private GameObject _upgradesGO;

		[SerializeField]
		private List<CommandConsoleUpgradeRow> _upgradeRows;

		private Upgrade IntervalUpgrade => null;

		protected override void Awake()
		{
		}

		private void Setup()
		{
		}

		public void ClickedUpgrade()
		{
		}

		public void ClickedManageUpgrades()
		{
		}
	}
}
