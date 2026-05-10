using UnityEngine;

namespace CTS.Core
{
	internal readonly struct NonSerializableObjectGiver : IGive, IParentable<Object>
	{
		private readonly object _obj;

		public NonSerializableObjectGiver(object obj)
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

		public object Get()
		{
			return _obj;
		}
	}
}
