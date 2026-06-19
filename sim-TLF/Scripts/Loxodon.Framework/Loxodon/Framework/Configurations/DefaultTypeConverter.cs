using System;
using System.Text.RegularExpressions;
using UnityEngine;

namespace Loxodon.Framework.Configurations
{
	public class DefaultTypeConverter : ITypeConverter
	{
		public virtual bool Support(Type type)
		{
			TypeCode typeCode = Type.GetTypeCode(type);
			if ((uint)(typeCode - 3) <= 13u || typeCode == TypeCode.String)
			{
				return true;
			}
			if (type.Equals(typeof(Version)))
			{
				return true;
			}
			if (type.Equals(typeof(Color)))
			{
				return true;
			}
			if (type.Equals(typeof(Vector2)))
			{
				return true;
			}
			if (type.Equals(typeof(Vector3)))
			{
				return true;
			}
			if (type.Equals(typeof(Vector4)))
			{
				return true;
			}
			if (type.Equals(typeof(Rect)))
			{
				return true;
			}
			return false;
		}

		public virtual object Convert(Type type, object value)
		{
			switch (Type.GetTypeCode(type))
			{
			case TypeCode.Boolean:
				if (value is string)
				{
					string text = ((string)value).Trim().ToLower();
					if (text.Equals("yes") || text.Equals("true"))
					{
						return true;
					}
					if (text.Equals("no") || text.Equals("false"))
					{
						return false;
					}
					throw new FormatException();
				}
				return System.Convert.ChangeType(value, type);
			case TypeCode.Char:
			case TypeCode.SByte:
			case TypeCode.Byte:
			case TypeCode.Int16:
			case TypeCode.UInt16:
			case TypeCode.Int32:
			case TypeCode.UInt32:
			case TypeCode.Int64:
			case TypeCode.UInt64:
			case TypeCode.Single:
			case TypeCode.Double:
			case TypeCode.Decimal:
			case TypeCode.DateTime:
			case TypeCode.String:
				return System.Convert.ChangeType(value, type);
			default:
				if (type.Equals(typeof(Version)))
				{
					if (value is Version)
					{
						return (Version)value;
					}
					if (!(value is string))
					{
						throw new FormatException($"This value \"{value}\" cannot be converted to the type \"{type.Name}\"");
					}
					try
					{
						return new Version((string)value);
					}
					catch (Exception innerException)
					{
						throw new FormatException($"This value \"{value}\" cannot be converted to the type \"{type.Name}\"", innerException);
					}
				}
				if (type.Equals(typeof(Color)))
				{
					if (value is Color)
					{
						return (Color)value;
					}
					if (!(value is string))
					{
						throw new FormatException($"This value \"{value}\" cannot be converted to the type \"{type.Name}\"");
					}
					try
					{
						if (ColorUtility.TryParseHtmlString((string)value, out var color))
						{
							return color;
						}
					}
					catch (Exception innerException2)
					{
						throw new FormatException($"This value \"{value}\" cannot be converted to the type \"{type.Name}\"", innerException2);
					}
				}
				else if (type.Equals(typeof(Vector2)))
				{
					if (value is Vector2)
					{
						return (Vector2)value;
					}
					if (!(value is string))
					{
						throw new FormatException($"This value \"{value}\" cannot be converted to the type \"{type.Name}\"");
					}
					try
					{
						string[] array = Regex.Replace(((string)value).Trim(), "(^\\()|(\\)$)", "").Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
						if (array.Length == 2)
						{
							return new Vector2(float.Parse(array[0]), float.Parse(array[1]));
						}
					}
					catch (Exception innerException3)
					{
						throw new FormatException($"This value \"{value}\" cannot be converted to the type \"{type.Name}\"", innerException3);
					}
				}
				else if (type.Equals(typeof(Vector3)))
				{
					if (value is Vector3)
					{
						return (Vector3)value;
					}
					if (!(value is string))
					{
						throw new FormatException($"This value \"{value}\" cannot be converted to the type \"{type.Name}\"");
					}
					try
					{
						string[] array2 = Regex.Replace(((string)value).Trim(), "(^\\()|(\\)$)", "").Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
						if (array2.Length == 3)
						{
							return new Vector3(float.Parse(array2[0]), float.Parse(array2[1]), float.Parse(array2[2]));
						}
					}
					catch (Exception innerException4)
					{
						throw new FormatException($"This value \"{value}\" cannot be converted to the type \"{type.Name}\"", innerException4);
					}
				}
				else if (type.Equals(typeof(Vector4)))
				{
					if (value is Vector4)
					{
						return (Vector4)value;
					}
					if (!(value is string))
					{
						throw new FormatException($"This value \"{value}\" cannot be converted to the type \"{type.Name}\"");
					}
					try
					{
						string[] array3 = Regex.Replace(((string)value).Trim(), "(^\\()|(\\)$)", "").Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
						if (array3.Length == 4)
						{
							return new Vector4(float.Parse(array3[0]), float.Parse(array3[1]), float.Parse(array3[2]), float.Parse(array3[3]));
						}
					}
					catch (Exception innerException5)
					{
						throw new FormatException($"This value \"{value}\" cannot be converted to the type \"{type.Name}\"", innerException5);
					}
				}
				else if (type.Equals(typeof(Rect)))
				{
					if (value is Rect)
					{
						return (Rect)value;
					}
					if (!(value is string))
					{
						throw new FormatException($"This value \"{value}\" cannot be converted to the type \"{type.Name}\"");
					}
					try
					{
						string[] array4 = Regex.Replace(((string)value).Trim(), "(^\\()|(\\)$)", "").Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
						if (array4.Length == 4)
						{
							return new Rect(float.Parse(array4[0]), float.Parse(array4[1]), float.Parse(array4[2]), float.Parse(array4[3]));
						}
					}
					catch (Exception innerException6)
					{
						throw new FormatException($"This value \"{value}\" cannot be converted to the type \"{type.Name}\"", innerException6);
					}
				}
				throw new FormatException($"This value \"{value}\" cannot be converted to the type \"{type.Name}\"");
			}
		}
	}
}
