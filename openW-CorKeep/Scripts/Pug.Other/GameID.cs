using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class GameID
{
	private const string MagicString = "gameid:";

	private const int SaltSize = 32;

	private const int HashSize = 32;

	private const int Iterations = 33333;

	private const int PasswordLength = 5;

	public static readonly char[] characterPool = new char[32]
	{
		'1', '2', '3', '4', '5', '6', '7', '8', '9', 'A',
		'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'L',
		'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W',
		'X', 'Z'
	};

	public string fullId;

	public string id;

	public string password;

	private RNGCryptoServiceProvider _rngCsp = new RNGCryptoServiceProvider();

	private Aes _aes = Aes.Create();

	public string PublicID => id;

	public GameID(int idLength)
	{
		id = Generate(idLength);
		password = Generate(5);
		fullId = password + id;
	}

	public GameID(string gameId)
	{
		fullId = gameId;
		password = gameId.Substring(0, Math.Min(5, gameId.Length));
		id = gameId.Substring(Math.Min(5, gameId.Length));
	}

	private string Generate(int length)
	{
		StringBuilder stringBuilder = new StringBuilder(length);
		for (int i = 0; i < stringBuilder.Capacity; i++)
		{
			stringBuilder.Append(characterPool[UnityEngine.Random.Range(0, characterPool.Length)]);
		}
		return stringBuilder.ToString();
	}

	public bool EncryptPartyDescriptor(string secret, out string encryptedSecret, out string salt, out string iv)
	{
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		try
		{
			byte[] array = new byte[32];
			_rngCsp.GetBytes(array);
			byte[] bytes = new Rfc2898DeriveBytes(password, array, 33333, HashAlgorithmName.SHA512).GetBytes(32);
			salt = Convert.ToBase64String(array);
			_aes.Key = bytes;
			_aes.GenerateIV();
			byte[] iV = _aes.IV;
			iv = Convert.ToBase64String(iV);
			using (ICryptoTransform transform = _aes.CreateEncryptor(_aes.Key, iV))
			{
				using MemoryStream memoryStream = new MemoryStream();
				using (CryptoStream stream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write))
				{
					using StreamWriter streamWriter = new StreamWriter(stream);
					streamWriter.Write("gameid:" + secret);
				}
				encryptedSecret = Convert.ToBase64String(memoryStream.ToArray());
			}
			stopwatch.Stop();
			long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
			UnityEngine.Debug.Log($"encrypted party descriptor in {elapsedMilliseconds} ms");
			return true;
		}
		catch (Exception exception)
		{
			UnityEngine.Debug.LogException(exception);
			encryptedSecret = (salt = (iv = null));
			return false;
		}
	}

	public bool DecryptPartyDescriptor(string encryptedSecret, string salt, string iv, out string decryptedSecret)
	{
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		try
		{
			byte[] salt2 = Convert.FromBase64String(salt);
			byte[] iV = Convert.FromBase64String(iv);
			byte[] buffer = Convert.FromBase64String(encryptedSecret);
			byte[] bytes = new Rfc2898DeriveBytes(password, salt2, 33333, HashAlgorithmName.SHA512).GetBytes(32);
			_aes.Key = bytes;
			_aes.IV = iV;
			using (ICryptoTransform transform = _aes.CreateDecryptor(_aes.Key, _aes.IV))
			{
				using MemoryStream stream = new MemoryStream(buffer);
				using CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Read);
				using StreamReader streamReader = new StreamReader(stream2);
				decryptedSecret = streamReader.ReadToEnd();
				if (!decryptedSecret.StartsWith("gameid:"))
				{
					return false;
				}
				decryptedSecret = decryptedSecret.Substring("gameid:".Length);
			}
			stopwatch.Stop();
			long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
			UnityEngine.Debug.Log($"decrypted party descriptor in {elapsedMilliseconds} ms");
			return true;
		}
		catch (Exception)
		{
			UnityEngine.Debug.Log("failed to decrypt party descriptor");
			decryptedSecret = null;
			return false;
		}
	}

	public override string ToString()
	{
		return fullId;
	}
}
