using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Interactivity;
using Loxodon.Framework.Views;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Sites.SkyHigh
{
	public class SkyHighView : UIView
	{
		[SerializeField]
		private Button _newOrderButon;

		[SerializeField]
		private Button _jobButton;

		[SerializeField]
		private OrderPopupView _orderPopup;

		[Inject]
		private DiContainer _diContainer;

		protected override void Awake()
		{
			base.Awake();
		}

		protected override void Start()
		{
			BindingSet<SkyHighView, SkyHighViewModel> bindingSet = this.CreateBindingSet<SkyHighView, SkyHighViewModel>();
			SkyHighViewModel skyHighViewModel = new SkyHighViewModel();
			_diContainer.Inject(skyHighViewModel);
			this.SetDataContext(skyHighViewModel);
			bindingSet.Bind(_newOrderButon).For((Button v) => v.onClick).To((SkyHighViewModel vm) => vm.NewOrderCommand)
				.OneWay();
			bindingSet.Bind(_jobButton).For((Button v) => v.onClick).To((SkyHighViewModel vm) => vm.GetJobCommand)
				.OneWay();
			bindingSet.Bind().For((SkyHighView v) => v.OnOpenOrderPopup).To((SkyHighViewModel vm) => vm.OpenOrderPopupRequest);
			bindingSet.Build();
		}

		private void OnOpenOrderPopup(object sender, InteractionEventArgs args)
		{
			_orderPopup.gameObject.SetActive(value: true);
		}
	}
}
