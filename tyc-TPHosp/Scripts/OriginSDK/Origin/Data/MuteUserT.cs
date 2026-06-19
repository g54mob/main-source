using System.Xml.Serialization;

namespace Origin.Data
{
	public class MuteUserT
	{
		[XmlAttribute]
		public bool bMute;

		[XmlAttribute]
		public string GroupId;

		[XmlAttribute]
		public ulong UserId;
	}
}
