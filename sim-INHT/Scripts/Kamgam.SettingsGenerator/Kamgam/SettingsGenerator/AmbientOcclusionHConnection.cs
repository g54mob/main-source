namespace Kamgam.SettingsGenerator
{
	public class AmbientOcclusionHConnection : Connection<bool>
	{
		public override bool Get()
		{
			return false;
		}

		public override void Set(bool enable)
		{
		}

		public override void OnQualityChanged(int qualityLevel)
		{
		}
	}
}
