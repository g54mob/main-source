using System;
using System.Collections;
using System.Reflection;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace NUnit.Framework
{
	[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = true, Inherited = false)]
	public class ValueSourceAttribute : DataAttribute, IParameterDataSource
	{
		public string SourceName { get; private set; }

		public Type SourceType { get; private set; }

		public ValueSourceAttribute(string sourceName)
		{
			SourceName = sourceName;
		}

		public ValueSourceAttribute(Type sourceType, string sourceName)
		{
			SourceType = sourceType;
			SourceName = sourceName;
		}

		public IEnumerable GetData(IParameterInfo parameter)
		{
			return GetDataSource(parameter);
		}

		private IEnumerable GetDataSource(IParameterInfo parameter)
		{
			Type type = SourceType ?? parameter.Method.TypeInfo.Type;
			if (SourceName == null)
			{
				return Reflect.Construct(type) as IEnumerable;
			}
			MemberInfo[] member = type.GetMember(SourceName, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy);
			IEnumerable dataSourceValue = GetDataSourceValue(member);
			if (dataSourceValue == null)
			{
				ThrowInvalidDataSourceException();
			}
			return dataSourceValue;
		}

		private static IEnumerable GetDataSourceValue(MemberInfo[] members)
		{
			if (members.Length != 1)
			{
				return null;
			}
			MemberInfo memberInfo = members[0];
			if (memberInfo is FieldInfo fieldInfo)
			{
				if (fieldInfo.IsStatic)
				{
					return (IEnumerable)fieldInfo.GetValue(null);
				}
				ThrowInvalidDataSourceException();
			}
			if (memberInfo is PropertyInfo propertyInfo)
			{
				if (propertyInfo.GetGetMethod(nonPublic: true).IsStatic)
				{
					return (IEnumerable)propertyInfo.GetValue(null, null);
				}
				ThrowInvalidDataSourceException();
			}
			if (memberInfo is MethodInfo methodInfo)
			{
				if (methodInfo.IsStatic)
				{
					return (IEnumerable)methodInfo.Invoke(null, null);
				}
				ThrowInvalidDataSourceException();
			}
			return null;
		}

		private static void ThrowInvalidDataSourceException()
		{
			throw new InvalidDataSourceException("The sourceName specified on a ValueSourceAttribute must refer to a non null static field, property or method.");
		}
	}
}
