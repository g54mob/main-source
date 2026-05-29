using System;
using UnityEngine;

namespace CTS.Core
{
	[Serializable]
	internal struct ObjectGiver : IGive, IParentable<UnityEngine.Object>
	{
		[SerializeField]
		private UnityEngine.Object _obj;

		public ObjectGiver(UnityEngine.Object obj)
		{
			_obj = obj;
		}

		public bool HasValue()
		{
			return _obj;
		}

		public object Get()
		{
			return _obj;
		}

		public UnityEngine.Object GetParent()
		{
			return _obj;
		}
	}
}
