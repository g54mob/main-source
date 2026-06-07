using System;

namespace Rewired.Utils.Classes.Data
{
	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public struct SerializableGuid : IEquatable<SerializableGuid>
	{
		private const int length = 16;

		public static readonly SerializableGuid Empty;

		private long _a;

		private long _b;

		public SerializableGuid(Guid P_0)
		{
			_a = 0L;
			_b = 0L;
		}

		public byte[] GetBytes()
		{
			return null;
		}

		public Guid ToGuid()
		{
			return default(Guid);
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public bool Equals(SerializableGuid other)
		{
			return false;
		}

		public static bool operator ==(SerializableGuid a, SerializableGuid b)
		{
			return false;
		}

		public static bool operator !=(SerializableGuid a, SerializableGuid b)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}

		public string ToString(string format)
		{
			return null;
		}

		public string ToString(string format, IFormatProvider provider)
		{
			return null;
		}
	}
}
