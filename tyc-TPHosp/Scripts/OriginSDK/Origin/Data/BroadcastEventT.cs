using System.Xml.Serialization;

namespace Origin.Data
{
	public class BroadcastEventT
	{
		[XmlAttribute]
		public BroadcastStateT State;
	}
}
