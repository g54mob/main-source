using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace Jundroo.Common.Cryptography
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

		public static string MD5(Stream stream)
		{
			using MD5 algorithm = System.Security.Cryptography.MD5.Create();
			return ComputeHash(algorithm, stream);
		}

		public static string MD5(string filePath)
		{
			using FileStream stream = File.OpenRead(filePath);
			return MD5(stream);
		}

		public static string SHA512(string value, string salt, Encoding encoding = null)
		{
			if (encoding == null)
			{
				encoding = Encoding.Default;
			}
			byte[] bytes = encoding.GetBytes(value);
			byte[] array = (string.IsNullOrWhiteSpace(salt) ? new byte[0] : encoding.GetBytes(salt));
			byte[] array2 = new byte[bytes.Length + array.Length];
			Buffer.BlockCopy(bytes, 0, array2, 0, bytes.Length);
			Buffer.BlockCopy(array, 0, array2, bytes.Length, array.Length);
			return SHA512(array2);
		}

		public static string SHA512(byte[] bytes)
		{
			using SHA512 algorithm = System.Security.Cryptography.SHA512.Create();
			return ComputeHash(algorithm, bytes);
		}

		private static string ComputeHash(HashAlgorithm algorithm, byte[] bytes)
		{
			return HashBytesToString(algorithm.ComputeHash(bytes));
		}

		private static string ComputeHash(HashAlgorithm algorithm, Stream stream)
		{
			return HashBytesToString(algorithm.ComputeHash(stream));
		}

		private static string HashBytesToString(byte[] hashBytes)
		{
			int num = hashBytes.Length;
			StringBuilder stringBuilder = new StringBuilder(num * 2);
			for (int i = 0; i < num; i++)
			{
				stringBuilder.Append(_byteToHexLookup[hashBytes[i]]);
			}
			return stringBuilder.ToString();
		}
	}
}
