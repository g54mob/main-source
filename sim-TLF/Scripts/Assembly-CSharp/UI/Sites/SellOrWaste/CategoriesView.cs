using System.Collections.Generic;
using Computer.Sites.SellOrWaste;
using Loxodon.Framework.Binding;
using Loxodon.Framework.Observables;
using Loxodon.Framework.Views;
using UnityEngine;
using Zenject;

namespace UI.Sites.SellOrWaste
{
	public class CategoriesView : UIView
	{
		[Header("Links")]
		[SerializeField]
		private CategoryView _categoryViewRes;

		[SerializeField]
		private ShopView _shopView;

		[SerializeField]
		private RightPanelView _rightPanelView;

		[Header("Params")]
		[SerializeField]
		private List<CategoryObjectConfig> _categoeiesConfigs;

		private ObservableList<CategoryViewModel> _categories = new ObservableList<CategoryViewModel>();

		[Inject]
		private DiContainer _diContainer;

		public void CreateBinding()
		{
			this.CreateBindingSet<CategoriesView, CategoriesViewModel>().Build();
		}

		public void PopulateCategories()
		{
			foreach (CategoryObjectConfig categoeiesConfig in _categoeiesConfigs)
			{
				CategoryViewModel categoryViewModel = new CategoryViewModel(categoeiesConfig, _shopView.GetDataContext() as ShopViewModel, _rightPanelView.GetDataContext() as RightPanelViewModel);
				_diContainer.Inject(categoryViewModel);
				CreateCategoryView(categoryViewModel);
			}
		}

		private void CreateCategoryView(CategoryViewModel categoryViewModel)
		{
			CategoryView categoryView = Object.Instantiate(_categoryViewRes, base.transform);
			categoryView.SetDataContext(categoryViewModel);
			categoryView.CreateBinding();
		}
	}
}
