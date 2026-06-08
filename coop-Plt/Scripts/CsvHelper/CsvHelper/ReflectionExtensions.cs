using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace CsvHelper
{
	public static class ReflectionExtensions
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Type MemberType(this MemberInfo member)
		{
			PropertyInfo propertyInfo = member as PropertyInfo;
			if (propertyInfo != null)
			{
				return propertyInfo.PropertyType;
			}
			FieldInfo fieldInfo = member as FieldInfo;
			if (fieldInfo != null)
			{
				return fieldInfo.FieldType;
			}
			throw new InvalidOperationException("Member is not a property or a field.");
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static MemberExpression GetMemberExpression(this MemberInfo member, Expression expression)
		{
			PropertyInfo propertyInfo = member as PropertyInfo;
			if (propertyInfo != null)
			{
				return Expression.Property(expression, propertyInfo);
			}
			FieldInfo fieldInfo = member as FieldInfo;
			if (fieldInfo != null)
			{
				return Expression.Field(expression, fieldInfo);
			}
			throw new InvalidOperationException("Member is not a property or a field.");
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsAnonymous(this Type type)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			if (Attribute.IsDefined(type, typeof(CompilerGeneratedAttribute), inherit: false) && type.IsGenericType && type.Name.Contains("AnonymousType") && (type.Name.StartsWith("<>") || type.Name.StartsWith("VB$")))
			{
				return (type.Attributes & TypeAttributes.Public) != TypeAttributes.Public;
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasParameterlessConstructor(this Type type)
		{
			return type.GetConstructor(new Type[0]) != null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasConstructor(this Type type)
		{
			return type.GetConstructors().Length != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ConstructorInfo GetConstructorWithMostParameters(this Type type)
		{
			return (from c in type.GetConstructors()
				orderby c.GetParameters().Length descending
				select c).First();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsUserDefinedStruct(this Type type)
		{
			if (type.IsValueType && !type.IsPrimitive)
			{
				return !type.IsEnum;
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static string GetDefinition(this ConstructorInfo constructor)
		{
			ParameterInfo[] parameters = constructor.GetParameters();
			return constructor.Name + "(" + string.Join(", ", parameters.Select((ParameterInfo p) => p.GetDefinition())) + ")";
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static string GetDefinition(this ParameterInfo parameter)
		{
			return parameter.ParameterType.Name + " " + parameter.Name;
		}
	}
}
