using CTS.Core;
using CTS.UI;
using TMPro;
using UnityEngine;

namespace CTS
{
	public abstract class UI_SandboxSlider<TObject, TValue> : UI_SandboxSetting<TObject, TValue> where TObject : ScriptableObject
	{
		[InjectScope(EGetScope.Children)]
		[SerializeField]
		[Inject(false)]
		private CTSSlider _slider;

		[SerializeField]
		[Inject(false)]
		private TMP_Text _valueTextContainer;

		[SerializeField]
		private string _stringFormat = "{0}";

		protected abstract bool IsInteger { get; }

		protected override void Start()
		{
			base.Start();
			_slider.wholeNumbers = IsInteger;
			OnSliderValueChanged(_slider.value);
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			_slider.onValueChanged.AddListener(OnSliderValueChanged);
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			_slider.onValueChanged.RemoveListener(OnSliderValueChanged);
		}

		protected abstract void OnSliderValueChanged(float value);

		protected void SetSliderText(string value)
		{
			_valueTextContainer.text = string.Format(_stringFormat, value);
		}

		protected void SetSliderValue(float value)
		{
			_slider.value = value;
		}
	}
}
