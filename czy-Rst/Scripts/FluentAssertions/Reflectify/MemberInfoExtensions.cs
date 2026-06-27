using System;
using System.Linq;
using System.Reflection;

namespace Reflectify
{
	internal static class MemberInfoExtensions
	{
		public static bool HasAttribute<TAttribute>(this MemberInfo member) where TAttribute : Attribute
		{
			return Attribute.IsDefined(member, typeof(TAttribute), inherit: false);
		}

		public static bool HasAttribute<TAttribute>(this MemberInfo member, Func<TAttribute, bool> predicate) where TAttribute : Attribute
		{
			if (predicate == null)
			{
				throw new ArgumentNullException("predicate");
			}
			return member.GetCustomAttributes<TAttribute>().Any((TAttribute a) => predicate(a));
		}

		public static bool HasAttributeInHierarchy<TAttribute>(this MemberInfo member) where TAttribute : Attribute
		{
			return Attribute.IsDefined(member, typeof(TAttribute), inherit: true);
		}
	}
}
