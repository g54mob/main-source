using System;

namespace Coherence.Cloud
{
	[Serializable]
	public readonly struct PlayerAccountId : IFormattable, IEquatable<PlayerAccountId>
	{
		public static readonly PlayerAccountId None;

		private readonly string value;

		internal PlayerAccountId(string value)
		{
			this.value = null;
		}

		public override string ToString()
		{
			return null;
		}

		public string ToString(string format, IFormatProvider formatProvider)
		{
			return null;
		}

		public bool Equals(PlayerAccountId other)
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

		public static string Serialize(PlayerAccountId id)
		{
			return null;
		}

		public static PlayerAccountId Deserialize(string serializedId)
		{
			return default(PlayerAccountId);
		}

		public static implicit operator string(PlayerAccountId id)
		{
			return null;
		}

		public static implicit operator PlayerAccountId(string id)
		{
			return default(PlayerAccountId);
		}

		public static bool operator ==(PlayerAccountId left, PlayerAccountId right)
		{
			return false;
		}

		public static bool operator !=(PlayerAccountId left, PlayerAccountId right)
		{
			return false;
		}
	}
}
