using System.Xml.Serialization;

namespace Origin.Data
{
	public class RestartGameT
	{
		[XmlAttribute]
		public ulong UserId;

		[XmlAttribute]
		public RestartOptionsT Options;
	}
}
