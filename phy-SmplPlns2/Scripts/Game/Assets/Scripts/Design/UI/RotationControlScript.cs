using Assets.Scripts.UI.Controls;
using Jundroo.Juicy.Widgets;

namespace Assets.Scripts.Design.UI
{
	public class RotationControlScript : NumericSpinnerControl
	{
		private bool _ignoreChangedEvents;

		public SliderWidget Slider { get; private set; }

		public override float Value
		{
			get
			{
				return base.Value;
			}
			set
			{
				try
				{
					_ignoreChangedEvents = true;
					Slider.Value = value / 180f * 0.5f + 0.5f;
					base.Value = value;
				}
				finally
				{
					_ignoreChangedEvents = false;
				}
			}
		}

		public RotationControlScript(Widget widget, SliderWidget slider, TransformPartPanelScript transformPartPanel)
			: base(widget)
		{
			RotationControlScript rotationControlScript = this;
			base.OnValueChanged = delegate
			{
				transformPartPanel.UpdatePartRotation();
			};
			base.GetIncrementAmount = () => transformPartPanel.RotateAmount;
			base.GetDecrementAmount = () => transformPartPanel.RotateAmount;
			base.NumericFormat = "0.000";
			Slider = slider;
			Slider.ValueChanged += delegate
			{
				rotationControlScript.OnSliderValueChanged();
			};
		}

		private void OnSliderValueChanged()
		{
			if (!_ignoreChangedEvents)
			{
				float value = Value;
				float num = (Slider.Value * 2f - 1f) * 180f;
				base.OnValueChanging?.Invoke(value, num);
				Value = num;
				base.OnValueChanged?.Invoke(value, num);
			}
		}
	}
}
