namespace UTJ.FrameCapturer
{
	public abstract class MovieEncoder : EncoderBase
	{
		public enum Type
		{
			Png = 0,
			Exr = 1,
			Gif = 2,
			WebM = 3,
			MP4 = 4
		}

		public abstract Type type { get; }

		public static Type[] GetAvailableEncoderTypes()
		{
			return null;
		}

		public abstract void Initialize(object config, string outPath);

		public abstract void AddVideoFrame(byte[] frame, fcAPI.fcPixelFormat format, double timestamp = -1.0);

		public abstract void AddAudioSamples(float[] samples);

		public static MovieEncoder Create(Type t)
		{
			return null;
		}

		public static MovieEncoder Create(MovieEncoderConfigs c, string path)
		{
			return null;
		}
	}
}
