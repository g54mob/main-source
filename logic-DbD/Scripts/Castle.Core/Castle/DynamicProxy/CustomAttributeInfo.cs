using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;

namespace Castle.DynamicProxy
{
	public class CustomAttributeInfo : IEquatable<CustomAttributeInfo>
	{
		private class AttributeArgumentValueEqualityComparer : IEqualityComparer<object>
		{
			bool IEqualityComparer<object>.Equals(object x, object y)
			{
				if (x == y)
				{
					return true;
				}
				if (x == null || y == null)
				{
					return false;
				}
				if (x.GetType() != y.GetType())
				{
					return false;
				}
				if (x.GetType().IsArray)
				{
					return AsObjectEnumerable(x).SequenceEqual(AsObjectEnumerable(y));
				}
				return x.Equals(y);
			}

			int IEqualityComparer<object>.GetHashCode(object obj)
			{
				if (obj == null)
				{
					return 0;
				}
				if (obj.GetType().IsArray)
				{
					return CombineHashCodes(AsObjectEnumerable(obj));
				}
				return obj.GetHashCode();
			}

			private static IEnumerable<object> AsObjectEnumerable(object array)
			{
				if (array.GetType().GetElementType().IsValueType)
				{
					return ((Array)array).Cast<object>();
				}
				return (IEnumerable<object>)array;
			}
		}

		private static readonly PropertyInfo[] EmptyProperties = new PropertyInfo[0];

		private static readonly FieldInfo[] EmptyFields = new FieldInfo[0];

		private static readonly object[] EmptyValues = new object[0];

		private static readonly IEqualityComparer<object> ValueComparer = new AttributeArgumentValueEqualityComparer();

		private readonly CustomAttributeBuilder builder;

		private readonly ConstructorInfo constructor;

		private readonly object[] constructorArgs;

		private readonly IDictionary<string, object> properties;

		private readonly IDictionary<string, object> fields;

		internal CustomAttributeBuilder Builder => builder;

		public CustomAttributeInfo(ConstructorInfo constructor, object[] constructorArgs, PropertyInfo[] namedProperties, object[] propertyValues, FieldInfo[] namedFields, object[] fieldValues)
		{
			builder = new CustomAttributeBuilder(constructor, constructorArgs, namedProperties, propertyValues, namedFields, fieldValues);
			this.constructor = constructor;
			this.constructorArgs = ((constructorArgs.Length == 0) ? EmptyValues : constructorArgs.ToArray());
			properties = MakeNameValueDictionary(namedProperties, propertyValues);
			fields = MakeNameValueDictionary(namedFields, fieldValues);
		}

		public CustomAttributeInfo(ConstructorInfo constructor, object[] constructorArgs, PropertyInfo[] namedProperties, object[] propertyValues)
			: this(constructor, constructorArgs, namedProperties, propertyValues, EmptyFields, EmptyValues)
		{
		}

		public CustomAttributeInfo(ConstructorInfo constructor, object[] constructorArgs, FieldInfo[] namedFields, object[] fieldValues)
			: this(constructor, constructorArgs, EmptyProperties, EmptyValues, namedFields, fieldValues)
		{
		}

		public CustomAttributeInfo(ConstructorInfo constructor, object[] constructorArgs)
			: this(constructor, constructorArgs, EmptyProperties, EmptyValues, EmptyFields, EmptyValues)
		{
		}

		public static CustomAttributeInfo FromExpression(Expression<Func<Attribute>> expression)
		{
			List<PropertyInfo> list = new List<PropertyInfo>();
			List<object> list2 = new List<object>();
			List<FieldInfo> list3 = new List<FieldInfo>();
			List<object> list4 = new List<object>();
			Expression expression2 = UnwrapBody(expression.Body);
			NewExpression newExpression = expression2 as NewExpression;
			if (newExpression == null)
			{
				MemberInitExpression obj = (expression2 as MemberInitExpression) ?? throw new ArgumentException("The expression must be either a simple constructor call or an object initializer expression");
				newExpression = obj.NewExpression;
				foreach (MemberBinding binding in obj.Bindings)
				{
					if (!(binding is MemberAssignment memberAssignment))
					{
						throw new ArgumentException("Only assignment bindings are supported");
					}
					object attributeArgumentValue = GetAttributeArgumentValue(memberAssignment.Expression, allowArray: true);
					PropertyInfo propertyInfo = memberAssignment.Member as PropertyInfo;
					if (propertyInfo != null)
					{
						list.Add(propertyInfo);
						list2.Add(attributeArgumentValue);
						continue;
					}
					FieldInfo fieldInfo = memberAssignment.Member as FieldInfo;
					if (fieldInfo != null)
					{
						list3.Add(fieldInfo);
						list4.Add(attributeArgumentValue);
						continue;
					}
					throw new ArgumentException("Only property and field assignments are supported");
				}
			}
			List<object> list5 = new List<object>();
			foreach (Expression argument in newExpression.Arguments)
			{
				object attributeArgumentValue2 = GetAttributeArgumentValue(argument, allowArray: true);
				list5.Add(attributeArgumentValue2);
			}
			return new CustomAttributeInfo(newExpression.Constructor, list5.ToArray(), list.ToArray(), list2.ToArray(), list3.ToArray(), list4.ToArray());
		}

		private static Expression UnwrapBody(Expression body)
		{
			if (body is UnaryExpression { NodeType: ExpressionType.Convert } unaryExpression)
			{
				return unaryExpression.Operand;
			}
			return body;
		}

		private static object GetAttributeArgumentValue(Expression arg, bool allowArray)
		{
			switch (arg.NodeType)
			{
			case ExpressionType.Constant:
				return ((ConstantExpression)arg).Value;
			case ExpressionType.MemberAccess:
			{
				MemberExpression memberExpression = (MemberExpression)arg;
				if (memberExpression.Member is FieldInfo fieldInfo && memberExpression.Expression is ConstantExpression constantExpression && IsCompilerGenerated(constantExpression.Type) && constantExpression.Value != null)
				{
					return fieldInfo.GetValue(constantExpression.Value);
				}
				break;
			}
			case ExpressionType.NewArrayInit:
			{
				if (!allowArray)
				{
					break;
				}
				NewArrayExpression newArrayExpression = (NewArrayExpression)arg;
				Array array = Array.CreateInstance(newArrayExpression.Type.GetElementType(), newArrayExpression.Expressions.Count);
				int num = 0;
				{
					foreach (Expression expression in newArrayExpression.Expressions)
					{
						object attributeArgumentValue = GetAttributeArgumentValue(expression, allowArray: false);
						array.SetValue(attributeArgumentValue, num);
						num++;
					}
					return array;
				}
			}
			}
			throw new ArgumentException("Only constant, local variables, method parameters and single-dimensional array expressions are supported");
		}

		private static bool IsCompilerGenerated(Type type)
		{
			return type.IsDefined(typeof(CompilerGeneratedAttribute));
		}

		public bool Equals(CustomAttributeInfo other)
		{
			if (other == null)
			{
				return false;
			}
			if (this == other)
			{
				return true;
			}
			if (constructor.Equals(other.constructor) && constructorArgs.SequenceEqual(other.constructorArgs, ValueComparer) && AreMembersEquivalent(properties, other.properties))
			{
				return AreMembersEquivalent(fields, other.fields);
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (this == obj)
			{
				return true;
			}
			if (obj.GetType() != GetType())
			{
				return false;
			}
			return Equals((CustomAttributeInfo)obj);
		}

		public override int GetHashCode()
		{
			return (((((constructor.GetHashCode() * 397) ^ CombineHashCodes(constructorArgs)) * 397) ^ CombineMemberHashCodes(properties)) * 397) ^ CombineMemberHashCodes(fields);
		}

		private static bool AreMembersEquivalent(IDictionary<string, object> x, IDictionary<string, object> y)
		{
			if (x.Count != y.Count)
			{
				return false;
			}
			foreach (KeyValuePair<string, object> item in x)
			{
				if (!y.TryGetValue(item.Key, out var value))
				{
					return false;
				}
				if (!ValueComparer.Equals(item.Value, value))
				{
					return false;
				}
			}
			return true;
		}

		private static int CombineHashCodes(IEnumerable<object> values)
		{
			int num = 173;
			foreach (object value in values)
			{
				num = (num * 397) ^ ValueComparer.GetHashCode(value);
			}
			return num;
		}

		private static int CombineMemberHashCodes(IDictionary<string, object> dict)
		{
			int num = 0;
			foreach (KeyValuePair<string, object> item in dict)
			{
				int hashCode = item.Key.GetHashCode();
				int hashCode2 = ValueComparer.GetHashCode(item.Value);
				num += (hashCode * 397) ^ hashCode2;
			}
			return num;
		}

		private IDictionary<string, object> MakeNameValueDictionary<T>(T[] members, object[] values) where T : MemberInfo
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			for (int i = 0; i < members.Length; i++)
			{
				dictionary.Add(members[i].Name, values[i]);
			}
			return dictionary;
		}
	}
}
