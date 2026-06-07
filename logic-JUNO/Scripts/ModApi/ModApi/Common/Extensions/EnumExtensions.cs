using System;
using System.Reflection;
using ModApi.Common.Attributes;

namespace ModApi.Common.Extensions
{
	public static class EnumExtensions
	{
		public static string DisplayName(this Enum value)
		{
			Type type = value.GetType();
			string name = Enum.GetName(type, value);
			if (name != null)
			{
				FieldInfo field = type.GetField(name);
				if (field != null && Attribute.GetCustomAttribute(field, typeof(DisplayNameAttribute)) is DisplayNameAttribute displayNameAttribute)
				{
					return displayNameAttribute.DisplayName;
				}
			}
			return value.ToString();
		}
	}
}
