using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class EnumNameValueCache<TEnum> where TEnum : struct, IComparable, IFormattable
	{
		private static EnumNameValueCache<TEnum> oHOYBGfIDVaBUZReOQDxLrzUGUN;

		private readonly ADictionary<string, TEnum> ICjTTAhpBjYQxKkcWQEMxtvcoUS;

		private readonly string[] fFzdyZejXcQVErRsRouIdtutuiGh;

		private readonly long[] XlGWzTbBfmAhMjPFhAECJrEzBmuL;

		public static EnumNameValueCache<TEnum> Default => oHOYBGfIDVaBUZReOQDxLrzUGUN ?? (oHOYBGfIDVaBUZReOQDxLrzUGUN = new EnumNameValueCache<TEnum>());

		public int Count => XlGWzTbBfmAhMjPFhAECJrEzBmuL.Length;

		public static void Free()
		{
			oHOYBGfIDVaBUZReOQDxLrzUGUN = null;
		}

		private EnumNameValueCache()
		{
			Type typeFromHandle = typeof(TEnum);
			if (!EnumTools.IsEnum(typeFromHandle))
			{
				throw new Exception("enumType is not an enum type.");
			}
			Type underlyingEnumType = ReflectionTools.GetUnderlyingEnumType(typeFromHandle);
			fFzdyZejXcQVErRsRouIdtutuiGh = Enum.GetNames(typeFromHandle);
			TEnum[] array = (TEnum[])Enum.GetValues(typeFromHandle);
			ICjTTAhpBjYQxKkcWQEMxtvcoUS = new ADictionary<string, TEnum>();
			XlGWzTbBfmAhMjPFhAECJrEzBmuL = new long[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				XlGWzTbBfmAhMjPFhAECJrEzBmuL[i] = MiscTools.ToLongUnchecked(Convert.ChangeType(array[i], underlyingEnumType));
				ICjTTAhpBjYQxKkcWQEMxtvcoUS.Add(fFzdyZejXcQVErRsRouIdtutuiGh[i], array[i]);
			}
		}

		public TEnum GetValue(string name)
		{
			return ICjTTAhpBjYQxKkcWQEMxtvcoUS[name];
		}

		public bool TryGetValue(string name, out TEnum value)
		{
			return ICjTTAhpBjYQxKkcWQEMxtvcoUS.TryGetValue(name, out value);
		}

		public string GetName(long value)
		{
			int num = IndexOf(value);
			if (num < 0)
			{
				throw new Exception("The value does not exist in the enum.");
			}
			return fFzdyZejXcQVErRsRouIdtutuiGh[num];
		}

		public bool TryGetName(long value, out string name)
		{
			int num = IndexOf(value);
			if (num < 0)
			{
				name = string.Empty;
				return false;
			}
			name = fFzdyZejXcQVErRsRouIdtutuiGh[num];
			return true;
		}

		public TEnum GetValueAt(int index)
		{
			if ((uint)index >= (uint)XlGWzTbBfmAhMjPFhAECJrEzBmuL.Length)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return ICjTTAhpBjYQxKkcWQEMxtvcoUS[fFzdyZejXcQVErRsRouIdtutuiGh[index]];
		}

		public string GetNameAt(int index)
		{
			if ((uint)index >= (uint)XlGWzTbBfmAhMjPFhAECJrEzBmuL.Length)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return fFzdyZejXcQVErRsRouIdtutuiGh[index];
		}

		public int IndexOf(string name)
		{
			return Array.IndexOf(fFzdyZejXcQVErRsRouIdtutuiGh, name);
		}

		public int IndexOf(long value)
		{
			return Array.IndexOf(XlGWzTbBfmAhMjPFhAECJrEzBmuL, value);
		}

		public bool Contains(string name)
		{
			return ICjTTAhpBjYQxKkcWQEMxtvcoUS.ContainsKey(name);
		}

		public bool Contains(long value)
		{
			return IndexOf(value) >= 0;
		}
	}
}
