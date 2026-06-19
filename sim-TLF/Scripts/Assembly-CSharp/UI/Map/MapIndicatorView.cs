using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Views;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Map
{
	public class MapIndicatorView : UIView
	{
		[SerializeField]
		private Image _image;

		[SerializeField]
		private Button _button;

		public void CreateBinding()
		{
			BindingSet<MapIndicatorView, MapIndicatorViewModel> bindingSet = this.CreateBindingSet<MapIndicatorView, MapIndicatorViewModel>();
			bindingSet.Bind(_image).For((Image v) => v.sprite).To((MapIndicatorViewModel vm) => vm.IndicatorSprite)
				.OneWay();
			bindingSet.Bind(_button).For((Button v) => v.onClick).To((MapIndicatorViewModel vm) => vm.OnIndicatorClick)
				.OneWay();
			bindingSet.Build();
		}
	}
}
