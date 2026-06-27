using System;
using System.Collections.Generic;
using UnityEngine;

namespace Restory.UI.Views.Shops.HomeDepot
{
	public sealed class GUI_DecorShopProductsPanelFilterView : MonoBehaviour
	{
		[SerializeField]
		private ToggleButtonGroup categoriesToggleGroup;

		public int SelectedCategoryIndex { get; private set; }

		public event Action OnSelectedCategoryChanged;

		public void SetCategoryButtons(IEnumerable<ToggleButton> toggleButtons)
		{
			categoriesToggleGroup.Clear();
			foreach (ToggleButton toggleButton in toggleButtons)
			{
				categoriesToggleGroup.Add(toggleButton);
			}
			SelectedCategoryIndex = Mathf.Clamp(SelectedCategoryIndex, 0, categoriesToggleGroup.Value.Length - 1);
			ToggleButtonGroupState value = categoriesToggleGroup.Value;
			value.ResetAllOptions();
			value[SelectedCategoryIndex] = true;
			categoriesToggleGroup.Value = value;
		}

		public void Activate()
		{
			categoriesToggleGroup.ValueChanged += ResolveDeviceCategoriesToggleGroupValueChanged;
		}

		public void Deactivate()
		{
			categoriesToggleGroup.ValueChanged -= ResolveDeviceCategoriesToggleGroupValueChanged;
		}

		private void ResolveDeviceCategoriesToggleGroupValueChanged(ToggleButtonGroupState index)
		{
			Span<int> activeOptionsIndices = stackalloc int[index.Length];
			Span<int> activeOptions = index.GetActiveOptions(activeOptionsIndices);
			SelectedCategoryIndex = ((activeOptions.Length == 1) ? activeOptions[0] : (-1));
			this.OnSelectedCategoryChanged?.Invoke();
		}
	}
}
