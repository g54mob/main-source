using System;
using System.Collections.Generic;
using UnityEngine;

namespace Restory.UI.Views.Shops.Devices
{
	public sealed class GUI_DeviceShopFilterView : MonoBehaviour
	{
		[SerializeField]
		private ToggleButtonGroup deviceCategoriesToggleGroup;

		public int SelectedDeviceCategoryIndex { get; private set; }

		public event Action OnSelectedDeviceCategoryChanged;

		public void SetDeviceCategoriesButtons(IEnumerable<ToggleButton> toggleButtons)
		{
			deviceCategoriesToggleGroup.Clear();
			foreach (ToggleButton toggleButton in toggleButtons)
			{
				deviceCategoriesToggleGroup.Add(toggleButton);
			}
			SelectedDeviceCategoryIndex = Mathf.Clamp(SelectedDeviceCategoryIndex, 0, deviceCategoriesToggleGroup.Value.Length - 1);
			ToggleButtonGroupState value = deviceCategoriesToggleGroup.Value;
			value.ResetAllOptions();
			value[SelectedDeviceCategoryIndex] = true;
			deviceCategoriesToggleGroup.Value = value;
		}

		public void Activate()
		{
			deviceCategoriesToggleGroup.ValueChanged += ResolveDeviceCategoriesToggleGroupValueChanged;
		}

		public void Deactivate()
		{
			deviceCategoriesToggleGroup.ValueChanged -= ResolveDeviceCategoriesToggleGroupValueChanged;
		}

		private void ResolveDeviceCategoriesToggleGroupValueChanged(ToggleButtonGroupState index)
		{
			Span<int> activeOptionsIndices = stackalloc int[index.Length];
			Span<int> activeOptions = index.GetActiveOptions(activeOptionsIndices);
			SelectedDeviceCategoryIndex = ((activeOptions.Length == 1) ? activeOptions[0] : (-1));
			this.OnSelectedDeviceCategoryChanged?.Invoke();
		}
	}
}
