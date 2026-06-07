using VoxelBusters.CoreLibrary;

namespace VoxelBusters.EssentialKit
{
	public interface IAddressBookContact
	{
		string FirstName { get; }

		string MiddleName { get; }

		string LastName { get; }

		string[] PhoneNumbers { get; }

		string[] EmailAddresses { get; }

		string CompanyName { get; }

		void LoadImage(EventCallback<TextureData> callback);
	}
}
