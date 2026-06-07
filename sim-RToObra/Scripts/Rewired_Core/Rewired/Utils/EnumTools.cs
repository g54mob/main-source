using System;

namespace Rewired.Utils
{
	public static class EnumTools
	{
		public static string GetName<TEnum>(TEnum value) where TEnum : struct, IComparable, IFormattable
		{
			try
			{
				return Enum.GetName(typeof(TEnum), value);
			}
			catch
			{
				return null;
			}
		}

		public static bool ConvertByName<TEnumFrom, TEnumTo>(TEnumFrom convertFrom, out TEnumTo value) where TEnumFrom : struct, IFormattable, IComparable where TEnumTo : struct, IFormattable, IComparable
		{
			if (!ReflectionTools.IsEnum(typeof(TEnumFrom)))
			{
				throw new ArgumentException("TEnumFrom must be an enumerated type.");
			}
			while (ReflectionTools.IsEnum(typeof(TEnumTo)))
			{
				while (true)
				{
					IL_0061:
					string[] names = Enum.GetNames(typeof(TEnumTo));
					int num = Array.IndexOf(names, convertFrom.ToString());
					if (num < 0)
					{
						value = default(TEnumTo);
						return false;
					}
					value = (TEnumTo)Enum.Parse(typeof(TEnumTo), names[num]);
					int num2 = -182908404;
					while (true)
					{
						switch (num2 ^ -182908403)
						{
						case 0:
							num2 = -182908401;
							continue;
						case 2:
							break;
						case 3:
							goto IL_0061;
						default:
							return true;
						}
						break;
					}
					break;
				}
			}
			throw new ArgumentException("TEnumTo must be an enumerated type.");
		}

		public static int[] GetIntValues(Type enumType)
		{
			return ArrayTools.ConvertToIntArray(Enum.GetValues(enumType));
		}

		public static bool IsEnum(Type type)
		{
			return ReflectionTools.IsEnum(type);
		}

		public static Type GetUnderlyingType(Type type)
		{
			return ReflectionTools.GetUnderlyingEnumType(type);
		}

		public static bool IsValidUnderlyingType(Type underlyingType)
		{
			if (!object.ReferenceEquals(underlyingType, typeof(int)) && !object.ReferenceEquals(underlyingType, typeof(uint)) && !object.ReferenceEquals(underlyingType, typeof(byte)) && !object.ReferenceEquals(underlyingType, typeof(sbyte)) && !object.ReferenceEquals(underlyingType, typeof(short)))
			{
				while (true)
				{
					int num = -1480113479;
					while (true)
					{
						switch (num ^ -1480113480)
						{
						case 2:
							break;
						case 1:
							goto IL_0081;
						default:
							goto IL_00ac;
						}
						break;
						IL_00ac:
						if (object.ReferenceEquals(underlyingType, typeof(ulong)))
						{
							goto end_IL_0063;
						}
						return false;
						IL_0081:
						if (object.ReferenceEquals(underlyingType, typeof(ushort)) || object.ReferenceEquals(underlyingType, typeof(long)))
						{
							goto end_IL_0063;
						}
						num = -1480113480;
					}
					continue;
					end_IL_0063:
					break;
				}
			}
			return true;
		}
	}
}
