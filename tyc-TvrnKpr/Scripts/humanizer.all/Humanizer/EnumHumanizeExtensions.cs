using System;
using System.Reflection;

namespace Humanizer
{
	public static class EnumHumanizeExtensions
	{
		private const string DisplayAttributeTypeName = "System.ComponentModel.DataAnnotations.DisplayAttribute";

		private const string DisplayAttributeGetDescriptionMethodName = "GetDescription";

		private const string DisplayAttributeGetNameMethodName = "GetName";

		private static readonly Func<PropertyInfo, bool> StringTypedProperty;

		public static string Humanize(this Enum input)
		{
			return null;
		}

		private static bool IsBitFieldEnum(TypeInfo typeInfo)
		{
			return false;
		}

		private static string GetCustomDescription(MemberInfo memberInfo)
		{
			return null;
		}

		public static string Humanize(this Enum input, LetterCasing casing)
		{
			return null;
		}
	}
}
