using VoxelBusters.CoreLibrary;

namespace VoxelBusters.EssentialKit
{
	public class SharingServicesError
	{
		public const string kDomain = "[Essential Kit] Notification Services";

		public static Error Unknown(string description = null)
		{
			return null;
		}

		public static Error PermissionNotAvailable(string description = null)
		{
			return null;
		}

		private static Error CreateError(int code, string description)
		{
			return null;
		}
	}
}
