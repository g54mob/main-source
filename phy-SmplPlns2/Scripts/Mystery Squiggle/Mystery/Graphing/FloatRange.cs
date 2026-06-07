namespace Mystery.Graphing
{
	public class FloatRange : ValueRange<float>
	{
		private float min = float.MaxValue;

		private float max = float.MinValue;

		public override float Min
		{
			get
			{
				return min;
			}
			set
			{
				min = value;
			}
		}

		public override float Max
		{
			get
			{
				return max;
			}
			set
			{
				max = value;
			}
		}

		public override void UpdateMin(float value)
		{
			if (value < min)
			{
				min = value;
			}
		}

		public override void UpdateMax(float value)
		{
			if (value > max)
			{
				max = value;
			}
		}

		public override void Reset()
		{
			min = float.MaxValue;
			max = float.MinValue;
		}
	}
}
