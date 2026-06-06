using System;
using System.Collections.Generic;
using PajamaLlama.Utilities;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.PajamaLlama;

public class BuildableCreation : Panel, ScrollRectSelectionScroller.IProvider
{
	[Flags]
	public enum PlaceableFlags
	{
		Buildables = 1,
		Decorations = 2,
		Utilities = 4
	}

	[SerializeField]
	private SelectableGroup _categorieToggleSelectableGroup;

	[Tooltip("The parent for the category tabs.")]
	public ToggleGroup CategoriesToggleParent;

	[Tooltip("The parent for the buildable toggle groups")]
	public Transform BuildableToggleGroupParent;

	[Tooltip("The buildable toggle group prefab.")]
	public SelectableGroup BuildableToggleGroupPrefab;

	[Tooltip("The prefab for the category toggle.")]
	public BuildableCreationCategoryToggle CategoryPrefab;

	[Tooltip("Flags that determin which Placeables spawn toggles")]
	[SerializeField]
	private PlaceableFlags _placeableFlags = PlaceableFlags.Buildables | PlaceableFlags.Decorations | PlaceableFlags.Utilities;

	[SerializeField]
	private RewiredActionInfoBarContext _actionInfoBarContext;

	protected List<BuildableCreationCategoryToggle> _categoryToggles;

	private BuildableCreationCategoryToggle _toggledCategory;

	protected bool _updateCategories;

	private bool _initialized;

	private bool _resetScrollRect;

	GameObject ScrollRectSelectionScroller.IProvider.SelectedGameObject
	{
		get
		{
			if (!_toggledCategory)
			{
				return null;
			}
			return _toggledCategory.BuildableToggleGroup.SelectedGameObject;
		}
	}

	bool ScrollRectSelectionScroller.IProvider.Reset
	{
		get
		{
			if (_resetScrollRect)
			{
				_resetScrollRect = false;
				return true;
			}
			return false;
		}
	}

	private void Awake()
	{
		GameEventDispatcher.AddListener(GameEventType.GameStart, Initialize);
	}

	private void OnEnable()
	{
		if (_updateCategories)
		{
			DoCategoriesUpdate();
		}
		_resetScrollRect = true;
		OnCategoryToggleValueChanged(value: true);
	}

	private void LateUpdate()
	{
		if (_updateCategories)
		{
			DoCategoriesUpdate();
		}
	}

	protected virtual void OnDestroy()
	{
		Community.PlayerCommunity.Inventory.InventoryUpdatedEvent.RemoveListener(UpdateCategories);
		Community.PlayerCommunity.BuildablesUpdatedEvent -= UpdateCategories;
		Community.PlayerCommunity.MooringPointsUpdatedEvent -= UpdateCategories;
		Community.PlayerCommunity.BoatsUpdatedEvent -= UpdateCategories;
	}

	public override bool Open(PanelID id, IPanelContext context = null)
	{
		if (base.Open(id, context))
		{
			if (context is BuildableCategory buildableCategory)
			{
				foreach (BuildableCreationCategoryToggle categoryToggle in _categoryToggles)
				{
					if (categoryToggle.Category == buildableCategory)
					{
						categoryToggle.isOn = true;
						break;
					}
				}
			}
			return true;
		}
		return false;
	}

	public virtual void Initialize(GameEvent gameEvent = null)
	{
		GameEventDispatcher.RemoveListener(GameEventType.GameStart, Initialize);
		if (_initialized)
		{
			return;
		}
		MakeCategories();
		MakeCreationToggles();
		UpdateCategories();
		DoCategoriesUpdate();
		_categorieToggleSelectableGroup.Initialize();
		foreach (BuildableCreationCategoryToggle categoryToggle in _categoryToggles)
		{
			categoryToggle.BuildableToggleGroup.Initialize();
			categoryToggle.onValueChanged.AddListener(OnCategoryToggleValueChanged);
		}
		Community.PlayerCommunity.Inventory.InventoryUpdatedEvent.AddListener(UpdateCategories);
		Community.PlayerCommunity.BuildablesUpdatedEvent += UpdateCategories;
		Community.PlayerCommunity.MooringPointsUpdatedEvent += UpdateCategories;
		Community.PlayerCommunity.BoatsUpdatedEvent += UpdateCategories;
		_initialized = true;
		base.gameObject.SetActive(value: false);
	}

	public override void OnContainerStateChanged(PanelContainerState state)
	{
		if (state == PanelContainerState.Closing)
		{
			_actionInfoBarContext.Disable();
		}
	}

	private void MakeCategories()
	{
		BuildableCategory[] categories = GameManager.Settings.BuildableSettings.Categories;
		CategoriesToggleParent.allowSwitchOff = true;
		_categoryToggles = new List<BuildableCreationCategoryToggle>(categories.Length);
		for (int i = 0; i < categories.Length; i++)
		{
			BuildableCreationCategoryToggle buildableCreationCategoryToggle = UnityEngine.Object.Instantiate(CategoryPrefab, CategoriesToggleParent.transform);
			buildableCreationCategoryToggle.Initialize(categories[i], UnityEngine.Object.Instantiate(BuildableToggleGroupPrefab, BuildableToggleGroupParent), i == 0);
			buildableCreationCategoryToggle.group = CategoriesToggleParent;
			buildableCreationCategoryToggle.gameObject.SetActive(value: false);
			_categoryToggles.Add(buildableCreationCategoryToggle);
		}
		CategoriesToggleParent.allowSwitchOff = false;
	}

	protected virtual void MakeCreationToggles()
	{
		if (_placeableFlags.HasFlag(PlaceableFlags.Buildables))
		{
			for (int i = 0; i < GameManager.Settings.BuildableSettings.Buildables.Length; i++)
			{
				MakeBuildableToggle(GameManager.Settings.BuildableSettings.Buildables[i]);
			}
		}
		if (_placeableFlags.HasFlag(PlaceableFlags.Decorations))
		{
			for (int j = 0; j < GameManager.Settings.BuildableSettings.Decorations.Length; j++)
			{
				MakeBuildableToggle(GameManager.Settings.BuildableSettings.Decorations[j]);
			}
		}
		if (_placeableFlags.HasFlag(PlaceableFlags.Utilities))
		{
			for (int k = 0; k < GameManager.Settings.BuildableSettings.Utilties.Length; k++)
			{
				MakeBuildableToggle(GameManager.Settings.BuildableSettings.Utilties[k]);
			}
		}
	}

	protected void UpdateCategories()
	{
		_updateCategories = true;
	}

	private void DoCategoriesUpdate()
	{
		foreach (BuildableCreationCategoryToggle categoryToggle in _categoryToggles)
		{
			categoryToggle.UpdateState();
		}
		_updateCategories = false;
	}

	private void MakeBuildableToggle(IPlaceable placeable)
	{
		if (!placeable.ShowToggle)
		{
			return;
		}
		using List<BuildableCreationCategoryToggle>.Enumerator enumerator = _categoryToggles.GetEnumerator();
		while (enumerator.MoveNext() && !enumerator.Current.TryAddBuildableToggle(placeable))
		{
		}
	}

	private void OnCategoryToggleValueChanged(bool value)
	{
		FinalUpdate.RegisterEndOfFrameOneShot(UpdateToggledCategory);
	}

	private void UpdateToggledCategory()
	{
		if (_categoryToggles.IsNullOrEmpty())
		{
			return;
		}
		foreach (BuildableCreationCategoryToggle categoryToggle in _categoryToggles)
		{
			if (categoryToggle.isOn && _toggledCategory != categoryToggle)
			{
				_toggledCategory = categoryToggle;
				_resetScrollRect = true;
			}
		}
	}

	protected bool TryReturnCategoryToggle(BuildableCategory category, out BuildableCreationCategoryToggle categoryToggle)
	{
		for (int i = 0; i < _categoryToggles.Count; i++)
		{
			categoryToggle = _categoryToggles[i];
			if (categoryToggle.Category == category)
			{
				return true;
			}
		}
		categoryToggle = null;
		return false;
	}
}
