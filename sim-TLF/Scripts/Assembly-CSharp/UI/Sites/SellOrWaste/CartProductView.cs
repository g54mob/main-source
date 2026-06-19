using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Interactivity;
using Loxodon.Framework.Views;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Sites.SellOrWaste
{
	public class CartProductView : UIView
	{
		[SerializeField]
		private Button _plusButton;

		[SerializeField]
		private Button _minusButton;

		[SerializeField]
		private Button _removeButton;

		[SerializeField]
		private TextMeshProUGUI _productName;

		[SerializeField]
		private TextMeshProUGUI _productQuantity;

		public void CreateBinding()
		{
			BindingSet<CartProductView, CartProductViewModel> bindingSet = this.CreateBindingSet<CartProductView, CartProductViewModel>();
			bindingSet.Bind(_productName).For((TextMeshProUGUI v) => v.text).To((CartProductViewModel vm) => vm.ProductName)
				.OneWay();
			bindingSet.Bind(_productQuantity).For((TextMeshProUGUI v) => v.text).To((CartProductViewModel vm) => vm.ProductQuantity)
				.OneWay();
			bindingSet.Bind(_plusButton).For((Button v) => v.onClick).To((CartProductViewModel vm) => vm.IncreaseQuantityCommand);
			bindingSet.Bind(_minusButton).For((Button v) => v.onClick).To((CartProductViewModel vm) => vm.DecreaseQuantityCommand);
			bindingSet.Bind(_removeButton).For((Button v) => v.onClick).To((CartProductViewModel vm) => vm.RemoveProductCommand);
			bindingSet.Bind().For((CartProductView v) => v.RemoveThisObject).To((CartProductViewModel vm) => vm.RemoveProductRequest);
			bindingSet.Build();
		}

		public void RemoveThisObject(object sender, InteractionEventArgs args)
		{
			Object.Destroy(base.gameObject);
		}
	}
}
