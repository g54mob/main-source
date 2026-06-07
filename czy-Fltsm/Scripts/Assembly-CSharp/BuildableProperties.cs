using System;
using System.Text.RegularExpressions;
using FMODUnity;
using PajamaLlama.Variables;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Flotsam/Buildable/Buildable Properties")]
public class BuildableProperties : PlaceableProperties
{
	[Header("Buildable Properties")]
	public Buildable Prefab;

	[SerializeField]
	public ModuleProperties[] _modules;

	[SerializeField]
	private WalkwaySegmentProperties[] _walkwaySegments;

	[Tooltip("Show a notification on finishing this buildable.")]
	public bool NotificationOnFinished = true;

	[Space]
	[Tooltip("Determines if this buildable is buildable by default.")]
	public bool IsDefaultBuildable = true;

	[Tooltip("Cursor properties that are used when placing this buildable.")]
	public BuildableCursorProperties PlacementCursorProperties;

	[Header("Boundary")]
	[Tooltip("Array of points that make up the outline of this buildable.")]
	public Vector2[] Outline;

	public Vector2Polygon[] PathfindingOutlines;

	public bool UseCustomSize;

	[ConditionalHide(false, HideInInspector = true, ConditionalSourceField = "UseCustomSize")]
	public VisualBoundary BoundaryPrefab;

	[Header("Audio")]
	[Tooltip("Audio that is played when this buildable starts building.")]
	public EventReference FMODEventReference_StartBuild;

	[Tooltip("Audio that is played when this buildable is finished building.")]
	public EventReference FMODEventReference_FinishBuilding;

	[Tooltip("Audio that is played when this buildable is destroyed.")]
	public EventReference FMODEventReference_DestroyBuilding;

	[Tooltip("Audio that is played when this buildable is selected.")]
	public EventReference FMODEventReference_Select;

	[Header("Visuals")]
	[Tooltip("Sprite of this buildable. This is shown in the panel and the build menu.")]
	public Sprite IconSprite;

	[Tooltip("Header of this buildable. This is shown at the top of the panel.")]
	public Sprite HeaderSprite;

	[Tooltip("Sprite of this buildable's research. This is shown in the research panel.")]
	public Sprite ResearchSprite;

	[Tooltip("Texture of this buildable's research.")]
	public Texture ResearchTexture;

	[Tooltip("The possible visual prefabs of this buildable.")]
	public VisualPrefab[] Visuals;

	[Tooltip("Should the visual's forward be the same as the townhearts forward? (e.g. the engine is always rotated to match the orientation of the townheart)")]
	public bool VisualMatchesTownheartOrientation;

	[Tooltip("Build buoy that is placed when this buildable is under construction./nIf this is null, no building lines will be placed.")]
	public GameObject BuildBuoy;

	[Tooltip("Build rope that is placed when this buildable is under construction./nIf this is null, no building lines will be placed.")]
	public GameObject BuildRope;

	[Tooltip("Plop properties when this buildable is placed.")]
	public PlopProperties PlopProperties;

	[Tooltip("Cost to research this buildable.")]
	[SerializeField]
	private IntVariable _researchCost;

	[Tooltip("The buildable that is unlocked by researching this Buildable")]
	public BuildableProperties ResearchNext;

	[HideInInspector]
	public BuildableProperties ResearchPrevious;

	[Tooltip("When enabled, this buildable won't be worked unless one of the connected buildables is in the finished state.")]
	public bool NeedsTownConnection = true;

	[Header("Upgrades")]
	public BuildableProperties Upgrade;

	[Header("UI Panel")]
	[FormerlySerializedAs("MainUIElement")]
	public BuildablePanelElementId UIElements;

	[Tooltip("Show the on / off toggle when selecting this buildable.")]
	[SerializeField]
	[FormerlySerializedAs("ShowActivationElement")]
	private bool _showActivationElement;

	[Tooltip("Show all health / salvage elements when selecting this buildable.")]
	[SerializeField]
	[FormerlySerializedAs("ShowDurabilityRelatedElements")]
	private bool _showDurabilityElements = true;

	[Tooltip("Show workshop related elements when selecting this buildable.")]
	[FormerlySerializedAs("ShowProductionElements")]
	public bool ShowWorkshopElements;

	[Tooltip("Show farm related elements when selecting this buildable.")]
	public bool ShowFarmElements;

	[Tooltip("Show house related elements when selecting this buildable.")]
	public bool ShowHouseElements;

	[Tooltip("Overwrites the CanEject setting on the inventory view.")]
	public bool CanEjectFromStorage = true;

	[Tooltip("Show boat related elements when selecting this buildable.")]
	public bool ShowBoatElements;

	[Tooltip("Show sail related elements when selecting this buildable.")]
	public bool ShowSailElements;

	[Tooltip("Show research related elements when selecting this buildable.")]
	public bool ShowResearchElements;

	[Tooltip("Show mooring point related elements when selecting this buildable.")]
	public bool ShowMooringPointElements;

	[Tooltip("Show malfunction panel.")]
	public bool ShowMalfunctionElements = true;

	[Tooltip("Show birdhouse panel.")]
	public bool ShowBirdHouseElements;

	[Tooltip("Show energy item producer panel.")]
	public bool ShowEnergyItemProducerElements;

	[Tooltip("Show energy manual producer panel.")]
	public bool ShowEnergyManualProducerElements;

	public bool ShowEnergyGridLinkElements;

	public bool ShowEnergyStorageElements;

	public bool ShowEnergyGridEfficiency;

	public bool ShowFisherElements;

	public bool ShowSchoolElements;

	public bool ShowRadioElements;

	[Space]
	public bool ShowInSurvivalGuide = true;

	public TutorialID TutorialPageID;

	[NonSerialized]
	private string _cachedDescription;

	[NonSerialized]
	private float _energyCost = -1f;

	[NonSerialized]
	private CountedItemProperty[] _upgradeResources;

	public ModuleProperties[] Modules => _modules;

	public bool ShowActivationElement
	{
		get
		{
			if (!_showActivationElement)
			{
				return UIElements.HasFlag(BuildablePanelElementId.Activation);
			}
			return true;
		}
	}

	public bool ShowDurabilityElements
	{
		get
		{
			if (!_showDurabilityElements)
			{
				return UIElements.HasFlag(BuildablePanelElementId.Durability);
			}
			return true;
		}
	}

	public override Types Type => Types.BuildableProperties;

	public override string SurvivalGuideIdentifier => "buildable-" + base.name.ToLower();

	public int ResearchCost
	{
		get
		{
			if (!(_researchCost == null))
			{
				return _researchCost.Value;
			}
			return 0;
		}
	}

	public CountedItemProperty[] UpgradeResources
	{
		get
		{
			if (Upgrade == null)
			{
				_upgradeResources = new CountedItemProperty[0];
			}
			if (_upgradeResources == null)
			{
				using ListPool<CountedItemProperty>.List list = ListPool<CountedItemProperty>.Get();
				CountedItemProperty[] requiredResources = Upgrade.RequiredResources;
				foreach (CountedItemProperty countedItemProperty in requiredResources)
				{
					CountedItemProperty countedItemProperty2 = new CountedItemProperty(countedItemProperty.ItemProperties, countedItemProperty.Amount);
					CountedItemProperty[] requiredResources2 = base.RequiredResources;
					foreach (CountedItemProperty countedItemProperty3 in requiredResources2)
					{
						if (countedItemProperty3.ItemProperties == countedItemProperty2.ItemProperties)
						{
							countedItemProperty2.Amount -= countedItemProperty3.Amount;
						}
					}
					if (countedItemProperty2.Amount > 0)
					{
						list.Add(countedItemProperty2);
					}
				}
				_upgradeResources = list.ToArray();
			}
			return _upgradeResources;
		}
	}

	public override void ActivateCursor(CursorManager.CursorEvent deachtivatedCallback)
	{
		PlacementCursorProperties.Initialize(Prefab);
		GameManager.CursorManager.Activate(PlacementCursorProperties, deachtivatedCallback);
	}

	public override bool ReturnCanBePlaced(Community community, bool checkResources = true)
	{
		bool num = !base.RequiresMooringPoint || community.IsThereAMooringPointFree();
		bool flag = ReturnBuildableRequirement(community);
		bool flag2 = !checkResources || ResourceManager.AreCommunityResourcesAvailable(base.RequiredResources.IsNullOrEmpty() ? PlacementCursorProperties.ReturnRequiredResources(this) : base.RequiredResources);
		bool flag3 = base.IgnoreWeightForPlacement || Engine.CanTug(this);
		return num && flag && flag2 && flag3;
	}

	private bool ReturnBuildableRequirement(Community community)
	{
		return true;
	}

	public bool ReturnIsUpgarde()
	{
		BuildableProperties[] buildables = GameManager.Settings.BuildableSettings.Buildables;
		for (int i = 0; i < buildables.Length; i++)
		{
			if (buildables[i].Upgrade == this)
			{
				return true;
			}
		}
		return false;
	}

	public bool TryReturnUpgradesFrom(out BuildableProperties buildable)
	{
		int num = GameManager.Settings.BuildableSettings.Buildables.Length;
		for (int i = 0; i < num; i++)
		{
			buildable = GameManager.Settings.BuildableSettings.Buildables[i];
			if (buildable.Upgrade == this)
			{
				return true;
			}
		}
		buildable = null;
		return false;
	}

	public VisualBoundary ReturnBoundary()
	{
		if (UseCustomSize)
		{
			return BoundaryPrefab;
		}
		return GameSettings.Instance.BuildableSettings.BoundaryPrefab;
	}

	public override string GetDescription()
	{
		if (!string.IsNullOrEmpty(_cachedDescription))
		{
			return _cachedDescription;
		}
		_cachedDescription = base.Description;
		_cachedDescription = Regex.Replace(_cachedDescription, "%NAME%", $"<b>{base.Name}</b>", RegexOptions.IgnoreCase);
		_cachedDescription = Regex.Replace(_cachedDescription, "%RESEARCH%", ResearchCost.ToString(), RegexOptions.IgnoreCase);
		IBuildableExtendable[] componentsInChildren = Prefab.GetComponentsInChildren<IBuildableExtendable>();
		foreach (IBuildableExtendable buildableExtendable in componentsInChildren)
		{
			_cachedDescription = buildableExtendable.ReturnDescription(_cachedDescription);
		}
		return _cachedDescription;
	}

	public override CountedItemProperty[] ReturnTooltipRequiredResources(bool isUpgrade = false)
	{
		if (isUpgrade)
		{
			return UpgradeResources;
		}
		if (_requiredResources.IsNullOrEmpty())
		{
			return PlacementCursorProperties.ReturnRequiredResources(this);
		}
		return _requiredResources;
	}

	public override bool TryGetEnergyCost(out float energyCost)
	{
		if (_energyCost < 0f)
		{
			_energyCost = (((bool)Prefab && Prefab.TryGetComponent<Producer>(out var component)) ? component.ProductionProperties.EnergyCost : 0f);
		}
		energyCost = _energyCost;
		return 0f < energyCost;
	}

	public override int ReturnBuildableTooltipBeautyScore()
	{
		if (_walkwaySegments.IsNullOrEmpty())
		{
			return base.BeautyScore;
		}
		return _walkwaySegments[0].BeautyScore;
	}

	public override float GetWeightModeWeight()
	{
		if (!_walkwaySegments.IsNullOrEmpty())
		{
			return _walkwaySegments[0].GetWeightModeWeight();
		}
		return base.GetWeightModeWeight();
	}

	public bool ReturnShowElement(IBuildablePanelElement element, bool canShowElements)
	{
		if (element == null)
		{
			return false;
		}
		if ((UIElements & element.Id) != BuildablePanelElementId.None)
		{
			if (element.Id == BuildablePanelElementId.StorageFilter)
			{
				return true;
			}
			return canShowElements;
		}
		return element.Id switch
		{
			BuildablePanelElementId.Activation => ShowActivationElement, 
			BuildablePanelElementId.Durability => ShowDurabilityElements, 
			BuildablePanelElementId.Malfunction => ShowMalfunctionElements, 
			BuildablePanelElementId.MooringPoint => ShowMooringPointElements && canShowElements, 
			BuildablePanelElementId.Boat => ShowBoatElements && canShowElements, 
			BuildablePanelElementId.Workshop => ShowWorkshopElements && canShowElements, 
			BuildablePanelElementId.Farm => ShowFarmElements && canShowElements, 
			BuildablePanelElementId.House => ShowHouseElements && canShowElements, 
			BuildablePanelElementId.Research => ShowResearchElements && canShowElements, 
			BuildablePanelElementId.Birdhouse => ShowBirdHouseElements && canShowElements, 
			BuildablePanelElementId.EnergyItemProducer => ShowEnergyItemProducerElements && canShowElements, 
			BuildablePanelElementId.EnergyManualProducer => ShowEnergyManualProducerElements && canShowElements, 
			BuildablePanelElementId.EnergyGridLink => ShowEnergyGridLinkElements && canShowElements, 
			BuildablePanelElementId.EnergyGridInformation => ShowEnergyGridEfficiency && canShowElements, 
			BuildablePanelElementId.EnergyStorage => ShowEnergyStorageElements && canShowElements, 
			BuildablePanelElementId.Fisher => ShowFisherElements && canShowElements, 
			BuildablePanelElementId.School => ShowSchoolElements && canShowElements, 
			BuildablePanelElementId.Radio => ShowRadioElements && canShowElements, 
			_ => false, 
		};
	}

	public override string GetName()
	{
		return base.Name;
	}

	public override Sprite GetIcon()
	{
		return IconSprite;
	}

	public override string GetTooltip(TooltipBuilder tooltipBuilder)
	{
		return string.Empty;
	}

	public override void ShowTooltip(GameObject trigger = null, bool delayed = true)
	{
		GameManager.UIManager.StartBuildableTooltipTimer(this, trigger.transform.position, delayed);
	}

	public override void ShowTooltip(Vector3 position, bool delayed = true)
	{
		GameManager.UIManager.StartBuildableTooltipTimer(this, position, delayed);
	}

	public void ShowUpgradeTooltip(GameObject trigger = null)
	{
		GameManager.UIManager.StartBuildableTooltipTimer(this, trigger.transform.position, delay: false, upgradeResources: true);
	}

	public override void HideTooltip()
	{
		GameManager.UIManager.ResetBuildableTooltipTimer(this);
	}
}
