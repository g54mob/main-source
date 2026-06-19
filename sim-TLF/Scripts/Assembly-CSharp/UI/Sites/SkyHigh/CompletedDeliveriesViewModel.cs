using Computer.Sites.Services.Delivery;
using Loxodon.Framework.Observables;
using Loxodon.Framework.ViewModels;
using Zenject;

namespace UI.Sites.SkyHigh
{
	public class CompletedDeliveriesViewModel : ViewModelBase
	{
		public ObservableList<OrderBlockViewModel> OrderBlocks = new ObservableList<OrderBlockViewModel>();

		[Inject]
		private readonly ISiteDeliveryService _siteDeliveryService;

		[Inject]
		private readonly DiContainer _diContainer;

		public void AddOrderBlock(OrderBlockViewModel orderBlock)
		{
			OrderBlocks.Add(orderBlock);
		}

		public void ClearOrderBlocks()
		{
			OrderBlocks.Clear();
		}

		public void SyncWithCompletedOrders()
		{
			foreach (DeliveryOrder completedOrder in _siteDeliveryService.CompletedOrders)
			{
				if (completedOrder.Completed)
				{
					OrderBlockViewModel orderBlockViewModel = _diContainer.Instantiate<OrderBlockViewModel>(new object[1] { completedOrder });
					orderBlockViewModel.IsInProgress = false;
					AddOrderBlock(orderBlockViewModel);
				}
			}
		}
	}
}
