using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Coherence.Log;
using Coherence.Runtime;

namespace Coherence.Cloud
{
	public record LoginResult
	{
		[CompilerGenerated]
		protected virtual Type EqualityContract
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
		}

		public PlayerAccount PlayerAccount { get; }

		public Result Type { get; }

		public PlayerAccountId Id { get; }

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Use Id instead.")]
		[Deprecated("04/2025", 1, 6, 0, Reason = "Use Id instead.")]
		public string UserId => null;

		public string Username => null;

		[Obsolete("Guest users no longer have passwords. This property will be removed in a future version")]
		[Deprecated("03/2025", 1, 6, 0, Reason = "Guest users no longer have passwords.")]
		public string GuestPassword => null;

		public SessionToken SessionToken => default(SessionToken);

		public ErrorType ErrorType { get; }

		public string ErrorMessage { get; }

		public IReadOnlyList<KeyValuePair<string, string>> KeyValuePairStoreState { get; }

		public IReadOnlyList<string> LobbyIds { get; }

		public bool LoggedIn => false;

		internal LoginErrorType LoginErrorType { get; }

		internal Error Error { get; }

		internal readonly LoginResponse? response;

		internal static LoginResult Success(PlayerAccount playerAccount, Result type, LoginResponse response)
		{
			return null;
		}

		internal static LoginResult Failure(Result type, LoginError error)
		{
			return null;
		}

		private LoginResult(Result type, PlayerAccount playerAccount, LoginResponse? response, LoginError error)
		{
		}

		public static implicit operator Result(LoginResult loginResult)
		{
			return default(Result);
		}

		public static bool operator ==(LoginResult result, Result type)
		{
			return false;
		}

		public static bool operator !=(LoginResult result, Result type)
		{
			return false;
		}

		public bool Equals(Result type)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}

		[CompilerGenerated]
		protected virtual bool PrintMembers(StringBuilder builder)
		{
			return false;
		}

		[CompilerGenerated]
		public virtual bool Equals(LoginResult? other)
		{
			return false;
		}

		[CompilerGenerated]
		protected LoginResult(LoginResult original)
		{
		}
	}
}
