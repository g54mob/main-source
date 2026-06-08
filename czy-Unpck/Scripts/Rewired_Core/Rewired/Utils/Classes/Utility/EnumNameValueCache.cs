using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class EnumNameValueCache<TEnum> where TEnum : struct, IComparable, IFormattable
	{
		private static EnumNameValueCache<TEnum> ysVZGtbGqpnZmwLEnoKqdTvOnfQ;

		private readonly ADictionary<string, TEnum> CpyyYddjcPJsDbaWtAhJgDxmJtNH;

		private readonly string[] fIohrwvXqMfXaubUydJLVrmxlLB;

		private readonly long[] BFTpsuzGYYgDogCzCKrXjTMrZNvl;

		public static EnumNameValueCache<TEnum> Default => ysVZGtbGqpnZmwLEnoKqdTvOnfQ ?? (ysVZGtbGqpnZmwLEnoKqdTvOnfQ = new EnumNameValueCache<TEnum>());

		public int Count => BFTpsuzGYYgDogCzCKrXjTMrZNvl.Length;

		public static void Free()
		{
			ysVZGtbGqpnZmwLEnoKqdTvOnfQ = null;
		}

		private EnumNameValueCache()
		{
			Type typeFromHandle = default(Type);
			Type underlyingEnumType = default(Type);
			TEnum[] array = default(TEnum[]);
			int num2 = default(int);
			while (true)
			{
				int num = -1917159438;
				while (true)
				{
					switch (num ^ -1917159437)
					{
					case 3:
						break;
					case 1:
						typeFromHandle = typeof(TEnum);
						if (!EnumTools.IsEnum(typeFromHandle))
						{
							throw new Exception("enumType is not an enum type.");
						}
						goto case 2;
					case 2:
						underlyingEnumType = ReflectionTools.GetUnderlyingEnumType(typeFromHandle);
						fIohrwvXqMfXaubUydJLVrmxlLB = Enum.GetNames(typeFromHandle);
						array = (TEnum[])Enum.GetValues(typeFromHandle);
						CpyyYddjcPJsDbaWtAhJgDxmJtNH = new ADictionary<string, TEnum>();
						BFTpsuzGYYgDogCzCKrXjTMrZNvl = new long[array.Length];
						num2 = 0;
						num = -1917159433;
						continue;
					case 0:
						BFTpsuzGYYgDogCzCKrXjTMrZNvl[num2] = MiscTools.ToLongUnchecked(Convert.ChangeType(array[num2], underlyingEnumType));
						CpyyYddjcPJsDbaWtAhJgDxmJtNH.Add(fIohrwvXqMfXaubUydJLVrmxlLB[num2], array[num2]);
						num2++;
						num = -1917159433;
						continue;
					default:
						if (num2 >= array.Length)
						{
							return;
						}
						goto case 0;
					}
					break;
				}
			}
		}

		public TEnum GetValue(string name)
		{
			return CpyyYddjcPJsDbaWtAhJgDxmJtNH[name];
		}

		public bool TryGetValue(string name, out TEnum value)
		{
			return CpyyYddjcPJsDbaWtAhJgDxmJtNH.TryGetValue(name, out value);
		}

		public string GetName(long value)
		{
			int num = IndexOf(value);
			while (true)
			{
				switch (0x13BFA624 ^ 0x13BFA625)
				{
				case 2:
					continue;
				case 1:
					if (num < 0)
					{
						throw new Exception("The value does not exist in the enum.");
					}
					break;
				}
				break;
			}
			return fIohrwvXqMfXaubUydJLVrmxlLB[num];
		}

		public bool TryGetName(long value, out string name)
		{
			int num = IndexOf(value);
			if (num < 0)
			{
				name = string.Empty;
				return false;
			}
			name = fIohrwvXqMfXaubUydJLVrmxlLB[num];
			return true;
		}

		public TEnum GetValueAt(int index)
		{
			if ((uint)index >= (uint)BFTpsuzGYYgDogCzCKrXjTMrZNvl.Length)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return CpyyYddjcPJsDbaWtAhJgDxmJtNH[fIohrwvXqMfXaubUydJLVrmxlLB[index]];
		}

		public string GetNameAt(int index)
		{
			if ((uint)index >= (uint)BFTpsuzGYYgDogCzCKrXjTMrZNvl.Length)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return fIohrwvXqMfXaubUydJLVrmxlLB[index];
		}

		public int IndexOf(string name)
		{
			return Array.IndexOf(fIohrwvXqMfXaubUydJLVrmxlLB, name);
		}

		public int IndexOf(long value)
		{
			return Array.IndexOf(BFTpsuzGYYgDogCzCKrXjTMrZNvl, value);
		}

		public bool Contains(string name)
		{
			return CpyyYddjcPJsDbaWtAhJgDxmJtNH.ContainsKey(name);
		}

		public bool Contains(long value)
		{
			return IndexOf(value) >= 0;
		}
	}
}
