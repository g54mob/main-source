namespace VoxelBusters.EssentialKit
{
	public class NotificationServicesRequestPermissionResult
	{
		public NotificationPermissionStatus PermissionStatus { get; private set; }

		internal NotificationServicesRequestPermissionResult(NotificationPermissionStatus permissionStatus)
		{
		}
	}
}
