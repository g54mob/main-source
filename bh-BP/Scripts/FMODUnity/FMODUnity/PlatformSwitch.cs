namespace FMODUnity
{
	public class PlatformSwitch : Platform
	{
		internal override string DisplayName => null;

		static PlatformSwitch()
		{
		}

		internal override void DeclareRuntimePlatforms(Settings settings)
		{
		}

		internal override string GetBankFolder()
		{
			return null;
		}
	}
}
