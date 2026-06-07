using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class EnumNameValueCache<TEnum> where TEnum : struct, IComparable, IFormattable
	{
		private static EnumNameValueCache<TEnum> FWaJiGPqFAFaeKnRqEMHyiXbPVAEb;

		private readonly ADictionary<string, TEnum> geGvFuJwMUcxULrewldEuNPUQAIV;

		private readonly string[] cnrLqNbaaQptACPPHoZhMIIlJCKH;

		private readonly long[] ZysGOiiRdIynpVNBhfdaJeyQQhcU;

		public static EnumNameValueCache<TEnum> Default => FWaJiGPqFAFaeKnRqEMHyiXbPVAEb ?? (FWaJiGPqFAFaeKnRqEMHyiXbPVAEb = new EnumNameValueCache<TEnum>());

		public int Count => ZysGOiiRdIynpVNBhfdaJeyQQhcU.Length;

		public static void Free()
		{
			FWaJiGPqFAFaeKnRqEMHyiXbPVAEb = null;
		}

		private EnumNameValueCache()
		{
			Type typeFromHandle = typeof(TEnum);
			if (!EnumTools.IsEnum(typeFromHandle))
			{
				throw new Exception("enumType is not an enum type.");
			}
			Type underlyingEnumType = ReflectionTools.GetUnderlyingEnumType(typeFromHandle);
			cnrLqNbaaQptACPPHoZhMIIlJCKH = Enum.GetNames(typeFromHandle);
			TEnum[] array = (TEnum[])Enum.GetValues(typeFromHandle);
			geGvFuJwMUcxULrewldEuNPUQAIV = new ADictionary<string, TEnum>();
			ZysGOiiRdIynpVNBhfdaJeyQQhcU = new long[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				ZysGOiiRdIynpVNBhfdaJeyQQhcU[i] = MiscTools.ToLongUnchecked(Convert.ChangeType(array[i], underlyingEnumType));
				geGvFuJwMUcxULrewldEuNPUQAIV.Add(cnrLqNbaaQptACPPHoZhMIIlJCKH[i], array[i]);
			}
		}

		public TEnum GetValue(string name)
		{
			return ((ADictionary<string, string>)(object)geGvFuJwMUcxULrewldEuNPUQAIV)[name];
		}

		public bool TryGetValue(string name, out TEnum value)
		{
			return geGvFuJwMUcxULrewldEuNPUQAIV.TryGetValue(name, out value);
		}

		public string GetName(long value)
		{
			int num = IndexOf(value);
			if (num < 0)
			{
				throw new Exception("The value does not exist in the enum.");
			}
			return cnrLqNbaaQptACPPHoZhMIIlJCKH[num];
		}

		public bool TryGetName(long value, out string name)
		{
			int num = IndexOf(value);
			if (num < 0)
			{
				name = string.Empty;
				return false;
			}
			name = cnrLqNbaaQptACPPHoZhMIIlJCKH[num];
			return true;
		}

		public TEnum GetValueAt(int index)
		{
			if ((uint)index >= (uint)ZysGOiiRdIynpVNBhfdaJeyQQhcU.Length)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return ((ADictionary<string, string>)(object)geGvFuJwMUcxULrewldEuNPUQAIV)[cnrLqNbaaQptACPPHoZhMIIlJCKH[index]];
		}

		public string GetNameAt(int index)
		{
			if ((uint)index >= (uint)ZysGOiiRdIynpVNBhfdaJeyQQhcU.Length)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return cnrLqNbaaQptACPPHoZhMIIlJCKH[index];
		}

		public int IndexOf(string name)
		{
			return Array.IndexOf(cnrLqNbaaQptACPPHoZhMIIlJCKH, name);
		}

		public int IndexOf(long value)
		{
			return Array.IndexOf(ZysGOiiRdIynpVNBhfdaJeyQQhcU, value);
		}

		public bool Contains(string name)
		{
			return geGvFuJwMUcxULrewldEuNPUQAIV.ContainsKey(name);
		}

		public bool Contains(long value)
		{
			return IndexOf(value) >= 0;
		}
	}
}
