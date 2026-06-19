using System.Xml.Serialization;

namespace Origin.Data
{
	public class ProfileEventT
	{
		[XmlAttribute]
		public ProfileStateChangeT Changed;

		[XmlAttribute]
		public ulong UserId;
	}
}
