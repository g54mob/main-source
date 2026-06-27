using System;
using System.Collections.Generic;
using System.Linq;
using Restory.Data.Shops;
using Restory.Gameplay.Devices;
using Restory.Gameplay.Shops.Devices;
using Restory.ObjectPools;
using Restory.UI.Pools;
using Restory.UI.Views.Shops.Devices;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace Restory.UI.Presenters.Shops.Devices
{
	public class GUI_DeviceShopFilter : MonoBehaviour
	{
		private struct DeviceCategoryButton
		{
			public GUI_ToggleButton ButtonPresenter;

			public IShopCategory Category;
		}

		[SerializeField]
		private GUI_DeviceShopFilterView view;

		private ToggleButtonsUiPool pool;

		private DeviceCategoriesDatabaseProviderService deviceCategoriesDatabaseProvider;

		private readonly List<DeviceCategoryButton> categoriesButtonsList = new List<DeviceCategoryButton>();

		public bool IsAllCategorySelected => SelectedCategory == deviceCategoriesDatabaseProvider.Database.AllDevicesCategory;

		public IShopCategory SelectedCategory
		{
			get
			{
				if (categoriesButtonsList.Count <= view.SelectedDeviceCategoryIndex || view.SelectedDeviceCategoryIndex <= 0)
				{
					return deviceCategoriesDatabaseProvider.AllDevicesCategory;
				}
				return categoriesButtonsList[view.SelectedDeviceCategoryIndex].Category;
			}
		}

		public event Action OnFiltersValueChanged;

		[Inject]
		private void Construct([Inject(Id = "DeviceShop")] ToggleButtonsUiPool pool, DeviceCategoriesDatabaseProviderService deviceCategoriesDatabaseProvider)
		{
			this.pool = pool;
			this.deviceCategoriesDatabaseProvider = deviceCategoriesDatabaseProvider;
		}

		private void OnEnable()
		{
			view.OnSelectedDeviceCategoryChanged += ResolveSelectedDeviceCategoryChanged;
		}

		private void OnDisable()
		{
			view.OnSelectedDeviceCategoryChanged -= ResolveSelectedDeviceCategoryChanged;
		}

		public void Activate()
		{
			view.Activate();
		}

		public void Deactivate()
		{
			view.Deactivate();
			ClearDeviceCategories();
		}

		public void SetUpFilters(IEnumerable<ILot> lots)
		{
			HashSet<IShopCategory> value;
			using (CollectionPool<HashSet<IShopCategory>, IShopCategory>.Get(out value))
			{
				foreach (ILot lot in lots)
				{
					if (lot is IDeviceShopLot deviceShopLot)
					{
						value.Add(deviceShopLot.Device.DeviceInfo.Category);
					}
				}
				SetUpDeviceCategories(value);
			}
		}

		private void SetUpDeviceCategories(IEnumerable<IShopCategory> deviceCategoriesList)
		{
			ClearDeviceCategories();
			AddCategoryButtonToList(deviceCategoriesDatabaseProvider.AllDevicesCategory, categoriesButtonsList);
			foreach (IShopCategory deviceCategories in deviceCategoriesList)
			{
				if (deviceCategories != deviceCategoriesDatabaseProvider.AllDevicesCategory)
				{
					AddCategoryButtonToList(deviceCategories, categoriesButtonsList);
				}
			}
			view.SetDeviceCategoriesButtons(categoriesButtonsList.Select((DeviceCategoryButton button) => button.ButtonPresenter.ToggleButton));
		}

		private void AddCategoryButtonToList(IShopCategory category, List<DeviceCategoryButton> deviceCategoryButtons)
		{
			GUI_ToggleButton gUI_ToggleButton = pool.Get<GUI_ToggleButton>();
			gUI_ToggleButton.SetInfo(category.BrowserIcon);
			deviceCategoryButtons.Add(new DeviceCategoryButton
			{
				ButtonPresenter = gUI_ToggleButton,
				Category = category
			});
		}

		private void ResolveSelectedDeviceCategoryChanged()
		{
			this.OnFiltersValueChanged?.Invoke();
		}

		private void ClearDeviceCategories()
		{
			foreach (DeviceCategoryButton categoriesButtons in categoriesButtonsList)
			{
				pool.Release(categoriesButtons.ButtonPresenter);
			}
			categoriesButtonsList.Clear();
		}
	}
}
