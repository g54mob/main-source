using System;
using Coherence.Runtime;

namespace Coherence.Cloud
{
	internal readonly struct LoginInfo : IEquatable<LoginInfo>
	{
		private readonly string usernameGuestIdOrIdentity;

		private readonly string passwordTokenTicketOrCode;

		public LoginType LoginType { get; }

		public bool AutoSignup { get; }

		public string Username => null;

		public GuestId GuestId => default(GuestId);

		public string Password => null;

		public string Token => null;

		public string Ticket => null;

		public string Identity => null;

		public SessionToken SessionToken => default(SessionToken);

		public string OneTimeCode => null;

		public bool IsGuest => false;

		private LoginInfo(LoginType loginType, string usernameGuestIdOrIdentity, string passwordTokenTicketOrCode, bool autoSignup)
		{
			this.usernameGuestIdOrIdentity = null;
			this.passwordTokenTicketOrCode = null;
			LoginType = default(LoginType);
			AutoSignup = false;
		}

		public static LoginInfo WithPassword(string username, string password, bool autoSignup)
		{
			return default(LoginInfo);
		}

		public static LoginInfo WithSteam(string ticket, string identity)
		{
			return default(LoginInfo);
		}

		public static LoginInfo WithEpicGames(string token)
		{
			return default(LoginInfo);
		}

		public static LoginInfo WithPlayStation(string token)
		{
			return default(LoginInfo);
		}

		public static LoginInfo WithXbox(string token)
		{
			return default(LoginInfo);
		}

		public static LoginInfo WithNintendo(string token)
		{
			return default(LoginInfo);
		}

		public static LoginInfo WithJwt(string token)
		{
			return default(LoginInfo);
		}

		public static LoginInfo WithSessionToken(SessionToken sessionToken)
		{
			return default(LoginInfo);
		}

		public static LoginInfo WithOneTimeCode(string code)
		{
			return default(LoginInfo);
		}

		public static LoginInfo ForGuest(IPlayerAccountProvider playerAccountProvider, bool preferLegacyLoginData)
		{
			return default(LoginInfo);
		}

		internal static LoginInfo ForGuest(GuestId guestId)
		{
			return default(LoginInfo);
		}

		internal static LoginInfo ForGuest(string projectId, CloudUniqueId uniqueId, bool preferLegacyLoginData)
		{
			return default(LoginInfo);
		}

		public static bool operator ==(LoginInfo x, LoginInfo y)
		{
			return false;
		}

		public static bool operator !=(LoginInfo x, LoginInfo y)
		{
			return false;
		}

		public bool Equals(LoginInfo other)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
