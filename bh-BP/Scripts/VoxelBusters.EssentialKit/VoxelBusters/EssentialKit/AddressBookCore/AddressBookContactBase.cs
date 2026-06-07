using UnityEngine;
using VoxelBusters.CoreLibrary;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit.AddressBookCore
{
	public abstract class AddressBookContactBase : NativeObjectBase, IAddressBookContact
	{
		internal static Texture2D defaultImage;

		private TextureData m_cachedData;

		public string FirstName => null;

		public string MiddleName => null;

		public string LastName => null;

		public string[] PhoneNumbers => null;

		public string[] EmailAddresses => null;

		public string CompanyName => null;

		protected abstract string GetFirstNameInternal();

		protected abstract string GetMiddleNameInternal();

		protected abstract string GetLastNameInternal();

		protected abstract string[] GetPhoneNumbersInternal();

		protected abstract string[] GetEmailAddressesInternal();

		protected abstract string GetCompanyNameInternal();

		protected abstract void LoadImageInternal(LoadImageInternalCallback callback);

		public override string ToString()
		{
			return null;
		}

		public void LoadImage(EventCallback<TextureData> callback)
		{
		}
	}
}
