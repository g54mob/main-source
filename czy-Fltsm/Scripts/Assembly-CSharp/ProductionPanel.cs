using System;
using System.Collections.Generic;
using I2.Loc;
using PajamaLlama.Debugs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProductionPanel : MonoBehaviour, IBuildablePanelElement, ILocalizationParamsManager
{
	[Header("Production")]
	[Tooltip("Slider to display the production progress.")]
	[SerializeField]
	private Slider _productionProgressSlider;

	[Header("Queue")]
	[Tooltip("List of all the displays in the queue.")]
	[SerializeField]
	private List<RecipeItemDisplay> _queueDisplays = new List<RecipeItemDisplay>();

	[Tooltip("Continuous production toggle")]
	[SerializeField]
	private Toggle _continuousToggle;

	[Header("Recipes")]
	[Tooltip("Toggle group of all the recipes.")]
	[SerializeField]
	private ToggleGroup _recipeToggleGroup;

	[Tooltip("Prefab for the recipe display. Ensure this has a toggle on it as well.")]
	[SerializeField]
	private ChildBehaviourCache<ProductionPanelRecipeToggle> _recipeToggleCache;

	[Tooltip("The selectable group that manages the recipes")]
	[SerializeField]
	private SelectableGroup _recipeSelectableGroup;

	[Header("Priority")]
	[SerializeField]
	private TextMeshProUGUI _priorityDividerLabel;

	[SerializeField]
	private LocalizedString _priorityDividerLabelPostfix;

	[SerializeField]
	private TextMeshProUGUI _priorityText;

	[Header("Inventory")]
	[Tooltip("The import inventory view.")]
	[SerializeField]
	private InventoryView _importView;

	[Tooltip("The export inventory view.")]
	[SerializeField]
	private InventoryView _exportView;

	private RecipeDisplay _recipeDisplay;

	private Producer _producer;

	private int _maximumQueuedRecipes;

	private AssignmentType _assignmentType;

	public BuildablePanelElementId Id => BuildablePanelElementId.Workshop;

	private void Awake()
	{
		_maximumQueuedRecipes = GameManager.Settings.BuildableSettings.MaximumQueuedRecipes;
		if (_maximumQueuedRecipes != _queueDisplays.Count)
		{
			Debugger.Error($"The production panel has {_queueDisplays.Count} slots, but the maximum amount of queued recipes is {_maximumQueuedRecipes}. Please make sure these sizes match.");
		}
	}

	private void OnEnable()
	{
		UpdateToggles();
	}

	private void Update()
	{
		_productionProgressSlider.value = _producer.ReturnProgressNormalized();
	}

	private void OnDestroy()
	{
		RemoveListeners();
	}

	public bool Activate(Buildable buildable, bool finished)
	{
		Deactivate();
		if (finished && buildable.TryReturnBuildableExtendable<Producer>(out _producer) && _producer.ProductionProperties.Type == Producer.Type.Workshop)
		{
			ProductionPanelRecipeToggle productionPanelRecipeToggle = null;
			base.gameObject.SetActive(value: true);
			if (_recipeDisplay == null)
			{
				_recipeDisplay = GetComponentInChildren<RecipeDisplay>(includeInactive: true);
			}
			_recipeDisplay.Initialize(_producer.SelectedRecipe, _producer.HasEnergyCost);
			_producer.MalfunctionsUpdated += UpdateToggles;
			_producer.QueueUpdatedEvent += UpdateQueue;
			LocalizationManager.ParamManagers.AddUnique(this);
			UpdatePanel();
			_recipeToggleGroup.allowSwitchOff = true;
			_recipeToggleCache.Reset();
			for (int i = 0; i < _producer.Recipes.Count; i++)
			{
				Producer.Recipe recipe = _producer.Recipes[i];
				ProductionPanelRecipeToggle productionPanelRecipeToggle2 = _recipeToggleCache.Get(active: true);
				productionPanelRecipeToggle2.Initialize(_producer, recipe);
				productionPanelRecipeToggle2.group = _recipeToggleGroup;
				if (_producer.SelectedRecipeIndex == i)
				{
					productionPanelRecipeToggle = productionPanelRecipeToggle2;
				}
				productionPanelRecipeToggle2.onValueChanged.AddListener(OnToggleValueChanged);
			}
			_recipeToggleCache.Trim();
			_recipeToggleGroup.allowSwitchOff = false;
			_recipeSelectableGroup.Initialize(clearSelected: true);
			if (!_recipeSelectableGroup.TrySelect(productionPanelRecipeToggle))
			{
				productionPanelRecipeToggle.isOn = true;
			}
			_importView.Initialize(_producer.Buildable.Inventory, SubInventoryType.Import);
			_exportView.Initialize(_producer.Buildable.Inventory, SubInventoryType.Export);
			return true;
		}
		return false;
	}

	public void Deactivate()
	{
		LocalizationManager.ParamManagers.Remove(this);
		RemoveListeners();
		base.gameObject.SetActive(value: false);
	}

	private void RemoveListeners()
	{
		if (_producer != null)
		{
			_producer.MalfunctionsUpdated -= UpdateToggles;
			_producer.QueueUpdatedEvent -= UpdateQueue;
		}
		for (int i = 0; i < _recipeToggleCache.Count; i++)
		{
			_recipeToggleCache[i].onValueChanged.RemoveListener(OnToggleValueChanged);
		}
	}

	private void SelectRecipe(int recipeIndex)
	{
		_producer.SetSelectedRecipe(recipeIndex);
		UpdatePanel();
	}

	private void UpdatePanel()
	{
		_recipeDisplay.SetRecipe(_producer.SelectedRecipe);
		_priorityText.text = _producer.Priority.Label;
		UpdateToggles();
		UpdateQueue();
		UpdateAssignmentType();
	}

	private void UpdateQueue()
	{
		for (int i = 0; i < _queueDisplays.Count; i++)
		{
			RecipeItemDisplay recipeItemDisplay = _queueDisplays[i];
			if (_producer.QueuedRecipes.Count <= i)
			{
				recipeItemDisplay.Initialize();
				continue;
			}
			QueuedRecipe queuedRecipe = _producer.QueuedRecipes[i];
			bool flag = queuedRecipe.RecipeStage == QueuedRecipe.Stage.WaitingToReserveItems;
			if (recipeItemDisplay.Recipe != queuedRecipe.Recipe || recipeItemDisplay.ItemDisabled != flag)
			{
				recipeItemDisplay.Initialize(queuedRecipe.Recipe, queuedRecipe.ReturnFirstProducedItemProperties(), flag);
			}
		}
		_continuousToggle.SetIsOnWithoutNotify(_producer.SelectedRecipe.IsContinuous);
	}

	private void UpdateToggles()
	{
		_recipeDisplay.UpdateAmountToProduce();
		_recipeToggleGroup.allowSwitchOff = true;
		for (int i = 0; i < _recipeToggleCache.Count; i++)
		{
			_recipeToggleCache[i].UpdateState();
		}
		_recipeToggleGroup.allowSwitchOff = false;
	}

	private void UpdateAssignmentType()
	{
		if ((bool)_producer && _assignmentType != _producer.ProductionProperties.ProductionProject.AssignmentType)
		{
			_assignmentType = _producer.ProductionProperties.ProductionProject.AssignmentType;
			_priorityDividerLabel.text = _priorityDividerLabelPostfix;
		}
	}

	private void OnToggleValueChanged(bool isOn)
	{
		if (!isOn)
		{
			return;
		}
		for (int i = 0; i < _recipeToggleCache.Count; i++)
		{
			if (_recipeToggleCache[i].isOn)
			{
				SelectRecipe(i);
			}
		}
	}

	public string GetParameterValue(string Param)
	{
		if (Param == "ASSIGNMENT_TYPE" && ProjectSettings.TryGetAssignmentSettings(out var settings, _assignmentType))
		{
			return settings.Name;
		}
		return null;
	}

	public void IncreaseAmountToProduce()
	{
		_producer.IncreaseSelectedRecipeAmountToProduce();
		UpdateToggles();
	}

	public void DecreaseAmountToProduce()
	{
		_producer.SelectedRecipe.DecreaseAmountToProduce();
		UpdateToggles();
	}

	public void ToggleContinuous(bool continuous)
	{
		_producer.SelectedRecipe.ToggleContinuous();
		UpdateToggles();
	}

	public void CancelQueueItem(int index)
	{
		_producer.CancelRecipe(index);
		UpdateQueue();
	}

	public void DecreasePriority()
	{
		_producer.DecreasePriority();
		_priorityText.text = _producer.Priority.Label;
	}

	public void IncreasePriority()
	{
		_producer.IncreasePriority();
		_priorityText.text = _producer.Priority.Label;
	}

	public void SelectQueuedRecipe(int index)
	{
		throw new NotImplementedException();
	}

	public void SelectContinuousRecipe()
	{
		throw new NotImplementedException();
	}

	public void CancelSelectedRecipe()
	{
		throw new NotImplementedException();
	}

	public void CancelContinuousRecipe()
	{
		throw new NotImplementedException();
	}
}
