using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class EnumNameValueCache<TEnum> where TEnum : struct, IComparable, IFormattable
	{
		private static EnumNameValueCache<TEnum> JdjbpQEKEmdDxNxUKRxCUOzcjxuX;

		private readonly ADictionary<string, TEnum> yxDFSuOIRgdATJjhGKQPCJxRNykl;

		private readonly string[] yjecEJmjzwCILaUQxoTiocumNrgAb;

		private readonly long[] DcfSLanAiaLKyRmGXQQlfTMNNFCM;

		public static EnumNameValueCache<TEnum> Default => JdjbpQEKEmdDxNxUKRxCUOzcjxuX ?? (JdjbpQEKEmdDxNxUKRxCUOzcjxuX = new EnumNameValueCache<TEnum>());

		public int Count => DcfSLanAiaLKyRmGXQQlfTMNNFCM.Length;

		public static void Free()
		{
			JdjbpQEKEmdDxNxUKRxCUOzcjxuX = null;
		}

		private EnumNameValueCache()
		{
			Type typeFromHandle = typeof(TEnum);
			if (!EnumTools.IsEnum(typeFromHandle))
			{
				throw new Exception("enumType is not an enum type.");
			}
			Type underlyingEnumType = ReflectionTools.GetUnderlyingEnumType(typeFromHandle);
			yjecEJmjzwCILaUQxoTiocumNrgAb = Enum.GetNames(typeFromHandle);
			TEnum[] array = (TEnum[])Enum.GetValues(typeFromHandle);
			yxDFSuOIRgdATJjhGKQPCJxRNykl = new ADictionary<string, TEnum>();
			DcfSLanAiaLKyRmGXQQlfTMNNFCM = new long[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				DcfSLanAiaLKyRmGXQQlfTMNNFCM[i] = MiscTools.ToLongUnchecked(Convert.ChangeType(array[i], underlyingEnumType));
				yxDFSuOIRgdATJjhGKQPCJxRNykl.Add(yjecEJmjzwCILaUQxoTiocumNrgAb[i], array[i]);
			}
		}

		public TEnum GetValue(string name)
		{
			return ((ADictionary<string, string>)(object)yxDFSuOIRgdATJjhGKQPCJxRNykl)[name];
		}

		public bool TryGetValue(string name, out TEnum value)
		{
			return yxDFSuOIRgdATJjhGKQPCJxRNykl.TryGetValue(name, out value);
		}

		public string GetName(long value)
		{
			int num = IndexOf(value);
			if (num < 0)
			{
				throw new Exception("The value does not exist in the enum.");
			}
			return yjecEJmjzwCILaUQxoTiocumNrgAb[num];
		}

		public bool TryGetName(long value, out string name)
		{
			int num = IndexOf(value);
			if (num < 0)
			{
				name = string.Empty;
				return false;
			}
			name = yjecEJmjzwCILaUQxoTiocumNrgAb[num];
			return true;
		}

		public TEnum GetValueAt(int index)
		{
			if ((uint)index >= (uint)DcfSLanAiaLKyRmGXQQlfTMNNFCM.Length)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return ((ADictionary<string, string>)(object)yxDFSuOIRgdATJjhGKQPCJxRNykl)[yjecEJmjzwCILaUQxoTiocumNrgAb[index]];
		}

		public string GetNameAt(int index)
		{
			if ((uint)index >= (uint)DcfSLanAiaLKyRmGXQQlfTMNNFCM.Length)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return yjecEJmjzwCILaUQxoTiocumNrgAb[index];
		}

		public int IndexOf(string name)
		{
			return Array.IndexOf(yjecEJmjzwCILaUQxoTiocumNrgAb, name);
		}

		public int IndexOf(long value)
		{
			return Array.IndexOf(DcfSLanAiaLKyRmGXQQlfTMNNFCM, value);
		}

		public bool Contains(string name)
		{
			return yxDFSuOIRgdATJjhGKQPCJxRNykl.ContainsKey(name);
		}

		public bool Contains(long value)
		{
			return IndexOf(value) >= 0;
		}
	}
}
