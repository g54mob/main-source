using System;
using System.Collections.Generic;
using Restory.Data.Devices;
using Restory.Gameplay.Competitions;
using Restory.Gameplay.Devices;
using Restory.UI.Pools;
using Restory.UI.Views;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters.Competitions
{
	public class GUI_CompetitionsDevicesProcurementPageFilters : MonoBehaviour
	{
		private struct DeviceCategoryButton
		{
			public GUI_ToggleButton Button;

			public IDeviceCategory Category;
		}

		[SerializeField]
		private ToggleButtonGroup categoriesToggleGroup;

		private int selectedCategoryIndex;

		private IDeviceCategory selectedCategory;

		private readonly List<DeviceCategoryButton> categoriesButtons = new List<DeviceCategoryButton>();

		private readonly HashSet<IDeviceCategory> categories = new HashSet<IDeviceCategory>();

		private CompetitionsApp competitionsApp;

		private ToggleButtonsUiPool pool;

		private DeviceCategoriesDatabaseProviderService deviceCategoriesDatabaseProvider;

		public bool IsAllDevicesCategorySelected => selectedCategory == deviceCategoriesDatabaseProvider.Database.AllDevicesCategory;

		public IDeviceCategory SelectedCategory => selectedCategory;

		public event Action OnFiltersValueChanged;

		[Inject]
		private void Construct(CompetitionsApp competitionsApp, [Inject(Id = "DeviceShop")] ToggleButtonsUiPool pool, DeviceCategoriesDatabaseProviderService deviceCategoriesDatabaseProvider)
		{
			this.competitionsApp = competitionsApp;
			this.pool = pool;
			this.deviceCategoriesDatabaseProvider = deviceCategoriesDatabaseProvider;
		}

		private void OnEnable()
		{
			categoriesToggleGroup.ValueChanged += ResolveDeviceCategoriesToggleGroupValueChanged;
		}

		private void OnDisable()
		{
			categoriesToggleGroup.ValueChanged -= ResolveDeviceCategoriesToggleGroupValueChanged;
		}

		public void UpdateDeviceCategories()
		{
			ClearCategories();
			UpdateCategoriesHashSet();
			AddCategory(deviceCategoriesDatabaseProvider.AllDevicesCategory);
			foreach (IDeviceCategory category in categories)
			{
				if (category != deviceCategoriesDatabaseProvider.AllDevicesCategory)
				{
					AddCategory(category);
				}
			}
			UpdateCategoriesToggleGroupValue();
		}

		private void UpdateCategoriesHashSet()
		{
			categories.Clear();
			foreach (DeviceInfo availableDevice in competitionsApp.AvailableDevices)
			{
				if (!categories.Contains(availableDevice.Category))
				{
					categories.Add(availableDevice.Category);
				}
			}
		}

		private void AddCategory(IDeviceCategory category)
		{
			GUI_ToggleButton component = pool.Get().GetComponent<GUI_ToggleButton>();
			component.SetInfo(category.BrowserIcon);
			categoriesButtons.Add(new DeviceCategoryButton
			{
				Button = component,
				Category = category
			});
			categoriesToggleGroup.Add(component.ToggleButton);
		}

		private void ClearCategories()
		{
			categoriesToggleGroup.Clear();
			foreach (DeviceCategoryButton categoriesButton in categoriesButtons)
			{
				pool.Release(categoriesButton.Button.gameObject);
			}
			categoriesButtons.Clear();
		}

		private void UpdateCategoriesToggleGroupValue()
		{
			int index = Mathf.Clamp(selectedCategoryIndex, 0, categoriesToggleGroup.Value.Length - 1);
			ToggleButtonGroupState value = categoriesToggleGroup.Value;
			value.ResetAllOptions();
			value[index] = true;
			categoriesToggleGroup.Value = value;
			SetSelectedCategory(index);
		}

		private void SetSelectedCategory(int categoryIndex)
		{
			selectedCategoryIndex = categoryIndex;
			selectedCategory = ((categoriesButtons.Count > selectedCategoryIndex && selectedCategoryIndex > 0) ? categoriesButtons[selectedCategoryIndex].Category : deviceCategoriesDatabaseProvider.AllDevicesCategory);
			this.OnFiltersValueChanged?.Invoke();
		}

		private void ResolveDeviceCategoriesToggleGroupValueChanged(ToggleButtonGroupState index)
		{
			Span<int> activeOptionsIndices = stackalloc int[index.Length];
			Span<int> activeOptions = index.GetActiveOptions(activeOptionsIndices);
			SetSelectedCategory((activeOptions.Length == 1) ? activeOptions[0] : (-1));
		}
	}
}
