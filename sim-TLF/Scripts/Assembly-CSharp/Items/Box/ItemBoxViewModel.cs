using Loxodon.Framework.ViewModels;

namespace Items.Box
{
	public class ItemBoxViewModel : ViewModelBase
	{
		private bool _opened;

		private bool _interactable;

		public bool Opened
		{
			get
			{
				return _opened;
			}
			set
			{
				Set(ref _opened, value, "Opened");
			}
		}

		public bool Interactable
		{
			get
			{
				return _interactable;
			}
			set
			{
				Set(ref _interactable, value, "Interactable");
			}
		}

		public void Open()
		{
			Opened = true;
		}
	}
}
