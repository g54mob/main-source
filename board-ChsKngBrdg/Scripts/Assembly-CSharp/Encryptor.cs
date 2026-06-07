using System;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class Encryptor : MonoBehaviour
{
	public static string IV = "1a1a1a1a1a1a1a1a";

	public static string Key = "1a1a1a1a1a1a1a1a1a1a1a1a1a1a1a13";

	public static string Encrypt(string decrypted)
	{
		byte[] bytes = Encoding.ASCII.GetBytes(decrypted);
		AesCryptoServiceProvider aesCryptoServiceProvider = new AesCryptoServiceProvider();
		aesCryptoServiceProvider.BlockSize = 128;
		aesCryptoServiceProvider.KeySize = 256;
		aesCryptoServiceProvider.IV = Encoding.ASCII.GetBytes(IV);
		aesCryptoServiceProvider.Key = Encoding.ASCII.GetBytes(Key);
		aesCryptoServiceProvider.Padding = PaddingMode.PKCS7;
		aesCryptoServiceProvider.Mode = CipherMode.CBC;
		ICryptoTransform cryptoTransform = aesCryptoServiceProvider.CreateEncryptor(aesCryptoServiceProvider.Key, aesCryptoServiceProvider.IV);
		byte[] inArray = cryptoTransform.TransformFinalBlock(bytes, 0, bytes.Length);
		cryptoTransform.Dispose();
		return Convert.ToBase64String(inArray);
	}

	public static string Decrypted(string encrypted)
	{
		byte[] array = Convert.FromBase64String(encrypted);
		AesCryptoServiceProvider aesCryptoServiceProvider = new AesCryptoServiceProvider();
		aesCryptoServiceProvider.BlockSize = 128;
		aesCryptoServiceProvider.KeySize = 256;
		aesCryptoServiceProvider.IV = Encoding.ASCII.GetBytes(IV);
		aesCryptoServiceProvider.Key = Encoding.ASCII.GetBytes(Key);
		aesCryptoServiceProvider.Padding = PaddingMode.PKCS7;
		aesCryptoServiceProvider.Mode = CipherMode.CBC;
		ICryptoTransform cryptoTransform = aesCryptoServiceProvider.CreateDecryptor(aesCryptoServiceProvider.Key, aesCryptoServiceProvider.IV);
		byte[] bytes = cryptoTransform.TransformFinalBlock(array, 0, array.Length);
		cryptoTransform.Dispose();
		return Encoding.ASCII.GetString(bytes);
	}
}
