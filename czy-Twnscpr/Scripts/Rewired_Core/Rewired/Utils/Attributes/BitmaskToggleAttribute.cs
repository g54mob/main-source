using System;
using UnityEngine;

namespace Rewired.Utils.Attributes
{
	public class BitmaskToggleAttribute : PropertyAttribute
	{
		public Type propType;

		public bool showNone;

		public bool showAll;

		public BitmaskToggleAttribute(Type aType)
		{
		}
	}
}
