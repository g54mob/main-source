using System;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit.AddressBookCore
{
	public abstract class NativeAddressBookInterfaceBase : NativeFeatureInterfaceBase, INativeAddressBookInterface, INativeFeatureInterface, INativeObject, IDisposable
	{
		protected NativeAddressBookInterfaceBase(bool isAvailable)
			: base(isAvailable: false)
		{
		}

		public abstract AddressBookContactsAccessStatus GetContactsAccessStatus();

		public abstract void ReadContacts(ReadContactsOptions options, ReadContactsInternalCallback callback);
	}
}
