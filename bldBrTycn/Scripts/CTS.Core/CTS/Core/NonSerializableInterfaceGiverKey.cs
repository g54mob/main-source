using UnityEngine;

namespace CTS.Core
{
	internal readonly struct NonSerializableInterfaceGiverKey : IGiveWithKey, IParentable<Object>
	{
		private readonly object _obj;

		public NonSerializableInterfaceGiverKey(object giver)
		{
			_obj = giver;
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
			object obj = _obj;
			if (!(obj is IGive<TKey, object> give))
			{
				if (obj is IGive<object> give2)
				{
					return give2.Get();
				}
				return null;
			}
			return give.Get(key);
		}
	}
}
