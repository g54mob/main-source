using System.Xml.Serialization;

namespace Origin.Data
{
	public class EventParamT
	{
		[XmlAttribute]
		public string Name;

		[XmlAttribute]
		public string Value;
	}
}
