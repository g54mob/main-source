using System;
using System.IO;
using System.Security.Cryptography;
using UnityEngine;

namespace MoreMountains.Tools
{
	public class MMSaveLoadManagerMethodJsonEncrypted : MMSaveLoadManagerEncrypter, IMMSaveLoadManagerMethod
	{
		public void Save(object objectToSave, FileStream saveFile)
		{
			string value = JsonUtility.ToJson(objectToSave);
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using StreamWriter streamWriter = new StreamWriter(memoryStream);
				streamWriter.Write(value);
				streamWriter.Flush();
				memoryStream.Position = 0L;
				Encrypt(memoryStream, saveFile, Key);
			}
			saveFile.Close();
		}

		public object Load(Type objectType, FileStream saveFile)
		{
			object result = null;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using StreamReader streamReader = new StreamReader(memoryStream);
				try
				{
					Decrypt(saveFile, memoryStream, Key);
				}
				catch (CryptographicException ex)
				{
					Debug.LogError("[MMSaveLoadManager] Encryption key error: " + ex.Message);
					return null;
				}
				memoryStream.Position = 0L;
				result = JsonUtility.FromJson(streamReader.ReadToEnd(), objectType);
			}
			saveFile.Close();
			return result;
		}
	}
}
