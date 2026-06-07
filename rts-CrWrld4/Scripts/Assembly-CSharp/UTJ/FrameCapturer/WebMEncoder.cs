namespace UTJ.FrameCapturer
{
	public class WebMEncoder : MovieEncoder
	{
		private fcAPI.fcWebMContext m_ctx;

		private fcAPI.fcWebMConfig m_config;

		public override Type type => default(Type);

		public override void Release()
		{
		}

		public override bool IsValid()
		{
			return false;
		}

		public override void Initialize(object config, string outPath)
		{
		}

		public override void AddVideoFrame(byte[] frame, fcAPI.fcPixelFormat format, double timestamp)
		{
		}

		public override void AddAudioSamples(float[] samples)
		{
		}
	}
}
