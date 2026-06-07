using System.IO;
using System.Text;
using System.Xml.Linq;

namespace Jundroo.Common.Extensions
{
	public static class XDocumentExtensions
	{
		public static byte[] SaveAsBytes(this XDocument xml)
		{
			using MemoryStream memoryStream = new MemoryStream();
			xml.Save(memoryStream);
			memoryStream.Position = 0L;
			return memoryStream.ToArray();
		}

		public static byte[] SaveAsBytes(this XDocument xml, SaveOptions options)
		{
			using MemoryStream memoryStream = new MemoryStream();
			xml.Save(memoryStream, options);
			memoryStream.Position = 0L;
			return memoryStream.ToArray();
		}

		public static string SaveAsString(this XDocument xml)
		{
			using MemoryStream memoryStream = new MemoryStream();
			xml.Save(memoryStream);
			memoryStream.Position = 0L;
			return Encoding.UTF8.GetString(memoryStream.ToArray());
		}

		public static string SaveAsString(this XDocument xml, SaveOptions options)
		{
			using MemoryStream memoryStream = new MemoryStream();
			xml.Save(memoryStream, options);
			memoryStream.Position = 0L;
			return Encoding.UTF8.GetString(memoryStream.ToArray());
		}
	}
}
