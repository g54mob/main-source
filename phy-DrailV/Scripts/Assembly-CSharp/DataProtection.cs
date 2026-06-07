using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public static class DataProtection
{
	private const string initVector = "pemgail9uzpgzl88";

	private const int keysize = 256;

	public static string EncryptString(string plainText, string passPhrase)
	{
		byte[] bytes = Encoding.UTF8.GetBytes("pemgail9uzpgzl88");
		byte[] bytes2 = Encoding.UTF8.GetBytes(plainText);
		byte[] bytes3 = new PasswordDeriveBytes(passPhrase, null).GetBytes(32);
		ICryptoTransform transform = new RijndaelManaged
		{
			Mode = CipherMode.CBC
		}.CreateEncryptor(bytes3, bytes);
		MemoryStream memoryStream = new MemoryStream();
		CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
		cryptoStream.Write(bytes2, 0, bytes2.Length);
		cryptoStream.FlushFinalBlock();
		byte[] inArray = memoryStream.ToArray();
		memoryStream.Close();
		cryptoStream.Close();
		return Convert.ToBase64String(inArray);
	}

	public static string DecryptString(string cipherText, string passPhrase)
	{
		byte[] bytes = Encoding.UTF8.GetBytes("pemgail9uzpgzl88");
		byte[] buffer = Convert.FromBase64String(cipherText);
		byte[] bytes2 = new PasswordDeriveBytes(passPhrase, null).GetBytes(32);
		ICryptoTransform transform = new RijndaelManaged
		{
			Mode = CipherMode.CBC
		}.CreateDecryptor(bytes2, bytes);
		MemoryStream memoryStream = new MemoryStream(buffer);
		CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Read);
		MemoryStream memoryStream2 = new MemoryStream();
		cryptoStream.CopyTo(memoryStream2);
		memoryStream.Close();
		cryptoStream.Close();
		memoryStream2.Close();
		return Encoding.UTF8.GetString(memoryStream2.ToArray());
	}
}
