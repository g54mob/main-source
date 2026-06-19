using System.Xml.Serialization;

namespace Origin.Data
{
	public class IGOEventT
	{
		[XmlAttribute]
		public IGOStateT State;
	}
}
