using System;
using System.Reflection;

namespace MoonSharp.Interpreter.Compatibility.Frameworks
{
	internal abstract class FrameworkReflectionBase : FrameworkBase
	{
		public abstract Type GetTypeInfoFromType(Type t);

		public override Assembly GetAssembly(Type t)
		{
			return null;
		}

		public override Type GetBaseType(Type t)
		{
			return null;
		}

		public override bool IsValueType(Type t)
		{
			return false;
		}

		public override bool IsInterface(Type t)
		{
			return false;
		}

		public override bool IsNestedPublic(Type t)
		{
			return false;
		}

		public override bool IsAbstract(Type t)
		{
			return false;
		}

		public override bool IsEnum(Type t)
		{
			return false;
		}

		public override bool IsGenericTypeDefinition(Type t)
		{
			return false;
		}

		public override bool IsGenericType(Type t)
		{
			return false;
		}

		public override Attribute[] GetCustomAttributes(Type t, bool inherit)
		{
			return null;
		}

		public override Attribute[] GetCustomAttributes(Type t, Type at, bool inherit)
		{
			return null;
		}
	}
}
