using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SerialisationHelpers
{
	public static byte[] SerializeBinary(object objectToSerialize)
	{
		MemoryStream memoryStream = SerializeToStream(objectToSerialize);
		try
		{
			byte[] array = new byte[16384];
			using MemoryStream memoryStream2 = new MemoryStream();
			memoryStream.Position = 0L;
			int count;
			while ((count = memoryStream.Read(array, 0, array.Length)) > 0)
			{
				memoryStream2.Write(array, 0, count);
			}
			return memoryStream2.ToArray();
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
		}
		return new byte[0];
	}

	public static MemoryStream SerializeToStream<T>(T objectToSerialize)
	{
		try
		{
			MemoryStream memoryStream = new MemoryStream();
			new BinaryFormatter().Serialize(memoryStream, objectToSerialize);
			return memoryStream;
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
		}
		return null;
	}

	public static bool DeserializeFromStream<T>(MemoryStream stream, out T deserializedObject)
	{
		deserializedObject = default(T);
		if (stream.Length > 0)
		{
			try
			{
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				stream.Seek(0L, SeekOrigin.Begin);
				deserializedObject = (T)binaryFormatter.Deserialize(stream);
				return true;
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}
		return false;
	}

	public static bool DeserializeBinary<T>(byte[] data, out T deserialzedObject)
	{
		deserialzedObject = default(T);
		try
		{
			MemoryStream memoryStream = new MemoryStream();
			memoryStream.Write(data, 0, data.Length);
			DeserializeFromStream<T>(memoryStream, out deserialzedObject);
			return true;
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
		}
		return false;
	}
}
