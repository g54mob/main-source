using System;
using UnityEngine;

namespace CTS.Core
{
	[Serializable]
	internal struct InterfaceGiverKey : IGiveWithKey, IParentable<UnityEngine.Object>
	{
		[SerializeField]
		private UnityEngine.Object _obj;

		public InterfaceGiverKey(UnityEngine.Object giver)
		{
			_obj = giver;
		}

		public bool HasValue()
		{
			return _obj;
		}

		public object Get<TKey>(TKey key)
		{
			UnityEngine.Object obj = _obj;
			if (!(obj is IGive<TKey, UnityEngine.Object> give))
			{
				if (obj is IGive<UnityEngine.Object> give2)
				{
					return give2.Get();
				}
				return null;
			}
			return give.Get(key);
		}

		public UnityEngine.Object GetParent()
		{
			return _obj;
		}
	}
}
