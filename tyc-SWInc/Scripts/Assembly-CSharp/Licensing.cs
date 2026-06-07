using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Licensing : MonoBehaviour
{
	public GameObject Panel;

	public Text text;

	public InputField KeyText;

	private ICryptoTransform encryptor;

	private ICryptoTransform decryptor;

	public static string LicenseFile = "VK";

	public static string LicenseFile2 = "VK2";

	private void Start()
	{
		Panel.SetActive(false);
	}

	public byte[] GetKey()
	{
		byte[] array = BytesFromString(SystemInfo.deviceUniqueIdentifier);
		byte[] array2 = BytesFromString(SystemInfo.deviceUniqueIdentifier.Reverse().ToString());
		byte[] array3 = new byte[32];
		for (int i = 0; i < array3.Length; i++)
		{
			array3[i] = (byte)(array[i] + array2[i] % 255);
		}
		return array3;
	}

	public string StringFromBytes(byte[] bytes)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < bytes.Length; i++)
		{
			stringBuilder.Append((char)bytes[i]);
		}
		return stringBuilder.ToString();
	}

	public byte[] BytesFromString(string txt)
	{
		byte[] array = new byte[txt.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = (byte)txt[i];
		}
		return array;
	}

	public void Validate()
	{
		if (CheckFormat(KeyText.text))
		{
			if (KeyValue(KeyText.text) == 21)
			{
				PlayerPrefs.SetString(LicenseFile2, KeyText.text);
				PlayerPrefs.Save();
				Panel.SetActive(false);
			}
			else
			{
				text.text = "Key not valid";
			}
		}
		else
		{
			text.text = "Key was formatted incorrectly";
		}
	}

	private bool CheckFormat(string input)
	{
		if (input == null || input.Length != 19)
		{
			return false;
		}
		for (int i = 0; i < 19; i++)
		{
			if ((i + 1) % 5 == 0)
			{
				if (input[i] != '-')
				{
					return false;
				}
			}
			else if (!char.IsDigit(input[i]))
			{
				return false;
			}
		}
		return input.Length == 19;
	}

	private int KeyValue(string key)
	{
		int num = 0;
		char[] array = key.ToArray();
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] != '-')
			{
				int num2 = Convert.ToInt32(array[i].ToString());
				char c = array[(i + num2) % array.Length];
				if (c != '-')
				{
					num += Convert.ToInt32(c.ToString());
				}
			}
		}
		return num;
	}
}
