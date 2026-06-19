using System.Xml.Serialization;

namespace Origin.Data
{
	public class IsFileDownloadedResponseT
	{
		[XmlAttribute]
		public string ItemId;

		[XmlAttribute]
		public string Filepath;

		[XmlAttribute]
		public bool Downloaded;
	}
}
