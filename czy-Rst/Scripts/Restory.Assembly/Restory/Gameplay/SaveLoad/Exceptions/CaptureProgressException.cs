using System;
using UnityEngine;

namespace Restory.Gameplay.SaveLoad.Exceptions
{
	public class CaptureProgressException : Exception
	{
		public CaptureProgressException(GameObject context)
			: base(context ? context.name : "GameObject is Null")
		{
		}

		public CaptureProgressException(GameObject context, Exception innerException)
			: base(context ? context.name : "GameObject is Null", innerException)
		{
		}

		public CaptureProgressException(Type context, Exception innerException)
			: base(context.Name, innerException)
		{
		}
	}
}
