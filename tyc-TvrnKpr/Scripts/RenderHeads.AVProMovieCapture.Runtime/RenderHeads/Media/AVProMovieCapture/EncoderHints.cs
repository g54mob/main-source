using System;

namespace RenderHeads.Media.AVProMovieCapture
{
	[Serializable]
	public class EncoderHints
	{
		public VideoEncoderHints videoHints;

		public ImageEncoderHints imageHints;

		public void SetDefaults()
		{
		}
	}
}
