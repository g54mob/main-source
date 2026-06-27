using System;
using System.Collections.Generic;
using Restory.Data.Localization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Restory.UI.Views.Shops.Elements
{
	public sealed class GUI_ElementsShopProductsPanelFilterView : MonoBehaviour
	{
		[SerializeField]
		private ToggleButtonGroup deviceCategoriesToggleGroup;

		[SerializeField]
		private TMP_Dropdown modelsDropdown;

		[SerializeField]
		private Toggle sortToggle;

		private readonly List<string> modelsOptionsList = new List<string>();

		private LocalizationSystem localizationSystem;

		public int SelectedDeviceCategoryIndex { get; private set; }

		public int SelectedModelIndex => modelsDropdown.value;

		public bool IsSortToggleOn => sortToggle.isOn;

		public event Action OnSelectedDeviceCategoryChanged;

		public event Action OnSelectedModelChanged;

		public event Action OnSortToggleChanged;

		[Inject]
		private void Construct(LocalizationSystem localizationSystem)
		{
			this.localizationSystem = localizationSystem;
		}

		private void OnEnable()
		{
			sortToggle.onValueChanged.AddListener(ResolveSortToggleChanged);
		}

		private void OnDisable()
		{
			sortToggle.onValueChanged.RemoveListener(ResolveSortToggleChanged);
		}

		public void SetDeviceCategoriesButtons(IEnumerable<ToggleButton> toggleButtons)
		{
			deviceCategoriesToggleGroup.Clear();
			foreach (ToggleButton toggleButton in toggleButtons)
			{
				deviceCategoriesToggleGroup.Add(toggleButton);
				toggleButton.transform.localScale = Vector3.one;
			}
			SelectedDeviceCategoryIndex = Mathf.Clamp(SelectedDeviceCategoryIndex, 0, deviceCategoriesToggleGroup.Value.Length - 1);
			ToggleButtonGroupState value = deviceCategoriesToggleGroup.Value;
			value.ResetAllOptions();
			value[SelectedDeviceCategoryIndex] = true;
			deviceCategoriesToggleGroup.Value = value;
		}

		public void SetModelsOptions(IEnumerable<string> models)
		{
			int value = modelsDropdown.value;
			modelsOptionsList.Clear();
			foreach (string model in models)
			{
				modelsOptionsList.Add(localizationSystem.GetTranslation(model));
			}
			modelsDropdown.ClearOptions();
			modelsDropdown.AddOptions(modelsOptionsList);
			modelsDropdown.value = Mathf.Clamp(value, 0, modelsOptionsList.Count - 1);
		}

		public void SetModelsOptionsVisibility(bool isVisible)
		{
			modelsDropdown.gameObject.SetActive(isVisible);
		}

		public void SetSortToggleVisibility(bool isVisible)
		{
			sortToggle.gameObject.SetActive(isVisible);
		}

		public void Activate()
		{
			deviceCategoriesToggleGroup.ValueChanged += ResolveDeviceCategoriesToggleGroupValueChanged;
			modelsDropdown.onValueChanged.AddListener(ResolveModelSelected);
		}

		public void Deactivate()
		{
			deviceCategoriesToggleGroup.ValueChanged -= ResolveDeviceCategoriesToggleGroupValueChanged;
			modelsDropdown.onValueChanged.RemoveListener(ResolveModelSelected);
		}

		public void SelectCategoryByIndex(int index)
		{
			ToggleButtonGroupState value = deviceCategoriesToggleGroup.Value;
			value.ResetAllOptions();
			value[index] = true;
			deviceCategoriesToggleGroup.Value = value;
		}

		public void ResetSelectedModelToDefault()
		{
			modelsDropdown.SetValueWithoutNotify(0);
		}

		private void ResolveDeviceCategoriesToggleGroupValueChanged(ToggleButtonGroupState index)
		{
			Span<int> activeOptionsIndices = stackalloc int[index.Length];
			Span<int> activeOptions = index.GetActiveOptions(activeOptionsIndices);
			SelectedDeviceCategoryIndex = ((activeOptions.Length == 1) ? activeOptions[0] : (-1));
			this.OnSelectedDeviceCategoryChanged?.Invoke();
		}

		private void ResolveModelSelected(int optionIndex)
		{
			this.OnSelectedModelChanged?.Invoke();
		}

		private void ResolveSortToggleChanged(bool isEnable)
		{
			this.OnSortToggleChanged?.Invoke();
		}
	}
}
