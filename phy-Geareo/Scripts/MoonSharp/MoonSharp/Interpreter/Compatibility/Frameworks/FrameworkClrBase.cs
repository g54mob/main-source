using System;
using System.Reflection;

namespace MoonSharp.Interpreter.Compatibility.Frameworks
{
	internal abstract class FrameworkClrBase : FrameworkReflectionBase
	{
		private BindingFlags BINDINGFLAGS_MEMBER;

		private BindingFlags BINDINGFLAGS_INNERCLASS;

		public override Type GetTypeInfoFromType(Type t)
		{
			return null;
		}

		public override MethodInfo GetAddMethod(EventInfo ei)
		{
			return null;
		}

		public override ConstructorInfo[] GetConstructors(Type type)
		{
			return null;
		}

		public override EventInfo[] GetEvents(Type type)
		{
			return null;
		}

		public override FieldInfo[] GetFields(Type type)
		{
			return null;
		}

		public override Type[] GetGenericArguments(Type type)
		{
			return null;
		}

		public override MethodInfo GetGetMethod(PropertyInfo pi)
		{
			return null;
		}

		public override Type[] GetInterfaces(Type t)
		{
			return null;
		}

		public override MethodInfo GetMethod(Type type, string name)
		{
			return null;
		}

		public override MethodInfo[] GetMethods(Type type)
		{
			return null;
		}

		public override Type[] GetNestedTypes(Type type)
		{
			return null;
		}

		public override PropertyInfo[] GetProperties(Type type)
		{
			return null;
		}

		public override PropertyInfo GetProperty(Type type, string name)
		{
			return null;
		}

		public override MethodInfo GetRemoveMethod(EventInfo ei)
		{
			return null;
		}

		public override MethodInfo GetSetMethod(PropertyInfo pi)
		{
			return null;
		}

		public override bool IsAssignableFrom(Type current, Type toCompare)
		{
			return false;
		}

		public override bool IsInstanceOfType(Type t, object o)
		{
			return false;
		}

		public override MethodInfo GetMethod(Type resourcesType, string name, Type[] types)
		{
			return null;
		}

		public override Type[] GetAssemblyTypes(Assembly asm)
		{
			return null;
		}
	}
}
