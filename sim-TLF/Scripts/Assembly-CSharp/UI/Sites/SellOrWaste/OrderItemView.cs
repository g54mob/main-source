using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Sites.SellOrWaste
{
	public class OrderItemView : MonoBehaviour
	{
		[SerializeField]
		private Image _productImage;

		[SerializeField]
		private TextMeshProUGUI _productNameText;

		[SerializeField]
		private TextMeshProUGUI _quantityText;

		public void CreateBinding()
		{
			BindingSet<OrderItemView, OrderItemViewModel> bindingSet = this.CreateBindingSet<OrderItemView, OrderItemViewModel>();
			bindingSet.Bind(_productImage).For((Image v) => v.sprite).To((OrderItemViewModel vm) => vm.ProductImage)
				.OneWay();
			bindingSet.Bind(_productNameText).For((TextMeshProUGUI v) => v.text).To((OrderItemViewModel vm) => vm.ProductName)
				.OneWay();
			bindingSet.Bind(_quantityText).For((TextMeshProUGUI v) => v.text).To((OrderItemViewModel vm) => vm.Quantity)
				.OneWay();
			bindingSet.Build();
		}
	}
}
