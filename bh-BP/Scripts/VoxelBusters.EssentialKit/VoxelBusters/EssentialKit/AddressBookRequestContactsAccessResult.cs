namespace VoxelBusters.EssentialKit
{
	public class AddressBookRequestContactsAccessResult
	{
		public AddressBookContactsAccessStatus AccessStatus { get; private set; }

		internal AddressBookRequestContactsAccessResult(AddressBookContactsAccessStatus accessStatus)
		{
		}
	}
}
