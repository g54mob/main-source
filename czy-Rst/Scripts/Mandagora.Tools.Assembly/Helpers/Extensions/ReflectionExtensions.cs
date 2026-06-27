using System;
using System.Collections.Generic;
using System.Reflection;

namespace Helpers.Extensions
{
	public static class ReflectionExtensions
	{
		public class Variance
		{
			public string Name { get; set; }

			public Type Type { get; set; }

			public object ValueA { get; set; }

			public object ValueB { get; set; }

			public bool IsSame
			{
				get
				{
					if (ValueA == null && ValueB == null)
					{
						return true;
					}
					if (ValueA == null && ValueB != null)
					{
						return false;
					}
					return ValueA.Equals(ValueB);
				}
			}
		}

		public static List<Variance> DetailedSerializeCompare<T>(this T val1, T val2)
		{
			BindingFlags bindingAttr = BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
			List<Variance> list = new List<Variance>();
			FieldInfo[] fields = val1.GetType().GetFields(bindingAttr);
			foreach (FieldInfo fieldInfo in fields)
			{
				Variance variance = new Variance();
				variance.Name = fieldInfo.Name;
				variance.Type = fieldInfo.FieldType;
				variance.ValueA = fieldInfo.GetValue(val1);
				variance.ValueB = fieldInfo.GetValue(val2);
				if (!variance.IsSame)
				{
					list.Add(variance);
				}
			}
			return list;
		}

		public static List<string> FindDifferenceFieldNames<T>(this T val1, T val2)
		{
			BindingFlags bindingAttr = BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
			List<string> list = new List<string>();
			FieldInfo[] fields = val1.GetType().GetFields(bindingAttr);
			foreach (FieldInfo fieldInfo in fields)
			{
				Variance variance = new Variance();
				variance.Name = fieldInfo.Name;
				variance.Type = fieldInfo.FieldType;
				variance.ValueA = fieldInfo.GetValue(val1);
				variance.ValueB = fieldInfo.GetValue(val2);
				if (!variance.IsSame)
				{
					list.Add(variance.Name);
				}
			}
			return list;
		}
	}
}
