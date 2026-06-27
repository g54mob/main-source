using System;
using System.Collections;
using System.Collections.Generic;
using Restory.Data.Equipment;
using Restory.Data.Localization;
using Restory.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Pool;
using UnityEngine.UI;
using Zenject;

namespace Restory.UI.Presenters.DevicePaintingTool
{
	public class GUI_DevicePainterMainParametersPanel : MonoBehaviour, IAxis1DHandler, IEventSystemHandler
	{
		private static int brushSizeAxisID = 98;

		[SerializeField]
		private GUI_PaintingPalettesDropdown palettesSelectionDropdown;

		[SerializeField]
		private Toggle brushTypeToggle;

		[SerializeField]
		private Slider brushSizeSlider;

		[SerializeField]
		private Slider brushOpacitySlider;

		[SerializeField]
		private float sizeKeyboardControlIncrement = 0.05f;

		[SerializeField]
		private float sizeKeyboardControlFirstDelay = 0.5f;

		[SerializeField]
		private float sizeKeyboardControlSubsequentDelays = 0.1f;

		private GUI_RewiredPanelInputModule inputModule;

		private LocalizationSystem localizationSystem;

		private readonly List<PaintingPaletteInfo> selectablePalettes = new List<PaintingPaletteInfo>();

		private PaintingPaletteInfo currentlySelectedPalette;

		private bool isCurrentlySelectedBrushSoftEdged;

		private float currentBrushOpacitySliderNormalizedValue;

		private float currentSizeAxisInputValue;

		private Coroutine sizeInputAxisTrackingCoroutine;

		private float currentBrushSizeSliderValue;

		public float BrushSizeSliderMinValue => brushSizeSlider.minValue;

		public float BrushSizeSliderMaxValue => brushSizeSlider.maxValue;

		public PaintingPaletteInfo CurrentlySelectedPalette
		{
			get
			{
				return currentlySelectedPalette;
			}
			private set
			{
				if ((bool)value && (!currentlySelectedPalette || !(value.ID == currentlySelectedPalette.ID)))
				{
					currentlySelectedPalette = value;
					this.OnPaletteSelectionChanged?.Invoke();
				}
			}
		}

		public bool IsCurrentlySelectedBrushSoftEdged
		{
			get
			{
				return isCurrentlySelectedBrushSoftEdged;
			}
			private set
			{
				if (value != isCurrentlySelectedBrushSoftEdged)
				{
					isCurrentlySelectedBrushSoftEdged = value;
					this.OnBrushTypeChanged?.Invoke();
				}
			}
		}

		public float CurrentBrushSizeSliderValue
		{
			get
			{
				return currentBrushSizeSliderValue;
			}
			private set
			{
				if (!Mathf.Approximately(value, currentBrushSizeSliderValue))
				{
					currentBrushSizeSliderValue = value;
					this.OnBrushSizeChanged?.Invoke();
				}
			}
		}

		public float CurrentBrushOpacitySliderNormalizedValue
		{
			get
			{
				return currentBrushOpacitySliderNormalizedValue;
			}
			private set
			{
				if (!Mathf.Approximately(value, currentBrushOpacitySliderNormalizedValue))
				{
					currentBrushOpacitySliderNormalizedValue = value;
					this.OnBrushOpacityChanged?.Invoke();
				}
			}
		}

		public event Action OnPaletteSelectionMenuOpened;

		public event Action OnPaletteSelectionChanged;

		public event Action OnBrushSizeChanged;

		public event Action OnBrushOpacityChanged;

		public event Action OnBrushTypeChanged;

		[Inject]
		private void Construct(GUI_RewiredPanelInputModule inputModule, LocalizationSystem localizationSystem)
		{
			this.localizationSystem = localizationSystem;
			this.inputModule = inputModule;
		}

		private void Awake()
		{
			palettesSelectionDropdown.ClearOptions();
		}

		private void OnDisable()
		{
			if (inputModule.MonoShellExists())
			{
				inputModule.RemoveSelectedPanel(base.gameObject);
			}
			if (sizeInputAxisTrackingCoroutine != null)
			{
				StopCoroutine(sizeInputAxisTrackingCoroutine);
				sizeInputAxisTrackingCoroutine = null;
			}
			palettesSelectionDropdown.onValueChanged.RemoveListener(ResolvePalettesDropdownSelectedValueChanged);
			palettesSelectionDropdown.OnDropdownMenuOpen -= ResolvePalettesSelectionMenuOpened;
			brushTypeToggle.onValueChanged.RemoveListener(ResolveBrushTypeToggleValueChanged);
			brushSizeSlider.onValueChanged.RemoveListener(ResolveBrushSizeSliderValueChanged);
			brushOpacitySlider.onValueChanged.RemoveListener(ResolveBrushOpacitySliderValueChanged);
		}

		public void Show()
		{
			inputModule.AddSelectedPanel(base.gameObject);
			palettesSelectionDropdown.onValueChanged.AddListener(ResolvePalettesDropdownSelectedValueChanged);
			palettesSelectionDropdown.OnDropdownMenuOpen += ResolvePalettesSelectionMenuOpened;
			brushTypeToggle.onValueChanged.AddListener(ResolveBrushTypeToggleValueChanged);
			brushSizeSlider.onValueChanged.AddListener(ResolveBrushSizeSliderValueChanged);
			brushOpacitySlider.onValueChanged.AddListener(ResolveBrushOpacitySliderValueChanged);
		}

		public void Hide()
		{
			inputModule.RemoveSelectedPanel(base.gameObject);
			if (sizeInputAxisTrackingCoroutine != null)
			{
				StopCoroutine(sizeInputAxisTrackingCoroutine);
				sizeInputAxisTrackingCoroutine = null;
			}
			palettesSelectionDropdown.Hide();
			palettesSelectionDropdown.onValueChanged.RemoveListener(ResolvePalettesDropdownSelectedValueChanged);
			palettesSelectionDropdown.OnDropdownMenuOpen -= ResolvePalettesSelectionMenuOpened;
			brushTypeToggle.onValueChanged.RemoveListener(ResolveBrushTypeToggleValueChanged);
			brushSizeSlider.onValueChanged.RemoveListener(ResolveBrushSizeSliderValueChanged);
			brushOpacitySlider.onValueChanged.RemoveListener(ResolveBrushOpacitySliderValueChanged);
		}

		private void ResolveBrushTypeToggleValueChanged(bool newValue)
		{
			IsCurrentlySelectedBrushSoftEdged = newValue;
		}

		private void ResolveBrushSizeSliderValueChanged(float newValue)
		{
			CurrentBrushSizeSliderValue = brushSizeSlider.value;
		}

		private void ResolveBrushOpacitySliderValueChanged(float newValue)
		{
			CurrentBrushOpacitySliderNormalizedValue = brushOpacitySlider.normalizedValue;
		}

		private void ResolvePalettesDropdownSelectedValueChanged(int selectedPaletteIndex)
		{
			CurrentlySelectedPalette = selectablePalettes[selectedPaletteIndex];
		}

		private void ResolvePalettesSelectionMenuOpened()
		{
			this.OnPaletteSelectionMenuOpened?.Invoke();
		}

		public void AddPalettesToDropDown(IEnumerable<PaintingPaletteInfo> palettes)
		{
			palettesSelectionDropdown.ClearOptions();
			List<TMP_Dropdown.OptionData> value;
			using (CollectionPool<List<TMP_Dropdown.OptionData>, TMP_Dropdown.OptionData>.Get(out value))
			{
				foreach (PaintingPaletteInfo palette in palettes)
				{
					if (!palette)
					{
						continue;
					}
					value.Add(new GUI_PaintingPalettesDropdownOptionData(localizationSystem.GetTranslation(palette.NameLocalizationKey), palette.Colors));
					bool flag = false;
					foreach (PaintingPaletteInfo selectablePalette in selectablePalettes)
					{
						if (selectablePalette.ID == palette.ID)
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						selectablePalettes.Add(palette);
					}
				}
				palettesSelectionDropdown.AddOptions(value);
			}
		}

		public void RestoreValues(bool shouldBrushBeSoftEdged, float size, float opacity, PaintingPaletteInfo palette)
		{
			if (!palette)
			{
				Debug.LogError("[GUI_DevicePainterMainParametersPanel] tried to restore its values, but the supplied palette was NULL!");
				return;
			}
			isCurrentlySelectedBrushSoftEdged = shouldBrushBeSoftEdged;
			brushTypeToggle.isOn = shouldBrushBeSoftEdged;
			brushSizeSlider.normalizedValue = size;
			currentBrushSizeSliderValue = brushSizeSlider.value;
			currentBrushOpacitySliderNormalizedValue = opacity;
			brushOpacitySlider.normalizedValue = opacity;
			for (int i = 0; i < selectablePalettes.Count; i++)
			{
				if (selectablePalettes[i].ID == palette.ID)
				{
					palettesSelectionDropdown.value = i;
					currentlySelectedPalette = palette;
					break;
				}
			}
		}

		public void OnAxis(Axis1DEventData eventData)
		{
			if (eventData.ActionId != brushSizeAxisID)
			{
				return;
			}
			currentSizeAxisInputValue = eventData.AxisValue;
			if (currentSizeAxisInputValue == 0f)
			{
				if (sizeInputAxisTrackingCoroutine != null)
				{
					StopCoroutine(sizeInputAxisTrackingCoroutine);
					sizeInputAxisTrackingCoroutine = null;
				}
			}
			else if (sizeInputAxisTrackingCoroutine == null)
			{
				sizeInputAxisTrackingCoroutine = StartCoroutine(SizeInputAxisTrackingCoroutine());
			}
		}

		private IEnumerator SizeInputAxisTrackingCoroutine()
		{
			brushSizeSlider.normalizedValue += currentSizeAxisInputValue * sizeKeyboardControlIncrement;
			yield return new WaitForSeconds(sizeKeyboardControlFirstDelay);
			while (sizeInputAxisTrackingCoroutine != null)
			{
				brushSizeSlider.normalizedValue += currentSizeAxisInputValue * sizeKeyboardControlIncrement;
				yield return new WaitForSeconds(sizeKeyboardControlSubsequentDelays);
			}
		}
	}
}
