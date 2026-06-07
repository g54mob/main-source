namespace VRTK
{
	[SDK_Description("Simulator (Standalone)", null, null, "Standalone", 0)]
	public class SDK_SimSystem : SDK_BaseSystem
	{
		public override bool IsDisplayOnDesktop()
		{
			return false;
		}

		public override bool ShouldAppRenderWithLowResources()
		{
			return false;
		}

		public override void ForceInterleavedReprojectionOn(bool force)
		{
		}

		public override void ResetSeatedPosition()
		{
		}

		public override void SetSeatedMode(bool isSeated)
		{
		}
	}
}
