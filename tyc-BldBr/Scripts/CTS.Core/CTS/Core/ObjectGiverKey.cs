using System;
using UnityEngine;

namespace CTS.Core
{
	[Serializable]
	internal struct ObjectGiverKey : IGiveWithKey, IParentable<UnityEngine.Object>
	{
		[SerializeField]
		private UnityEngine.Object _obj;

		public ObjectGiverKey(UnityEngine.Object obj)
		{
			_obj = obj;
		}

		public bool HasValue()
		{
			return _obj;
		}

		public object Get<TKey>(TKey key)
		{
			return _obj;
		}

		public UnityEngine.Object GetParent()
		{
			return _obj;
		}
	}
}
