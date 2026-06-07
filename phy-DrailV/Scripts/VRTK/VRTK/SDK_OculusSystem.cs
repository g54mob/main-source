namespace VRTK
{
	[SDK_Description("Oculus Rift (Standalone:Oculus)", "VRTK_DEFINE_SDK_OCULUS", "Oculus", "Standalone", 0)]
	[SDK_Description("GearVR (Android:Oculus)", "VRTK_DEFINE_SDK_OCULUS", "Oculus", "Android", 1)]
	public class SDK_OculusSystem : SDK_BaseSystem
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
			OVRManager.display.RecenterPose();
		}

		public override void SetSeatedMode(bool isSeated)
		{
			OVRManager.instance.trackingOriginType = ((!isSeated) ? OVRManager.TrackingOrigin.FloorLevel : OVRManager.TrackingOrigin.EyeLevel);
		}
	}
}
