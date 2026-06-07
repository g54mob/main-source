using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameCreator.Runtime.Common.UnityUI
{
	[Serializable]
	[Title("Slider")]
	[Category("UI/Slider")]
	[Description("Gets the Slider's min, max or current value")]
	[Image(typeof(IconUISlider), ColorTheme.Type.TextLight)]
	public class GetDecimalUISlider : PropertyTypeGetDecimal
	{
		private enum Property
		{
			Value = 0,
			MinValue = 1,
			MaxValue = 2
		}

		[SerializeField]
		private Property m_Property;

		[SerializeField]
		private PropertyGetGameObject m_Slider = GetGameObjectInstance.Create();

		public static PropertyGetDecimal Create => new PropertyGetDecimal(new GetDecimalUISlider());

		public override string String => $"{m_Slider} {TextUtils.Humanize(m_Property.ToString())}";

		public override double Get(Args args)
		{
			GameObject gameObject = m_Slider.Get(args);
			if (gameObject == null)
			{
				return 0.0;
			}
			Slider slider = gameObject.Get<Slider>();
			return m_Property switch
			{
				Property.Value => slider.value, 
				Property.MinValue => slider.minValue, 
				Property.MaxValue => slider.maxValue, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
	}
}
