using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class EnumNameValueCache<TEnum> where TEnum : struct, IComparable, IFormattable
	{
		private static EnumNameValueCache<TEnum> hIGOaPnWbcWPNCMoViZYwrGhQExf;

		private readonly ADictionary<string, TEnum> JDbNBRnDzOOVcHAgJAtnACxNnIsfb;

		private readonly string[] yFjhsKcvfBPAHjCuSkDpUGwIsoeiA;

		private readonly long[] YLSXrUlzZZpcZwTTaOxvYAMSOmKQ;

		public static EnumNameValueCache<TEnum> Default => hIGOaPnWbcWPNCMoViZYwrGhQExf ?? (hIGOaPnWbcWPNCMoViZYwrGhQExf = new EnumNameValueCache<TEnum>());

		public int Count => YLSXrUlzZZpcZwTTaOxvYAMSOmKQ.Length;

		public static void Free()
		{
			hIGOaPnWbcWPNCMoViZYwrGhQExf = null;
		}

		private EnumNameValueCache()
		{
			Type typeFromHandle = typeof(TEnum);
			if (!EnumTools.IsEnum(typeFromHandle))
			{
				throw new Exception("enumType is not an enum type.");
			}
			Type underlyingEnumType = ReflectionTools.GetUnderlyingEnumType(typeFromHandle);
			yFjhsKcvfBPAHjCuSkDpUGwIsoeiA = Enum.GetNames(typeFromHandle);
			TEnum[] array = (TEnum[])Enum.GetValues(typeFromHandle);
			JDbNBRnDzOOVcHAgJAtnACxNnIsfb = new ADictionary<string, TEnum>();
			YLSXrUlzZZpcZwTTaOxvYAMSOmKQ = new long[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				YLSXrUlzZZpcZwTTaOxvYAMSOmKQ[i] = MiscTools.ToLongUnchecked(Convert.ChangeType(array[i], underlyingEnumType));
				JDbNBRnDzOOVcHAgJAtnACxNnIsfb.Add(yFjhsKcvfBPAHjCuSkDpUGwIsoeiA[i], array[i]);
			}
		}

		public TEnum GetValue(string name)
		{
			return JDbNBRnDzOOVcHAgJAtnACxNnIsfb[name];
		}

		public bool TryGetValue(string name, out TEnum value)
		{
			return JDbNBRnDzOOVcHAgJAtnACxNnIsfb.TryGetValue(name, out value);
		}

		public string GetName(long value)
		{
			int num = IndexOf(value);
			if (num < 0)
			{
				throw new Exception("The value does not exist in the enum.");
			}
			return yFjhsKcvfBPAHjCuSkDpUGwIsoeiA[num];
		}

		public bool TryGetName(long value, out string name)
		{
			int num = IndexOf(value);
			if (num < 0)
			{
				name = string.Empty;
				return false;
			}
			name = yFjhsKcvfBPAHjCuSkDpUGwIsoeiA[num];
			return true;
		}

		public TEnum GetValueAt(int index)
		{
			if ((uint)index >= (uint)YLSXrUlzZZpcZwTTaOxvYAMSOmKQ.Length)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return JDbNBRnDzOOVcHAgJAtnACxNnIsfb[yFjhsKcvfBPAHjCuSkDpUGwIsoeiA[index]];
		}

		public string GetNameAt(int index)
		{
			if ((uint)index >= (uint)YLSXrUlzZZpcZwTTaOxvYAMSOmKQ.Length)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return yFjhsKcvfBPAHjCuSkDpUGwIsoeiA[index];
		}

		public int IndexOf(string name)
		{
			return Array.IndexOf(yFjhsKcvfBPAHjCuSkDpUGwIsoeiA, name);
		}

		public int IndexOf(long value)
		{
			return Array.IndexOf(YLSXrUlzZZpcZwTTaOxvYAMSOmKQ, value);
		}

		public bool Contains(string name)
		{
			return JDbNBRnDzOOVcHAgJAtnACxNnIsfb.ContainsKey(name);
		}

		public bool Contains(long value)
		{
			return IndexOf(value) >= 0;
		}
	}
}
