using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace DV.UserManagement.Util
{
	public static class DataProtection
	{
		private const string initVector = "pemgail9uzpgzl88";

		private const int keysize = 256;

		public static string EncryptString(string plainText, byte[] passPhrase)
		{
			return Convert.ToBase64String(EncryptBytes(Encoding.UTF8.GetBytes(plainText), passPhrase));
		}

		public static byte[] EncryptBytes(byte[] inputBytes, byte[] passPhrase)
		{
			byte[] bytes = Encoding.UTF8.GetBytes("pemgail9uzpgzl88");
			byte[] bytes2 = new PasswordDeriveBytes(passPhrase, null).GetBytes(32);
			ICryptoTransform transform = new RijndaelManaged
			{
				Mode = CipherMode.CBC
			}.CreateEncryptor(bytes2, bytes);
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
			cryptoStream.Write(inputBytes, 0, inputBytes.Length);
			cryptoStream.FlushFinalBlock();
			byte[] result = memoryStream.ToArray();
			memoryStream.Close();
			cryptoStream.Close();
			return result;
		}

		public static byte[] DecryptBytes(byte[] cipherTextBytes, byte[] passPhrase)
		{
			byte[] bytes = Encoding.UTF8.GetBytes("pemgail9uzpgzl88");
			byte[] bytes2 = new PasswordDeriveBytes(passPhrase, null).GetBytes(32);
			ICryptoTransform transform = new RijndaelManaged
			{
				Mode = CipherMode.CBC
			}.CreateDecryptor(bytes2, bytes);
			MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
			CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Read);
			MemoryStream memoryStream2 = new MemoryStream();
			cryptoStream.CopyTo(memoryStream2);
			memoryStream.Close();
			cryptoStream.Close();
			memoryStream2.Close();
			return memoryStream2.ToArray();
		}

		public static string DecryptString(string cipherText, byte[] passPhrase)
		{
			byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
			return Encoding.UTF8.GetString(DecryptBytes(cipherTextBytes, passPhrase));
		}
	}
}
