namespace VoxelBusters.CoreLibrary.NativePlugins
{
	public interface INativeFeatureUsagePermissionHandler
	{
		void ShowPrepermissionDialog(string permissionType, Callback onAllowCallback, Callback onDenyCallback);
	}
}
