using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Contexts;
using Loxodon.Framework.Views;
using UnityEngine;
using UnityEngine.UI;

namespace UI.HUD
{
	public class ToolIconView : UIView
	{
		[SerializeField]
		private Image _toolImage;

		[SerializeField]
		private Image _toolBorder;

		[SerializeField]
		private GameObject _controllsHint;

		private ToolIconViewModel _viewModel;

		protected override void Start()
		{
			_viewModel = Context.GetApplicationContext().GetService<ToolIconViewModel>();
			BindingSet<ToolIconView, ToolIconViewModel> bindingSet = this.CreateBindingSet<ToolIconView, ToolIconViewModel>();
			this.SetDataContext(_viewModel);
			bindingSet.Bind(_toolImage).For((Image v) => v.sprite).To((ToolIconViewModel vm) => vm.CurrentToolSprite)
				.OneWay();
			bindingSet.Bind(this).For((ToolIconView v) => v.Visibility).To((ToolIconViewModel vm) => vm.Enabled)
				.OneWay();
			bindingSet.Build();
		}
	}
}
