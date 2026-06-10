namespace FMODUnity
{
	public class PlatformDefault : Platform
	{
		public const string ConstIdentifier = "default";

		public override string DisplayName => null;

		public override bool IsIntrinsic => false;

		public override void DeclareRuntimePlatforms(Settings settings)
		{
		}

		public override void InitializeProperties()
		{
		}

		public override void EnsurePropertiesAreValid()
		{
		}
	}
}
