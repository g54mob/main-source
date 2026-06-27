using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class EnumNameValueCache<TEnum> where TEnum : struct, IComparable, IFormattable
	{
		private static EnumNameValueCache<TEnum> YgFoibSPOdpFzljTSuhyQXJJiRym;

		private readonly ADictionary<string, TEnum> hYhEBZIEZtMSRyVmYSKfaIJcPMqlA;

		private readonly string[] nfMHovwfovCPIOBblTiOiWGNLHqG;

		private readonly long[] YDNWOPryqjwIcZEBPfKHCjkoFpMMA;

		public static EnumNameValueCache<TEnum> Default => YgFoibSPOdpFzljTSuhyQXJJiRym ?? (YgFoibSPOdpFzljTSuhyQXJJiRym = new EnumNameValueCache<TEnum>());

		public int Count => YDNWOPryqjwIcZEBPfKHCjkoFpMMA.Length;

		public static void Free()
		{
			YgFoibSPOdpFzljTSuhyQXJJiRym = null;
		}

		private EnumNameValueCache()
		{
			Type typeFromHandle = typeof(TEnum);
			if (!EnumTools.IsEnum(typeFromHandle))
			{
				throw new Exception("enumType is not an enum type.");
			}
			Type underlyingEnumType = ReflectionTools.GetUnderlyingEnumType(typeFromHandle);
			nfMHovwfovCPIOBblTiOiWGNLHqG = Enum.GetNames(typeFromHandle);
			TEnum[] array = (TEnum[])Enum.GetValues(typeFromHandle);
			hYhEBZIEZtMSRyVmYSKfaIJcPMqlA = new ADictionary<string, TEnum>();
			YDNWOPryqjwIcZEBPfKHCjkoFpMMA = new long[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				YDNWOPryqjwIcZEBPfKHCjkoFpMMA[i] = MiscTools.ToLongUnchecked(Convert.ChangeType(array[i], underlyingEnumType));
				hYhEBZIEZtMSRyVmYSKfaIJcPMqlA.Add(nfMHovwfovCPIOBblTiOiWGNLHqG[i], array[i]);
			}
		}

		public TEnum GetValue(string name)
		{
			return ((ADictionary<string, string>)(object)hYhEBZIEZtMSRyVmYSKfaIJcPMqlA)[name];
		}

		public bool TryGetValue(string name, out TEnum value)
		{
			return hYhEBZIEZtMSRyVmYSKfaIJcPMqlA.TryGetValue(name, out value);
		}

		public string GetName(long value)
		{
			int num = IndexOf(value);
			if (num < 0)
			{
				throw new Exception("The value does not exist in the enum.");
			}
			return nfMHovwfovCPIOBblTiOiWGNLHqG[num];
		}

		public bool TryGetName(long value, out string name)
		{
			int num = IndexOf(value);
			if (num < 0)
			{
				name = string.Empty;
				return false;
			}
			name = nfMHovwfovCPIOBblTiOiWGNLHqG[num];
			return true;
		}

		public TEnum GetValueAt(int index)
		{
			if ((uint)index >= (uint)YDNWOPryqjwIcZEBPfKHCjkoFpMMA.Length)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return ((ADictionary<string, string>)(object)hYhEBZIEZtMSRyVmYSKfaIJcPMqlA)[nfMHovwfovCPIOBblTiOiWGNLHqG[index]];
		}

		public string GetNameAt(int index)
		{
			if ((uint)index >= (uint)YDNWOPryqjwIcZEBPfKHCjkoFpMMA.Length)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return nfMHovwfovCPIOBblTiOiWGNLHqG[index];
		}

		public int IndexOf(string name)
		{
			return Array.IndexOf(nfMHovwfovCPIOBblTiOiWGNLHqG, name);
		}

		public int IndexOf(long value)
		{
			return Array.IndexOf(YDNWOPryqjwIcZEBPfKHCjkoFpMMA, value);
		}

		public bool Contains(string name)
		{
			return hYhEBZIEZtMSRyVmYSKfaIJcPMqlA.ContainsKey(name);
		}

		public bool Contains(long value)
		{
			return IndexOf(value) >= 0;
		}
	}
}
