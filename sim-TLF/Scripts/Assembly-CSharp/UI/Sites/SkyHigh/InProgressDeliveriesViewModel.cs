using Computer.Sites.Services.Delivery;
using Loxodon.Framework.Observables;
using Loxodon.Framework.ViewModels;
using Zenject;

namespace UI.Sites.SkyHigh
{
	public class InProgressDeliveriesViewModel : ViewModelBase
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

		public void SyncWithOrders()
		{
			foreach (DeliveryOrder activeOrder in _siteDeliveryService.ActiveOrders)
			{
				if (!activeOrder.Completed && activeOrder.Tracked)
				{
					OrderBlockViewModel orderBlock = _diContainer.Instantiate<OrderBlockViewModel>(new object[1] { activeOrder });
					AddOrderBlock(orderBlock);
				}
			}
		}
	}
}
