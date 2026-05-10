namespace FluffyUnderware.Curvy.Generator
{
	public class CGDataRequestRasterization : CGDataRequestParameter
	{
		public enum ModeEnum
		{
			Even = 0,
			Optimized = 1
		}

		public float Start;

		public float RasterizedRelativeLength;

		public int Resolution;

		public float AngleThreshold;

		public ModeEnum Mode;

		public CGDataRequestRasterization(float start, float rasterizedRelativeLength, int resolution, float angle, ModeEnum mode = ModeEnum.Even)
		{
		}

		public CGDataRequestRasterization(CGDataRequestRasterization source)
		{
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
