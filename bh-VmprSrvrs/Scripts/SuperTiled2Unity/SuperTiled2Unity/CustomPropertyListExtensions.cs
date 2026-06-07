using System.Collections.Generic;

namespace SuperTiled2Unity
{
	public static class CustomPropertyListExtensions
	{
		public static bool TryGetProperty(this List<CustomProperty> list, string propertyName, out CustomProperty property)
		{
			property = null;
			return false;
		}
	}
}
