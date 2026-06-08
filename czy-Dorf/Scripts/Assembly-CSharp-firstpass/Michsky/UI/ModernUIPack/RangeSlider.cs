using TMPro;
using UnityEngine;

namespace Michsky.UI.ModernUIPack
{
	public class RangeSlider : MonoBehaviour
	{
		public int DecimalPlaces;

		public float minValue;

		public float maxValue = 1f;

		public bool useWholeNumbers;

		public bool showLabels = true;

		public RangeMinSlider minSlider;

		public TextMeshProUGUI minSliderLabel;

		public RangeMaxSlider maxSlider;

		public TextMeshProUGUI maxSliderLabel;

		public float CurrentLowerValue => minSlider.value;

		public float CurrentUpperValue => maxSlider.realValue;

		private void Awake()
		{
			if (showLabels)
			{
				minSlider.label = minSliderLabel;
				minSlider.numberFormat = "n" + DecimalPlaces;
				maxSlider.label = maxSliderLabel;
				maxSlider.numberFormat = "n" + DecimalPlaces;
			}
			else
			{
				minSliderLabel.gameObject.SetActive(value: false);
				maxSliderLabel.gameObject.SetActive(value: false);
			}
			minSlider.minValue = minValue;
			minSlider.maxValue = maxValue;
			minSlider.wholeNumbers = useWholeNumbers;
			maxSlider.minValue = minValue;
			maxSlider.maxValue = maxValue;
			maxSlider.wholeNumbers = useWholeNumbers;
		}
	}
}
