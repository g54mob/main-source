using Computer.Sites.Services.Delivery;
using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Interactivity;
using Loxodon.Framework.Views;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Sites.SkyHigh
{
	public class OrderPopupView : UIView
	{
		[SerializeField]
		private Button _orderButton;

		[SerializeField]
		private Button _closeButton;

		[SerializeField]
		private TMP_InputField _deliveryNumberInputField;

		[SerializeField]
		private InProgressDeliveriesView _progressDeliveriesView;

		[Inject]
		private readonly ISiteDeliveryService _deliveryService;

		[Inject]
		private readonly DiContainer _diContainer;

		protected override void Start()
		{
			BindingSet<OrderPopupView, OrderPopupViewModel> bindingSet = this.CreateBindingSet<OrderPopupView, OrderPopupViewModel>();
			OrderPopupViewModel dataContext = _diContainer.Instantiate<OrderPopupViewModel>(new object[1] { _progressDeliveriesView.GetDataContext() as InProgressDeliveriesViewModel });
			this.SetDataContext(dataContext);
			bindingSet.Bind(_orderButton).For((Button v) => v.onClick).To((OrderPopupViewModel vm) => vm.PlaceOrderCommand)
				.OneWay();
			bindingSet.Bind(_closeButton).For((Button v) => v.onClick).To((OrderPopupViewModel vm) => vm.CloseCommand)
				.OneWay();
			bindingSet.Bind(_deliveryNumberInputField).For((TMP_InputField v) => v.text, (TMP_InputField v) => v.onEndEdit).To((OrderPopupViewModel vm) => vm.DeliveryNumber)
				.TwoWay();
			bindingSet.Bind(_deliveryNumberInputField).For((TMP_InputField v) => v.onValueChanged).To<string>((OrderPopupViewModel vm) => vm.OnDeliveryNumberChanged);
			bindingSet.Bind(_deliveryNumberInputField).For((TMP_InputField v) => v.text).To((OrderPopupViewModel vm) => vm.DeliveryNumber)
				.TwoWay();
			bindingSet.Bind(this).For((OrderPopupView v) => v.OnClosePopup).To((OrderPopupViewModel vm) => vm.CloseRequest);
			bindingSet.Build();
		}

		private void OnClosePopup(object sender, InteractionEventArgs args)
		{
			base.gameObject.SetActive(value: false);
		}
	}
}
