using VoxelBusters.CoreLibrary;

namespace VoxelBusters.EssentialKit.AddressBookCore
{
	public delegate void ReadContactsInternalCallback(IAddressBookContact[] contacts, int nextOffset, Error error);
}
