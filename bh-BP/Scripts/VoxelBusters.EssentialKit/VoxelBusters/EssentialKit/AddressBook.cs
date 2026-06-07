using VoxelBusters.CoreLibrary;
using VoxelBusters.EssentialKit.AddressBookCore;

namespace VoxelBusters.EssentialKit
{
	public static class AddressBook
	{
		[ClearOnReload]
		private static INativeAddressBookInterface s_nativeInterface;

		public static AddressBookUnitySettings UnitySettings { get; private set; }

		public static bool IsAvailable()
		{
			return false;
		}

		public static void Initialize(AddressBookUnitySettings settings)
		{
		}

		public static AddressBookContactsAccessStatus GetContactsAccessStatus()
		{
			return default(AddressBookContactsAccessStatus);
		}

		public static void ReadContacts(ReadContactsOptions options, EventCallback<AddressBookReadContactsResult> callback)
		{
		}

		private static void SendReadContactsResult(EventCallback<AddressBookReadContactsResult> callback, IAddressBookContact[] contacts, int nextOffset, Error error)
		{
		}
	}
}
