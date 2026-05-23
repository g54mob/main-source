using Data.FactoryFloor.Resources;
using Data.Operator;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.Menus
{
	public class ProductionGraphFilterToggle : MonoBehaviour
	{
		[SerializeField]
		private Toggle _toggle;

		[SerializeField]
		private ProductionGraphMenu _menu;

		[SerializeField]
		private FactoryObjectData _data;

		[SerializeField]
		private ResourceDataSO _resourceData;

		private void Start()
		{
			_menu.OnFilterModeChanged += HandleMenuFilterModeChanged;
			_toggle.onValueChanged.AddListener(OnValueChanged);
			if (_toggle.isOn)
			{
				HandleMenuFilterModeChanged();
			}
		}

		private void HandleMenuFilterModeChanged()
		{
			OnValueChanged(_toggle.isOn);
		}

		private void OnDestroy()
		{
			_menu.OnFilterModeChanged -= HandleMenuFilterModeChanged;
			_toggle.onValueChanged.RemoveListener(OnValueChanged);
		}

		private void OnValueChanged(bool pEnabled)
		{
			if (_resourceData != null)
			{
				if (_menu.IsFilteringByDelivered)
				{
					_menu.SetFilterDeliveredEnabled(_resourceData.ID, pEnabled);
				}
				else
				{
					_menu.SetFilterProducedEnabled(_resourceData.ID, pEnabled);
				}
			}
		}
	}
}
