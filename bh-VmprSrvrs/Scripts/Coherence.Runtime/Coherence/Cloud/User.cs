using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Coherence.Cloud
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Replaced by PlayerAccount.")]
	[Deprecated("04/2025", 1, 6, 0, Reason = "Replaced by PlayerAccount.")]
	public record User
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

		public string UserId { get; }

		public CloudUniqueId Guid { get; }

		public string Username { get; }

		public SessionToken SessionToken { get; }

		public static readonly User None;

		private User(CloudUniqueId guid, string userId, string username, SessionToken sessionToken)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public static implicit operator CloudUniqueId(User user)
		{
			return default(CloudUniqueId);
		}

		public static implicit operator PlayerAccount(User user)
		{
			return null;
		}

		public static implicit operator User(PlayerAccount playerAccount)
		{
			return null;
		}

		[CompilerGenerated]
		protected virtual bool PrintMembers(StringBuilder builder)
		{
			return false;
		}

		[CompilerGenerated]
		public virtual bool Equals(User? other)
		{
			return false;
		}

		[CompilerGenerated]
		protected User(User original)
		{
		}
	}
}
