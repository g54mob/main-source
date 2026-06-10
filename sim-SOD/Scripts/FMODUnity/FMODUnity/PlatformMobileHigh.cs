namespace FMODUnity
{
	public class PlatformMobileHigh : PlatformMobileLow
	{
		public override string DisplayName => null;

		public override float Priority => 0f;

		public override bool MatchesCurrentEnvironment => false;

		static PlatformMobileHigh()
		{
		}
	}
}
