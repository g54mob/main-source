using System.Collections.Generic;
using I2.Loc;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Point of Interest")]
public class PointOfInterestProperties : PersistentProperties
{
	[Header("General")]
	[SerializeField]
	private LocalizedString _title = null;

	[Tooltip("Radius for this point of interest.")]
	public float Radius = 5f;

	[Tooltip("Radius to keep clear in the center of the point of interest.")]
	public float ClearRadius;

	[Tooltip("Use Gaussian distribution when placing flotsam items. This results in more organic looking spawns. When disabled the pieces will be placed uniformly.")]
	public bool UseGaussianDistribution = true;

	[Tooltip("Whether the flotsam of this point of interest can be salvaged or not.")]
	public bool CanBeSalvaged = true;

	[Tooltip("Icon of the whole point of interest.")]
	public VisualPrefab MapVisualPrefab;

	[Header("Spawning")]
	[Tooltip("The point of interest won't spawn in the construction radius.")]
	public bool NoSpawnInConstructionRadius;

	[Header("Composite Flotsam")]
	[Tooltip("Get ALL the guaranteed composites. When disabled it will at least give one based on the chance.")]
	[SerializeField]
	private bool _includeAllGuaranteedComposites;

	[Tooltip("Excludes guaranteed composites from the general spawn list. When disabled guaranteed composites can still spawn as if they are a regular part of the spawn list.")]
	[SerializeField]
	private bool _excludeGuaranteedComposites;

	[Tooltip("Place the first composited piece on the center of the point of interest.")]
	public bool PlaceFirstCompositeInCenter = true;

	[Tooltip("A random amount of composite flotsam will be spawned.")]
	[SerializeField]
	private bool _randomCompositeAmount;

	[Tooltip("Minimum amount of composite flotsam to spawn when set to random amount.")]
	[SerializeField]
	[ConditionalHide("_randomCompositeAmount", true)]
	private int _minimumCompositeCount;

	[Tooltip("Maximum amount of composite flotsam to spawn when set to random amount.")]
	[SerializeField]
	[ConditionalHide("_randomCompositeAmount", true)]
	private int _maximumCompositeCount = 10;

	[Tooltip("Fixed amount of composite flotsam to spawn.")]
	[SerializeField]
	[ConditionalHide("_randomCompositeAmount", true, true)]
	private int _fixedCompositeCount = 1;

	[Space]
	[Tooltip("Composited flotsam for this point of interest.")]
	[SerializeField]
	private List<WeightedCompositeProperty> _compositedFlotsam = new List<WeightedCompositeProperty>();

	[Header("Flotsam Items")]
	[Tooltip("Get ALL the guaranteed items. When disabled it will at least give one based on the chance.")]
	[SerializeField]
	private bool _includeAllGuaranteedItems;

	[Tooltip("Excludes guaranteed items from the general spawn list. When disabled guaranteed items can still spawn as if they are a regular part of the spawn list.")]
	[SerializeField]
	private bool _excludeGuaranteedItems;

	[Tooltip("A random amount of flotsam items will be spawned.")]
	[SerializeField]
	private bool _randomItemAmount = true;

	[Tooltip("Minimum amount of flotsam items to spawn when set to random amount.")]
	[SerializeField]
	[ConditionalHide("_randomItemAmount", true)]
	private int _minimumItemCount;

	[Tooltip("Maximum amount of flotsam items to spawn when set to random amount.")]
	[SerializeField]
	[ConditionalHide("_randomItemAmount", true)]
	private int _maximumItemCount = 10;

	[Tooltip("Fixed amount of flotsam items to spawn.")]
	[SerializeField]
	[ConditionalHide("_randomItemAmount", true, true)]
	private int _fixedItemCount = 1;

	[Space]
	[Tooltip("Items to spawn for this point of interest.")]
	[SerializeField]
	private List<WeightedItemProperty> _flotsamItems = new List<WeightedItemProperty>();

	[Space]
	[Header("Map Visual")]
	[SerializeField]
	[Tooltip("The count used to scale the map visual. If the count is 0 or smaller the scale is based on the size of the patch.")]
	private int _mapVisualCount;

	[SerializeField]
	[Range(0f, 1f)]
	private float _mapVisualMinimumScale = 0.35f;

	[SerializeField]
	private Sprite _bearingIcon;

	[Header("Debug")]
	public Sprite DebugIcon;

	public float DebugRadius = 30f;

	public override Types Type => Types.PointOfInterestProperties;

	public LocalizedString Title => _title;

	public int MapVisualCount => _mapVisualCount;

	public float MapVisualMinimumScale => _mapVisualMinimumScale;

	public Sprite BearingIcon => _bearingIcon;

	public int ReturnMaximumPiecesCount()
	{
		int num = 0;
		num = ((!_randomCompositeAmount) ? (num + _fixedCompositeCount) : (num + _maximumCompositeCount));
		if (_randomItemAmount)
		{
			return num + _maximumItemCount;
		}
		return num + _fixedItemCount;
	}

	public List<CompositedFlotsamProperties> ReturnCompositedFlotsam()
	{
		int num = (_randomCompositeAmount ? Random.Range(_minimumCompositeCount, _maximumCompositeCount + 1) : _fixedCompositeCount);
		return WeightedItem.ReturnCompositedFlotsamProperties(_compositedFlotsam, num, _includeAllGuaranteedComposites, _excludeGuaranteedComposites);
	}

	public ListPool<CompositedFlotsamProperties>.List ReturnAllCompositedFlotsamProperties()
	{
		ListPool<CompositedFlotsamProperties>.List list = ListPool<CompositedFlotsamProperties>.Get();
		foreach (WeightedCompositeProperty item in _compositedFlotsam)
		{
			list.AddUnique(item.CompositedFlotsamProperties);
		}
		return list;
	}

	public ListPool<ItemProperties>.List ReturnItems()
	{
		int num = (_randomItemAmount ? Random.Range(_minimumItemCount, _maximumItemCount + 1) : _fixedItemCount);
		return WeightedItem.ReturnItemProperties(_flotsamItems, num, _includeAllGuaranteedItems, _excludeGuaranteedItems);
	}
}
