using UnityEngine;

namespace CTS.Core
{
	internal readonly struct NonSerializableObjectGiverKey : IGiveWithKey, IParentable<Object>
	{
		private readonly object _obj;

		public NonSerializableObjectGiverKey(object obj)
		{
			_obj = obj;
		}

		public Object GetParent()
		{
			return null;
		}

		public bool HasValue()
		{
			return _obj != null;
		}

		public object Get<TKey>(TKey key)
		{
			return _obj;
		}
	}
}
