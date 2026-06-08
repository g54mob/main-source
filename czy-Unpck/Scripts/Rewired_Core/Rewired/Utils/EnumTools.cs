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
			while (true)
			{
				int num;
				int num2;
				if (ReflectionTools.IsEnum(typeof(TEnumTo)))
				{
					num = 1861937545;
					num2 = num;
				}
				else
				{
					num = 1861937547;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x6EFAE988)
					{
					case 0:
						num = 1861937548;
						continue;
					case 4:
						break;
					case 3:
						throw new ArgumentException("TEnumTo must be an enumerated type.");
					case 1:
					{
						string[] names = Enum.GetNames(typeof(TEnumTo));
						int num3 = Array.IndexOf(names, convertFrom.ToString());
						if (num3 < 0)
						{
							num = 1861937546;
							continue;
						}
						value = (TEnumTo)Enum.Parse(typeof(TEnumTo), names[num3]);
						return true;
					}
					default:
						value = default(TEnumTo);
						return false;
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
					int num = -1342855395;
					while (true)
					{
						switch (num ^ -1342855394)
						{
						case 0:
							break;
						case 3:
							goto IL_0042;
						case 2:
							goto IL_005e;
						case 4:
							goto IL_009e;
						case 5:
							goto IL_00cc;
						default:
							return false;
						}
						break;
						IL_00cc:
						if (object.ReferenceEquals(underlyingType, typeof(byte)))
						{
							goto end_IL_0015;
						}
						num = -1342855398;
						continue;
						IL_0042:
						if (object.ReferenceEquals(underlyingType, typeof(uint)))
						{
							goto end_IL_0015;
						}
						num = -1342855397;
						continue;
						IL_009e:
						if (object.ReferenceEquals(underlyingType, typeof(sbyte)) || object.ReferenceEquals(underlyingType, typeof(short)))
						{
							goto end_IL_0015;
						}
						num = -1342855396;
						continue;
						IL_005e:
						if (object.ReferenceEquals(underlyingType, typeof(ushort)) || object.ReferenceEquals(underlyingType, typeof(long)) || object.ReferenceEquals(underlyingType, typeof(ulong)))
						{
							goto end_IL_0015;
						}
						num = -1342855393;
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
