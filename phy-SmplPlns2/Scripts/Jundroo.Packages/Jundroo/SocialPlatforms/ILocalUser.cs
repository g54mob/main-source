using System;

namespace Jundroo.SocialPlatforms
{
	public interface ILocalUser : IUserProfile
	{
		bool authenticated { get; }

		IUserProfile[] friends { get; }

		bool underage { get; }

		void Authenticate(Action<bool> callback);

		void Authenticate(Action<bool, string> callback);

		void LoadFriends(Action<bool> callback);
	}
}
