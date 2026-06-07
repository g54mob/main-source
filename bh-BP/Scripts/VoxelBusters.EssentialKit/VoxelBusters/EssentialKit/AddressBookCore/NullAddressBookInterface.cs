using System;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit.AddressBookCore
{
	internal class NullAddressBookInterface : NativeAddressBookInterfaceBase, INativeAddressBookInterface, INativeFeatureInterface, INativeObject, IDisposable
	{
		public NullAddressBookInterface()
			: base(isAvailable: false)
		{
		}

		private static void LogNotSupported()
		{
		}

		public override AddressBookContactsAccessStatus GetContactsAccessStatus()
		{
			return default(AddressBookContactsAccessStatus);
		}

		public override void ReadContacts(ReadContactsOptions options, ReadContactsInternalCallback callback)
		{
		}
	}
}
