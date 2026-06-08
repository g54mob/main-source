using System;

namespace Kitchen
{
	public struct MessageIdentifier : IEquatable<MessageIdentifier>
	{
		public ViewIdentifier Identifier;

		public MessageType Type;

		public Type ResponseType;

		public bool Equals(MessageIdentifier other)
		{
			if (Identifier.Equals(other.Identifier) && Type == other.Type)
			{
				return object.Equals(ResponseType, other.ResponseType);
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj is MessageIdentifier other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (int)(((uint)(Identifier.GetHashCode() * 397) ^ (uint)Type) * 397) ^ ((ResponseType != null) ? ResponseType.GetHashCode() : 0);
		}

		public static bool operator ==(MessageIdentifier left, MessageIdentifier right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(MessageIdentifier left, MessageIdentifier right)
		{
			return !left.Equals(right);
		}
	}
}
