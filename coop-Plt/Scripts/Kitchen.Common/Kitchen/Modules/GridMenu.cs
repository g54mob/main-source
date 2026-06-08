using System;
using System.Collections.Generic;
using Controllers;
using UnityEngine;

namespace Kitchen.Modules
{
	public abstract class GridMenu
	{
		public ModuleGrid Grid;

		public Transform Container;

		public int Player;

		public PanelElement Panel;

		public event Action<GridMenuConfig> OnRequestMenu = delegate
		{
		};

		public event Action<object> OnRequest = delegate
		{
		};

		public event Action OnGoBack = delegate
		{
		};

		public bool HandleInteraction(InputState state)
		{
			return Grid.HandleInteraction(state);
		}

		public void Destroy()
		{
			Grid.Destroy();
			Panel.Destroy();
		}

		protected void RequestNewMenu(GridMenuConfig cfg)
		{
			this.OnRequestMenu(cfg);
		}

		protected void RequestGoBack()
		{
			this.OnGoBack();
		}

		protected void Request(object obj)
		{
			this.OnRequest(obj);
		}

		public int SelectedIndex()
		{
			return Grid.Modules.IndexOf(Grid.Selected);
		}

		public void SelectByIndex(int index)
		{
			if (index >= 0 && index < Grid.Modules.Count)
			{
				Grid.Select(Grid.Modules[index].Module);
			}
		}
	}
	public abstract class GridMenu<TItem> : GridMenu
	{
		protected virtual int RowLength => 4;

		protected virtual int ColumnLength => 2;

		protected int MaxPerGroup => RowLength * ColumnLength;

		protected virtual float ElementWidth => 0.5f;

		protected virtual float ElementHeight => 0.5f;

		protected virtual float Padding => 0.1f;

		protected virtual GridMenuElement GetPrefab()
		{
			return ModuleDirectory.Main.GetPrefab<GridMenuElement>();
		}

		public GridMenu(List<TItem> items, Transform container, int player, bool has_back)
		{
			Container = container;
			Player = player;
			Panel = UnityEngine.Object.Instantiate(ModuleDirectory.Main.GetPrefab<PanelElement>(), container, worldPositionStays: false);
			CreateElements(items, has_back);
		}

		protected virtual void CreateElements(List<TItem> list, bool has_back)
		{
			GridMenuElement prefab = GetPrefab();
			Grid = new ModuleGrid
			{
				RowLength = RowLength,
				ColumnLength = ColumnLength,
				XSpacing = ElementWidth,
				YSpacing = ElementHeight,
				Padding = Padding
			};
			int num = MaxPerGroup - (has_back ? 1 : 0);
			if (has_back)
			{
				GridMenuElement gridMenuElement = UnityEngine.Object.Instantiate(prefab, Container, worldPositionStays: false);
				gridMenuElement.OnActivate += base.RequestGoBack;
				gridMenuElement.SetAsBack();
				Grid.AddModule(gridMenuElement);
			}
			int num2 = 0;
			foreach (TItem item in list)
			{
				GridMenuElement gridMenuElement2 = UnityEngine.Object.Instantiate(prefab, Container, worldPositionStays: false);
				SetupElement(item, gridMenuElement2);
				gridMenuElement2.OnActivate += delegate
				{
					OnSelect(item);
				};
				Grid.AddModule(gridMenuElement2);
				if (++num2 >= num)
				{
					break;
				}
			}
			for (; num2 < num; num2++)
			{
				GridMenuElement gridMenuElement3 = UnityEngine.Object.Instantiate(prefab, Container, worldPositionStays: false);
				gridMenuElement3.SetSelectable(selectable: false);
				Grid.AddModule(gridMenuElement3);
			}
			Panel.SetTarget(Grid);
			Panel.SetColour(Player);
		}

		protected abstract void SetupElement(TItem item, GridMenuElement element);

		protected abstract void OnSelect(TItem item);
	}
}
