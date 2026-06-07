using System.Xml;

namespace Rewired.Utils
{
	public static class SerializationTools
	{
		public static string SerializeObjectToXmlString<T>(T obj)
		{
			return null;
		}

		public static void WriteXmlElement(XmlWriter writer, string name, object value)
		{
		}

		public static void WriteXmlElement<T>(XmlWriter writer, string name, T value)
		{
		}

		private static void jddSTstjxZlpgYXUzNsStuXTtOaQ(XmlWriter P_0, object P_1)
		{
		}

		public static string ReadXmlElement(XmlReader reader, string name)
		{
			return null;
		}

		public static T ReadXmlElement<T>(XmlReader reader, string name)
		{
			return default(T);
		}

		public static bool TryReadXmlElement(XmlReader reader, string name, out string outValue)
		{
			outValue = null;
			return false;
		}

		public static bool TryReadXmlElement<T>(XmlReader reader, string name, out T outValue)
		{
			outValue = default(T);
			return false;
		}

		public static bool TryReadXmlElement<T>(XmlReader reader, string name, out T outValue, T defaultValue)
		{
			outValue = default(T);
			return false;
		}

		public static bool TryReadXmlStartElement(XmlReader reader, string name, out bool isEmpty)
		{
			isEmpty = default(bool);
			return false;
		}

		public static bool TryReadXmlEndElement(XmlReader reader)
		{
			return false;
		}

		public static string CleanInvalidXmlChars(string text)
		{
			return null;
		}
	}
}
