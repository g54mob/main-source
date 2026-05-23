using System;
using UnityEngine.Serialization;

namespace Libs
{
	[Serializable]
	public struct SerializableGuid : IComparable, IComparable<SerializableGuid>, IEquatable<SerializableGuid>
	{
		[FormerlySerializedAs("V")]
		[FormerlySerializedAs("Value")]
		public string v;

		private SerializableGuid(string v)
		{
			this.v = null;
		}

		public static implicit operator SerializableGuid(Guid guid)
		{
			return default(SerializableGuid);
		}

		public static implicit operator Guid(SerializableGuid serializableGuid)
		{
			return default(Guid);
		}

		public int CompareTo(object value)
		{
			return 0;
		}

		public int CompareTo(SerializableGuid other)
		{
			return 0;
		}

		public bool Equals(SerializableGuid other)
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

		public override string ToString()
		{
			return null;
		}

		public static implicit operator bool(SerializableGuid guid)
		{
			return false;
		}

		public static bool operator true(SerializableGuid guid)
		{
			return false;
		}

		public static bool operator false(SerializableGuid guid)
		{
			return false;
		}

		public static bool operator ==(SerializableGuid lhs, SerializableGuid rhs)
		{
			return false;
		}

		public static bool operator !=(SerializableGuid lhs, SerializableGuid rhs)
		{
			return false;
		}
	}
}
