using System;

namespace Coherence.Cloud
{
	public readonly struct SessionToken : IEquatable<SessionToken>
	{
		public static readonly SessionToken None;

		private readonly string value;

		internal SessionToken(string value)
		{
			this.value = null;
		}

		public static string Serialize(SessionToken sessionToken)
		{
			return null;
		}

		public static SessionToken Deserialize(string serializedSessionToken)
		{
			return default(SessionToken);
		}

		public static implicit operator string(SessionToken sessionToken)
		{
			return null;
		}

		public static implicit operator SessionToken(string sessionToken)
		{
			return default(SessionToken);
		}

		public static bool operator ==(SessionToken x, SessionToken y)
		{
			return false;
		}

		public static bool operator !=(SessionToken x, SessionToken y)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public bool Equals(SessionToken other)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		private bool Equals(string otherValue)
		{
			return false;
		}
	}
}
