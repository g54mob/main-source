using Computer.Sites.SellOrWaste;
using Loxodon.Framework.Contexts;
using Loxodon.Framework.ViewModels;
using Services.Missions;
using UnityEngine;
using Zenject;

namespace UI.Sites.SellOrWaste
{
	public class ProductViewModel : ViewModelBase
	{
		private Sprite _icon;

		private string _title;

		private float _price;

		private string _assetReferenceID;

		private ApplicationContext _context;

		[Inject]
		private MissionEventBus _missionEventBus;

		protected RightPanelViewModel _rightPanelVM;

		public Sprite Icon
		{
			get
			{
				return _icon;
			}
			internal set
			{
				Set(ref _icon, value, "Icon");
			}
		}

		public string Title
		{
			get
			{
				return _title;
			}
			internal set
			{
				Set(ref _title, value, "Title");
			}
		}

		public float Price
		{
			get
			{
				return _price;
			}
			internal set
			{
				Set(ref _price, value, "Price");
			}
		}

		public string AssetReferenceID => _assetReferenceID;

		public ProductViewModel(ProductObjectConfig productObject, RightPanelViewModel rightPanelViewModel)
		{
			_context = Loxodon.Framework.Contexts.Context.GetApplicationContext();
			_icon = productObject.ProductIcon;
			_title = productObject.ProductName;
			_price = productObject.ProductPrice;
			_assetReferenceID = productObject.AssetReference.AssetGUID;
			_rightPanelVM = rightPanelViewModel;
		}

		public void OnProductClick()
		{
			RightPanelViewModel rightPanelVM = _rightPanelVM;
			rightPanelVM.OpenCart();
			rightPanelVM.cartViewModel.AddProductToCart(new CartProductViewModel(Title, _rightPanelVM.cartViewModel, _assetReferenceID, 1, Price));
			_missionEventBus.Emit("interact", "buyBeer");
		}
	}
}
