using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Views;

namespace UI.Sites.SellOrWaste
{
	public class SponsorsView : UIView
	{
		public void CreateBinding()
		{
			BindingSet<SponsorsView, SponsorsViewModel> bindingSet = this.CreateBindingSet<SponsorsView, SponsorsViewModel>();
			bindingSet.Bind(this).For((SponsorsView v) => v.Visibility).To((SponsorsViewModel vm) => vm.Active)
				.OneWay();
			bindingSet.Build();
		}
	}
}
