using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Coherence.Cloud
{
	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Replaced by CloudUniqueId.")]
	[Deprecated("04/2025", 1, 6, 0, Reason = "Replaced by CloudUniqueId.")]
	public record UserGuid : IFormattable
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

		public static readonly UserGuid None;

		internal string value;

		private UserGuid()
		{
		}

		internal UserGuid(string value)
		{
		}

		public static implicit operator string(UserGuid userId)
		{
			return null;
		}

		public static implicit operator CloudUniqueId(UserGuid userId)
		{
			return default(CloudUniqueId);
		}

		public static implicit operator UserGuid(CloudUniqueId userId)
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}

		public string ToString(string format, IFormatProvider formatProvider)
		{
			return null;
		}

		public static string Serialize(UserGuid userId)
		{
			return null;
		}

		public static SessionToken Deserialize(string serializedUserId)
		{
			return default(SessionToken);
		}

		[CompilerGenerated]
		public virtual bool Equals(UserGuid? other)
		{
			return false;
		}

		[CompilerGenerated]
		protected UserGuid(UserGuid original)
		{
		}
	}
}
