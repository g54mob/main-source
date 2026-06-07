namespace UTJ.FrameCapturer
{
	public class MP4Encoder : MovieEncoder
	{
		private fcAPI.fcMP4Context m_ctx;

		private fcAPI.fcMP4Config m_config;

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
