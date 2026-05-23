using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class EnumNameValueCache<TEnum> where TEnum : struct, IComparable, IFormattable
	{
		private static EnumNameValueCache<TEnum> uvNYvxxoNbiZGCdyAYFjEILHxdmo;

		private readonly ADictionary<string, TEnum> EWokEpliJVGixyUgOOHCsSBpfGj;

		private readonly string[] bTgXOohcFQaZEnRwJOiUqoGwgTz;

		private readonly long[] HeDEduzNjKzgQDdJpbSQuRuwlZX;

		public static EnumNameValueCache<TEnum> Default
		{
			get
			{
				return uvNYvxxoNbiZGCdyAYFjEILHxdmo ?? (uvNYvxxoNbiZGCdyAYFjEILHxdmo = new EnumNameValueCache<TEnum>());
			}
		}

		public int Count
		{
			get
			{
				return HeDEduzNjKzgQDdJpbSQuRuwlZX.Length;
			}
		}

		public static void Free()
		{
			uvNYvxxoNbiZGCdyAYFjEILHxdmo = null;
		}

		private EnumNameValueCache()
		{
			Type typeFromHandle = typeof(TEnum);
			if (!EnumTools.IsEnum(typeFromHandle))
			{
				throw new Exception("enumType is not an enum type.");
			}
			Type underlyingEnumType = ReflectionTools.GetUnderlyingEnumType(typeFromHandle);
			bTgXOohcFQaZEnRwJOiUqoGwgTz = Enum.GetNames(typeFromHandle);
			TEnum[] array = (TEnum[])Enum.GetValues(typeFromHandle);
			EWokEpliJVGixyUgOOHCsSBpfGj = new ADictionary<string, TEnum>();
			HeDEduzNjKzgQDdJpbSQuRuwlZX = new long[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				HeDEduzNjKzgQDdJpbSQuRuwlZX[i] = MiscTools.ToLongUnchecked(Convert.ChangeType(array[i], underlyingEnumType));
				EWokEpliJVGixyUgOOHCsSBpfGj.Add(bTgXOohcFQaZEnRwJOiUqoGwgTz[i], array[i]);
			}
		}

		public TEnum GetValue(string name)
		{
			return EWokEpliJVGixyUgOOHCsSBpfGj[name];
		}

		public bool TryGetValue(string name, out TEnum value)
		{
			return EWokEpliJVGixyUgOOHCsSBpfGj.TryGetValue(name, out value);
		}

		public string GetName(long value)
		{
			int num = IndexOf(value);
			if (num < 0)
			{
				throw new Exception("The value does not exist in the enum.");
			}
			return bTgXOohcFQaZEnRwJOiUqoGwgTz[num];
		}

		public bool TryGetName(long value, out string name)
		{
			int num = IndexOf(value);
			if (num < 0)
			{
				while (true)
				{
					int num2 = -886109013;
					while (true)
					{
						switch (num2 ^ -886109015)
						{
						case 0:
							break;
						case 2:
							goto IL_002a;
						default:
							return false;
						}
						break;
						IL_002a:
						name = string.Empty;
						num2 = -886109016;
					}
				}
			}
			name = bTgXOohcFQaZEnRwJOiUqoGwgTz[num];
			return true;
		}

		public TEnum GetValueAt(int index)
		{
			if ((uint)index >= (uint)HeDEduzNjKzgQDdJpbSQuRuwlZX.Length)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return EWokEpliJVGixyUgOOHCsSBpfGj[bTgXOohcFQaZEnRwJOiUqoGwgTz[index]];
		}

		public string GetNameAt(int index)
		{
			if ((uint)index >= (uint)HeDEduzNjKzgQDdJpbSQuRuwlZX.Length)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return bTgXOohcFQaZEnRwJOiUqoGwgTz[index];
		}

		public int IndexOf(string name)
		{
			return Array.IndexOf(bTgXOohcFQaZEnRwJOiUqoGwgTz, name);
		}

		public int IndexOf(long value)
		{
			return Array.IndexOf(HeDEduzNjKzgQDdJpbSQuRuwlZX, value);
		}

		public bool Contains(string name)
		{
			return EWokEpliJVGixyUgOOHCsSBpfGj.ContainsKey(name);
		}

		public bool Contains(long value)
		{
			return IndexOf(value) >= 0;
		}
	}
}
