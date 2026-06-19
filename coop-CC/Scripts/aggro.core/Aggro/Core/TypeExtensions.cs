using System;

namespace Aggro.Core
{
	public static class TypeExtensions
	{
		public static T GetCustomAttribute<T>(this Enum enumVal) where T : Attribute
		{
			object[] customAttributes = enumVal.GetType().GetMember(enumVal.ToString())[0].GetCustomAttributes(typeof(T), inherit: false);
			if (customAttributes.Length == 0)
			{
				return null;
			}
			return (T)customAttributes[0];
		}
	}
}
