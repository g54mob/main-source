using System;
using System.Collections.Generic;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ComputerRecipeBookUI : MonoBehaviour
{
	[Header("Factory Info")]
	[SerializeField]
	private TextMeshProUGUI moneyText;

	[SerializeField]
	private TextMeshProUGUI levelText;

	[Header("Item List")]
	[SerializeField]
	private GameObject recipeItemPrefab;

	[SerializeField]
	private Transform itemListContent;

	[Header("Filter")]
	[SerializeField]
	private TextMeshProUGUI filterButtonText;

	[Header("Detail Panel")]
	[SerializeField]
	private GameObject detailPanelRoot;

	[SerializeField]
	private GameObject detailContentPanel;

	[SerializeField]
	private Image detailItemIcon;

	[SerializeField]
	private TextMeshProUGUI detailItemNameText;

	[SerializeField]
	private TextMeshProUGUI detailItemDescriptionText;

	[Header("Production Time")]
	[SerializeField]
	private GameObject productionTimeRoot;

	[SerializeField]
	private TextMeshProUGUI detailProductionTimeText;

	[Header("Recipe Section")]
	[SerializeField]
	private GameObject recipeHeaderRoot;

	[SerializeField]
	private Transform ingredientListContent;

	[SerializeField]
	private GameObject ingredientPrefab;

	[Header("Produced By")]
	[SerializeField]
	private GameObject producedByRoot;

	[SerializeField]
	private GameObject producedByObject;

	[SerializeField]
	private Image producedByIcon;

	[SerializeField]
	private TextMeshProUGUI producedByNameText;

	[Header("Hover Panel")]
	[SerializeField]
	private ComputerHoverPanel hoverPanel;

	private List<RecipeBookItemUI> _spawnedItems = new List<RecipeBookItemUI>();

	private List<GameObject> _spawnedIngredients = new List<GameObject>();

	private T_ItemSO _selectedItem;

	private int currentFilterIndex = -1;

	private static readonly int filterTypeCount = Enum.GetValues(typeof(FilterType)).Length;

	private void OnEnable()
	{
		_selectedItem = null;
		SubscribeToEvents();
		UpdateFactoryInfo();
		HideDetailPanel();
		RefreshItemList();
		ResetFilter();
	}

	private void OnDisable()
	{
		UnsubscribeFromEvents();
		HideHoverPanel();
	}

	private void SubscribeToEvents()
	{
		if (FactoryManager.Instance != null)
		{
			FactoryManager.Instance.onMoneyChanged.AddListener(OnMoneyChanged);
			FactoryManager.Instance.onLevelChanged.AddListener(OnLevelChanged);
		}
	}

	private void UnsubscribeFromEvents()
	{
		if (FactoryManager.Instance != null)
		{
			FactoryManager.Instance.onMoneyChanged.RemoveListener(OnMoneyChanged);
			FactoryManager.Instance.onLevelChanged.RemoveListener(OnLevelChanged);
		}
	}

	private void OnMoneyChanged(int oldMoney, int newMoney)
	{
		UpdateMoneyText(newMoney);
	}

	private void OnLevelChanged(int oldLevel, int newLevel)
	{
		UpdateLevelText(newLevel);
	}

	private void UpdateFactoryInfo()
	{
		if (FactoryManager.Instance != null)
		{
			UpdateMoneyText(FactoryManager.Instance.Money);
			UpdateLevelText(FactoryManager.Instance.Level);
		}
	}

	private void UpdateMoneyText(int money)
	{
		if (moneyText != null)
		{
			moneyText.text = $"{money:N0}";
		}
	}

	private void UpdateLevelText(int level)
	{
		if (levelText != null)
		{
			string translation = LocalizationManager.GetTranslation("Level");
			LocalizationManager.ApplyLocalizationParams(ref translation, new Dictionary<string, object> { 
			{
				"Number",
				level.ToString()
			} });
			levelText.text = translation;
		}
	}

	public void RefreshUI()
	{
		RefreshItemList();
	}

	private void RefreshItemList()
	{
		ClearItemList();
		if (ScriptableListManager.Instance == null)
		{
			return;
		}
		IReadOnlyList<T_ItemSO> allItemSOs = ScriptableListManager.Instance.AllItemSOs;
		if (allItemSOs == null || allItemSOs.Count == 0)
		{
			return;
		}
		foreach (T_ItemSO item in allItemSOs)
		{
			if (!(item == null))
			{
				CreateItemUI(item);
			}
		}
		ApplyFilter();
	}

	private void CreateItemUI(T_ItemSO itemSO)
	{
		if (!(recipeItemPrefab == null) && !(itemListContent == null))
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(recipeItemPrefab, itemListContent);
			RecipeBookItemUI component = gameObject.GetComponent<RecipeBookItemUI>();
			if (component != null)
			{
				bool isSelected = _selectedItem != null && _selectedItem.GetItemID() == itemSO.GetItemID();
				component.Initialize(itemSO, isSelected, OnItemClicked, this);
				_spawnedItems.Add(component);
			}
			else
			{
				UnityEngine.Object.Destroy(gameObject);
			}
		}
	}

	private void ClearItemList()
	{
		foreach (RecipeBookItemUI spawnedItem in _spawnedItems)
		{
			if (spawnedItem != null)
			{
				UnityEngine.Object.Destroy(spawnedItem.gameObject);
			}
		}
		_spawnedItems.Clear();
	}

	public void OnFilterButtonClicked()
	{
		currentFilterIndex++;
		if (currentFilterIndex >= filterTypeCount)
		{
			currentFilterIndex = -1;
		}
		UpdateFilterButtonText();
		ApplyFilter();
	}

	private void UpdateFilterButtonText()
	{
		if (!(filterButtonText == null))
		{
			if (currentFilterIndex == -1)
			{
				string translation = LocalizationManager.GetTranslation("FilterType_All");
				filterButtonText.text = ((!string.IsNullOrEmpty(translation)) ? translation : "NL- All");
			}
			else
			{
				FilterType filterType = (FilterType)currentFilterIndex;
				string translation2 = LocalizationManager.GetTranslation("FilterType_" + filterType);
				filterButtonText.text = ((!string.IsNullOrEmpty(translation2)) ? translation2 : ("NL- " + filterType));
			}
		}
	}

	public void ApplyFilter()
	{
		foreach (RecipeBookItemUI spawnedItem in _spawnedItems)
		{
			if (spawnedItem == null)
			{
				continue;
			}
			if (currentFilterIndex == -1)
			{
				spawnedItem.gameObject.SetActive(value: true);
				continue;
			}
			FilterType item = (FilterType)currentFilterIndex;
			T_ItemSO itemSO = spawnedItem.ItemSO;
			if (itemSO != null && itemSO.FilterTypes != null)
			{
				spawnedItem.gameObject.SetActive(itemSO.FilterTypes.Contains(item));
			}
			else
			{
				spawnedItem.gameObject.SetActive(value: false);
			}
		}
	}

	public void ResetFilter()
	{
		currentFilterIndex = -1;
		UpdateFilterButtonText();
		ApplyFilter();
	}

	private void OnItemClicked(T_ItemSO itemSO)
	{
		if (!(itemSO == null))
		{
			_selectedItem = itemSO;
			UpdateSelectionStates();
			ShowDetailPanel(itemSO);
		}
	}

	private void UpdateSelectionStates()
	{
		foreach (RecipeBookItemUI spawnedItem in _spawnedItems)
		{
			if (spawnedItem != null)
			{
				bool selected = _selectedItem != null && spawnedItem.ItemId == _selectedItem.GetItemID();
				spawnedItem.SetSelected(selected);
			}
		}
	}

	private void ShowDetailPanel(T_ItemSO itemSO)
	{
		if (itemSO == null)
		{
			HideDetailPanel();
			return;
		}
		if (detailContentPanel != null)
		{
			detailContentPanel.SetActive(value: true);
		}
		if (detailItemIcon != null)
		{
			detailItemIcon.sprite = itemSO.Icon;
			detailItemIcon.gameObject.SetActive(itemSO.Icon != null);
		}
		if (detailItemNameText != null)
		{
			string translation = LocalizationManager.GetTranslation(itemSO.Name);
			detailItemNameText.text = ((!string.IsNullOrEmpty(translation)) ? translation : itemSO.Name);
		}
		if (detailItemDescriptionText != null)
		{
			string translation2 = LocalizationManager.GetTranslation(itemSO.Description);
			detailItemDescriptionText.text = ((!string.IsNullOrEmpty(translation2)) ? translation2 : itemSO.Description);
		}
		bool flag = itemSO.productionTime > 0f;
		if (productionTimeRoot != null)
		{
			productionTimeRoot.SetActive(flag);
		}
		if (flag && detailProductionTimeText != null)
		{
			detailProductionTimeText.text = $"{itemSO.productionTime:F1}s";
		}
		ShowIngredients(itemSO);
		ShowProducedBy(itemSO);
	}

	private void ShowIngredients(T_ItemSO itemSO)
	{
		ClearIngredientList();
		bool active = false;
		if (itemSO.ore != null)
		{
			CreateIngredientUI(itemSO.ore, itemSO.oreCount);
			active = true;
		}
		if (itemSO.RecipeList != null)
		{
			foreach (T_ItemSO.RecipeIngredient recipe in itemSO.RecipeList)
			{
				if (recipe != null && !(recipe.Item == null))
				{
					CreateIngredientUI(recipe.Item, recipe.Count);
					active = true;
				}
			}
		}
		if (recipeHeaderRoot != null)
		{
			recipeHeaderRoot.SetActive(active);
		}
	}

	private void ShowProducedBy(T_ItemSO itemSO)
	{
		bool flag = itemSO.producedBy != null;
		if (producedByRoot != null)
		{
			producedByRoot.SetActive(flag);
		}
		if (producedByObject != null)
		{
			producedByObject.SetActive(flag);
		}
		if (flag)
		{
			T_BuildingItemSO producedBy = itemSO.producedBy;
			if (producedByIcon != null)
			{
				producedByIcon.sprite = producedBy.Icon;
				producedByIcon.gameObject.SetActive(producedBy.Icon != null);
			}
			if (producedByNameText != null)
			{
				string translation = LocalizationManager.GetTranslation(producedBy.Name);
				producedByNameText.text = ((!string.IsNullOrEmpty(translation)) ? translation : producedBy.Name);
			}
		}
	}

	private void CreateIngredientUI(T_ItemSO item, int count)
	{
		if (!(ingredientPrefab == null) && !(ingredientListContent == null))
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(ingredientPrefab, ingredientListContent);
			RecipeBookIngredientUI component = gameObject.GetComponent<RecipeBookIngredientUI>();
			if (component != null)
			{
				component.Initialize(item, count);
				_spawnedIngredients.Add(gameObject);
			}
			else
			{
				UnityEngine.Object.Destroy(gameObject);
			}
		}
	}

	private void ClearIngredientList()
	{
		foreach (GameObject spawnedIngredient in _spawnedIngredients)
		{
			if (spawnedIngredient != null)
			{
				UnityEngine.Object.Destroy(spawnedIngredient);
			}
		}
		_spawnedIngredients.Clear();
	}

	private void HideDetailPanel()
	{
		if (detailContentPanel != null)
		{
			detailContentPanel.SetActive(value: false);
		}
	}

	public void ShowHoverPanel(T_ItemSO itemSO, RectTransform targetRect)
	{
		if (hoverPanel != null)
		{
			hoverPanel.Show(itemSO, targetRect);
		}
	}

	public void HideHoverPanel()
	{
		if (hoverPanel != null)
		{
			hoverPanel.Hide();
		}
	}
}
