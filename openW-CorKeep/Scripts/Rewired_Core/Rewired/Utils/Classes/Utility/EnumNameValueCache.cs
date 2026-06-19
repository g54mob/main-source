using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class EnumNameValueCache<TEnum> where TEnum : struct, IComparable, IFormattable
	{
		private static EnumNameValueCache<TEnum> VcywrtdVdbHoafzyTvRopIFcFFl;

		private readonly ADictionary<string, TEnum> ieAHzZdrghqHCKGYoGaAcsUmglBt;

		private readonly string[] kTlnHkVSGtacUHhrXqnnMODVziZW;

		private readonly long[] JDgWMBCHZhFkjYidzggucFjsFMpqA;

		public static EnumNameValueCache<TEnum> Default => VcywrtdVdbHoafzyTvRopIFcFFl ?? (VcywrtdVdbHoafzyTvRopIFcFFl = new EnumNameValueCache<TEnum>());

		public int Count => JDgWMBCHZhFkjYidzggucFjsFMpqA.Length;

		public static void Free()
		{
			VcywrtdVdbHoafzyTvRopIFcFFl = null;
		}

		private EnumNameValueCache()
		{
			Type typeFromHandle = typeof(TEnum);
			if (!EnumTools.IsEnum(typeFromHandle))
			{
				throw new Exception("enumType is not an enum type.");
			}
			Type underlyingEnumType = ReflectionTools.GetUnderlyingEnumType(typeFromHandle);
			kTlnHkVSGtacUHhrXqnnMODVziZW = Enum.GetNames(typeFromHandle);
			TEnum[] array = (TEnum[])Enum.GetValues(typeFromHandle);
			ieAHzZdrghqHCKGYoGaAcsUmglBt = new ADictionary<string, TEnum>();
			JDgWMBCHZhFkjYidzggucFjsFMpqA = new long[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				JDgWMBCHZhFkjYidzggucFjsFMpqA[i] = MiscTools.ToLongUnchecked(Convert.ChangeType(array[i], underlyingEnumType));
				ieAHzZdrghqHCKGYoGaAcsUmglBt.Add(kTlnHkVSGtacUHhrXqnnMODVziZW[i], array[i]);
			}
		}

		public TEnum GetValue(string name)
		{
			return ((ADictionary<string, string>)(object)ieAHzZdrghqHCKGYoGaAcsUmglBt)[name];
		}

		public bool TryGetValue(string name, out TEnum value)
		{
			return ieAHzZdrghqHCKGYoGaAcsUmglBt.TryGetValue(name, out value);
		}

		public string GetName(long value)
		{
			int num = IndexOf(value);
			if (num < 0)
			{
				throw new Exception("The value does not exist in the enum.");
			}
			return kTlnHkVSGtacUHhrXqnnMODVziZW[num];
		}

		public bool TryGetName(long value, out string name)
		{
			int num = IndexOf(value);
			if (num < 0)
			{
				name = string.Empty;
				return false;
			}
			name = kTlnHkVSGtacUHhrXqnnMODVziZW[num];
			return true;
		}

		public TEnum GetValueAt(int index)
		{
			if ((uint)index >= (uint)JDgWMBCHZhFkjYidzggucFjsFMpqA.Length)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return ((ADictionary<string, string>)(object)ieAHzZdrghqHCKGYoGaAcsUmglBt)[kTlnHkVSGtacUHhrXqnnMODVziZW[index]];
		}

		public string GetNameAt(int index)
		{
			if ((uint)index >= (uint)JDgWMBCHZhFkjYidzggucFjsFMpqA.Length)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return kTlnHkVSGtacUHhrXqnnMODVziZW[index];
		}

		public int IndexOf(string name)
		{
			return Array.IndexOf(kTlnHkVSGtacUHhrXqnnMODVziZW, name);
		}

		public int IndexOf(long value)
		{
			return Array.IndexOf(JDgWMBCHZhFkjYidzggucFjsFMpqA, value);
		}

		public bool Contains(string name)
		{
			return ieAHzZdrghqHCKGYoGaAcsUmglBt.ContainsKey(name);
		}

		public bool Contains(long value)
		{
			return IndexOf(value) >= 0;
		}
	}
}
