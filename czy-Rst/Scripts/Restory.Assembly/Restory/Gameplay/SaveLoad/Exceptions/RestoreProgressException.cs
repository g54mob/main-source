using System;
using UnityEngine;

namespace Restory.Gameplay.SaveLoad.Exceptions
{
	[Serializable]
	public class RestoreProgressException : Exception
	{
		public RestoreProgressException(GameObject context, object data, Exception innerException)
			: base((context ? context.name : "GameObject is Null") + "\n Data: " + data, innerException)
		{
		}

		public RestoreProgressException(Type context, object data, Exception innerException)
			: base(context.Name + "\n Data: " + data, innerException)
		{
		}

		public RestoreProgressException(GameObject context, object data)
			: base((context ? context.name : "GameObject is Null") + "\n Data: " + data)
		{
		}

		public RestoreProgressException(Type context, object data)
			: base(context.Name + "\n Data: " + data)
		{
		}
	}
}
