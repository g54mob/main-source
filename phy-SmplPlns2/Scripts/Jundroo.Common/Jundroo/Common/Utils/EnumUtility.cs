using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Jundroo.Common.Attributes;

namespace Jundroo.Common.Utils
{
	public static class EnumUtility
	{
		public static TAttribute GetAttribute<TAttribute, TEnum>(TEnum value) where TAttribute : Attribute where TEnum : Enum
		{
			return typeof(TEnum).GetField(Enum.GetName(typeof(TEnum), value)).GetCustomAttribute<TAttribute>();
		}

		public static string GetDisplayName(Type type, object value)
		{
			if (!type.IsEnum)
			{
				throw new ArgumentException("Type must be an enumeration");
			}
			FieldInfo field = type.GetField(Enum.GetName(type, value));
			return field.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName ?? field.Name;
		}

		public static string GetDisplayName<T>(T value) where T : Enum
		{
			FieldInfo field = typeof(T).GetField(Enum.GetName(typeof(T), value));
			return field.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName ?? field.Name;
		}

		public static IList<string> GetDisplayNames<T>() where T : Enum
		{
			FieldInfo[] fields = typeof(T).GetFields(BindingFlags.Static | BindingFlags.Public);
			List<string> list = new List<string>(fields.Length);
			FieldInfo[] array = fields;
			foreach (FieldInfo fieldInfo in array)
			{
				list.Add(fieldInfo.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName ?? fieldInfo.Name);
			}
			return list;
		}

		public static IList<KeyValuePair<T, string>> GetDisplayNamesAndValues<T>() where T : Enum
		{
			FieldInfo[] fields = typeof(T).GetFields(BindingFlags.Static | BindingFlags.Public);
			List<KeyValuePair<T, string>> list = new List<KeyValuePair<T, string>>(fields.Length);
			FieldInfo[] array = fields;
			foreach (FieldInfo fieldInfo in array)
			{
				list.Add(new KeyValuePair<T, string>((T)fieldInfo.GetValue(null), fieldInfo.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName ?? fieldInfo.Name));
			}
			return list;
		}

		public static IList<string> GetNames<T>() where T : Enum
		{
			return Enum.GetNames(typeof(T));
		}

		public static IList<T> GetValues<T>() where T : Enum
		{
			return (T[])Enum.GetValues(typeof(T));
		}

		public static T NextEnum<T>(T src) where T : Enum
		{
			T[] array = (T[])Enum.GetValues(typeof(T));
			int num = Array.IndexOf(array, src) + 1;
			if (array.Length != num)
			{
				return array[num];
			}
			return array[0];
		}

		public static T Parse<T>(string value) where T : Enum
		{
			return (T)Enum.Parse(typeof(T), value, ignoreCase: true);
		}

		public static T ParseFromDisplayName<T>(string displayName) where T : Enum
		{
			FieldInfo[] fields = typeof(T).GetFields(BindingFlags.Static | BindingFlags.Public);
			foreach (FieldInfo fieldInfo in fields)
			{
				if ((fieldInfo.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName ?? fieldInfo.Name) == displayName)
				{
					return (T)fieldInfo.GetValue(null);
				}
			}
			throw new ArgumentException(displayName + " is not a valid display name for type: " + typeof(T).Name);
		}
	}
	public static class EnumUtility<T> where T : struct, Enum
	{
		private static readonly string[] _displayNames;

		private static readonly FieldInfo[] _fields;

		private static readonly string[] _names;

		private static readonly int _valueCount;

		private static readonly KeyValuePair<T, string>[] _valueDisplayNamePair;

		private static readonly KeyValuePair<T, string>[] _valueNamePair;

		private static readonly T[] _values;

		private static int _byteSize;

		private static Type _underlyingType;

		private static IEqualityComparer<T> _valueEqualityComparer;

		public static int ByteSize => _byteSize;

		public static IReadOnlyList<string> DisplayNames => _displayNames;

		public static IReadOnlyList<FieldInfo> Fields => _fields;

		public static IReadOnlyList<string> Names => _names;

		public static Type UnderlyingType => _underlyingType;

		public static IReadOnlyList<T> Values => _values;

		public static IReadOnlyList<KeyValuePair<T, string>> ValuesAndDisplayNames => _valueDisplayNamePair;

		public static IReadOnlyList<KeyValuePair<T, string>> ValuesAndNames => _valueNamePair;

		static EnumUtility()
		{
			_fields = typeof(T).GetFields(BindingFlags.Static | BindingFlags.Public);
			_valueCount = _fields.Length;
			_underlyingType = typeof(T).GetEnumUnderlyingType();
			_byteSize = Unsafe.SizeOf<T>();
			_values = new T[_valueCount];
			_names = new string[_valueCount];
			_displayNames = new string[_valueCount];
			_valueNamePair = new KeyValuePair<T, string>[_valueCount];
			_valueDisplayNamePair = new KeyValuePair<T, string>[_valueCount];
			for (int i = 0; i < _valueCount; i++)
			{
				FieldInfo fieldInfo = _fields[i];
				string name = fieldInfo.Name;
				T val = (T)fieldInfo.GetValue(null);
				_values[i] = val;
				_names[i] = name;
				_displayNames[i] = fieldInfo.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName ?? name.PascalCaseToDisplay();
				_valueNamePair[i] = new KeyValuePair<T, string>(val, name);
				_valueDisplayNamePair[i] = new KeyValuePair<T, string>(val, _displayNames[i]);
			}
			_valueEqualityComparer = EqualityComparer<T>.Default;
		}

		public static string DisplayName(T value)
		{
			int num = IndexOfValue(value);
			if (num < 0)
			{
				return value.ToString();
			}
			return _displayNames[num];
		}

		public static TAttribute GetAttribute<TAttribute>(T value) where TAttribute : Attribute
		{
			int num = IndexOfValue(value);
			if (num < 0)
			{
				return null;
			}
			return _fields[num].GetCustomAttribute<TAttribute>();
		}

		public static int IndexOfDisplayName(string displayName)
		{
			for (int i = 0; i < _valueCount; i++)
			{
				if (_displayNames[i] == displayName)
				{
					return i;
				}
			}
			return -1;
		}

		public static int IndexOfName(string name)
		{
			for (int i = 0; i < _valueCount; i++)
			{
				if (_names[i] == name)
				{
					return i;
				}
			}
			return -1;
		}

		public static int IndexOfValue(T value)
		{
			for (int i = 0; i < _valueCount; i++)
			{
				if (_valueEqualityComparer.Equals(_values[i], value))
				{
					return i;
				}
			}
			return -1;
		}

		public static T NextEnum(T value)
		{
			int num = (IndexOfValue(value) + 1) % _valueCount;
			return _values[num];
		}

		public static T Parse(string value, bool ignoreCase = true)
		{
			return Enum.Parse<T>(value, ignoreCase);
		}

		public static T Parse(ReadOnlySpan<char> value, bool ignoreCase = true)
		{
			return Enum.Parse<T>(value.ToString(), ignoreCase);
		}

		public static T ParseFromDisplayName(string displayName)
		{
			int num = IndexOfDisplayName(displayName);
			if (num < 0)
			{
				throw new ArgumentException(displayName + " is not a valid display name for type: " + typeof(T).Name);
			}
			return _values[num];
		}

		public static T PreviousEnum(T value)
		{
			int num = IndexOfValue(value) - 1;
			if (num < 0)
			{
				return _values[_valueCount - 1];
			}
			return _values[num];
		}

		public static bool TryParse(string value, out T result)
		{
			return Enum.TryParse<T>(value, out result);
		}

		public static bool TryParse(string value, bool ignoreCase, out T result)
		{
			return Enum.TryParse<T>(value, ignoreCase, out result);
		}

		public static bool TryParse(ReadOnlySpan<char> value, out T result)
		{
			return Enum.TryParse<T>(value.ToString(), out result);
		}

		public static bool TryParse(ReadOnlySpan<char> value, bool ignoreCase, out T result)
		{
			return Enum.TryParse<T>(value.ToString(), ignoreCase, out result);
		}
	}
}
