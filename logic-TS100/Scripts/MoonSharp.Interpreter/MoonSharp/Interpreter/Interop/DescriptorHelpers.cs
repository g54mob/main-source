using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MoonSharp.Interpreter.Interop
{
	public static class DescriptorHelpers
	{
		public static bool? GetVisibilityFromAttributes(this MemberInfo mi)
		{
			if (mi == null)
			{
				return false;
			}
			MoonSharpVisibleAttribute moonSharpVisibleAttribute = mi.GetCustomAttributes(true).OfType<MoonSharpVisibleAttribute>().SingleOrDefault();
			if (moonSharpVisibleAttribute != null)
			{
				return moonSharpVisibleAttribute.Visible;
			}
			return null;
		}

		public static bool IsPropertyInfoPublic(this PropertyInfo pi)
		{
			MethodInfo getMethod = pi.GetGetMethod();
			MethodInfo setMethod = pi.GetSetMethod();
			if (getMethod == null || !getMethod.IsPublic)
			{
				if (setMethod != null)
				{
					return setMethod.IsPublic;
				}
				return false;
			}
			return true;
		}

		public static List<string> GetMetaNamesFromAttributes(this MethodInfo mi)
		{
			return (from a in mi.GetCustomAttributes(typeof(MoonSharpUserDataMetamethodAttribute), true).OfType<MoonSharpUserDataMetamethodAttribute>()
				select a.Name).ToList();
		}

		public static string GetConversionMethodName(this Type type)
		{
			StringBuilder stringBuilder = new StringBuilder(type.Name);
			for (int i = 0; i < stringBuilder.Length; i++)
			{
				if (!char.IsLetterOrDigit(stringBuilder[i]))
				{
					stringBuilder[i] = '_';
				}
			}
			return "__to" + stringBuilder.ToString();
		}
	}
}
