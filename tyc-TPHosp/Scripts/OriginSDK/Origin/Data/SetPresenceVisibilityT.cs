using System.Xml.Serialization;

namespace Origin.Data
{
	public class SetPresenceVisibilityT
	{
		[XmlAttribute]
		public ulong UserId;

		[XmlAttribute]
		public bool Visible;
	}
}
