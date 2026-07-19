using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using UnityEngine;

namespace UniJSON
{
	public static class FormatterExtensions
	{
		public static ArraySegment<byte> GetStoreBytes(this IFormatter f)
		{
			return f.GetStore().Bytes;
		}

		public static void Key(this IFormatter f, string x)
		{
			f.Key(Utf8String.From(x));
		}

		public static void Value(this IFormatter f, IEnumerable<byte> raw, int count)
		{
			f.Value(new ArraySegment<byte>(raw.Take(count).ToArray()));
		}

		public static void Value(this IFormatter f, byte[] bytes)
		{
			f.Value(new ArraySegment<byte>(bytes));
		}

		public static void Value(this IFormatter f, Vector2 v)
		{
			f.BeginMap(2);
			f.Key("x");
			f.Value(v.x);
			f.Key("y");
			f.Value(v.y);
			f.EndMap();
		}

		public static void Value(this IFormatter f, Vector3 v)
		{
			f.BeginMap(3);
			f.Key("x");
			f.Value(v.x);
			f.Key("y");
			f.Value(v.y);
			f.Key("z");
			f.Value(v.z);
			f.EndMap();
		}

		public static void Value(this IFormatter f, Vector4 v)
		{
			f.BeginMap(4);
			f.Key("x");
			f.Value(v.x);
			f.Key("y");
			f.Value(v.y);
			f.Key("z");
			f.Value(v.z);
			f.Key("w");
			f.Value(v.w);
			f.EndMap();
		}

		private static MethodInfo GetMethod<T>(Expression<Func<T>> expression)
		{
			return typeof(FormatterExtensions).GetMethod("Serialize").MakeGenericMethod(typeof(T));
		}

		public static void KeyValue<T>(this IFormatter f, Expression<Func<T>> expression)
		{
			MemberExpression memberExpression = (MemberExpression)expression.Body;
			if (memberExpression.Expression.NodeType == ExpressionType.Constant)
			{
				ConstantExpression constantExpression = (ConstantExpression)memberExpression.Expression;
				object value = ((FieldInfo)memberExpression.Member).GetValue(constantExpression.Value);
				if (value != null)
				{
					f.Key(memberExpression.Member.Name);
					f.Serialize(value);
				}
				return;
			}
			MemberExpression obj = (MemberExpression)memberExpression.Expression;
			object value2 = ((ConstantExpression)obj.Expression).Value;
			object value3 = ((FieldInfo)obj.Member).GetValue(value2);
			FieldInfo fieldInfo = (FieldInfo)memberExpression.Member;
			object value4 = fieldInfo.GetValue(value3);
			if (value4 != null)
			{
				f.Key(fieldInfo.Name);
				f.Serialize(value4);
			}
		}
	}
}
