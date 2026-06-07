using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Coherence.Cloud
{
	public static class CoherenceCloud
	{
		public static event Action<PlayerAccount> OnLoggingIn
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event Action<LoginOperationError> OnLoggingInFailed
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event Action<PlayerAccount> OnLoggedIn
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event Action<PlayerAccount> OnLoggingOut
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static LoginOperation LoginAsGuest(CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		public static LoginOperation LoginAsGuest(LoginAsGuestOptions options, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		public static LoginOperation LoginWithPassword(string username, string password, bool autoSignup = false, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		public static LoginOperation LoginWithSessionToken(SessionToken sessionToken, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		public static LoginOperation LoginWithSteam(string ticket, string identity = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		public static LoginOperation LoginWithEpicGames(string token, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		public static LoginOperation LoginWithPlayStation(string token, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		public static LoginOperation LoginWithXbox(string token, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		public static LoginOperation LoginWithNintendo(string token, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		public static LoginOperation LoginWithJwt(string token, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		public static LoginOperation LoginWithOneTimeCode(string code, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		internal static LoginOperation Login(LoginInfo loginInfo, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		internal static void RaiseOnLoggingIn(PlayerAccount playerAccount)
		{
		}

		internal static void RaiseOnLoggingInFailed(LoginOperationError error)
		{
		}

		internal static void RaiseOnLoggedIn(PlayerAccount playerAccount)
		{
		}

		internal static void RaiseOnLoggingOut(PlayerAccount playerAccount)
		{
		}
	}
}
