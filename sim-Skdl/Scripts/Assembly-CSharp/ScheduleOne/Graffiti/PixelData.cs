namespace ScheduleOne.Graffiti
{
	public class PixelData
	{
		public UShort2 Coordinate;

		public ESprayColor Color;

		public byte StrokeSize;

		public byte StrokeRadiusRoundedUp => 0;

		public byte StrokeRadiusRoundedDown => 0;

		public PixelData(UShort2 coordinate, ESprayColor color, byte strokeSize)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public float GetPixelStrength(int pixelIndex)
		{
			return 0f;
		}
	}
}
