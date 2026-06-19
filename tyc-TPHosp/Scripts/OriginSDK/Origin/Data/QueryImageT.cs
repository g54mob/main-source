using System.Xml.Serialization;

namespace Origin.Data
{
	public class QueryImageT
	{
		[XmlAttribute]
		public string ImageId;

		[XmlAttribute]
		public int Width;

		[XmlAttribute]
		public int Height;
	}
}
