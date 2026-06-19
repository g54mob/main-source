using Loxodon.Framework.Commands;
using Loxodon.Framework.ViewModels;

namespace Loxodon.Framework.Tutorials
{
	public class ListItemViewModel : ViewModelBase
	{
		private string title;

		private string icon;

		private float price;

		private bool selected;

		private ICommand clickCommand;

		private ICommand selectCommand;

		public ICommand ClickCommand => clickCommand;

		public ICommand SelectCommand => selectCommand;

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

		public bool IsSelected
		{
			get
			{
				return selected;
			}
			set
			{
				Set(ref selected, value, "IsSelected");
			}
		}

		public ListItemViewModel(ICommand selectCommand, ICommand clickCommand)
		{
			this.selectCommand = selectCommand;
			this.clickCommand = clickCommand;
		}
	}
}
