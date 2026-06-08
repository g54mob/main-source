using System;

namespace LaundryBear.PlatformServices
{
	public interface IUserController : IEquatable<IUserController>
	{
		IUser User { get; }
	}
}
