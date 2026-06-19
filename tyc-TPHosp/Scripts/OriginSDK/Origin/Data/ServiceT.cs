using System.Xml.Serialization;

namespace Origin.Data
{
	public class ServiceT
	{
		[XmlAttribute]
		public string Name;

		[XmlAttribute]
		public FacilityT Facility;
	}
}
