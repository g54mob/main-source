using Computer.Sites.SellOrWaste;
using Loxodon.Framework.Contexts;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using Zenject;

namespace UI.Sites.SellOrWaste
{
	public class CategoryViewModel : ViewModelBase
	{
		private Sprite _icon;

		private string _title;

		private readonly CategoryObjectConfig _categoryConfig;

		private readonly ShopViewModel _shopViewModel;

		[Inject]
		private DiContainer _diContainer;

		private readonly RightPanelViewModel _rightPanelVM;

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

		public CategoryViewModel(CategoryObjectConfig categoryObjectConfig, ShopViewModel shopVM, RightPanelViewModel rightPanelVM)
		{
			Loxodon.Framework.Contexts.Context.GetApplicationContext();
			Icon = categoryObjectConfig.CategoryIcon;
			Title = categoryObjectConfig.CategoryName;
			_categoryConfig = categoryObjectConfig;
			_shopViewModel = shopVM;
			_rightPanelVM = rightPanelVM;
		}

		public void CategoryClicked()
		{
			_shopViewModel.Products.Clear();
			foreach (ProductObjectConfig product in _categoryConfig.Products)
			{
				ProductViewModel productViewModel = new ProductViewModel(product, _rightPanelVM);
				_diContainer.Inject(productViewModel);
				_shopViewModel.AddProduct(productViewModel);
			}
			_shopViewModel.Active = true;
		}
	}
}
