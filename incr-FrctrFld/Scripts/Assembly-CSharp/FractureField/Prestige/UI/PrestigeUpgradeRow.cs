using FractureField.UI.Components.Buttons;
using FractureField.Upgrades;
using Reactivity.Unity.Components;
using UnityEngine;
using UnityEngine.UI;

namespace FractureField.Prestige.UI
{
	public class PrestigeUpgradeRow : RComponent
	{
		[Header("Variables")]
		[SerializeField]
		private PrestigeLayerType _prestigeLayer;

		[Header("References")]
		[SerializeField]
		private Image _iconImage;

		[SerializeField]
		private RText _titleText;

		[SerializeField]
		private RText _descriptionText;

		[SerializeField]
		private RText _effectText;

		[SerializeField]
		private RText _levelText;

		[SerializeField]
		private RButtonComponent _upgradeButton;

		[SerializeField]
		private GameObject _lockedInDemoBanner;

		private Upgrade _upgrade;

		public void Setup(Upgrade upgrade)
		{
		}

		public void ClickedUpgrade()
		{
		}
	}
}
