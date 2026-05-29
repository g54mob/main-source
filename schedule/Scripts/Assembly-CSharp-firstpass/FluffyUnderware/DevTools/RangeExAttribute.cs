namespace FluffyUnderware.DevTools
{
	public class RangeExAttribute : DTPropertyAttribute
	{
		public float MinValue;

		public string MinFieldOrPropertyName;

		public float MaxValue;

		public string MaxFieldOrPropertyName;

		public bool Slider;

		public RangeExAttribute(float minValue, float maxValue, string label = "", string tooltip = "")
			: base(null, null)
		{
		}

		public RangeExAttribute(string minFieldOrProperty, float maxValue, string label = "", string tooltip = "")
			: base(null, null)
		{
		}

		public RangeExAttribute(float minValue, string maxFieldOrProperty, string label = "", string tooltip = "")
			: base(null, null)
		{
		}

		public RangeExAttribute(string minFieldOrProperty, string maxFieldOrProperty, string label = "", string tooltip = "")
			: base(null, null)
		{
		}
	}
}
