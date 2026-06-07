using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public struct IdString : ISerializationCallbackReceiver, IEquatable<IdString>
	{
		public static readonly IdString EMPTY = new IdString(string.Empty);

		[SerializeField]
		private string m_String;

		[NonSerialized]
		private int m_Hash;

		public string String
		{
			get
			{
				return m_String ?? string.Empty;
			}
			set
			{
				m_String = value;
				m_Hash = value.GetHashCode();
			}
		}

		public int Hash
		{
			get
			{
				if (m_Hash == 0)
				{
					m_Hash = String.GetHashCode();
				}
				return m_Hash;
			}
		}

		public IdString(string value)
		{
			m_String = value;
			m_Hash = 0;
		}

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
			if (!AssemblyUtils.IsReloading && !string.IsNullOrEmpty(m_String))
			{
				m_String = TextUtils.ProcessID(m_String);
				m_Hash = m_String.GetHashCode();
			}
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
			m_Hash = m_String.GetHashCode();
		}

		public override int GetHashCode()
		{
			return Hash;
		}

		public bool Equals(IdString other)
		{
			return Hash == other.Hash;
		}

		public override bool Equals(object other)
		{
			if (other is IdString other2)
			{
				return Equals(other2);
			}
			return false;
		}

		public override string ToString()
		{
			return m_String;
		}

		public static bool operator ==(IdString left, IdString right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(IdString left, IdString right)
		{
			return !left.Equals(right);
		}
	}
}
