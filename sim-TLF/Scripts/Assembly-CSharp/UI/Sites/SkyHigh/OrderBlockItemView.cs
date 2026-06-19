using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Views;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Sites.SkyHigh
{
	public class OrderBlockItemView : UIView
	{
		[SerializeField]
		private Image _planeImage;

		[SerializeField]
		private TextMeshProUGUI _nameText;

		[SerializeField]
		private TextMeshProUGUI _quantity;

		public void CreateBinding()
		{
			BindingSet<OrderBlockItemView, OrderBlockItemViewModel> bindingSet = this.CreateBindingSet<OrderBlockItemView, OrderBlockItemViewModel>();
			bindingSet.Bind(_planeImage).For((Image v) => v.color).To((OrderBlockItemViewModel vm) => vm.IndicatorColor)
				.OneWay();
			bindingSet.Bind(_nameText).For((TextMeshProUGUI v) => v.text).To((OrderBlockItemViewModel vm) => vm.ProductName)
				.OneWay();
			bindingSet.Bind(_quantity).For((TextMeshProUGUI v) => v.text).To((OrderBlockItemViewModel vm) => vm.Quantity)
				.OneWay();
			bindingSet.Build();
		}
	}
}
