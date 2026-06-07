using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public static class StorableUtilities
{
	public enum LoadResult
	{
		Success = 0,
		Failed_HeaderHashMismatch = 1,
		Failed_InvalidHeader = 2
	}

	public static string GenerateFilename(string prefix, string extension, string playerId)
	{
		return $"{prefix}{playerId}{extension}";
	}

	public static string GenerateFilename(string prefix, string extension, string playerId, string deviceId)
	{
		return $"{prefix}{deviceId}_{playerId}{extension}";
	}

	public static bool TryParseFilename(string filename, string prefix, string extension, out string playerId)
	{
		playerId = null;
		if (!filename.StartsWith(prefix))
		{
			return false;
		}
		if (!filename.EndsWith(extension))
		{
			return false;
		}
		int length = prefix.Length;
		int length2 = extension.Length;
		int num = filename.Length - (length + length2);
		if (num < 1)
		{
			return false;
		}
		playerId = filename.Substring(length, num);
		return true;
	}

	public static bool TryParseFilename(string filename, string prefix, string extension, out string playerId, out string deviceId)
	{
		playerId = null;
		deviceId = null;
		if (!filename.StartsWith(prefix))
		{
			return false;
		}
		if (!filename.EndsWith(extension))
		{
			return false;
		}
		int length = prefix.Length;
		int length2 = extension.Length;
		int num = filename.Length - (length + length2);
		if (num < 3)
		{
			return false;
		}
		string[] array = filename.Substring(length, num).Split('_');
		if (array.Length != 2)
		{
			return false;
		}
		deviceId = array[0];
		playerId = array[1];
		return true;
	}

	public static bool LoadJsonStorable(IJsonSerializableSaveData jsonStorable, byte[] data)
	{
		if (data == null || data.Length < 2)
		{
			return false;
		}
		bool flag = false;
		bool flag2 = false;
		if (data.Length >= 2)
		{
			bool num = data[0] == 254 && data[1] == byte.MaxValue;
			bool flag3 = data[0] == byte.MaxValue && data[1] == 254;
			flag2 = num || flag3;
			if (data.Length >= 3)
			{
				flag = data[0] == 239 && data[1] == 187 && data[2] == 191;
			}
			int num2 = 0;
			if (flag2)
			{
				num2 = 2;
			}
			if (flag)
			{
				num2 = 3;
			}
			if (num2 > 0)
			{
				byte[] array = new byte[data.Length - num2];
				Buffer.BlockCopy(data, num2, array, 0, data.Length - num2);
				data = array;
			}
		}
		if (!flag && !flag2 && data.Length >= 2)
		{
			flag2 = data[1] == 0;
		}
		string jsonText = ((!flag2) ? Encoding.UTF8.GetString(data) : Encoding.Unicode.GetString(data));
		if (!(JSON.LoadFromString(jsonText) is JSON.Dictionary jsonSaveData))
		{
			return false;
		}
		jsonStorable.InitializeWithJson(jsonSaveData);
		return true;
	}

	public static LoadResult LoadBinaryStorable(IBinarySerializableSaveData binaryStorable, byte[] data)
	{
		using MemoryStream input = new MemoryStream(data);
		using BinaryReader binaryReader = new BinaryReader(input);
		switch (binaryStorable.ValidateHeader(binaryReader))
		{
		case IBinarySerializableSaveData.HeaderValidationResult.Success:
		{
			byte[] saveDataAsBytes = binaryReader.ReadBytes((int)(binaryReader.BaseStream.Length - binaryReader.BaseStream.Position));
			binaryStorable.InitializeWithBytes(saveDataAsBytes);
			return LoadResult.Success;
		}
		case IBinarySerializableSaveData.HeaderValidationResult.HashCodesMismatched:
			return LoadResult.Failed_HeaderHashMismatch;
		case IBinarySerializableSaveData.HeaderValidationResult.InvalidHeader:
			return LoadResult.Failed_InvalidHeader;
		default:
			return LoadResult.Failed_InvalidHeader;
		}
	}

	public static byte[] StoreJsonStorable(IJsonSerializableSaveData jsonStorable)
	{
		Dictionary<string, object> dictionary = jsonStorable.SerializeToJson();
		if (dictionary == null)
		{
			return null;
		}
		return Encoding.Unicode.GetBytes(Json.Serialize(dictionary));
	}

	public static byte[] StoreBinaryStorable(IBinarySerializableSaveData binaryStorable)
	{
		try
		{
			using MemoryStream memoryStream = new MemoryStream();
			using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
			{
				binaryStorable.OnSerializeBeforeData(binaryWriter);
				binaryWriter.Write(binaryStorable.GetBytesForSerializing());
			}
			memoryStream.Close();
			return memoryStream.ToArray();
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
			return null;
		}
	}
}
