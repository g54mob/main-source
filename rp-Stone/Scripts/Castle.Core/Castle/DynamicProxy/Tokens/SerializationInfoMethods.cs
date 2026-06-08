using System;
using System.Reflection;
using System.Runtime.Serialization;

namespace Castle.DynamicProxy.Tokens
{
	public static class SerializationInfoMethods
	{
		public static readonly MethodInfo AddValue_Bool = typeof(SerializationInfo).GetMethod("AddValue", new Type[2]
		{
			typeof(string),
			typeof(bool)
		});

		public static readonly MethodInfo AddValue_Int32 = typeof(SerializationInfo).GetMethod("AddValue", new Type[2]
		{
			typeof(string),
			typeof(int)
		});

		public static readonly MethodInfo AddValue_Object = typeof(SerializationInfo).GetMethod("AddValue", new Type[2]
		{
			typeof(string),
			typeof(object)
		});

		public static readonly MethodInfo GetValue = typeof(SerializationInfo).GetMethod("GetValue", new Type[2]
		{
			typeof(string),
			typeof(Type)
		});

		public static readonly MethodInfo SetType = typeof(SerializationInfo).GetMethod("SetType");
	}
}
