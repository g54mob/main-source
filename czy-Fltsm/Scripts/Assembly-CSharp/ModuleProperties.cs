using I2.Loc;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Buildable/Upgrade Properties")]
public class ModuleProperties : ResearchUnlockable, ILocalizationParamsManager
{
	private enum CostMode
	{
		Items = 0,
		ItemsPerWeight = 1
	}

	private enum ModifierString
	{
		Percentage = 0,
		Integer = 1
	}

	[SerializeField]
	private LocalizedString _name;

	[SerializeField]
	private LocalizedString _description;

	[SerializeField]
	private Sprite _icon;

	[SerializeField]
	private Sprite _iconDisabled;

	[SerializeField]
	[Tooltip("The weight this module adds to the Buildable it is attached to.")]
	private float _weight;

	[Header("Cost")]
	[SerializeField]
	private CostMode _costMode;

	[SerializeField]
	private CountedItemProperty[] _cost;

	[SerializeField]
	[ConditionalEnumHide("_costMode", 1, true)]
	private float _costWeight;

	[Header("Modifiers")]
	[SerializeField]
	private ModifierType _modifier;

	[SerializeField]
	[Tooltip("The value of the modifier, this value is added to the modifier. E.g. the standard modifier for weight is 1. If the module modifier is -.1 the resulting weight modifier will be 1.0 + -0.1 = 0.9")]
	private float _modifierValue;

	[SerializeField]
	private ModifierString _modifierToString;

	private CountedItemProperty[] _computedCost;

	public override Types Type => Types.Upgrade;

	public LocalizedString Name => _name;

	public LocalizedString Description => _description;

	public Sprite Icon => _icon;

	public Sprite IconDisabled => _iconDisabled;

	public float Weight => _weight;

	public float ModifierValue => _modifierValue;

	public bool TryGetModifier(ModifierType modifier, out float value)
	{
		if (modifier == _modifier)
		{
			value = _modifierValue;
			return true;
		}
		value = 0f;
		return false;
	}

	public CountedItemProperty[] GetCost(Buildable buildable, bool excludeItemsinInventory)
	{
		if (_computedCost == null || _computedCost.Length != _cost.Length)
		{
			_computedCost = new CountedItemProperty[_cost.Length];
			for (int i = 0; i < _cost.Length; i++)
			{
				_computedCost[i] = new CountedItemProperty(_cost[i]);
			}
		}
		if (_costMode == CostMode.ItemsPerWeight)
		{
			int num = Mathf.Max(1, Mathf.FloorToInt(buildable.Properties.Weight / _costWeight));
			for (int j = 0; j < _computedCost.Length; j++)
			{
				_computedCost[j].Amount = _cost[j].Amount * num - (excludeItemsinInventory ? buildable.Inventory.ReturnCount(_cost[j].ItemProperties, SubInventoryType.Modules) : 0);
			}
		}
		return _computedCost;
	}

	public override string GetName()
	{
		return _name;
	}

	public override string GetDescription()
	{
		try
		{
			LocalizationManager.ParamManagers.Add(this);
			return _description;
		}
		finally
		{
			LocalizationManager.ParamManagers.Remove(this);
		}
	}

	public override Sprite GetIcon()
	{
		return _icon;
	}

	public override string GetTooltip(TooltipBuilder tooltipBuilder)
	{
		Debug.LogWarning("Not implemented warning");
		return string.Empty;
	}

	public bool CanBeDone(Buildable buildable)
	{
		if (IsUnlocked())
		{
			return buildable.Community.Inventory.ReturnContainsItems(GetCost(buildable, excludeItemsinInventory: true));
		}
		return false;
	}

	public string GetParameterValue(string Param)
	{
		if (Param == "AMOUNT")
		{
			return GetModifierString(_modifierToString);
		}
		return null;
	}

	private string GetModifierString(ModifierString modifierString)
	{
		return modifierString switch
		{
			ModifierString.Percentage => $"{Mathf.RoundToInt(Mathf.Clamp(_modifierValue, -1f, 1f) * 100f)}%", 
			ModifierString.Integer => Mathf.RoundToInt(_modifierValue).ToString(), 
			_ => null, 
		};
	}
}
