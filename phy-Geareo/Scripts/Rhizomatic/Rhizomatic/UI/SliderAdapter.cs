namespace Rhizomatic.UI
{
	public abstract class SliderAdapter : UIAdapter<float>, IBar
	{
		public float progress
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public abstract float minValue { get; set; }

		public abstract float maxValue { get; set; }

		public abstract bool wholeNumbers { get; set; }
	}
}
