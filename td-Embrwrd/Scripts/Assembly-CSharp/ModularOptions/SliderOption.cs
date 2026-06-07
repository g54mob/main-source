using UnityEngine;
using UnityEngine.UI;

namespace ModularOptions
{
	[RequireComponent(typeof(Slider))]
	public abstract class SliderOption : OptionBase<float, FloatSlider>
	{
		protected Slider slider;

		public override float Value
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		protected virtual void Awake()
		{
		}

		protected void OnValueChange(float _value)
		{
		}
	}
}
