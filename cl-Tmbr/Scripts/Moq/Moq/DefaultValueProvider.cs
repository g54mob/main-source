using System;
using System.Reflection;

namespace Moq
{
	public abstract class DefaultValueProvider
	{
		public static DefaultValueProvider Empty { get; } = new EmptyDefaultValueProvider();

		public static DefaultValueProvider Mock { get; } = new MockDefaultValueProvider();

		internal virtual DefaultValue Kind => DefaultValue.Custom;

		protected internal abstract object GetDefaultValue(Type type, Mock mock);

		protected internal virtual object GetDefaultParameterValue(ParameterInfo parameter, Mock mock)
		{
			return GetDefaultValue(parameter.ParameterType, mock);
		}

		protected internal virtual object GetDefaultReturnValue(MethodInfo method, Mock mock)
		{
			return GetDefaultValue(method.ReturnType, mock);
		}
	}
}
