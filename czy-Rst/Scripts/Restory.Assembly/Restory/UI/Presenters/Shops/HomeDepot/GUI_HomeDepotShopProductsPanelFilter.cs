using System;
using System.Collections.Generic;
using System.Linq;
using Restory.Data.Shops;
using Restory.Data.Shops.HomeDepot;
using Restory.ObjectPools;
using Restory.UI.Pools;
using Restory.UI.Views.Shops.HomeDepot;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters.Shops.HomeDepot
{
	public class GUI_HomeDepotShopProductsPanelFilter : MonoBehaviour
	{
		private struct DecorCategoryButton
		{
			public GUI_ToggleButton ButtonPresenter;

			public IShopCategory Category;
		}

		[SerializeField]
		private GUI_DecorShopProductsPanelFilterView view;

		private readonly List<HomeDepotShopDecorItemData> filteredDecorItems = new List<HomeDepotShopDecorItemData>();

		private readonly List<HomeDepotShopDecorItemData> allDecorItems = new List<HomeDepotShopDecorItemData>();

		private readonly List<HomeDepotShopCleaningToolItemData> filteredCleaningToolItems = new List<HomeDepotShopCleaningToolItemData>();

		private readonly List<HomeDepotShopCleaningToolItemData> allCleaningToolItems = new List<HomeDepotShopCleaningToolItemData>();

		private readonly List<HomeDepotShopPaintingPaletteItemData> filteredPaintingPaletteItems = new List<HomeDepotShopPaintingPaletteItemData>();

		private readonly List<HomeDepotShopPaintingPaletteItemData> allPaintingPaletteItems = new List<HomeDepotShopPaintingPaletteItemData>();

		private readonly List<HomeDepotShopPcAppItemData> filteredPcAppItems = new List<HomeDepotShopPcAppItemData>();

		private readonly List<HomeDepotShopPcAppItemData> allPcAppItems = new List<HomeDepotShopPcAppItemData>();

		private readonly List<DecorCategoryButton> categories = new List<DecorCategoryButton>();

		private ToggleButtonsUiPool pool;

		public List<HomeDepotShopDecorItemData> FilteredDecorItems => filteredDecorItems;

		public List<HomeDepotShopCleaningToolItemData> FilteredCleaningToolItems => filteredCleaningToolItems;

		public List<HomeDepotShopPaintingPaletteItemData> FilteredPaintingPaletteItems => filteredPaintingPaletteItems;

		public List<HomeDepotShopPcAppItemData> FilteredPcAppItems => filteredPcAppItems;

		public event Action OnFiltersValueChanged;

		[Inject]
		private void Construct([Inject(Id = "ElementsShop")] ToggleButtonsUiPool pool)
		{
			this.pool = pool;
		}

		private void OnDisable()
		{
			if ((bool)view)
			{
				view.OnSelectedCategoryChanged -= ResolveSelectedCategoryChanged;
			}
		}

		public void Activate()
		{
			view.Activate();
			view.OnSelectedCategoryChanged += ResolveSelectedCategoryChanged;
		}

		public void Deactivate()
		{
			view.OnSelectedCategoryChanged -= ResolveSelectedCategoryChanged;
			view.Deactivate();
			ClearCategories();
		}

		public void SetUpFilters(IEnumerable<HomeDepotShopDecorItemData> decorItems, IEnumerable<HomeDepotShopCleaningToolItemData> cleaningToolItems, IEnumerable<HomeDepotShopPaintingPaletteItemData> paintingPaletteItems, IEnumerable<HomeDepotShopPcAppItemData> pcAppItems)
		{
			allDecorItems.Clear();
			allDecorItems.AddRange(decorItems);
			allCleaningToolItems.Clear();
			allCleaningToolItems.AddRange(cleaningToolItems);
			allPaintingPaletteItems.Clear();
			allPaintingPaletteItems.AddRange(paintingPaletteItems);
			allPcAppItems.Clear();
			allPcAppItems.AddRange(pcAppItems);
			UpdateCategories();
			UpdateFilteredItems();
		}

		private void UpdateFilteredItems()
		{
			filteredDecorItems.Clear();
			filteredCleaningToolItems.Clear();
			filteredPaintingPaletteItems.Clear();
			filteredPcAppItems.Clear();
			IShopCategory category = categories.ElementAtOrDefault(view.SelectedCategoryIndex).Category;
			filteredDecorItems.AddRange(allDecorItems.Where((HomeDepotShopDecorItemData i) => i.GetCategory().ID == category.ID));
			filteredDecorItems.Sort(CompareBySortOrderThenPrice);
			filteredCleaningToolItems.AddRange(allCleaningToolItems.Where((HomeDepotShopCleaningToolItemData i) => i.GetCategory().ID == category.ID));
			filteredCleaningToolItems.Sort(CompareBySortOrderThenPrice);
			filteredPaintingPaletteItems.AddRange(allPaintingPaletteItems.Where((HomeDepotShopPaintingPaletteItemData i) => i.Category.ID == category.ID));
			filteredPaintingPaletteItems.Sort(CompareBySortOrderThenPrice);
			filteredPcAppItems.AddRange(allPcAppItems.Where((HomeDepotShopPcAppItemData i) => i.Category.ID == category.ID));
			filteredPcAppItems.Sort(CompareBySortOrderThenPrice);
		}

		private static int CompareBySortOrderThenPrice(HomeDepotShopItemData a, HomeDepotShopItemData b)
		{
			int num = b.SortOrder.CompareTo(a.SortOrder);
			if (num != 0)
			{
				return num;
			}
			return a.Price.CompareTo(b.Price);
		}

		private void UpdateCategories()
		{
			ClearCategories();
			List<IShopCategory> list = new List<IShopCategory>();
			foreach (HomeDepotShopCleaningToolItemData allCleaningToolItem in allCleaningToolItems)
			{
				IShopCategory category = allCleaningToolItem.GetCategory();
				if (!list.Contains(category))
				{
					list.Add(category);
				}
			}
			foreach (HomeDepotShopDecorItemData allDecorItem in allDecorItems)
			{
				IShopCategory category = allDecorItem.GetCategory();
				if (!list.Contains(category))
				{
					list.Add(category);
				}
			}
			foreach (HomeDepotShopPaintingPaletteItemData allPaintingPaletteItem in allPaintingPaletteItems)
			{
				IShopCategory category = allPaintingPaletteItem.Category;
				if (!list.Contains(category))
				{
					list.Add(category);
				}
			}
			foreach (HomeDepotShopPcAppItemData allPcAppItem in allPcAppItems)
			{
				IShopCategory category = allPcAppItem.Category;
				if (!list.Contains(category))
				{
					list.Add(category);
				}
			}
			foreach (IShopCategory item in list)
			{
				GUI_ToggleButton gUI_ToggleButton = pool.Get<GUI_ToggleButton>();
				gUI_ToggleButton.SetInfo(item.BrowserIcon);
				categories.Add(new DecorCategoryButton
				{
					ButtonPresenter = gUI_ToggleButton,
					Category = item
				});
			}
			view.SetCategoryButtons(categories.Select((DecorCategoryButton button) => button.ButtonPresenter.ToggleButton));
		}

		private void ClearCategories()
		{
			foreach (DecorCategoryButton category in categories)
			{
				pool.Release(category.ButtonPresenter);
			}
			categories.Clear();
		}

		private void ResolveSelectedCategoryChanged()
		{
			UpdateFilteredItems();
			this.OnFiltersValueChanged?.Invoke();
		}
	}
}
