using UnityEngine.XR;

namespace VRTK
{
	[SDK_Description("Unity (Standalone:Oculus)", null, "Oculus", "Standalone", 0)]
	[SDK_Description("Unity (Standalone:OpenVR)", null, "OpenVR", "Standalone", 1)]
	[SDK_Description("Unity (Android:Cardboard)", null, "cardboard", "Android", 2)]
	[SDK_Description("Unity (Android:Daydream)", null, "daydream", "Android", 3)]
	[SDK_Description("Unity (Android:Oculus)", null, "Oculus", "Android", 4)]
	[SDK_Description("Unity (Android:OpenVR)", null, "OpenVR", "Android", 5)]
	public class SDK_UnitySystem : SDK_BaseSystem
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
			InputTracking.Recenter();
		}

		public override void SetSeatedMode(bool isSeated)
		{
			XRDevice.SetTrackingSpaceType((!isSeated) ? TrackingSpaceType.RoomScale : TrackingSpaceType.Stationary);
		}
	}
}
