using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

public class XmlSerializerHelper
{
	public static string SerializeObject(object obj)
	{
		try
		{
			string text = null;
			MemoryStream stream = new MemoryStream();
			XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());
			Encoding encoding = Encoding.GetEncoding("ISO-8859-1");
			XmlTextWriter xmlTextWriter = new XmlTextWriter(stream, encoding);
			xmlSerializer.Serialize(xmlTextWriter, obj);
			stream = (MemoryStream)xmlTextWriter.BaseStream;
			return encoding.GetString(stream.ToArray());
		}
		catch (Exception message)
		{
			Debug.LogError(message);
			return null;
		}
	}

	public static T DeserializeObject<T>(string xml)
	{
		try
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
			Encoding encoding = Encoding.GetEncoding("ISO-8859-1");
			MemoryStream stream = new MemoryStream(encoding.GetBytes(xml));
			return (T)xmlSerializer.Deserialize(stream);
		}
		catch (Exception message)
		{
			Debug.LogError(message);
			return default(T);
		}
	}

	public static byte[] StringToByteArray(string s)
	{
		byte[] array = new byte[s.Length];
		for (int i = 0; i < s.Length; i++)
		{
			array[i] = (byte)s[i];
		}
		return array;
	}

	public static string ByteArrayToString(byte[] b)
	{
		string text = string.Empty;
		for (int i = 0; i < b.Length; i++)
		{
			text += (char)b[i];
		}
		return text;
	}
}
