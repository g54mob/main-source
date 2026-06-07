namespace Crosstales.Common.Util
{
	public abstract class XmlHelper
	{
		public static void SerializeToFile<T>(T obj, string filename)
		{
		}

		public static T DeserializeFromFile<T>(string filename, bool skipBOM = false)
		{
			return default(T);
		}

		public static string SerializeToString<T>(T obj)
		{
			return null;
		}

		public static T DeserializeFromString<T>(string xmlAsString, bool skipBOM = true)
		{
			return default(T);
		}

		public static T DeserializeFromResource<T>(string resourceName, bool skipBOM = true)
		{
			return default(T);
		}
	}
}
