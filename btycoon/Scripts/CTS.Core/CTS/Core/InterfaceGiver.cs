using System;
using UnityEngine;

namespace CTS.Core
{
	[Serializable]
	internal struct InterfaceGiver : IGive, IParentable<UnityEngine.Object>
	{
		[SerializeField]
		private UnityEngine.Object _obj;

		public InterfaceGiver(UnityEngine.Object giver)
		{
			_obj = giver;
		}

		public bool HasValue()
		{
			return _obj;
		}

		public object Get()
		{
			return ((IGive<UnityEngine.Object>)_obj).Get();
		}

		public UnityEngine.Object GetParent()
		{
			return _obj;
		}
	}
}
