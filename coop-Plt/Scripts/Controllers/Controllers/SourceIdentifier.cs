using System;
using MessagePack;

namespace Controllers
{
	[Serializable]
	[MessagePackObject(false)]
	public struct SourceIdentifier : IEquatable<SourceIdentifier>
	{
		[Key(0)]
		public int Value;

		public static implicit operator SourceIdentifier(int x)
		{
			return new SourceIdentifier
			{
				Value = x
			};
		}

		public static implicit operator int(SourceIdentifier x)
		{
			return x.Value;
		}

		public override string ToString()
		{
			return Value.ToString();
		}

		public bool Equals(SourceIdentifier other)
		{
			return Value == other.Value;
		}

		public override bool Equals(object obj)
		{
			if (obj is SourceIdentifier other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return Value;
		}

		public static bool operator ==(SourceIdentifier left, SourceIdentifier right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(SourceIdentifier left, SourceIdentifier right)
		{
			return !left.Equals(right);
		}
	}
}
