using VoxelBusters.CoreLibrary;

namespace VoxelBusters.EssentialKit
{
	public static class AppUpdaterError
	{
		private static string kDomain;

		public static Error Unknown => null;

		public static Error NetworkIssue => null;

		public static Error UpdateNotCompatible => null;

		public static Error UpdateInfoNotAvailable => null;

		public static Error UpdateNotAvailable => null;

		public static Error UpdateInProgress => null;

		public static Error UpdateCancelled => null;

		public static Error CreateError(AppUpdaterErrorCode code, string description)
		{
			return null;
		}
	}
}
