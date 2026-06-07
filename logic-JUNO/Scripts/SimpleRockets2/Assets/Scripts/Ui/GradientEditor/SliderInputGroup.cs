using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Ui.GradientEditor
{
	public class SliderInputGroup : MonoBehaviour
	{
		[SerializeField]
		private TMP_InputField _input;

		[SerializeField]
		private Slider _slider;

		public float Value
		{
			get
			{
				return _slider.value;
			}
			set
			{
				_slider.SetValueWithoutNotify(value);
				_input.SetTextWithoutNotify(value.ToString("0.0000"));
			}
		}

		public event Action<float> OnValueChanged;

		private void Awake()
		{
			Value = 0f;
			_input.onSubmit.AddListener(delegate(string s)
			{
				if (float.TryParse(s, out var result))
				{
					result = (Value = Mathf.Clamp01(result));
					this.OnValueChanged?.Invoke(result);
				}
			});
			_slider.onValueChanged.AddListener(delegate(float f)
			{
				f = Mathf.Clamp01(f);
				Value = f;
				this.OnValueChanged?.Invoke(f);
			});
		}
	}
}
