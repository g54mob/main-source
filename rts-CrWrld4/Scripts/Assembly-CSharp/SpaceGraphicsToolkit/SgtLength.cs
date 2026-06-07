using System;

namespace SpaceGraphicsToolkit
{
	[Serializable]
	public struct SgtLength
	{
		public enum ScaleType
		{
			Meter = 0,
			Kilometer = 1,
			AU = 2,
			Lightyear = 3,
			Parsec = 4,
			GigaParsec = 5
		}

		public double Value;

		public ScaleType Scale;

		public SgtLength(double newValue, ScaleType newScale)
		{
			Value = 0.0;
			Scale = default(ScaleType);
		}

		public static implicit operator double(SgtLength length)
		{
			return 0.0;
		}

		public static implicit operator SgtLength(double length)
		{
			return default(SgtLength);
		}
	}
}
