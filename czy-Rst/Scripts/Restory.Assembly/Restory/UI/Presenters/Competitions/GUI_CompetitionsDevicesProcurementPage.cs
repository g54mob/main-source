using System.Collections.Generic;
using Restory.Data.Devices;
using Restory.Gameplay.Competitions;
using Restory.UI.Pools.Shops.Competitions;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters.Competitions
{
	public sealed class GUI_CompetitionsDevicesProcurementPage : MonoBehaviour
	{
		[SerializeField]
		private RectTransform itemsContainer;

		[SerializeField]
		private GUI_CompetitionsDevicesProcurementPageFilters filters;

		private readonly List<GUI_CompetitionsDevicesProcurementItem> items = new List<GUI_CompetitionsDevicesProcurementItem>();

		private CompetitionDeviceProcurementItemsUiPool deviceItemsPool;

		private CompetitionsApp competitionsApp;

		[Inject]
		public void Construct(CompetitionDeviceProcurementItemsUiPool deviceItemsPool, CompetitionsApp competitionsApp)
		{
			this.deviceItemsPool = deviceItemsPool;
			this.competitionsApp = competitionsApp;
		}

		private void OnEnable()
		{
			filters.OnFiltersValueChanged += ResolveFiltersValueChanged;
		}

		private void OnDisable()
		{
			filters.OnFiltersValueChanged -= ResolveFiltersValueChanged;
		}

		public void Show()
		{
			UpdatePage();
		}

		public void Hide()
		{
		}

		private void UpdatePage()
		{
			filters.UpdateDeviceCategories();
			UpdateItems();
		}

		private void UpdateItems()
		{
			ClearItems();
			foreach (DeviceInfo availableDevice in competitionsApp.AvailableDevices)
			{
				if (filters.IsAllDevicesCategorySelected || availableDevice.Category == filters.SelectedCategory)
				{
					GUI_CompetitionsDevicesProcurementItem component = deviceItemsPool.Get(itemsContainer).GetComponent<GUI_CompetitionsDevicesProcurementItem>();
					component.Init(availableDevice);
					items.Add(component);
				}
			}
		}

		private void ClearItems()
		{
			foreach (GUI_CompetitionsDevicesProcurementItem item in items)
			{
				item.Clean();
				deviceItemsPool.Release(item.gameObject);
			}
			items.Clear();
		}

		private void ResolveFiltersValueChanged()
		{
			UpdateItems();
		}
	}
}
