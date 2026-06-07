using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class PropertyGetColor : TPropertyGet<PropertyTypeGetColor, Color>
	{
		public PropertyGetColor()
			: base((PropertyTypeGetColor)new GetColorValue())
		{
		}

		public PropertyGetColor(PropertyTypeGetColor defaultType)
			: base(defaultType)
		{
		}

		public PropertyGetColor(Color value)
			: base((PropertyTypeGetColor)new GetColorValue(value))
		{
		}
	}
}
