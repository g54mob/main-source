using System.Collections.Generic;
using FractureField.Prestige.UI;
using FractureField.UI.CommandConsole;
using FractureField.UI.Components.Buttons;
using Reactivity.Unity.Components;
using UnityEngine;
using UnityEngine.UI;

namespace FractureField.UI.Popups.RealityShatter
{
	public class RealityShatterPopup : Popup
	{
		[Header("References")]
		[SerializeField]
		private RText _availableRealityShardsText;

		[SerializeField]
		private RText _pendingRealityShardsText;

		[SerializeField]
		private RText _timeInRunText;

		[SerializeField]
		private RText _realityShatterCountText;

		[SerializeField]
		private RButtonComponent _shatterRealityButton;

		[SerializeField]
		private CommandConsoleTabs _upgradeTabs;

		[SerializeField]
		private CommandConsoleTabs _rocksTabs_Row1;

		[SerializeField]
		private CommandConsoleTabs _rocksTabs_Row2;

		[SerializeField]
		private RComponent _rockLayers1to3GO;

		[SerializeField]
		private RComponent _rockLayers4to5GO;

		[SerializeField]
		private RComponent _rockLayersSingleGO;

		[Header("Player Stats Upgrade Rows")]
		[SerializeField]
		private PrestigeUpgradeRow _rowFracturedMindMkII;

		[SerializeField]
		private PrestigeUpgradeRow _rowGeologistsInsightMkII;

		[SerializeField]
		private PrestigeUpgradeRow _rowSwiftStrikesMkII;

		[SerializeField]
		private PrestigeUpgradeRow _rowExtendedReach;

		[SerializeField]
		private PrestigeUpgradeRow _rowToolLegacy;

		[SerializeField]
		private PrestigeUpgradeRow _rowLuckyStrikeMkII;

		[SerializeField]
		private PrestigeUpgradeRow _rowDevastatingBlowMkII;

		[SerializeField]
		private PrestigeUpgradeRow _rowCriticalCascade;

		[SerializeField]
		private PrestigeUpgradeRow _rowAdeptMiner;

		[SerializeField]
		private PrestigeUpgradeRow _rowMuscleMemory;

		[Header("Quarry (General) upgrades")]
		[SerializeField]
		private PrestigeUpgradeRow _rowDustMultiplierMkII;

		[SerializeField]
		private PrestigeUpgradeRow _rowQuarryExpansionMkII;

		[SerializeField]
		private PrestigeUpgradeRow _rowAnomalousYieldsMkII;

		[SerializeField]
		private PrestigeUpgradeRow _rowGeologicalHasteMkII;

		[SerializeField]
		private PrestigeUpgradeRow _rowCoreSaturationMkII;

		[SerializeField]
		private PrestigeUpgradeRow _rowSuddenAppearance;

		[SerializeField]
		private PrestigeUpgradeRow _rowGeodeClusters;

		[SerializeField]
		private PrestigeUpgradeRow _rowGeologicalMemory;

		[Header("Rock Layer Upgrades")]
		[SerializeField]
		private PrestigeUpgradeRow _rowLayers1to3RealityPurity;

		[SerializeField]
		private PrestigeUpgradeRow _rowLayers1to3EfficientProspecting;

		[SerializeField]
		private PrestigeUpgradeRow _rowLayers1to3GeologicalErosion;

		[SerializeField]
		private PrestigeUpgradeRow _rowLayers4to5RealityPurity;

		[SerializeField]
		private PrestigeUpgradeRow _rowLayers4to5EfficientProspecting;

		[SerializeField]
		private PrestigeUpgradeRow _rowLayers4to5GeologicalErosion;

		[SerializeField]
		private PrestigeUpgradeRow _rowSingleLayerRealityPurity;

		[SerializeField]
		private PrestigeUpgradeRow _rowSingleLayerEfficientProspecting;

		[SerializeField]
		private PrestigeUpgradeRow _rowSingleLayerGeologicalErosion;

		[SerializeField]
		private List<Image> _rowSingleLayerCurrencyImages;

		[SerializeField]
		private List<Image> _rowSingleLayerRockImages;

		[Header("Drones Upgrades")]
		[SerializeField]
		private PrestigeUpgradeRow _rowDroneSchematicsMkII;

		[SerializeField]
		private PrestigeUpgradeRow _rowMassProduction;

		[SerializeField]
		private PrestigeUpgradeRow _rowSwarmTactics;

		[SerializeField]
		private PrestigeUpgradeRow _rowPredictiveDronesMkII;

		[SerializeField]
		private PrestigeUpgradeRow _rowCoreSynthesis;

		[SerializeField]
		private PrestigeUpgradeRow _rowPersistentHub;

		[SerializeField]
		private PrestigeUpgradeRow _rowDroneHubForeman;

		[SerializeField]
		private PrestigeUpgradeRow _rowDroneBlueprints;

		[Header("Bombs Upgrades")]
		[SerializeField]
		private PrestigeUpgradeRow _rowAdvancedOrdnance;

		[SerializeField]
		private PrestigeUpgradeRow _rowSurplusMunitions;

		[SerializeField]
		private PrestigeUpgradeRow _rowBombSchematics;

		[SerializeField]
		private PrestigeUpgradeRow _rowArmorPiercingWarhead;

		[SerializeField]
		private PrestigeUpgradeRow _rowFocusedBombardment;

		[SerializeField]
		private PrestigeUpgradeRow _rowExtractorCharges;

		[Header("Meta Upgrades")]
		[SerializeField]
		private PrestigeUpgradeRow _rowSingularityGain;

		[SerializeField]
		private PrestigeUpgradeRow _rowFracturedCosts;

		[SerializeField]
		private PrestigeUpgradeRow _rowWorldFractureForeman;

		[SerializeField]
		private PrestigeUpgradeRow _rowPrestigeMomentum;

		[SerializeField]
		private PrestigeUpgradeRow _rowPersistentForeman;

		[SerializeField]
		private PrestigeUpgradeRow _rowForemanLegacy;

		[SerializeField]
		private PrestigeUpgradeRow _rowForemanSquared;

		[SerializeField]
		private PrestigeUpgradeRow _rowFractureMemory;

		[SerializeField]
		private PrestigeUpgradeRow _rowRealityShatterForeman;

		protected override void Awake()
		{
		}

		private void Setup()
		{
		}

		private void SetupUpgrades()
		{
		}

		public void ClickedShatterReality()
		{
		}
	}
}
