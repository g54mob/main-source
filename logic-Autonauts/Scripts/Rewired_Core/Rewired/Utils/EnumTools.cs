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
			string[] names = default(string[]);
			while (true)
			{
				int num;
				int num2;
				if (ReflectionTools.IsEnum(typeof(TEnumTo)))
				{
					num = -1844870531;
					num2 = num;
				}
				else
				{
					num = -1844870530;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1844870532)
					{
					case 0:
						num = -1844870529;
						continue;
					case 1:
						names = Enum.GetNames(typeof(TEnumTo));
						num = -1844870536;
						continue;
					case 2:
						throw new ArgumentException("TEnumTo must be an enumerated type.");
					case 3:
						break;
					default:
					{
						int num3 = Array.IndexOf(names, convertFrom.ToString());
						if (num3 < 0)
						{
							value = default(TEnumTo);
							return false;
						}
						value = (TEnumTo)Enum.Parse(typeof(TEnumTo), names[num3]);
						return true;
					}
					}
					break;
				}
			}
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
			if (!object.ReferenceEquals(underlyingType, typeof(int)))
			{
				while (true)
				{
					int num = -1672312255;
					while (true)
					{
						switch (num ^ -1672312254)
						{
						case 2:
							break;
						case 5:
							goto IL_0042;
						case 4:
							goto IL_0070;
						case 3:
							goto IL_0089;
						case 1:
							goto IL_00a5;
						default:
							return false;
						}
						break;
						IL_00a5:
						if (object.ReferenceEquals(underlyingType, typeof(sbyte)) || object.ReferenceEquals(underlyingType, typeof(short)) || object.ReferenceEquals(underlyingType, typeof(ushort)))
						{
							goto end_IL_0015;
						}
						num = -1672312249;
						continue;
						IL_0089:
						if (object.ReferenceEquals(underlyingType, typeof(uint)))
						{
							goto end_IL_0015;
						}
						num = -1672312250;
						continue;
						IL_0042:
						if (object.ReferenceEquals(underlyingType, typeof(long)) || object.ReferenceEquals(underlyingType, typeof(ulong)))
						{
							goto end_IL_0015;
						}
						num = -1672312254;
						continue;
						IL_0070:
						if (object.ReferenceEquals(underlyingType, typeof(byte)))
						{
							goto end_IL_0015;
						}
						num = -1672312253;
					}
					continue;
					end_IL_0015:
					break;
				}
			}
			return true;
		}
	}
}
