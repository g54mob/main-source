using System.Xml.Serialization;

namespace Origin.Data
{
	public class IsFileDownloadedT
	{
		[XmlAttribute]
		public string ItemId;

		[XmlAttribute]
		public string Filepath;
	}
}
