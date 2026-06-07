namespace UTJ.FrameCapturer
{
	public abstract class AudioEncoder : EncoderBase
	{
		public enum Type
		{
			Wave = 0,
			Ogg = 1,
			Flac = 2
		}

		public abstract Type type { get; }

		public static Type[] GetAvailableEncoderTypes()
		{
			return null;
		}

		public abstract void Initialize(object config, string outPath);

		public abstract void AddAudioSamples(float[] samples);

		public static AudioEncoder Create(Type t)
		{
			return null;
		}

		public static AudioEncoder Create(AudioEncoderConfigs c, string path)
		{
			return null;
		}
	}
}
