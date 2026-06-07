using System.Collections;

namespace VoxelBusters.EssentialKit
{
	public interface IAddressBookContactsEnumerator : IEnumerator
	{
		int BlockSize { get; }

		int AvailableContactsCount { get; }

		IAddressBookContact GetContact(int index);
	}
}
