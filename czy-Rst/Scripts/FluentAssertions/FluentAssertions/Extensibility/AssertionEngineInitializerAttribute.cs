using System;
using System.Reflection;

namespace FluentAssertions.Extensibility
{
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
	public sealed class AssertionEngineInitializerAttribute : Attribute
	{
		private readonly string methodName;

		private readonly Type type;

		public AssertionEngineInitializerAttribute(Type type, string methodName)
		{
			this.type = type;
			this.methodName = methodName;
		}

		internal void Initialize()
		{
			type?.GetMethod(methodName, BindingFlags.Static | BindingFlags.Public)?.Invoke(null, null);
		}
	}
}
