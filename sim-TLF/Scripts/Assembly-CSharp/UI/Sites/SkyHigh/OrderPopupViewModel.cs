using Computer.Sites.Services.Delivery;
using Loxodon.Framework.Interactivity;
using Loxodon.Framework.ViewModels;
using Services.Missions;
using Zenject;

namespace UI.Sites.SkyHigh
{
	internal class OrderPopupViewModel : ViewModelBase
	{
		private string _deliveryNumber;

		private InteractionRequest _interactionRequest = new InteractionRequest();

		private readonly InProgressDeliveriesViewModel _inProgressDeliveriesViewModel;

		[Inject]
		private readonly ISiteDeliveryService _deliveryService;

		[Inject]
		private readonly MissionEventBus _missionEventBus;

		[Inject]
		private readonly DiContainer _diContainer;

		public InteractionRequest CloseRequest => _interactionRequest;

		public string DeliveryNumber
		{
			get
			{
				return _deliveryNumber;
			}
			set
			{
				Set(ref _deliveryNumber, value, "DeliveryNumber");
			}
		}

		public OrderPopupViewModel(InProgressDeliveriesViewModel inProgressDeliveriesViewModel)
		{
			_inProgressDeliveriesViewModel = inProgressDeliveriesViewModel;
		}

		internal void OnDeliveryNumberChanged(string value)
		{
			DeliveryNumber = value;
		}

		public void CloseCommand()
		{
			CloseRequest?.Raise();
		}

		public void PlaceOrderCommand()
		{
			DeliveryOrder deliveryOrder = _deliveryService.ActiveOrders.Find((DeliveryOrder o) => o.OrderId == DeliveryNumber);
			if (deliveryOrder != null)
			{
				OrderBlockViewModel orderBlock = _diContainer.Instantiate<OrderBlockViewModel>(new object[1] { deliveryOrder });
				deliveryOrder.Tracked = true;
				_inProgressDeliveriesViewModel.AddOrderBlock(orderBlock);
				_missionEventBus.Emit("interact", "typeOrderId");
				CloseCommand();
			}
		}
	}
}
