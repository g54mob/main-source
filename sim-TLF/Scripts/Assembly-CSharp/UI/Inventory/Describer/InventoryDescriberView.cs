using System;
using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Contexts;
using Loxodon.Framework.Observables;
using Loxodon.Framework.Views;
using TMPro;
using UnityEngine;

namespace UI.Inventory.Describer
{
	public class InventoryDescriberView : UIView
	{
		[SerializeField]
		private CanvasGroup _describerGroup;

		[SerializeField]
		private TextMeshProUGUI _describerText;

		[SerializeField]
		private CanvasGroup _useToolTipGroup;

		[SerializeField]
		private Vector2 _offset = new Vector2(0f, 0f);

		[SerializeField]
		private Vector2 _windowOffset = new Vector2(0f, 0f);

		private InventoryDescriberViewModel _viewModel;

		private Vector2 _anchoredPos = new Vector2(0f, 0f);

		private ObservableProperty<bool> _enabledUseTooltip = new ObservableProperty<bool>(value: false);

		protected override void Start()
		{
			BindingSet<InventoryDescriberView, InventoryDescriberViewModel> bindingSet = this.CreateBindingSet<InventoryDescriberView, InventoryDescriberViewModel>();
			_viewModel = Context.GetApplicationContext().GetService<InventoryDescriberViewModel>();
			this.SetDataContext(_viewModel);
			bindingSet.Bind(_describerText).For((TextMeshProUGUI v) => v.text).To((InventoryDescriberViewModel vm) => vm.InfoText)
				.OneWay();
			bindingSet.Build();
			_viewModel.Enabled.ValueChanged += EnabledValueChanged;
		}

		private void Update()
		{
			(_describerGroup.transform as RectTransform).anchoredPosition = _anchoredPos + _offset + _windowOffset;
		}

		private void EnabledValueChanged(object sender, EventArgs e)
		{
			Debug.Log("Value CHanged");
			UpdateVisibility();
		}

		private void UpdateVisibility()
		{
			_describerGroup.alpha = (_viewModel.Enabled.Value ? 1 : 0);
			_describerGroup.blocksRaycasts = _viewModel.Enabled.Value;
		}
	}
}
