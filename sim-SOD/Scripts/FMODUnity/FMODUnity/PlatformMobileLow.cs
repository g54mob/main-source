namespace FMODUnity
{
	public class PlatformMobileLow : Platform
	{
		public override string DisplayName => null;

		public override float Priority => 0f;

		public override bool MatchesCurrentEnvironment => false;

		static PlatformMobileLow()
		{
		}

		public override void DeclareRuntimePlatforms(Settings settings)
		{
		}
	}
}
