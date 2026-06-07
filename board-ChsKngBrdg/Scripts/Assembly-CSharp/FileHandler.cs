using System.IO;
using UnityEngine;

public class FileHandler : MonoBehaviour
{
	public static void WriteString(string path, string input, bool doEncrypt = false)
	{
		path = Application.persistentDataPath + "/" + path + ".txt";
		if (doEncrypt)
		{
			input = Encryptor.Encrypt(input);
		}
		File.WriteAllText(path, input);
	}

	public static string ReadString(string path, bool doDecrypt = false)
	{
		try
		{
			path = Application.persistentDataPath + "/" + path + ".txt";
			string text = File.ReadAllText(path);
			if (doDecrypt)
			{
				text = Encryptor.Decrypted(text);
			}
			return text;
		}
		catch
		{
			return null;
		}
	}
}
