using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Coherence.Cloud
{
	public sealed record PlayerAccountInfo
	{
		[CompilerGenerated]
		private Type EqualityContract
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
		}

		public PlayerAccountId Id { get; }

		public string Username { get; }

		public string DisplayName { get; }

		public string AvatarUrl { get; }

		public IReadOnlyList<Identity> Identities { get; }

		public DateTimeOffset CreatedAt { get; }

		public bool IsVerified { get; }

		internal PlayerAccountInfo(string id, string username, string displayName, string avatarUrl, Identity[] identities, DateTimeOffset createdAt, bool isVerified)
		{
		}

		[CompilerGenerated]
		public override string ToString()
		{
			return null;
		}

		[CompilerGenerated]
		private bool PrintMembers(StringBuilder builder)
		{
			return false;
		}

		[CompilerGenerated]
		public bool Equals(PlayerAccountInfo? other)
		{
			return false;
		}

		[CompilerGenerated]
		private PlayerAccountInfo(PlayerAccountInfo original)
		{
		}
	}
}
