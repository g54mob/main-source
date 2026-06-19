using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Views;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Sites.SellOrWaste
{
	public class CategoryView : UIView
	{
		[SerializeField]
		private Image _icon;

		[SerializeField]
		private TextMeshProUGUI _title;

		[SerializeField]
		private Button _button;

		public void CreateBinding()
		{
			BindingSet<CategoryView, CategoryViewModel> bindingSet = this.CreateBindingSet<CategoryView, CategoryViewModel>();
			bindingSet.Bind(_icon).For((Image v) => v.sprite).To((CategoryViewModel vm) => vm.Icon)
				.OneWay();
			bindingSet.Bind(_title).For((TextMeshProUGUI v) => v.text).To((CategoryViewModel vm) => vm.Title)
				.OneWay();
			bindingSet.Bind(_button).For((Button v) => v.onClick).To((CategoryViewModel vm) => vm.CategoryClicked)
				.OneWay();
			bindingSet.Build();
		}
	}
}
