namespace VoxelBusters.EssentialKit
{
	public class MediaServicesRequestCameraAccessResult
	{
		public CameraAccessStatus AccessStatus { get; private set; }

		internal MediaServicesRequestCameraAccessResult(CameraAccessStatus accessStatus)
		{
		}
	}
}
