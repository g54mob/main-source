using System;
using Loxodon.Framework.Commands;
using Loxodon.Framework.Interactivity;
using Loxodon.Framework.Observables;
using Loxodon.Framework.ViewModels;
using UnityEngine;

namespace Loxodon.Framework.Tutorials
{
	public class ListViewViewModel : ViewModelBase
	{
		private ListItemViewModel selectedItem;

		private SimpleCommand<ListItemViewModel> itemSelectCommand;

		private SimpleCommand<ListItemViewModel> itemClickCommand;

		private AsyncInteractionRequest<VisibilityNotification> itemEditRequest;

		private ObservableList<ListItemViewModel> items;

		public ObservableList<ListItemViewModel> Items
		{
			get
			{
				return items;
			}
			set
			{
				Set(ref items, value, "Items");
			}
		}

		public ListItemViewModel SelectedItem
		{
			get
			{
				return selectedItem;
			}
			set
			{
				Set(ref selectedItem, value, "SelectedItem");
			}
		}

		public IInteractionRequest ItemEditRequest => itemEditRequest;

		public ListViewViewModel()
		{
			itemEditRequest = new AsyncInteractionRequest<VisibilityNotification>(this);
			itemClickCommand = new SimpleCommand<ListItemViewModel>(OnItemClick);
			itemSelectCommand = new SimpleCommand<ListItemViewModel>(OnItemSelect);
			items = CreateList();
		}

		public ListItemViewModel SelectItem(int index)
		{
			if (index < 0 || index >= items.Count)
			{
				throw new Exception();
			}
			ListItemViewModel listItemViewModel = items[index];
			listItemViewModel.IsSelected = true;
			SelectedItem = listItemViewModel;
			if (items != null && listItemViewModel.IsSelected)
			{
				foreach (ListItemViewModel item in items)
				{
					if (item != listItemViewModel)
					{
						item.IsSelected = false;
					}
				}
			}
			return listItemViewModel;
		}

		private async void OnItemClick(ListItemViewModel item)
		{
			ListItemEditViewModel editViewModel = new ListItemEditViewModel(item);
			await itemEditRequest.Raise(VisibilityNotification.CreateShowNotification(editViewModel, waitDisabled: true));
			if (!editViewModel.Cancelled)
			{
				item.Icon = editViewModel.Icon;
				item.Price = editViewModel.Price;
				item.Title = editViewModel.Title;
			}
		}

		private void OnItemSelect(ListItemViewModel item)
		{
			item.IsSelected = !item.IsSelected;
			if (items != null && item.IsSelected)
			{
				foreach (ListItemViewModel item2 in items)
				{
					if (item2 != item)
					{
						item2.IsSelected = false;
					}
				}
			}
			if (item.IsSelected)
			{
				SelectedItem = item;
			}
		}

		public void AddItem()
		{
			Debug.Log("Adding view model item");
			int count = items.Count;
			items.Add(NewItem(count));
		}

		public void RemoveItem()
		{
			if (items.Count > 0)
			{
				int index = UnityEngine.Random.Range(0, items.Count - 1);
				if (items[index].IsSelected)
				{
					SelectedItem = null;
				}
				items.RemoveAt(index);
			}
		}

		public void ClearItem()
		{
			if (items.Count > 0)
			{
				items.Clear();
				SelectedItem = null;
			}
		}

		public void ChangeItemIcon()
		{
			if (items.Count <= 0)
			{
				return;
			}
			foreach (ListItemViewModel item in items)
			{
				int num = UnityEngine.Random.Range(1, 30);
				item.Icon = $"EquipImages_{num}";
			}
		}

		public void ChangeItems()
		{
			SelectedItem = null;
			Items = CreateList();
		}

		private ObservableList<ListItemViewModel> CreateList()
		{
			ObservableList<ListItemViewModel> observableList = new ObservableList<ListItemViewModel>();
			for (int i = 0; i < 3; i++)
			{
				observableList.Add(NewItem(i));
			}
			return observableList;
		}

		private ListItemViewModel NewItem(int id)
		{
			int num = UnityEngine.Random.Range(1, 30);
			float price = UnityEngine.Random.Range(0f, 100f);
			return new ListItemViewModel(itemSelectCommand, itemClickCommand)
			{
				Title = "Equip " + id,
				Icon = $"EquipImages_{num}",
				Price = price
			};
		}
	}
}
