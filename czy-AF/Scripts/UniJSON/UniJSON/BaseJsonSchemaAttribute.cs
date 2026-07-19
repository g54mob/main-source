using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace UniJSON
{
	public class BaseJsonSchemaAttribute : Attribute
	{
		public string Title;

		public string Description;

		public double Minimum = double.NaN;

		public bool ExclusiveMinimum;

		public double Maximum = double.NaN;

		public bool ExclusiveMaximum;

		public double MultipleOf;

		public string Pattern;

		public int MinItems;

		public int MaxItems;

		public ValueNodeType ValueType;

		public int MinProperties;

		public bool Required;

		public string[] Dependencies;

		public EnumSerializationType EnumSerializationType;

		public object[] EnumValues;

		public object[] EnumExcludes;

		public PropertyExportFlags ExportFlags = PropertyExportFlags.Default;

		public bool SkipSchemaComparison;

		public object ExplicitIgnorableValue;

		public int ExplicitIgnorableItemLength = -1;

		public void Merge(BaseJsonSchemaAttribute rhs)
		{
			if (rhs != null && string.IsNullOrEmpty(Title))
			{
				Title = rhs.Title;
			}
		}

		public virtual string GetInfo(FieldInfo fi)
		{
			return "";
		}

		public static bool IsNumber(Type t)
		{
			if (t == typeof(sbyte) || t == typeof(short) || t == typeof(int) || t == typeof(long) || t == typeof(byte) || t == typeof(ushort) || t == typeof(uint) || t == typeof(ulong) || t == typeof(float) || t == typeof(double))
			{
				return true;
			}
			return false;
		}

		public static string GetTypeName(Type t)
		{
			if (t.IsArray)
			{
				return t.GetElementType().Name + "[]";
			}
			if (t.IsGenericType)
			{
				if (t.GetGenericTypeDefinition() == typeof(List<>))
				{
					return "List<" + t.GetGenericArguments()[0]?.ToString() + ">";
				}
				if (t.GetGenericTypeDefinition() == typeof(Dictionary<, >))
				{
					return "Dictionary<" + string.Join(", ", (from x in t.GetGenericArguments()
						select x.Name).ToArray()) + ">";
				}
			}
			return t.Name;
		}
	}
}
