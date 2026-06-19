using System;
using DG.Tweening;
using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Observables;
using Loxodon.Framework.Views;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Craft
{
	public class CraftProgressIndicatorView : UIView
	{
		[SerializeField]
		private Image _image;

		[SerializeField]
		private Color _activeColor;

		[SerializeField]
		private Color _inactiveColor;

		private ObservableProperty<bool> _indicatorActive = new ObservableProperty<bool>();

		public void CreateBinding(CraftProgressIndicatorViewModel vm)
		{
			_indicatorActive.ValueChanged += ActiveValueChanged;
			BindingSet<CraftProgressIndicatorView, CraftProgressIndicatorViewModel> bindingSet = this.CreateBindingSet<CraftProgressIndicatorView, CraftProgressIndicatorViewModel>();
			this.SetDataContext(vm);
			bindingSet.Bind(this).For((CraftProgressIndicatorView v) => v._indicatorActive).To((CraftProgressIndicatorViewModel craftProgressIndicatorViewModel) => craftProgressIndicatorViewModel.IndicatorActive)
				.OneWay();
			bindingSet.Build();
		}

		private void ActiveValueChanged(object sender, EventArgs e)
		{
			_image.DOComplete();
			if (_indicatorActive.Value)
			{
				_image.DOColor(_activeColor, 0.2f);
			}
			else
			{
				_image.DOColor(_inactiveColor, 0.2f);
			}
		}
	}
}
