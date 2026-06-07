namespace R3.Internal
{
	internal static class FrameCountExtensions
	{
		public static int NormalizeFrame(this int frameCount)
		{
			if (frameCount <= 0)
			{
				return 1;
			}
			return frameCount;
		}
	}
}
