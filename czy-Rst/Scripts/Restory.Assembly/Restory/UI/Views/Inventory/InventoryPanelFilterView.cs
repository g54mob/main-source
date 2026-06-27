using System;
using System.Collections.Generic;
using Restory.Data.Localization;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Restory.UI.Views.Inventory
{
	public sealed class InventoryPanelFilterView : UIBehaviour
	{
		[SerializeField]
		private ToggleButtonGroup deviceCategoriesToggleGroup;

		[SerializeField]
		private ToggleButton deviceCategoryTogglePrefab;

		[SerializeField]
		private TMP_Dropdown modelsDropdown;

		[SerializeField]
		private Toggle sortToggle;

		private readonly List<string> models = new List<string>();

		private readonly List<DeviceCategory> deviceCategories = new List<DeviceCategory>();

		private readonly List<Button> deviceCategoriesButtons = new List<Button>();

		private LocalizationSystem localizationSystem;

		public bool Visible
		{
			get
			{
				return base.gameObject.activeSelf;
			}
			set
			{
				base.gameObject.SetActive(value);
			}
		}

		public List<DeviceCategory> DeviceCategories
		{
			get
			{
				return deviceCategories;
			}
			set
			{
				deviceCategories.Clear();
				deviceCategories.AddRange(value);
				deviceCategoriesToggleGroup.Clear();
				foreach (Button deviceCategoriesButton in deviceCategoriesButtons)
				{
					UnityEngine.Object.Destroy(deviceCategoriesButton);
				}
				deviceCategoriesButtons.Clear();
				for (int i = 0; i < deviceCategories.Count; i++)
				{
					ToggleButton toggleButton = UnityEngine.Object.Instantiate(deviceCategoryTogglePrefab);
					toggleButton.transform.Find("Icon").GetComponent<Image>().overrideSprite = deviceCategories[i].Icon;
					deviceCategoriesButtons.Add(toggleButton);
					deviceCategoriesToggleGroup.Add(toggleButton);
				}
			}
		}

		public int SelectedDeviceCategoryIndex
		{
			get
			{
				ToggleButtonGroupState value = deviceCategoriesToggleGroup.Value;
				Span<int> activeOptionsIndices = stackalloc int[value.Length];
				value = deviceCategoriesToggleGroup.Value;
				Span<int> activeOptions = value.GetActiveOptions(activeOptionsIndices);
				if (activeOptions.Length != 1)
				{
					return -1;
				}
				return activeOptions[0];
			}
			set
			{
				ToggleButtonGroupState value2 = deviceCategoriesToggleGroup.Value;
				value2.ResetAllOptions();
				if (value > 0 && value < value2.Length)
				{
					value2[value] = true;
				}
				deviceCategoriesToggleGroup.Value = value2;
			}
		}

		public List<string> Models
		{
			set
			{
				models.Clear();
				foreach (string item in value)
				{
					models.Add(localizationSystem.GetTranslation(item));
				}
				modelsDropdown.ClearOptions();
				modelsDropdown.AddOptions(models);
			}
		}

		public int SelectedModelIndex
		{
			get
			{
				return modelsDropdown.value;
			}
			set
			{
				modelsDropdown.value = value;
			}
		}

		public bool SortState
		{
			get
			{
				return sortToggle.isOn;
			}
			set
			{
				sortToggle.isOn = value;
			}
		}

		public event Action<InventoryPanelFilterView, int> SelectedCategoryChanged;

		public event Action<InventoryPanelFilterView, int> SelectedModelChanged;

		public event Action<InventoryPanelFilterView, bool> SortChanged;

		[Inject]
		private void Construct(LocalizationSystem localizationSystem)
		{
			this.localizationSystem = localizationSystem;
		}

		protected override void OnEnable()
		{
			sortToggle.onValueChanged.AddListener(OnSortChanged);
			deviceCategoriesToggleGroup.ValueChanged += OnDeviceSelected;
			modelsDropdown.onValueChanged.AddListener(OnModelSelected);
		}

		protected override void OnDisable()
		{
			sortToggle.onValueChanged.RemoveListener(OnSortChanged);
			deviceCategoriesToggleGroup.ValueChanged -= OnDeviceSelected;
			modelsDropdown.onValueChanged.RemoveListener(OnModelSelected);
		}

		public void ChangeInteractivity(bool isInteractable)
		{
			foreach (Button deviceCategoriesButton in deviceCategoriesButtons)
			{
				deviceCategoriesButton.interactable = isInteractable;
			}
			modelsDropdown.interactable = isInteractable;
		}

		private void OnDeviceSelected(ToggleButtonGroupState index)
		{
			Span<int> activeOptionsIndices = stackalloc int[index.Length];
			Span<int> activeOptions = index.GetActiveOptions(activeOptionsIndices);
			int arg = ((activeOptions.Length == 1) ? activeOptions[0] : (-1));
			this.SelectedCategoryChanged?.Invoke(this, arg);
		}

		private void OnModelSelected(int index)
		{
			this.SelectedModelChanged?.Invoke(this, index);
		}

		private void OnSortChanged(bool isOn)
		{
			this.SortChanged?.Invoke(this, isOn);
		}

		public void Clear()
		{
			this.SelectedCategoryChanged = null;
			this.SelectedModelChanged = null;
			this.SortChanged = null;
			foreach (Button deviceCategoriesButton in deviceCategoriesButtons)
			{
				UnityEngine.Object.Destroy(deviceCategoriesButton);
			}
			deviceCategoriesButtons.Clear();
			deviceCategories.Clear();
			deviceCategoriesToggleGroup.Clear();
			modelsDropdown.ClearOptions();
			sortToggle.isOn = false;
		}
	}
}
