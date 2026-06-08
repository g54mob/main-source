using System;

namespace LaundryBear.PlatformServices
{
	public interface IUser : IEquatable<IUser>
	{
		bool IsSignedIn();

		ILocalID GetLocalID();

		IUniqueID GetUniqueID();

		string GetDisplayName();

		void GetProfilePicture(PhotoSize size, OnProfilePictureRetrieved callback);

		IUserController[] GetControllers();
	}
}
