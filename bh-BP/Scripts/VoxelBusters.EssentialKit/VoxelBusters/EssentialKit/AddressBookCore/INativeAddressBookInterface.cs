using System;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit.AddressBookCore
{
	public interface INativeAddressBookInterface : INativeFeatureInterface, INativeObject, IDisposable
	{
		AddressBookContactsAccessStatus GetContactsAccessStatus();

		void ReadContacts(ReadContactsOptions options, ReadContactsInternalCallback callback);
	}
}
