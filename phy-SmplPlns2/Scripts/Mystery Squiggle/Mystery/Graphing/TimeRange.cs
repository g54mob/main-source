namespace Mystery.Graphing
{
	public class TimeRange : ValueRange<float>, ITimeRange, IValueRange
	{
		private bool useSharedTime;

		private float min = float.MaxValue;

		private float max = float.MinValue;

		private static float sharedMin = float.MaxValue;

		private static float sharedMax = float.MinValue;

		public bool UseSharedTime
		{
			get
			{
				return useSharedTime;
			}
			set
			{
				useSharedTime = value;
			}
		}

		public override float Min
		{
			get
			{
				if (!useSharedTime)
				{
					return min;
				}
				return sharedMin;
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
				if (!useSharedTime)
				{
					return max;
				}
				return sharedMax;
			}
			set
			{
				max = value;
			}
		}

		public static float SharedMin
		{
			get
			{
				return sharedMin;
			}
			set
			{
				sharedMin = value;
			}
		}

		public static float SharedMax
		{
			get
			{
				return sharedMax;
			}
			set
			{
				sharedMax = value;
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
