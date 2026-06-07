using System;
using UnityEngine;

namespace Coherence.Cloud
{
	[Serializable]
	public struct CloudUniqueId : IFormattable, IEquatable<CloudUniqueId>
	{
		public static readonly CloudUniqueId None;

		[SerializeField]
		internal string value;

		internal CloudUniqueId(string value)
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

		public bool Equals(CloudUniqueId other)
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

		public static string Serialize(CloudUniqueId userId)
		{
			return null;
		}

		public static CloudUniqueId Deserialize(string serializedUserId)
		{
			return default(CloudUniqueId);
		}

		public static implicit operator string(CloudUniqueId id)
		{
			return null;
		}

		public static implicit operator CloudUniqueId(string id)
		{
			return default(CloudUniqueId);
		}

		public static bool operator ==(CloudUniqueId left, CloudUniqueId right)
		{
			return false;
		}

		public static bool operator !=(CloudUniqueId left, CloudUniqueId right)
		{
			return false;
		}
	}
}
