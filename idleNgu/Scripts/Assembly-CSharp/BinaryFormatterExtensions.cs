using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class BinaryFormatterExtensions
{
	public static string SerializeToString(BinaryFormatter formatter, PlayerData value)
	{
		using (MemoryStream memoryStream = new MemoryStream())
		{
			formatter.Serialize(memoryStream, value);
			memoryStream.Flush();
			return Convert.ToBase64String(memoryStream.ToArray());
		}
	}

	public static string SerializeToString(BinaryFormatter formatter, SaveData value)
	{
		using (MemoryStream memoryStream = new MemoryStream())
		{
			formatter.Serialize(memoryStream, value);
			memoryStream.Flush();
			return Convert.ToBase64String(memoryStream.ToArray());
		}
	}

	public static SaveData DeserializeFromString(BinaryFormatter formatter, string data)
	{
		using (MemoryStream serializationStream = new MemoryStream(Convert.FromBase64String(data)))
		{
			return (SaveData)formatter.Deserialize(serializationStream);
		}
	}

	public static PlayerData DeserializePlayerDataFromString(BinaryFormatter formatter, string data)
	{
		using (MemoryStream serializationStream = new MemoryStream(Convert.FromBase64String(data)))
		{
			return (PlayerData)formatter.Deserialize(serializationStream);
		}
	}
}
