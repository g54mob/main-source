using UnityEngine;

namespace CTS
{
	public abstract class UI_SandboxIntSlider<TObject> : UI_SandboxSlider<TObject, int> where TObject : ScriptableObject
	{
		[SerializeField]
		private int _defaultValue;

		protected override bool IsInteger => true;

		protected override void OnSliderValueChanged(float value)
		{
			TObject obj = GetObject();
			int num = Mathf.RoundToInt(value);
			if (GetValue(obj) == num)
			{
				SetSliderText(GetValue(obj).ToString());
				return;
			}
			SetValue(obj, num);
			int value2 = GetValue(obj);
			if (value2 != num)
			{
				SetSliderValue(value2);
			}
			SetSliderText(GetValue(obj).ToString());
		}

		public override void ResetValue()
		{
			SetSliderValue(_defaultValue);
		}
	}
}
