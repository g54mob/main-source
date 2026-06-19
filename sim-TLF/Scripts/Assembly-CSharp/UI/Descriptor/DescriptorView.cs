using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Views;
using TMPro;
using UnityEngine;

namespace UI.Descriptor
{
	public class DescriptorView : UIView
	{
		[SerializeField]
		private TextMeshProUGUI _describerText;

		protected override void Start()
		{
			Bind();
		}

		private void Bind()
		{
			BindingSet<DescriptorView, DescriptorViewModel> bindingSet = this.CreateBindingSet<DescriptorView, DescriptorViewModel>();
			bindingSet.Bind(_describerText).For((TextMeshProUGUI v) => v.text).To((DescriptorViewModel vm) => vm.DescriptorText)
				.OneWay();
			bindingSet.Build();
		}
	}
}
