using System;

namespace LaundryBear.PlatformServices.None
{
	public class UserController : IUserController, IEquatable<IUserController>
	{
		public IUser User
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public bool Equals(IUserController other)
		{
			return this == other as UserController;
		}
	}
}
