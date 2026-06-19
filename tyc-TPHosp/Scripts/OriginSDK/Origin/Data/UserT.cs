using System.Xml.Serialization;

namespace Origin.Data
{
	public class UserT
	{
		[XmlAttribute]
		public string EAID;

		[XmlAttribute]
		public ulong UserId;

		[XmlAttribute]
		public ulong PersonaId;
	}
}
