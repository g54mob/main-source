using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class EnumNameValueCache<TEnum> where TEnum : struct, IComparable, IFormattable
	{
		private static EnumNameValueCache<TEnum> VUVdmyJPLrditBBtIsRvmbNoHcfS;

		private readonly ADictionary<string, TEnum> lHydgiTXwHduIEhggSRULXfzmIa;

		private readonly string[] CJmWqdRLBYwxjDDbpiTMBgKgEja;

		private readonly long[] mbFaVvRFrChAdKnWVtSCqBscHMMj;

		public static EnumNameValueCache<TEnum> Default
		{
			get
			{
				return VUVdmyJPLrditBBtIsRvmbNoHcfS ?? (VUVdmyJPLrditBBtIsRvmbNoHcfS = new EnumNameValueCache<TEnum>());
			}
		}

		public int Count
		{
			get
			{
				return mbFaVvRFrChAdKnWVtSCqBscHMMj.Length;
			}
		}

		public static void Free()
		{
			VUVdmyJPLrditBBtIsRvmbNoHcfS = null;
		}

		private EnumNameValueCache()
		{
			int num2 = default(int);
			TEnum[] array = default(TEnum[]);
			Type underlyingEnumType = default(Type);
			Type typeFromHandle = default(Type);
			while (true)
			{
				int num = -1554072980;
				while (true)
				{
					switch (num ^ -1554072979)
					{
					case 7:
						break;
					case 3:
						mbFaVvRFrChAdKnWVtSCqBscHMMj[num2] = MiscTools.ToLongUnchecked(Convert.ChangeType(array[num2], underlyingEnumType));
						lHydgiTXwHduIEhggSRULXfzmIa.Add(CJmWqdRLBYwxjDDbpiTMBgKgEja[num2], array[num2]);
						num2++;
						num = -1554072981;
						continue;
					case 4:
						if (!EnumTools.IsEnum(typeFromHandle))
						{
							throw new Exception("enumType is not an enum type.");
						}
						goto case 0;
					case 1:
						typeFromHandle = typeof(TEnum);
						num = -1554072983;
						continue;
					case 2:
						num = -1554072981;
						continue;
					case 5:
						lHydgiTXwHduIEhggSRULXfzmIa = new ADictionary<string, TEnum>();
						mbFaVvRFrChAdKnWVtSCqBscHMMj = new long[array.Length];
						num2 = 0;
						num = -1554072977;
						continue;
					case 0:
						underlyingEnumType = ReflectionTools.GetUnderlyingEnumType(typeFromHandle);
						CJmWqdRLBYwxjDDbpiTMBgKgEja = Enum.GetNames(typeFromHandle);
						array = (TEnum[])Enum.GetValues(typeFromHandle);
						num = -1554072984;
						continue;
					default:
						if (num2 >= array.Length)
						{
							return;
						}
						goto case 3;
					}
					break;
				}
			}
		}

		public TEnum GetValue(string name)
		{
			return lHydgiTXwHduIEhggSRULXfzmIa[name];
		}

		public bool TryGetValue(string name, out TEnum value)
		{
			return lHydgiTXwHduIEhggSRULXfzmIa.TryGetValue(name, out value);
		}

		public string GetName(long value)
		{
			int num = IndexOf(value);
			while (true)
			{
				switch (0x346701B ^ 0x346701A)
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
			return CJmWqdRLBYwxjDDbpiTMBgKgEja[num];
		}

		public bool TryGetName(long value, out string name)
		{
			int num = IndexOf(value);
			if (num < 0)
			{
				goto IL_000c;
			}
			name = CJmWqdRLBYwxjDDbpiTMBgKgEja[num];
			int num2 = -312539167;
			goto IL_0011;
			IL_0011:
			while (true)
			{
				switch (num2 ^ -312539165)
				{
				case 0:
					break;
				case 1:
					goto IL_002e;
				case 3:
					return false;
				default:
					return true;
				}
				break;
				IL_002e:
				name = string.Empty;
				num2 = -312539168;
			}
			goto IL_000c;
			IL_000c:
			num2 = -312539166;
			goto IL_0011;
		}

		public TEnum GetValueAt(int index)
		{
			if ((uint)index >= (uint)mbFaVvRFrChAdKnWVtSCqBscHMMj.Length)
			{
				while (true)
				{
					switch (0x4A8852F6 ^ 0x4A8852F7)
					{
					case 0:
						continue;
					case 1:
						throw new ArgumentOutOfRangeException("index");
					}
					break;
				}
			}
			return lHydgiTXwHduIEhggSRULXfzmIa[CJmWqdRLBYwxjDDbpiTMBgKgEja[index]];
		}

		public string GetNameAt(int index)
		{
			if ((uint)index >= (uint)mbFaVvRFrChAdKnWVtSCqBscHMMj.Length)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return CJmWqdRLBYwxjDDbpiTMBgKgEja[index];
		}

		public int IndexOf(string name)
		{
			return Array.IndexOf(CJmWqdRLBYwxjDDbpiTMBgKgEja, name);
		}

		public int IndexOf(long value)
		{
			return Array.IndexOf(mbFaVvRFrChAdKnWVtSCqBscHMMj, value);
		}

		public bool Contains(string name)
		{
			return lHydgiTXwHduIEhggSRULXfzmIa.ContainsKey(name);
		}

		public bool Contains(long value)
		{
			return IndexOf(value) >= 0;
		}
	}
}
