using UnityEngine;

namespace CTS
{
	public abstract class UI_SandboxFloatSlider<TObject> : UI_SandboxSlider<TObject, float> where TObject : ScriptableObject
	{
		[SerializeField]
		private float _defaultValue;

		protected override bool IsInteger => false;

		protected override void OnSliderValueChanged(float value)
		{
			TObject obj = GetObject();
			if (Mathf.Approximately(GetValue(obj), value))
			{
				SetSliderText(GetValue(obj).ToString("N2"));
				return;
			}
			SetValue(obj, value);
			float value2 = GetValue(obj);
			if (!Mathf.Approximately(value2, value))
			{
				SetSliderValue(value2);
			}
			SetSliderText(GetValue(obj).ToString("N2"));
		}

		public override void ResetValue()
		{
			SetSliderValue(_defaultValue);
		}
	}
}
