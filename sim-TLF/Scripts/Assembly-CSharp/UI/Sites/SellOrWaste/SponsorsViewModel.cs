using Loxodon.Framework.ViewModels;

namespace UI.Sites.SellOrWaste
{
	public class SponsorsViewModel : ViewModelBase
	{
		private bool _active = true;

		public bool Active
		{
			get
			{
				return _active;
			}
			internal set
			{
				Set(ref _active, value, "Active");
			}
		}
	}
}
