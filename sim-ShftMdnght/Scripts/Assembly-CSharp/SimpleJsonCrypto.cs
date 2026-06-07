using System;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public static class SimpleJsonCrypto
{
	private static readonly byte[] Key = Convert.FromBase64String("8f4z1sYw1VZ0bZJ8F6nWQXc5rJX9k3M2KkZb3cT0JqE=");

	public static string EncryptJsonToBase64(string json)
	{
		if (string.IsNullOrEmpty(json))
		{
			return string.Empty;
		}
		using Aes aes = Aes.Create();
		aes.Key = Key;
		aes.Mode = CipherMode.CBC;
		aes.Padding = PaddingMode.PKCS7;
		aes.GenerateIV();
		byte[] bytes = Encoding.UTF8.GetBytes(json);
		using ICryptoTransform cryptoTransform = aes.CreateEncryptor(aes.Key, aes.IV);
		byte[] array = cryptoTransform.TransformFinalBlock(bytes, 0, bytes.Length);
		byte b = 1;
		byte[] array2 = new byte[1 + aes.IV.Length + array.Length];
		array2[0] = b;
		Buffer.BlockCopy(aes.IV, 0, array2, 1, aes.IV.Length);
		Buffer.BlockCopy(array, 0, array2, 1 + aes.IV.Length, array.Length);
		return Convert.ToBase64String(array2);
	}

	public static string DecryptBase64ToJson(string base64)
	{
		if (string.IsNullOrEmpty(base64))
		{
			return string.Empty;
		}
		byte[] array;
		try
		{
			array = Convert.FromBase64String(base64);
		}
		catch
		{
			Debug.LogWarning("Encrypted file is not valid Base64.");
			return string.Empty;
		}
		if (array.Length < 17)
		{
			Debug.LogWarning("Encrypted file is too short (missing version/IV).");
			return string.Empty;
		}
		byte b = array[0];
		if (b != 1)
		{
			Debug.LogWarning($"Unknown encrypted payload version: {b}");
			return string.Empty;
		}
		byte[] array2 = new byte[16];
		Buffer.BlockCopy(array, 1, array2, 0, 16);
		int num = array.Length - 17;
		if (num <= 0)
		{
			Debug.LogWarning("Encrypted file contains no ciphertext.");
			return string.Empty;
		}
		byte[] array3 = new byte[num];
		Buffer.BlockCopy(array, 17, array3, 0, num);
		try
		{
			using Aes aes = Aes.Create();
			aes.Key = Key;
			aes.IV = array2;
			aes.Mode = CipherMode.CBC;
			aes.Padding = PaddingMode.PKCS7;
			using ICryptoTransform cryptoTransform = aes.CreateDecryptor(aes.Key, aes.IV);
			byte[] bytes = cryptoTransform.TransformFinalBlock(array3, 0, array3.Length);
			return Encoding.UTF8.GetString(bytes);
		}
		catch (CryptographicException)
		{
			Debug.LogWarning("Failed to decrypt (wrong key or corrupted file).");
			return string.Empty;
		}
	}
}
