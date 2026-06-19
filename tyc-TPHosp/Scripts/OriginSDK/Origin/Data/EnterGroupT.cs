using System.Xml.Serialization;

namespace Origin.Data
{
	public class EnterGroupT
	{
		[XmlAttribute]
		public ulong UserId;

		[XmlAttribute]
		public string GroupId;
	}
}
