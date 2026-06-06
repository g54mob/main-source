using System;
using I2.Loc;
using PajamaLlama.SurvivalGuide;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public abstract class PlaceableProperties : ResearchUnlockable, IPlaceable, IIconProvider, ITooltipProvider, ISurvivalGuideIdentifiable
{
	public class Event : UnityEvent<IPlaceable>
	{
	}

	[Header("Placeable Properties")]
	[SerializeField]
	[FormerlySerializedAs("Name")]
	private LocalizedString _name = null;

	[SerializeField]
	[Tooltip("This should be used for development only! If no localization key is provided, this will be used instead.")]
	private string _fallbackName;

	[SerializeField]
	private LocalizedString _description;

	[SerializeField]
	[Tooltip("This should be used for development only! If no localization key is provided, this will be used instead.")]
	private string _fallbackDescription;

	[SerializeField]
	private Sprite _icon;

	[SerializeField]
	private int _beautyScore;

	[SerializeField]
	private int _width = 1;

	[SerializeField]
	private int _depth = 1;

	[SerializeField]
	private BuildableCategory _category;

	[SerializeField]
	private bool _showToggle = true;

	[SerializeField]
	private LocalizedString _cantDeconstructTooltip = null;

	[Header("Projects")]
	[SerializeField]
	private ProjectProperties _haulToConstructibleProjectProperties;

	[SerializeField]
	private ProjectProperties _constructionProjectProperties;

	[Header("Requirements")]
	[SerializeField]
	protected CountedItemProperty[] _requiredResources = new CountedItemProperty[0];

	[SerializeField]
	private bool _requiresMooringPoint;

	[SerializeField]
	private float _weight;

	[SerializeField]
	private bool _ignoreWeight;

	[SerializeField]
	private bool _ignoreWeightForPlacement;

	private string _footprintString;

	public string Name => _name.GetOrDefault(_fallbackName);

	public string LocalizedNameTerm => _name.mTerm.GetOrDefault(_fallbackName);

	public LocalizedString NameLocalizedString => _name;

	public string Description => _description.GetOrDefault(_fallbackDescription);

	public Sprite Icon => _icon;

	public int BeautyScore => _beautyScore;

	public int Width => _width;

	public int Depth => _depth;

	public BuildableCategory Category => _category;

	public bool ShowToggle => _showToggle;

	public bool IsToggleEnabled => IsUnlocked();

	public bool IsCategoryEnabled => IsUnlocked();

	public LocalizedString CantDeconstructTooltip => _cantDeconstructTooltip;

	public ProjectProperties HaulToConstructibleProjectProperties => _haulToConstructibleProjectProperties;

	public ProjectProperties ConstructionProjectProperties => _constructionProjectProperties;

	public bool ShouldDeconstructInstantly => _constructionProjectProperties == null;

	public CountedItemProperty[] RequiredResources => _requiredResources;

	public bool RequiresMooringPoint => _requiresMooringPoint;

	public float Weight => _weight;

	public bool IgnoreWeight => _ignoreWeight;

	public bool IgnoreWeightForPlacement => _ignoreWeightForPlacement;

	public abstract string SurvivalGuideIdentifier { get; }

	public int OrderIndex { get; set; }

	public abstract void ActivateCursor(CursorManager.CursorEvent deactivateCallback = null);

	public abstract bool ReturnCanBePlaced(Community community, bool checkResources = true);

	public override void ShowTooltip(GameObject trigger = null, bool delayed = true)
	{
		GameManager.UIManager.StartBuildableTooltipTimer(this, trigger.transform.position, delayed);
	}

	public override void ShowTooltip(Vector3 position, bool delayed = true)
	{
		GameManager.UIManager.StartBuildableTooltipTimer(this, position, delayed);
	}

	public override void HideTooltip()
	{
		GameManager.UIManager.ResetBuildableTooltipTimer(this);
	}

	public override string GetName()
	{
		return Name;
	}

	public string GetDefaultEnglishName()
	{
		return LocalizationManager.GetTranslation(_name.mTerm, !_name.mRTL_IgnoreArabicFix, _name.mRTL_MaxLineLength, !_name.mRTL_ConvertNumbers, applyParameters: true, null, "English");
	}

	public override string GetDescription()
	{
		return Description;
	}

	public override Sprite GetIcon()
	{
		return _icon;
	}

	public override string GetTooltip(TooltipBuilder tooltipBuilder)
	{
		return string.Empty;
	}

	public virtual float GetWeightModeWeight()
	{
		if (_ignoreWeight)
		{
			return 0f;
		}
		switch (GameManager.Settings.BuildableSettings.WeightMode)
		{
		case BuildableSettings.WeightModes.Properties:
			return _weight;
		case BuildableSettings.WeightModes.Items:
		{
			float num = 0f;
			CountedItemProperty[] requiredResources = _requiredResources;
			foreach (CountedItemProperty countedItemProperty in requiredResources)
			{
				num += countedItemProperty.ItemProperties.Weight * (float)countedItemProperty.Amount;
			}
			return num;
		}
		default:
			throw new NotImplementedException();
		}
	}

	public virtual CountedItemProperty[] ReturnTooltipRequiredResources(bool isUpgrade = false)
	{
		return _requiredResources;
	}

	public string GetFootprint()
	{
		if (string.IsNullOrEmpty(_footprintString))
		{
			_footprintString = $"{Width}x{Depth}";
		}
		return _footprintString;
	}

	public virtual bool TryGetEnergyCost(out float energyCost)
	{
		energyCost = 0f;
		return false;
	}

	public virtual int ReturnBuildableTooltipBeautyScore()
	{
		return _beautyScore;
	}

	public float GetConstructionTime()
	{
		int num = 0;
		CountedItemProperty[] requiredResources = _requiredResources;
		foreach (CountedItemProperty countedItemProperty in requiredResources)
		{
			num += countedItemProperty.Amount;
		}
		foreach (TaskBase item in GameSettings.Instance.ProjectSettings.BuildBuildableProperties.TaskQueue.List)
		{
			if (item is MoveConstructionResource moveConstructionResource)
			{
				return moveConstructionResource.Duration * (float)num;
			}
		}
		return (float)num * 10f;
	}
}
