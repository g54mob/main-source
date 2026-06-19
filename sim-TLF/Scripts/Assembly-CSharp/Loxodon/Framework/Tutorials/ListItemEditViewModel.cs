using Loxodon.Framework.ViewModels;
using UnityEngine;

namespace Loxodon.Framework.Tutorials
{
	public class ListItemEditViewModel : ViewModelBase
	{
		private string title;

		private string icon;

		private float price;

		private bool cancelled;

		public string Title
		{
			get
			{
				return title;
			}
			set
			{
				Set(ref title, value, "Title");
			}
		}

		public string Icon
		{
			get
			{
				return icon;
			}
			set
			{
				Set(ref icon, value, "Icon");
			}
		}

		public float Price
		{
			get
			{
				return price;
			}
			set
			{
				Set(ref price, value, "Price");
			}
		}

		public bool Cancelled
		{
			get
			{
				return cancelled;
			}
			set
			{
				Set(ref cancelled, value, "Cancelled");
			}
		}

		public ListItemEditViewModel(ListItemViewModel vm)
		{
			title = vm.Title;
			icon = vm.Icon;
			price = vm.Price;
		}

		public void OnChangeIcon()
		{
			int num = Random.Range(1, 30);
			Icon = $"EquipImages_{num}";
		}
	}
}
