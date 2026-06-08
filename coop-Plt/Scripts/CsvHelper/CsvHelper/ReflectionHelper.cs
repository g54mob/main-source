using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;

namespace CsvHelper
{
	internal static class ReflectionHelper
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static PropertyInfo GetDeclaringProperty(Type type, PropertyInfo property, BindingFlags flags)
		{
			if (property.DeclaringType != type)
			{
				PropertyInfo property2 = property.DeclaringType.GetProperty(property.Name, flags);
				return GetDeclaringProperty(property.DeclaringType, property2, flags);
			}
			return property;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static FieldInfo GetDeclaringField(Type type, FieldInfo field, BindingFlags flags)
		{
			if (field.DeclaringType != type)
			{
				FieldInfo field2 = field.DeclaringType.GetField(field.Name, flags);
				return GetDeclaringField(field.DeclaringType, field2, flags);
			}
			return field;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static List<PropertyInfo> GetUniqueProperties(Type type, BindingFlags flags, bool overwrite = false)
		{
			bool flag = type.GetCustomAttribute(typeof(IgnoreBaseAttribute)) != null;
			Dictionary<string, PropertyInfo> dictionary = new Dictionary<string, PropertyInfo>();
			flags |= BindingFlags.DeclaredOnly;
			Type type2 = type;
			while (type2 != null)
			{
				PropertyInfo[] properties = type2.GetProperties(flags);
				foreach (PropertyInfo propertyInfo in properties)
				{
					if (!dictionary.ContainsKey(propertyInfo.Name) || overwrite)
					{
						dictionary[propertyInfo.Name] = propertyInfo;
					}
				}
				if (flag)
				{
					break;
				}
				type2 = type2.BaseType;
			}
			return dictionary.Values.ToList();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static List<FieldInfo> GetUniqueFields(Type type, BindingFlags flags, bool overwrite = false)
		{
			bool flag = type.GetCustomAttribute(typeof(IgnoreBaseAttribute)) != null;
			Dictionary<string, FieldInfo> dictionary = new Dictionary<string, FieldInfo>();
			flags |= BindingFlags.DeclaredOnly;
			Type type2 = type;
			while (type2 != null)
			{
				FieldInfo[] fields = type2.GetFields(flags);
				foreach (FieldInfo fieldInfo in fields)
				{
					if (!dictionary.ContainsKey(fieldInfo.Name) || overwrite)
					{
						dictionary[fieldInfo.Name] = fieldInfo;
					}
				}
				if (flag)
				{
					break;
				}
				type2 = type2.BaseType;
			}
			return dictionary.Values.ToList();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static MemberInfo GetMember<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression)
		{
			MemberInfo member = GetMemberExpression(expression.Body).Member;
			PropertyInfo propertyInfo = member as PropertyInfo;
			if (propertyInfo != null)
			{
				return propertyInfo;
			}
			FieldInfo fieldInfo = member as FieldInfo;
			if (fieldInfo != null)
			{
				return fieldInfo;
			}
			throw new ConfigurationException("'" + member.Name + "' is not a member.");
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Stack<MemberInfo> GetMembers<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression)
		{
			Stack<MemberInfo> stack = new Stack<MemberInfo>();
			Expression expression2 = expression.Body;
			while (true)
			{
				MemberExpression memberExpression = GetMemberExpression(expression2);
				if (memberExpression == null)
				{
					break;
				}
				stack.Push(memberExpression.Member);
				expression2 = memberExpression.Expression;
			}
			return stack;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static MemberExpression GetMemberExpression(Expression expression)
		{
			MemberExpression result = null;
			if (expression.NodeType == ExpressionType.Convert)
			{
				result = ((UnaryExpression)expression).Operand as MemberExpression;
			}
			else if (expression.NodeType == ExpressionType.MemberAccess)
			{
				result = expression as MemberExpression;
			}
			return result;
		}
	}
}
