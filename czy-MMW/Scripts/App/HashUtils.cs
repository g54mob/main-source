using System;
using System.Security.Cryptography;
using System.Text;
using JetBrains.Annotations;

public static class HashUtils
{
	public static string GetMD5([CanBeNull] string sourceString)
	{
		byte[] bytes = new UTF8Encoding().GetBytes(sourceString ?? "");
		byte[] array = new MD5CryptoServiceProvider().ComputeHash(bytes);
		string text = "";
		for (int i = 0; i < array.Length; i++)
		{
			text += Convert.ToString(array[i], 16).PadLeft(2, '0');
		}
		return text.PadLeft(32, '0');
	}
}
