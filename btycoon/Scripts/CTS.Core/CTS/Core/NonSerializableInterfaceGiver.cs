using UnityEngine;

namespace CTS.Core
{
	internal readonly struct NonSerializableInterfaceGiver : IGive, IParentable<Object>
	{
		private readonly IGive<object> _obj;

		public NonSerializableInterfaceGiver(IGive<object> obj)
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
			return _obj.Get();
		}
	}
}
