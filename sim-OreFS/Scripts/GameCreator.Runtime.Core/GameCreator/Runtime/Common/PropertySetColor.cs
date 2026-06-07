using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class PropertySetColor : TPropertySet<PropertyTypeSetColor, Color>
	{
		public PropertySetColor()
			: base((PropertyTypeSetColor)new SetColorNone())
		{
		}

		public PropertySetColor(PropertyTypeSetColor defaultType)
			: base(defaultType)
		{
		}
	}
}
