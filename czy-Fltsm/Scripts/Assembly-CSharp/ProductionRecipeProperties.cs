using System.Collections.Generic;
using I2.Loc;
using PajamaLlama.Flotsam.Narrative;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Buildable/Production Recipe Properties")]
public class ProductionRecipeProperties : Unlockable, ILocalizationParamsManager
{
	[Header("Description")]
	[SerializeField]
	private LocalizedString _localizedName = "";

	[SerializeField]
	private LocalizedString _localizedDescription = "";

	[SerializeField]
	private Sprite _producedItemIconOverride;

	[Header("Input")]
	[SerializeField]
	private List<CountedItemProperty> _requiredItems = new List<CountedItemProperty>();

	[Header("Production Process")]
	[SerializeField]
	private DrifterAttributes.AttributeType _attribute = DrifterAttributes.AttributeType.Recycling;

	[SerializeField]
	private float _productionTime = 10f;

	[SerializeField]
	private float _pollution;

	[SerializeField]
	private bool _requiresPerson = true;

	[Header("Output")]
	[SerializeField]
	private List<CountedItemProperty> _producedItems = new List<CountedItemProperty>();

	[SerializeField]
	private float _productionExperience;

	[SerializeField]
	private QueuedRecipe.Stage _resetToStage;

	[Header("Animation")]
	[SerializeField]
	private Activity _activity = Activity.Working;

	[SerializeField]
	private List<RecipeVisual> _recipeVisualPrefabs;

	[Header("Scenario")]
	[SerializeField]
	private bool _requiresUnlock;

	[SerializeReference]
	[InstantiateSerializeReference]
	[Tooltip("If the recipe has unlock conditions it will not be unlocked in the Unlockable Manaer")]
	private IScenarioTriggerableCondition[] _unlockConditions;

	public LocalizedString LocalizedName => _localizedName;

	public LocalizedString LocalizedDescription => _localizedDescription;

	public IReadOnlyList<CountedItemProperty> RequiredItems => _requiredItems;

	public DrifterAttributes.AttributeType Attribute => _attribute;

	public float ProductionTime => _productionTime;

	public float Pollution => _pollution;

	public bool RequiresPerson => _requiresPerson;

	public IReadOnlyList<CountedItemProperty> ProducedItems => _producedItems;

	public float ProductionExperience => _productionExperience;

	public QueuedRecipe.Stage ResetToStage => _resetToStage;

	public Activity Activity => _activity;

	public IReadOnlyList<RecipeVisual> RecipeVisualPrefabs => _recipeVisualPrefabs;

	public override Types Type => Types.ProductionRecipe;

	public override bool IsUnlocked()
	{
		if (_requiresUnlock)
		{
			if (base.IsUnlocked())
			{
				return true;
			}
			if (_unlockConditions.IsNullOrEmpty())
			{
				return false;
			}
			IScenarioTriggerableCondition[] unlockConditions = _unlockConditions;
			for (int i = 0; i < unlockConditions.Length; i++)
			{
				if (!unlockConditions[i].IsMet())
				{
					return false;
				}
			}
			Unlock();
		}
		return true;
	}

	public override void Unlock()
	{
		base.Unlock();
		List<Buildable> buildables = Community.PlayerCommunity.Buildables;
		GameObject objectOfInterest = null;
		foreach (Buildable item in (IEnumerable<Buildable>)buildables)
		{
			if (item.TryReturnBuildableExtendable<Producer>(out var buildableExtendable) && buildableExtendable.IsProducerOf(this))
			{
				objectOfInterest = item.gameObject;
				break;
			}
		}
		GameManager.UIManager.NotificationHandler.AddNotification(GameSettings.Instance.UISettings.UnlockableRecipeNotification, new UnlockableRecipeNotification(objectOfInterest, this));
	}

	public Sprite ReturnIcon(ItemProperties itemProperties)
	{
		if ((bool)_producedItemIconOverride && itemProperties == ReturnFirstProducedItemProperties())
		{
			return _producedItemIconOverride;
		}
		return itemProperties.InventorySprite;
	}

	public List<Item> ReturnProducedItems()
	{
		List<Item> list = new List<Item>();
		for (int i = 0; i < ProducedItems.Count; i++)
		{
			for (int j = 0; j < ProducedItems[i].Amount; j++)
			{
				list.Add(new Item(ProducedItems[i].ItemProperties));
			}
		}
		return list;
	}

	public ItemProperties ReturnFirstProducedItemProperties()
	{
		if (ProducedItems.Count == 0)
		{
			return null;
		}
		return ProducedItems[0].ItemProperties;
	}

	public ItemProperties ReturnFirstRequiredItemProperties()
	{
		return RequiredItems[0].ItemProperties;
	}

	public bool ReturnProducesItem(ItemProperties itemProperties)
	{
		if (ProducedItems.IsNullOrEmpty())
		{
			return false;
		}
		foreach (CountedItemProperty producedItem in ProducedItems)
		{
			if (producedItem.ItemProperties == itemProperties && 0 < producedItem.Amount)
			{
				return true;
			}
		}
		return false;
	}

	public bool ReturnUsesItem(ItemProperties itemProperties)
	{
		if (RequiredItems.IsNullOrEmpty())
		{
			return false;
		}
		foreach (CountedItemProperty requiredItem in RequiredItems)
		{
			if (requiredItem.ItemProperties == itemProperties && 0 < requiredItem.Amount)
			{
				return true;
			}
		}
		return false;
	}

	public int ReturnProducedItemCount()
	{
		int num = 0;
		if (ProducedItems.IsNullOrEmpty())
		{
			return num;
		}
		foreach (CountedItemProperty producedItem in ProducedItems)
		{
			num += producedItem.Amount;
		}
		return num;
	}

	public GameEventType ReturnFinishedGameEventType()
	{
		if (Attribute == DrifterAttributes.AttributeType.Farming)
		{
			return GameEventType.ItemFarmed;
		}
		return GameEventType.ProducerItemProduced;
	}

	string ILocalizationParamsManager.GetParameterValue(string param)
	{
		if (!(param == "DURATIONMINUTES"))
		{
			if (param == "DURATIONSECONDS")
			{
				return (Mathf.FloorToInt(_productionTime) % 60).ToString();
			}
			return null;
		}
		return (Mathf.FloorToInt(_productionTime) / 60).ToString();
	}
}
