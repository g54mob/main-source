using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class EnumNameValueCache<TEnum> where TEnum : struct, IFormattable, IComparable
	{
		private static EnumNameValueCache<TEnum> AFQWXYDiFivvlrNUgfYqbvScZMtr;

		private readonly ADictionary<string, TEnum> oGhUQYXZjYwUekEjoFaTTYjGKveD;

		private readonly string[] FjtczNJODBbfjzQQfHpBHZLVkmwQ;

		private readonly long[] fpKyQVVRtVTHrZDhZIZVLdtLBoQiA;

		public static EnumNameValueCache<TEnum> Default => AFQWXYDiFivvlrNUgfYqbvScZMtr ?? (AFQWXYDiFivvlrNUgfYqbvScZMtr = new EnumNameValueCache<TEnum>());

		public int Count => fpKyQVVRtVTHrZDhZIZVLdtLBoQiA.Length;

		public static void Free()
		{
			AFQWXYDiFivvlrNUgfYqbvScZMtr = null;
		}

		private EnumNameValueCache()
		{
			Type typeFromHandle = typeof(TEnum);
			if (!EnumTools.IsEnum(typeFromHandle))
			{
				throw new Exception("enumType is not an enum type.");
			}
			Type underlyingEnumType = ReflectionTools.GetUnderlyingEnumType(typeFromHandle);
			FjtczNJODBbfjzQQfHpBHZLVkmwQ = Enum.GetNames(typeFromHandle);
			TEnum[] array = (TEnum[])Enum.GetValues(typeFromHandle);
			oGhUQYXZjYwUekEjoFaTTYjGKveD = new ADictionary<string, TEnum>();
			fpKyQVVRtVTHrZDhZIZVLdtLBoQiA = new long[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				fpKyQVVRtVTHrZDhZIZVLdtLBoQiA[i] = MiscTools.ToLongUnchecked(Convert.ChangeType(array[i], underlyingEnumType));
				oGhUQYXZjYwUekEjoFaTTYjGKveD.Add(FjtczNJODBbfjzQQfHpBHZLVkmwQ[i], array[i]);
			}
		}

		public TEnum GetValue(string name)
		{
			return oGhUQYXZjYwUekEjoFaTTYjGKveD[name];
		}

		public bool TryGetValue(string name, out TEnum value)
		{
			return oGhUQYXZjYwUekEjoFaTTYjGKveD.TryGetValue(name, out value);
		}

		public string GetName(long value)
		{
			int num = IndexOf(value);
			if (num < 0)
			{
				throw new Exception("The value does not exist in the enum.");
			}
			return FjtczNJODBbfjzQQfHpBHZLVkmwQ[num];
		}

		public bool TryGetName(long value, out string name)
		{
			int num = IndexOf(value);
			if (num < 0)
			{
				name = string.Empty;
				return false;
			}
			name = FjtczNJODBbfjzQQfHpBHZLVkmwQ[num];
			return true;
		}

		public TEnum GetValueAt(int index)
		{
			if ((uint)index >= (uint)fpKyQVVRtVTHrZDhZIZVLdtLBoQiA.Length)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return oGhUQYXZjYwUekEjoFaTTYjGKveD[FjtczNJODBbfjzQQfHpBHZLVkmwQ[index]];
		}

		public string GetNameAt(int index)
		{
			if ((uint)index >= (uint)fpKyQVVRtVTHrZDhZIZVLdtLBoQiA.Length)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return FjtczNJODBbfjzQQfHpBHZLVkmwQ[index];
		}

		public int IndexOf(string name)
		{
			return Array.IndexOf(FjtczNJODBbfjzQQfHpBHZLVkmwQ, name);
		}

		public int IndexOf(long value)
		{
			return Array.IndexOf(fpKyQVVRtVTHrZDhZIZVLdtLBoQiA, value);
		}

		public bool Contains(string name)
		{
			return oGhUQYXZjYwUekEjoFaTTYjGKveD.ContainsKey(name);
		}

		public bool Contains(long value)
		{
			return IndexOf(value) >= 0;
		}
	}
}
