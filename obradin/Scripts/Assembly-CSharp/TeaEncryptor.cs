using System;
using System.Text;

public class TeaEncryptor
{
	private readonly string _cryptoKey;

	private static UTF8Encoding _encoding = new UTF8Encoding();

	private const short CRYPTO_KEY_LENGTH = 16;

	private const short MIN_ENCRYPTION_LENGTH = 6;

	public TeaEncryptor(string cryptoKey)
	{
		int length = cryptoKey.Length;
		if (length > 16)
		{
			cryptoKey = cryptoKey.Substring(0, 16);
		}
		else if (length < 16)
		{
			cryptoKey = cryptoKey.PadRight(16, ' ');
		}
		_cryptoKey = cryptoKey;
	}

	public string Encrypt(string text)
	{
		byte[] byteForEncryption = GetByteForEncryption(text);
		uint[] array = ToLongs(byteForEncryption);
		uint[] array2 = ToLongs(_encoding.GetBytes(_cryptoKey.Substring(0, 16)));
		uint num = (uint)array.Length;
		uint num2 = array[num - 1];
		uint num3 = array[0];
		uint num4 = 2654435769u;
		uint num5 = 6 + 52 / num;
		uint num6 = 0u;
		uint num7 = 0u;
		while (num5-- != 0)
		{
			num6 += num4;
			uint num8 = (num6 >> 2) & 3;
			for (num7 = 0u; num7 < num - 1; num7++)
			{
				num3 = array[num7 + 1];
				num2 = (array[num7] += (((num2 >> 5) ^ (num3 << 2)) + ((num3 >> 3) ^ (num2 << 4))) ^ ((num6 ^ num3) + (array2[(num7 & 3) ^ num8] ^ num2)));
			}
			num3 = array[0];
			num2 = (array[num - 1] += (((num2 >> 5) ^ (num3 << 2)) + ((num3 >> 3) ^ (num2 << 4))) ^ ((num6 ^ num3) + (array2[(num7 & 3) ^ num8] ^ num2)));
		}
		return Convert.ToBase64String(ToBytes(array));
	}

	private byte[] GetByteForEncryption(string text)
	{
		byte[] array = _encoding.GetBytes(text);
		if (array.Length < 6)
		{
			byte[] array2 = new byte[6];
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i] = 0;
			}
			Buffer.BlockCopy(array, 0, array2, 0, array.Length);
			array = array2;
		}
		return array;
	}

	public string Decrypt(string encrypted)
	{
		if (encrypted.Length == 0)
		{
			return string.Empty;
		}
		try
		{
			uint[] array = ToLongs(Convert.FromBase64String(encrypted));
			uint[] array2 = ToLongs(_encoding.GetBytes(_cryptoKey.Substring(0, 16)));
			if (array.Length == 0)
			{
				return null;
			}
			uint num = (uint)array.Length;
			uint num2 = array[num - 1];
			uint num3 = array[0];
			uint num4 = 2654435769u;
			uint num5 = 6 + 52 / num;
			uint num6 = num5 * num4;
			uint num7 = 0u;
			while (num6 != 0)
			{
				uint num8 = (num6 >> 2) & 3;
				for (num7 = num - 1; num7 != 0; num7--)
				{
					num2 = array[num7 - 1];
					num3 = (array[num7] -= (((num2 >> 5) ^ (num3 << 2)) + ((num3 >> 3) ^ (num2 << 4))) ^ ((num6 ^ num3) + (array2[(num7 & 3) ^ num8] ^ num2)));
				}
				num2 = array[num - 1];
				num3 = (array[0] -= (((num2 >> 5) ^ (num3 << 2)) + ((num3 >> 3) ^ (num2 << 4))) ^ ((num6 ^ num3) + (array2[(num7 & 3) ^ num8] ^ num2)));
				num6 -= num4;
			}
			return _encoding.GetString(ToBytes(array)).TrimEnd(default(char));
		}
		catch
		{
		}
		return null;
	}

	private uint[] ToLongs(byte[] s)
	{
		uint[] array = new uint[(int)Math.Ceiling((decimal)s.Length / 4m)];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = (uint)(s[i * 4] + ((i * 4 + 1 < s.Length) ? (s[i * 4 + 1] << 8) : 0) + ((i * 4 + 2 < s.Length) ? (s[i * 4 + 2] << 16) : 0) + ((i * 4 + 3 < s.Length) ? (s[i * 4 + 3] << 24) : 0));
		}
		return array;
	}

	private byte[] ToBytes(uint[] l)
	{
		byte[] array = new byte[l.Length * 4];
		for (int i = 0; i < l.Length; i++)
		{
			array[i * 4] = (byte)(l[i] & 0xFF);
			array[i * 4 + 1] = (byte)(l[i] >> 8);
			array[i * 4 + 2] = (byte)(l[i] >> 16);
			array[i * 4 + 3] = (byte)(l[i] >> 24);
		}
		return array;
	}
}
