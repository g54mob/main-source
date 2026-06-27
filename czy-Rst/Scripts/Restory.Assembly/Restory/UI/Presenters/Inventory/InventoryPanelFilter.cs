using System;
using System.Collections.Generic;
using System.Linq;
using Restory.Data.Devices;
using Restory.Data.Elements;
using Restory.Gameplay.Devices;
using Restory.Gameplay.Inventory;
using Restory.UI.Views.Inventory;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters.Inventory
{
	public sealed class InventoryPanelFilter : MonoBehaviour
	{
		public Action<InventoryPanelFilter> DevicePartInfosChanged;

		public Action<InventoryPanelFilter> SortChanged;

		[SerializeField]
		private InventoryPanelFilterView view;

		private DeviceInfoDatabase deviceDatabase;

		private IInventory inventory;

		private DeviceCategoriesDatabaseProviderService deviceCategoriesDatabaseProvider;

		private readonly List<IDeviceCategory> deviceCategories = new List<IDeviceCategory>();

		private readonly List<string> deviceModels = new List<string>();

		private readonly HashSet<IElementInfo> devicePartInfos = new HashSet<IElementInfo>();

		private readonly HashSet<string> availableModels = new HashSet<string>();

		private readonly HashSet<IDeviceCategory> availableCategories = new HashSet<IDeviceCategory>();

		private bool isLocked;

		public HashSet<IElementInfo> DevicePartInfos => devicePartInfos;

		public bool Visible
		{
			get
			{
				return view.Visible;
			}
			set
			{
				view.Visible = value;
			}
		}

		public bool Sort => view.SortState;

		[Inject]
		private void Construct(IInventory inventory, DeviceInfoDatabase deviceDatabase, DeviceCategoriesDatabaseProviderService deviceCategoriesDatabaseProvider)
		{
			this.inventory = inventory;
			this.deviceDatabase = deviceDatabase;
			this.deviceCategoriesDatabaseProvider = deviceCategoriesDatabaseProvider;
		}

		public void Init()
		{
			isLocked = false;
			view.SelectedDeviceCategoryIndex = 0;
			view.SelectedModelIndex = 0;
			UpdateStorageInfo();
			ResetFilter();
		}

		public void Subscribe()
		{
			view.SelectedCategoryChanged += OnSelectedCategoryChanged;
			view.SelectedModelChanged += OnSelectedModelChanged;
			view.SortChanged += OnSortChanged;
		}

		public void Unsubscribe()
		{
			view.SortChanged -= OnSortChanged;
			view.SelectedModelChanged -= OnSelectedModelChanged;
			view.SelectedCategoryChanged -= OnSelectedCategoryChanged;
			devicePartInfos.Clear();
			deviceCategories.Clear();
			deviceModels.Clear();
		}

		public void Lock(DeviceInfo deviceInfo)
		{
			isLocked = true;
			view.DeviceCategories = new List<Restory.UI.Views.Inventory.DeviceCategory>
			{
				new Restory.UI.Views.Inventory.DeviceCategory
				{
					ID = deviceInfo.Category.ID,
					Icon = deviceInfo.Category.Icon
				}
			};
			view.Models = new List<string> { deviceInfo.NameLocalizationKey };
			view.SelectedDeviceCategoryIndex = 0;
			view.SelectedModelIndex = 0;
			deviceDatabase.GetDevicePartInfos(deviceInfo.Category, deviceInfo.NameLocalizationKey, devicePartInfos);
			DevicePartInfosChanged?.Invoke(this);
		}

		public void Release()
		{
			isLocked = false;
			ResetFilter();
		}

		public void UpdateStorageInfo()
		{
			deviceDatabase.GetStorageState(inventory.StorageElements, availableModels, availableCategories);
		}

		private void ResetFilter()
		{
			UpdateDeviceCategories();
			UpdateDeviceModels();
			UpdateView();
			UpdateDevicePartInfos();
		}

		private void UpdateDeviceCategories()
		{
			deviceCategories.Clear();
			foreach (IDeviceCategory availableCategory in availableCategories)
			{
				deviceCategories.Add(availableCategory);
			}
		}

		private void UpdateDeviceModels()
		{
			deviceModels.Clear();
			bool num = view.SelectedDeviceCategoryIndex == 0 || view.SelectedDeviceCategoryIndex == -1;
			int index = view.SelectedDeviceCategoryIndex - 1;
			if (num)
			{
				foreach (string availableModel in availableModels)
				{
					deviceModels.Add(availableModel);
				}
				return;
			}
			List<string> list = new List<string>();
			deviceDatabase.GetDeviceModels(deviceCategories[index], list);
			foreach (string item in list)
			{
				if (availableModels.Contains(item))
				{
					deviceModels.Add(item);
				}
			}
		}

		private void UpdateDevicePartInfos()
		{
			devicePartInfos.Clear();
			bool num = view.SelectedDeviceCategoryIndex == 0 || view.SelectedDeviceCategoryIndex == -1;
			bool flag = view.SelectedModelIndex == 0 || view.SelectedModelIndex == -1;
			int index = view.SelectedModelIndex - 1;
			int index2 = view.SelectedDeviceCategoryIndex - 1;
			if (num)
			{
				if (flag)
				{
					deviceDatabase.GetDevicePartInfos(devicePartInfos);
					return;
				}
				string deviceModel = deviceModels[index];
				deviceDatabase.GetDevicePartInfos(deviceModel, devicePartInfos);
			}
			else if (flag)
			{
				IDeviceCategory category = deviceCategories[index2];
				deviceDatabase.GetDevicePartInfos(category, devicePartInfos);
			}
			else
			{
				IDeviceCategory category2 = deviceCategories[index2];
				string deviceModel2 = deviceModels[index];
				deviceDatabase.GetDevicePartInfos(category2, deviceModel2, devicePartInfos);
			}
		}

		private void UpdateView()
		{
			UpdateDeviceCategoriesView();
			UpdateModelsView();
		}

		private void UpdateDeviceCategoriesView()
		{
			List<Restory.UI.Views.Inventory.DeviceCategory> list = new List<Restory.UI.Views.Inventory.DeviceCategory>
			{
				new Restory.UI.Views.Inventory.DeviceCategory
				{
					ID = deviceCategoriesDatabaseProvider.AllDevicesCategory.ID,
					Icon = deviceCategoriesDatabaseProvider.AllDevicesCategory.Icon
				}
			};
			list.AddRange(deviceCategories.Select((IDeviceCategory t) => new Restory.UI.Views.Inventory.DeviceCategory
			{
				ID = t.ID,
				Icon = t.Icon
			}));
			view.DeviceCategories = list;
			if (view.SelectedDeviceCategoryIndex == -1)
			{
				view.SelectedDeviceCategoryIndex = 0;
			}
		}

		private void UpdateModelsView()
		{
			List<string> list = new List<string> { "UI_TEXT_ALL" };
			list.AddRange(deviceModels);
			view.Models = list;
			if (view.SelectedModelIndex == -1)
			{
				view.SelectedModelIndex = 0;
			}
		}

		private void OnSelectedCategoryChanged(InventoryPanelFilterView v, int i)
		{
			if (!isLocked)
			{
				UpdateDeviceModels();
				UpdateModelsView();
				UpdateDevicePartInfos();
				DevicePartInfosChanged?.Invoke(this);
			}
		}

		private void OnSelectedModelChanged(InventoryPanelFilterView v, int i)
		{
			UpdateDevicePartInfos();
			DevicePartInfosChanged?.Invoke(this);
		}

		private void OnSortChanged(InventoryPanelFilterView v, bool s)
		{
			SortChanged?.Invoke(this);
		}

		public void Clear()
		{
			view.SortChanged -= OnSortChanged;
			view.SelectedModelChanged -= OnSelectedModelChanged;
			view.SelectedCategoryChanged -= OnSelectedCategoryChanged;
			view.Clear();
			devicePartInfos.Clear();
			deviceCategories.Clear();
			deviceModels.Clear();
		}
	}
}
