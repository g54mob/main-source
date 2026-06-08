using System;
using UnityEngine;

namespace Bewildered.SmartLibrary
{
	[Serializable]
	public struct UniqueID : ISerializationCallbackReceiver
	{
		private Guid _guid;

		[SerializeField]
		private byte[] _serializedGuid;

		public static readonly UniqueID Empty = new UniqueID
		{
			_guid = Guid.Empty,
			_serializedGuid = null
		};

		public UniqueID(string id)
		{
			_guid = new Guid(id);
			_serializedGuid = _guid.ToByteArray();
		}

		public UniqueID(byte[] b)
		{
			_guid = new Guid(b);
			_serializedGuid = b;
		}

		public static UniqueID NewUniqueId()
		{
			Guid guid = Guid.NewGuid();
			return new UniqueID
			{
				_guid = guid,
				_serializedGuid = guid.ToByteArray()
			};
		}

		public static bool operator ==(UniqueID lhs, UniqueID rhs)
		{
			return lhs._guid == rhs._guid;
		}

		public static bool operator !=(UniqueID lhs, UniqueID rhs)
		{
			return lhs._guid != rhs._guid;
		}

		public override bool Equals(object obj)
		{
			if (obj is UniqueID uniqueID)
			{
				return _guid.Equals(uniqueID._guid);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return _guid.GetHashCode();
		}

		public override string ToString()
		{
			return _guid.ToString();
		}

		public byte[] ToByteArray()
		{
			return _serializedGuid;
		}

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
			if (_guid != Guid.Empty)
			{
				_serializedGuid = _guid.ToByteArray();
			}
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
			if (_serializedGuid != null && _serializedGuid.Length == 16)
			{
				_guid = new Guid(_serializedGuid);
			}
		}
	}
}
