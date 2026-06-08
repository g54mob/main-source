using System;
using MessagePack;

namespace Kitchen
{
	[Serializable]
	[MessagePackObject(false)]
	public struct ProfileIdentifier : IEquatable<ProfileIdentifier>
	{
		[Key(0)]
		public string _Value;

		public static ProfileIdentifier Generic => new ProfileIdentifier
		{
			_Value = "PROFILE"
		};

		public static ProfileIdentifier Default => new ProfileIdentifier
		{
			_Value = "Player"
		};

		public static ProfileIdentifier New(string x)
		{
			return new ProfileIdentifier
			{
				_Value = x
			};
		}

		public static implicit operator string(ProfileIdentifier x)
		{
			return x._Value;
		}

		public static explicit operator ProfileIdentifier(string x)
		{
			return new ProfileIdentifier
			{
				_Value = x
			};
		}

		public override string ToString()
		{
			return _Value;
		}

		public bool Equals(ProfileIdentifier other)
		{
			return _Value == other._Value;
		}

		public override bool Equals(object obj)
		{
			if (obj is ProfileIdentifier other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			if (_Value != null)
			{
				return _Value.GetHashCode();
			}
			return 0;
		}

		public static bool operator ==(ProfileIdentifier left, ProfileIdentifier right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(ProfileIdentifier left, ProfileIdentifier right)
		{
			return !left.Equals(right);
		}
	}
}
