namespace VoxelBusters.EssentialKit
{
	public class AddressBookReadContactsResult
	{
		public IAddressBookContact[] Contacts { get; private set; }

		public int NextOffset { get; private set; }

		internal AddressBookReadContactsResult(IAddressBookContact[] contacts, int nextOffset)
		{
		}
	}
}
