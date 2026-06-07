using Valve.VR;

namespace VRTK
{
	[SDK_Description("SteamVR (Standalone:OpenVR)", "VRTK_DEFINE_SDK_STEAMVR", "OpenVR", "Standalone", 0)]
	public class SDK_SteamVRSystem : SDK_BaseSystem
	{
		public override bool IsDisplayOnDesktop()
		{
			if (OpenVR.System != null)
			{
				return OpenVR.System.IsDisplayOnDesktop();
			}
			return true;
		}

		public override bool ShouldAppRenderWithLowResources()
		{
			if (OpenVR.Compositor != null)
			{
				return OpenVR.Compositor.ShouldAppRenderWithLowResources();
			}
			return false;
		}

		public override void ForceInterleavedReprojectionOn(bool force)
		{
			if (OpenVR.Compositor != null)
			{
				OpenVR.Compositor.ForceInterleavedReprojectionOn(force);
			}
		}

		public override void ResetSeatedPosition()
		{
			SteamVR.instance.hmd.ResetSeatedZeroPose();
		}

		public override void SetSeatedMode(bool isSeated)
		{
			SteamVR_Render.instance.trackingSpace = ((!isSeated) ? ETrackingUniverseOrigin.TrackingUniverseStanding : ETrackingUniverseOrigin.TrackingUniverseSeated);
		}
	}
}
