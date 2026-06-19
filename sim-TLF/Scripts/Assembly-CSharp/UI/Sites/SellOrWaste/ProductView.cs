using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Views;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Sites.SellOrWaste
{
	public class ProductView : UIView
	{
		[SerializeField]
		private Image _icon;

		[SerializeField]
		private TextMeshProUGUI _title;

		[SerializeField]
		private TextMeshProUGUI _price;

		[SerializeField]
		private Button _button;

		public void CreateBinding()
		{
			BindingSet<ProductView, ProductViewModel> bindingSet = this.CreateBindingSet<ProductView, ProductViewModel>();
			bindingSet.Bind(_icon).For((Image v) => v.sprite).To((ProductViewModel vm) => vm.Icon)
				.OneWay();
			bindingSet.Bind(_title).For((TextMeshProUGUI v) => v.text).To((ProductViewModel vm) => vm.Title)
				.OneWay();
			bindingSet.Bind(_price).For((TextMeshProUGUI v) => v.text).To((ProductViewModel vm) => vm.Price)
				.OneWay();
			bindingSet.Bind(_button).For((Button v) => v.onClick).To((ProductViewModel vm) => vm.OnProductClick)
				.OneWay();
			bindingSet.Build();
		}
	}
}
