using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class EnumNameValueCache<TEnum> where TEnum : struct, IComparable, IFormattable
	{
		private static EnumNameValueCache<TEnum> MrizsvSulKaCOWEgXXwzVKMaWvQ;

		private readonly ADictionary<string, TEnum> cpRGaehUgyUvvrTOXgCTzpMGtGmP;

		private readonly string[] VIDPVjIqwdGoCECCWkaZifJXlssL;

		private readonly long[] lfgHStUdQhmOGyivkzSVtBfBVaO;

		public static EnumNameValueCache<TEnum> Default => MrizsvSulKaCOWEgXXwzVKMaWvQ ?? (MrizsvSulKaCOWEgXXwzVKMaWvQ = new EnumNameValueCache<TEnum>());

		public int Count => lfgHStUdQhmOGyivkzSVtBfBVaO.Length;

		public static void Free()
		{
			MrizsvSulKaCOWEgXXwzVKMaWvQ = null;
		}

		private EnumNameValueCache()
		{
			Type typeFromHandle = typeof(TEnum);
			if (!EnumTools.IsEnum(typeFromHandle))
			{
				throw new Exception("enumType is not an enum type.");
			}
			Type underlyingEnumType = ReflectionTools.GetUnderlyingEnumType(typeFromHandle);
			VIDPVjIqwdGoCECCWkaZifJXlssL = Enum.GetNames(typeFromHandle);
			TEnum[] array = (TEnum[])Enum.GetValues(typeFromHandle);
			cpRGaehUgyUvvrTOXgCTzpMGtGmP = new ADictionary<string, TEnum>();
			lfgHStUdQhmOGyivkzSVtBfBVaO = new long[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				lfgHStUdQhmOGyivkzSVtBfBVaO[i] = MiscTools.ToLongUnchecked(Convert.ChangeType(array[i], underlyingEnumType));
				cpRGaehUgyUvvrTOXgCTzpMGtGmP.Add(VIDPVjIqwdGoCECCWkaZifJXlssL[i], array[i]);
			}
		}

		public TEnum GetValue(string name)
		{
			return cpRGaehUgyUvvrTOXgCTzpMGtGmP[name];
		}

		public bool TryGetValue(string name, out TEnum value)
		{
			return cpRGaehUgyUvvrTOXgCTzpMGtGmP.TryGetValue(name, out value);
		}

		public string GetName(long value)
		{
			int num = IndexOf(value);
			if (num < 0)
			{
				throw new Exception("The value does not exist in the enum.");
			}
			return VIDPVjIqwdGoCECCWkaZifJXlssL[num];
		}

		public bool TryGetName(long value, out string name)
		{
			int num = IndexOf(value);
			if (num < 0)
			{
				name = string.Empty;
				return false;
			}
			name = VIDPVjIqwdGoCECCWkaZifJXlssL[num];
			return true;
		}

		public TEnum GetValueAt(int index)
		{
			if ((uint)index >= (uint)lfgHStUdQhmOGyivkzSVtBfBVaO.Length)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return cpRGaehUgyUvvrTOXgCTzpMGtGmP[VIDPVjIqwdGoCECCWkaZifJXlssL[index]];
		}

		public string GetNameAt(int index)
		{
			if ((uint)index >= (uint)lfgHStUdQhmOGyivkzSVtBfBVaO.Length)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return VIDPVjIqwdGoCECCWkaZifJXlssL[index];
		}

		public int IndexOf(string name)
		{
			return Array.IndexOf(VIDPVjIqwdGoCECCWkaZifJXlssL, name);
		}

		public int IndexOf(long value)
		{
			return Array.IndexOf(lfgHStUdQhmOGyivkzSVtBfBVaO, value);
		}

		public bool Contains(string name)
		{
			return cpRGaehUgyUvvrTOXgCTzpMGtGmP.ContainsKey(name);
		}

		public bool Contains(long value)
		{
			return IndexOf(value) >= 0;
		}
	}
}
