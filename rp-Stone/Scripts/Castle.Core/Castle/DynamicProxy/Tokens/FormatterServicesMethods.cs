using System;
using System.Reflection;
using System.Runtime.Serialization;

namespace Castle.DynamicProxy.Tokens
{
	public static class FormatterServicesMethods
	{
		public static readonly MethodInfo GetObjectData = typeof(FormatterServices).GetMethod("GetObjectData", new Type[2]
		{
			typeof(object),
			typeof(MemberInfo[])
		});

		public static readonly MethodInfo GetSerializableMembers = typeof(FormatterServices).GetMethod("GetSerializableMembers", new Type[1] { typeof(Type) });
	}
}
