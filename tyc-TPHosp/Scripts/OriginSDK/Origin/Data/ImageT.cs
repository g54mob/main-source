using System.Xml.Serialization;

namespace Origin.Data
{
	public class ImageT
	{
		[XmlAttribute]
		public string ImageId;

		[XmlAttribute]
		public int Width;

		[XmlAttribute]
		public int Height;

		[XmlAttribute]
		public string ResourcePath;
	}
}
