using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class EnumNameValueCache<TEnum> where TEnum : struct, IComparable, IFormattable
	{
		private static EnumNameValueCache<TEnum> BCscaeTxVdAnKZyZxgYchgKgFnFR;

		private readonly ADictionary<string, TEnum> iGSRTGHWYjelsdqarpLvlMyZuRVc;

		private readonly string[] oxvVZnnfmvmemiTRIeiOZSLoMhZy;

		private readonly long[] RzyMQjsbarePNvZYovTSGvMXHpPb;

		public static EnumNameValueCache<TEnum> Default => BCscaeTxVdAnKZyZxgYchgKgFnFR ?? (BCscaeTxVdAnKZyZxgYchgKgFnFR = new EnumNameValueCache<TEnum>());

		public int Count => RzyMQjsbarePNvZYovTSGvMXHpPb.Length;

		public static void Free()
		{
			BCscaeTxVdAnKZyZxgYchgKgFnFR = null;
		}

		private EnumNameValueCache()
		{
			Type typeFromHandle = typeof(TEnum);
			if (!EnumTools.IsEnum(typeFromHandle))
			{
				throw new Exception("enumType is not an enum type.");
			}
			Type underlyingEnumType = ReflectionTools.GetUnderlyingEnumType(typeFromHandle);
			oxvVZnnfmvmemiTRIeiOZSLoMhZy = Enum.GetNames(typeFromHandle);
			TEnum[] array = (TEnum[])Enum.GetValues(typeFromHandle);
			iGSRTGHWYjelsdqarpLvlMyZuRVc = new ADictionary<string, TEnum>();
			RzyMQjsbarePNvZYovTSGvMXHpPb = new long[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				RzyMQjsbarePNvZYovTSGvMXHpPb[i] = MiscTools.ToLongUnchecked(Convert.ChangeType(array[i], underlyingEnumType));
				iGSRTGHWYjelsdqarpLvlMyZuRVc.Add(oxvVZnnfmvmemiTRIeiOZSLoMhZy[i], array[i]);
			}
		}

		public TEnum GetValue(string name)
		{
			return ((ADictionary<string, string>)(object)iGSRTGHWYjelsdqarpLvlMyZuRVc)[name];
		}

		public bool TryGetValue(string name, out TEnum value)
		{
			return iGSRTGHWYjelsdqarpLvlMyZuRVc.TryGetValue(name, out value);
		}

		public string GetName(long value)
		{
			int num = IndexOf(value);
			if (num < 0)
			{
				throw new Exception("The value does not exist in the enum.");
			}
			return oxvVZnnfmvmemiTRIeiOZSLoMhZy[num];
		}

		public bool TryGetName(long value, out string name)
		{
			int num = IndexOf(value);
			if (num < 0)
			{
				name = string.Empty;
				return false;
			}
			name = oxvVZnnfmvmemiTRIeiOZSLoMhZy[num];
			return true;
		}

		public TEnum GetValueAt(int index)
		{
			if ((uint)index >= (uint)RzyMQjsbarePNvZYovTSGvMXHpPb.Length)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return ((ADictionary<string, string>)(object)iGSRTGHWYjelsdqarpLvlMyZuRVc)[oxvVZnnfmvmemiTRIeiOZSLoMhZy[index]];
		}

		public string GetNameAt(int index)
		{
			if ((uint)index >= (uint)RzyMQjsbarePNvZYovTSGvMXHpPb.Length)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return oxvVZnnfmvmemiTRIeiOZSLoMhZy[index];
		}

		public int IndexOf(string name)
		{
			return Array.IndexOf(oxvVZnnfmvmemiTRIeiOZSLoMhZy, name);
		}

		public int IndexOf(long value)
		{
			return Array.IndexOf(RzyMQjsbarePNvZYovTSGvMXHpPb, value);
		}

		public bool Contains(string name)
		{
			return iGSRTGHWYjelsdqarpLvlMyZuRVc.ContainsKey(name);
		}

		public bool Contains(long value)
		{
			return IndexOf(value) >= 0;
		}
	}
}
