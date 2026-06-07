namespace UTJ.FrameCapturer
{
	public class ExrEncoder : MovieEncoder
	{
		private static readonly string[] s_channelNames;

		private fcAPI.fcExrContext m_ctx;

		private fcAPI.fcExrConfig m_config;

		private string m_outPath;

		private int m_frame;

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

		public override void AddVideoFrame(byte[] frame, fcAPI.fcPixelFormat format, double timestamp = -1.0)
		{
		}

		public override void AddAudioSamples(float[] samples)
		{
		}
	}
}
