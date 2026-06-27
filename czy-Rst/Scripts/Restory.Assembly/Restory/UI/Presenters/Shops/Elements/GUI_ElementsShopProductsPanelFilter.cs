using System;
using System.Collections.Generic;
using System.Linq;
using Restory.Data.Devices;
using Restory.Data.Elements;
using Restory.Data.Licenses;
using Restory.Data.Shops.Elements;
using Restory.Gameplay.Devices;
using Restory.ObjectPools;
using Restory.UI.Pools;
using Restory.UI.Views.Shops.Elements;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters.Shops.Elements
{
	public class GUI_ElementsShopProductsPanelFilter : MonoBehaviour
	{
		public struct CategoryButton
		{
			public GUI_ToggleButton Button;

			public IDeviceCategory Category;

			public LicenseCategory LicenseCategory;
		}

		[SerializeField]
		private GUI_ToggleButton licenseCategoryButton;

		[SerializeField]
		private GUI_ElementsShopProductsPanelFilterView view;

		private ToggleButtonsUiPool pool;

		private DeviceInfoDatabase deviceDatabase;

		private DeviceCategoriesDatabaseProviderService deviceCategoriesDatabaseProvider;

		private readonly List<CategoryButton> categories = new List<CategoryButton>();

		private readonly List<LicenseShopItemData> licenceItems = new List<LicenseShopItemData>();

		private readonly List<LicenseShopItemData> filteredLicenceItems = new List<LicenseShopItemData>();

		private readonly List<ElementsShopItemData> elementItems = new List<ElementsShopItemData>();

		private readonly List<ElementsShopItemData> filteredElementItems = new List<ElementsShopItemData>();

		private readonly List<IDeviceInfo> devices = new List<IDeviceInfo>();

		private readonly List<string> deviceModels = new List<string>();

		private string allModelsName;

		public bool IsLicensesSelected
		{
			get
			{
				if (view.SelectedDeviceCategoryIndex >= 0 && view.SelectedDeviceCategoryIndex < categories.Count)
				{
					return categories[view.SelectedDeviceCategoryIndex].LicenseCategory;
				}
				return false;
			}
		}

		public IReadOnlyCollection<CategoryButton> Categories => categories;

		public IReadOnlyList<ElementsShopItemData> FilteredElementInfos => filteredElementItems;

		public IReadOnlyList<LicenseShopItemData> FilteredLicenceItems => filteredLicenceItems;

		public event Action OnFiltersChanged;

		[Inject]
		private void Construct([Inject(Id = "ElementsShop")] ToggleButtonsUiPool pool, DeviceInfoDatabase deviceDatabase, DeviceCategoriesDatabaseProviderService deviceCategoriesDatabaseProvider)
		{
			this.pool = pool;
			this.deviceDatabase = deviceDatabase;
			this.deviceCategoriesDatabaseProvider = deviceCategoriesDatabaseProvider;
		}

		private void OnDisable()
		{
			if ((bool)view)
			{
				view.OnSelectedDeviceCategoryChanged -= ResolveSelectedDeviceCategoryChanged;
			}
		}

		public void Activate()
		{
			view.Activate();
			view.OnSelectedDeviceCategoryChanged += ResolveSelectedDeviceCategoryChanged;
			view.OnSelectedModelChanged += ResolveSelectedDeviceModelChanged;
			view.OnSortToggleChanged += ResolveSortToggleChanged;
		}

		public void Deactivate()
		{
			view.OnSelectedDeviceCategoryChanged -= ResolveSelectedDeviceCategoryChanged;
			view.OnSelectedModelChanged -= ResolveSelectedDeviceModelChanged;
			view.OnSortToggleChanged -= ResolveSortToggleChanged;
			view.Deactivate();
			ClearCategories();
			deviceModels.Clear();
		}

		public void SetUpFilters(IEnumerable<ElementsShopItemData> elementItems, IEnumerable<LicenseShopItemData> licenceItems)
		{
			allModelsName = "UI_TEXT_ALL";
			this.elementItems.Clear();
			this.elementItems.AddRange(elementItems);
			this.licenceItems.Clear();
			this.licenceItems.AddRange(licenceItems);
			foreach (ElementsShopItemData elementItem in elementItems)
			{
				IElementInfo element = elementItem.Element;
				if (element != null && deviceDatabase.TryGetDeviceInfo(element, out var deviceInfo))
				{
					devices.Add(deviceInfo);
				}
			}
			SetUpCategories();
			SetUpModels();
			UpdateFilteredInfo();
		}

		public void UpdateFilteredInfo()
		{
			UpdateFilteredItems();
			SortFilteredItems();
			this.OnFiltersChanged?.Invoke();
		}

		public void SelectCategory(IDeviceCategory deviceCategory)
		{
			for (int i = 0; i < categories.Count; i++)
			{
				if (categories[i].Category == deviceCategory)
				{
					view.SelectCategoryByIndex(i);
					break;
				}
			}
		}

		public void SelectCategory(int index)
		{
			if (categories.Count >= index + 1)
			{
				view.SelectCategoryByIndex(index);
			}
		}

		private void SetUpCategories()
		{
			ClearCategories();
			using (IEnumerator<LicenseCategory> enumerator = licenceItems.Select((LicenseShopItemData x) => x.License.Category).Distinct().GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					LicenseCategory current = enumerator.Current;
					AddLicenseCategoryButton(current);
				}
			}
			if (devices.Count > 0)
			{
				AddCategoryButton(deviceCategoriesDatabaseProvider.AllDevicesCategory);
				foreach (IDeviceCategory item in devices.Select((IDeviceInfo x) => x.Category).Distinct())
				{
					AddCategoryButton(item);
				}
			}
			view.SetDeviceCategoriesButtons(categories.Select((CategoryButton button) => button.Button.ToggleButton));
		}

		private void AddCategoryButton(IDeviceCategory category)
		{
			GUI_ToggleButton gUI_ToggleButton = pool.Get<GUI_ToggleButton>();
			gUI_ToggleButton.SetInfo(category.BrowserIcon);
			categories.Add(new CategoryButton
			{
				Button = gUI_ToggleButton,
				Category = category,
				LicenseCategory = null
			});
		}

		private void AddLicenseCategoryButton(LicenseCategory category)
		{
			licenseCategoryButton.gameObject.SetActive(value: true);
			licenseCategoryButton.transform.localScale = Vector3.one;
			categories.Add(new CategoryButton
			{
				Button = licenseCategoryButton,
				Category = null,
				LicenseCategory = category
			});
		}

		private void ClearCategories()
		{
			foreach (CategoryButton category in categories)
			{
				if (category.Button == licenseCategoryButton)
				{
					licenseCategoryButton.gameObject.SetActive(value: false);
				}
				else
				{
					pool.Release(category.Button);
				}
			}
			categories.Clear();
		}

		private void SetUpModels()
		{
			deviceModels.Clear();
			CategoryButton categoryButton = categories[view.SelectedDeviceCategoryIndex];
			if (!categoryButton.LicenseCategory)
			{
				deviceModels.Add(allModelsName);
				if (categoryButton.Category == deviceCategoriesDatabaseProvider.Database.AllDevicesCategory)
				{
					AddAllModelsToListFromDevicesList(deviceModels);
				}
				else
				{
					AddModelsToListFromDevicesList(categoryButton.Category, deviceModels);
				}
				view.SetModelsOptionsVisibility(isVisible: true);
				view.SetSortToggleVisibility(isVisible: true);
				view.SetModelsOptions(deviceModels);
			}
			else
			{
				view.SetModelsOptionsVisibility(isVisible: false);
				view.SetSortToggleVisibility(isVisible: false);
			}
		}

		private void AddAllModelsToListFromDevicesList(List<string> modelsList)
		{
			foreach (IDeviceInfo device in devices)
			{
				if (device.NameLocalizationKey != allModelsName && !modelsList.Contains(device.NameLocalizationKey))
				{
					modelsList.Add(device.NameLocalizationKey);
				}
			}
		}

		private void AddModelsToListFromDevicesList(IDeviceCategory deviceCategory, List<string> modelsList)
		{
			foreach (IDeviceInfo device in devices)
			{
				if (device.Category == deviceCategory && device.NameLocalizationKey != allModelsName && !modelsList.Contains(device.NameLocalizationKey))
				{
					modelsList.Add(device.NameLocalizationKey);
				}
			}
		}

		private void UpdateFilteredItems()
		{
			filteredElementItems.Clear();
			filteredLicenceItems.Clear();
			CategoryButton categoryButton = categories[view.SelectedDeviceCategoryIndex];
			if ((bool)categoryButton.LicenseCategory)
			{
				filteredLicenceItems.AddRange(licenceItems.Where((LicenseShopItemData item) => item.License.Category == categoryButton.LicenseCategory));
			}
			else if (view.SelectedModelIndex == 0 || view.SelectedModelIndex == -1)
			{
				if (categoryButton.Category == deviceCategoriesDatabaseProvider.Database.AllDevicesCategory)
				{
					AddAllElementsToFilteredItems();
				}
				else
				{
					AddElementsToFilteredItems(categoryButton.Category);
				}
			}
			else
			{
				AddElementsToFilteredItem(deviceModels[view.SelectedModelIndex]);
			}
		}

		private void AddAllElementsToFilteredItems()
		{
			foreach (ElementsShopItemData elementItem in elementItems)
			{
				if (elementItem != null && (object)elementItem.Element != null && !filteredElementItems.Contains(elementItem))
				{
					filteredElementItems.Add(elementItem);
				}
			}
		}

		private void AddElementsToFilteredItems(IDeviceCategory deviceCategory)
		{
			foreach (IDeviceInfo device in devices)
			{
				if (device.Category != deviceCategory)
				{
					continue;
				}
				foreach (ElementsShopItemData elementItem in elementItems)
				{
					if (elementItem == null)
					{
						continue;
					}
					IElementInfo element = elementItem.Element;
					if (element == null)
					{
						continue;
					}
					foreach (IElementInfo element2 in device.Elements)
					{
						if (element == element2 && !filteredElementItems.Contains(elementItem))
						{
							filteredElementItems.Add(elementItem);
						}
					}
				}
			}
		}

		private void AddElementsToFilteredItem(string model)
		{
			foreach (IDeviceInfo device in devices)
			{
				if (!(device.NameLocalizationKey == model))
				{
					continue;
				}
				{
					foreach (ElementsShopItemData elementItem in elementItems)
					{
						if (elementItem == null)
						{
							continue;
						}
						IElementInfo element = elementItem.Element;
						if (element == null)
						{
							continue;
						}
						foreach (IElementInfo element2 in device.Elements)
						{
							if (element == element2 && !filteredElementItems.Contains(elementItem))
							{
								filteredElementItems.Add(elementItem);
							}
						}
					}
					break;
				}
			}
		}

		private void SortFilteredItems()
		{
			if (view.IsSortToggleOn)
			{
				filteredElementItems.Sort((ElementsShopItemData x, ElementsShopItemData y) => x.Price.CompareTo(y.Price));
			}
			else
			{
				filteredElementItems.Sort((ElementsShopItemData x, ElementsShopItemData y) => y.Price.CompareTo(x.Price));
			}
		}

		private void ResolveSelectedDeviceCategoryChanged()
		{
			SetUpModels();
			UpdateFilteredItems();
			SortFilteredItems();
			this.OnFiltersChanged?.Invoke();
		}

		private void ResolveSelectedDeviceModelChanged()
		{
			UpdateFilteredItems();
			SortFilteredItems();
			this.OnFiltersChanged?.Invoke();
		}

		private void ResolveSortToggleChanged()
		{
			SortFilteredItems();
			this.OnFiltersChanged?.Invoke();
		}
	}
}
