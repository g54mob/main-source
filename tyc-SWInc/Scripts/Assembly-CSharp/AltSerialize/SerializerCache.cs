using System;
using System.Collections.Generic;

namespace AltSerialize
{
	internal class SerializerCache
	{
		internal class SubHash
		{
			private object _storedObject;

			private int _objectId;

			public object StoredObject
			{
				get
				{
					return _storedObject;
				}
				set
				{
					_storedObject = value;
				}
			}

			public int ObjectID
			{
				get
				{
					return _objectId;
				}
				set
				{
					_objectId = value;
				}
			}

			public SubHash()
			{
			}

			public SubHash(object storedObject, int id)
			{
				StoredObject = storedObject;
				ObjectID = id;
			}

			public override int GetHashCode()
			{
				return StoredObject.GetHashCode();
			}
		}

		private Dictionary<object, int> _hashByObject = new Dictionary<object, int>();

		private List<object> _objList = new List<object>();

		private int _staticID = 1;

		private int _newUniqueID = 1;

		public SerializerCache()
		{
			_objList.Add(0);
		}

		public void Clear()
		{
			Clear(false);
		}

		public void Clear(bool clearPermanant)
		{
			_newUniqueID = 1;
			for (int i = _staticID; i < _objList.Count; i++)
			{
				if (_objList[i] != null)
				{
					_hashByObject.Remove(_objList[i]);
				}
			}
			_objList.RemoveRange(_staticID, _objList.Count - _staticID);
			_newUniqueID = _staticID;
		}

		public int GetObjectCacheID(object obj, Type objectType)
		{
			int value;
			if (_hashByObject.TryGetValue(obj, out value))
			{
				return value;
			}
			return 0;
		}

		public int CacheObject(object obj, bool permanant)
		{
			if (permanant && _staticID != _newUniqueID)
			{
				throw new Exception("Unable to cache item.");
			}
			int newUniqueID = _newUniqueID;
			_newUniqueID++;
			_objList.Insert(newUniqueID, obj);
			_hashByObject[obj] = newUniqueID;
			if (permanant)
			{
				_staticID++;
			}
			return newUniqueID;
		}

		public object GetCachedObject(int uniqueId)
		{
			if (uniqueId < _objList.Count)
			{
				return _objList[uniqueId];
			}
			return null;
		}

		public void SetCachedObjectId(object obj, int uniqueId)
		{
			while (_objList.Count <= uniqueId)
			{
				_objList.Add(null);
			}
			_objList[uniqueId] = obj;
		}
	}
}
