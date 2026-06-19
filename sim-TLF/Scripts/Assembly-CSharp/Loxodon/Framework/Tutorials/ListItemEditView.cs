using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Views;
using UnityEngine.UI;

namespace Loxodon.Framework.Tutorials
{
	public class ListItemEditView : UIView
	{
		public Text title;

		public Text price;

		public Slider priceSlider;

		public Button changeIcon;

		public Image image;

		public Button submit;

		public Button cancel;

		public ListItemEditViewModel ViewModel
		{
			get
			{
				return (ListItemEditViewModel)this.GetDataContext();
			}
			set
			{
				this.SetDataContext(value);
			}
		}

		protected override void Start()
		{
			BindingSet<ListItemEditView, ListItemEditViewModel> bindingSet = this.CreateBindingSet<ListItemEditView, ListItemEditViewModel>();
			bindingSet.Bind(title).For((Text v) => v.text).To((ListItemEditViewModel vm) => vm.Title);
			bindingSet.Bind(price).For((Text v) => v.text).ToExpression((ListItemEditViewModel vm) => $"${vm.Price:0.00}")
				.OneWay();
			bindingSet.Bind(priceSlider).For((Slider v) => v.value, (Slider v) => v.onValueChanged).To((ListItemEditViewModel vm) => vm.Price)
				.TwoWay();
			bindingSet.Bind(image).For((Image v) => v.sprite).To((ListItemEditViewModel vm) => vm.Icon)
				.WithConversion("spriteConverter")
				.OneWay();
			bindingSet.Bind(changeIcon).For((Button v) => v.onClick).To((ListItemEditViewModel vm) => vm.OnChangeIcon);
			bindingSet.Build();
			cancel.onClick.AddListener(Cancel);
			submit.onClick.AddListener(Submit);
		}

		private void Cancel()
		{
			ViewModel.Cancelled = true;
			base.gameObject.SetActive(value: false);
			this.SetDataContext(null);
		}

		private void Submit()
		{
			ViewModel.Cancelled = false;
			base.gameObject.SetActive(value: false);
			this.SetDataContext(null);
		}
	}
}
