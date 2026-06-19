using System;

namespace Loxodon.Framework.Localizations
{
	public class PrimitiveTypeConverter : ITypeConverter
	{
		public bool Support(string typeName)
		{
			switch (typeName)
			{
			case "string":
			case "boolean":
			case "sbyte":
			case "byte":
			case "short":
			case "ushort":
			case "int":
			case "uint":
			case "long":
			case "ulong":
			case "char":
			case "float":
			case "double":
			case "decimal":
			case "datetime":
				return true;
			default:
				return false;
			}
		}

		public Type GetType(string typeName)
		{
			return typeName switch
			{
				"string" => typeof(string), 
				"boolean" => typeof(bool), 
				"sbyte" => typeof(sbyte), 
				"byte" => typeof(byte), 
				"short" => typeof(short), 
				"ushort" => typeof(ushort), 
				"int" => typeof(int), 
				"uint" => typeof(uint), 
				"long" => typeof(long), 
				"ulong" => typeof(ulong), 
				"char" => typeof(char), 
				"float" => typeof(float), 
				"double" => typeof(double), 
				"decimal" => typeof(decimal), 
				"datetime" => typeof(DateTime), 
				_ => throw new NotSupportedException(), 
			};
		}

		public object Convert(Type type, object value)
		{
			return System.Convert.ChangeType(value, type);
		}
	}
}
