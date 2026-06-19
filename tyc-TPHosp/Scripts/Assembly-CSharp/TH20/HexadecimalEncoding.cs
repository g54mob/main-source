using System;
using System.Text;

namespace TH20
{
	public static class HexadecimalEncoding
	{
		public static string ToHexString(string str)
		{
			StringBuilder stringBuilder = new StringBuilder();
			byte[] bytes = Encoding.Unicode.GetBytes(str);
			foreach (byte b in bytes)
			{
				stringBuilder.Append(b.ToString("X2"));
			}
			return stringBuilder.ToString();
		}

		public static string FromHexString(string hexString)
		{
			byte[] array = new byte[hexString.Length / 2];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
			}
			return Encoding.Unicode.GetString(array);
		}
	}
}
