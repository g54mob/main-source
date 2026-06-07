using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Coherence.Runtime;

namespace Coherence.Cloud
{
	public interface IAuthClient
	{
		bool LoggedIn { get; }

		event Action<LoginResponse> OnLogin;

		event Action OnLogout;

		event Action<LoginError> OnError;

		Task<LoginResult> LoginAsGuest(CancellationToken cancellationToken = default(CancellationToken));

		Task<LoginResult> LoginWithPassword(string username, string password, bool autoSignup, CancellationToken cancellationToken = default(CancellationToken));

		Task<LoginResult> LoginWithOneTimeCode(string code, CancellationToken cancellationToken = default(CancellationToken));

		Task<LoginResult> LoginWithSteam(string ticket, string identity = null, CancellationToken cancellationToken = default(CancellationToken));

		Task<LoginResult> LoginWithEpicGames(string token, CancellationToken cancellationToken = default(CancellationToken));

		Task<LoginResult> LoginWithPlayStation(string token, CancellationToken cancellationToken = default(CancellationToken));

		Task<LoginResult> LoginWithXbox(string token, CancellationToken cancellationToken = default(CancellationToken));

		Task<LoginResult> LoginWithNintendo(string token, CancellationToken cancellationToken = default(CancellationToken));

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("This method will be removed in a future version. Use LoginWithSessionToken instead.")]
		[Deprecated("03/2025", 1, 6, 0, Reason = "Renamed to 'LoginWithSessionToken' to avoid ambiguity with the JSON Web Token based authentication.")]
		Task<LoginResult> LoginWithToken(SessionToken sessionToken)
		{
			return null;
		}

		Task<LoginResult> LoginWithSessionToken(SessionToken sessionToken, CancellationToken cancellationToken = default(CancellationToken));

		Task<LoginResult> LoginWithJwt(string token, CancellationToken cancellationToken = default(CancellationToken));

		void Logout();
	}
}
