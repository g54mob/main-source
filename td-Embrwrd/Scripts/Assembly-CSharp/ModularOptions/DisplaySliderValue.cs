using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ModularOptions
{
	[AddComponentMenu("Modular Options/Display Slider Value")]
	[RequireComponent(typeof(Slider))]
	public sealed class DisplaySliderValue : MonoBehaviour
	{
		[Tooltip("Text UI to use for displaying the slider value.")]
		public TextMeshProUGUI displayText;

		private Slider slider;

		private ISliderDisplayFormatter formattingOverride;

		private void Awake()
		{
		}

		private void SetDisplayText(float _value)
		{
		}
	}
}
