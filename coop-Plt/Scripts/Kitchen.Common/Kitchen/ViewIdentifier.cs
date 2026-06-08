using System;
using MessagePack;

namespace Kitchen
{
	[Serializable]
	[MessagePackObject(false)]
	public struct ViewIdentifier : IEquatable<ViewIdentifier>
	{
		[Key(0)]
		public int Identifier;

		[IgnoreMember]
		public bool IsNullEntity => Identifier == 0;

		public bool Equals(ViewIdentifier other)
		{
			return Identifier == other.Identifier;
		}

		public override bool Equals(object obj)
		{
			if (obj is ViewIdentifier other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return Identifier;
		}

		public static bool operator ==(ViewIdentifier left, ViewIdentifier right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(ViewIdentifier left, ViewIdentifier right)
		{
			return !left.Equals(right);
		}

		public static implicit operator ViewIdentifier(CLinkedView lv)
		{
			return lv.Identifier;
		}
	}
}
