using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FarmPanel : MonoBehaviour, IBuildablePanelElement
{
	[Tooltip("Recipe item display for the input of this farm.")]
	[SerializeField]
	private RecipeItemDisplay _inputDisplay;

	[Tooltip("Recipe item display for the output of this farm.")]
	[SerializeField]
	private RecipeItemDisplay _outputDisplay;

	[Tooltip("Prefab for the item displays.")]
	[SerializeField]
	private ChildBehaviourCache<RecipeItemDisplay> _itemDisplayCache;

	[Header("Recipes")]
	[Tooltip("Toggle group of all the recipes.")]
	[SerializeField]
	private ToggleGroup _recipeToggleGroup;

	[Tooltip("Prefab for the recipe display. Ensure this has a toggle on it as well.")]
	[SerializeField]
	private ChildBehaviourCache<RecipeItemDisplay> _recipeToggleCache;

	[Tooltip("The selectable group that manages the recipes")]
	[SerializeField]
	private SelectableGroup _recipeSelectableGroup;

	[Tooltip("The parent which holds the producing display section.")]
	[SerializeField]
	private RectTransform _productionDisplayParent;

	[Tooltip("Reference to the recipe title text.")]
	[SerializeField]
	private TextMeshProUGUI _recipeTitle;

	[Tooltip("Reference to the recipe description text.")]
	[SerializeField]
	private TextMeshProUGUI _recipeDescription;

	[Tooltip("Reference to the recipe desxription text.")]
	[SerializeField]
	private LocalizedString _noRecipeTitle = "";

	[Tooltip("Reference to the recipe desxription text.")]
	[SerializeField]
	private LocalizedString _noRecipeDescription = "";

	[Space]
	[SerializeField]
	private GameObject _pollutionIcon;

	[SerializeField]
	private TextMeshProUGUI _pollutionText;

	private Producer _producer;

	private bool _initialized;

	public BuildablePanelElementId Id => BuildablePanelElementId.Farm;

	public bool HasValidRecipe
	{
		get
		{
			if (!_producer)
			{
				return false;
			}
			if (-1 < _producer.SelectedRecipeIndex)
			{
				return _producer.SelectedRecipeIndex < _producer.Recipes.Count;
			}
			return false;
		}
	}

	public bool Activate(Buildable buildable, bool finished)
	{
		Deactivate();
		if (finished && buildable.TryReturnBuildableExtendable<Producer>(out _producer) && _producer.ProductionProperties.Type == Producer.Type.Farm)
		{
			base.gameObject.SetActive(value: true);
			bool hasValidRecipe = HasValidRecipe;
			_recipeToggleGroup.allowSwitchOff = !hasValidRecipe;
			_productionDisplayParent.gameObject.SetActive(hasValidRecipe);
			InitializeRecipesToggles();
			GenerateRecipeItemDisplays();
			_producer.QueueUpdatedEvent += UpdateRecipeDisplays;
			_initialized = true;
			if (hasValidRecipe)
			{
				Toggle toggle = _recipeToggleCache[_producer.SelectedRecipeIndex].Toggle;
				SelectRecipe(_producer.SelectedRecipeIndex);
				if (!_recipeSelectableGroup.TrySelect(_recipeToggleCache[_producer.SelectedRecipeIndex].Toggle))
				{
					toggle.isOn = true;
				}
			}
			return true;
		}
		return false;
	}

	private void InitializeRecipesToggles()
	{
		_recipeToggleCache.Reset();
		for (int i = 0; i < _producer.Recipes.Count; i++)
		{
			Producer.Recipe recipe = _producer.Recipes[i];
			RecipeItemDisplay recipeItemDisplay = _recipeToggleCache.Get(active: true);
			recipeItemDisplay.Initialize(recipe, recipe.GetFirstProducedItemProperties());
			recipeItemDisplay.Toggle.group = _recipeToggleGroup;
			recipeItemDisplay.Toggle.onValueChanged.AddListener(OnToggleValueChanged);
		}
		_recipeToggleCache.Trim();
		_recipeSelectableGroup.Initialize(clearSelected: true);
	}

	private void OnToggleValueChanged(bool isOn)
	{
		if (!isOn)
		{
			return;
		}
		for (int i = 0; i < _recipeToggleCache.Count; i++)
		{
			if (_recipeToggleCache[i].Toggle.isOn)
			{
				SelectRecipe(i);
				break;
			}
		}
	}

	private void Update()
	{
		for (int i = 0; i < _producer.QueuedRecipes.Count; i++)
		{
			QueuedRecipe queuedRecipe = _producer.QueuedRecipes[i];
			if (queuedRecipe.Recipe != null)
			{
				float progress = queuedRecipe.Progress / queuedRecipe.ProductionTime;
				if (i < _itemDisplayCache.Count)
				{
					_itemDisplayCache[i].SetProgress(progress);
				}
			}
		}
		UpdateProductionDisplayParent();
	}

	public void Deactivate()
	{
		if (_initialized)
		{
			RemoveListeners();
			_producer.QueueUpdatedEvent -= UpdateRecipeDisplays;
			_initialized = false;
		}
		base.gameObject.SetActive(value: false);
	}

	private void OnDestroy()
	{
		if (_initialized)
		{
			_producer.QueueUpdatedEvent -= UpdateRecipeDisplays;
		}
	}

	private void UpdateRecipeDisplays()
	{
		for (int i = 0; i < _producer.QueuedRecipes.Count && i < _itemDisplayCache.Count; i++)
		{
			QueuedRecipe queuedRecipe = _producer.QueuedRecipes[i];
			RecipeItemDisplay recipeItemDisplay = _itemDisplayCache[i];
			if (queuedRecipe.Recipe != null)
			{
				switch (queuedRecipe.RecipeStage)
				{
				case QueuedRecipe.Stage.WaitingToReserveItems:
				case QueuedRecipe.Stage.WaitingToImport:
					recipeItemDisplay.Initialize(queuedRecipe.ReturnFirstRequiredItemProperties().InventorySprite, GameManager.Settings.ItemSettings.DisabledColor, GameManager.Settings.ItemSettings.WaitingForResourceTooltip);
					break;
				case QueuedRecipe.Stage.WaitingToProduce:
				case QueuedRecipe.Stage.Producing:
					recipeItemDisplay.Initialize(queuedRecipe, queuedRecipe.ReturnFirstRequiredItemProperties());
					break;
				case QueuedRecipe.Stage.WaitingToExportItems:
					recipeItemDisplay.Initialize(queuedRecipe, queuedRecipe.ReturnFirstProducedItemProperties());
					break;
				}
			}
		}
	}

	private void GenerateRecipeItemDisplays()
	{
		_itemDisplayCache.Reset();
		for (int i = 0; i < _producer.MaximumQueuedRecipes; i++)
		{
			_itemDisplayCache.Get(active: true);
		}
		_itemDisplayCache.Trim();
	}

	private void RemoveListeners()
	{
		if (_recipeToggleCache.Count != 0)
		{
			for (int i = 0; i < _recipeToggleCache.Count; i++)
			{
				_recipeToggleCache[i].Toggle.onValueChanged.RemoveAllListeners();
			}
		}
	}

	private void SelectRecipe(int recipeIndex = -1)
	{
		_producer.SetSelectedRecipe(recipeIndex);
		UpdateRecipeDisplay();
		UpdateProductionDisplayParent();
		UpdateRecipeDisplays();
		UpdateRecipeTitleDescription();
	}

	private void UpdateProductionDisplayParent()
	{
		if (ReturnRecipeInProgress() || (_producer.SelectedRecipeIndex >= 0 && _producer.SelectedRecipeIndex < _producer.ProductionProperties.Recipes.Count))
		{
			_productionDisplayParent.gameObject.SetActive(value: true);
		}
		else
		{
			_productionDisplayParent.gameObject.SetActive(value: false);
		}
	}

	private bool ReturnRecipeInProgress()
	{
		for (int i = 0; i < _producer.QueuedRecipes.Count; i++)
		{
			QueuedRecipe queuedRecipe = _producer.QueuedRecipes[i];
			if (queuedRecipe.Recipe != null)
			{
				float normalizedProgress = queuedRecipe.NormalizedProgress;
				if (!Mathf.Approximately(normalizedProgress, 0f) && !Mathf.Approximately(normalizedProgress, 1f))
				{
					return true;
				}
			}
		}
		return false;
	}

	private void UpdateRecipeTitleDescription()
	{
		if (HasValidRecipe)
		{
			ItemProperties firstProducedItemProperties = _producer.SelectedRecipe.GetFirstProducedItemProperties();
			firstProducedItemProperties.ReturnNameAndNutritionalValue(out var text, out var _);
			_recipeTitle.text = text;
			_recipeDescription.text = firstProducedItemProperties.LocalizedDescription;
		}
		else
		{
			_recipeTitle.text = _noRecipeTitle;
			_recipeDescription.text = _noRecipeDescription;
		}
	}

	public void UpdateRecipeDisplay()
	{
		if (HasValidRecipe)
		{
			Producer.Recipe selectedRecipe = _producer.SelectedRecipe;
			_inputDisplay.Initialize(selectedRecipe, selectedRecipe.GetFirstIngredientItemProperties(), itemDisabled: false, selectedRecipe.Ingredients[0].Amount.ToString());
			_outputDisplay.Initialize(selectedRecipe, selectedRecipe.GetFirstProducedItemProperties(), itemDisabled: false, selectedRecipe.ProducedItems[0].Amount.ToString());
			if (selectedRecipe.ProducedItems.Count > 0)
			{
				ItemProperties itemProperties = selectedRecipe.ProducedItems[0].ItemProperties;
				_pollutionIcon.gameObject.SetActive(itemProperties.ConsumptionPollution > 0);
				_pollutionText.text = itemProperties.ConsumptionPollution.ToString();
			}
			else
			{
				_pollutionIcon.gameObject.SetActive(value: false);
			}
		}
	}
}
