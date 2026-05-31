using System;
using System.Security.Cryptography;
using System.Text;

public static class Crypto
{
	private const string saltIndiatior = "MySaltIndacationString";

	private const int startSaltLength = 32;

	private const int endSaltLength = 32;

	public static string RandomString(int length)
	{
		string text = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*<>+-=_";
		char[] array = new char[length];
		Random random = new Random();
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = text[random.Next(text.Length)];
		}
		return new string(array);
	}

	private static string GetSalt(int max)
	{
		byte[] array = new byte[max];
		RandomNumberGenerator.Create().GetNonZeroBytes(array);
		return Encoding.UTF8.GetString(array);
	}

	public static string Encrypt(string toEncrypt, string key)
	{
		string text = RandomString(32);
		string salt = GetSalt(32);
		byte[] bytes = Encoding.UTF8.GetBytes(key);
		byte[] bytes2 = Encoding.UTF8.GetBytes(text + "MySaltIndacationString{" + salt.Length + "}" + toEncrypt + salt);
		byte[] array = new RijndaelManaged
		{
			Key = bytes,
			Mode = CipherMode.ECB,
			Padding = PaddingMode.PKCS7
		}.CreateEncryptor().TransformFinalBlock(bytes2, 0, bytes2.Length);
		return Convert.ToBase64String(array, 0, array.Length);
	}

	public static string Decrypt(string toDecrypt, string key)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(key);
		byte[] array = Convert.FromBase64String(toDecrypt);
		byte[] bytes2 = new RijndaelManaged
		{
			Key = bytes,
			Mode = CipherMode.ECB,
			Padding = PaddingMode.PKCS7
		}.CreateDecryptor().TransformFinalBlock(array, 0, array.Length);
		string text = Encoding.UTF8.GetString(bytes2);
		text = text.Remove(0, 32);
		if (text.StartsWith("MySaltIndacationString"))
		{
			string text2 = text.Substring(0, 1 + text.IndexOf("}"));
			int num = int.Parse(text2.Replace("MySaltIndacationString", "").Replace("{", "").Replace("}", ""));
			text = text.Remove(0, text2.Length);
			if (num > 0)
			{
				text = text.Remove(text.Length - num, num);
			}
			return text;
		}
		return text;
	}
}
