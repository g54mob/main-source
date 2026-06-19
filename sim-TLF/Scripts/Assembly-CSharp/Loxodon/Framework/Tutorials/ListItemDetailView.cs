using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using UnityEngine;
using UnityEngine.UI;

namespace Loxodon.Framework.Tutorials
{
	public class ListItemDetailView : MonoBehaviour
	{
		public GameObject panel;

		public Text title;

		public Text price;

		public Image image;

		public ListItemViewModel Item
		{
			get
			{
				return (ListItemViewModel)this.GetDataContext();
			}
			set
			{
				this.SetDataContext(value);
			}
		}

		private void Start()
		{
			BindingSet<ListItemDetailView, ListItemViewModel> bindingSet = this.CreateBindingSet<ListItemDetailView, ListItemViewModel>();
			bindingSet.Bind(panel).For((GameObject v) => v.activeSelf).To((ListItemViewModel vm) => vm.IsSelected);
			bindingSet.Bind(title).For((Text v) => v.text).To((ListItemViewModel vm) => vm.Title);
			bindingSet.Bind(image).For((Image v) => v.sprite).To((ListItemViewModel vm) => vm.Icon)
				.WithConversion("spriteConverter")
				.OneWay();
			bindingSet.Bind(price).For((Text v) => v.text).ToExpression((ListItemViewModel vm) => $"${vm.Price:0.00}")
				.OneWay();
			bindingSet.Build();
		}
	}
}
