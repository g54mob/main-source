using Loxodon.Framework.ViewModels;
using Services.Missions;
using Zenject;

namespace UI.Sites.SellOrWaste
{
	public class RightPanelViewModel : ViewModelBase
	{
		public readonly SponsorsViewModel sponsorsViewModel;

		public readonly CartViewModel cartViewModel;

		[Inject]
		private MissionEventBus _missionEventBus;

		public RightPanelViewModel(SponsorsViewModel sponsorsViewModel, CartViewModel cartViewModel)
		{
			this.sponsorsViewModel = sponsorsViewModel;
			this.cartViewModel = cartViewModel;
		}

		public void OpenCart()
		{
			cartViewModel.Active = true;
			sponsorsViewModel.Active = false;
		}

		public void CartButtonClick()
		{
			cartViewModel.Active = !cartViewModel.Active;
			sponsorsViewModel.Active = !cartViewModel.Active;
		}
	}
}
