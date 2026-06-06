using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildableOverview : MonoBehaviour, IBuildablePanelElement, ISelectableGroupFirstSelectedProvider
{
	[SerializeField]
	[Tooltip("Category icons should be uneven.")]
	private BuildableOverviewCategory[] _categoryIcons;

	[SerializeField]
	private TextMeshProUGUI _categoryLabel;

	[SerializeField]
	private ChildBehaviourCache<BuildableOverviewListItem> _buildableListItemCache;

	[SerializeField]
	private SelectableGroup _buildableListSelectableGroup;

	[SerializeField]
	private float _selectBuildableZoomLevel;

	[SerializeField]
	private BuildableCategory[] _categoriesToExclude;

	[Header("Prefab References")]
	[SerializeField]
	public PanelTabContainer _panelTabContainer;

	private Buildable _buildable;

	private List<BuildableCategory> _categories = new List<BuildableCategory>();

	private BuildableCategory _selectedCategory;

	private int _selectedCategoyIndex;

	private bool _unselectTab;

	private bool _clearSelected;

	public BuildablePanelElementId Id => BuildablePanelElementId.Activation;

	private void OnEnable()
	{
		UpdateState();
		GameEventDispatcher.AddListener(GameEventType.BuildablePlaced, UpdateState);
		GameEventDispatcher.AddListener(GameEventType.BuildableSalvaged, UpdateState);
	}

	private void LateUpdate()
	{
		if (_unselectTab)
		{
			_panelTabContainer.ToggleFirstTab();
			_unselectTab = false;
		}
	}

	private void OnDisable()
	{
		GameEventDispatcher.RemoveListener(GameEventType.BuildablePlaced, UpdateState);
		GameEventDispatcher.RemoveListener(GameEventType.BuildableSalvaged, UpdateState);
	}

	public bool Activate(Buildable buildable, bool finished)
	{
		_buildable = buildable;
		UpdateCategories();
		if (_categories.Count > 0 && TryGetBuildableCategoryIndex(out var index, buildable))
		{
			SelectCategory(index);
			base.gameObject.SetActive(value: true);
			return true;
		}
		return false;
	}

	public void Deactivate()
	{
		base.gameObject.SetActive(value: false);
	}

	private void SelectCategory(int index)
	{
		_selectedCategory = _categories.GetValueWrapped(index);
		_selectedCategoyIndex = _categories.IndexOf(_selectedCategory);
		_clearSelected = true;
		UpdateState();
	}

	private void UpdateCategories()
	{
		_categories.Clear();
		if (_buildable == null || _buildable.Community == null)
		{
			return;
		}
		BuildableCategory[] categories = GameSettings.Instance.BuildableSettings.Categories;
		foreach (BuildableCategory buildableCategory in categories)
		{
			if (_buildable.Community.CategorizedBuildables.ContainsKey(buildableCategory) && !_categoriesToExclude.Contains(buildableCategory))
			{
				_categories.Add(buildableCategory);
			}
		}
	}

	private void UpdateState(GameEvent gameEvent = null)
	{
		UpdateCategory();
		UpdateBuildableList();
	}

	private void UpdateCategory()
	{
		bool flag = _categoryIcons.Length <= _categories.Count || _selectedCategoyIndex % 2 == 0;
		int num = _selectedCategoyIndex;
		int num2 = _categoryIcons.Length / 2;
		_categoryIcons[num2].Initialize(_selectedCategory, SelectCategory);
		for (int i = 1; i < _categoryIcons.Length; i++)
		{
			if (flag)
			{
				num2 += i;
				num += i;
			}
			else
			{
				num2 -= i;
				num -= i;
			}
			BuildableOverviewCategory buildableOverviewCategory = _categoryIcons[num2];
			if (i < _categories.Count)
			{
				buildableOverviewCategory.Initialize(_categories.GetValueWrapped(num), SelectCategory);
			}
			else
			{
				buildableOverviewCategory.gameObject.SetActive(value: false);
			}
			flag = !flag;
		}
		_categoryLabel.text = _selectedCategory.Name;
	}

	private void UpdateBuildableList()
	{
		_buildableListItemCache.Reset();
		if (_buildable.Community.CategorizedBuildables.TryGetValue(_selectedCategory, out var value))
		{
			GameSettings.Instance.BuildableSettings.SortBuildableList(value);
			foreach (Buildable item in value)
			{
				_buildableListItemCache.Get(active: true).Initialize(item, item == _buildable, SelectBuildable);
			}
		}
		_buildableListItemCache.Trim();
		_buildableListSelectableGroup.Initialize(_clearSelected);
		_clearSelected = false;
	}

	private void SelectCategory(BuildableOverviewCategory category)
	{
		int num = _categories.IndexOf(category.Category);
		if (num != _selectedCategoyIndex)
		{
			SelectCategory(num);
		}
	}

	private void SelectBuildable(BuildableOverviewListItem listItem)
	{
		if (!(_buildable == listItem.Buildable))
		{
			_unselectTab = _panelTabContainer;
			CameraController.Instance.Lock(listItem.Buildable.gameObject, _selectBuildableZoomLevel);
			listItem.Buildable.OnSelected(playSelectionSound: true);
		}
	}

	public void PreviousCategory()
	{
		SelectCategory(_selectedCategoyIndex - 1);
	}

	public void NextCategory()
	{
		SelectCategory(_selectedCategoyIndex + 1);
	}

	private bool TryGetBuildableCategoryIndex(out int index, Buildable buildable)
	{
		index = _categories.Count;
		while (0 < index--)
		{
			if (_categories[index] == buildable.Properties.Category)
			{
				return true;
			}
		}
		return false;
	}

	public bool TryGetFirstSelected(out Selectable selectable)
	{
		BuildableOverviewListItem buildableOverviewListItem = null;
		for (int i = 0; i < _buildableListItemCache.Count; i++)
		{
			buildableOverviewListItem = _buildableListItemCache[i];
			if (buildableOverviewListItem.Buildable == _buildable)
			{
				selectable = buildableOverviewListItem.Selectable;
				return selectable != null;
			}
		}
		selectable = null;
		return false;
	}
}
