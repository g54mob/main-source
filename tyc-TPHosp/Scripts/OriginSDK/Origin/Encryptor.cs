using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Origin
{
	public class Encryptor
	{
		private static byte[] key = new byte[16];

		public static void SetKey(uint seed)
		{
			if (seed == 0)
			{
				for (int i = 0; i < key.Length; i++)
				{
					key[i] = (byte)i;
				}
				return;
			}
			Random.srand(7u);
			Random.srand(Random.rand() + seed);
			for (int j = 0; j < key.Length; j++)
			{
				key[j] = (byte)(Random.rand() & 0xFF);
			}
		}

		private static byte[] EncryptStringToBytes(string plainText, byte[] Key, byte[] IV)
		{
			if (plainText == null || plainText.Length <= 0)
			{
				throw new ArgumentNullException("plainText");
			}
			if (Key == null || Key.Length <= 0)
			{
				throw new ArgumentNullException("Key");
			}
			if (IV == null || IV.Length <= 0)
			{
				throw new ArgumentNullException("Key");
			}
			using RijndaelManaged rijndaelManaged = new RijndaelManaged();
			rijndaelManaged.Key = Key;
			rijndaelManaged.IV = IV;
			rijndaelManaged.Mode = CipherMode.ECB;
			ICryptoTransform transform = rijndaelManaged.CreateEncryptor(rijndaelManaged.Key, rijndaelManaged.IV);
			using MemoryStream memoryStream = new MemoryStream();
			using CryptoStream stream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
			using (StreamWriter streamWriter = new StreamWriter(stream))
			{
				streamWriter.Write(plainText);
			}
			return memoryStream.ToArray();
		}

		private static string DecryptStringFromBytes(byte[] cipherText, byte[] Key, byte[] IV)
		{
			if (cipherText == null || cipherText.Length <= 0)
			{
				throw new ArgumentNullException("cipherText");
			}
			if (Key == null || Key.Length <= 0)
			{
				throw new ArgumentNullException("Key");
			}
			if (IV == null || IV.Length <= 0)
			{
				throw new ArgumentNullException("Key");
			}
			string text = null;
			using RijndaelManaged rijndaelManaged = new RijndaelManaged();
			rijndaelManaged.Key = Key;
			rijndaelManaged.IV = IV;
			rijndaelManaged.Mode = CipherMode.ECB;
			ICryptoTransform transform = rijndaelManaged.CreateDecryptor(rijndaelManaged.Key, rijndaelManaged.IV);
			using MemoryStream stream = new MemoryStream(cipherText);
			using CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Read);
			using StreamReader streamReader = new StreamReader(stream2, Encoding.UTF8);
			return streamReader.ReadToEnd();
		}

		public static byte[] encrypt(string msg)
		{
			return EncryptStringToBytes(msg, key, new byte[16]);
		}

		public static string decrypt(byte[] msg)
		{
			return DecryptStringFromBytes(msg, key, new byte[16]);
		}

		public static string ByteArrayToString(byte[] ba)
		{
			StringBuilder stringBuilder = new StringBuilder(ba.Length * 2);
			for (int i = 0; i < ba.Length; i++)
			{
				stringBuilder.AppendFormat("{0:x2}", ba[i]);
			}
			return stringBuilder.ToString();
		}

		public static string ByteArrayToString(byte[] ba, int len)
		{
			StringBuilder stringBuilder = new StringBuilder(len * 2);
			for (int i = 0; i < len; i++)
			{
				stringBuilder.AppendFormat("{0:x2}", ba[i]);
			}
			return stringBuilder.ToString();
		}

		public static byte[] StringToByteArray(string s)
		{
			byte[] array = new byte[s.Length / 2];
			for (int i = 0; i < s.Length; i += 2)
			{
				array[i / 2] = Convert.ToByte(s.Substring(i, 2), 16);
			}
			return array;
		}

		public static byte[] StringToByteArray(string s, int len)
		{
			byte[] array = new byte[len / 2];
			for (int i = 0; i < len; i += 2)
			{
				array[i / 2] = Convert.ToByte(s.Substring(i, 2), 16);
			}
			return array;
		}
	}
}
