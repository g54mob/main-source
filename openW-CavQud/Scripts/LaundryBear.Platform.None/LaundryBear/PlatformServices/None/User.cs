using System;

namespace LaundryBear.PlatformServices.None
{
	public class User : IUser, IEquatable<IUser>
	{
		private class LocalID : ILocalID, IEquatable<ILocalID>
		{
			public bool Equals(ILocalID other)
			{
				return true;
			}
		}

		private class UniqueID : IUniqueID, IEquatable<IUniqueID>
		{
			public bool Equals(IUniqueID other)
			{
				return true;
			}
		}

		internal User()
		{
		}

		public bool IsSignedIn()
		{
			return false;
		}

		public IUserController[] GetControllers()
		{
			return null;
		}

		public string GetDisplayName()
		{
			return string.Empty;
		}

		public ILocalID GetLocalID()
		{
			return new LocalID();
		}

		public void GetProfilePicture(PhotoSize size, OnProfilePictureRetrieved callback)
		{
			callback(null);
		}

		public IUniqueID GetUniqueID()
		{
			return new UniqueID();
		}

		public bool Equals(IUser otherUser)
		{
			return true;
		}
	}
}
