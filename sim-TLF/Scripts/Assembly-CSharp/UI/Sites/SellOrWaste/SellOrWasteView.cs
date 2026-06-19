using Computer.Sites.Services.Delivery;
using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Contexts;
using Loxodon.Framework.Views;
using Services;
using TMPro;
using UnityEngine;
using Zenject;

namespace UI.Sites.SellOrWaste
{
	public class SellOrWasteView : UIView
	{
		[Header("Links")]
		[SerializeField]
		private CategoriesView _categoriesView;

		[SerializeField]
		private ShopView _shopView;

		[SerializeField]
		private OrderContainerView _orderContainerView;

		[SerializeField]
		private RightPanelView _rightPanelView;

		[SerializeField]
		private TextMeshProUGUI _balanceText;

		private ApplicationContext context;

		[Inject]
		protected ISiteDeliveryService _siteDeliveryService;

		[Inject]
		protected IMoneyService _moneyService;

		[Inject]
		protected DiContainer _diContainer;

		protected override void Awake()
		{
			base.Awake();
			context = Loxodon.Framework.Contexts.Context.GetApplicationContext();
		}

		protected override void Start()
		{
			BindingSet<SellOrWasteView, SellOrWasteViewModel> bindingSet = this.CreateBindingSet<SellOrWasteView, SellOrWasteViewModel>();
			SellOrWasteViewModel dataContext = new SellOrWasteViewModel();
			this.SetDataContext(dataContext);
			bindingSet.Build();
			OrderContainerViewModel dataContext2 = _diContainer.Instantiate<OrderContainerViewModel>();
			_orderContainerView.SetDataContext(dataContext2);
			_orderContainerView.CreateBinding();
			_rightPanelView.SolveDependencies();
			_rightPanelView.CreateBinding();
			ShopViewModel dataContext3 = new ShopViewModel();
			_shopView.SetDataContext(dataContext3);
			_shopView.CreateBinding();
			CategoriesViewModel dataContext4 = new CategoriesViewModel();
			_categoriesView.SetDataContext(dataContext4);
			_categoriesView.CreateBinding();
			_categoriesView.PopulateCategories();
		}

		protected override void OnEnable()
		{
			_balanceText.text = $"Balance: {_moneyService.CurrencyBalance.FlyCoinsBalance} SkyCoins";
		}
	}
}
