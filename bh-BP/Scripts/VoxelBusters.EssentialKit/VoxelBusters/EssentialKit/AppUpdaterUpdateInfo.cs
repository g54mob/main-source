namespace VoxelBusters.EssentialKit
{
	public class AppUpdaterUpdateInfo
	{
		public AppUpdaterUpdateStatus Status { get; private set; }

		private int BuildTag { get; set; }

		internal AppUpdaterUpdateInfo(AppUpdaterUpdateStatus status, int buildTag)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
