namespace UTJ.FrameCapturer
{
	public class WaveEncoder : AudioEncoder
	{
		private fcAPI.fcWaveContext m_ctx;

		private fcAPI.fcWaveConfig m_config;

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

		public override void AddAudioSamples(float[] samples)
		{
		}
	}
}
