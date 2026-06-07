using FractureField.Prestige.UI;
using FractureField.UI.Components.Buttons;
using Reactivity.Unity.Components;
using UnityEngine;

namespace FractureField.UI.Popups.WorldFracture
{
	public class WorldFracturePopup : Popup
	{
		[Header("References")]
		[SerializeField]
		private GameObject _remainingInDemoGO;

		[SerializeField]
		private RText _remainingInDemoText;

		[SerializeField]
		private RText _availableCoreFragmentsText;

		[SerializeField]
		private RText _pendingCoreFragmentsText;

		[SerializeField]
		private RText _timeInRunText;

		[SerializeField]
		private RText _worldFractureCountText;

		[SerializeField]
		private RButtonComponent _fractureTheWorldButton;

		[SerializeField]
		private PrestigeUpgradeRow _fracturedMindUpgradeRow;

		[SerializeField]
		private PrestigeUpgradeRow _geologistsInsightUpgradeRow;

		[SerializeField]
		private PrestigeUpgradeRow _quarryExpansionUpgradeRow;

		[SerializeField]
		private PrestigeUpgradeRow _anomalousYieldsUpgradeRow;

		[SerializeField]
		private PrestigeUpgradeRow _geologicalHasteUpgradeRow;

		[SerializeField]
		private PrestigeUpgradeRow _predictiveDronesUpgradeRow;

		[SerializeField]
		private PrestigeUpgradeRow _coreSaturationUpgradeRow;

		[SerializeField]
		private PrestigeUpgradeRow _coreExtractionUpgradeRow;

		[SerializeField]
		private PrestigeUpgradeRow _quarryForemanUpgradeRow;

		[SerializeField]
		private PrestigeUpgradeRow _droneSchematicsUpgradeRow;

		[SerializeField]
		private PrestigeUpgradeRow _dustMultiplierUpgradeRow;

		[SerializeField]
		private PrestigeUpgradeRow _stoneFragmentsMultiplierUpgradeRow;

		[SerializeField]
		private PrestigeUpgradeRow _clayTabletsMultiplierUpgradeRow;

		[SerializeField]
		private PrestigeUpgradeRow _sandstoneShardsMultiplierUpgradeRow;

		[SerializeField]
		private PrestigeUpgradeRow _quartzCrystalsMultiplierUpgradeRow;

		[SerializeField]
		private PrestigeUpgradeRow _ironFragmentsMultiplierUpgradeRow;

		[SerializeField]
		private PrestigeUpgradeRow _silverTabletsMultiplierUpgradeRow;

		[SerializeField]
		private PrestigeUpgradeRow _goldShardsMultiplierUpgradeRow;

		[SerializeField]
		private PrestigeUpgradeRow _diamondCrystalsMultiplierUpgradeRow;

		private const int MaxWorldFracturesInDemo = 2;

		private bool HasReachedDemoLimit => false;

		protected override void Awake()
		{
		}

		private void Setup()
		{
		}

		public void ClickedFractureTheWorld()
		{
		}
	}
}
