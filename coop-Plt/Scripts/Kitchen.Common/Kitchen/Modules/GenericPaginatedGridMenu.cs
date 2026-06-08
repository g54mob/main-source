using System.Collections.Generic;
using UnityEngine;

namespace Kitchen.Modules
{
	public class GenericPaginatedGridMenu : GenericGridMenu
	{
		public int CurrentIndex;

		public List<IGridItem> Items;

		protected override int RowLength => 6;

		protected override int ColumnLength => 1;

		public GenericPaginatedGridMenu(List<IGridItem> items, Transform container, int player, bool has_back)
			: base(items, container, player, has_back)
		{
			Items = items;
		}

		protected void ChangePage(int offset)
		{
			CurrentIndex += offset;
			CurrentIndex = Mathf.Clamp(CurrentIndex, 0, Items.Count - 1);
			CreateElements(Items, has_back: false);
			(int total, bool is_first, bool is_back, int final) indices = GetIndices();
			bool item = indices.is_first;
			bool item2 = indices.is_back;
			if (Grid.Modules.Count > 0)
			{
				if (offset > 0 && !item2)
				{
					Grid.Select(Grid.Modules[Grid.Modules.Count - 1].Module);
				}
				else if (offset < 0 && !item)
				{
					Grid.Select(Grid.Modules[0].Module);
				}
			}
		}

		protected (int total, bool is_first, bool is_back, int final) GetIndices()
		{
			int num = base.MaxPerGroup - 2;
			bool item = CurrentIndex == 0;
			bool item2 = Items.Count < CurrentIndex + num;
			int item3 = Mathf.Min(Items.Count, CurrentIndex + num);
			return (total: num, is_first: item, is_back: item2, final: item3);
		}

		protected override void CreateElements(List<IGridItem> list, bool has_back)
		{
			Items = list;
			GridMenuElement prefab = GetPrefab();
			Grid?.Destroy();
			Grid = new ModuleGrid
			{
				RowLength = RowLength,
				ColumnLength = ColumnLength,
				XSpacing = ElementWidth,
				YSpacing = ElementHeight,
				Padding = Padding
			};
			(int, bool, bool, int) indices = GetIndices();
			int total_icons = indices.Item1;
			bool item = indices.Item2;
			bool item2 = indices.Item3;
			int item3 = indices.Item4;
			GridMenuElement gridMenuElement = Object.Instantiate(prefab, Container, worldPositionStays: false);
			if (!item)
			{
				gridMenuElement.OnActivate += delegate
				{
					ChangePage(-total_icons);
				};
			}
			gridMenuElement.SetAsBack();
			gridMenuElement.SetVisible(!item);
			gridMenuElement.SetSelectable(!item);
			Grid.AddModule(gridMenuElement);
			int num = 0;
			for (int num2 = CurrentIndex; num2 < item3; num2++)
			{
				IGridItem item4 = list[num2];
				GridMenuElement gridMenuElement2 = Object.Instantiate(prefab, Container, worldPositionStays: false);
				SetupElement(item4, gridMenuElement2);
				gridMenuElement2.OnActivate += delegate
				{
					OnSelect(item4);
				};
				Grid.AddModule(gridMenuElement2);
				num++;
			}
			for (; num < total_icons; num++)
			{
				GridMenuElement gridMenuElement3 = Object.Instantiate(prefab, Container, worldPositionStays: false);
				gridMenuElement3.SetSelectable(selectable: false);
				Grid.AddModule(gridMenuElement3);
			}
			GridMenuElement gridMenuElement4 = Object.Instantiate(prefab, Container, worldPositionStays: false);
			if (!item2)
			{
				gridMenuElement4.OnActivate += delegate
				{
					ChangePage(total_icons);
				};
			}
			gridMenuElement4.SetAsNext();
			gridMenuElement4.SetVisible(!item2);
			gridMenuElement4.SetSelectable(!item2);
			Grid.AddModule(gridMenuElement4);
			Panel.SetTarget(Grid);
			Panel.SetColour(Player);
		}
	}
}
