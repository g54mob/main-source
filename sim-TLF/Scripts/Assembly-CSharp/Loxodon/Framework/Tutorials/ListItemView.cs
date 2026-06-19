using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Views;
using UnityEngine;
using UnityEngine.UI;

namespace Loxodon.Framework.Tutorials
{
	public class ListItemView : UIView
	{
		public Text title;

		public Text price;

		public Image image;

		public GameObject border;

		public Button selectButton;

		public Button clickButton;

		protected override void Start()
		{
			BindingSet<ListItemView, ListItemViewModel> bindingSet = this.CreateBindingSet<ListItemView, ListItemViewModel>();
			bindingSet.Bind(title).For((Text v) => v.text).To((ListItemViewModel vm) => vm.Title)
				.OneWay();
			bindingSet.Bind(image).For((Image v) => v.sprite).To((ListItemViewModel vm) => vm.Icon)
				.WithConversion("spriteConverter")
				.OneWay();
			bindingSet.Bind(price).For((Text v) => v.text).ToExpression((ListItemViewModel vm) => $"${vm.Price:0.00}")
				.OneWay();
			bindingSet.Bind(border).For((GameObject v) => v.activeSelf).To((ListItemViewModel vm) => vm.IsSelected)
				.OneWay();
			bindingSet.Bind(selectButton).For((Button v) => v.onClick).To((ListItemViewModel vm) => vm.SelectCommand)
				.CommandParameter(this.GetDataContext);
			bindingSet.Bind(clickButton).For((Button v) => v.onClick).To((ListItemViewModel vm) => vm.ClickCommand)
				.CommandParameter(this.GetDataContext);
			bindingSet.Build();
		}
	}
}
