using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class EnumNameValueCache<TEnum> where TEnum : struct, IComparable, IFormattable
	{
		private static EnumNameValueCache<TEnum> ypYaLQReAnicNkkEZOeJpdrUSpMnA;

		private readonly ADictionary<string, TEnum> HJgkpwZFZbhglUfpHLPUfNddwPQj;

		private readonly string[] LANvmHdflzhjvDRIirOpUTuWbhMNA;

		private readonly long[] aIGjwXggGhbSVCOiOJezMOrULgyA;

		public static EnumNameValueCache<TEnum> Default => ypYaLQReAnicNkkEZOeJpdrUSpMnA ?? (ypYaLQReAnicNkkEZOeJpdrUSpMnA = new EnumNameValueCache<TEnum>());

		public int Count => aIGjwXggGhbSVCOiOJezMOrULgyA.Length;

		public static void Free()
		{
			ypYaLQReAnicNkkEZOeJpdrUSpMnA = null;
		}

		private EnumNameValueCache()
		{
			Type typeFromHandle = typeof(TEnum);
			if (!EnumTools.IsEnum(typeFromHandle))
			{
				throw new Exception("enumType is not an enum type.");
			}
			Type underlyingEnumType = ReflectionTools.GetUnderlyingEnumType(typeFromHandle);
			LANvmHdflzhjvDRIirOpUTuWbhMNA = Enum.GetNames(typeFromHandle);
			TEnum[] array = (TEnum[])Enum.GetValues(typeFromHandle);
			HJgkpwZFZbhglUfpHLPUfNddwPQj = new ADictionary<string, TEnum>();
			aIGjwXggGhbSVCOiOJezMOrULgyA = new long[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				aIGjwXggGhbSVCOiOJezMOrULgyA[i] = MiscTools.ToLongUnchecked(Convert.ChangeType(array[i], underlyingEnumType));
				HJgkpwZFZbhglUfpHLPUfNddwPQj.Add(LANvmHdflzhjvDRIirOpUTuWbhMNA[i], array[i]);
			}
		}

		public TEnum GetValue(string name)
		{
			return ((ADictionary<string, string>)(object)HJgkpwZFZbhglUfpHLPUfNddwPQj)[name];
		}

		public bool TryGetValue(string name, out TEnum value)
		{
			return HJgkpwZFZbhglUfpHLPUfNddwPQj.TryGetValue(name, out value);
		}

		public string GetName(long value)
		{
			int num = IndexOf(value);
			if (num < 0)
			{
				throw new Exception("The value does not exist in the enum.");
			}
			return LANvmHdflzhjvDRIirOpUTuWbhMNA[num];
		}

		public bool TryGetName(long value, out string name)
		{
			int num = IndexOf(value);
			if (num < 0)
			{
				name = string.Empty;
				return false;
			}
			name = LANvmHdflzhjvDRIirOpUTuWbhMNA[num];
			return true;
		}

		public TEnum GetValueAt(int index)
		{
			if ((uint)index >= (uint)aIGjwXggGhbSVCOiOJezMOrULgyA.Length)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return ((ADictionary<string, string>)(object)HJgkpwZFZbhglUfpHLPUfNddwPQj)[LANvmHdflzhjvDRIirOpUTuWbhMNA[index]];
		}

		public string GetNameAt(int index)
		{
			if ((uint)index >= (uint)aIGjwXggGhbSVCOiOJezMOrULgyA.Length)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return LANvmHdflzhjvDRIirOpUTuWbhMNA[index];
		}

		public int IndexOf(string name)
		{
			return Array.IndexOf(LANvmHdflzhjvDRIirOpUTuWbhMNA, name);
		}

		public int IndexOf(long value)
		{
			return Array.IndexOf(aIGjwXggGhbSVCOiOJezMOrULgyA, value);
		}

		public bool Contains(string name)
		{
			return HJgkpwZFZbhglUfpHLPUfNddwPQj.ContainsKey(name);
		}

		public bool Contains(long value)
		{
			return IndexOf(value) >= 0;
		}
	}
}
