using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MoreMountains.Feel
{
	[AddComponentMenu("")]
	public class FeelSpringsDemoSlider : MonoBehaviour
	{
		[Header("Bindings")]
		public Slider TargetSlider;

		public TMP_Text ValueText;

		public float value => TargetSlider.value;

		public void UpdateText()
		{
			ValueText.text = TargetSlider.value.ToString("F2");
		}
	}
}
