using System.Xml.Serialization;

namespace Origin.Data
{
	public class MuteStateT
	{
		[XmlAttribute]
		public EnumMuteStateT State;

		[XmlAttribute]
		public ulong UserId;
	}
}
