using VoxelBusters.CoreLibrary;

namespace VoxelBusters.EssentialKit
{
	public static class AddressBookError
	{
		public const string kDomain = "[Essential Kit] Address Book";

		public static Error Unknown { get; }

		public static Error PermissionDenied { get; }

		private static Error CreateError(int code, string description)
		{
			return null;
		}
	}
}
