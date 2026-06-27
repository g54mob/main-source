using System;
using System.Reflection;

namespace NSubstitute.Core
{
	public class DefaultForType : IDefaultForType
	{
		private static readonly object BoxedBoolean = false;

		private static readonly object BoxedInt = 0;

		private static readonly object BoxedLong = 0L;

		private static readonly object BoxedDouble = 0.0;

		public object? GetDefaultFor(Type type)
		{
			if (IsVoid(type))
			{
				return null;
			}
			if (type.GetTypeInfo().IsValueType)
			{
				return DefaultInstanceOfValueType(type);
			}
			return null;
		}

		private bool IsVoid(Type returnType)
		{
			return returnType == typeof(void);
		}

		private object DefaultInstanceOfValueType(Type returnType)
		{
			if (returnType == typeof(bool))
			{
				return BoxedBoolean;
			}
			if (returnType == typeof(int))
			{
				return BoxedInt;
			}
			if (returnType == typeof(long))
			{
				return BoxedLong;
			}
			if (returnType == typeof(double))
			{
				return BoxedDouble;
			}
			return Activator.CreateInstance(returnType);
		}
	}
}
