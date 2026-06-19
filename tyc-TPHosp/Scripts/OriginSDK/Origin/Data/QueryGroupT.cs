using System.Xml.Serialization;

namespace Origin.Data
{
	public class QueryGroupT
	{
		[XmlAttribute]
		public ulong UserId;

		[XmlAttribute]
		public string GroupId;
	}
}
