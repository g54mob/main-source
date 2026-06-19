using System.Xml.Serialization;

namespace Origin.Data
{
	public class VoipStatusEventT
	{
		[XmlAttribute]
		public VoipStatusT Status;

		[XmlAttribute]
		public ulong UserId;
	}
}
