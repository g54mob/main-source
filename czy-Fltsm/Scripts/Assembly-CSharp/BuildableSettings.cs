using System.Collections.Generic;
using I2.Loc;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Settings/Buildable Settings")]
public class BuildableSettings : ScriptableObject, IComparer<Buildable>
{
	public enum WeightModes
	{
		Properties = 0,
		Items = 1
	}

	[Header("Buildables")]
	[SerializeField]
	private BuildableProperties[] _buildables;

	public DecorationProperties[] Decorations;

	public PlaceableUtilityProperties[] Utilties;

	[Tooltip("All the potential buildable categories.")]
	public BuildableCategory[] Categories = new BuildableCategory[0];

	[Space]
	[Tooltip("Buoy prefab used when building constructions.")]
	public GameObject BuildBuoy;

	[Header("Decoration prefabs")]
	[SerializeField]
	private Decoration _decorationPrefab;

	[SerializeField]
	private Decoration _cropDecorationPrefab;

	[SerializeField]
	private BuildableProperties _energyPoleBuildableProperties;

	[SerializeField]
	private DecorationProperties _energyPoleDecorationProperties;

	[SerializeField]
	private Decoration _energyPoleDecorationPrefab;

	[Header("Grid")]
	public VisualBoundary BoundaryPrefab;

	public int GridSize = 1;

	public int GridWidthDisplayPadding = 3;

	public int GridHeightDisplayPadding = 3;

	[Header("Props")]
	[Tooltip("The prefab for footbridges.")]
	public GameObject FootbridgePrefab;

	[Header("Pathfinding")]
	[Tooltip("The prefab for the Hierarchical node marker placed on objects placed on the construction graph.")]
	public HierarchicalNodeMarker HierarchicalNodeMarkerPrefab;

	[Header("Producers")]
	[Tooltip("Maximum amount of queued recipes in producers.")]
	public int MaximumQueuedRecipes = 7;

	[Tooltip("Threshold the fuel needs to be at before agents will refill it.")]
	public float FuelRefillThreshold = 0.5f;

	[Header("Resource Providers")]
	[Tooltip("The delay between when an item is blocked and de the blocked item malfunction is shown")]
	public float ItemBlockedMalFunctionDelay;

	[Header("Weight")]
	[Tooltip("Select the way the wight for a Buildable is determined")]
	public WeightModes WeightMode;

	[SerializeField]
	private LocalizedString _weightTotalString = null;

	[Header("Information")]
	[Tooltip("Tooltip text letting the player know that the buildable is locked into the Haul From state.")]
	public LocalizedString HaulFromTooltip = null;

	[Tooltip("Tooltip text letting the player know that the buildable is locked into the Haul To state.")]
	public LocalizedString UpgradeHaulToTooltip = null;

	[Tooltip("Tooltip when a building can be deconstructed, telling the player what resources they will get.")]
	public LocalizedString DeconstructionTooltip = null;

	public LocalizedString CancelDeconstructionTooltip = null;

	[Header("Cabels")]
	public float CableLinkRange = 20f;

	public float CableRadius = 0.075f;

	public float CableSegmentLength = 1f;

	[Range(3f, 16f)]
	public int CableSideAmount = 6;

	[Header("Icons")]
	public IconProperties MultipleMalfunctionsIconProperties;

	[Space]
	public PlaceableAlertProperties StatusResourcesComingProperties;

	public PlaceableAlertProperties StatusWaitingForResourcesProperties;

	public PlaceableAlertProperties StatusBuildingProperties;

	public PlaceableAlertProperties StatusWaitingForConstructorProperties;

	public PlaceableAlertProperties StatusWaitingForDeconstructorProperties;

	public PlaceableAlertProperties StatusStoppingConstructionProperties;

	public PlaceableAlertProperties StatusDeconstructingProperties;

	public PlaceableAlertProperties StatusUpgradingProperties;

	public PlaceableAlertProperties StatusProducerHaulingItemstoStorageProperties;

	public PlaceableAlertProperties StatusSalvagingHaulingItemstoStorageProperties;

	public PlaceableAlertProperties StatusUpgradeHaulingItemstoStorageProperties;

	public PlaceableAlertProperties StatusIdleProperties;

	public PlaceableAlertProperties StatusWorkingProperties;

	public PlaceableAlertProperties StatusQueueEmptyProperties;

	public PlaceableAlertProperties StatusNoRecipeSelectedProperties;

	public PlaceableAlertProperties StatusWaitingForProducerProperties;

	public PlaceableAlertProperties StatusInactiveProperties;

	[Space]
	public PlaceableAlertProperties ErrorExportStorageFullProperties;

	public PlaceableAlertProperties ErrorNoItemsToSalvageProperties;

	public PlaceableAlertProperties ErrorSeagullsHungryProperties;

	public PlaceableAlertProperties ErrorProductionLimitReachedProperties;

	public PlaceableAlertProperties ErrorItemsMissingProperties;

	public PlaceableAlertProperties ErrorNotLinkedToEnergyGridProperties;

	public PlaceableAlertProperties ErrorNoEnergyProperties;

	public PlaceableAlertProperties ErrorInefficientGridProperties;

	public PlaceableAlertProperties ErrorResourceProviderBlocked;

	public BuildableProperties[] Buildables => _buildables;

	public Decoration DecorationPrefab => _decorationPrefab;

	public Decoration CropDecorationPrefab => _cropDecorationPrefab;

	public BuildableProperties EnergyPoleBuildableProperties => _energyPoleBuildableProperties;

	public DecorationProperties EnergyPoleDecorationProperties => _energyPoleDecorationProperties;

	public Decoration EnergyPoleDecorationPrefab => _energyPoleDecorationPrefab;

	public LocalizedString WeightTotalString => _weightTotalString;

	public void SortBuildableList(List<Buildable> buildablesToSort)
	{
		for (int i = 0; i < _buildables.Length; i++)
		{
			_buildables[i].OrderIndex = i;
		}
		Sorting.SlowSort(buildablesToSort, this);
	}

	public int Compare(Buildable x, Buildable y)
	{
		return x.Properties.OrderIndex - y.Properties.OrderIndex;
	}
}
