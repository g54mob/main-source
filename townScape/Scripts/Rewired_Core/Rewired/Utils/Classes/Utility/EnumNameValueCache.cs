using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation]
	[CustomClassObfuscation]
	internal sealed class EnumNameValueCache<TEnum> where TEnum : struct, IComparable, IFormattable
	{
		private static EnumNameValueCache<TEnum> BipqDsxmzicPZpuwvLSJXNCGnAk;

		private readonly ADictionary<string, TEnum> ddIOvyzShCshmwlojEIoJjWcXlpp;

		private readonly string[] SfQiQtfjtTKkDWjwksownuDbiRv;

		private readonly long[] eMjzXdnSJLfQVLrRYUAgbFptALHG;

		public static EnumNameValueCache<TEnum> Default => null;

		public int Count => 0;

		public static void Free()
		{
		}

		private EnumNameValueCache()
		{
		}

		public TEnum GetValue(string name)
		{
			return default(TEnum);
		}

		public bool TryGetValue(string name, out TEnum value)
		{
			value = default(TEnum);
			return false;
		}

		public string GetName(long value)
		{
			return null;
		}

		public bool TryGetName(long value, out string name)
		{
			name = null;
			return false;
		}

		public TEnum GetValueAt(int index)
		{
			return default(TEnum);
		}

		public string GetNameAt(int index)
		{
			return null;
		}

		public int IndexOf(string name)
		{
			return 0;
		}

		public int IndexOf(long value)
		{
			return 0;
		}

		public bool Contains(string name)
		{
			return false;
		}

		public bool Contains(long value)
		{
			return false;
		}
	}
}
