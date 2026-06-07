using System;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class PropertyGetLocation : TPropertyGet<PropertyTypeGetLocation, Location>
	{
		public PropertyGetLocation()
			: base((PropertyTypeGetLocation)new GetLocationNone())
		{
		}

		public PropertyGetLocation(PropertyTypeGetLocation defaultType)
			: base(defaultType)
		{
		}
	}
}
