using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace ModApi.Common.Cryptography
{
	public static class Hash
	{
		private static string[] _byteToHexLookup = (from x in Enumerable.Range(0, 256)
			select x.ToString("x2")).ToArray();

		public static string MD5(string value, Encoding encoding = null)
		{
			if (encoding == null)
			{
				encoding = Encoding.Default;
			}
			return MD5(encoding.GetBytes(value));
		}

		public static string MD5(XNode xml, Encoding encoding = null)
		{
			if (encoding == null)
			{
				encoding = Encoding.UTF8;
			}
			return MD5(encoding.GetBytes(xml.ToString(SaveOptions.DisableFormatting)));
		}

		public static string MD5(byte[] bytes)
		{
			using MD5 algorithm = System.Security.Cryptography.MD5.Create();
			return ComputeHash(algorithm, bytes);
		}

		private static string ComputeHash(HashAlgorithm algorithm, byte[] bytes)
		{
			byte[] array = algorithm.ComputeHash(bytes);
			int num = array.Length;
			StringBuilder stringBuilder = new StringBuilder(num * 2);
			for (int i = 0; i < num; i++)
			{
				stringBuilder.Append(_byteToHexLookup[array[i]]);
			}
			return stringBuilder.ToString();
		}
	}
}
