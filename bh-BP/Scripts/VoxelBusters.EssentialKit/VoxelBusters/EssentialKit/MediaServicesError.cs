using VoxelBusters.CoreLibrary;

namespace VoxelBusters.EssentialKit
{
	public class MediaServicesError
	{
		public const string kDomain = "[Essential Kit] Media Services";

		public static Error Unknown(string description = null)
		{
			return null;
		}

		public static Error PermissionNotAvailable(string description = null)
		{
			return null;
		}

		public static Error UserCancelled(string description = null)
		{
			return null;
		}

		public static Error DataNotAvailable(string description = null)
		{
			return null;
		}

		private static Error CreateError(int code, string description)
		{
			return null;
		}
	}
}
