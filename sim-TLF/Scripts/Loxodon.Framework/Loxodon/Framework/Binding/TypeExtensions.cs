using System;
using System.Reflection;

namespace Loxodon.Framework.Binding
{
	public static class TypeExtensions
	{
		public static MemberInfo FindFirstMemberInfo(this Type type, string name)
		{
			MemberInfo[] member = type.GetMember(name);
			if (member == null || member.Length == 0)
			{
				return null;
			}
			return member[0];
		}

		public static MemberInfo FindFirstMemberInfo(this Type type, string name, BindingFlags flags)
		{
			MemberInfo[] member = type.GetMember(name, flags);
			if (member == null || member.Length == 0)
			{
				return null;
			}
			return member[0];
		}
	}
}
