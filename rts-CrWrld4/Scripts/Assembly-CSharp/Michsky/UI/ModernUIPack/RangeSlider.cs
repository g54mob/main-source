using TMPro;
using UnityEngine;

namespace Michsky.UI.ModernUIPack
{
	public class RangeSlider : MonoBehaviour
	{
		public int DecimalPlaces;

		public float minValue;

		public float maxValue;

		public bool useWholeNumbers;

		public bool showLabels;

		public RangeMinSlider minSlider;

		public TextMeshProUGUI minSliderLabel;

		public RangeMaxSlider maxSlider;

		public TextMeshProUGUI maxSliderLabel;

		public float CurrentLowerValue => 0f;

		public float CurrentUpperValue => 0f;

		private void Awake()
		{
		}
	}
}
