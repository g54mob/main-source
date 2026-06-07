using System.Collections.Generic;
using FractureField.Rocks;
using FractureField.UI.CommandConsole;
using FractureField.UI.Components;
using FractureField.UI.Components.Buttons;
using FractureField.Upgrades;
using Reactivity.Unity.Components;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FractureField.UI.Popups.QuarryForeman
{
	public class QuarryForemanRockLayerRow : MonoBehaviour
	{
		[Header("Variables")]
		public RockLayerType RockLayerType;

		[Header("References")]
		[SerializeField]
		private Image _rockImage;

		[SerializeField]
		private TMP_Text _titleText;

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

		[SerializeField]
		private RockUpgradesTabContent _rockUpgradesTabContent;

		private Upgrade IntervalUpgrade => null;

		private void Awake()
		{
		}

		public void Setup(RockLayerType rockLayerType)
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
