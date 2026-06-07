using System.Collections.Generic;
using DV.UIFramework;
using TMPro;
using UnityEngine.UI;

namespace DV.UI
{
	public class SliderSelector : Selector
	{
		public Slider slider;

		protected override void Initialize()
		{
			if (!initialized)
			{
				labelTMPro = base.transform.Find("[texts]/[text label]")?.GetComponent<TextMeshProUGUI>();
				valueTMPro = base.transform.Find("[texts]/[text value] [noloc]")?.GetComponent<TextMeshProUGUI>();
				slider.wholeNumbers = true;
				slider.minValue = 0f;
				slider.maxValue = values.Count - 1;
				slider.value = 0f;
				slider.onValueChanged.AddListener(OnSliderValueChanged);
				base.InteractabilityChanged += OnInteractabilityChanged;
				base.SelectionChanged += OnSelectionChanged;
				initialized = true;
			}
		}

		public override void SetValues(List<string> newValues)
		{
			base.SetValues(newValues);
			slider.minValue = 0f;
			slider.maxValue = values.Count - 1;
			slider.value = base.SelectedIndex;
		}

		public override void SetSelectedIndex(int index, bool fireEvent = true)
		{
			base.SetSelectedIndex(index, fireEvent);
			if (!fireEvent)
			{
				OnSelectionChanged(null, base.SelectedIndex);
			}
		}

		private void OnSelectionChanged(IClickable _, int selectedindex)
		{
			slider.value = selectedindex;
		}

		private void OnInteractabilityChanged(IHoverable _)
		{
			slider.interactable = base.IsInteractable;
		}

		private void OnSliderValueChanged(float value)
		{
			SetSelectedIndex((int)value);
		}
	}
}
