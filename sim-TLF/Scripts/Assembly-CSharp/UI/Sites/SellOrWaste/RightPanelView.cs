using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Views;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Sites.SellOrWaste
{
	public class RightPanelView : UIView
	{
		[SerializeField]
		private SponsorsView _sponsorsView;

		[SerializeField]
		private OrderContainerView _orderContainerView;

		[SerializeField]
		private CartView _cartView;

		[SerializeField]
		private Button _cartButton;

		private SponsorsViewModel _sponsorsVM;

		private CartViewModel _cartVM;

		[Inject]
		private DiContainer _diContainer;

		public void SolveDependencies()
		{
			_sponsorsVM = new SponsorsViewModel();
			_cartVM = new CartViewModel(_orderContainerView.GetDataContext() as OrderContainerViewModel);
			_diContainer.Inject(_cartVM);
		}

		public void CreateBinding()
		{
			RightPanelViewModel rightPanelViewModel = new RightPanelViewModel(_sponsorsVM, _cartVM);
			_diContainer.Inject(rightPanelViewModel);
			BindingSet<RightPanelView, RightPanelViewModel> bindingSet = this.CreateBindingSet<RightPanelView, RightPanelViewModel>();
			this.SetDataContext(rightPanelViewModel);
			_cartView.SetDataContext(rightPanelViewModel.cartViewModel);
			_sponsorsView.SetDataContext(rightPanelViewModel.sponsorsViewModel);
			_cartView.CreateBinding();
			_sponsorsView.CreateBinding();
			bindingSet.Bind(_cartButton).For((Button v) => v.onClick).To((RightPanelViewModel vm) => vm.CartButtonClick)
				.OneWay();
			bindingSet.Build();
		}
	}
}
