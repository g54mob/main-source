using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace Coherence.Cloud
{
	public sealed record Identity
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

		public IdentityType Type { get; }

		public string Id { get; }

		internal Identity(IdentityType type, string id)
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
		public bool Equals(Identity? other)
		{
			return false;
		}

		[CompilerGenerated]
		private Identity(Identity original)
		{
		}
	}
}
