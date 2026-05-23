using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Bozo.ModularCharacters
{
	public class BlendSlider : MonoBehaviour
	{
		private Slider slider;

		[SerializeField]
		private TMP_Text title;

		[SerializeField]
		private TMP_Text sliderValue;

		[SerializeField]
		private OutfitSystem system;

		[SerializeField]
		private string shape;

		public void Init(OutfitSystem system, string key)
		{
			slider = GetComponentInChildren<Slider>();
			slider.onValueChanged.AddListener(Apply);
			this.system = system;
			title.text = key;
			shape = key;
			float shapeValue = system.GetShapeValue(key);
			slider.value = shapeValue;
		}

		private void OnEnable()
		{
			float shapeValue = system.GetShapeValue(shape);
			slider.value = shapeValue;
		}

		private void UpdateSlider()
		{
		}

		public void Apply(float value)
		{
			system.SetShape(shape, value);
			sliderValue.text = $"{slider.value}%";
		}
	}
}
